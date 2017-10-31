
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ssms.DataClasses;

namespace ssms.Pages.StockOut
{
    public partial class StockOutUpdate : UserControl
    {
        Timer ScanTimer = new Timer();
        System.Timers.Timer timer;
        int time = 0;
        SettingsMain sm = new SettingsMain();
        List<ImpinjRevolution> impinjrev = new List<ImpinjRevolution>();
        string epc = "";
        BookOutMain current = new BookOutMain();
        List<BookOutMain> bom = new List<BookOutMain>();
        List<LTS.Store> st = new List<LTS.Store>();

        public StockOutUpdate()
        {
            InitializeComponent();

        }

        //Margo
        private void comboBoxStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<LTS.Product> product = new List<LTS.Product>();
            product = DAT.DataAccess.GetProduct().ToList();
            storeName.Text = comboBoxStore.GetItemText(comboBoxStore.SelectedValue);
        }

        //Margo
        private void btnlogin_Click(object sender, EventArgs e)
        {
            lblReason.Visible = false;
            lblProject.Visible = false;
            bool check = true;
            if(textBox1.Text == "")
            {
                lblReason.Visible = true;
                check = false;
            }

            if (textBox2.Text == "")
            {
                lblProject.Visible = true;
                check = false;
            }

            if (check == true)
            {
                int BookOutID = current.BookOutID;
                LTS.BookOut bo = new LTS.BookOut();
                bo = DAT.DataAccess.GetBookOut().Where(u => u.BookOutID == BookOutID).FirstOrDefault();
                if (bo != null)
                {
                    bo.Reason = textBox1.Text;
                    bo.Project = textBox2.Text;

                    bool update = DAT.DataAccess.UpdateBookOut(bo);
                    if (update)
                    {
                        MessageBox.Show("The book out update was succesful!");
                    }
                    else
                    {
                        MessageBox.Show("The book out update was unsuccesful!");
                    }
                }
                else
                {
                    MessageBox.Show("The book out update was unsuccesful!");
                }
            }
            
        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.StockOut.StockOut>();
        }

        //Margo
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                time = 0;
                lblTimer.Text = time.ToString();
                timer = new System.Timers.Timer();
                timer.Elapsed += timer_Elapsed;
                timer.Interval = 1000;

                EnableOrDisable(false);
                epc = "";
                int iStore = comboBoxStore.SelectedIndex;
                LTS.Store s = st[iStore];

