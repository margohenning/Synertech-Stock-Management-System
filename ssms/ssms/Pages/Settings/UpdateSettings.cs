using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ssms.Pages.Settings;
using ssms.DataClasses;

namespace ssms.Pages
{
    public partial class UpdateSettings : UserControl
    {
        List<LTS.Settings> setList = new List<LTS.Settings>();

        //Margo
        List<LTS.Store> listS = new List<LTS.Store>();
        List<AntennaConfig> AntennaList = new List<AntennaConfig>();
        List<Reader> reader = new List<Reader>();
        List<Reader> readerBackUp = new List<Reader>();
        SettingsMain sm = new SettingsMain();
        public UpdateSettings()
        {
            InitializeComponent();
        }

        //Margo
        private void button2_Click(object sender, EventArgs e)
        {
            comboBoxStore.Enabled = false;
            comboBoxSettingsName.Enabled = false;
            dataGridViewReaders.Enabled = false;
            buttonAddReader.Enabled = false;
            buttonRemoveReader.Enabled = false;
            panel1.Visible = true;
            txtIP.Text = "";
            flpAntennaConfig.Controls.Clear();
        }

        //Margo
        private void button3_Click(object sender, EventArgs e)
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

        //Margo
        private void button4_Click(object sender, EventArgs e)
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

        //Margo
        private void button5_Click(object sender, EventArgs e)
        {
            if (AntennaList.Count > 0)
            {
                var RemoveItem = AntennaList[AntennaList.Count - 1];

                AntennaList.Remove(RemoveItem);

                flpAntennaConfig.Controls.Clear();

                if (AntennaList.Count <= 4)
                {

                    AntennaList.Where(a => a.PortNumber == "1").FirstOrDefault().BackColor = Color.White;
                }

                AntennaList.ForEach(o =>
                {
                    flpAntennaConfig.Controls.Add(o);
                });
            }
        }

        //Margo
        private void button6_Click(object sender, EventArgs e)
        {
            lblIP.Visible = false;
            lblAntenna.Visible = false;

            if (AntennaList.Count > 0)
            {
                if (txtIP.Text != "")
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
                    comboBoxSettingsName.Enabled = true;
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
                else
                {
                    lblIP.Visible = true;
                }


            }
            else
            {
                lblAntenna.Visible = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Settings.Settings>();
        }

        private void UpdateSettings_Load(object sender, EventArgs e)
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

        private void comboBoxStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxStore.SelectedIndex;
            int sid = listS[index].StoreID;

            setList = DAT.DataAccess.GetSettings().Where(i => i.StoreID == sid).ToList();
            List<string> scomb = new List<string>();
            for (int q = 0; q < setList.Count; q++)
            {
                string s = setList[q].SettingsName;
                scomb.Add(s);
            }

            comboBoxSettingsName.DataSource = scomb;


        }

