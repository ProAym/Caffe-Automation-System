using System;
using System.Collections;
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
    public partial class FrmOnay : Form
    {
        public FrmOnay()
        {
            InitializeComponent();
        }

        private void FrmOnay_Load(object sender, EventArgs e)
        {
            GetOrders();
        }

        private void GetOrders()
        {
            flowLayoutPanel1.Controls.Clear();
            string qry1 = @"Select * from tblMain where status = 'Pending' ";
            SqlCommand cmd1 = new SqlCommand(qry1, MainClass.con);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt1);

            FlowLayoutPanel p1;

            for(int i = 0; i < dt1.Rows.Count; i++)
            {
                p1 = new FlowLayoutPanel();
                p1.AutoSize = true;
                p1.Width = 230;
                p1.Height = 350;
                p1.FlowDirection = FlowDirection.TopDown;
                p1.BorderStyle = BorderStyle.FixedSingle;
                p1.Margin = new Padding(10,10, 10, 10);

                FlowLayoutPanel p2 = new FlowLayoutPanel();

                p2 = new FlowLayoutPanel();
                p2.BackColor = Color.FromArgb(50, 55, 89);
                p2.AutoSize = true;
                p2.Width = 230;
                p2.Height = 125;
                p2.FlowDirection = FlowDirection.TopDown;
                p2.Margin = new Padding(0, 0, 0, 0);


                Label lb1 = new Label();
                lb1.ForeColor = Color.White;
                lb1.Margin =  new Padding(10, 10, 3, 0);
                lb1.AutoSize = true;

                Label lb2 = new Label();
                lb2.ForeColor = Color.White;
                lb2.Margin = new Padding(10, 5, 3, 0);
                lb2.AutoSize = true;

                Label lb3 = new Label();
                lb3.ForeColor = Color.White;
                lb3.Margin = new Padding(10, 5, 3, 0);
                lb3.AutoSize = true;

                Label lb4 = new Label();
                lb4.ForeColor = Color.White;
                lb4.Margin = new Padding(10, 5, 3, 10);
                lb4.AutoSize = true;

                lb1.Text = "Siparis :" + dt1.Rows[i]["SiparisId"].ToString();
                lb2.Text = "Hizmet Veren :" + dt1.Rows[i]["PersonelAd"].ToString();
                lb3.Text = "Siparis Saati :" + dt1.Rows[i]["Time"].ToString();
                lb4.Text = "Siparis Tipi :" + dt1.Rows[i]["orderType"].ToString();

                p2.Controls.Add(lb1);
                p2.Controls.Add(lb2);
                p2.Controls.Add(lb3);
                p2.Controls.Add(lb4);

                
                p1.Controls.Add(p2);





                int mid = Convert.ToInt32(dt1.Rows[i]["MainID"].ToString());

                string qry2 = @"SELECT * FROM tblMain m
                INNER JOIN tblDetails d ON m.MainID = d.MainID
                INNER JOIN Urunler p ON p.uID = d.proID
                WHERE m.MainID = " + mid;

                SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(dt2);

                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    Label lb5 = new Label();
                    lb5.ForeColor = Color.Black;
                    lb5.Margin = new Padding(10, 10, 3, 0);
                    lb5.AutoSize = true;

                    int no = j + 1;

                    lb5.Text = "" + no + " " + dt2.Rows[j]["uAd"].ToString() + " " + dt2.Rows[j]["qty"].ToString();

                    p1.Controls.Add(lb5);
                }


                //Siparis durumunu degistirmek icin Degistirme Butonu

                Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                b.AutoRoundedCorners = true;
                b.Size = new Size(100, 35);
                b.FillColor = Color.FromArgb(241, 85, 126);
                b.Margin = new Padding(30, 5, 3, 10);
                b.Text = "Ode";
                b.Tag = dt1.Rows[i]["MainID"].ToString();//Store id


                b.Click += new EventHandler(b_click);
                p1.Controls.Add (b);

                flowLayoutPanel1.Controls.Add(p1);
            }
        }

        private void b_click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as Guna.UI2.WinForms.Guna2Button).Tag.ToString());

            if (MessageBox.Show("Silmek istediğinizden Emin Misiniz?", "Çıkış Yap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string qry = @"Update tblMain set status = 'Complete' where MainID =@ID ";
                Hashtable ht  = new Hashtable();
                ht.Add("@ID", id);

                if(MainClass.SQL(qry,ht) > 0)
                {
                    MessageBox.Show("Başarıyla Kaydedildi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                GetOrders();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
