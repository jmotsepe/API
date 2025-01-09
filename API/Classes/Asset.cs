using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_Asset_Management
{
    internal class Asset
    {
        private string AssetNumber {  get; set; }
        private string SerialNumber { get;set; }
        private string AssetType { get;set; }
        private string Location_ID {  get;set; }
        private string Supplier_ID { get;set; }
        private DateTime InvoiceDate { get;set; }
        private double PriceExcl { get;set; }
        private string OperatingSystem { get; set; }
        private decimal MemorySize {  get; set; }
        private string StorageType {  get; set; }
        private decimal StorageSize { get; set; }
        private string Processor { get; set; }
        private string DisplaySize {get;set; }
        private char Numpad { get; set; }
        private string Make { get; set; }
        private string Model { get; set; }
        
<<<<<<< Updated upstream:API Asset Management/Asset.cs

=======
        public Asset()
        {
            GetAssetDetails();
        }

        public Asset(string placeHolder)
        {

        }
>>>>>>> Stashed changes:API Asset Management/Classes/Asset.cs
               
        //Add asset
        public Asset(string assetNumber, string serialNumber, string assetType, string location_ID, string supplier_ID, DateTime invoiceDate, double priceExcl, string make, string model, string operatingSystem, decimal memorySize, string storageType, decimal storageSize, string processor, string displaySize, char numpad)
        {
            AssetNumber = assetNumber;
            SerialNumber = serialNumber;
            AssetType = assetType;
            Location_ID = location_ID;
            Supplier_ID = supplier_ID;
            InvoiceDate = invoiceDate;
            PriceExcl = priceExcl;            
            Make = make;
            Model = model;
            OperatingSystem = operatingSystem;
            MemorySize = memorySize;
            StorageType = storageType;
            StorageSize = storageSize;
            Processor = processor;
            DisplaySize = displaySize;
            Numpad = numpad;

            AddAsset();
        }

        //Edit asset
        public Asset(string assetNumber, string serialNumber, string assetType, string location, string supplier, DateTime invoiceDate, double priceExcl, string make, string model, string operatingSystem, decimal memorySize, string storageType, decimal storageSize, string processor, string displaySize, char numpad, bool edit)
        {
            SerialNumber = serialNumber;
            AssetNumber = assetNumber;
            AssetType = assetType;
            Location_ID = location;
            Supplier_ID = supplier;
            InvoiceDate = invoiceDate;
            PriceExcl = priceExcl;
            Make = make;
            Model = model;
            OperatingSystem = operatingSystem;
            MemorySize = memorySize;
            StorageType = storageType;
            StorageSize = storageSize;
            Processor = processor;
            DisplaySize = displaySize;
            Numpad = Numpad;

            ConfirmEdit();
            
        }

        //Assign the asset
        public Asset(string serialNumber, string assetType, char insured, string location, string supplier, DateTime invoiceDate, double priceExcl, int? userID)
        {
            SerialNumber = serialNumber;
            AssetType = assetType;
            Location_ID = location;
            Supplier_ID = supplier;
            InvoiceDate = invoiceDate;
            PriceExcl = priceExcl;
            AssetNumber = "API" + NextNumber.NextSequence("tblAsset", "asset_num");
        }

        private void AddAsset()
        {
            string storedProc = "sp_addAsset";

            using (SqlConnection con = new SqlConnection(Connection.ConnectionString()))
            {
                using(SqlCommand cmd = new SqlCommand(storedProc, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@assetNumber", SqlDbType.VarChar).Value = AssetNumber;
                    cmd.Parameters.AddWithValue("@serialNumber", SqlDbType.VarChar).Value = SerialNumber;
                    cmd.Parameters.AddWithValue("@assetType", SqlDbType.VarChar).Value = AssetType;
                    cmd.Parameters.AddWithValue("@location_ID", SqlDbType.VarChar).Value = Location_ID;
                    cmd.Parameters.AddWithValue("@supplier_ID", SqlDbType.VarChar).Value = Supplier_ID;
                    cmd.Parameters.AddWithValue("@invoiceDate", SqlDbType.VarChar).Value = InvoiceDate;
                    cmd.Parameters.AddWithValue("@priceExcl", SqlDbType.VarChar).Value = PriceExcl;
                    cmd.Parameters.AddWithValue("@make", SqlDbType.VarChar).Value = Make;

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (SqlException ex)
                    {
                        _ = MessageBox.Show("Duplicate Asset number found");
                    }
                }
            }
        }
        
        private void ConfirmEdit()
        {
            string storedProc = "sp_editAsset";

            using (SqlConnection con = new SqlConnection(Connection.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(storedProc, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@assetNumber", SqlDbType.VarChar).Value = AssetNumber;
                    cmd.Parameters.AddWithValue("@serialNumber", SqlDbType.VarChar).Value = SerialNumber;
                    cmd.Parameters.AddWithValue("@assetType", SqlDbType.VarChar).Value = AssetType;
                    cmd.Parameters.AddWithValue("@location", SqlDbType.VarChar).Value = Location_ID;
                    cmd.Parameters.AddWithValue("@supplier", SqlDbType.VarChar).Value = Supplier_ID;
                    cmd.Parameters.AddWithValue("@invoiceDate", SqlDbType.VarChar).Value = InvoiceDate;
                    cmd.Parameters.AddWithValue("@priceExcl", SqlDbType.VarChar).Value = PriceExcl;
                    cmd.Parameters.AddWithValue("@make", SqlDbType.VarChar).Value = Make;
                    cmd.Parameters.AddWithValue("@model", SqlDbType.VarChar).Value = Model;
	                cmd.Parameters.AddWithValue("@os", SqlDbType.VarChar).Value = OperatingSystem;
                    cmd.Parameters.AddWithValue("@ram", SqlDbType.Int).Value = MemorySize;
                    cmd.Parameters.AddWithValue("@storage_type", SqlDbType.Char).Value = StorageType;
                    cmd.Parameters.AddWithValue("@storage_size", SqlDbType.Int).Value = StorageSize;
                    cmd.Parameters.AddWithValue("@processor", SqlDbType.VarChar).Value = Processor;
                    cmd.Parameters.AddWithValue("@screen_size", SqlDbType.NChar).Value = MemorySize;
                    cmd.Parameters.AddWithValue("@numpad", SqlDbType.Char).Value = Numpad;

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (SqlException ex)
                    {
                        _ = MessageBox.Show(ex.ToString());
                    }

                }

                //using (SqlCommand cmd2 = new SqlCommand(storedProc2, con))
                //{
                //    cmd2.CommandType = CommandType.StoredProcedure;
                //    cmd2.Parameters.AddWithValue("@serialNumber", SqlDbType.VarChar).Value = SerialNumber;
                //    cmd2.Parameters.AddWithValue("@os", SqlDbType.VarChar).Value = OperatingSystem;
                //    cmd2.Parameters.AddWithValue("@ram", SqlDbType.Int).Value = MemorySize;
                //    cmd2.Parameters.AddWithValue("@storage_type", SqlDbType.VarChar).Value = StorageType;
                //    cmd2.Parameters.AddWithValue("@storage_size", SqlDbType.Int).Value = StorageSize;
                //    cmd2.Parameters.AddWithValue("@processor", SqlDbType.VarChar).Value = Processor;
                //    cmd2.Parameters.AddWithValue("@screen_size", SqlDbType.NChar).Value = DisplaySize;
                //    cmd2.Parameters.AddWithValue("@numpad", SqlDbType.Char).Value = Numpad;

                //    try
                //    {
                //        con.Open();
                //        cmd2.ExecuteNonQuery();
                //        con.Close();
                //    }
                //    catch (SqlException ex)
                //    {
                //        _ = MessageBox.Show(ex.ToString());
                //    }
                //}
            }
        }
<<<<<<< Updated upstream:API Asset Management/Asset.cs
=======

        public DataTable GetAssetDetails()
        {
            DataTable dataTable = new DataTable();
            string storedPRoc = "sp_getAssets";
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(storedPRoc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    _ = MessageBox.Show("An error occurred: " + ex.ToString());
                }
            }
            return dataTable;
        }

        public DataTable GetAssetType()
        {
            DataTable dataTable = new DataTable();
            string storedProc = "sp_getAssetType";
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(@storedProc, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    _ = MessageBox.Show("An error occurred: " + ex.ToString());
                }
            }
            return dataTable;
        }
>>>>>>> Stashed changes:API Asset Management/Classes/Asset.cs
    }
}
