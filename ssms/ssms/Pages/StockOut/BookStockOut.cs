
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
    public partial class BookStockOut : UserControl
    {
         
        List<DataClasses.ItemMain> imList = new List<ItemMain>();       
        List<LTS.Item> item = new List<LTS.Item>();        
        ItemMain current = new ItemMain();        
         Timer ScanTimer = new Timer();
        System.Timers.Timer timer;
        SettingsMain sm = new SettingsMain();
        int time = 0;
        List<LTS.Store> st = new List<LTS.Store>();
        List<ImpinjRevolution> impinjrev = new List<ImpinjRevolution>();
        string epc = "";
        
        
        
        public BookStockOut()
        {
            InitializeComponent();
        }

        //Tiaan
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool ok = true;
                labelError1.Visible = false;
                labelError2.Visible = false;
                labelError3.Visible = false;
                //change item status to false
                //make bookOut record
                if (textBox1.Text == "")
                {
                    labelError1.Text = "Please enter Booking Out Reason!";
                    labelError1.Visible = true;
                    ok = false;
                }
                if (textBox2.Text == "")
                {
                    labelError2.Text = "Please enter Project Name!";
                    labelError2.Visible = true;
                    ok = false;
                }
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    labelError3.Text = "Please select a row from the list!";
                    labelError3.Visible = true;
                    ok = false;
                }
                else if (ok)
                {

                    LTS.BookOut checkOut = new LTS.BookOut();

                    LTS.Item p = new LTS.Item();
                    p = DAT.DataAccess.GetItem().Where(y => y.ItemID == current.itemID).FirstOrDefault();

                    if (p != null)
                    {
                        checkOut.Reason = textBox1.Text;
                        checkOut.Project = textBox2.Text;
                        checkOut.Date = DateTime.Today;
                        checkOut.UserID = ((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserID;
                        checkOut.ItemID = p.ItemID;

                        int check = DAT.DataAccess.AddBookOut(checkOut);
                        if (check != -1)
                        {
                            p.ItemStatus = false;

                            bool itemUpdate = DAT.DataAccess.UpdateItem(p);
                            if (itemUpdate)
                            {
                                MessageBox.Show("The product was successfully booked out!");
                                ((Main)this.Parent.Parent).ChangeView<Pages.StockOut.StockOut>();
                            }
                            else
                            {
                                bool remove = DAT.DataAccess.RemoveBookOut(check);
                                MessageBox.Show("Sorry something went wrong, the product was not booked out!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sorry something went wrong, the product was not booked out!");
                            ((Main)this.Parent.Parent).ChangeView<BookStockOut>();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           
        }

        
        //Tiaan
        private void BookStockOut_Load(object sender, EventArgs e)
        {
            try
            {
                imList = new List<ItemMain>();

                item = DAT.DataAccess.GetItem().Where(u => u.ItemStatus == true).ToList();
                if (item != null)
                {
                    for (int x = 0; x < item.Count; x++)
                    {
                        ItemMain im = new ItemMain();
                        //assign the item info to the ItemMain object
                        im.itemID = item[x].ItemID;
                        im.EPC = item[x].TagEPC;
                        im.ItemStatus = item[x].ItemStatus;
                        im.ProductID = item[x].ProductID;
                        im.StoreID = item[x].StoreID;

                        //get the specific product and assign the info to the ItemMain object
                        LTS.Product p = new LTS.Product();

                        p = DAT.DataAccess.GetProduct().Where(h => h.ProductID == im.ProductID).FirstOrDefault();

                        im.ProductName = p.ProductName;
                        im.ProductDescription = p.ProductDescription;
                        im.BrandID = p.BrandID;
                        im.CategoryID = p.CategoryID;

                        im.BarcodeID = p.BarcodeID;


                        //get the specific store and assign the info to the ItemMain object
                        LTS.Store s = new LTS.Store();
                        s = DAT.DataAccess.GetStore().Where(j => j.StoreID == im.StoreID).FirstOrDefault();
                        im.StoreName = s.StoreName;
                        im.StoreLocation = s.StoreLocation;

                        //get the specific brand and assign the info to the ItemMain object
                        LTS.Brand b = new LTS.Brand();
                        b = DAT.DataAccess.GetBrand().Where(y => y.BrandID == im.BrandID).FirstOrDefault();
                        im.BrandName = b.BrandName;
                        im.BrandDescription = b.BrandDescription;


                        //get the sepcific category and assign the info to the ItemMain object
                        LTS.Category c = new LTS.Category();
                        c = DAT.DataAccess.GetCategory().Where(z => z.CategoryID == im.CategoryID).FirstOrDefault();
                        im.CategoryName = c.CategoryName;
                        im.CategoryDescription = c.CategoryDescription;

                        //get the sepcific category and assign the info to the ItemMain object
                        LTS.Barcode ba = new LTS.Barcode();
                        ba = DAT.DataAccess.GetBarcode().Where(a => a.BarcodeID == im.BarcodeID).FirstOrDefault();
                        im.BarcodeNumber = ba.BarcodeNumber;

                        imList.Add(im);
                        dataGridView1.Rows.Add(im.itemID, im.EPC, im.ProductName, im.ProductDescription, im.BarcodeNumber, im.BrandName, im.CategoryName
                            , im.ItemStatus, im.StoreName);
                    }
                }


                st = new List<LTS.Store>();
                st = DAT.DataAccess.GetStore().ToList();
                List<string> S = new List<string>();

                for (int x = 0; x < st.Count; x++)
                {
                    S.Add(st[x].StoreName);
                }
                comboBoxStore.DataSource = S;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           
        } 
         
        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.StockOut.StockOut>();
        }

        //Tiaan
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count >= 1)
                {
                    using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                    {
                        ItemMain itemi = new ItemMain();
                        itemi = imList[this.dataGridView1.SelectedRows[0].Index];

                        current = itemi;
                        storeName.Text = itemi.StoreName;
                        StoreLoc.Text = itemi.StoreLocation;
                        barcode.Text = itemi.BarcodeNumber;
                        productName.Text = itemi.ProductName;
                        ProductDesc.Text = itemi.ProductDescription;
                        ProductBrand.Text = itemi.BrandName;
                        ProductCat.Text = itemi.ProductDescription;
                        EPC.Text = itemi.EPC;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
           
        }
   
        //Margo
        bool connect(LTS.Settings se)
        {
            try
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
            
            return true;

        }
        
        //Margo
        void ir_TagRead(TagInfo tag, EventArgs e)
        {
            if (tag != null && epc=="")
            {
                string Tag = tag.TagNo;
                epc = Tag;


            }
        }

        //Margo
        public void EnableOrDisable(bool what)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
        }

        //Margo
        private void button2_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           
            
        }

        //Margo
        void Stop()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           
        }

        //Margo
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            

        }

        //Margo
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                lblerrorEPC.Visible = false;
                if (txtEPC.Text != "")
                {
                    ItemMain boo = new ItemMain();
                    boo = imList.Where(u => u.EPC == txtEPC.Text).FirstOrDefault();
                    if (boo != null)
                    {
                        int index = imList.IndexOf(boo);
                        if (dataGridView1.SelectedRows.Count != 0)
                        {
                            dataGridView1.ClearSelection();
                        }
                        dataGridView1.Rows[index].Selected = true;
                    }
                    else
                    {
                        lblerrorEPC.Visible = true;
                    }
                }
                else
                {
                    lblerrorEPC.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           
        }

        
    }
}
