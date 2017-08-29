using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ssms.Admin.Settings;
using ssms.DataClasses;

namespace ssms.Admin
{
    public partial class UpdateSettings : UserControl
    {
        List<AntennaConfig> AntennaList = new List<AntennaConfig>();
        List<Reader> reader = new List<Reader>();
        public UpdateSettings()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBoxStore.Enabled = false;
            comboBox1.Enabled = false;
            dataGridView2.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            panel1.Visible = true;
            textBox1.Text = "";
            flpAntennaConfig.Controls.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows == null)
            {

            }
            else
            {
                if (MessageBox.Show("Are You sure you want to remove this reader?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (DataGridViewRow item = this.dataGridView2.SelectedRows[0])
                    {
                        int i = item.Index;
                        reader.RemoveAt(i);
                        dataGridView2.Rows.Clear();
                        for (int x = 0; x < reader.Count; x++)
                        {
                            dataGridView2.Rows.Add(reader[x].IPaddress, reader[x].numAntennas);
                        }

                    }
                }
            }
        }

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

        private void button6_Click(object sender, EventArgs e)
        {
            if (AntennaList.Count > 0 && textBox1.Text != "")
            {
                Reader r = new Reader();
                r.IPaddress = textBox1.Text;
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
                textBox2.Enabled = true;
                dataGridView2.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                dataGridView2.Rows.Clear();
                for (int x = 0; x < reader.Count; x++)
                {
                    dataGridView2.Rows.Add(reader[x].IPaddress, reader[x].numAntennas);
                }
                panel1.Visible = false;
                textBox1.Text = "";
                AntennaList.Clear();
                flpAntennaConfig.Controls.Clear();

            }
        }
    }
}
