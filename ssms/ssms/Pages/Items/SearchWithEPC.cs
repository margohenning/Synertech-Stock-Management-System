using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ssms.DataClasses;

namespace ssms.Pages.Items
{
    public partial class SearchWithEPC : UserControl
    {
        Timer ScanTimer = new Timer();
        int time = 0;
        System.Timers.Timer timer;
        SettingsMain sm = new SettingsMain();
        List<ImpinjRevolution> impinjrev = new List<ImpinjRevolution>();
        string epc = "";
        List<LTS.Store> st = new List<LTS.Store>();
        public SearchWithEPC()
        {
            InitializeComponent();
        }

        //Margo
        private void SearchWithEPC_Load(object sender, EventArgs e)
        {
            try
            {
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Visible = false;
                if (st.Where(u => u.StoreName == comboBoxStore.SelectedItem.ToString()).FirstOrDefault() != null)
                {
                    try
                    {

                        time = 0;
                        lblTimer.Text = time.ToString();
                        timer = new System.Timers.Timer();
                        timer.Elapsed += timer_Elapsed;
                        timer.Interval = 1000;
                        ((UpdateStock)this.Parent.Parent).EnableOrDisable(false);
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
                            ((UpdateStock)this.Parent.Parent).EnableOrDisable(true);

                        }
                    }
                    catch (Exception exx)
                    {
                        lblConnect.Text = ("Store not selected!");
                        EnableOrDisable(true);
                        ((UpdateStock)this.Parent.Parent).EnableOrDisable(true);
                    }
                }
                else
                {
                    label1.Visible = true;
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

                        ((Form1)this.Parent.Parent.Parent.Parent.Parent.Parent).scan = true;
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
                        ((UpdateStock)this.Parent.Parent).EnableOrDisable(true);
                        ((Form1)this.Parent.Parent.Parent.Parent.Parent.Parent).scan = false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
                return true;
            }
           

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

                               ((Form1)this.Parent.Parent.Parent.Parent.Parent.Parent).scan = false;
                    ((UpdateStock)this.Parent.Parent).EnableOrDisable(true);
                    EnableOrDisable(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
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
                        ((UpdateStock)this.Parent.Parent).EnableOrDisable(true);
                        button4.Enabled = true;
                        comboBoxStore.Enabled = true;
                        time = 0;
                    }
                    else
                    {
                        ((UpdateStock)this.Parent.Parent).EnableOrDisable(false);
                        button4.Enabled = false;
                        comboBoxStore.Enabled = false;

                    }
                }));
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
                    bool search = ((UpdateStock)this.Parent.Parent).Search(txtEPC.Text);
                    if (search != true)
                    {
                        lblerrorEPC.Visible = true;
                    }
                    else
                    {
                        lblerrorEPC.Visible = false;
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
