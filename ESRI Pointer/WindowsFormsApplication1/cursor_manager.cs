using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;

/*****************************************************************************************************
 *  @author: Tuan Nguyen                                                                  *
 *  @description: This class handles the loading and restoration of custom mouse cursors             *
 *  @last modified: 14/04/2016                                                                        *
 *****************************************************************************************************/

namespace ESRIPPTPointer
{
    class CursorManager
    {
        /*Variables*/
        private const int SPI_SETCURSORS = 0x0057;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDCHANGE = 0x02;

        /**************************************************
         * Description: Default Constructor
         * Parameters: Nil
         **************************************************/
        public CursorManager()
        {
        }

        /**************************************************
         * Description: Changes cursor to custom one
         * Parameters: location string
         **************************************************/
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fWinIni);

        public void ChangeCursor(string loc)
        {
            Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Cursors\\", "Arrow", @loc);
            SystemParametersInfo(SPI_SETCURSORS, 0, null, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE); 
        }

        /**************************************************
         * Description: Restores the cursor back to default
         * Parameters: Nil
         **************************************************/
        public void Restore()
        {
            Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Cursors\\", "Arrow", @"C:\\Windows\\Cursors\\aero_arrow.cur");
            SystemParametersInfo(SPI_SETCURSORS, 0, null, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE); 
        }

    }
}
