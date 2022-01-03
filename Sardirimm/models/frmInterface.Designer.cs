namespace Sardirimm
{
    partial class frmInterface
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
            this.btnMutfak = new System.Windows.Forms.Button();
            this.btnMasalar = new System.Windows.Forms.Button();
            this.btnSiparisler = new System.Windows.Forms.Button();
            this.btnRezervasyon = new System.Windows.Forms.Button();
            this.btnKasa = new System.Windows.Forms.Button();
            this.btnMuhasebe = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMusteriler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMutfak
            // 
            this.btnMutfak.Location = new System.Drawing.Point(173, 74);
            this.btnMutfak.Name = "btnMutfak";
            this.btnMutfak.Size = new System.Drawing.Size(141, 56);
            this.btnMutfak.TabIndex = 0;
            this.btnMutfak.Text = "MUTFAK";
            this.btnMutfak.UseVisualStyleBackColor = true;
            this.btnMutfak.Click += new System.EventHandler(this.btnMutfak_Click);
            // 
            // btnMasalar
            // 
            this.btnMasalar.Location = new System.Drawing.Point(173, 12);
            this.btnMasalar.Name = "btnMasalar";
            this.btnMasalar.Size = new System.Drawing.Size(141, 56);
            this.btnMasalar.TabIndex = 0;
            this.btnMasalar.Text = "MASALAR";
            this.btnMasalar.UseVisualStyleBackColor = true;
            this.btnMasalar.Click += new System.EventHandler(this.btnMasalar_Click);
            // 
            // btnSiparisler
            // 
            this.btnSiparisler.Location = new System.Drawing.Point(173, 136);
            this.btnSiparisler.Name = "btnSiparisler";
            this.btnSiparisler.Size = new System.Drawing.Size(141, 56);
            this.btnSiparisler.TabIndex = 0;
            this.btnSiparisler.Text = "SİPARİŞLER";
            this.btnSiparisler.UseVisualStyleBackColor = true;
            // 
            // btnRezervasyon
            // 
            this.btnRezervasyon.Location = new System.Drawing.Point(173, 198);
            this.btnRezervasyon.Name = "btnRezervasyon";
            this.btnRezervasyon.Size = new System.Drawing.Size(141, 56);
            this.btnRezervasyon.TabIndex = 0;
            this.btnRezervasyon.Text = "REZERVASYON";
            this.btnRezervasyon.UseVisualStyleBackColor = true;
            this.btnRezervasyon.Click += new System.EventHandler(this.btnRezervasyon_Click);
            // 
            // btnKasa
            // 
            this.btnKasa.Location = new System.Drawing.Point(173, 260);
            this.btnKasa.Name = "btnKasa";
            this.btnKasa.Size = new System.Drawing.Size(141, 56);
            this.btnKasa.TabIndex = 0;
            this.btnKasa.Text = "KASA";
            this.btnKasa.UseVisualStyleBackColor = true;
            this.btnKasa.Click += new System.EventHandler(this.btnKasa_Click);
            // 
            // btnMuhasebe
            // 
            this.btnMuhasebe.Location = new System.Drawing.Point(173, 322);
            this.btnMuhasebe.Name = "btnMuhasebe";
            this.btnMuhasebe.Size = new System.Drawing.Size(141, 56);
            this.btnMuhasebe.TabIndex = 0;
            this.btnMuhasebe.Text = "MUHASEBE";
            this.btnMuhasebe.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(415, 417);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Çıkış";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMusteriler
            // 
            this.btnMusteriler.Location = new System.Drawing.Point(173, 384);
            this.btnMusteriler.Name = "btnMusteriler";
            this.btnMusteriler.Size = new System.Drawing.Size(141, 56);
            this.btnMusteriler.TabIndex = 2;
            this.btnMusteriler.Text = "MÜŞTERİLER";
            this.btnMusteriler.UseVisualStyleBackColor = true;
            this.btnMusteriler.Click += new System.EventHandler(this.btnMusteriler_Click);
            // 
            // frmInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 446);
            this.Controls.Add(this.btnMusteriler);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMuhasebe);
            this.Controls.Add(this.btnKasa);
            this.Controls.Add(this.btnRezervasyon);
            this.Controls.Add(this.btnSiparisler);
            this.Controls.Add(this.btnMasalar);
            this.Controls.Add(this.btnMutfak);
            this.Name = "frmInterface";
            this.Text = "frmInterface";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMutfak;
        private System.Windows.Forms.Button btnMasalar;
        private System.Windows.Forms.Button btnSiparisler;
        private System.Windows.Forms.Button btnRezervasyon;
        private System.Windows.Forms.Button btnKasa;
        private System.Windows.Forms.Button btnMuhasebe;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMusteriler;
    }
}