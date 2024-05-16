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
    public partial class frmTableAdd : SampleAdd
    {
        public frmTableAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Lütfen bir isim girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without proceeding further
            }
            string qry = "";

            if (id == 0)//insert
            {
                qry = "Insert into tables Values(@Name)";
            }
            else// Update
            {
                qry = "Update tables  Set tname= @Name where tid = @id ";
            }

            Hashtable ht = new Hashtable();
            ht.Add("id", id);
            ht.Add("@Name", txtName.Text);

            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Bşarıyla Kaydedildi...");
                id = 0;
                txtName.Text = "";
                txtName.Focus();
            }
        }
    }
}
