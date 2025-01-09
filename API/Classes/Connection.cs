using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Asset_Management
{
    internal class Connection
    {
        public static string ConnectionString()
        {
            string username = "";
            string password = "";

            //return "Data Source=.\\SQLEXPRESS;Initial Catalog=api;Persist Security Info=True;User ID=" + username + ";Password=" + password;
            return "Data Source=.\\SQLExpress;Initial Catalog=api;Integrated Security=True";
        }
    }
}
