using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;

namespace CKDSpanTeam
{
    internal class Class1
    {
        public static string ConnectionOPDString = "";
        public static string ConnectionADMString = "";
        public static string ConnectionGENString = "";
        public static Object GetSQLServerFromODBC(string chdb_name)
        {
            try
            {

                return new Computer().Registry.GetValue(new Computer().Registry.CurrentUser.Name
                                                        + "" + chdb_name,
                                                        "",
                                                        null);
            }
            catch (Exception)
            {
                return null;
            }
        }
        
    }
}
