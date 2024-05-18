using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    internal class MainClass
    {

        public static readonly string con_string = "Data Source=DESKTOP-7E9QC34;Initial Catalog = RM; Integrated Security = True;";
        public static SqlConnection con = new SqlConnection(con_string);

       
        //Method to check User Validation


        public static bool IsValidUser(string user, string password, string userType)
        {
            bool isValid = false;
            string qry = "";

            if (userType == "Personel")
            {
                qry = "Select * from Personel where TCKN = @TCKN and pSifre = @Password";
            }
            else if (userType == "Yonetici")
            {
                qry = "Select * from Yonetici where TCKN = @TCKN and Sifre = @Password";
            }

            using (SqlConnection con = new SqlConnection(con_string))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@TCKN", user);
                    cmd.Parameters.AddWithValue("@Password", password);

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        isValid = true;
                        USER = userType == "Yonetici" ? dt.Rows[0]["Isim"].ToString() : dt.Rows[0]["pAd"].ToString();
                    }

                }
                catch (SqlException ex)
                {
                    // Handle database errors here (e.g., logging the exception)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return isValid;
        }


        //create username proprety

        public static string user;
        
        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }
        


        //Method for curd operation


        public static int SQL(string qry, Hashtable ht)
        {
            int res = 0;

            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                res = cmd.ExecuteNonQuery();

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }

            return res;

        }
        //For Loading data from database

        public static void LoadData(string qry, DataGridView gv, ListBox lb)
        {

            // Serial no in gridview

            gv.CellFormatting += new DataGridViewCellFormattingEventHandler(gv_CellFormatting);

            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                for (int i = 0; i < lb.Items.Count; i++)
                {
                    string colNam1 = ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[colNam1].DataPropertyName = dt.Columns[i].ToString();
                }

                gv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }

        private static void gv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Guna.UI2.WinForms.Guna2DataGridView gv = (Guna.UI2.WinForms.Guna2DataGridView)sender;
            int count = 0;

            foreach (DataGridViewRow row in gv.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        public static void BlurBackground(Form Model)
        {
            Form Background = new Form();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = 0.5d;
                Background.BackColor = Color.Black;
                Background.Size = frmMain.Instance.Size;
                Background.Location = frmMain.Instance.Location;
                Background.ShowInTaskbar = false;
                Background.Show();
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();
            }

        }

        //For cb fill
        public static void CBFill(string qry, ComboBox cb)
        {
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb.DisplayMember = "name";
            cb.ValueMember = "id";
            cb.DataSource = dt;
            cb.SelectedIndex = -1;
        }

        
    }
}
