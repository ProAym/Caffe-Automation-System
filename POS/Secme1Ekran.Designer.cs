namespace POS
{
    partial class Secme1Ekran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Secme1Ekran));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.Yonetici = new Guna.UI2.WinForms.Guna2CircleButton();
            this.Personel = new Guna.UI2.WinForms.Guna2CircleButton();
            this.BtnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            resources.ApplyResources(this.guna2Panel1, "guna2Panel1");
            this.guna2Panel1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2Panel1.Controls.Add(this.Yonetici);
            this.guna2Panel1.Controls.Add(this.Personel);
            this.guna2Panel1.Controls.Add(this.BtnExit);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = global::POS.Properties.Resources._2;
            resources.ApplyResources(this.guna2CirclePictureBox1, "guna2CirclePictureBox1");
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.ShadowDecoration.Parent = this.guna2CirclePictureBox1;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // Yonetici
            // 
            this.Yonetici.BackColor = System.Drawing.Color.Transparent;
            this.Yonetici.CheckedState.Parent = this.Yonetici;
            this.Yonetici.CustomImages.Parent = this.Yonetici;
            this.Yonetici.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            resources.ApplyResources(this.Yonetici, "Yonetici");
            this.Yonetici.ForeColor = System.Drawing.Color.Black;
            this.Yonetici.HoverState.Parent = this.Yonetici;
            this.Yonetici.Image = global::POS.Properties.Resources.manager;
            this.Yonetici.ImageSize = new System.Drawing.Size(60, 60);
            this.Yonetici.Name = "Yonetici";
            this.Yonetici.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Yonetici.ShadowDecoration.Parent = this.Yonetici;
            this.Yonetici.Click += new System.EventHandler(this.Yonetici_Click);
            // 
            // Personel
            // 
            this.Personel.BackColor = System.Drawing.Color.Transparent;
            this.Personel.CheckedState.Parent = this.Personel;
            this.Personel.CustomImages.Parent = this.Personel;
            this.Personel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            resources.ApplyResources(this.Personel, "Personel");
            this.Personel.ForeColor = System.Drawing.Color.Black;
            this.Personel.HoverState.Parent = this.Personel;
            this.Personel.Image = global::POS.Properties.Resources.staff_symbol;
            this.Personel.ImageSize = new System.Drawing.Size(60, 60);
            this.Personel.Name = "Personel";
            this.Personel.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Personel.ShadowDecoration.Parent = this.Personel;
            this.Personel.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // BtnExit
            // 
            resources.ApplyResources(this.BtnExit, "BtnExit");
            this.BtnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(200)))), ((int)(((byte)(189)))));
            this.BtnExit.HoverState.Parent = this.BtnExit;
            this.BtnExit.IconColor = System.Drawing.Color.White;
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.ShadowDecoration.Parent = this.BtnExit;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // Secme1Ekran
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Secme1Ekran";
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ControlBox BtnExit;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2CircleButton Yonetici;
        private Guna.UI2.WinForms.Guna2CircleButton Personel;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
    }
}