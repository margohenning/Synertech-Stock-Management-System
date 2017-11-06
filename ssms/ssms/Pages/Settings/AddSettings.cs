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

namespace ssms.Pages.Settings
{
    public partial class AddSettings : UserControl
    {
        List<LTS.Store> listS = new List<LTS.Store>();
        List<AntennaConfig> AntennaList = new List<AntennaConfig>();
        List<Reader> reader = new List<Reader>();
        SettingsMain sm = new SettingsMain();
        public AddSettings()
        {
            InitializeComponent();
        }

        //Margo
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (AntennaList.Count < 32)
                {
                    AntennaConfig ac = new AntennaConfig();

                    ac.PortNumber = (AntennaList.Count + 1).ToString();
                    ac.AntennaEnabled = true;
                    ac.RXPower = -70;
                    ac.TXPower = 30;
                    ac.BorderStyle = BorderStyle.FixedSingle;

                    AntennaList.Add(ac);

                    flpAntennaConfig.Controls.Clear();

                    if (AntennaList.Count > 4)
                    {
                        AntennaList.Where(a => a.PortNumber == "1").FirstOrDefault().BackColor = Color.LightBlue;

                    }

                    AntennaList.ForEach(o =>
                    {
                        flpAntennaConfig.Controls.Add(o);
                    });
                }
                else
                {
                    MessageBox.Show("Sorry 32 antennas, are the maximum number of antennas that the reader can support");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           
        }

