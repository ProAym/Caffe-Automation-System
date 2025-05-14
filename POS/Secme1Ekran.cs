 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class Secme1Ekran : Form
    {
        public Secme1Ekran()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Personel_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            PersonelGiris frm = new PersonelGiris("Personel");
            frm.Show();

        }
        private void Yonetici_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1("Yonetici");
            frm.Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
