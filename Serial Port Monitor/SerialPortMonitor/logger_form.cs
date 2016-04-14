using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

/*  
 *  @description: A simple data logger for the CC2431. This file contains mainly the logic implementation
 *                of the logger's main page. Other pages and their logic has been respectively splitted to
 *                ensure easier tracking.
 *  @last modified: 21/12/2012
 *  @author: Tuan Nguyen
 */

namespace SerialPortMonitor
{
    //Custom struct to hold data in for combolists
    //Usage: new comboList.Add(new KEYPAIRVALUE(key = xx, value = yy))
    struct KEYPAIRVALUE
    {
        public string key { get; set; }
        public string value { get; set; }
    };

    public partial class logger_form : Form
    {
        //Variables
        private SerialComManager m_serialComManager;        //Manages serial com
        private bool m_isTimedLogging;                      //Enables logging over time
        private bool m_isLogging;                           //Logging toggle
        private bool m_saveToFile;                          //Save to file toggle
        private string m_datetimeString;                    //Holds current date time string for log files
        private StreamWriter writer;                        //Writer for log files
        private int m_retrieveInterval;                     //Holds ms of time we'll retrieve data from
        private Timer m_watcher;                            //Stop-timer
        /**  
         *  @description: Consctructor
         *  @param: Nil
         *  @returns: Nil
         */
        public logger_form()
        {
            InitializeComponent();
            m_serialComManager = new SerialComManager();
            m_isLogging = false;
            m_isTimedLogging = false;
            m_saveToFile = false;
            data_viewer.ReadOnly = true;
            data_viewer.ForeColor = Color.Green;
            custom_log_display.ForeColor = Color.Green;
            custom_log_display.ReadOnly = true;
            this.MaximizeBox = false;
            m_retrieveInterval = 1000;     //Every 5 seconds
            m_watcher = new Timer();
            m_watcher.Tick += new EventHandler(ticker);

            m_watcher.Interval = m_retrieveInterval;

            //Load port list
            foreach (string n in m_serialComManager.RetrievePortList())
            {
                serial_selector.Items.Add(n);
            }

            //Load query list
            query_selector.Items.Add(new KEYPAIRVALUE { key = "VERSION", value = string_definition.VERSION });
            query_selector.Items.Add(new KEYPAIRVALUE { key = "XY-RSSI REQUEST", value = string_definition.XY_RSSI_REQUEST });
            query_selector.Items.Add(new KEYPAIRVALUE { key = "BLIND NODE REQUEST", value = string_definition.BLIND_NODE_FIND_REQUEST });
            query_selector.ValueMember = "key";
            query_selector.DisplayMember = "key";
            timer1.Start();
        }

        /**
         *  @description: ticker for the stopwatch, executes function every few seconds
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void ticker(object sender, EventArgs e)
        {
            if(tab_control.SelectedTab == tab_control.TabPages["logger_page"])
            {
                ParseQuery();
                tab_control.SelectedTab = tab_control.TabPages["logger_page"];
            }
            else if (tab_control.SelectedTab == tab_control.TabPages["custom_page"])
            {
                ParseQuery(m_custom_msg);
                tab_control.SelectedTab = tab_control.TabPages["custom_page"];
            }
            
        }

        /**  
         *  @description: Overrides closing logic to implement own clean-up logic
         *  @param: Nil
         *  @returns: Nil
         */
        protected override void OnClosing(CancelEventArgs e)
        {
            m_serialComManager.Close();
            base.OnClosing(e);
        }

        /** 
         *  @description: event handler for selection changed
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void serial_selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_serialComManager.SetSerialPort(serial_selector.SelectedItem.ToString());
        }

        /**
         *  @description: event handler for capture button
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void capture_button_Click(object sender, EventArgs e)
        {
            if (!m_isLogging)
            {
                //Only query if we can open the port!
                if (m_serialComManager.Checkport() == true)
                {
                    //If time logging is enabled, enter logging mode else just call general query function
                    if (m_isTimedLogging)
                    {
                        m_isLogging = true;
                        //Save all the data to the log file
                        if (m_saveToFile)
                        {
                            m_datetimeString = string.Format("{0:hh-mm-ss-tt}", DateTime.Now);
                            writer = new StreamWriter("Log - " + m_datetimeString + " - default.txt");
                        }
                        m_watcher.Start();
                    }
                    else
                    {
                        ParseQuery();
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Port is not opened. Cannot send query!");
                }
            }
        }

        /**
         *  @description: event handler for stop button
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void stop_button_Click(object sender, EventArgs e)
        {
            if (m_isLogging)
            {
                m_isLogging = false;
            }
            m_watcher.Stop();
        }

        /**
         *  @description: update function based on program timer, keeps updating while condition is true
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            //If timer is enabled, do continous parsing
            //if (m_isTimedLogging && m_isLogging)
            //{         
            //    ParseQuery();
            //}

            //Update GUI based on status
            if (m_isTimedLogging == true)
            {
                timelog_checkbox_custom.Checked = true;
                timelog_checkbox_logger.Checked = true;
            }
            else if (m_isTimedLogging == false)
            {
                timelog_checkbox_custom.Checked = false;
                timelog_checkbox_logger.Checked = false;
            }

            if (m_serialComManager.Callback == true)
            {
                custom_callback_checkbox.Checked = true;
                callback_check_box_logger.Checked = true;
            }
            else if (m_serialComManager.Callback == false)
            {
                custom_callback_checkbox.Checked = false;
                callback_check_box_logger.Checked = false;
            }

            if (m_saveToFile == true)
            {
                file_save.Checked = true;
                file_save_custom.Checked = true;
            }
            else if(m_saveToFile == false)
            {
                file_save.Checked = false;
                file_save_custom.Checked = false;
            }

            //Only update the view if the port is opened for monitoring and the correct tab is selected
            if (m_serialComManager.Checkport())
            {
                if (tab_control.SelectedTab == tab_control.TabPages["logger_page"])
                {
                    List<string> l = m_serialComManager.RetrieveData();
                    if (l.Count != 0)
                    {
                        foreach (string s in l.ToList())
                        {
                            data_viewer.AppendText(s);
                            if (m_saveToFile)
                            {
                                writer.WriteLine(s);
                            }
                        }
                    }
                }
                else if (tab_control.SelectedTab == tab_control.TabPages["custom_page"])
                {
                    List<string> l = m_serialComManager.RetrieveData();
                    if (l.Count != 0)
                    {
                        foreach (string s in l.ToList())
                        {
                            custom_log_display.AppendText(s);
                            if (m_saveToFile)
                            {
                                writer.WriteLine(s);
                            }
                        }
                    }

                }

                //Clear the data after we've finished for the next batch
                m_serialComManager.ClearData();
            }
            
            //Check for which page is selected and load any special associated settings with it
            if (tab_control.SelectedTab == tab_control.TabPages["logger_page"])
            {
                m_serialComManager.FCS = false; //Disable the FCS calculations since they've already been defined
            }
        }

        /**
         *  @description: grabs the list of queries and parses them
         *  @param: Nil
         *  @returns: Nil
         */
        private void ParseQuery(string msg = "")
        {
            if (tab_control.SelectedTab == tab_control.TabPages["logger_page"])
            {
                foreach (KEYPAIRVALUE x in query_collection.Items)
                {
                    string query = x.value;
                    m_serialComManager.Send(query);
                }
            }
            else if (tab_control.SelectedTab == tab_control.TabPages["custom_page"])
            {
                m_serialComManager.Send(msg);
            }

        }

