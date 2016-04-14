using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace USB_Reader
{
    /**
     *  This class provides communcation between the USB-ISS and our interface.
     *  The purpose of this class is to establish a communication link and retrieve certain data
     *  based on the user's input.
     **/

    /**
     *  Operation flags in enum for our interface
     **/
    #region Operation Flags
    //Supposing communcation-mode flags for USB-ISS
    enum ISSModdes
    {
        IO_MODE = 0x00,
        IO_CHANGE = 0x10,
        I2C_S_20KHZ = 0x20,
        I2C_S_50KHZ = 0x30,
        I2C_S_100KHZ = 0x40,
        I2C_S_400KHZ = 0x50,
        IC2_H_100KHZ = 0x60,
        IC2_H_400KHZ = 0x70,
        IC2_H_1000KHZ = 0x80,
        SPI_MODE = 0x90,
        SERIAL = 0x01,
        CMD_REGISTER = 0x16
    };

    //Commands for device
    enum ISSCmd
    {
        ISS_VER = 0x01, 		// returns version num, 1 byte
        ISS_MODE = 0x02,		// returns ACK, NACK, 1 byte
        GET_SER_NUM=0x03,       // returns the serial number of the device

        I2C_SGL = 0x53,		    // 0x53 Read/Write single byte for non-registered devices
        I2C_AD0 = 0x54,			// 0x54 Read/Write multiple bytes for devices without internal address register
        I2C_AD1 = 0x55,			// 0x55 Read/Write multiple bytes for 1 byte addressed devices 
        I2C_AD2 = 0x56,			// 0x56 Read/Write multiple bytes for 2 byte addressed devices
        I2C_DIRECT = 0x57,		// 0x57 Direct control of I2C start, stop, read, write.
        ISS_CMD = 0x5A,		    // 0x5A 
        SPI_IO = 0x61,			// 0x61 SPI I/O
        SERIAL_IO = 0x62,       // 0x62
        SETPINS = 0x63,			// 0x63 [SETPINS] [pin states]
        GETPINS = 0x64,			// 0x64 
        GETAD = 0x65,			// 0x65 [GETAD] [pin to convert]
    };

    //Direct Commands
    enum ISSDirectCmd
    {
        I2CSRP = 0x00,			// Start/Stop Codes - 0x01=start, 0x02=restart, 0x03=stop, 0x04=nack
        I2CSTART,				// send start sequence
        I2CRESTART,				// send restart sequence
        I2CSTOP,				// send stop sequence
        I2CNACK,				// send NACK after next read
        I2CREAD = 0x20,		    // 0x20-0x2f, reads 1-16 bytes
        I2CWRITE = 0x30,		// 0x30-0x3f, writes next 1-16 bytes
    };

    //Error flags
    enum Reason
    {
        DEVICE = 0x01,      //No device found
        BUF_OVRFLW,         //Buffer overflow
        RD_OVRFLW,          //No room in buffer to read data
        WR_UNDERFLW         //Not enough data provided
    };

    //CMPS10 Commands
    enum CMPS10Cmd
    {
        IC2_AD1 = 0x55,       //IC2 Read Mode for a single byte
        READ_CMPS10 = 0xc1,   //Address of CMPS10 for read/write
        WRITE_CMPS10 = 0xc0,  //Address of CMPS10 for read/write
        IC2_255CMP = 0x01,    //Compass bearing for 0-255
        IC2_359CMP = 0x02,    //Compass bearing for 0-359
        IC2_PITCH = 0x04,     //Pitch
        IC2_ROLL = 0x05,      //Roll
        IC2_MAG_X = 0x0A,     //Magnetometer High X, Low X: 0x0B
        IC2_MAG_Y = 0x0C,     //Magnetometer High Y, Low Y: 0x0D
        IC2_MAG_Z = 0x0E,     //Magnetometer High Z, Low Z: 0x0E
        IC2_ACCEL_X = 0x10,   //Accelerator High X, Low X: 0x11
        IC2_ACCEL_Y = 0x12,   //Accelerator High Y, Low Y: 0x13
        IC2_ACCEL_Z = 0x14    //Accelerator High Z, Low Z: 0x15
    };
    #endregion

    class CMPS10_INTERFACE
    {
        static SerialPort USB_ISS;
        byte device_found = 0;
        byte[] serbuff = new byte[200];
        public bool connected = false;
        public float correction = 0;
        //Offset values
        int offsetAngle = 47;

        //Constructor
        public CMPS10_INTERFACE()
        {
            USB_ISS = new SerialPort();
        }

        public bool Open()
        {
            //Grab any ports/devices currently available.
            //At this stage there exists only one device so this should suffice*
            string[] s = SerialPort.GetPortNames();

            try
            {
                USB_ISS.Close();                  //Close any existing connections
                USB_ISS.PortName = s[0];          //Assign port to open. We'll need a method to search for the portnames but this will do for now
                USB_ISS.Parity = 0;               //Error flag
                USB_ISS.BaudRate = 19200;
                USB_ISS.StopBits = StopBits.Two;  //Allows detection of end-of-char for re-sync
                USB_ISS.DataBits = 8;             //How many bits is transfered
                USB_ISS.ReadTimeout = 500;        //How long til we stop trying to read
                USB_ISS.WriteTimeout = 500;       //How long til we stop trying to write
                USB_ISS.Open();                   //Open the port for reading/writing
                connected = true;
            }
            catch (IOException)
            {
                connected = false;
                MessageBox.Show("Device Connection has been lost.", "Lost Connection");
            }
            catch (Exception)
            {
                //Console.WriteLine("Error! Device not found.");
                MessageBox.Show("Error! Cannot open device.!", "No Device");
                return false;
                //Application.Exit();
            }
            return true;
        }

        //Clean up anything we've done here
        public void Close()
        {
            //If port is opened, close it
            if (USB_ISS.IsOpen)
            {
                try
                {
                    USB_ISS.Close();                  
                }
                catch (IOException)
                {
                    connected = false;
                    MessageBox.Show("Device Connection has been lost.", "Lost Connection");
                }
            }
        }

        //Check the status every now and then
        public bool UpdateDeviceStatus()
        {
            if (!Open())
            {
                return false;
            }

            return true;
        }

        //Calibrate Settings for the device
        public void Calibrate()
        {
            if (Open())
            {
                var result = MessageBox.Show("Entering Calibration Mode. Do you want to continue?","Calibration",MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Console.WriteLine("Starting callibration");
                    serbuff[0] = (byte)ISSCmd.I2C_AD1;
                    serbuff[1] = (byte)CMPS10Cmd.WRITE_CMPS10;
                    serbuff[2] = (byte)0x16;
                    serbuff[3] = 0x01;
                    serbuff[4] = (byte)0xF0;

                    Transmit(5);

                    MessageBox.Show("Please locate North and press Ok.", "Calibrating");
                    //Console.WriteLine("Locate North and press enter.");
                    //Console.ReadLine();
                    serbuff[0] = (byte)ISSCmd.I2C_AD1;
                    serbuff[1] = (byte)CMPS10Cmd.WRITE_CMPS10;
                    serbuff[2] = (byte)0x16;
                    serbuff[3] = 0x01;
                    serbuff[4] = (byte)0xF5;

                    Transmit(5);

                    MessageBox.Show("Please rotate 90 degrees East and press Ok.", "Calibrating");
                    //Console.WriteLine("Rotate 90 degrees East and press enter.");
                    //Console.ReadLine();
                    serbuff[0] = (byte)ISSCmd.I2C_AD1;
                    serbuff[1] = (byte)CMPS10Cmd.WRITE_CMPS10;
                    serbuff[2] = (byte)0x16;
                    serbuff[3] = 0x01;
                    serbuff[4] = (byte)0xF5;

                    Transmit(5);

                    MessageBox.Show("Please rotate 90 degrees South and press Ok.", "Calibrating");
                    //Console.WriteLine("Rotate 90 degrees South and press enter.");
                    //Console.ReadLine();
                    serbuff[0] = (byte)ISSCmd.I2C_AD1;
                    serbuff[1] = (byte)CMPS10Cmd.WRITE_CMPS10;
                    serbuff[2] = (byte)0x16;
                    serbuff[3] = 0x01;
                    serbuff[4] = (byte)0xF5;

                    Transmit(5);

                    MessageBox.Show("Please rotate 90 degrees West and press Ok.", "Calibrating");
                    //Console.WriteLine("Rotate 90 degrees West and press enter.");
                    //Console.ReadLine();
                    serbuff[0] = (byte)ISSCmd.I2C_AD1;
                    serbuff[1] = (byte)CMPS10Cmd.WRITE_CMPS10;
                    serbuff[2] = (byte)0x16;
                    serbuff[3] = 0x01;
                    serbuff[4] = (byte)0xF5;

                    Transmit(5);

                    Application.Restart();
                }
                else
                {
                    return;
                }
            }
        }

        //Restore factory settings incase we mess up
        public void RestoreSettings()
        {
            if (Open())
            {
                var result = MessageBox.Show("Warning: All settings will be lost! Do you want to continue?", "Resetting", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Console.WriteLine("Resetting system!");
                    Console.WriteLine("Writing flag 0x20");
                    serbuff[0] = (byte)ISSCmd.I2C_AD1;
                    serbuff[1] = (byte)CMPS10Cmd.WRITE_CMPS10;
                    serbuff[2] = (byte)0x16;
                    serbuff[3] = 0x01;
                    serbuff[4] = (byte)0x20;

                    Transmit(5);

                    Thread.Sleep(100);   //Wait a 100 milliseconds

                    Console.WriteLine("Writing flag 0x2A");
                    serbuff[0] = (byte)ISSCmd.I2C_AD1;
                    serbuff[1] = (byte)CMPS10Cmd.WRITE_CMPS10;
                    serbuff[2] = (byte)0x16;
                    serbuff[3] = 0x01;
                    serbuff[4] = (byte)0x2A;

                    Transmit(5);
                    Thread.Sleep(100);

                    Console.WriteLine("Writing flag 0x60");
                    serbuff[0] = (byte)ISSCmd.I2C_AD1;
                    serbuff[1] = (byte)CMPS10Cmd.WRITE_CMPS10;
                    serbuff[2] = (byte)0x16;
                    serbuff[3] = 0x01;
                    serbuff[4] = (byte)0x60;

                    Transmit(5);
                    Thread.Sleep(100);

                    Application.Restart();
                }
                else
                {
                    return;
                }
            }
        }

        /**
         *  This region contains all the methods needed to retrieve data from the CMPS10 device
         **/
        #region Get Information

        public string[] GetDeviceInformation()
        {
            string[] info = new string[2];

            serbuff[0] = 0x5A;                  //Tells the device that this incoming transmition is a command
            serbuff[1] = (byte)ISSCmd.ISS_VER;  //Tells the device to grab the version
            Transmit(2);
            Recieve(3);

            //If we've reached here, it means we've found the device and can communicate with it
            if (serbuff[0] == 7)
            {
                device_found = serbuff[1];      //Set the indicator to found along with it's version
                info[0] = string.Format("Found USBISS Version{0}\r\n", device_found);

                serbuff[0] = 0x5A;                      //USBISS Command
                serbuff[1] = (byte)ISSCmd.GET_SER_NUM;  //Grab revision  ver
                Transmit(2);                            //Send 2 bits with information/command
                Recieve(8);                             //Expect 8 bits in return

                string tmp = "";
                for (byte x = 0; x < 8; x++)
                {
                    tmp += char.ConvertFromUtf32(serbuff[x]);
                    info[1] = "Serial #" + tmp;
                }
            }

            return info;
        }

        //Gets the pitch in bytes from 0-255 representing a full circle.
        //A conversion algorithm has been applied to change it from unsigned to sign which leaves
        //the angle range to be from -85 to +85
        public string GetPitch()
        {
            serbuff[0] = (byte)CMPS10Cmd.IC2_AD1;
            serbuff[1] = (byte)CMPS10Cmd.READ_CMPS10;
            serbuff[2] = 0x04;
            serbuff[3] = 0x01;

            Transmit(4);
            Recieve(1);

            sbyte pitch = 0;
            if (serbuff[0] == 0x80)
            {
                pitch = (sbyte)-(pitch + 1);
            }
            else
            {
                pitch = (sbyte)serbuff[0];
            }

            pitch = (sbyte)serbuff[0];

            return pitch.ToString();
        }

        //Gets the roll in bytes from 0-255 representing a full circle.
        //A conversion algorithm has been applied to change it from unsigned to sign which leaves
        //the angle range to be from -85 to +85
        public string GetRoll()
        {
            serbuff[0] = (byte)CMPS10Cmd.IC2_AD1;
            serbuff[1] = (byte)CMPS10Cmd.READ_CMPS10;
            serbuff[2] = 0x05;
            serbuff[3] = 0x01;

            Transmit(4);
            Recieve(1);

            sbyte roll = 0;

            if (serbuff[0] == 0x80)
            {
                roll = (sbyte)-(roll + 1);
            }
            else
            {
                roll = (sbyte)serbuff[0];
            }

            return roll.ToString();
        }

        //Gets the angle in radians from 0 - 359.9
        public string GetAngle()
        {
            serbuff[0] = (byte)CMPS10Cmd.IC2_AD1;
            serbuff[1] = (byte)CMPS10Cmd.READ_CMPS10;
            serbuff[2] = (byte)CMPS10Cmd.IC2_359CMP;
            serbuff[3] = (byte)0x02;

            Transmit(4);
            Recieve(2);

            int angle = 0;
            angle = serbuff[0];
            angle = angle << 8;
            angle += serbuff[1];    
            angle /= 10;
            //angle -= offsetAngle;

            return angle.ToString();
        }

        //Gets the magnitude x, y and z
        public string [] GetMagnitude()
        {
            string[] coords = new string[9];

            byte xlow = 0;
            byte xhigh = 0;
            int xfinal = 0;

            byte ylow = 0;
            byte yhigh = 0;
            int yfinal;

            byte zlow = 0;
            byte zhigh = 0;
            int zfinal = 0;

            //Get the x value
            serbuff[0] = (byte)CMPS10Cmd.IC2_AD1;
            serbuff[1] = (byte)CMPS10Cmd.READ_CMPS10;
            serbuff[2] = (byte)CMPS10Cmd.IC2_MAG_X;
            serbuff[3] = (byte)0x02;
            
            Transmit(4);
            Recieve(2);

            xlow = (byte)serbuff[0];
            xhigh = (byte)serbuff[1];
            xfinal = BitConverter.ToInt16(new byte[2]{xhigh, xlow}, 0);

            coords[0] = xlow.ToString();
            coords[1] = xhigh.ToString();
            coords[2] = xfinal.ToString();

            //Get the y value
            serbuff[0] = (byte)CMPS10Cmd.IC2_AD1;
            serbuff[1] = (byte)CMPS10Cmd.READ_CMPS10;
            serbuff[2] = (byte)CMPS10Cmd.IC2_MAG_Y;
            serbuff[3] = (byte)0x02;

            Transmit(4);
            Recieve(2);

            ylow = (byte)serbuff[0];
            yhigh = (byte)serbuff[1];
            //yfinal = (int)((ylow << 8) | yhigh);    //Combine the x-low and x-high values together
            yfinal = BitConverter.ToInt16(new byte[2]{yhigh,ylow},0);

            coords[3] = ylow.ToString();
            coords[4] = yhigh.ToString();
            coords[5] = yfinal.ToString();

            //Get the z value
            serbuff[0] = (byte)CMPS10Cmd.IC2_AD1;
            serbuff[1] = (byte)CMPS10Cmd.READ_CMPS10;
            serbuff[2] = (byte)CMPS10Cmd.IC2_MAG_Z;
            serbuff[3] = (byte)0x02;

            Transmit(4);
            Recieve(2);

            zlow = (byte)serbuff[0];
            zhigh = (byte)serbuff[1];
            //zfinal = (int)((zlow << 8 )| zhigh);    //Combine the x-low and x-high values together
            zfinal = BitConverter.ToInt16(new byte[2] { zhigh, zlow }, 0);

            coords[6] = zlow.ToString();
            coords[7] = zhigh.ToString();
            coords[8] = zfinal.ToString();

            return coords;
        }

        //Get the Acceleration x,y,z
        public string[] GetAcceleration()
        {
            string[] coords = new string[9];

            byte xlow = 0;
            byte xhigh = 0;
            int xfinal = 0;

            byte ylow = 0;
            byte yhigh = 0;
            int yfinal = 0;

            byte zlow = 0;
            byte zhigh = 0;
            int zfinal = 0;

            //Get the x value
            serbuff[0] = (byte)CMPS10Cmd.IC2_AD1;
            serbuff[1] = (byte)CMPS10Cmd.READ_CMPS10;
            serbuff[2] = (byte)CMPS10Cmd.IC2_ACCEL_X;
            serbuff[3] = (byte)0x02;

            Transmit(4);
            Recieve(2);

            xlow = (byte)serbuff[0];
            xhigh = (byte)serbuff[1];
            //xfinal = (int)((xlow << 8) | xhigh);    //Combine the x-low and x-high values together
            xfinal = BitConverter.ToInt16(new byte[] { xhigh, xlow }, 0);

            coords[0] = xlow.ToString();
            coords[1] = xhigh.ToString();
            coords[2] = xfinal.ToString();

            serbuff[0] = (byte)CMPS10Cmd.IC2_AD1;
            serbuff[1] = (byte)CMPS10Cmd.READ_CMPS10;
            serbuff[2] = (byte)CMPS10Cmd.IC2_ACCEL_Y;
            serbuff[3] = (byte)0x02;

            Transmit(4);
            Recieve(2);

            ylow = (byte)serbuff[0];
            yhigh = serbuff[1];
            //yfinal = (int)((ylow << 8) | yhigh);    //Combine the x-low and x-high values together
            yfinal = BitConverter.ToInt16(new byte[] { yhigh, ylow }, 0);

            coords[3] = ylow.ToString();
            coords[4] = yhigh.ToString();
            coords[5] = yfinal.ToString();

            //Get the z value
            serbuff[0] = (byte)CMPS10Cmd.IC2_AD1;
            serbuff[1] = (byte)CMPS10Cmd.READ_CMPS10;
            serbuff[2] = (byte)CMPS10Cmd.IC2_ACCEL_Z;
            serbuff[3] = (byte)0x02;

            Transmit(4);
            Recieve(2);

            zlow = (byte)serbuff[0];
            zhigh = serbuff[1];
            //zfinal = (int)((zlow << 8) | zhigh);    //Combine the x-low and x-high values together
            zfinal = BitConverter.ToInt16(new byte[] { zhigh, zlow }, 0);

            coords[6] = zlow.ToString();
            coords[7] = zhigh.ToString();
            coords[8] = zfinal.ToString();

            return coords;
        }

        //Calculates the heading and returns it as a string
        public string GetHeading()
        {
            string hString;
            string[] magneto_data = GetMagnitude();
            string[] accel_data = GetAcceleration();

            float m_x = Convert.ToInt16(magneto_data[2]);
            float m_y = Convert.ToInt16(magneto_data[5]);
            float m_z = Convert.ToInt16(magneto_data[8]);

            float a_x = Convert.ToInt16(accel_data[2]);
            float a_y = Convert.ToInt16(accel_data[5]);
            float a_z = Convert.ToInt16(accel_data[8]);

            //Note: Since the device pitch and roll only will go up to -/+85 degrees, we may have to calculate our
            //own pitch and roll unless the lock between those values are desired
            float pitch = Convert.ToInt32(GetPitch());
            pitch = (float)(pitch * (Math.PI / 180));
            float roll = Convert.ToInt32(GetRoll());
            roll = (float)(roll * (Math.PI / 180));

            //Pitch and roll from accelerator
            float a_pitch = (float)Math.Atan(a_x / (Math.Sqrt(a_y * a_y + a_z * a_z)));
            float a_roll = (float)Math.Atan(a_y / (Math.Sqrt(a_x * a_x + a_z * a_z)));

            float vec_x = (float)((m_x * Math.Cos(pitch)) + (m_y * Math.Sin(roll) * Math.Sin(pitch)) - (m_z * Math.Cos(roll) * Math.Sin(pitch)));
            float vec_y = (float)((m_y * Math.Cos(roll)) + (m_z * Math.Sin(pitch)));

            float heading = 0;
            if (m_x == 0 && m_y > 0)
            {
                heading = 270;            
            }
            else if (m_x == 0 && m_y < 0)
            {
                heading = 90;
            }
            else if (m_x > 0 && m_y > 0)
            {
                heading = 360.0f - (float)(Math.Atan(m_y / m_x) * (180 / Math.PI));
            }
            else if (m_x > 0 && m_y < 0)
            {
                heading = -(float)(Math.Atan(m_y / m_x) * (180 / Math.PI));
            }
            else if (m_x < 0)
            {
                heading = 180-(float)(Math.Atan(m_y / m_x) * (180 / Math.PI));
            }

            correction = heading - 180;

            Console.WriteLine(correction.ToString());
            //Since these calculations are in radians, we need to convert them to degrees for them to be useful
            //heading += (float)Math.Atan(vec_y / vec_x);
            correction += (float)Math.Atan(vec_y / vec_x);
            //correction = heading - 180;
            hString = Convert.ToInt32(heading).ToString();
            return hString;
        }

        #endregion

        /**
         *  This section contains internal methods for the communication interface 
         **/

        #region Internal Methods

        /** TRANSMITTING DATA TO USB-ISS
         *  The format for writing/transmitting information to the device follows as in I2C mode: 
         *  [PRIMARY USB-ISS COMMAND] -> [DEVICE ADDRESS + READ/WRITE BUT] -> [DEVICE INTERNAL REGISTER] 
         *  -> [NUMBER OF DATA BYTES] -> [DATA BYTES]
         **/

        private void Transmit(byte b)
        {
            try
            {
                USB_ISS.Write(serbuff, 0, b);
            }
            catch (IOException)
            {
                connected = false;
                Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot transmit due to error. Please check flags and data.\n");
            }
        }

        /** TRANSMITTING DATA TO USB-ISS
         *  The format for recieving information from the device follows as in I2C mode: 
         *  [PRIMARY USB-ISS COMMAND] -> [DEVICE ADDRESS + READ/WRITE BUT] -> [ADDRESS REGISTER] 
         *  -> [NUMBER OF BYTES EXPECTED TO RECIEVE] 
         *  
         **/
        private void Recieve(byte b)
        {
            byte x;

            for (x = 0; x < b; x++)
            {
                try
                {
                    USB_ISS.Read(serbuff, x, 1);    //Retrieve a byte a time at position x
                }
                catch (IOException)
                {
                    connected = false;
                    Close();
                }
                catch (Exception)
                {
                    serbuff[x] = 0x88;
                    Console.WriteLine("Cannot recieve due to error. Please check flags and data.\n");
                }
            }
        }

        #endregion

    }
}
