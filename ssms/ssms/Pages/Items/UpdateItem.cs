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
    public partial class UpdateStock : UserControl
    {       
        List<LTS.Brand> listB;
        List<LTS.Category> listC;
        List<LTS.Store> listS;
        List<LTS.Barcode> listBar;
        List<DataClasses.ItemMain> imList = new List<ItemMain>();

        public UpdateStock()
        {
            InitializeComponent();
        }

        //Devon
        private void UpdateStock_Load(object sender, EventArgs e)
        {
            //load store names into combo box from db
            listS = DAT.DataAccess.GetStore().ToList();
            List<string> S = new List<string>();

            for (int x = 0; x < listS.Count; x++)
            {
                S.Add(listS[x].StoreName);
            }
            comboBoxStore.DataSource = S;

            //load barcode into combo box from db
            listBar = DAT.DataAccess.GetBarcode().ToList();
            List<string> Ba = new List<string>();

            for (int x = 0; x < listBar.Count; x++)
            {
                Ba.Add(listBar[x].BarcodeNumber);
            }
            comboBox1.DataSource = Ba;

            List<LTS.Item> i = new List<LTS.Item>();
            i = DAT.DataAccess.GetItem().ToList();//list from db
            imList = new List<ItemMain>();

            for (int x = 0; x < i.Count; x++)
            {
                ItemMain im = new ItemMain();
                //assign the item info to the ItemMain object
                im.itemID = i[x].ItemID;
                im.EPC = i[x].TagEPC;
                im.ItemStatus = i[x].ItemStatus;
                im.ProductID = i[x].ProductID;
                im.StoreID = i[x].StoreID;

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
                dataGridView2.Rows.Add(im.itemID, im.EPC, im.ProductName, im.ProductDescription, im.BarcodeNumber, im.BrandName, im.CategoryName
                    , im.ItemStatus, im.StoreName);
            }
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
            button3.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button7.Enabled = false;

            textBox2.Enabled = false;
            textBox3.Enabled = false;

            comboBoxStore.Enabled = false;
            comboBox1.Enabled = false;
            dataGridView2.Enabled = false;

            ChangeView<Store.AddStoreSmall>();
        }


        //after a store is added in the small panel you need to update the combobox
        //Margo
        public void doneStore()
        {
            panel1.Controls.Clear();
            comboBoxStore.DataSource = null;
            if (listS != null)
            {
                listS.Clear();
            }
            
            listS = DAT.DataAccess.GetStore().ToList();
            List<string> S = new List<string>();

            for (int x = 0; x < listS.Count; x++)
            {
                S.Add(listS[x].StoreName);
            }
            comboBoxStore.DataSource = S;

            button3.Enabled = true;

            button2.Enabled = true;
            button4.Enabled = true;
            button7.Enabled = true;

            textBox2.Enabled = true;
            textBox3.Enabled = true;

            comboBoxStore.Enabled = true;
            comboBox1.Enabled = true;
            dataGridView2.Enabled = true;
        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Items>();
        }

        //Devon
        private void button4_Click(object sender, EventArgs e)
        {
            string epc = textBox3.Text;
            if (epc != "")
            {
                ItemMain find = imList.Where(i => i.EPC == epc).FirstOrDefault();

                int index = imList.IndexOf(find);
                dataGridView2.Rows[index].Selected = true;
                //dataGridView2.SelectedRows.Clear();
            }
        }

        //Devon
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count >= 1)
            { 
                using (DataGridViewRow item = this.dataGridView2.SelectedRows[0])
                {
                    ItemMain itemi = new ItemMain();
                    itemi = imList[this.dataGridView2.SelectedRows[0].Index];

                    int sIndex = listS.IndexOf(listS.Where(u => u.StoreID == itemi.StoreID).FirstOrDefault());
                    comboBoxStore.SelectedIndex = sIndex;

                    int i = item.Index;
                    string itemID = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    string rfTag = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    string barNum = dataGridView2.Rows[i].Cells[4].Value.ToString();

                    label5.Text = itemID;
                    textBox2.Text = rfTag;
                    comboBox1.Text = barNum;  
                }
            }
            else
            {

            }
        }

        //Devon
        private void button3_Click(object sender, EventArgs e)
        {
            int itemID = Int32.Parse(label5.Text);
            LTS.Item olditem = DAT.DataAccess.GetItem().Where(d => d.ItemID == itemID).FirstOrDefault();

            bool status = olditem.ItemStatus;

            int sIndex = comboBoxStore.SelectedIndex;
            int bIndex = comboBox1.SelectedIndex;
            if (sIndex == -1 || bIndex == -1)
            {
                label7.Visible = true;
            }
            else
            {
                label7.Visible = false;
                int storeID = listS[sIndex].StoreID;
                int barID = listBar[bIndex].BarcodeID;

                LTS.Product p = new LTS.Product();
                p = DAT.DataAccess.GetProduct().Where(f => f.BarcodeID == barID).FirstOrDefault();
                int productID;
                LTS.Item checkTag = DAT.DataAccess.GetItem().Where(b => b.TagEPC == textBox2.Text).FirstOrDefault();
                
                if (p != null)
                {
                    try
                    {
                        if (comboBoxStore.Text == "")
                        {
                            label4.Visible = true;
                        }
                        else if (checkTag != null)
                        {
                            label4.Visible = true;
                            label4.Text = "TAG alreasy exists! Please enter a different one.";
                        }
                        else
                        {
                            label4.Visible = false;
                            productID = p.ProductID;
                            LTS.Item newitem = new LTS.Item();
                            newitem.ItemID = itemID;
                            newitem.ItemStatus = status;
                            newitem.ProductID = productID;
                            newitem.TagEPC = textBox2.Text;
                            newitem.StoreID = storeID;

                            bool check = DAT.DataAccess.UpdateItem(newitem);
                            if (check)
                            {
                                MessageBox.Show("Item has been updated!");
                                ((Main)this.Parent.Parent).ChangeView<Pages.Items.Items>();
                            }
                            else
                            {
                                MessageBox.Show("Item has not been updated!");
                            }
                        }  
                    }
                    catch
                    {

                    }
                }
            }    
        }

    }
}
