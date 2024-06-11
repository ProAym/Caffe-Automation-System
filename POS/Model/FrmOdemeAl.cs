using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace POS.Model
{
    public partial class FrmOdemeAl : Form
    {
        public double amt;
        public int MainID = 0;
        public string orderType { get; set; }



        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        public FrmOdemeAl()
        {
            InitializeComponent();
            
        }

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

            change = Math.Abs(receipt - amt); // Calculate the change

            txtChange.Text = change.ToString("N2"); // Format to 2 decimal places
        }

        private void btnÖde_Click(object sender, EventArgs e)
        {
            
            if (!ValidateFields())
            {
                return; // Exit the method if validation fails
            }

            string qry = @"Update tblMain set total = @total, received = @received, change = @change, status = 'Ödendi', orderType = @orderType,kartNakit = @kartNakit
                            WHERE MainID = @id  ";

           

            Hashtable ht = new Hashtable();
            ht.Add("@total", txtBillAmount.Text);
            ht.Add("@received", txtReceived.Text);
            ht.Add("@change", txtChange.Text);
            ht.Add("@orderType", cbOrderType.Text);
            ht.Add("@id", MainID);
            ht.Add("@KartNakit", KartNakit.Text);





            if (MainClass.SQL(qry, ht) > 0)
            {
                if(KartNakit.Text == "Nakit") {
                    MessageBox.Show("Ödeme alabilmek için Kasa açılmıştır!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Temassız Ödeme Yönlendirilmiştir!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem != null)
            {
                orderType = comboBox.SelectedItem.ToString();
                MessageBox.Show($"Order Type: {orderType}");
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtBillAmount.Text))
            {
                MessageBox.Show("Fatura tutarı boş olamaz.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtReceived.Text))
            {
                MessageBox.Show("Alınan tutar boş olamaz.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtChange.Text))
            {
                MessageBox.Show("Para üstü boş olamaz.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbOrderType.Text))
            {
                MessageBox.Show("Sipariş türü seçilmelidir.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        private void FrmodemeAl_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void FrmodemeAl_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void FrmodemeAl_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2RadioButton1.Checked == true)
            {
                KartNakit.Text = "Kart";
            }
        }

        private void guna2RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (Nakit.Checked == true)
            {
                KartNakit.Text = "Nakit";
            }
        }
    }
}
