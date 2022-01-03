using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sardirimm
{
    public partial class frmMasalar : Form
    {
        public frmMasalar()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmInterface frm = new frmInterface();
            this.Close();
            frm.Show();
        }

        private void btnMasa1_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int boy = btnMasa1.Text.Length;

            General.ButtonValue = btnMasa1.Text.Substring(boy - 6, 6);
            General.ButtonName = btnMasa1.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa2_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int boy = btnMasa2.Text.Length;

            General.ButtonValue = btnMasa2.Text.Substring(boy - 6, 6);
            General.ButtonName = btnMasa2.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa3_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int boy = btnMasa3.Text.Length;

            General.ButtonValue = btnMasa3.Text.Substring(boy - 6, 6);
            General.ButtonName = btnMasa3.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa4_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int boy = btnMasa4.Text.Length;

            General.ButtonValue = btnMasa4.Text.Substring(boy - 6, 6);
            General.ButtonName = btnMasa4.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa5_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int boy = btnMasa5.Text.Length;

            General.ButtonValue = btnMasa5.Text.Substring(boy - 6, 6);
            General.ButtonName = btnMasa5.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa6_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int boy = btnMasa6.Text.Length;

            General.ButtonValue = btnMasa6.Text.Substring(boy - 6, 6);
            General.ButtonName = btnMasa6.Name;
            this.Close();
            frm.ShowDialog();
        }
        General gnl = new General();
        private void frmMasalar_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(gnl.conString);
            SqlCommand command = new SqlCommand("Select STATUS, ID from Tables",connection);
            SqlDataReader dataReader = null;
            if (connection.State==ConnectionState.Closed)
            {
                connection.Open();
            }
            dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                foreach (Control item in this.Controls)
                {
                    if (item is Button)
                    {
                        if (item.Name=="btnMasa"+dataReader["ID"].ToString() && dataReader["STATUS"].ToString()=="1")
                        {
                            item.BackgroundImage=(System.Drawing.Image)(Properties.Resources.boş);   //buraya boş masanın arkaplan resmi gelecek
                        }
                        else if (item.Name=="btnMasa"+dataReader["ID"].ToString() && dataReader["STATUS"].ToString()=="2")
                        {
                            Tables tb = new Tables();
                            DateTime dt1 = Convert.ToDateTime(tb.Summary(2,dataReader["ID"].ToString()));
                            DateTime dt2 = DateTime.Now;

                            string st1 = Convert.ToDateTime(tb.Summary(2,dataReader["ID"].ToString())).ToShortTimeString();
                            string st2 = DateTime.Now.ToShortTimeString();

                            DateTime t1 = dt1.AddMinutes(DateTime.Parse(st1).TimeOfDay.TotalMinutes);
                            DateTime t2 = dt2.AddMinutes(DateTime.Parse(st2).TimeOfDay.TotalMinutes);

                            var minus = t2 - t1;

                            item.Text = string.Format("{0}{1}{2}",
                                minus.Days > 0 ? string.Format("{0} Gün", minus.Days) : "",
                                minus.Hours > 0 ? string.Format("{0} Saat", minus.Hours) : "",
                                minus.Minutes > 0 ? string.Format("{0} Dakika", minus.Minutes) : "").Trim() + "\n\n\nMasa" + dataReader["ID"].ToString();

                        }
                        else if (item.Name=="btnmasa" + dataReader["ID"].ToString() && dataReader["STATUS"].ToString()=="3")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.rezerve); //rezervasyonlu masa resmi gelecek
                        }
                    }
                }
            }
        }
    }
}
