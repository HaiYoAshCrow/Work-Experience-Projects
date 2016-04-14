using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
/*  
 *  @description: A simple data logger for the CC2431. This file contains mainly the logic implementation
 *                of the custom page. Other pages and their logic has been respectively splitted to
 *                ensure easier tracking.
 *  @last modified: 21/12/2012
 *  @author: Tuan Nguyen
 */
namespace SerialPortMonitor
{
    public partial class logger_form : Form
    {
        private string m_custom_msg = "";        //Holds a custom query message

        /**
         *  @description: Toggle logic for timer logging event
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void timelog_checkbox_CheckedChanged(object sender, EventArgs e)
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
         *  @description: Toggle logic for timer logging event
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void send_button_custom_Click(object sender, EventArgs e)
        {
            if (query_input.TextLength != 0)
            {
                m_custom_msg = query_input.Text;
            }

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
                            writer = new StreamWriter("Log - " + m_datetimeString + " - custom.txt");
                        }
                        m_watcher.Start();
                    }
                    else
                    {
                        ParseQuery(m_custom_msg);
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Port is not opened. Cannot send query!");
                }
            }
        }

        /**
         *  @description: clears custom view
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void custom_clear_display_Click(object sender, EventArgs e)
        {
            custom_log_display.Clear();
        }

        /**
         *  @description: saves data to log file
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void save_custom_Click(object sender, EventArgs e)
        {
            string datetimeString = string.Format("{0:hh-mm-ss-tt}", DateTime.Now);
            data_viewer.SaveFile("Log-" + datetimeString + "-custom" + ".txt");
        }

        /**
         *  @description: stops the recording if in proccess
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void stop_custom_Click(object sender, EventArgs e)
        {
            if (m_isLogging)
            {
                m_isLogging = false;
            }
            m_watcher.Stop();
        }

        /**
         *  @description: Toggles the FCS calculation flag
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void enable_FCS_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_serialComManager.FCS)
            {
                m_serialComManager.FCS = true;
            }
            else if (m_serialComManager.FCS)
            {
                m_serialComManager.FCS = false;
            }
        }

        /**
         *  @description: Toggles the callback flag
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void custom_callback_checkbox_CheckedChanged(object sender, EventArgs e)
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
         *  @description: Change detection custom_log_display
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void custom_log_display_TextChanged(object sender, EventArgs e)
        {
            custom_log_display.ScrollToCaret();
        }

        /**
         *  @description: Sets custom time on click
         *  @param: object, Eventargs
         *  @returns: Nil
         */
        private void set_time_cust_but_Click(object sender, EventArgs e)
        {
            m_retrieveInterval = Convert.ToInt32(time_set_box_custom.Text);
            m_watcher.Interval = m_retrieveInterval;
            custom_log_display.AppendText("Update interval has been changed to: " + m_retrieveInterval.ToString() + " miliseconds. \r");
        }

        /**
         *  @description: Checks for changes in the save to file checkbox
         *  @param: Nil
         *  @returns: Nil
         */
        private void file_save_custom_CheckedChanged(object sender, EventArgs e)
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
    }
}
