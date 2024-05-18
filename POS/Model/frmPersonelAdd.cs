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
    public partial class frmPersonelAdd : SampleAdd
    {
        public frmPersonelAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        private void frmPersonelAdd_Load(object sender, EventArgs e)
        {

        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            // Check if any required field is empty
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("İsim Girmeiniz.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone cannot be empty.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cbRole.Text))
            {
                MessageBox.Show("Role cannot be empty.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbRole.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTCKN.Text))
            {
                MessageBox.Show("TCKN cannot be empty.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTCKN.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtSifre.Text))
            {
                MessageBox.Show("Password cannot be empty.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtSifre.Focus();
                return;
            }

            if (txtTCKN.Text.Length != 11)
            {
                MessageBox.Show("TCKN tam olarak 11 karakter uzunluğunda olmalıdır.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTCKN.Focus();
                return;
            }

            string connectionString = "Data Source=DESKTOP-7E9QC34;Initial Catalog=RM;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string checkTCKNQuery = "SELECT COUNT(*) FROM Personel WHERE TCKN = @TCKN";
                SqlCommand cmd = new SqlCommand(checkTCKNQuery, con);
                cmd.Parameters.AddWithValue("@TCKN", txtTCKN.Text);

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Bu TCKN zaten mevcut.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTCKN.Focus();
                    return;
                }
                string qry = "";

                if (id == 0)//insert
                {
                    qry = "Insert into Personel Values(@Name, @Phone, @Role,@tckn,@sifre)";
                }
                else// Update
                {
                    qry = "Update Personel  Set pAd= @Name, pTelefon = @Phone, pRol = @Role,TCKN = @tckn, pSifre= @sifre where PersonelID = @id ";
                }

                Hashtable ht = new Hashtable();
                ht.Add("id", id);
                ht.Add("@Name", txtName.Text);
                ht.Add("@Phone", txtPhone.Text);
                ht.Add("@Role", cbRole.Text);
                ht.Add("@tckn", txtTCKN.Text);
                ht.Add("@sifre", TxtSifre.Text);


                if (MainClass.SQL(qry, ht) > 0)
                {
                    MessageBox.Show("Bşarıyla Eklendi...");
                    id = 0;
                    txtName.Text = "";
                    txtPhone.Text = "";
                    cbRole.SelectedIndex = -1;
                    txtTCKN.Text = "";
                    TxtSifre.Text = "";
                    txtName.Focus();
                }
            }


        }
    }
}
