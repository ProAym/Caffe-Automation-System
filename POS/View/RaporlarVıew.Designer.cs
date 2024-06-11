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
            this.KatigoriSatis = new Guna.UI2.WinForms.Guna2Button();
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
            // KatigoriSatis
            // 
            this.KatigoriSatis.CheckedState.Parent = this.KatigoriSatis;
            this.KatigoriSatis.CustomImages.Parent = this.KatigoriSatis;
            this.KatigoriSatis.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(200)))), ((int)(((byte)(189)))));
            this.KatigoriSatis.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KatigoriSatis.ForeColor = System.Drawing.Color.Black;
            this.KatigoriSatis.HoverState.Parent = this.KatigoriSatis;
            this.KatigoriSatis.Location = new System.Drawing.Point(23, 85);
            this.KatigoriSatis.Name = "KatigoriSatis";
            this.KatigoriSatis.ShadowDecoration.Parent = this.KatigoriSatis;
            this.KatigoriSatis.Size = new System.Drawing.Size(180, 126);
            this.KatigoriSatis.TabIndex = 2;
            this.KatigoriSatis.Text = "Kategoriye Göre Satışlar";
            this.KatigoriSatis.Click += new System.EventHandler(this.KatigoriSatis_Click);
            // 
            // RaporlarVıew
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(863, 568);
            this.Controls.Add(this.KatigoriSatis);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RaporlarVıew";
            this.Text = "RaporlarVıew";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button KatigoriSatis;
    }
}