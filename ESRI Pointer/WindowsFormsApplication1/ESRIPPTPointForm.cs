using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

/*****************************************************************************************************
 *  @author: Noct the Gestalt                                                                        *
 *  @description: A simple program that changes the cursor to a laser-icon for powerpoint slideshows *
 *  @last modified: 07/12/2012                                                                       *
 *****************************************************************************************************/
namespace ESRIPPTPointer
{
    public partial class ESRIPPTForm : Form
    {
        /* Variables */
        private Keys m_CmdKey;                                      // Holds the command key i.e. ctrl
        private Keys m_secondaryKey;                                // Holds the secondary key i.e. p
        private bool m_isActive;                                    // Holds icon change status
        private string m_custCursor;                                // Holds the custom cursor
        private string m_directory;                                 // Holds the current cursor folder directory
        private CursorManager c_manager;                            // Cursor manager
        private GlobalHotkey m_enablerHK;                           // Global hotkey for toggling icon change
        private GlobalHotkey m_toggleNext;                          // Global hotkey for toggling next icon in directory
        private GlobalHotkey m_togglePrevious;                      // Global hotkey for toggling previous icon in directory
        private Hotkey_selector_form m_HKForm;                      // Selector form

        /**************************************************
         * Description: Default Constructor
         * Parameters: Nil
         **************************************************/
        public ESRIPPTForm()
        {
            InitializeComponent();
            InitializeSettings();
        }

        /**************************************************
         * Description: Initializes settings
         * Parameters: Nil
         **************************************************/
        private void InitializeSettings()
        {
            m_isActive = false;
            string settings = Application.StartupPath + "\\settings.ini";

            //If no settings file has been found, make one and establish default key settings
            if (!File.Exists(settings))
            {
                BuildSettings();
            }
            else //Load the settings if the settings.ini exists
            {
                KeysConverter t = new KeysConverter(); //For reading strings into keys
                StreamReader file = new System.IO.StreamReader(Application.StartupPath + "\\settings.ini");
                string line = "";
                string temp = "";
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("Command Key:"))
                    {
                        //Strip the string to a certain point only
                        temp = line.Remove(0, line.IndexOf(":")+1);
                        m_CmdKey = (Keys)t.ConvertFromString(temp);
                    }
                    else if (line.Contains("Secondary Key:"))
                    {
                        //Strip the string to a certain point only
                        temp = line.Remove(0, line.IndexOf(":") + 1);
                        m_secondaryKey = (Keys)t.ConvertFromString(temp);
                    }
                    else if (line.Contains("Cursor:"))
                    {
                        //***DISABLED FOR NOW***
                        //Strip the string to a certain point only
                        //temp = line.Remove(0, line.IndexOf(":")+1);
                        //m_custCursor = temp;
                    }

                    //TODO: Check for settings.ini corruption
                }
                file.Close();
            }

            //TEMP FIX
            m_custCursor = Application.StartupPath + "\\cursor\\red\\def_red_24x.cur";

            c_manager = new CursorManager();
            m_enablerHK = new GlobalHotkey(keycode_constants.CTRL, m_secondaryKey,this);
            m_toggleNext = new GlobalHotkey(keycode_constants.CTRL, Keys.Oemplus, this);
            m_togglePrevious = new GlobalHotkey(keycode_constants.CTRL, Keys.OemMinus, this);

            m_enablerHK.Register();
            m_toggleNext.Register();
            m_togglePrevious.Register();