                LTS.Settings set = DAT.DataAccess.GetSettings().Where(y => y.StoreID == s.StoreID && y.SettingsSelect == true).FirstOrDefault();
                if (set != null)
                {
                    connect(set);
                }
                else
                {
                    lblConnect.Text = ("Settings not found!");
                    EnableOrDisable(true);

                }
            }
            catch (Exception exx)
            {
                lblConnect.Text = ("Store not selected!");
                EnableOrDisable(true);
            }
        }

        //Margo
        bool connect(LTS.Settings se)
        {
            lblConnect.Text = "Connecting...";
           

            int index = comboBoxStore.SelectedIndex;
            if (st != null)
            {
                int storeID = st[index].StoreID;

                LTS.Settings set = se;

                sm = null;
                sm = new SettingsMain();
                impinjrev.Clear();
                sm.SettingsID = set.SettingsID;
                sm.SettingsName = set.SettingsName;
                sm.SettingsSelect = set.SettingsSelect;
                sm.StoreID = set.StoreID;

                LTS.Store store = DAT.DataAccess.GetStore().Where(i => i.StoreID == sm.StoreID).FirstOrDefault();
                sm.StoreLocation = store.StoreLocation;
                sm.StoreName = store.StoreName;

                List<LTS.Reader> readers = new List<LTS.Reader>();
                readers = DAT.DataAccess.GetReader().Where(j => j.SettingsID == sm.SettingsID).ToList();
                for (int j = 0; j < readers.Count; j++)
                {
                    ReaderMain rm = new ReaderMain();
                    rm.ReaderID = readers[j].ReaderID;
                    rm.IPaddress = readers[j].IPaddress;
                    rm.NumAntennas = readers[j].NumAntennas;
                    rm.antennas = DAT.DataAccess.GetAntenna().Where(q => q.ReaderID == rm.ReaderID).ToList();

                    sm.Readers.Add(rm);

                }
                bool checks = true;

                for (int x = 0; x < sm.Readers.Count; x++)
                {

                    ImpinjRevolution ir = new ImpinjRevolution();
                    ir.ReaderScanMode = ScanMode.ScanItem;
                    ir.HostName = sm.Readers[x].IPaddress;
                    ir.Antennas = sm.Readers[x].antennas;

                    ir.TagRead += ir_TagRead;
                    ir.Connect();

                    impinjrev.Add(ir);
                    if (!ir.isConnected)
                    {
                        if (checks == true)
                        {
                            checks = false;
                        }

                    }
                }

                if (checks == true)
                {
                    lblConnect.Text = "Connected";
                    timer.Start();
                    impinjrev.ForEach(imp =>
                    {
                        imp.TagRead += ir_TagRead;
                        imp.StartRead();
                    });

                    ((Form1)this.Parent.Parent.Parent.Parent).scan = true;
                    lblConnect.Text = "Reading...";
                    lblTimer.Text = time.ToString();
                   
                }
                else
                {
                    lblConnect.Text = "Not Connected!";
                    timer.Stop();
                    timer.Elapsed -= timer_Elapsed;
                    time = 0;
                    for (int i = 0; i < impinjrev.Count; i++)
                    {
                        impinjrev[i].StopRead();
                        impinjrev[i].Disconnect();

                    }
                    EnableOrDisable(true);
                    ((Form1)this.Parent.Parent.Parent.Parent).scan = false;
                }
            }
            return true;

        }
        
        //Margo
        void ir_TagRead(TagInfo tag, EventArgs e)
        {
            if (tag != null && epc == "")
            {
                string Tag = tag.TagNo;
                epc = Tag;

            }
        }

        void Stop()
        {
            if (impinjrev != null)
            {
                for (int i = 0; i < impinjrev.Count; i++)
                {
                    impinjrev[i].StopRead();
                    impinjrev[i].Disconnect();

                }
                if (lblConnect.InvokeRequired)
                {
                    lblConnect.Invoke(new MethodInvoker(delegate () {
                        lblConnect.Text = "Disconnected!";
                    }));

                }

                ((Form1)this.Parent.Parent.Parent.Parent).scan = false;
                EnableOrDisable(true);
            }
        }

        //Margo
        public void EnableOrDisable(bool what)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (what)
                {
                    
                    button4.Enabled = true;
                    comboBoxStore.Enabled = true;
                    button1.Enabled = true;
                    btnlogin.Enabled = true;
                    time = 0;
                }
                else
                {

                    button4.Enabled = false;
                    comboBoxStore.Enabled = false;
                    button1.Enabled = false;
                    btnlogin.Enabled = false;
                }
            }));

        }

        //Margo
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (time < 60 && epc == "")
            {
                if (time >= 60)
                {
                    timer.Stop();
                    timer.Elapsed -= timer_Elapsed;
                    if (lblTimer.InvokeRequired)
                    {
                        lblTimer.Invoke(new MethodInvoker(delegate () {
                            lblTimer.Text = time.ToString();
                            txtEPC.Text = epc;
                        }));

                    }

                    Stop();
                    time = 0;
                }
                else
                {
                    time++;
                    if (lblTimer.InvokeRequired)
                    {
                        lblTimer.Invoke(new MethodInvoker(delegate () {
                            lblTimer.Text = time.ToString();
                        }));

                    }
                }
               
            }
            else
            {
                timer.Stop();
                timer.Elapsed -= timer_Elapsed;
                if (lblTimer.InvokeRequired)
                {
                    lblTimer.Invoke(new MethodInvoker(delegate () {
                        lblTimer.Text = time.ToString();
                        txtEPC.Text = epc;
                    }));

                }

                Stop();
                time = 0;
            }

        }
               
        //Margo
        private void StockOutUpdate_Load_1(object sender, EventArgs e)
        {
            st = DAT.DataAccess.GetStore().ToList();
            List<string> S = new List<string>();

            for (int x = 0; x < st.Count; x++)
            {
                S.Add(st[x].StoreName);
            }
            comboBoxStore.DataSource = S;

            List<LTS.BookOut> bo = new List<LTS.BookOut>();
            bo = DAT.DataAccess.GetBookOut().ToList();

            for (int i = 0; i < bo.Count; i++)
            {
                BookOutMain b = new BookOutMain();
                b.BookOutID = bo[i].BookOutID;
                b.itemID = bo[i].ItemID;
                b.UserID = bo[i].UserID;
                b.Reason = bo[i].Reason;
                b.Project = bo[i].Project;
                b.Date = bo[i].Date;

                LTS.Item it = new LTS.Item();
                it = DAT.DataAccess.GetItem().Where(u => u.ItemID == b.itemID).FirstOrDefault();
                b.ItemStatus = it.ItemStatus;
                b.EPC = it.TagEPC;
                b.ProductID = it.ProductID;
                b.StoreID = it.StoreID;

                //get the specific product and assign the info to the ItemMain object
                LTS.Product p = new LTS.Product();
                p = DAT.DataAccess.GetProduct().Where(h => h.ProductID == b.ProductID).FirstOrDefault();
                b.ProductName = p.ProductName;
                b.ProductDescription = p.ProductDescription;
                b.BrandID = p.BrandID;
                b.CategoryID = p.CategoryID;
                b.BarcodeID = p.BarcodeID;

                //get the specific store and assign the info to the ItemMain object
                LTS.Store s = new LTS.Store();
                s = DAT.DataAccess.GetStore().Where(j => j.StoreID == b.StoreID).FirstOrDefault();
                b.StoreName = s.StoreName;
                b.StoreLocation = s.StoreLocation;

                //get the specific brand and assign the info to the ItemMain object
                LTS.Brand br = new LTS.Brand();
                br = DAT.DataAccess.GetBrand().Where(y => y.BrandID == b.BrandID).FirstOrDefault();
                b.BrandName = b.BrandName;
                b.BrandDescription = b.BrandDescription;

                //get the sepcific category and assign the info to the ItemMain object
                LTS.Category c = new LTS.Category();
                c = DAT.DataAccess.GetCategory().Where(z => z.CategoryID == b.CategoryID).FirstOrDefault();
                b.CategoryName = c.CategoryName;
                b.CategoryDescription = c.CategoryDescription;

                //get the sepcific category and assign the info to the ItemMain object
                LTS.Barcode ba = new LTS.Barcode();
                ba = DAT.DataAccess.GetBarcode().Where(a => a.BarcodeID == b.BarcodeID).FirstOrDefault();
                b.BarcodeNumber = ba.BarcodeNumber;

                LTS.User us = new LTS.User();
                us = DAT.DataAccess.GetUser().Where(h => h.UserID == b.UserID).FirstOrDefault();
                b.UserIdentityNumber = us.UserIdentityNumber;
                b.UserName = us.UserName;
                b.UserSurname = us.UserSurname;

                bom.Add(b);

                dataGridView1.Rows.Add(b.BookOutID, b.EPC, b.ProductName, b.Reason, b.Project, b.Date, b.UserName, b.UserSurname);

            }
        }

        //Margo
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                {
                    BookOutMain bo = new BookOutMain();
                    bo = bom[this.dataGridView1.SelectedRows[0].Index];
                    current = bo;
                    storeName.Text = bo.StoreName;
                    StoreLoc.Text = bo.StoreLocation;
                    barcode.Text = bo.BarcodeNumber;
                    productName.Text = bo.ProductName;
                    ProductDesc.Text = bo.ProductDescription;
                    ProductBrand.Text = bo.BrandName;
                    ProductCat.Text = bo.CategoryName;
                    lblEPC.Text = bo.EPC;
                    textBox1.Text = bo.Reason;
                    textBox2.Text = bo.Project;

                }
            }
        }

        //Margo
        private void button4_Click(object sender, EventArgs e)
        {
            lblEPCerror.Visible = false;
            if (txtEPC.Text != "")
            {
                BookOutMain boo = new BookOutMain();
                boo = bom.Where(u => u.EPC == txtEPC.Text).FirstOrDefault();
                if (boo != null)
                {
                    int index = bom.IndexOf(boo);
                    if (dataGridView1.SelectedRows.Count != 0)
                    {
                        dataGridView1.ClearSelection();
                    }
                    dataGridView1.Rows[index].Selected = true;
                }
                else
                {
                    lblEPCerror.Visible = true;
                }
            }
            else
            {
                lblEPCerror.Visible = true;
            }
            
        }
    }
}
