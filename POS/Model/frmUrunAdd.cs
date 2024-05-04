using System;
using System.Collections;
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
    public partial class frmUrunAdd : SampleAdd
    {
        public frmUrunAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        public int cID = 0;

        private void frmUrunAdd_Load(object sender, EventArgs e)
        {
            string qry = "Select catID 'id', catName 'name' from category ";

            MainClass.CBFill(qry, cbcat);

            if(cID > 0)//For update
            {
                cbcat.SelectedValue = cID;
            }
            if (id > 0)
            {
                ForUpdateLoadData();
            }
        }

        string filePath;
        Byte[] imageByteArray;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png, jpeg)|* .png; * .jpg; * .jpeg";
            if(ofd.ShowDialog() == DialogResult.OK) 
            {
                filePath = ofd.FileName;
                txtImage.Image = new Bitmap(filePath);
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0)//insert
            {
                qry = "Insert into Urunler Values(@Name, @Price, @cat,@image)";
            }
            else// Update
            {
                qry = "Update Urunler  Set uAd= @Name, uFiyat = @Price, kategoriID = @cat,uImage = @image  where uID = @id ";
            }
            //For image

            Image temp = new Bitmap(txtImage.Image);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imageByteArray = ms.ToArray();

            
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@Price", txtPrice.Text);
            ht.Add("@cat",  Convert.ToInt32(cbcat.SelectedValue));
            ht.Add("@image", imageByteArray);



            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Bşarıyla Kaydedildi...");
                id = 0;
                cID = 0;
                txtName.Text = "";
                txtPrice.Text = "";
                cbcat.SelectedIndex = 0;
                cbcat.SelectedIndex = -1;
                txtImage.Image = POS.Properties.Resources.products;
                txtName.Focus();
            }
        }

        private void ForUpdateLoadData()
        {
            string qry = @"Select * from urunler where uID = " + id + "";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["uAd"].ToString();
                txtPrice.Text = dt.Rows[0]["uFiyat"].ToString();

                Byte[] imageArray = (byte[])(dt.Rows[0]["uImage"]);
                byte[] imageByteArray = imageArray;
                txtImage.Image = Image.FromStream(new MemoryStream(imageArray));
            }


        }


    }
}
