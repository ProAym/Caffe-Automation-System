using POS.Model;
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

namespace POS.View
{
    public partial class frmCategoryView : SampleView
    {

        private void InitializeDataGridViewColumns()
        {
            // Ensure these columns are added to guna2DataGridView1
            if (!guna2DataGridView1.Columns.Contains("dgvid"))
            {
                guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "dgvid", HeaderText = "ID" });
            }

            if (!guna2DataGridView1.Columns.Contains("dgvName"))
            {
                guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "dgvName", HeaderText = "Name" });
            }
        }
        public frmCategoryView()
        {
            InitializeComponent();
            InitializeDataGridViewColumns();  // Ensure columns are initialized

        }

        public void GetData()
        {
            string qry = "SELECT * FROM category WHERE catName LIKE '%" + txtSearch.Text + "%'";

            ListBox lb = new ListBox();

            var dgvid = guna2DataGridView1.Columns["dgvid"];
            var dgvName = guna2DataGridView1.Columns["dgvName"];

            if (dgvid != null)
            {
                lb.Items.Add(dgvid);
            }
            else
            {
                MessageBox.Show("dgvid column does not exist in the DataGridView.");
            }

            if (dgvName != null)
            {
                lb.Items.Add(dgvName);
            }
            else
            {
                MessageBox.Show("dgvName column does not exist in the DataGridView.");
            }

            if (lb.Items.Count > 0)  // Ensure there are items to process
            {
                MainClass.LoadData(qry, guna2DataGridView1, lb);
            }
            else
            {
                MessageBox.Show("No valid columns were found to process.");
            }
        }


        private void frmCategoryView_Load(object sender, EventArgs e)
        {
            GetData();
        }
        
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            //frnCategoryAdd frm = new frnCategoryAdd();
            //frm.ShowDialog();

            MainClass.BlurBackground(new frnCategoryAdd());
            GetData();
        }
        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();        
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                frnCategoryAdd frm = new frnCategoryAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                MainClass.BlurBackground(frm);
                GetData();
            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel") 
            {

                if(MessageBox.Show("Silmek istediğinizden Emin Misiniz?", "Kategori Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    string qry = "Delete from category where catID= " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQL(qry, ht);

                    MessageBox.Show("başarıyla Silindi");
                    GetData();
                }
                
            }

        }

        
    }
}
