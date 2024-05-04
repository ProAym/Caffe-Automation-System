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
        public Form1()
        {
            InitializeComponent();
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
            //Create database and user tables
            if( MainClass.IsValidUser(TxtUser.Text, TxtPass.Text) == false)
            {
                MessageBox.Show("Hatali kullanici adi veya sifre!");
            }
            else
            {
                this.Hide();
                frmMain frm =  new frmMain();
                frm.Show();
            }

            //insert a user first
        }
    }
}
