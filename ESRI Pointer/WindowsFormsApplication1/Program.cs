using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ESRIPPTPointer
{
    static class Program
    {
        /*******************************************
         * Description: Main entry point
         * Parameters: Nil
         ******************************************/
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ESRIPPTForm());
        }


    }
}
