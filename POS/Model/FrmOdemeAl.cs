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
using System.Windows.Forms.VisualStyles;

namespace POS.Model
{
    public partial class FrmOdemeAl : Form
    {
        
        public FrmOdemeAl()
        {
            InitializeComponent();
        }

        public double amt;
        public int MainID = 0;

        private void FrmOdemeAl_Load(object sender, EventArgs e)
        {
            txtBillAmount.Text = amt.ToString();
            txtBillAmount.ReadOnly = true; // Make Bill Amount non-editable
            txtChange.ReadOnly = true; // Make Change non-editable

            
        }

        private void txtReceived_TextChanged(object sender, EventArgs e)
        {
            double amt = 0;
            double receipt = 0;
            double change = 0;

            double.TryParse(txtBillAmount.Text, out amt);
            double.TryParse(txtReceived.Text, out receipt);

            change =Math.Abs( receipt - amt); // Calculate the change

            txtChange.Text = change.ToString("N2"); // Format to 2 decimal places
        }

        private void btnÖde_Click(object sender, EventArgs e)
        {
            string qry = @"Update tblMain set total = @total, received = @received, change = @change, status = 'Ödendi'
                            WHERE MainID = @id";

            Hashtable ht = new Hashtable();
            ht.Add("@total", txtBillAmount.Text);
            ht.Add("@received", txtReceived.Text);
            ht.Add("@change", txtChange.Text);
            ht.Add("@id", MainID);

            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Ödeme alabilmek için Kasa açılmıştır!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
