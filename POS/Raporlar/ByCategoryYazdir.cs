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
    public partial class ByCategoryYazdir : Form
    {
        private DateTime startDate;
        private DateTime endDate;
        public ByCategoryYazdir(DateTime sdate, DateTime edate)
        {
            InitializeComponent();
            startDate = sdate.Date;
            endDate = edate.Date;
        }

        private void ByCategoryYazdir_Load(object sender, EventArgs e)
        {
            GenerateReport();
            this.reportViewer2.RefreshReport();
        }


        private void GenerateReport()
        {
            try
            {
                string ConnectionString = "Data Source=DESKTOP-7E9QC34;Initial Catalog=RM;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    string qry = @"
        SELECT 
            v.catName,
            v.aDate,
            v.uAd,
            v.qty,
            v.uFiyat,
            v.Toplam,
            ct.TotalQty,
            ct.TotalPrice
        FROM View_Katigori_gore_Satis v
        JOIN (
            SELECT 
                catName,
                SUM(qty) AS TotalQty,
                SUM(Toplam) AS TotalPrice
            FROM View_Katigori_gore_Satis
            WHERE aDate BETWEEN @sdate AND @edate
            GROUP BY catName
        ) ct ON v.catName = ct.catName
        WHERE v.aDate BETWEEN @sdate AND @edate
        ORDER BY v.catName, v.aDate, v.uAd;
        ";
                    SqlDataAdapter da = new SqlDataAdapter(qry, con);
                    da.SelectCommand.Parameters.AddWithValue("@sdate", startDate);
                    da.SelectCommand.Parameters.AddWithValue("@edate", endDate);

                    ByCategory ds = new ByCategory();
                    da.Fill(ds, "DataTable_ByCategory");

                    if (ds.Tables["DataTable_ByCategory"].Rows.Count == 0)
                    {
                        MessageBox.Show("No data found for the selected date range.");
                        return;
                    }

                    ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables["DataTable_ByCategory"]);
                    this.reportViewer2.LocalReport.DataSources.Clear();
                    this.reportViewer2.LocalReport.DataSources.Add(datasource);
                    this.reportViewer2.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
