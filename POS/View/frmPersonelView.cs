using POS.Model;
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

namespace POS.View
{
    public partial class frmPersonelView : SampleView
    {
        public frmPersonelView()
        {
            InitializeComponent();
            guna2DataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        private void frmPersonelView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            string qry = " Select * From Personel where pAd like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvRole);
            lb.Items.Add(dgvTC);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
            guna2DataGridView1.Columns["pSifre"].Visible = false;
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmPersonelAdd());
            GetData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                frmPersonelAdd frm = new frmPersonelAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                frm.txtPhone.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPhone"].Value);
                frm.cbRole.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvRole"].Value);
                frm.txtTCKN.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvTC"].Value);
                MainClass.BlurBackground(frm);
                GetData();
            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                if (MessageBox.Show("Silmek istediğinizden Emin Misiniz?", "Personel Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    string qry = "Delete from Personel where PersonelID= " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQL(qry, ht);
                    MessageBox.Show("başarıyla Silindi");
                    GetData();
                }
            }
        }
        // Bu fonksiyon tc kimlik numarasini gizliyor Tamamen gozukmuyor
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView1.Columns["dgvTC"].Index && e.Value != null)
            {
                string value = e.Value.ToString();
                if (value.Length > 4)
                {
                    int lengthToMask = value.Length - 4;
                    string maskedValue = value.Substring(0, 4) + new string('*', lengthToMask) + value.Substring(value.Length - 4);
                    e.Value = maskedValue;
                }
            }
        }
    }
}
