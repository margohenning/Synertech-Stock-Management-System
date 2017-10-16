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
    public partial class AddStock : UserControl
    {
        List<LTS.Brand> listB;
        List<LTS.Category> listC;
        List<LTS.Store> listS;
        List<LTS.Barcode> listBar;
        SettingsMain sm = new SettingsMain();
        List<ImpinjRevolution> impinjrev = new List<ImpinjRevolution>();
        string epc = "";

        public AddStock()
        {
            InitializeComponent();
        }






        //to change the content of the small panel
        //Margo
        public void ChangeView<T>() where T : Control, new()
        {
            try
            {

                panel1.Controls.Clear();
                T find = new T();
                find.Parent = panel1;
                find.Dock = DockStyle.Fill;
                find.BringToFront();
            }
            catch
            {

            }
        }


        //Margo
        private void button5_Click(object sender, EventArgs e)
        {
            btnlogin.Enabled = false;
            button2.Enabled = false;
            
            comboBoxStore.Enabled = false;
            comboBox1.Enabled = false;
            ChangeView<Store.AddStoreSmall>();
        }



        //after a store is added in the small panel you need to update the combobox
        //Margo
        public void doneStore()
        {
            panel1.Controls.Clear();
            comboBoxStore.DataSource = null;
            listS.Clear();
            listS = DAT.DataAccess.GetStore().ToList();
            List<string> S = new List<string>();

            for (int x = 0; x < listS.Count; x++)
            {
                S.Add(listS[x].StoreName);
            }
            comboBoxStore.DataSource = S;

            btnlogin.Enabled = true;
            button2.Enabled = true;

            comboBoxStore.Enabled = true;
            comboBox1.Enabled = true;
        }

        private void AddStock_Load(object sender, EventArgs e)
        {
           
            //load store names into combo box from db
            listS = DAT.DataAccess.GetStore().ToList();
            List<string> S = new List<string>();

            for (int x = 0; x < listS.Count; x++)
            {
                S.Add(listS[x].StoreName);
            }
            comboBoxStore.DataSource = S;
            

            //load barcode numbers into combo box from db
            listBar = DAT.DataAccess.GetBarcode().ToList();
            List<string> Bar = new List<string>();

            for (int x = 0; x < listBar.Count; x++)
            {
                Bar.Add(listBar[x].BarcodeNumber);
            }
            comboBox1.DataSource = Bar;



        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Items>();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            LTS.Item i = new LTS.Item();

            int storeIndex = comboBoxStore.SelectedIndex;
            int storeID = listS[storeIndex].StoreID;
            // ons het die storeID, so ons assign dit
            i.StoreID = storeID;
            
            int barcodeIndex = comboBox1.SelectedIndex;
            int barcodeID = listBar[barcodeIndex].BarcodeID;
            //ons het die BarcodeID nou gebruik ons dit om die product te kry wat daaraan behoort

            LTS.Product p = DAT.DataAccess.GetProduct().Where(a => a.BarcodeID == barcodeID).FirstOrDefault();
            //nou het ons die product

            //nou kry ons net die product ID en assign dit
            i.ProductID = p.ProductID;

            i.ItemStatus = true; // want ons add dit nou eers so dit is nog in stock
            i.TagEPC = textBox2.Text; // hier moet jy nou nog checks in werk om te kyk of dit nie leeg is nie ens.

            //nou is jy reg om jou nuwe item te add in die db

            int resultID = DAT.DataAccess.AddItem(i);

            if(resultID == -1)
            {
                //iets is fout
            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            int iStore = comboBoxStore.SelectedIndex;
            LTS.Store s = listS[iStore];

            LTS.Settings set = DAT.DataAccess.GetSettings().Where(y => y.StoreID == s.StoreID).FirstOrDefault();
            if(set != null)
            {
                connect(set);
            }
            else
            {
                lblConnect.Text = ("Settings not found!");
                
            }
        }

        bool connect(LTS.Settings se)
        {
            lblConnect.Text = "Connecting...";
            

            int index = comboBoxStore.SelectedIndex;
            int storeID = listS[index].StoreID;

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
                impinjrev.ForEach(imp =>
                {
                    imp.TagRead += ir_TagRead;
                    imp.StartRead();
                });

                ((Form1)this.Parent.Parent.Parent.Parent).scan = true;
                lblConnect.Text = "Reading...";
                while (epc == "")
                {
                    //do nothing
                }
                textBox2.Text = epc;
                for (int i = 0; i < impinjrev.Count; i++)
                {
                    impinjrev[i].StopRead();
                    impinjrev[i].Disconnect();

                }
                lblConnect.Text = "Disconnected!";

                ((Form1)this.Parent.Parent.Parent.Parent).scan = false;


            }
            else
            {
                lblConnect.Text = "Not Connected!";
            }
            return true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           

        }

        void ir_TagRead(TagInfo tag, EventArgs e)
        {
            if (tag != null)
            {
                string tagEPC = tag.TagNo;
                    epc = tagEPC;
                

               
            }
        }


    }
}
