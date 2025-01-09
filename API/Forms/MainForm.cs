using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API
{
    public partial class MainForm : Form
    {
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public MainForm()
        {
            InitializeComponent();
            random = new Random();
            BtnCloseChildForm.Visible = false;
            Text = string.Empty;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Forms.FormDashboard(), sender);
        }
    }
}
