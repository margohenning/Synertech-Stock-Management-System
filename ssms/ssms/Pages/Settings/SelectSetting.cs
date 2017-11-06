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
using System.Net.NetworkInformation;

namespace ssms.Pages.Settings
{
    public partial class SelectSetting : UserControl
    {
        //Margo
        List<LTS.Store> listS = new List<LTS.Store>();
        List<LTS.Settings> listSet = new List<LTS.Settings>();
        SettingsMain smi = new SettingsMain();
        List<ImpinjRevolution> impinjrev = new List<ImpinjRevolution>();
        int SelectedStore;
        int SelectedSetting;

        public SelectSetting()
        {
            InitializeComponent();
        }

        //Margo
        private void buttonBack_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Settings>();
        }

        //Margo
        private void SelectSetting_Load(object sender, EventArgs e)
        {
            try
            {
                //load store names into combo box from db
                listS = DAT.DataAccess.GetStore().ToList();
                List<string> S = new List<string>();

                for (int x = 0; x < listS.Count; x++)
                {
                    S.Add(listS[x].StoreName);
                }
                comboBoxStore.DataSource = S;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           
        }

        //Margo
        private void comboBoxStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridViewReaders.DataSource = null;
                dataGridViewReaders.Rows.Clear();

                int storeIndex = comboBoxStore.SelectedIndex;
                int storeID = listS[storeIndex].StoreID;
                SelectedStore = storeID;

                listSet = DAT.DataAccess.GetSettings().Where(i => i.StoreID == storeID).ToList();

                List<String> setName = new List<string>();
                for (int q = 0; q < listSet.Count; q++)
                {
                    setName.Add(listSet[q].SettingsName);
                }

                comboBox1.DataSource = setName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
        }

        //Margo
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridViewReaders.DataSource = null;
                dataGridViewReaders.Rows.Clear();

                int settingsIndex = comboBox1.SelectedIndex;
                int settingsID = listSet[settingsIndex].SettingsID;
                SelectedSetting = settingsID;

                SettingsMain sm = new SettingsMain();
                sm.SettingsID = settingsID;
                sm.SettingsName = listSet[settingsIndex].SettingsName;
                sm.SettingsSelect = listSet[settingsIndex].SettingsSelect;
                sm.StoreID = listSet[settingsIndex].StoreID;

                smi = sm;

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

                for (int i = 0; i < sm.Readers.Count; i++)
                {
                    for (int y = 0; y < sm.Readers[i].antennas.Count; y++)
                    {
                        dataGridViewReaders.Rows.Add(sm.Readers[i].IPaddress, sm.Readers[i].antennas[y].AntennaNumber, sm.Readers[i].antennas[y].TxPower, sm.Readers[i].antennas[y].RxPower);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           

        }

        //Margo
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                label6.Visible = false;
                test.Visible = false;
                if (listS.Where(u => u.StoreName == comboBoxStore.SelectedItem.ToString()).FirstOrDefault() == null)
                {

                    label6.Visible = true;
                }

                if (listSet.Where(u => u.SettingsName == comboBox1.SelectedItem.ToString()).FirstOrDefault() == null)
                {
                    label6.Visible = true;
                }

                if (label6.Visible == false)
                {
                    label6.Visible = false;
                    if (dataGridViewReaders.Rows.Count != 0)
                    {
                        LTS.Settings old = DAT.DataAccess.GetSettings().Where(i => i.StoreID == SelectedStore && i.SettingsSelect == true).FirstOrDefault();
                        bool oldchanged;
                        if (old != null)
                        {
                            old.SettingsSelect = false;
                            oldchanged = DAT.DataAccess.UpdateSettings(old);
                        }
                        else
                        {
                            oldchanged = true;
                        }


                        if (oldchanged)
                        {
                            LTS.Settings newSelect = DAT.DataAccess.GetSettings().Where(i => i.SettingsID == SelectedSetting).FirstOrDefault();
                            newSelect.SettingsSelect = true;
                            bool newchanged = DAT.DataAccess.UpdateSettings(newSelect);
                            if (newchanged)
                            {
                                MessageBox.Show("Setting Selected Successfully!");
                                ((Main)this.Parent.Parent).ChangeView<Settings>();

                            }
                            else
                            {
                                MessageBox.Show("Sorry, something went wrong, the setting was not selected!");
                                ((Main)this.Parent.Parent).ChangeView<Settings>();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sorry, something went wrong, the setting was not selected!");
                            ((Main)this.Parent.Parent).ChangeView<Settings>();
                        }
                    }
                    else
                    {
                        label6.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label6.Visible = false;
                test.Visible = false;
                if (listS.Where(u => u.StoreName == comboBoxStore.SelectedItem.ToString()).FirstOrDefault() == null)
                {

                    test.Visible = true;
                }

                if (listSet.Where(u => u.SettingsName == comboBox1.SelectedItem.ToString()).FirstOrDefault() == null)
                {
                    test.Visible = true;
                }

                if (test.Visible == false)
                {
                    connect(smi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
            
        }

        void connect(SettingsMain smii)
        {
            try
            {
                ((Form1)this.Parent.Parent.Parent.Parent).scan = true;
                lblConnect.Text = "Connecting...";

                bool checks = true;

                for (int x = 0; x < smii.Readers.Count; x++)
                {

                    ImpinjRevolution ir = new ImpinjRevolution();
                    ir.ReaderScanMode = ScanMode.FullScan;
                    ir.HostName = smii.Readers[x].IPaddress;
                    ir.Antennas = smii.Readers[x].antennas;

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
                    lblConnect.Text = "";
                    MessageBox.Show("All the readers connected succesfully!");
                    for (int i = 0; i < impinjrev.Count; i++)
                    {
                        impinjrev[i].StopRead();
                        impinjrev[i].Disconnect();

                    }

                    ((Form1)this.Parent.Parent.Parent.Parent).scan = false;


                }
                else
                {
                    lblConnect.Text = "";
                    MessageBox.Show("The readers did not connect succesfully!");
                    for (int i = 0; i < impinjrev.Count; i++)
                    {
                        impinjrev[i].StopRead();
                        impinjrev[i].Disconnect();

                    }
                    ((Form1)this.Parent.Parent.Parent.Parent).scan = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
                
            }
            
            

        }
    }
}
