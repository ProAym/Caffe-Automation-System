using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            string qry = "";

            if (id == 0)//insert
            {
                qry = "Insert into Personel Values(@Name, @Phone, @Role,@tckn)";
            }
            else// Update
            {
                qry = "Update Personel  Set pAd= @Name, pTelefon = @Phone, pRol = @Role,TCKN = @tckn  where PersonelID = @id ";
            }

            Hashtable ht = new Hashtable();
            ht.Add("id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@Phone", txtPhone.Text);
            ht.Add("@Role", cbRole.Text);
            ht.Add("@tckn", txtTCKN.Text);


            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Bşarıyla Kaydedildi...");
                id = 0;
                txtName.Text = "";
                txtPhone.Text = "";
                cbRole.SelectedIndex = -1;
                txtTCKN.Text = "";
                txtName.Focus();
            }
        }
    }
}
