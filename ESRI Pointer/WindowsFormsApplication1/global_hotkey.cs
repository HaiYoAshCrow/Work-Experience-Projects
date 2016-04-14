using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
/*****************************************************************************************************
 *  @author: Tuan Nguyen                                                                   *
 *  @description: This class handles the loading and unloading of global hotkeys                     *
 *  @last modified: 14/04/2016                                                                   *
 *****************************************************************************************************/

namespace ESRIPPTPointer
{
    class GlobalHotkey
    {
        /*Variables*/
        private int modifier;
        private int key;
        private IntPtr hWnd;
        private int id;

        //Map these functions to the system functions/underlaying structure of the window
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /**************************************************
         * Description: Default Constructor
         * Parameters: Nil
         **************************************************/
        public GlobalHotkey(int modifier, Keys key, Form form)
        {
            this.modifier = modifier;
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        /**************************************************
         * Description: Generates a custom hash key
         * Parameters: Nil
         **************************************************/
        public override int GetHashCode()
        {
            return modifier ^ key ^ hWnd.ToInt32();
        }

        /**************************************************
         * Description: Attempts to register a hotkey
         * Parameters: Nil
         **************************************************/
        public bool Register()
        {
            return RegisterHotKey(hWnd, id, modifier, key);
        }

        /**************************************************
         * Description: Attempts to un-register a hotkey
         * Parameters: Nil
         **************************************************/
        public bool UnRegister()
        {
            return UnregisterHotKey(hWnd, id);
        }
    }
}
