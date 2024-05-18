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
    public partial class PersonelRapor : Form
    {
        public PersonelRapor()
        {
            InitializeComponent();
        }

        private void PersonelRapor_Load(object sender, EventArgs e)
        {
            LoadBillDetails();
            this.reportViewer1.RefreshReport();
            
        }

        private void LoadBillDetails()
        {
            string ConnectionString = "Data Source=DESKTOP-7E9QC34;Initial Catalog=RM;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string qry = @"Select pAd, pTelefon, pRol from Personel";
                SqlDataAdapter da = new SqlDataAdapter(qry, con);
                DataSet2 ds = new DataSet2();
                da.Fill(ds, "Personel");

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables["Personel"]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(datasource);
                this.reportViewer1.RefreshReport();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
