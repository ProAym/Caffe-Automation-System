using Microsoft.Reporting.WinForms;
using POS.Raporlar;
using POS.View;
using System;
using System.Collections;
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

namespace POS.Model
{
    public partial class FaturaListeleri : SampleAdd
    {
        public FaturaListeleri()
        {
            InitializeComponent();
        }

        public int MainID = 0;
        private void FaturaListeleri_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string qry = @"select MainID, SiparisId, PersonelAd, orderType, status, total,KartNakit From tblMain
                           where status <> 'Hold'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvtable);
            lb.Items.Add(dgvWaiter);
            lb.Items.Add(dgvType);
            lb.Items.Add(dgvStatus);
            lb.Items.Add(dgvTotal);
            lb.Items.Add(dgvKartNakit);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Sıralama düzenlemesi
            int count = 0;
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                MainID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                this.Close();
            }

            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                // Print bill
                MainID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                 FisYazdir frm = new FisYazdir(MainID);
                 frm.Show();
                
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Define the query with parameter placeholders
            string qry = @"SELECT MainID, SiparisId, PersonelAd, orderType, status, total, KartNakit
                   FROM tblMain
                   WHERE aDate BETWEEN @sdate AND @edate";

            // Get the selected start and end dates from the date pickers
            DateTime startDate = guna2DateTimePicker1.Value.Date;
            DateTime endDate = guna2DateTimePicker2.Value.Date;

            // Define the connection string (replace with your actual connection string)
            string ConnectionString = "Data Source=DESKTOP-7E9QC34;Initial Catalog=RM;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";


            // Create a new DataTable to hold the query results
            DataTable dt = new DataTable();

            // Create and open a new SqlConnection
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                // Create a new SqlDataAdapter with the query and the connection
                using (SqlDataAdapter da = new SqlDataAdapter(qry, con))
                {
                    // Add parameters to the SelectCommand
                    da.SelectCommand.Parameters.AddWithValue("@sdate", startDate);
                    da.SelectCommand.Parameters.AddWithValue("@edate", endDate);

                    // Fill the DataTable with the results of the query
                    da.Fill(dt);
                }
            }

            // Assuming you have a DataGridView named dgvResults to display the data
            guna2DataGridView1.DataSource = dt;
        }
    }
}
