using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*  
 *  @description: Contains a series of pre-defined strings we can use for the querying the device.
 *                This is a static class so if the user wants, they can define their own strings and
 *                add them to the auto-query list in the program.
 *  @last modified: 21/12/2012
 *  @author: Tuan Nguyen
 */
namespace SerialPortMonitor
{
    public static class string_definition
    {
        public static string VERSION = "02 00 08 00 08";                                       //Returns device version
        public static string XY_RSSI_REQUEST = "02 00 18 07 CB FF FF CA 11 00 00 0F";          //Returns Reference Node Location and RSSI values
        public static string REF_NODE_REQUEST;                                                 //Returns Reference Node configuration
        public static string BLIND_NODE_REQUEST;                                               //Returns Blind Node configuration
        public static string BLIND_NODE_FIND_REQUEST = "02 00 18 07 CB FF FF CA 13 00 00 0D";  //Returns Blind Node information if found
    }
}
