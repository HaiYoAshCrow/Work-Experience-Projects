using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace USB_Reader
{
    public partial class UI_Form : Form
    {
        //Our communication interface with USB_ISS
        CMPS10_INTERFACE m_commInterface = new CMPS10_INTERFACE();
        pedometer_algorithm m_palgorithm;
        Stopwatch m_stopwatch;
        TimeSpan ts;

        //Flags
        bool m_calibrate = false;       //Device Calibration flag
        bool m_reset = false;           //Reset Device flag
        bool m_record = false;          //Record page flag
        bool m_recordAll = false;       //Record All flag
        bool m_devExists = false;       //Device exists flag

        //File variables
        string datetimeString;

        //Drawing context
        SolidBrush m_brush;
        Graphics m_formGraphics;

        //Constructor
        public UI_Form()
        {
            InitializeComponent();
        }

        //Load everything here
        private void Form1_Load(object sender, EventArgs e)
        {
            m_devExists = m_commInterface.Open();   //Open our device for action
            m_palgorithm = new pedometer_algorithm(m_commInterface); //Initialize our pedometer algorithm 
            m_timer.Start();                        //Start the update timer

            //Gets time elapsed
            m_stopwatch = new Stopwatch();
            m_stopwatch.Start();

            //Check if our directories exist. If not, make them
            CheckDirectories();

            //Load the sensitivty ticker for the pedometer
            sensitivity_changer.TickFrequency = 1;
            sensitivity_changer.Maximum = 100;
            sensitivity_changer.Value = (int)m_palgorithm.step_thresh;
            step_thresh_label.Text = "Pedometer sensitivity Threshold: " + (int)m_palgorithm.step_thresh;
        
            //Show the general tab on startup
            compass_panel.Paint += new PaintEventHandler(general_tab_Paint);
        }

        //Create Log directories
        private void CheckDirectories()
        {
            if (!Directory.Exists("Log Files"))
            {
                Directory.CreateDirectory("Log Files");
                Directory.CreateDirectory("Log Files\\Accelometer Logs");
                Directory.CreateDirectory("Log Files\\General Logs");
                Directory.CreateDirectory("Log Files\\Magnetometer Logs");
                Directory.CreateDirectory("Log Files\\All Pages Logs");
            }
            else
            {   //Fill in the missing directories to organized our logs
                if (!Directory.Exists("Log Files\\Accelometer Logs"))
                {
                    Directory.CreateDirectory("Log Files\\Accelometer Logs");
                }
                if (!Directory.Exists("Log Files\\General Logs"))
                {
                    Directory.CreateDirectory("Log Files\\General Logs");
                }
                if (!Directory.Exists("Log Files\\Magnetometer Logs"))
                {
                    Directory.CreateDirectory("Log Files\\Magnetometer Logs");
                }
                if (!Directory.Exists("Log Files\\All Pages Logs"))
                {
                    Directory.CreateDirectory("Log Files\\All Page Logs");
                }

            }
        }

        //Close the window
        private void close_Click(object sender, EventArgs e)
        {
            m_timer.Stop();
            Application.Exit();
        }

        //Upon user selection of a tab, controls will be set according to information retrieved
        private void tab_selection(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabControl.TabPages["general_tab"])
            {
                general_tab.Controls.Add(this.compass_panel);
            }
            else if (tabControl.SelectedTab == tabControl.TabPages["raw_mag_tab"])
            {
                //Add Controls as we need them: re-using them since accel and mag share the same data
                #region AddControls
                this.raw_mag_tab.Controls.Add(this.high_z_display);
                this.raw_mag_tab.Controls.Add(this.high_y_display);
                this.raw_mag_tab.Controls.Add(this.high_x_display);
                this.raw_mag_tab.Controls.Add(this.high_z_label);
                this.raw_mag_tab.Controls.Add(this.high_y_label);
                this.raw_mag_tab.Controls.Add(this.high_x_label);
                this.raw_mag_tab.Controls.Add(this.tab_label);
                this.raw_mag_tab.Controls.Add(this.low_z_display);
                this.raw_mag_tab.Controls.Add(this.low_y_display);
                this.raw_mag_tab.Controls.Add(this.low_x_display);
                this.raw_mag_tab.Controls.Add(this.low_z_label);
                this.raw_mag_tab.Controls.Add(this.low_y_label);
                this.raw_mag_tab.Controls.Add(this.low_x_label);
                this.raw_mag_tab.Controls.Add(this.final_z_display);
                this.raw_mag_tab.Controls.Add(this.final_y_display);
                this.raw_mag_tab.Controls.Add(this.final_x_display);
                this.raw_mag_tab.Controls.Add(this.final_z_label);
                this.raw_mag_tab.Controls.Add(this.final_y_label);
                this.raw_mag_tab.Controls.Add(this.final_x_label);
                #endregion

                tab_label.Text = "Raw Magnometer Data";
            }
            else if (tabControl.SelectedTab == tabControl.TabPages["raw_accel_tab"])
            {
                #region AddControls
                //Add the controls as we need them
                this.raw_accel_tab.Controls.Add(this.high_z_display);
                this.raw_accel_tab.Controls.Add(this.high_y_display);
                this.raw_accel_tab.Controls.Add(this.high_x_display);
                this.raw_accel_tab.Controls.Add(this.high_z_label);
                this.raw_accel_tab.Controls.Add(this.high_y_label);
                this.raw_accel_tab.Controls.Add(this.high_x_label);
                this.raw_accel_tab.Controls.Add(this.tab_label);
                this.raw_accel_tab.Controls.Add(this.low_z_display);
                this.raw_accel_tab.Controls.Add(this.low_y_display);
                this.raw_accel_tab.Controls.Add(this.low_x_display);
                this.raw_accel_tab.Controls.Add(this.low_z_label);
                this.raw_accel_tab.Controls.Add(this.low_y_label);
                this.raw_accel_tab.Controls.Add(this.low_x_label);
                this.raw_accel_tab.Controls.Add(this.final_z_display);
                this.raw_accel_tab.Controls.Add(this.final_y_display);
                this.raw_accel_tab.Controls.Add(this.final_x_display);
                this.raw_accel_tab.Controls.Add(this.final_z_label);
                this.raw_accel_tab.Controls.Add(this.final_y_label);
                this.raw_accel_tab.Controls.Add(this.final_x_label);
                #endregion

                tab_label.Text = "Raw Accelerator Data";
            }
            else if (tabControl.SelectedTab == tabControl.TabPages["dev_info_tab"])
            {
                //Additional Logic goes here
            }
        }

        //Draw a compass
        private void general_tab_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Red);
            p.Width = 3;
            SolidBrush r = new SolidBrush(Color.Red);
            SolidBrush b = new SolidBrush(Color.Blue);
            SolidBrush s = new SolidBrush(Color.Silver);
            e.Graphics.FillEllipse(s, 0, 0, 75, 75);

            Matrix m = new Matrix();
            Matrix t = new Matrix();
            m.Translate(35, 35);
            m.Rotate(m_commInterface.correction, MatrixOrder.Prepend);
            //t.Invert();

            //m.Multiply(t, MatrixOrder.Append);
            e.Graphics.Transform = m;

            //e.Graphics.TranslateTransform(35, 35);
            //e.Graphics.RotateTransform(Convert.ToInt16(m_commInterface.GetHeading()),MatrixOrder.Prepend);
            //e.Graphics.TranslateTransform(-22, -6);
            //e.Graphics.ScaleTransform(0.05f, 0.10f,MatrixOrder.Prepend);


            e.Graphics.DrawLine(p,new Point(0,0),new Point(5,35 ));
            //e.Graphics.FillPolygon(r, new Point[] { new Point(300, 100), new Point(400, 300), new Point(300, 500), new Point(200, 300) });
            e.Graphics.ResetTransform();

            Font myFont = new Font("Arial", 10);
            e.Graphics.DrawString("N", myFont, b, 30, 0);
            e.Graphics.DrawString("S", myFont, b, 30, 60);
            e.Graphics.DrawString("E", myFont, b, 60, 30);
            e.Graphics.DrawString("W", myFont, b, 0, 30);

            e.Graphics.Flush();
        }

        //This will constantly update our device information so long the program is running
        private void timer_Tick(object sender, EventArgs e)
        {
            //Update our device status
            m_devExists = m_commInterface.connected;
            //Update file time
            if (!m_record && !m_recordAll)
            {
                datetimeString = string.Format("{0:hh-mm-ss-tt}", DateTime.Now);
            }

            //Don't want the device to be accessed during re-configuration or if it doesn't exist!
            if (!m_calibrate && !m_reset && m_devExists)
            {
                //Only update according to tab selected. This way we save processing power
                if (tabControl.SelectedTab == tabControl.TabPages["general_tab"])
                {
                    pitch_display.Text = m_commInterface.GetPitch();
                    roll_display.Text = m_commInterface.GetRoll();
                    hangle_display.Text = m_commInterface.GetAngle();
                    step_display.Text = m_palgorithm.steps.ToString();
                    dist_trav_display.Text = m_palgorithm.distance.ToString();
                    heading_display.Text = m_commInterface.GetHeading();

                    
                    //Set our cardinal direction according to a fuzzy logic set
                    int n = Convert.ToInt32(m_commInterface.GetHeading());

                    if (n == 360 || (n >= 0 && n <= 45 ))
                    {
                        cardinal_disp.Text = "North";
                    }
                    else if (n >= 45 &&  n <= 90)
                    {
                        cardinal_disp.Text = "North East";
                    }
                    else if (n >= 90 && n <= 135)
                    {
                        cardinal_disp.Text = "East";
                    }
                    else if (n >= 135 && n <= 180)
                    {
                        cardinal_disp.Text = "South East";
                    }
                    else if (n >= 180 && n <=225)
                    {
                        cardinal_disp.Text = "South";
                    }
                    else if (n >= 225 && n <= 280)
                    {
                        cardinal_disp.Text = "South West";
                    }
                    else if (n >= 280 && n <= 325)
                    {
                        cardinal_disp.Text = "West";
                    }
                    else if (n >= 325 && n <= 360)
                    {
                        cardinal_disp.Text = "North West";
                    }

                    if (m_record)
                    {
                        string mystr = (m_commInterface.GetPitch()
                                        + " " + m_commInterface.GetRoll()
                                        + " " + m_commInterface.GetAngle());


                        PrintLog(mystr, "Log Files\\General Logs\\General Log - " + datetimeString + ".txt");
                    }

                    //Need this for paint to work
                    //compass_panel.Invalidate();
                    compass_panel.Refresh();
                }
                else if (tabControl.SelectedTab == tabControl.TabPages["raw_mag_tab"])
                {
                    //Set magnitude values
                    string[] magnetometer_coords = new string[9];
                    magnetometer_coords = m_commInterface.GetMagnitude();

                    low_x_display.Text = magnetometer_coords[0];
                    high_x_display.Text = magnetometer_coords[1];
                    final_x_display.Text = magnetometer_coords[2];

                    low_y_display.Text = magnetometer_coords[3];
                    high_y_display.Text = magnetometer_coords[4];
                    final_y_display.Text = magnetometer_coords[5];

                    low_z_display.Text = magnetometer_coords[6];
                    high_z_display.Text = magnetometer_coords[7];
                    final_z_display.Text = magnetometer_coords[8];

                    if (m_record)
                    {
                        string mystr = (magnetometer_coords[0]
                                        + " " + magnetometer_coords[2]
                                        + " " + magnetometer_coords[3]
                                        + " " + magnetometer_coords[5]
                                        + " " + magnetometer_coords[6]
                                        + " " + magnetometer_coords[8]);

                        PrintLog(mystr, "Log Files\\Magnetometer Logs\\Magnetometer Log - " + datetimeString + ".txt");
                    }
                }
                else if (tabControl.SelectedTab == tabControl.TabPages["raw_accel_tab"])
                {
                    //Set accleration values
                    string[] accel_coords = new string[9];
                    accel_coords = m_commInterface.GetAcceleration();

                    low_x_display.Text = accel_coords[0];
                    high_x_display.Text = accel_coords[1];
                    final_x_display.Text = accel_coords[2];

                    low_y_display.Text = accel_coords[3];
                    high_y_display.Text = accel_coords[4];
                    final_y_display.Text = accel_coords[5];

                    low_z_display.Text = accel_coords[6];
                    high_z_display.Text = accel_coords[7];
                    final_z_display.Text = accel_coords[8];

                    //Output data to a log file
                    if (m_record)
                    {
                        string mystr = (accel_coords[0]
                                        + " " + accel_coords[2]
                                        + " " + accel_coords[3]
                                        + " " + accel_coords[5]
                                        + " " + accel_coords[6]
                                        + " " + accel_coords[8]);

                        PrintLog(mystr, "Log Files\\Accelometer Logs\\Accelerator Log - " + datetimeString + ".txt");     
                    }
                }
                else if (tabControl.SelectedTab == tabControl.TabPages["dev_info_tab"])
                {
                    string [] m_devInformation = m_commInterface.GetDeviceInformation();
                    dev_found_display.Text = m_devInformation[0];
                    ver_display.Text = m_devInformation[1];
                }

                if (m_recordAll)
                {
                    string[] magnetometer_coords = new string[9];
                    magnetometer_coords = m_commInterface.GetMagnitude();
                    string magStr = (magnetometer_coords[0]
                                        + " " + magnetometer_coords[2]
                                        + " " + magnetometer_coords[3]
                                        + " " + magnetometer_coords[5]
                                        + " " + magnetometer_coords[6]
                                        + " " + magnetometer_coords[8]);

                    string[] accel_coords = new string[9];
                    accel_coords = m_commInterface.GetAcceleration();
                    string accelStr = (accel_coords[0]
                                        + " " + accel_coords[2]
                                        + " " + accel_coords[3]
                                        + " " + accel_coords[5]
                                        + " " + accel_coords[6]
                                        + " " + accel_coords[8]);

                    string generalStr = (m_commInterface.GetPitch()
                                      + " " + m_commInterface.GetRoll()
                                      + " " + m_commInterface.GetAngle());

                    string a = "Magnetometer: " + magStr + "\n";
                    string b = "Accelerometer: " + accelStr + "\n";
                    string c = "General: " + generalStr + "\n";

                    PrintLog(a, "Log Files\\All Pages Logs\\Everything - mag - " + datetimeString + ".txt");
                    PrintLog(b, "Log Files\\All Pages Logs\\Everything - accel - " + datetimeString + ".txt");
                    PrintLog(c, "Log Files\\All Pages Logs\\Everything - angle - " + datetimeString + ".txt"); 
                }

                //Update the pedometer algorithm
                ts = m_stopwatch.Elapsed;                   //Grab elapsed time
                m_palgorithm.CalculateSteps(ts.Seconds);    //Update Algorithm
                
            }

        }

        //Prints out a log for us based on input string.
        private void PrintLog(string str, string filename)
        {
            CheckDirectories(); //Check if directories exist. If not make them
            using (StreamWriter outFile = new StreamWriter(filename, true))
            {
                outFile.WriteLine(str);
            }             
        }

        //Clears the log directory
        private void ClearLogs()
        {
            CheckDirectories(); //Check if directories exist. If not make them

            string[] gen = Directory.GetFiles("Log Files\\General Logs", "*.txt");
            string[] ace = Directory.GetFiles("Log Files\\Accelometer Logs", "*.txt");
            string[] mag = Directory.GetFiles("Log Files\\Magnetometer Logs", "*.txt");
            string[] all = Directory.GetFiles("Log Files\\All Pages Logs");

            foreach (string x in gen)
            {
                File.Delete(x);
            }

            foreach (string y in ace)
            {
                File.Delete(y);
            }

            foreach (string z in mag)
            {
                File.Delete(z);
            }

            foreach (string w in all)
            {
                File.Delete(w);
            }
        }

        //Calibration button
        private void calib_button_Click(object sender, EventArgs e)
        {
            m_timer.Stop();               //Stop the timer, stop updating
            m_calibrate = true;             //Ensure our program doesn't continue
            m_commInterface.Calibrate();  //Calibrate the device
            m_calibrate = false;            //Continue the program after we've finished
            m_timer.Start();              //Stop the timer, stop updating
        }

        //Reset button
        private void reset_button_Click(object sender, EventArgs e)
        {
            m_timer.Stop();
            m_reset = true;
            m_commInterface.RestoreSettings();
            m_reset = false;
            m_timer.Start();
        }

        //Clear the logs directory
        private void clear_log_button_Click(object sender, EventArgs e)
        {
            var v = MessageBox.Show("This will clear everything from your logs directory. Are you sure you want to continue?","Clearing Logs", MessageBoxButtons.YesNo);
            if (v == DialogResult.Yes)
            {
                ClearLogs();
            }
        }

        //Allows users to view logs
        private void view_log_button_Click(object sender, EventArgs e)
        {
            CheckDirectories(); //If the user has deleted the directories, new ones will be created
            System.Diagnostics.Process.Start("Log Files");
        }

        private void restart_button_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void record_all_button_Click(object sender, EventArgs e)
        {
            if (m_devExists)
            {
                if (!m_recordAll)
                {
                    m_recordAll = true;
                    record_status.Text = "Recording Status: True";
                    rec_all_button.BackColor = (Color.Green);
                    tabControl.Enabled = false;
                    rec_button.Enabled = false;
                    clear_log_button.Enabled = false;
                    view_log_button.Enabled = false;
                }
                else if (m_recordAll)
                {
                    m_recordAll = false;
                    record_status.Text = "Recording Status: False";
                    rec_all_button.BackColor = (Color.Red);
                    tabControl.Enabled = true;
                    rec_button.Enabled = true;
                    clear_log_button.Enabled = true;
                    view_log_button.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Error! Cannot open device.!", "No Device");
            }
        }

        //Enables data recording
        private void record_Click(object sender, EventArgs e)
        {
            if (m_devExists)
            {
                if (!m_record)
                {
                    m_record = true;
                    record_status.Text = "Recording Status: True";
                    rec_button.BackColor = (Color.Green);
                    tabControl.Enabled = false;
                    rec_all_button.Enabled = false;
                    clear_log_button.Enabled = false;
                    view_log_button.Enabled = false;
                }
                else if (m_record)
                {
                    m_record = false;
                    record_status.Text = "Recording Status: False";
                    rec_button.BackColor = (Color.Red);
                    tabControl.Enabled = true;
                    rec_all_button.Enabled = true;
                    clear_log_button.Enabled = true;
                    view_log_button.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Error! Cannot open device.!", "No Device");
            }
        }

        private void sensitivity_changer_Scroll(object sender, EventArgs e)
        {
            m_palgorithm.step_thresh = sensitivity_changer.Value;
            step_thresh_label.Text = "Pedometer sensitivity Threshold: " + (int)m_palgorithm.step_thresh;
        }

    }
}