        //Margo
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (AntennaList.Count > 0)
                {
                    var RemoveItem = AntennaList[AntennaList.Count - 1];

                    AntennaList.Remove(RemoveItem);

                    flpAntennaConfig.Controls.Clear();

                    if (AntennaList.Count <= 4 && AntennaList.Count != 0)
                    {

                        AntennaList.Where(a => a.PortNumber == "1").FirstOrDefault().BackColor = Color.White;
                    }

                    AntennaList.ForEach(o =>
                    {
                        flpAntennaConfig.Controls.Add(o);
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
        }

        private void AddSettings_Load(object sender, EventArgs e)
        {
            try
            {
                // load store names into combo box from db
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                comboBoxStore.Enabled = false;
                txtSettingsName.Enabled = false;
                dataGridViewReaders.Enabled = false;
                buttonAddReader.Enabled = false;
                buttonRemoveReader.Enabled = false;
                panel1.Visible = true;
                txtIP.Text = "";
                flpAntennaConfig.Controls.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
        }

        //Margo
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                lblIP.Visible = false;
                lblAntenna.Visible = false;

                if (AntennaList.Count > 0)
                {


                    if (txtIP.Text != "")
                    {

                        string[] parts = txtIP.Text.Split('.');
                        if (parts.Length < 4)
                        {
                            lblIP.Visible = true;
                        }
                        else
                        {
                            bool valid = false;
                            foreach (string part in parts)
                            {
                                byte checkPart = 0;
                                if (!byte.TryParse(part, out checkPart))
                                {
                                    valid = true;
                                }
                            }

                            if (valid != false)
                            {
                                lblIP.Visible = true;
                            }
                            else
                            {
                                Reader r = new Reader();
                                r.IPaddress = txtIP.Text;
                                r.numAntennas = AntennaList.Count;
                                for (int i = 0; i < r.numAntennas; i++)
                                {
                                    antenna a = new antenna();
                                    a.antennaNumber = Int32.Parse(AntennaList[i].PortNumber);
                                    a.rxPower = AntennaList[i].RXPower;
                                    a.txPower = AntennaList[i].TXPower;
                                    r.antenna.Add(a);
                                }
                                reader.Add(r);

                                comboBoxStore.Enabled = true;
                                txtSettingsName.Enabled = true;
                                dataGridViewReaders.Enabled = true;
                                buttonAddReader.Enabled = true;
                                buttonRemoveReader.Enabled = true;
                                dataGridViewReaders.Rows.Clear();
                                for (int x = 0; x < reader.Count; x++)
                                {
                                    dataGridViewReaders.Rows.Add(reader[x].IPaddress, reader[x].numAntennas);
                                }
                                panel1.Visible = false;
                                txtIP.Text = "";
                                AntennaList.Clear();
                                flpAntennaConfig.Controls.Clear();
                            }
                        }

                    }
                    else
                    {
                        lblIP.Visible = true;
                    }


                }
                else
                {
                    lblAntenna.Visible = true;
                    if (txtIP.Text != "")
                    {

                        string[] parts = txtIP.Text.Split('.');
                        if (parts.Length < 4)
                        {
                            lblIP.Visible = true;
                        }
                        else
                        {
                            bool valid = false;
                            foreach (string part in parts)
                            {
                                byte checkPart = 0;
                                if (!byte.TryParse(part, out checkPart))
                                {
                                    valid = true;
                                }
                            }

                            if (valid != false)
                            {
                                lblIP.Visible = true;
                            }

                        }

                    }
                    else
                    {
                        lblIP.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
            
        }

        //Margo
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewReaders.SelectedRows == null)
                {

                }
                else
                {
                    if (MessageBox.Show("Are You sure you want to remove this reader?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (DataGridViewRow item = this.dataGridViewReaders.SelectedRows[0])
                        {
                            int i = item.Index;
                            reader.RemoveAt(i);
                            dataGridViewReaders.Rows.Clear();
                            for (int x = 0; x < reader.Count; x++)
                            {
                                dataGridViewReaders.Rows.Add(reader[x].IPaddress, reader[x].numAntennas);
                            }

                        }
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
            ((Main)this.Parent.Parent).ChangeView<Settings>();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int totalNum = 0;
                lblName.Visible = false;
                lblReader.Visible = false;
                lblStore.Visible = false;
                lblAntenna.Visible = false;
                lblIP.Visible = false;

                string name = txtSettingsName.Text;

                if (name != "")
                {
                    if (comboBoxStore.DataSource != null && listS.Where(u => u.StoreName == comboBoxStore.SelectedItem.ToString()).FirstOrDefault() != null)
                    {
                        if (reader.Count != 0)
                        {
                            int index = comboBoxStore.SelectedIndex;
                            int storeID = listS[index].StoreID;
                            sm.StoreID = storeID;
                            sm.SettingsName = name;
                            sm.SettingsSelect = false;

                            for (int x = 0; x < reader.Count; x++)
                            {
                                ReaderMain rm = new ReaderMain();
                                rm.IPaddress = reader[x].IPaddress;
                                rm.NumAntennas = reader[x].numAntennas;

                                for (int y = 0; y < reader[x].antenna.Count; y++)
                                {
                                    LTS.Antenna a = new LTS.Antenna();
                                    a.AntennaNumber = reader[x].antenna[y].antennaNumber;
                                    a.RxPower = reader[x].antenna[y].rxPower;
                                    a.TxPower = reader[x].antenna[y].txPower;
                                    rm.antennas.Add(a);

                                }
                                sm.Readers.Add(rm);

                            }
                            LTS.Settings set = new LTS.Settings();
                            set.SettingsName = sm.SettingsName;
                            set.SettingsSelect = sm.SettingsSelect;
                            set.StoreID = sm.StoreID;

                            int setDone = DAT.DataAccess.AddSettings(set);
                            if (setDone != -1)
                            {
                                sm.SettingsID = setDone;
                                for (int a = 0; a < sm.Readers.Count; a++)
                                {
                                    LTS.Reader r = new LTS.Reader();
                                    r.IPaddress = sm.Readers[a].IPaddress;
                                    r.NumAntennas = sm.Readers[a].NumAntennas;
                                    r.SettingsID = sm.SettingsID;

                                    int rid = DAT.DataAccess.AddReader(r);
                                    if (rid != -1)
                                    {
                                        sm.Readers[a].ReaderID = rid;
                                        for (int b = 0; b < sm.Readers[a].antennas.Count; b++)
                                        {
                                            LTS.Antenna ant = new LTS.Antenna();
                                            ant.AntennaNumber = sm.Readers[a].antennas[b].AntennaNumber;
                                            ant.RxPower = sm.Readers[a].antennas[b].RxPower;
                                            ant.TxPower = sm.Readers[a].antennas[b].TxPower;
                                            ant.ReaderID = sm.Readers[a].ReaderID;
                                            int aid = DAT.DataAccess.AddAntenna(ant);

                                            if (aid != -1)
                                            {
                                                totalNum = totalNum + 1;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Sorry, something went wrong, the setting was not added!");
                                                ((Main)this.Parent.Parent).ChangeView<Settings>();
                                                break;
                                            }

                                        }
                                        if (totalNum == sm.TotalAmountAntennas())
                                        {
                                            MessageBox.Show("The setting was added successfully!");
                                            ((Main)this.Parent.Parent).ChangeView<Settings>();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Sorry, something went wrong, the setting was not added!");
                                            ((Main)this.Parent.Parent).ChangeView<Settings>();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sorry, something went wrong, the setting was not added!");
                                        ((Main)this.Parent.Parent).ChangeView<Settings>();
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Sorry, something went wrong, the setting was not added!");
                                ((Main)this.Parent.Parent).ChangeView<Settings>();
                            }
                        }
                        else
                        {
                            lblReader.Visible = true;
                        }

                    }
                    else
                    {
                        lblStore.Visible = true;
                    }

                }
                else
                {
                    lblName.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
            


            

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            txtIP.Text = "";
            AntennaList.Clear();
            flpAntennaConfig.Controls.Clear();
            comboBoxStore.Enabled = true;
            txtSettingsName.Enabled = true;
            dataGridViewReaders.Enabled = true;
            buttonAddReader.Enabled = true;
            buttonRemoveReader.Enabled = true;

        }

       
    }
}