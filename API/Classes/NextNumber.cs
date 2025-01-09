using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_Asset_Management
{
    class NextNumber
    {
        public static string NextSequence(string table, string column)
        {
            string query = "SELECT MAX(" + column + ") \"MAX\" FROM " + table;
            int newNumber = 0000;
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            if (sdr["MAX"] != DBNull.Value)
                            {
                                newNumber = int.Parse(sdr["MAX"].ToString().Substring(4)) + 1;
                            }
                            else
                            {
                                newNumber = 0000;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        _ = MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            string next = "";
            if (newNumber == 0)
            {
                return "0000";
            }
            else if (newNumber.ToString().Length != 4)
            {
                int length = 4;
                next = newNumber.ToString("D" + length);
            }
            return next;
        }
    }
}
