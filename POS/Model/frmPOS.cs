using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Model
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }

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

                    CategoryPanel.Controls.Add(b);
                }
            }
        }

        private void AddItems(string id, string name, string cat, string price, Image pImage)
        {
            int parsedPrice;
            if (!int.TryParse(price, out parsedPrice))
            {
                // Dönüşüm başarısız oldu, uygun bir işlem yapılabilir.
                // Örneğin, bir hata mesajı gösterebilir veya varsayılan bir fiyat atayabilirsiniz.
                return;
            }

            var w = new ucProduct()
            {
                PName = name,
                PPrice = parsedPrice,
                PCategory = cat,
                PImage = pImage,
                id = Convert.ToInt32(id),
            };

            ProductPanel.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;
                foreach (DataGridViewRow Item in guna2DataGridView1.Rows)
                {
                    //this Will check if product already there then add one to the quantity and update price
                    if (Convert.ToInt32(Item.Cells["dgvid"].Value) == wdg.id)
                    {
                        Item.Cells["dgvQty"].Value = int.Parse(Item.Cells["dgvQty"].Value.ToString()) + 1;
                        Item.Cells["dgvAmount"].Value = int.Parse(Item.Cells["dgvQty"].Value.ToString()) * 
                        double.Parse(Item.Cells["dgvPrice"].Value.ToString());

                        return;

                    }
                }

                guna2DataGridView1.Rows.Add(new object[] { 0, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice });
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

                AddItems(item["uID"].ToString(), item["uAd"].ToString(), item["catName"].ToString(),
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
    }
}
