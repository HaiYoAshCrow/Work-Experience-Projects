using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*****************************************************************************************************
 *  @author: Tuan                                                                      *
 *  @description: A simple class to contain global access key values                                 *
 *  @last modified: 07/12/2012                                                                       *
 *****************************************************************************************************/
namespace ESRIPPTPointer
{
    public static class keycode_constants
    {
        /*Keycode Constants*/
        public const int NOMOD = 0x0000;                // No key
        public const int ALT = 0x0001;                  // Alt
        public const int CTRL = 0x0002;                 // Ctrl
        public const int SHIFT = 0x0004;                // Shift
        public const int WIN = 0x0008;                  // Windows key
        public const int WM_HOTKEY_MSG_ID = 0x0312;     // Message from global key
    }
}
