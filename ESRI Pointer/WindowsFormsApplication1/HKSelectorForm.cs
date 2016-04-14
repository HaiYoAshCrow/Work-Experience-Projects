using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/*****************************************************************************************************
 *  @author: Noct the Gestalt                                                                        *
 *  @description: This form class handles loading and defintion of custom global hoteys              *
 *  @last modified: 07/12/2012                                                                       *
 *****************************************************************************************************/
namespace ESRIPPTPointer
{
    public partial class Hotkey_selector_form : Form
    {
        /*Variables*/
        private Keys m_primary;         // Holds the primary key
        private Keys m_secondary;       // Holds the secondary key
        private bool m_setModeOn;       // Determines whether in setting mode or not

        /**************************************************
         * Description: Default Constructor
         * Parameters: Nil
         **************************************************/
        public Hotkey_selector_form()
        {
            InitializeComponent();
        }

        /**************************************************
         * Description: Loads everything
         * Parameters: sender object, EventArgs
         **************************************************/
        private void Hotkey_selector_form_Load(object sender, EventArgs e)
        {
            Closing += new System.ComponentModel.CancelEventHandler(Window_Closing);
            m_setModeOn = false;
        }

        /**************************************************
         * Description: Prevents total shutdown
         * Parameters: sender object, CancelEventArgs
         **************************************************/
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        /**************************************************
         * Description: Closes the window and passes the value to the parent
         * Parameters: sender object, CancelEventArgs
         **************************************************/
        private void ok_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**************************************************
         * Description: Enters set mode for the primary keys
         * Parameters: sender object, CancelEventArgs
         **************************************************/
        private void primary_set_Click(object sender, EventArgs e)
        {
            m_setModeOn = true;
            primary_set.Enabled = false;
            this.Enabled = false;
            this.Owner.Enabled = false;
        }

        /**************************************************
         * Description: Enters set mode for the secondary keys
         * Parameters: sender object, CancelEventArgs
         **************************************************/
        private void secondary_set_Click(object sender, EventArgs e)
        {
            m_setModeOn = true;
            secondary_set.Enabled = false;
            this.Enabled = false;
            this.Owner.Enabled = false;
        }

        /**************************************************
         * Description: Gets the selected keys 
         * Parameters: sender object, KeyPressEventArgs
         **************************************************/
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (m_setModeOn == true)
            {
                if (primary_set.Enabled == false)
                {
                    switch (keyData)
                    {
                        case (Keys.Control | Keys.ControlKey):
                            m_primary = keyData;
                            primary_set.Enabled = true;
                            primary_set.Text = keyData.ToString();
                            m_setModeOn = false;
                            this.Enabled = true;
                            this.Owner.Enabled = true;
                            break;
                        case ((Keys.Alt)):
                            m_primary = keyData;
                            primary_set.Enabled = true;
                            primary_set.Text = keyData.ToString();
                            m_setModeOn = false;
                            this.Enabled = true;
                            this.Owner.Enabled = true;
                            break;
                        case ((Keys.Modifiers | Keys.Shift)):
                            m_primary = keyData;
                            primary_set.Enabled = true;
                            primary_set.Text = keyData.ToString();
                            this.Enabled = true;
                            this.Owner.Enabled = true;
                            m_setModeOn = false;
                            break;
                        case (Keys.Escape):
                            primary_set.Enabled = true;
                            this.Enabled = true;
                            this.Owner.Enabled = true;
                            m_setModeOn = false;
                            break;
                        default:   
                            break;
                    }
                }
                if(secondary_set.Enabled == false)
                {
                        int h = (int)Keys.A;
                        Console.WriteLine(h);
                        switch (keyData)
                        {                              
                            case(Keys.A):
                                m_secondary = keyData;
                                secondary_set.Enabled = true;
                                secondary_set.Text = keyData.ToString();
                                m_setModeOn = false;
                                this.Enabled = true;
                                this.Owner.Enabled = true;
                                break;
                            case (Keys.Escape):
                                secondary_set.Enabled = true;
                                this.Enabled = true;
                                this.Owner.Enabled = true;
                                m_setModeOn = false;
                                break;
                            default:
                                break;
                        }
               }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
