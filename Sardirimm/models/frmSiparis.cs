using System;
using System.Collections;
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
    public partial class frmSiparis : Form
    {
        public frmSiparis()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmMasalar frm = new frmMasalar();
            this.Close();
            frm.Show();
        }

        void islem(Object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btn1":
                    txtAdet.Text += (1).ToString();
                    break;
                case "btn2":
                    txtAdet.Text += (2).ToString();
                    break;
                case "btn3":
                    txtAdet.Text += (3).ToString();
                    break;
                case "btn4":
                    txtAdet.Text += (4).ToString();
                    break;
                case "btn5":
                    txtAdet.Text += (5).ToString();
                    break;
                case "btn6":
                    txtAdet.Text += (6).ToString();
                    break;
                case "btn7":
                    txtAdet.Text += (7).ToString();
                    break;
                case "btn8":
                    txtAdet.Text += (8).ToString();
                    break;
                case "btn9":
                    txtAdet.Text += (9).ToString();
                    break;
                case "btn0":
                    txtAdet.Text += (0).ToString();
                    break;
            }
        }

        int tableId = 0; int AdditionID = 0;
        private void frmSiparis_Load(object sender, EventArgs e)
        {
            lblMasaNo.Text = General.ButtonValue;

            Tables tbl = new Tables();
            tableId = tbl.TableGetbyNumber(General.ButtonName);
            if (tbl.TableGetbyState(tableId, 2) == true || tbl.TableGetbyState(tableId, 4) == true)
            {
                Check hesap = new Check();
                AdditionID = hesap.GetByAddition(tableId);
                Siparis orders = new Siparis();
                orders.getByOrder(lvSiparis, AdditionID);
            }

            btn1.Click += new EventHandler(islem);
            btn2.Click += new EventHandler(islem);
            btn3.Click += new EventHandler(islem);
            btn4.Click += new EventHandler(islem);
            btn5.Click += new EventHandler(islem);
            btn6.Click += new EventHandler(islem);
            btn7.Click += new EventHandler(islem);
            btn8.Click += new EventHandler(islem);
            btn9.Click += new EventHandler(islem);
            btn0.Click += new EventHandler(islem);
        }

        ProductVariety pv = new ProductVariety();
        private void btnAnaYemek1_Click(object sender, EventArgs e)
        {
            pv.getByProductTypes(lvMenu, btnAnaYemek1);
        }

        private void btnSalata2_Click(object sender, EventArgs e)
        {
            pv.getByProductTypes(lvMenu, btnSalata2);
        }

        private void btnBaslangıc3_Click(object sender, EventArgs e)
        {
            pv.getByProductTypes(lvMenu, btnBaslangıc3);
        }

        private void btnAraSıcak4_Click(object sender, EventArgs e)
        {
            pv.getByProductTypes(lvMenu, btnAraSıcak4);
        }

        private void btnTatli5_Click(object sender, EventArgs e)
        {
            pv.getByProductTypes(lvMenu, btnTatli5);
        }

        private void btnIcecekler6_Click(object sender, EventArgs e)
        {
            pv.getByProductTypes(lvMenu, btnIcecekler6);
        }

        int sayac = 0; int sayac2 = 0;
        private void lvMenu_DoubleClick(object sender, EventArgs e)
        {
            if (txtAdet.Text == "")
            {
                txtAdet.Text = "1";
            }

            if (lvMenu.Items.Count > 0)
            {
                sayac = lvSiparis.Items.Count;
                lvSiparis.Items.Add(lvMenu.SelectedItems[0].Text);
                lvSiparis.Items[sayac].SubItems.Add(txtAdet.Text);
                lvSiparis.Items[sayac].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvSiparis.Items[sayac].SubItems.Add((Convert.ToDecimal(lvMenu.SelectedItems[0].SubItems[1].Text) * Convert.ToDecimal(txtAdet.Text)).ToString());
                lvSiparis.Items[sayac].SubItems.Add("0");

                sayac2 = lvYenieklenenler.Items.Count;
                lvSiparis.Items[sayac].SubItems.Add(sayac2.ToString());

                lvYenieklenenler.Items.Add(tableId.ToString());
                lvYenieklenenler.Items[sayac2].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvYenieklenenler.Items[sayac].SubItems.Add(txtAdet.Text);
                lvYenieklenenler.Items[sayac].SubItems.Add(tableId.ToString());
                lvYenieklenenler.Items[sayac2].SubItems.Add(sayac2.ToString());

                sayac2++;
                txtAdet.Text = "";

            }
        }

        ArrayList silinen = new ArrayList();
        private void btnSiparis_Click(object sender, EventArgs e)
        {
            Tables tbl = new Tables();
            frmMasalar frmtbl = new frmMasalar();
            Check newAddition = new Check();
            Siparis saveOrder = new Siparis();
            bool sonuc = false;
            if (tbl.TableGetbyState(tableId, 1) == true)
            {
                newAddition.ServiceTypeNo = 1;
                
                newAddition.EmployeeID = 1;
                newAddition.TableID = tableId;
                newAddition.Date = Convert.ToInt32(DateTime.Now);
                sonuc = newAddition.setByAdditionNew(newAddition);
                tbl.setChangeTableState(General.ButtonName, 2);

                if (lvSiparis.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparis.Items.Count; i++)
                    {
                        saveOrder.TableID = tableId;
                        saveOrder.ProductID = Convert.ToInt32(lvSiparis.Items[i].SubItems[2].Text);
                        saveOrder.CheckID = newAddition.GetByAddition(tableId);
                        saveOrder.Amount = Convert.ToInt32(lvSiparis.Items[i].SubItems[1].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }
                    this.Close();
                    frmtbl.Show();
                }
            }
            else if (tbl.TableGetbyState(tableId, 2) == true || tbl.TableGetbyState(tableId, 4) == true)
            {
                
                if (lvYenieklenenler.Items.Count > 0)
                {
                    for (int i = 0; i < lvYenieklenenler.Items.Count; i++)
                    {
                        saveOrder.TableID = tableId;
                        saveOrder.ProductID = Convert.ToInt32(lvYenieklenenler.Items[i].SubItems[1].Text);
                        saveOrder.CheckID = newAddition.GetByAddition(tableId);
                        saveOrder.Amount = Convert.ToInt32(lvYenieklenenler.Items[i].SubItems[2].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }
                    
                }
                if (silinen.Count > 0)
                {
                    foreach (string item in silinen)
                    {
                        saveOrder.setDeleteOrder(Convert.ToInt32(item));
                    }
                }

                this.Close();
                frmtbl.Show();
            }
            else if (tbl.TableGetbyState(tableId, 3) == true)
            {
                newAddition.ServiceTypeNo = 1;
                
                newAddition.EmployeeID = 1;
                newAddition.TableID = tableId;
                newAddition.Date = Convert.ToInt32(DateTime.Now);
                sonuc = newAddition.setByAdditionNew(newAddition);
                tbl.setChangeTableState(General.ButtonName, 4);

                if (lvSiparis.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparis.Items.Count; i++)
                    {
                        saveOrder.TableID = tableId;
                        saveOrder.ProductID = Convert.ToInt32(lvSiparis.Items[i].SubItems[2].Text);
                        saveOrder.CheckID = newAddition.GetByAddition(tableId);
                        saveOrder.Amount = Convert.ToInt32(lvSiparis.Items[i].SubItems[1].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }
                    this.Close();
                    frmtbl.Show();
                }
            }

            
        }
        private void lvSiparis_DoubleClick(object sender, EventArgs e)
        {
            if (lvSiparis.Items.Count > 0)
            {


                if (lvSiparis.SelectedItems[0].SubItems[4].Text != "0")
                {
                    Siparis saveOrder = new Siparis();
                    saveOrder.setDeleteOrder(Convert.ToInt32(lvSiparis.SelectedItems[0].SubItems[4].Text));
                }
                else
                {
                    for (int i = 0; i < lvYenieklenenler.Items.Count; i++)
                    {
                        if (lvYenieklenenler.Items[i].SubItems[4].Text == lvSiparis.SelectedItems[0].SubItems[5].Text)
                        {
                            lvYenieklenenler.Items.RemoveAt(i);
                        }
                    }
                }

                lvSiparis.Items.RemoveAt(lvSiparis.SelectedItems[0].Index);
            }
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            General._ServisTypeNo = 1;
            General._AdisyonId = AdditionID.ToString();
            frmBill frm = new frmBill();
            this.Close();
            frm.Show();
        }
    }
}
