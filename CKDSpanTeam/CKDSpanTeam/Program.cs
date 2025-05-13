using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKDSpanTeam
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
        public static string sSeeDate = "";
        public static string sPNC = "";
        public static string sRoom = "";
        public static int intRegNo=0;
        public static int intSeqNo = 0;
        public static string sChooes = "";
        public static string sFrom = "";
        public static string sOCaseNo = "";
        public static string sUserType = "";
        public static string sMRNo = "";
    }
}
