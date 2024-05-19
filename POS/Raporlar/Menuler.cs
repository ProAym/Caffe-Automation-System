using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


namespace POS.Raporlar
{
    public partial class Menuler : Form
    {
        public Menuler()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            GenerateReport();
            this.reportViewer1.RefreshReport();
        }

        private void GenerateReport()
        {
            try
            {
                string ConnectionString = "Data Source=DESKTOP-7E9QC34;Initial Catalog=RM;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    string qry = @"Select * from Urunler ";
                    SqlDataAdapter da = new SqlDataAdapter(qry, con);
                    

                    ByCategory ds = new ByCategory();
                    da.Fill(ds, "Urunler");

                    if (ds.Tables["Urunler"].Rows.Count == 0)
                    {
                        MessageBox.Show("No data found for the selected date range.");
                        return;
                    }

                    ReportDataSource datasource = new ReportDataSource("DataSet2", ds.Tables["Urunler"]);
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.LocalReport.DataSources.Add(datasource);
                    this.reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
