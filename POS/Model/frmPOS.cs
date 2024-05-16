using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace POS.Model
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }

        public int MainID = 0;
        public string OrderType;
        private void frmPOS_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();

            ProductPanel.Controls.Clear();
            LoadProducts();
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
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.FillColor = Color.FromArgb(50, 55, 89);
                    b.Size = new Size(197, 53);
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    b.Text = row["catName"].ToString();

                    // event for click
                    b.Click += new EventHandler(b_Click);

                    CategoryPanel.Controls.Add(b);
                }
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;
            if(b.Text == "Tum Kategoriler")
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

        private void AddItems(String id,String proID, String name, String cat, String price, Image pImage)
        {
            int parsedPrice;
            if (!int.TryParse(price, out parsedPrice))
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

                foreach (DataGridViewRow Item in guna2DataGridView1.Rows)
                {
                    if (Convert.ToInt32(Item.Cells["dgvProID"].Value) == wdg.id)
                    {
                        // Update quantity and total amount for existing product
                        Item.Cells["dgvQty"].Value = int.Parse(Item.Cells["dgvQty"].Value.ToString()) + 1;
                        Item.Cells["dgvAmount"].Value = int.Parse(Item.Cells["dgvQty"].Value.ToString()) * wdg.PPrice;

                        productFound = true;
                        break;
                    }
                }

                if (!productFound)
                {
                    // Add a new row for the product if it's not already in the DataGridView
                    guna2DataGridView1.Rows.Add(new object[] { 0, 0, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice * 1 });
                }

                // Update the total amount
                GetTotal();
            };

        }

        private void LoadProducts()
        {
            string qry = "Select * from Urunler inner join category on catID = KategoriID";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                Byte[] imagearray = (byte[])item["uImage"];
                Byte[] imagebytearray = imagearray;

                AddItems("0",item["uID"].ToString(), item["uAd"].ToString(), item["catName"].ToString(),
                    item["uFiyat"].ToString(), Image.FromStream(new MemoryStream(imagearray)));
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
            //Sıralama düzenlemesi
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
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            guna2DataGridView1.Rows.Clear();
            MainID = 0;
            lblTotal.Text = "00,0";
        }

        private void btnTakeAway_Click_1(object sender, EventArgs e)
        {
            OrderType = "take Away";
            FrmSiparisSelect frm = new FrmSiparisSelect();
            MainClass.BlurBackground(frm);

            if (!string.IsNullOrEmpty(frm.Siparis))
            {
                lblTable.Text = frm.Siparis;
                lblTable.Visible = true;
            }
            else
            {
                lblTable.Text = "";
                lblTable.Visible = false;
            }

            FrmPersonelSecme frm1 = new FrmPersonelSecme();
            MainClass.BlurBackground(frm1);

            if (!string.IsNullOrEmpty(frm1.PersonelAd))
            {
                lblWaiter.Text = frm1.PersonelAd;
                lblWaiter.Visible = true;
            }
            else
            {
                lblWaiter.Text = "";
                lblWaiter.Visible = false;
            }
            
        }

        private void BtnDin_Click(object sender, EventArgs e)
        {
            // Check if the basket is empty
            if (guna2DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Lütfen devam etmeden önce sepete ürün ekleyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OrderType = "Din in";
            FrmSiparisSelect frm = new FrmSiparisSelect();
            MainClass.BlurBackground(frm);

            if (!string.IsNullOrEmpty(frm.Siparis))
            {
                lblTable.Text = frm.Siparis;
                lblTable.Visible = true;
            }
            else
            {
                lblTable.Text = "";
                lblTable.Visible = false;
            }

            FrmPersonelSecme frm1 = new FrmPersonelSecme();
            MainClass.BlurBackground(frm1);

            if (!string.IsNullOrEmpty(frm1.PersonelAd))
            {
                lblWaiter.Text = frm1.PersonelAd;
                lblWaiter.Visible = true;
            }
            else
            {
                lblWaiter.Text = "";
                lblWaiter.Visible = false;
            }
        }


        private void BtnBeklet_Click_1(object sender, EventArgs e)
        {
            
           // Order type is selected
            if (string.IsNullOrEmpty(OrderType))
            {
                MessageBox.Show("Lütfen devam etmeden önce bir sipariş türü seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string qry1 = ""; // Ana tablo
            string qry2 = ""; // Detay tablosu

            int detailID = 0;

            if (MainID == 0) // ekle
            {
                qry1 = @"Insert into tblMain Values(@aDate, @aTime, @Siparis, @PersonelAd,
                         @status, @orderType, @total, @received, @change);
                         Select SCOPE_IDENTITY()"; // BU SATIR EN SON EKLENEN ID DEĞERİNİ GETİRECEK
            }
            else // Güncelle
            {
                qry1 = @"Update tblMain Set status = @status, total = @total, received = @received, change = @change where MainID = @ID";
            }

            SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
            cmd.Parameters.AddWithValue("@ID", MainID);
            cmd.Parameters.AddWithValue("@aDate", Convert.ToDateTime(DateTime.Now.Date));
            cmd.Parameters.AddWithValue("@aTime", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@Siparis", lblTable.Text);
            cmd.Parameters.AddWithValue("@PersonelAd", lblWaiter.Text);
            cmd.Parameters.AddWithValue("@status", "Hold");
            cmd.Parameters.AddWithValue("@orderType", OrderType);
            cmd.Parameters.AddWithValue("@total", Convert.ToDouble(lblTotal.Text));
            cmd.Parameters.AddWithValue("@received", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@change", Convert.ToDouble(0));

            if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            if (MainID == 0) { MainID = Convert.ToInt32(cmd.ExecuteScalar()); } else { cmd.ExecuteNonQuery(); }
            if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                detailID = Convert.ToInt32(row.Cells["dgvid"].Value);

                if (detailID == 0) // Ekle
                {
                    qry2 = @"Insert into tblDetails Values (@MainID, @proID, @qty, @fiyat, @Toplam)";
                }
                else // Güncelle
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

            MessageBox.Show("Başarıyla kaydedildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainID = 0;
            detailID = 0;
            guna2DataGridView1.Rows.Clear();
            // Yeni sipariş için
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            MainID = 0;
            lblTotal.Text = "00,00";
           
            
        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            FrmOnay frm = new FrmOnay();
            MainClass.BlurBackground(frm);
        }

        public int id = 0;
        private void btnBill_Click(object sender, EventArgs e)
        {
            FaturaListeleri frm = new FaturaListeleri();
            MainClass.BlurBackground(frm);

            if(frm.MainID > 0)
            {
                id = frm.MainID;
                MainID = frm.MainID;
                LoadEntries();
            }
        }

        private void LoadEntries()
        {
            string qry3 = @"SELECT * FROM tblMain m
                INNER JOIN tblDetails d ON m.MainID = d.MainID
                INNER JOIN Urunler p ON p.uID = d.proID
                WHERE m.MainID = " + id +"";

            SqlCommand cmd3 = new SqlCommand(qry3, MainClass.con);
            DataTable dt3 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
            da2.Fill(dt3);


            if (dt3.Rows[0]["ordertype"].ToString()== "Take Away")
            {
                btnTakeAway.Checked = true;
                lblWaiter.Visible = false;
                lblTable.Visible = false;
            }
            else
            {
                BtnDin.Checked = true;
                lblWaiter.Visible = true;
                lblTable.Visible = true;
                
            }


            guna2DataGridView1.Rows.Clear();
            foreach (DataRow item in dt3.Rows)
            {
                lblTable.Text = item["Siparisid"].ToString();
                lblWaiter.Text = item["PersonelAd"].ToString();


                string detailid = item["DetailsID"].ToString();
                string proName = item["uAd"].ToString();
                string proid = item["proID"].ToString();
                string qty = item["qty"].ToString();
                string price = item["fiyat"].ToString();
                string amount = item["Toplam"].ToString();

                object[] obj = { 0, detailid, proid,proName, qty, price, amount };
                guna2DataGridView1.Rows.Add(obj);

            }
            GetTotal();
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            FrmOdemeAl frm = new FrmOdemeAl();
            frm.MainID = id;
            frm.amt = Convert.ToDouble(lblTotal.Text);
            MainClass.BlurBackground(frm);

            
            MainID = 0;
            guna2DataGridView1.Rows.Clear();
            // Yeni sipariş için
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            MainID = 0;
            lblTotal.Text = "00,00";
        }
    }
}
 

