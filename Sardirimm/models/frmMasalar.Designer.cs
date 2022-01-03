namespace Sardirimm
{
    partial class frmMasalar
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
            this.btnMasa1 = new System.Windows.Forms.Button();
            this.btnMasa2 = new System.Windows.Forms.Button();
            this.btnMasa3 = new System.Windows.Forms.Button();
            this.btnMasa4 = new System.Windows.Forms.Button();
            this.btnMasa5 = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMasa6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMasa1
            // 
            this.btnMasa1.Location = new System.Drawing.Point(45, 23);
            this.btnMasa1.Name = "btnMasa1";
            this.btnMasa1.Size = new System.Drawing.Size(107, 44);
            this.btnMasa1.TabIndex = 0;
            this.btnMasa1.Text = "Masa 1";
            this.btnMasa1.UseVisualStyleBackColor = true;
            this.btnMasa1.Click += new System.EventHandler(this.btnMasa1_Click);
            // 
            // btnMasa2
            // 
            this.btnMasa2.Location = new System.Drawing.Point(183, 23);
            this.btnMasa2.Name = "btnMasa2";
            this.btnMasa2.Size = new System.Drawing.Size(107, 44);
            this.btnMasa2.TabIndex = 0;
            this.btnMasa2.Text = "Masa2 ";
            this.btnMasa2.UseVisualStyleBackColor = true;
            this.btnMasa2.Click += new System.EventHandler(this.btnMasa2_Click);
            // 
            // btnMasa3
            // 
            this.btnMasa3.Location = new System.Drawing.Point(324, 23);
            this.btnMasa3.Name = "btnMasa3";
            this.btnMasa3.Size = new System.Drawing.Size(107, 44);
            this.btnMasa3.TabIndex = 0;
            this.btnMasa3.Text = "Masa 3";
            this.btnMasa3.UseVisualStyleBackColor = true;
            this.btnMasa3.Click += new System.EventHandler(this.btnMasa3_Click);
            // 
            // btnMasa4
            // 
            this.btnMasa4.Location = new System.Drawing.Point(45, 73);
            this.btnMasa4.Name = "btnMasa4";
            this.btnMasa4.Size = new System.Drawing.Size(107, 44);
            this.btnMasa4.TabIndex = 0;
            this.btnMasa4.Text = "Masa 4";
            this.btnMasa4.UseVisualStyleBackColor = true;
            this.btnMasa4.Click += new System.EventHandler(this.btnMasa4_Click);
            // 
            // btnMasa5
            // 
            this.btnMasa5.Location = new System.Drawing.Point(183, 73);
            this.btnMasa5.Name = "btnMasa5";
            this.btnMasa5.Size = new System.Drawing.Size(107, 44);
            this.btnMasa5.TabIndex = 0;
            this.btnMasa5.Text = "Masa 5";
            this.btnMasa5.UseVisualStyleBackColor = true;
            this.btnMasa5.Click += new System.EventHandler(this.btnMasa5_Click);
            // 
            // btnGeri
            // 
            this.btnGeri.Location = new System.Drawing.Point(23, 213);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(75, 23);
            this.btnGeri.TabIndex = 1;
            this.btnGeri.Text = "Geri Dön";
            this.btnGeri.UseVisualStyleBackColor = true;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(396, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Boş";
            // 
            // btnMasa6
            // 
            this.btnMasa6.Location = new System.Drawing.Point(324, 73);
            this.btnMasa6.Name = "btnMasa6";
            this.btnMasa6.Size = new System.Drawing.Size(107, 44);
            this.btnMasa6.TabIndex = 0;
            this.btnMasa6.Text = "Masa 6";
            this.btnMasa6.UseVisualStyleBackColor = true;
            this.btnMasa6.Click += new System.EventHandler(this.btnMasa6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(396, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dolu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(396, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rezerve";
            // 
            // frmMasalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 248);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.btnMasa6);
            this.Controls.Add(this.btnMasa5);
            this.Controls.Add(this.btnMasa4);
            this.Controls.Add(this.btnMasa3);
            this.Controls.Add(this.btnMasa2);
            this.Controls.Add(this.btnMasa1);
            this.Name = "frmMasalar";
            this.Text = "frmMasalar";
            this.Load += new System.EventHandler(this.frmMasalar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMasa1;
        private System.Windows.Forms.Button btnMasa2;
        private System.Windows.Forms.Button btnMasa3;
        private System.Windows.Forms.Button btnMasa4;
        private System.Windows.Forms.Button btnMasa5;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMasa6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}