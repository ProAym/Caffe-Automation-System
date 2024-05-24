using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS.View
{
    public partial class StockView : Form
    {
        public StockView()
        {
            InitializeComponent();
        }

        private void AyarlarView_Load(object sender, EventArgs e)
        {
            LoadInventoryData();
        }

        private void LoadInventoryData()
        {
            string qry = "SELECT UrunID, UrunAdi, Adet, Threshold , LastUpdated FROM Stok";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-7E9QC34;Initial Catalog=RM;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                using (SqlCommand cmd = new SqlCommand(qry, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            guna2DataGridView1.DataSource = dt;
        }

       

        private void UpdateInventory(int productId, int YeniStokLeveli, int newReorderThreshold)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-7E9QC34;Initial Catalog=RM;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Update Urunler table
                        string updateQry = "UPDATE Stok SET Adet = @StockLevel, Threshold = @ReorderThreshold, LastUpdated = GETDATE() WHERE UrunID = @ProductID";
                        using (SqlCommand updateCmd = new SqlCommand(updateQry, con, transaction))
                        {
                            updateCmd.Parameters.AddWithValue("@StockLevel", YeniStokLeveli);;
                            updateCmd.Parameters.AddWithValue("@ReorderThreshold", newReorderThreshold);
                            updateCmd.Parameters.AddWithValue("@ProductID", productId);
                            updateCmd.ExecuteNonQuery();
                        }

                        // Insert into InventoryLogs
                        string logQry = "INSERT INTO DepoGirdileri (UrunID, GirelenAdet, Tarih) VALUES (@ProductID, @ChangeAmount, GETDATE())";
                        using (SqlCommand logCmd = new SqlCommand(logQry, con, transaction))
                        {
                            logCmd.Parameters.AddWithValue("@ProductID", productId);
                            logCmd.Parameters.AddWithValue("@ChangeAmount", YeniStokLeveli); // assuming ChangeAmount is the new stock level
                            logCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private void LoadInventoryLogs(int productId)
        {
            string qry = "SELECT GirdiID, UrunID, GirelenAdet, Tarih FROM DepoGirdileri WHERE UrunID = @ProductID ORDER BY Tarih DESC";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-7E9QC34;Initial Catalog=RM;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                using (SqlCommand cmd = new SqlCommand(qry, con))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            logsDataGridView.DataSource = dt; 
        }

        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                int productId = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["UrunID"].Value);
                LoadInventoryLogs(productId);
            }
        }

        private void btnSaveChanges_Click_1(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir ürün seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];
            int productId = Convert.ToInt32(selectedRow.Cells["UrunID"].Value);
            int YeniStokLeveli;
            int newReorderThreshold;

            if (!int.TryParse(txtStockLevel.Text, out YeniStokLeveli) || !int.TryParse(txtReorderThreshold.Text, out newReorderThreshold))
            {
                MessageBox.Show("Geçerli bir stok seviyesi ve yeniden sipariş eşiği girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateInventory(productId, YeniStokLeveli, newReorderThreshold);
            LoadInventoryData();
            LoadInventoryLogs(productId);
        }
    }
}
