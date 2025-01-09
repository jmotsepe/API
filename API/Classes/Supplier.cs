using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

namespace API_Asset_Management
{
    class Supplier
    {
        private string SupplierID { get; set; }
        private string SupplierName { get; set;}
        private string VatReference { get; set; }
        private string SupplierContact { get; set; }
        private string Telephone{ get; set; }
        private string Email { get; set; }
        private string Mobile { get; set; }
        private string Postal { get; set; }
        private string Physical { get; set; }
        private string Stored_Procedure { get; set; }

        public Supplier() 
        { 

        }

        public Supplier(string supplierID, string supplierName, string vatReference, string supplierContact, string telephone, string email, string mobile, string postal, string physical)
        {
            SupplierID = supplierID;
            SupplierName = supplierName;
            VatReference = vatReference;
            SupplierContact = supplierContact;
            Telephone = telephone;
            Email = email;
            Mobile = mobile;
            Postal = postal;
            Physical = physical;

            AddSupplier();
        }

        public Supplier(string supplierID, string supplierName, string vatReference, string supplierContact, string telephone, string email, string mobile, string postal, string physical, string update)
        {
            SupplierID = supplierID;
            SupplierName = supplierName;
            VatReference = vatReference;
            SupplierContact = supplierContact;
            Telephone = telephone;
            Email = email;
            Mobile = mobile;
            Postal = postal;
            Physical = physical;

            UpdateSupplier();
        }


        private void AddSupplier()
        {
            string storedProc = "sp_addSupplier";
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(storedProc, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@supplierID", SqlDbType.VarChar).Value = SupplierID;
                    cmd.Parameters.AddWithValue("@supplierName", SqlDbType.VarChar).Value = SupplierName;
                    cmd.Parameters.AddWithValue("@vatReference", SqlDbType.VarChar).Value = VatReference;
                    cmd.Parameters.AddWithValue("@contact", SqlDbType.Char).Value = SupplierContact;
                    cmd.Parameters.AddWithValue("@telephone", SqlDbType.VarChar).Value = Telephone;
                    cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = Email;                    
                    cmd.Parameters.AddWithValue("@mobile", SqlDbType.VarChar).Value = Mobile;                    
                    cmd.Parameters.AddWithValue("@postal", SqlDbType.VarChar).Value = Postal;
                    cmd.Parameters.AddWithValue("@physical", SqlDbType.VarChar).Value = Physical;


                    //string query = "UPDATE tblSupplier SET supplier_name = " + SupplierName + " vat_reference = " + VatReference + ", contact_person = " + SupplierContact;
                    //query += ", telephone = " + Telephone + ", email = " + Email + ", mobile = " + Mobile + ", postal_address = " + Postal + ", physical_Address = " + Physical;
                    //query += " WHERE supplier_ID = " + SupplierID;

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Supplier added successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                    catch (SqlException ex)
                    {
                        _ = MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void UpdateSupplier()
        {

        }
    }
}
