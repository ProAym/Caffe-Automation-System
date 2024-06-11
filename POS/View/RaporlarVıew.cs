using POS.Raporlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.View
{
    public partial class RaporlarVıew : Form
    {
        public RaporlarVıew()
        {
            InitializeComponent();
        }

        

        private void KatigoriSatis_Click(object sender, EventArgs e)
        {
            KatigoriyegoreSatis frm = new KatigoriyegoreSatis();
            frm.Show();
        }

        
    }
}
