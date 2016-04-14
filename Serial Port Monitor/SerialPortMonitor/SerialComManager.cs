using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

/**
 * @description:  A simple serial port interface class that manages connections for our program
 * @last modified: 21/12/2012
 * @author: Tuan Nguyen
 */
namespace SerialPortMonitor
{
    class SerialComManager
    {
        #region variables
        private bool m_CallbackEnabled;                     //Toggles whether we want command callbacks or not
        private bool m_setFCS;                              //Toggles whether we want FCS on or not
        private string m_currentQuery;                      //Holds the current query string
        private bool m_justOpened;

        //INITIAL SETTINGS - NEEDS TO BE UPDATED FOR EASY CHANGE ACCESS
        SerialPort m_serialPort = new SerialPort();
        private int m_baudRate = 38400;
        private int m_dataBits = 8;
        private Parity m_parity = Parity.None;
        private string m_portName;
        private StopBits m_stopBits = StopBits.One;
        private string m_data;
        private List<string> m_dataList;
        public List<string> m_blindDataList;
        private string[] m_portList;

        #endregion

        #region methods

        /**
         *  @description: Default constructor
         *  @param: Nil
         *  @return: Nil
         */
        public SerialComManager()
        {
            m_portList = SerialPort.GetPortNames();
            m_dataList = new List<string> { };
            m_blindDataList = new List<string> { };
            m_setFCS = false;
            m_CallbackEnabled = false;
        }

        /**
         *  @description: Attempts to open a serial port
         *  @param: Nil
         *  @return: boolean
         */
        public void Open()
        {
            try
            {
                m_serialPort.BaudRate = m_baudRate;
                m_serialPort.DataBits = m_dataBits;
                m_serialPort.Parity = m_parity;
                m_serialPort.PortName = m_portName;
                m_serialPort.StopBits = m_stopBits;
                m_serialPort.RtsEnable = true;
                m_serialPort.Open();
                m_justOpened = true;
                m_serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataRecieved);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error! Could not open Serial port! Please check and try again.");        
            }
            Console.WriteLine("Serial port: " + m_serialPort.PortName + " has been opened.");
        }

        /**
         *  @description: Sends a message to the serial port
         *  @param: String
         *  @return: Nil
         */
        public bool Send(string hexString)
        {
            try
            {
                if (m_serialPort.CtsHolding == true)
                {
                    m_serialPort.DiscardInBuffer();
                    m_serialPort.DiscardOutBuffer();

                    byte[] mb = HexToBytes(hexString);

                    //Calculate the FCS for the message string
                    if (m_setFCS)
                    {
                        mb = CalculateFCS(mb);
                    }
                    if (m_CallbackEnabled)
                    {
                        m_currentQuery = "INPUTTED STRING: " + hexString + "\r" + "RESULT: ";
                    }
                    m_serialPort.Write(mb, 0, mb.Length);
                }
            }
            catch
            {
                Console.WriteLine("Could not send string");
                return false;
            }
            return true;
        }

        /**
         *  @description: Opens a buffer stream to the port and reads incoming data
         *  @param: Sender Object, SerialDataRecievedEventArgs
         *  @return: Nil
         */
        void _serialPort_DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            //If it's just been opened, clear the buffers to makesure no old data remains
            if (m_justOpened)
            {
                m_justOpened = false;
                m_serialPort.DiscardInBuffer();
                m_serialPort.DiscardOutBuffer();
            }
            else if(!m_justOpened)
            {
                try
                {
                    byte[] comBuffer;
                    List<byte> mb = new List<byte> { };
                    while (m_serialPort.BytesToRead > 0)
                    {
                        mb.Add((byte)m_serialPort.ReadByte());
                    }

                    comBuffer = mb.ToArray();
                    m_data = ByteToHex(comBuffer);
                    m_dataList.Add(m_data);
                }
                catch
                {
                    Console.WriteLine("Failed to read data.");
                }
            }    
        }

        /**
         *  @description: Converts a series of bytes to hexadecimal
         *  @param: byte array
         *  @return: string
         */
        private string ByteToHex(byte[] buffer)
        {
            StringBuilder builder = new StringBuilder(buffer.Length * 3);
            foreach (byte data in buffer)
            {
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            }
            return builder.ToString().ToUpper();
        }

        /**
         *  @description: Converts a hex-string to a byte array
         *  @param: byte array
         *  @return: string
         */
        private byte[] HexToBytes(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            byte[] bytes = new byte[hexString.Length/2];
            for (int i = 0; i < hexString.Length; i+=2)
            {
                bytes[i / 2] = (byte)Convert.ToByte(hexString.Substring(i, 2), 16);
            }

            return bytes;
        }

        /**
         *  @description: Closes the serial port after we've finished
         *  @param: Nil
         *  @return: Nil
         */
        public void Close()
        {
            Console.WriteLine("Closing port: " + m_serialPort.PortName + ".");
            m_serialPort.DataReceived -= _serialPort_DataRecieved;
            m_serialPort.Close();
        }

        /**
         *  @description: Retrieves data string from serial port
         *  @param: Nil
         *  @return: string list
         */
        public List<string> RetrieveData()
        {
            //Line formatting
            if (m_dataList.Count != 0)
            {
                m_dataList[m_dataList.Count - 1] += "\r" + "\r";

                //Check callback flag
                if (m_CallbackEnabled && m_currentQuery != null)
                {
                    m_dataList.Insert(0, m_currentQuery);
                }
            }

            return m_dataList;
        }

        /**
         *  @description: Sets the serial port
         *  @param: string
         *  @return: Nil
         */
        public void SetSerialPort(string portname)
        {
            m_portName = portname;
        }

        /**
         *  @description: Retrieves a list of ports
         *  @param: string
         *  @return: Nil
         */
        public string[] RetrievePortList()
        {
            return m_portList;
        }

        /**
         *  @description: Checks if port is opened
         *  @param: Nil
         *  @return: Nil
         */
        public bool Checkport()
        {
            return m_serialPort.IsOpen;
        }

        /**
         *  @description: Calculates the FCS flag for each message
         *  @param: byte array
         *  @return: byte array
         */
        private byte [] CalculateFCS(byte[] buffer)
        {
            //Skip the first element, calculate the FCS 
            int FCS = 0;
            for (int i = 1; i < buffer.Length; i++)
            {
                FCS ^= buffer[i];
            }

            //Conacatate the last element of the buffer with the FCS check flag
            List<byte> tempList = buffer.ToList();
            tempList.Add((byte)FCS);
            buffer = tempList.ToArray();

            return buffer;
        }

        /**
         *  @description: Clears the data list
         *  @param: Nil
         *  @return: Nil
         */
        public void ClearData()
        {
            m_dataList.Clear();
            m_blindDataList.Clear();
        }

        /**
         *  @description: Property setter/getter for the m_setFCS flag
         *  @param: boolean
         *  @return: boolean
         */
        public bool FCS
        {
            get
            {
                return m_setFCS;
            }
            set
            {
                m_setFCS = value;
            }
        }

        /**
         *  @description: Property setter/getter for the m_callbackEnabled flag
         *  @param: boolean
         *  @return: boolean
         */
        public bool Callback
        {
            get
            {
                return m_CallbackEnabled;
            }
            set
            {
                m_CallbackEnabled = value;
            }
        }
        #endregion
    }
}