        private void comboBoxSettingsName_SelectedIndexChanged(object sender, EventArgs e)
        {

            reader.Clear();

            int index = comboBoxSettingsName.SelectedIndex;
            int setid = setList[index].SettingsID;

            List<LTS.Reader> r = DAT.DataAccess.GetReader().Where(w => w.SettingsID == setid).ToList();
            if (r != null)
            {
                for (int d = 0; d < r.Count; d++)
                {
                    Reader re = new Reader();
                    re.IPaddress = r[d].IPaddress;
                    re.numAntennas = r[d].NumAntennas;
                    re.readerID = r[d].ReaderID;
                    List<LTS.Antenna> ant = DAT.DataAccess.GetAntenna().Where(c => c.ReaderID == re.readerID).ToList();
                    if (ant != null)
                    {
                        for (int k = 0; k < ant.Count; k++)
                        {
                            antenna a = new antenna();
                            a.antennaID = ant[k].AntennaID;
                            a.antennaNumber = ant[k].AntennaNumber;
                            a.rxPower = ant[k].RxPower;
                            a.txPower = ant[k].TxPower;

                            re.antenna.Add(a);
                        }
                        reader.Add(re);


                    }

                }

                dataGridViewReaders.Rows.Clear();
                for (int x = 0; x < reader.Count; x++)
                {
                    dataGridViewReaders.Rows.Add(reader[x].IPaddress, reader[x].numAntennas);
                }
            }

            readerBackUp.Clear();

            int indexR = comboBoxSettingsName.SelectedIndex;
            int setidR = setList[indexR].SettingsID;

            List<LTS.Reader> ri = DAT.DataAccess.GetReader().Where(w => w.SettingsID == setidR).ToList();
            if (ri != null)
            {
                for (int d = 0; d < ri.Count; d++)
                {
                    Reader red = new Reader();
                    red.IPaddress = ri[d].IPaddress;
                    red.numAntennas = ri[d].NumAntennas;
                    red.readerID = ri[d].ReaderID;
                    List<LTS.Antenna> ant = DAT.DataAccess.GetAntenna().Where(c => c.ReaderID == red.readerID).ToList();
                    if (ant != null)
                    {
                        for (int k = 0; k < ant.Count; k++)
                        {
                            antenna a = new antenna();
                            a.antennaID = ant[k].AntennaID;
                            a.antennaNumber = ant[k].AntennaNumber;
                            a.rxPower = ant[k].RxPower;
                            a.txPower = ant[k].TxPower;

                            red.antenna.Add(a);
                        }
                        readerBackUp.Add(red);


                    }

                }

                
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int antToAdd = 0;
            int antAdded = 0;
            int antToDel = 0;
            int antDeleted = 0;
            int rToDel = 0;
            int rDeleted = 0;
            bool done = false;
            LTS.Settings s;
            bool fail = false;
            if (comboBoxStore.DataSource != null)
            {
                if (comboBoxSettingsName.DataSource != null)
                {
                    if (txtNewSettingsName.Text == "")
                    {
                        int index = comboBoxSettingsName.SelectedIndex;
                        s = setList[index];
                        done = true;

                    }
                    else
                    {
                        int index = comboBoxSettingsName.SelectedIndex;
                        s = setList[index];
                        s.SettingsName = txtNewSettingsName.Text;
                        done = DAT.DataAccess.UpdateSettings(s);


                    }

                    if (done)
                    {
                        List<Reader> toAdd = reader.Where(i => i.readerID == 0).ToList();
                        if (toAdd != null)
                        {
                            for (int q = 0; q < toAdd.Count; q++)
                            {
                                LTS.Reader r = new LTS.Reader();
                                r.IPaddress = toAdd[q].IPaddress;
                                r.NumAntennas = toAdd[q].numAntennas;
                                r.SettingsID = s.SettingsID;
                                antToAdd = antToAdd + toAdd[q].antenna.Count;
                                int rid = DAT.DataAccess.AddReader(r);
                                if (rid != -1)
                                {
                                    for (int y = 0; y < toAdd[q].antenna.Count; y++)
                                    {
                                        LTS.Antenna a = new LTS.Antenna();
                                        a.AntennaNumber = toAdd[q].antenna[y].antennaNumber;
                                        a.ReaderID = rid;
                                        a.TxPower = toAdd[q].antenna[y].txPower;
                                        a.RxPower = toAdd[q].antenna[y].rxPower;
                                        int aid = DAT.DataAccess.AddAntenna(a);
                                        if (aid != -1)
                                        {
                                            antAdded++;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Sorry, something went wrong, the setting was not updated!");
                                            ((Main)this.Parent.Parent).ChangeView<Settings.Settings>();
                                        }


                                    }


                                }
                                else
                                {
                                    MessageBox.Show("Sorry, something went wrong, the setting was not updated!");
                                    ((Main)this.Parent.Parent).ChangeView<Settings.Settings>();
                                }


                            }

                            if (antAdded == antToAdd)
                            {
                                List<Reader> stay = new List<Reader>();
                                stay = reader.Where(i => i.readerID != 0).ToList();
                                for(int x = 0; x < stay.Count; x++)
                                {
                                    Reader b = new Reader();
                                    b = stay[x];
                                    Reader c = new Reader();
                                    c = readerBackUp.Where(t => t.readerID == b.readerID).FirstOrDefault();
                                    if (c != null)
                                    {
                                        int ind = readerBackUp.IndexOf(c);
                                        readerBackUp.RemoveAt(ind);
                                    }
                                    
                                    
                                    
                                }
                                if (readerBackUp.Count != 0)
                                {
                                    rToDel = readerBackUp.Count;
                                    for (int r = 0; r < readerBackUp.Count; r++)
                                    {
                                        antToDel = antToDel + readerBackUp[r].numAntennas;
                                        for(int z = 0; z < readerBackUp[r].antenna.Count; z++)
                                        {
                                            int aid = readerBackUp[r].antenna[z].antennaID;
                                            bool remA = DAT.DataAccess.RemoveAntenna(aid);
                                            if (remA )
                                            {
                                                antDeleted++;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Sorry, something went wrong, the setting was not updated!");
                                                ((Main)this.Parent.Parent).ChangeView<Settings.Settings>();
                                            }


                                        }

                                        int reID = readerBackUp[r].readerID;
                                        bool remR = DAT.DataAccess.RemoveReader(reID);
                                        if (remR)
                                        {
                                            rDeleted++;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Sorry, something went wrong, the setting was not updated!");
                                            ((Main)this.Parent.Parent).ChangeView<Settings.Settings>();
                                        }

                                    }
                                    if(antDeleted==antToDel && rDeleted == rToDel)
                                    {
                                        MessageBox.Show("The setting was updated succesfully!");
                                        ((Main)this.Parent.Parent).ChangeView<Settings.Settings>();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sorry, something went wrong, the setting was not updated!");
                                        ((Main)this.Parent.Parent).ChangeView<Settings.Settings>();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("The setting was updated succesfully!");
                                    ((Main)this.Parent.Parent).ChangeView<Settings.Settings>();
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("Sorry, something went wrong, the setting was not updated!");
                                ((Main)this.Parent.Parent).ChangeView<Settings.Settings>();
                            }



                        }
                        else
                        {
                            MessageBox.Show("Sorry, something went wrong, the setting was not updated!");
                            ((Main)this.Parent.Parent).ChangeView<Settings.Settings>();
                            

                        }


                    }
                    else
                    {
                        MessageBox.Show("Sorry, something went wrong, the setting was not updated!");
                        ((Main)this.Parent.Parent).ChangeView<Settings.Settings>();
                    }


                }
                else
                {
                    lblName.Visible = true;
                }
            }
            else
            {
                lblStore.Visible = true;
            }

            
        }
    }
}
