using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_Asset_Management
{
    internal class Specifications
    {
        private string SerialNumber { get; set; }
        private string OperatingSystem { get; set; }
        private int RAM { get; set; }
        private string StorageType { get; set; }
        private int StorageSize { get; set; }
        string Processor {  get; set; }
        private string DisplaySize { get; set; }
        private string Numpad { get; set; }
        //private string Function { get; set; }

        public Specifications() { }

        public Specifications(string serialNumber, string operatingSystem, int ram, string storageType, int storageSize, string processor, string displaySize, string numpad/*, string function*/)
        {
            SerialNumber = serialNumber;
            OperatingSystem = operatingSystem;
            RAM = ram;
            StorageType = storageType;
            StorageSize = storageSize;
            Processor = processor;
            DisplaySize = displaySize;
            Numpad = numpad;
            //Function = function;

            InsertSpecs();
        }

        private void InsertSpecs()
        {
            string sp = "sp_updateSpecs";

            using(SqlConnection con = new SqlConnection(Connection.ConnectionString()))
            {
                using(SqlCommand cmd = new SqlCommand(sp, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@serialNumber", SqlDbType.NVarChar).Value = SerialNumber;
                    cmd.Parameters.AddWithValue("@os", SqlDbType.NVarChar).Value = OperatingSystem;
                    cmd.Parameters.AddWithValue("@ram", SqlDbType.Int).Value = RAM;
                    cmd.Parameters.AddWithValue("@storage_type", SqlDbType.NChar).Value = StorageType;
                    cmd.Parameters.AddWithValue("@storage_size", SqlDbType.Int).Value = StorageSize;
                    cmd.Parameters.AddWithValue("@processor", SqlDbType.NVarChar).Value= Processor;
                    cmd.Parameters.AddWithValue("@screen_size", SqlDbType.NChar).Value = DisplaySize;
                    cmd.Parameters.AddWithValue("@numpad", SqlDbType.Char).Value = Numpad;

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Computer Specifications updated seccussfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(SqlException ex) 
                    {
                        _ = MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
    }
}
