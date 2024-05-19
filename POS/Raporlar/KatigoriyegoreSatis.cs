using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;



namespace POS.Raporlar
{
    public partial class KatigoriyegoreSatis : Form
    {
        public KatigoriyegoreSatis()
        {
            InitializeComponent();
        }

        private void BtnRaporla_Click(object sender, EventArgs e)
        {

            DateTime startDate = guna2DateTimePicker1.Value.Date;
            DateTime endDate = guna2DateTimePicker2.Value.Date;

            // Open the new form and pass the selected dates
            ByCategoryYazdir reportForm = new ByCategoryYazdir(startDate, endDate);
            reportForm.Show();

        }


        

        private void KatigoriyegoreSatis_Load(object sender, EventArgs e)
        {
           
        }
    }
}