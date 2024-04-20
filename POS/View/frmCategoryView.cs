using POS.Model;
using System;
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
        public frmCategoryView()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = " Select * From category where catName like '%"+ txtSearch.Text  +"%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);

            MainClass.LoadData(qry, guna2DataGridView1 , lb);
        }


        private void frmCategoryView_Load(object sender, EventArgs e)
        {
            GetData();
        }
        
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frnCategoryAdd frm = new frnCategoryAdd();
            frm.ShowDialog();
            GetData();
        }
        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();        }
    }
}
