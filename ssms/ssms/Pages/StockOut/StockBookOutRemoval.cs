
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
    public partial class StockBookOutRemoval : UserControl
    {
        Timer ScanTimer = new Timer();
        int time = 0;
        System.Timers.Timer timer;
        SettingsMain sm = new SettingsMain();
        List<ImpinjRevolution> impinjrev = new List<ImpinjRevolution>();
        string epc = "";
        bool wait = false;
        bool foundIt = false;
        List<LTS.Store> st = new List<LTS.Store>();

        public StockBookOutRemoval()
        {
            InitializeComponent();
           
        }

        private void label5_Click(object sender, EventArgs e)
        {


        }

        private void StockBookOutRemoval_Load(object sender, EventArgs e)
        {
            List<LTS.Store> store = new List<LTS.Store>();
            List<LTS.Barcode> barcode = new List<LTS.Barcode>();
            List<LTS.Item> item = new List<LTS.Item>();
            List<string> s = new List<string>();

            item = DAT.DataAccess.GetItem().ToList();
            barcode = DAT.DataAccess.GetBarcode().ToList();
            store = DAT.DataAccess.GetStore().ToList();

            for (int i = 0; i < s.Count; i++)
            {
                s.Add(store[i].StoreName + barcode[i].BarcodeNumber + item[i].TagEPC);
            }
            comboBoxStore.DataSource = storeName;
            comboBox1.DataSource = barcode;
            comboBox2.DataSource = item;

            st = new List<LTS.Store>();
            st = DAT.DataAccess.GetStore().ToList();

            
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

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
                foundIt = false;
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
                    // while (wait!=true)
                    // {
                    //    if (epc != "")
                    //    {
                    //       int find = comboBox2.FindStringExact(epc);
                    //       if (find != -1)
                    //      {
                    //          comboBox2.SelectedIndex = find;
                    //          wait = true;
                    //          break;
                    //     }
                    //  }

                    // }




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
        //read tags
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
                    
                   
                    comboBox2.Enabled = true;
                    comboBoxStore.Enabled = true;
                    button1.Enabled = true;
                    btnlogin.Enabled = true;
                    time = 0;
                }
                else
                {
                    
                    
                    comboBox2.Enabled = false;
                    comboBoxStore.Enabled = false;
                    button1.Enabled = false;
                    btnlogin.Enabled = false;
                }
            }));
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (time < 60 && epc == "")
            {
                time++;
                if (lblTimer.InvokeRequired)
                {
                    lblTimer.Invoke(new MethodInvoker(delegate () {
                        lblTimer.Text = time.ToString();
                    }));

                }


            }
            else
            {
                int find = comboBox2.FindStringExact(epc);
                if (find != -1)
                {
                    timer.Stop();
                    timer.Elapsed -= timer_Elapsed;
                    foundIt = true;

                    if (comboBox2.InvokeRequired)
                    {
                        comboBox2.Invoke(new MethodInvoker(delegate () {
                            comboBox2.SelectedIndex = find;
                        }));

                    }

                    Stop();
                    time = 0;

                }
                else
                {
                    epc = "";
                    time++;
                    if (lblTimer.InvokeRequired)
                    {
                        lblTimer.Invoke(new MethodInvoker(delegate () {
                            lblTimer.Text = time.ToString();
                        }));

                    }


                }

            }

        }

    }
}

