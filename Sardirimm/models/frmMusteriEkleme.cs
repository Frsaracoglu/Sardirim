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
    public partial class frmMusteriEkleme : Form
    {
        public frmMusteriEkleme()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Length>6)
            {
                if (txtMusteriAd.Text == "" || txtMusteriSoyad.Text == "")
                {
                    MessageBox.Show("Lütfen müşterinin ad ve soyad alanlarını doldurunuz.!");
                }
                else
                {
                    Musteriler m = new Musteriler();
                    bool sonuc = m.MusteriVarMi(txtTelefon.Text);
                    if (!sonuc)
                    {
                        m.Musteriad = txtMusteriAd.Text;
                        m.Musterisoyad = txtMusteriSoyad.Text;
                        m.Telefon = txtTelefon.Text;
                        m.Email = txtEmail.Text;
                        m.Adres = txtAdres.Text;
                        txtMusteriNo.Text = m.musteriEkle(m).ToString();
                        if (txtMusteriNo.Text !="")
                        {
                            MessageBox.Show("Müşteri Eklendi");
                        }
                        else
                        {
                            MessageBox.Show("Müşteri Eklenemedi!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu isimde kayıt bulunmaktadır!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen en az 7 haneli bir telefon numarası giriniz!");
            }
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            if (General._musteriEkleme==0)
            {
                frmRezervasyon frm = new frmRezervasyon();
                General._musteriEkleme = 1;
                this.Close();
                frm.Show();
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Length > 6)
            {
                if (txtMusteriAd.Text == "" || txtMusteriSoyad.Text == "")
                {
                    MessageBox.Show("Lütfen müşterinin ad ve soyad alanlarını doldurunuz.!");
                }
                else
                {
                    Musteriler m = new Musteriler();

                    m.Musteriad = txtMusteriAd.Text;
                    m.Musterisoyad = txtMusteriSoyad.Text;
                    m.Telefon = txtTelefon.Text;
                    m.Email = txtEmail.Text;
                    m.Adres = txtAdres.Text;
                    m.Musteriid = Convert.ToInt32(txtMusteriNo.Text);
                    bool sonuc=m.musteriBilgileriGuncelle(m);
                 
                    if (!sonuc)
                    {
                        
                        if (txtMusteriNo.Text != "")
                        {
                            MessageBox.Show("Müşteri Güncellendi");
                        }
                        else
                        {
                            MessageBox.Show("Müşteri Güncellenmedi!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu isimde kayıt bulunmaktadır!");
                    }
                }
            }
        }
    }
}
