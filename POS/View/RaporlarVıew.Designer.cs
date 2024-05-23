namespace POS.View
{
    partial class RaporlarVıew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Personel = new Guna.UI2.WinForms.Guna2Button();
            this.KatigoriSatis = new Guna.UI2.WinForms.Guna2Button();
            this.Menu = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Raporlar";
            // 
            // Personel
            // 
            this.Personel.CheckedState.Parent = this.Personel;
            this.Personel.CustomImages.Parent = this.Personel;
            this.Personel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(200)))), ((int)(((byte)(189)))));
            this.Personel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Personel.ForeColor = System.Drawing.Color.Black;
            this.Personel.HoverState.Parent = this.Personel;
            this.Personel.Location = new System.Drawing.Point(33, 88);
            this.Personel.Name = "Personel";
            this.Personel.ShadowDecoration.Parent = this.Personel;
            this.Personel.Size = new System.Drawing.Size(180, 126);
            this.Personel.TabIndex = 1;
            this.Personel.Text = "Personel";
            // 
            // KatigoriSatis
            // 
            this.KatigoriSatis.CheckedState.Parent = this.KatigoriSatis;
            this.KatigoriSatis.CustomImages.Parent = this.KatigoriSatis;
            this.KatigoriSatis.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(200)))), ((int)(((byte)(189)))));
            this.KatigoriSatis.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KatigoriSatis.ForeColor = System.Drawing.Color.Black;
            this.KatigoriSatis.HoverState.Parent = this.KatigoriSatis;
            this.KatigoriSatis.Location = new System.Drawing.Point(219, 88);
            this.KatigoriSatis.Name = "KatigoriSatis";
            this.KatigoriSatis.ShadowDecoration.Parent = this.KatigoriSatis;
            this.KatigoriSatis.Size = new System.Drawing.Size(180, 126);
            this.KatigoriSatis.TabIndex = 2;
            this.KatigoriSatis.Text = "Kategoriye Gore Satislar";
            this.KatigoriSatis.Click += new System.EventHandler(this.KatigoriSatis_Click);
            // 
            // Menu
            // 
            this.Menu.CheckedState.Parent = this.Menu;
            this.Menu.CustomImages.Parent = this.Menu;
            this.Menu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(200)))), ((int)(((byte)(189)))));
            this.Menu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.Menu.ForeColor = System.Drawing.Color.Black;
            this.Menu.HoverState.Parent = this.Menu;
            this.Menu.Location = new System.Drawing.Point(405, 88);
            this.Menu.Name = "Menu";
            this.Menu.ShadowDecoration.Parent = this.Menu;
            this.Menu.Size = new System.Drawing.Size(180, 126);
            this.Menu.TabIndex = 3;
            this.Menu.Text = "Menü";
            this.Menu.Click += new System.EventHandler(this.Menu_Click);
            // 
            // RaporlarVıew
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(863, 568);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.KatigoriSatis);
            this.Controls.Add(this.Personel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RaporlarVıew";
            this.Text = "RaporlarVıew";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button Personel;
        private Guna.UI2.WinForms.Guna2Button KatigoriSatis;
        private Guna.UI2.WinForms.Guna2Button Menu;
    }
}