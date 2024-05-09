using Guna.UI2.WinForms;
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
            guna2DataGridView1.BorderStyle=BorderStyle.FixedSingle;
            AddCategory();
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
        private void AddItems(int id, string name, string cat, int price, Image pImage)
        {
            var w = new ucProduct()
            {
                PName = name,
                PPrice = price,
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
                        Item.Cells["dgvQty"].Value = int.Parse(Item.Cells["dgvQty"].ToString()) + 1;
                        Item.Cells["dgvAmount"].Value = int.Parse(Item.Cells["dgvQty"].ToString()) * int.Parse(Item.Cells["dgvPrice"].ToString());

                    }

                    guna2DataGridView1.Rows.Add(new object[] { 0, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice });
                }
            };
        }


        // Getting product's data from database
        private void LoadProducts() { }
    }
}