        /**
         *  @description: clears the log box
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void clear_Click(object sender, EventArgs e)
        {
            data_viewer.Clear();
        }

        /**
         *  @description: saves the log box data into a txt file
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void save_Click(object sender, EventArgs e)
        {
            string datetimeString = string.Format("{0:hh-mm-ss-tt}", DateTime.Now);
            data_viewer.SaveFile("Log -" + datetimeString + " - default.txt");
        }

        /**
         *  @description: event handler for open button
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void open_Click(object sender, EventArgs e)
        {
            if (!m_serialComManager.Checkport())
            {
                m_serialComManager.Open();
                if (m_serialComManager.Checkport())
                {
                    data_viewer.AppendText("PORT Has been opened. \r");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Cannot open port. Is it opened or being used by another program?");
            }
        }

        /**
         *  @description: event handler for close button
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void close_Click(object sender, EventArgs e)
        {
            if (m_serialComManager.Checkport())
            {
                m_serialComManager.Close();
                if (!m_serialComManager.Checkport())
                {
                    data_viewer.AppendText("PORT Has been closed. \r");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Cannot close port. Is it already closed?");
            }
        }

        /**
         *  @description: Toggle logic for timer logging event
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void timelog_checkbox_logger_CheckedChanged_1(object sender, EventArgs e)
        {
            if (m_isTimedLogging == false)
            {
                m_isTimedLogging = true;
            }
            else if (m_isTimedLogging == true)
            {
                m_isTimedLogging = false;
            }
        }

        /**
         *  @description: Toggle logic for query callback
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void callback_check_box_logger_CheckedChanged(object sender, EventArgs e)
        {
            if (m_serialComManager.Callback == false)
            {
                m_serialComManager.Callback = true;
            }
            else if (m_serialComManager.Callback == true)
            {
                m_serialComManager.Callback = false;
            }

        }

        /**
         *  @description: Adds current selected query to list
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void add_logging_Click(object sender, EventArgs e)
        {
            if (query_selector.SelectedItem != null)
            {
                query_collection.Items.Add(query_selector.SelectedItem);
                query_collection.DisplayMember = "key";
            }
        }

        /**
         *  @description: Removes selected query from list
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void remove_logging_Click(object sender, EventArgs e)
        {
            query_collection.BeginUpdate();
            for (int i = query_collection.CheckedIndices.Count - 1; i >= 0; i--)
            {
                query_collection.Items.RemoveAt(query_collection.CheckedIndices[i]);
            }
            query_collection.EndUpdate();
        }

        /**
         *  @description: Toggles whether we want to save results to file during capture or not
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void file_save_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_saveToFile)
            {
                m_saveToFile = true;
            }
            else if (m_saveToFile)
            {
                m_saveToFile = false;
            }
        }

        /**
         *  @description: Change detection data_viewer
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void data_viewer_TextChanged(object sender, EventArgs e)
        {
            data_viewer.ScrollToCaret();
        }

        /**
         *  @description: Resets program settings
         *  @param: Nil
         *  @returns: Nil
         */
        private void ResetSettings()
        {
            m_isLogging = false;
            m_isTimedLogging = false;
            m_saveToFile = false;
            m_serialComManager.FCS = false;
            m_serialComManager.Callback = false;
        }

        /**
         *  @description: Sets time interval for retrieval
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void time_set_button_Click(object sender, EventArgs e)
        {
            m_retrieveInterval = Convert.ToInt32(time_set_box.Text);
            m_watcher.Interval = m_retrieveInterval;
            data_viewer.AppendText("Update interval has been changed to: " + m_retrieveInterval.ToString() + " miliseconds. \r");
        }

        /**
         *  @description: check and filter numeric values in the time_set_box
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void check_numeric_keydown(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

    }
}
