﻿using Guna.UI2.WinForms;
using POS.Raporlar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace POS.Model
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }

        public int MainID = 0;


        private void frmPOS_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();
            ProductPanel.Controls.Clear();
            LoadProducts();
            SetOrderDetails();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCategory()
        {
            string qry = "Select * from category";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CategoryPanel.Controls.Clear();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Guna2Button b = new Guna2Button
                    {
                        FillColor = Color.FromArgb(217, 200, 189),
                        Size = new Size(197, 53),
                        ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton,
                        Text = row["catName"].ToString()
                    };

                    b.Click += new EventHandler(b_Click);
                    CategoryPanel.Controls.Add(b);
                }
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            Guna2Button b = (Guna2Button)sender;
            if (b.Text == "Tum Kategoriler")
            {
                txtSearch.Text = "1";
                txtSearch.Text = "";
                return;
            }
            foreach (var item in ProductPanel.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PCategory.ToLower().Contains(b.Text.Trim().ToLower());
            }
        }

        private void AddItems(string id, string proID, string name, string cat, string price, Image pImage, string v)
        {
            if (!int.TryParse(price, out int parsedPrice))
            {
                return;
            }

            var w = new ucProduct()
            {
                PName = name,
                PPrice = parsedPrice,
                PCategory = cat,
                PImage = pImage,
                id = Convert.ToInt32(proID)
            };

            ProductPanel.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;
                bool productFound = false;

                foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                {
                    if (Convert.ToInt32(item.Cells["dgvProID"].Value) == wdg.id)
                    {
                        item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) + 1;
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) * wdg.PPrice;
                        productFound = true;
                        break;
                    }
                }

                if (!productFound)
                {
                    guna2DataGridView1.Rows.Add(new object[] { 0, 0, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice * 1 });
                }

                GetTotal();
            };
        }

        private void LoadProducts()
        {
            string qry = "SELECT u.uID, u.uAd, u.uFiyat, u.uImage, c.catName, c.catID FROM Urunler u INNER JOIN category c ON u.KategoriID = c.catID";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                byte[] imagearray = (byte[])item["uImage"];
                AddItems("0", item["uID"].ToString(), item["uAd"].ToString(), item["catName"].ToString(),
                    item["uFiyat"].ToString(), Image.FromStream(new MemoryStream(imagearray)),
                    item["catID"].ToString()); // Pass the KategoriID to AddItems method
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in ProductPanel.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PName.ToLower().Contains(txtSearch.Text.Trim().ToLower());
            }
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        private void GetTotal()
        {
            double tot = 0;
            lblTotal.Text = "";
            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            {
                tot += double.Parse(item.Cells["dgvAmount"].Value.ToString());
            }
            lblTotal.Text = tot.ToString("N2");
        }

        private void BtnYeni_Click_1(object sender, EventArgs e)
        {
            ResetOrderForm();
            SetOrderDetails();
        }




        private void BtnBeklet_Click_1(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Lütfen devam etmeden önce bir sipariş türü seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveOrder();
            MessageBox.Show("Başarıyla kaydedildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetOrderForm();
        }

        public int id = 0;
        private void btnBill_Click(object sender, EventArgs e)
        {
            FaturaListeleri frm = new FaturaListeleri();
            MainClass.BlurBackground(frm);

            if (frm.MainID > 0)
            {
                id = frm.MainID;
                MainID = frm.MainID;
                LoadEntries();
                PrintBill();
            }
        }

        private void LoadEntries()
        {
            string qry = @"SELECT * FROM tblMain m
                INNER JOIN tblDetails d ON m.MainID = d.MainID
                INNER JOIN Urunler p ON p.uID = d.proID
                INNER JOIN category c ON p.KategoriID = c.catID
                WHERE m.MainID = " + id;

            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                guna2DataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    guna2DataGridView1.Rows.Add(new object[]
                    {
                        0,
                        item["DetailsID"],
                        item["proID"],
                        item["uAd"],
                        item["qty"],
                        item["fiyat"],
                        item["Toplam"],
                        item["KategoriID"]
                    });
                }

                lblTable.Text = dt.Rows[0]["SiparisId"].ToString();
                lblWaiter.Text = dt.Rows[0]["PersonelAd"].ToString();
                lblTotal.Text = dt.Rows[0]["total"].ToString();

                lblTable.Visible = true;
                lblWaiter.Visible = true;
                GetTotal();
            }
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Lütfen bir ürün seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveOrder();

            FrmOdemeAl frm = new FrmOdemeAl
            {
                MainID = MainID,
                amt = Convert.ToDouble(lblTotal.Text)
            };
            MainClass.BlurBackground(frm);

            if (frm.DialogResult == DialogResult.OK)
            {
                UpdateOrderStatus("Ödendi");

                // Subtract the ingredients used in the order from the stock
                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    int urunId = Convert.ToInt32(row.Cells["dgvProID"].Value);
                    Dictionary<string, int> ingredients = GetIngredients(urunId);
                    UpdateStock(ingredients);
                }

                ResetOrderForm();
                MessageBox.Show("Ödeme başarıyla alındı ve sipariş kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void SaveOrder()
        {
            string qry1;
            string qry2;
            int detailID = 0;

            if (MainID == 0)
            {
                qry1 = @"Insert into tblMain (aDate, Time, SiparisId, PersonelAd, status, total, received, change)
                         Values (@aDate, @aTime, @Siparis, @PersonelAd, @status, @total, @received, @change);
                         Select SCOPE_IDENTITY()";
            }
            else
            {
                qry1 = @"Update tblMain Set status = @status, total = @total, received = @received, change = @change 
                         where MainID = @ID";
            }

            SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
            cmd.Parameters.AddWithValue("@ID", MainID);
            cmd.Parameters.AddWithValue("@aDate", DateTime.Today);
            cmd.Parameters.AddWithValue("@aTime", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@Siparis", lblTable.Text);
            cmd.Parameters.AddWithValue("@PersonelAd", lblWaiter.Text);
            cmd.Parameters.AddWithValue("@status", "Hold");

            cmd.Parameters.AddWithValue("@total", Convert.ToDouble(lblTotal.Text));
            cmd.Parameters.AddWithValue("@received", 0);
            cmd.Parameters.AddWithValue("@change", 0);

            if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            if (MainID == 0) { MainID = Convert.ToInt32(cmd.ExecuteScalar()); } else { cmd.ExecuteNonQuery(); }
            if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                detailID = Convert.ToInt32(row.Cells["dgvid"].Value);

                if (detailID == 0)
                {
                    qry2 = @"Insert into tblDetails (MainID, proID, qty, fiyat, Toplam) Values (@MainID, @proID, @qty, @fiyat, @Toplam)";
                }
                else
                {
                    qry2 = @"Update tblDetails Set proID = @proID, qty = @qty, fiyat = @fiyat, Toplam = @Toplam
                             where DetailsID = @ID";
                }

                SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                cmd2.Parameters.AddWithValue("@ID", detailID);
                cmd2.Parameters.AddWithValue("@MainID", MainID);
                cmd2.Parameters.AddWithValue("@proID", Convert.ToInt32(row.Cells["dgvProID"].Value));
                cmd2.Parameters.AddWithValue("@qty", Convert.ToInt32(row.Cells["dgvQty"].Value));
                cmd2.Parameters.AddWithValue("@fiyat", Convert.ToDouble(row.Cells["dgvPrice"].Value));
                cmd2.Parameters.AddWithValue("@Toplam", Convert.ToDouble(row.Cells["dgvAmount"].Value));

                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                cmd2.ExecuteNonQuery();
                if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
            }
        }

        private void UpdateOrderStatus(string status)
        {
            string qry = "Update tblMain Set status = @status where MainID = @ID";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            cmd.Parameters.AddWithValue("@ID", MainID);
            cmd.Parameters.AddWithValue("@status", status);

            if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            cmd.ExecuteNonQuery();
            if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
        }

        private void ResetOrderForm()
        {
            MainID = 0;
            guna2DataGridView1.Rows.Clear();
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            lblTotal.Text = "00,00";
        }






        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the dgvSilme column
            if (e.ColumnIndex == guna2DataGridView1.Columns["dgvSilme"].Index && e.RowIndex >= 0)
            {
                // Get the current quantity of the product
                int currentQty = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvQty"].Value);

                if (currentQty > 1)
                {
                    // Decrease the quantity by 1
                    currentQty--;
                    guna2DataGridView1.Rows[e.RowIndex].Cells["dgvQty"].Value = currentQty;

                    // Update the amount
                    int price = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvPrice"].Value);
                    guna2DataGridView1.Rows[e.RowIndex].Cells["dgvAmount"].Value = currentQty * price;
                }
                else
                {
                    // If quantity is 1, remove the row
                    guna2DataGridView1.Rows.RemoveAt(e.RowIndex);
                }

                // Update the total
                GetTotal();
            }
        }

        private void SetOrderDetails()
        {
            // Generate a unique Siparis ID
            int uniqueSiparisId = GenerateUniqueSiparisId();
            lblTable.Text = uniqueSiparisId.ToString();
            lblTable.Visible = true;

            // Set the name of the logged-in personnel
            if (!string.IsNullOrEmpty(MainClass.USER))
            {
                lblWaiter.Text = MainClass.USER;
                lblWaiter.Visible = true;
            }
            else
            {
                lblWaiter.Text = "";
                lblWaiter.Visible = false;
            }
        }

        private int GenerateUniqueSiparisId()
        {
            Random random = new Random();
            int siparisId;

            while (true)
            {
                // Generate a random Siparis ID between 1000 and 9999
                siparisId = random.Next(1000, 9999);

                // Check if the generated ID already exists in the database
                if (!SiparisIdExists(siparisId))
                {
                    break;
                }
            }

            return siparisId;
        }

        private bool SiparisIdExists(int siparisId)
        {
            bool exists = false;

            // Define the connection string (replace with your actual connection string)
            string connectionString = "Data Source=DESKTOP-7E9QC34;Initial Catalog=RM;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";


            string qry = "SELECT COUNT(*) FROM tblMain WHERE SiparisId = @SiparisId";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(qry, con))
                {
                    cmd.Parameters.AddWithValue("@SiparisId", siparisId);

                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    exists = (count > 0);
                }
            }

            return exists;
        }

        private void PrintBill()
        {
            FisYazdir fisForm = new FisYazdir(MainID);
            fisForm.Show();
        }


        private Dictionary<string, int> GetIngredients(int urunId)
        {
            Dictionary<string, int> ingredients = new Dictionary<string, int>();

            string qry = @"SELECT UrunAdi, UniteAdeti FROM UrunIngredients WHERE UrunID = @UrunID";

            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            cmd.Parameters.AddWithValue("@UrunID", urunId);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string ingredientName = reader["UrunAdi"].ToString();
                    int quantity = int.Parse(reader["UniteAdeti"].ToString());
                    if (ingredients.ContainsKey(ingredientName))
                    {
                        ingredients[ingredientName] += quantity;
                    }
                    else
                    {
                        ingredients.Add(ingredientName, quantity);
                    }
                }
            }

            return ingredients;
        }


        private void UpdateStock(Dictionary<string, int> ingredients)
        {
            using (SqlTransaction transaction = MainClass.con.BeginTransaction())
            {
                try
                {
                    foreach (var ingredient in ingredients)
                    {
                        // Update stock in the Stok table
                        string updateQry = @"
                    UPDATE Stok
                    SET Adet = Adet - @UsedQuantity
                    WHERE UrunAdi = @UrunAdi";

                        SqlCommand updateCmd = new SqlCommand(updateQry, MainClass.con, transaction);
                        updateCmd.Parameters.AddWithValue("@UsedQuantity", ingredient.Value);
                        updateCmd.Parameters.AddWithValue("@UrunAdi", ingredient.Key);

                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new Exception($"No stock update for {ingredient.Key}. Check if the product name matches exactly.");
                        }

                        // Log the inventory change in DepoGirdileri
                        string logQry = @"
                    INSERT INTO DepoGirdileri (UrunID, GirilenAdet, Tarih)
                    VALUES ((SELECT UrunID FROM Stok WHERE UrunAdi = @UrunAdi), @UsedQuantity, @Date)";

                        SqlCommand logCmd = new SqlCommand(logQry, MainClass.con, transaction);
                        logCmd.Parameters.AddWithValue("@UrunAdi", ingredient.Key);
                        logCmd.Parameters.AddWithValue("@UsedQuantity", -ingredient.Value);
                        logCmd.Parameters.AddWithValue("@Date", DateTime.Now);

                        logCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    // Show success message after stock update
                    MessageBox.Show("Stock has been successfully updated.", "Stock Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error updating stock: {ex.Message}", "Stock Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }








    }
}

