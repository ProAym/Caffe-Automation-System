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
    public partial class PersonelGiris : Form
    {
        private string userType;
        public PersonelGiris(string userType)
        {
            InitializeComponent();
            this.userType = userType;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = TxtUser.Text;
            string password = TxtPass.Text;
            if (MainClass.IsValidUser(TxtUser.Text, TxtPass.Text, userType))
            {

                MessageBox.Show($"Hoşgeldiniz, {MainClass.USER}");
                this.Hide();
                PersonelMenu frm = new PersonelMenu();
                frm.Show();
            }
            else
            {
                
                MessageBox.Show("Hatali kullanici adi veya sifre!");
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Secme1Ekran frm = new Secme1Ekran();
            frm.Show();
        }
    }
}
