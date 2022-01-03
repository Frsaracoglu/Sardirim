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
    public partial class frmEnter : Form
    {
        public frmEnter()
        {
            InitializeComponent();
        }

        General gnl = new General();

        private void frmEnter_Load(object sender, EventArgs e)
        {
            Employees em = new Employees();
            em.EmployeesGetbyInformation(cbUser);
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            Employees em = new Employees();
            bool result = em.EmployeesEntryControl(txtPassword.Text, General._Id);

            if (true)
            {
                EmployeeAction ea = new EmployeeAction();
                ea.EmplooyeesID = General._Id;
                ea.Date = DateTime.Now;
                ea.EmployeesActionSave(ea);

                this.Hide();
                frmInterface Interface = new frmInterface();
                Interface.Show();
            }
            else 
            {
                MessageBox.Show("Şifreniz Yanlış!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employees em = (Employees)cbUser.SelectedItem;
            General._Id = em.Id;
            General._Id = em.TitleId;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinize emin misiniz?","Uyarı!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
