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
            this.Personel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Personel.ForeColor = System.Drawing.Color.Black;
            this.Personel.HoverState.Parent = this.Personel;
            this.Personel.Location = new System.Drawing.Point(33, 88);
            this.Personel.Name = "Personel";
            this.Personel.ShadowDecoration.Parent = this.Personel;
            this.Personel.Size = new System.Drawing.Size(180, 126);
            this.Personel.TabIndex = 1;
            this.Personel.Text = "Personel";
            this.Personel.Click += new System.EventHandler(this.Personel_Click);
            // 
            // RaporlarVıew
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(863, 568);
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
    }
}