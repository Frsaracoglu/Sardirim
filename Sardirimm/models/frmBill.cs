using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sardirimm
{
    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmInterface frm = new frmInterface();
            this.Close();
            frm.Show();
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz?", "Uyarı !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        Siparis cs = new Siparis();
        private void frmBill_Load(object sender, EventArgs e)
        {
            gbIndirim.Visible = false;
            if (General._ServisTypeNo == 1)
            {
                lblAdisyonId.Text = General._AdisyonId;
                txtIndirimTutari.TextChanged += new EventHandler(txtIndirimTutari_TextChanged);
                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));
                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                    }
                    lblToplamTutar.Text = string.Format("0:0.000", toplam);
                    lblOdenecek.Text = string.Format("0:0.000", toplam);
                    decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
                    lblKdv.Text = string.Format("{0:0.000}", kdv);
                }
                gbIndirim.Visible = true;
                txtIndirimTutari.Clear();
            }
            else if (General._ServisTypeNo == 2)
            {
                lblAdisyonId.Text = General._AdisyonId;
                txtIndirimTutari.TextChanged += new EventHandler(txtIndirimTutari_TextChanged);
                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));



                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                    }
                    lblToplamTutar.Text = string.Format("0:0.000", toplam);
                    lblOdenecek.Text = string.Format("0:0.000", toplam);
                    decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
                    lblKdv.Text = string.Format("{0:0.000}", kdv);
                }
                gbIndirim.Visible = true;
                txtIndirimTutari.Clear();
            }
        }


        private void txtIndirimTutari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtIndirimTutari.Text) < Convert.ToDecimal(lblToplamTutar.Text))
                {
                    try
                    {
                        lblIndirim.Text = string.Format("{0:0.000}", Convert.ToDecimal(txtIndirimTutari.Text));
                    }
                    catch (Exception)
                    {

                        lblIndirim.Text = string.Format("{0:0.000}", 0);
                    }
                }
                else
                {
                    MessageBox.Show("İndirim Tutarı Toplam Tutardan Fazla Olamaz!");
                }
            }
            catch (Exception)
            {

                lblIndirim.Text = string.Format("{0:0.000}", 0);
            }
        }

        private void chkIndirim_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndirim.Checked)
            {
                gbIndirim.Visible = true;
                txtIndirimTutari.Clear();
            }
            else
            {
                gbIndirim.Visible = false;
                txtIndirimTutari.Clear();
            }
        }

        private void lblIndirim_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblIndirim.Text) > 0)
            {
                decimal odenecek = 0;
                lblOdenecek.Text = lblToplamTutar.Text;
                odenecek = Convert.ToDecimal(lblOdenecek.Text) - Convert.ToDecimal(lblIndirim.Text);
                lblOdenecek.Text = string.Format("{0:0.000}", odenecek);
            }

            decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
            lblKdv.Text = string.Format("{0:0.000}", kdv);
        }

        Tables tbl = new Tables();
        Rezervasyon rezerve = new Rezervasyon();
        private void btnHesapKapat_Click(object sender, EventArgs e)
        {
            if (General._ServisTypeNo == 1)
            {
                int masaid = tbl.TableGetbyNumber(General.ButtonName);
                int musteriId = 0;

                if (tbl.TableGetbyState(masaid, 4) == true)
                {
                    musteriId = rezerve.getByClientIdFromReservation(masaid);
                }
                else
                {
                    musteriId = 1;
                }
                int odemeTurId = 0;
                if (rbNakit.Checked)
                {
                    odemeTurId = 1;
                }
                if (rbKrediKarti.Checked)
                {
                    odemeTurId = 2;
                }
                if (rbTicket.Checked)
                {
                    odemeTurId = 3;
                }

                Odeme odeme = new Odeme();
                //CheckID,PaymentTypeID,CustomerID,SubTotal,KDV,LastTotal,Discount

                odeme.CheckID = Convert.ToInt32(lblAdisyonId.Text);
                odeme.PaymentTypeID = odemeTurId;
                odeme.CustomerID = musteriId;
                odeme.SubTotal = Convert.ToDecimal(lblOdenecek.Text);
                odeme.KDV = Convert.ToDecimal(lblKdv.Text);
                odeme.LastTotal = Convert.ToDecimal(lblToplamTutar.Text);
                odeme.Discount = Convert.ToDecimal(lblIndirim.Text);

                bool result = odeme.billClose(odeme);
                if (result)
                {
                    MessageBox.Show("Hesap Kapatılmıştır");
                    tbl.setChangeTableState(Convert.ToString(masaid), 1);

                    Rezervasyon rez = new Rezervasyon();
                    rez.reservationClose(Convert.ToInt32(lblAdisyonId.Text));

                    Check hesap = new Check();
                    hesap.CheckClose(Convert.ToInt32(lblAdisyonId.Text), 0);

                    this.Close();
                    frmMasalar frm = new frmMasalar();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Hesap Kapatılırken bir hata oluştu!");
                }

            }
        }

        private void btnOzet_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        Font Baslik = new Font("Verdana", 15, FontStyle.Bold);
        Font altBaslik = new Font("Verdana", 12, FontStyle.Regular);
        Font icerik = new Font("Verdana", 10);
        SolidBrush sb = new SolidBrush(Color.Black);

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat st = new StringFormat();
            st.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("Sardırım Restaurant", Baslik, sb, 350, 100, st);
            e.Graphics.DrawString("-------------------", altBaslik, sb, 350, 120, st);
            e.Graphics.DrawString("Ürün Adı                     Adet            Fiyat", altBaslik, sb, 150, 250, st);
            e.Graphics.DrawString("-------------------------------------------------------------", altBaslik, sb, 150, 280, st);
            for (int i = 0; i < lvUrunler.Items.Count; i++)
            {
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[0].Text, icerik, sb, 150, 300 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[1].Text, icerik, sb, 350, 300 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[3].Text, icerik, sb, 420, 300 + i * 30, st);
            }
            e.Graphics.DrawString("----------------------------------------------------------", altBaslik, sb, 150, 300 + 30 * lvUrunler.Items.Count, st);
            e.Graphics.DrawString("İndirim Tutarı     :----------" + lblIndirim.Text + "TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 1), st);
            e.Graphics.DrawString("KDV Tutarı         :----------" + lblKdv.Text + "TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 2), st);
            e.Graphics.DrawString("Toplam Tutarı      :----------" + lblToplamTutar.Text + "TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 3), st);
            e.Graphics.DrawString("Ödediğiniz Tutar   :----------" + lblOdenecek.Text + "TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 4), st);


        }
    }
}
