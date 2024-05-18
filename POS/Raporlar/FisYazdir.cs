using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace POS.Raporlar
{
    public partial class FisYazdir : Form
    {
        private int MainID;

        public FisYazdir(int mainID)
        {
            InitializeComponent();
            MainID = mainID;
        }

        private void FisYazdir_Load(object sender, EventArgs e)
        {
            LoadBillDetails();
            this.reportViewer2.RefreshReport();
        }

        private void LoadBillDetails()
        {
            string ConnectionString = "Data Source=DESKTOP-7E9QC34;Initial Catalog=RM;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string qry = "Select * from View_All_Bill where MainID = @MainID";
                SqlDataAdapter da = new SqlDataAdapter(qry, con);
                da.SelectCommand.Parameters.AddWithValue("@MainID", MainID);
                DataSet2 ds = new DataSet2();
                da.Fill(ds, "DataTable_Fis");

                ReportDataSource datasource = new ReportDataSource("DataSet4", ds.Tables[0]);
                this.reportViewer2.LocalReport.DataSources.Clear();
                this.reportViewer2.LocalReport.DataSources.Add(datasource);
                this.reportViewer2.RefreshReport();
            }
        }

        

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
