using API_Asset_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API.Forms
{
    public partial class FormAddSupplier : Form
    {
        private string supplierID = "SUP" + NextNumber.NextSequence("tblSupplier", "supplier_ID");
        public FormAddSupplier()
        {
            InitializeComponent();
        }

        private void BtnAddSupplier_Click(object sender, EventArgs e)
        {
            if (TxtAddSupplierName.Text == "" && TxtAddSupContact.Text == "")
            {
                _ = MessageBox.Show("Supplier and Rep name are both empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _ = TxtAddSupplierName.Focus();
            }
            else if (TxtAddSupEmail.Text == "" && TxtAddSupTelephone.Text == "" && TxtAddSupMobile.Text == "")
            {
                _ = MessageBox.Show("Supplier must have at least one contact method", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ = TxtAddSupEmail.Focus();
            }
            else if (TxtAddSupEmail.Text != "" && RegexUtilities.IsValidEmail(TxtAddSupEmail.Text) == false)
            {
                _ = MessageBox.Show(TxtAddSupEmail.Text + " is not a valid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ = TxtAddSupEmail.Focus();
                TxtAddSupEmail.SelectAll();
            }
            else
            {

                _ = new Supplier(supplierID, TxtAddSupplierName.Text, TxtAddVat.Text, TxtAddSupContact.Text, TxtAddSupTelephone.Text, TxtAddSupEmail.Text, TxtAddSupMobile.Text, TxtAddPostalAddress.Text, TxtAddPhysicalAddress.Text);
            }
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void FormAddSupplier_Load(object sender, EventArgs e)
        {

        }
    }
}
