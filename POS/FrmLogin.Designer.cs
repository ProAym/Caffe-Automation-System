﻿namespace POS
{
    partial class Form1
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
            this.TxtUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.TxtPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnLogin = new Guna.UI2.WinForms.Guna2TileButton();
            this.BtnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(105, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "TC Kimlik No:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TxtUser
            // 
            this.TxtUser.BackColor = System.Drawing.Color.Transparent;
            this.TxtUser.BorderColor = System.Drawing.Color.White;
            this.TxtUser.BorderRadius = 15;
            this.TxtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtUser.DefaultText = "";
            this.TxtUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtUser.DisabledState.Parent = this.TxtUser;
            this.TxtUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtUser.FocusedState.Parent = this.TxtUser;
            this.TxtUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtUser.HoverState.Parent = this.TxtUser;
            this.TxtUser.Location = new System.Drawing.Point(108, 194);
            this.TxtUser.Margin = new System.Windows.Forms.Padding(4);
            this.TxtUser.Name = "TxtUser";
            this.TxtUser.PasswordChar = '\0';
            this.TxtUser.PlaceholderText = "";
            this.TxtUser.SelectedText = "";
            this.TxtUser.ShadowDecoration.Parent = this.TxtUser;
            this.TxtUser.Size = new System.Drawing.Size(262, 41);
            this.TxtUser.TabIndex = 0;
            this.TxtUser.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // TxtPass
            // 
            this.TxtPass.BackColor = System.Drawing.Color.Transparent;
            this.TxtPass.BorderRadius = 15;
            this.TxtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtPass.DefaultText = "";
            this.TxtPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtPass.DisabledState.Parent = this.TxtPass;
            this.TxtPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtPass.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TxtPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtPass.FocusedState.Parent = this.TxtPass;
            this.TxtPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtPass.HoverState.Parent = this.TxtPass;
            this.TxtPass.Location = new System.Drawing.Point(109, 283);
            this.TxtPass.Margin = new System.Windows.Forms.Padding(5);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.PasswordChar = '\0';
            this.TxtPass.PlaceholderText = "";
            this.TxtPass.SelectedText = "";
            this.TxtPass.ShadowDecoration.Parent = this.TxtPass;
            this.TxtPass.Size = new System.Drawing.Size(262, 41);
            this.TxtPass.TabIndex = 1;
            this.TxtPass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(117, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Şifre:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.Transparent;
            this.BtnLogin.BorderRadius = 25;
            this.BtnLogin.CheckedState.Parent = this.BtnLogin;
            this.BtnLogin.CustomImages.Parent = this.BtnLogin;
            this.BtnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtnLogin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogin.ForeColor = System.Drawing.Color.Black;
            this.BtnLogin.HoverState.Parent = this.BtnLogin;
            this.BtnLogin.Location = new System.Drawing.Point(256, 343);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.ShadowDecoration.Parent = this.BtnLogin;
            this.BtnLogin.Size = new System.Drawing.Size(115, 52);
            this.BtnLogin.TabIndex = 2;
            this.BtnLogin.Text = "Giris Yap";
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtnExit.HoverState.Parent = this.BtnExit;
            this.BtnExit.IconColor = System.Drawing.Color.Black;
            this.BtnExit.Location = new System.Drawing.Point(1527, 23);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.ShadowDecoration.Parent = this.BtnExit;
            this.BtnExit.Size = new System.Drawing.Size(45, 29);
            this.BtnExit.TabIndex = 7;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Image = global::POS.Properties.Resources.icons8_left_arrow_100;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.Location = new System.Drawing.Point(25, 33);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(43, 40);
            this.guna2Button1.TabIndex = 15;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(142, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 39);
            this.label3.TabIndex = 16;
            this.label3.Text = "Yönetici Girişi";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BackgroundImage = global::POS.Properties.Resources.aesthetic_brown_lines_background_scaled3;
            this.guna2Panel1.BorderRadius = 50;
            this.guna2Panel1.Controls.Add(this.TxtUser);
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.TxtPass);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.BtnLogin);
            this.guna2Panel1.Location = new System.Drawing.Point(736, 353);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(470, 502);
            this.guna2Panel1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AcceptButton = this.BtnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::POS.Properties.Resources.pexels_bluerhinomedia_2788792__1_;
            this.ClientSize = new System.Drawing.Size(1584, 879);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.BtnExit);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "bb";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox TxtUser;
        private Guna.UI2.WinForms.Guna2TextBox TxtPass;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TileButton BtnLogin;
        private Guna.UI2.WinForms.Guna2ControlBox BtnExit;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}