            m_directory = Application.StartupPath + "\\cursor\\red\\";
            primary_txt.Text = m_CmdKey.ToString();
            second_txt.Text = m_secondaryKey.ToString();
        }

        /**************************************************
         * Description: Grabs the key press message from the window
         * Parameters: Intptr
         **************************************************/
        private Keys Getkey(IntPtr LParam)
        {
            return (Keys)((LParam.ToInt32()) >> 16);
        }

        /**************************************************
         * Description: Overloads the message handler to handle custom messages
         * Parameters: reference message
         **************************************************/
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == keycode_constants.WM_HOTKEY_MSG_ID)
            {
                Keys k = Getkey(m.LParam);
                if (k == m_secondaryKey && m_isActive == false)
                {
                    c_manager.ChangeCursor(m_custCursor);
                    m_isActive = true;
                }
                else if(k == m_secondaryKey && m_isActive == true)
                {
                    c_manager.Restore();
                    m_isActive = false;
                }
                else if (k == Keys.Oemplus && m_isActive == true)
                {
                    GetNextCursor(1);
                }
                else if (k == Keys.OemMinus && m_isActive == true)
                {
                    GetNextCursor(-1);
                }
            }

            base.WndProc(ref m);
        }

        /**************************************************
         * Description: Builds the settings file
         * Parameters: Nil
         **************************************************/
        private void BuildSettings()
        {
            m_CmdKey = Keys.Control;
            m_secondaryKey = Keys.K;
            m_custCursor = Application.StartupPath + "\\cursor\\red\\def_red_24x.cur";
            
            StreamWriter file = new StreamWriter(Application.StartupPath + "\\settings.ini");
            file.WriteLine("Command Key:" + m_CmdKey.ToString());
            file.WriteLine("Secondary Key:" + m_secondaryKey.ToString());
            file.WriteLine("Cursor:" + m_custCursor);
            file.Close();
        }

        /**************************************************
         * Description: Changes the key settings
         * Parameters: keyPressed
         **************************************************/
        private void ChangeKeyCombo()
        {
            //TODO
        }

        /**************************************************
         * Description: Gets next cursor in directory
         * Parameters: Nil
         **************************************************/
        private void GetNextCursor(int value)
        {
            //Grab the list of files in the directory
            //TODO: This is a hack and slash version. A neater and more elegeant solution needs to be looked into
            string[] FileList = Directory.GetFiles(m_directory);
            int curr_index = Array.IndexOf(FileList, m_custCursor);
            string nextFile = "";

            //Assign the next/previous fileto the current cursor in a cylic manner
            if (curr_index == 0 && value < 0)
            {
                nextFile = FileList.ElementAt(FileList.Length - 1);
                m_custCursor = nextFile;
                c_manager.Restore();
                c_manager.ChangeCursor(m_custCursor);
            }
            else if (curr_index == FileList.Length - 1 && value > 0)
            {
                nextFile = FileList.ElementAt(0);
                m_custCursor = nextFile;
                c_manager.Restore();
                c_manager.ChangeCursor(m_custCursor);
            }
            else
            {
                nextFile = FileList.ElementAt(curr_index + value);
                m_custCursor = nextFile;
                c_manager.Restore();
                c_manager.ChangeCursor(m_custCursor);
            }
        }

        /**************************************************
         * Description: Overrides the close button
         * Parameters: CancelEventArgs
         **************************************************/
        protected override void OnClosing(CancelEventArgs e)
        {
            //Restores the cursor upon exit. We don't want the user's cursor to be stuck like this!
            if (m_isActive)
            {
                c_manager.Restore();
            }
            if (m_enablerHK.UnRegister())
            {
                Console.WriteLine("Un-registration successful.");
            }
            if (m_toggleNext.UnRegister())
            {
                Console.WriteLine("Un-registration successful.");
            }
            if (m_togglePrevious.UnRegister())
            {
                Console.WriteLine("Un-registration successful.");
            }
            base.OnClosing(e);
        }

        /**************************************************
         * Description: Manages the resizing of the window
         * Parameters: Sender Object, CancelEventArgs
         **************************************************/
        private void ESRIPPTForm_Resize(object sender, EventArgs e)
        {
            //Hide the window, set it hidden to the tray
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(2000);
            }
        }

        /**************************************************
         * Description: Mouse-click handler for the icon event
         * Parameters: Sender Object, MouseEventArgs
         **************************************************/
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        /**************************************************
         * Description: cust_icon click event handler
         * Parameters: sender object, EventArgs
         **************************************************/
        private void cust_icon_Click(object sender, EventArgs e)
        {
            OpenFileDialog m_fileBrowser = new OpenFileDialog();
            m_fileBrowser.InitialDirectory = Application.StartupPath + "//cursor";
            m_fileBrowser.Filter = "Cursor Files (*.cur)|*.cur";
            m_fileBrowser.RestoreDirectory = true;

            if (m_fileBrowser.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string f = m_fileBrowser.FileName;
                    m_directory = Path.GetDirectoryName(m_fileBrowser.FileName);
                    Console.WriteLine(m_directory);
                    m_custCursor = f;
                    if (m_isActive)
                    {
                        //Reset the cursor and set it to the new one if active
                        c_manager.Restore();
                        c_manager.ChangeCursor(m_custCursor);
                    }
                    this.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        /**************************************************
         * Description: cust_key click event handler
         * Parameters: sender object, EventArgs
         **************************************************/
        private void cust_key_but_Click(object sender, EventArgs e)
        {
            //TODO
            MessageBox.Show("Not Implemented yet!");
            //if (m_HKForm == null)
            //{
            //    m_HKForm = new Hotkey_selector_form();
            //    m_HKForm.Owner = this;
            //}
            //m_HKForm.Show();
        }
    }
}
