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
    public partial class Form1 : Form
    {
        private string userType;
        public Form1(string userType)
        {
            InitializeComponent();
            this.userType = userType;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = TxtUser.Text;
            string password = TxtPass.Text;
            //Create database and user tables
            if ( MainClass.IsValidUser(TxtUser.Text, TxtPass.Text, userType))
            {
                
                MessageBox.Show($"Hoşgeldiniz, {MainClass.USER}");
                this.Hide();
                frmMain frm = new frmMain();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Hatali kullanici adi veya sifre!");
            }

            //insert a user first
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Secme1Ekran frm = new Secme1Ekran();
            frm.Show();
        }
    }
}
