using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Pages.Items
{
    public partial class UpdateStock : UserControl
    {
        List<ItemMain> imList ;//goue gaans
        List<LTS.Brand> listB;
        List<LTS.Category> listC;
        List<LTS.Store> listS;
        public UpdateStock()
        {
            InitializeComponent();
        }

        private void UpdateStock_Load(object sender, EventArgs e)
        {
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
                p = DAT.DataAccess.GetProduct().Where(q => q.ProductID == im.ProductID).FirstOrDefault();
                im.ProductName = p.ProductName;
                im.ProductDescription = p.ProductDescription;
                im.BrandID = p.BrandID;
                im.CategoryID = p.CategoryID;

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

                //we are now done getting all the information and adding it to the created object we now add our object to the list
                /////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////
                //////////////////////////////////////////////////////////////////
                imList.Add(im);
                dataGridView2.Rows.Add(im.itemID, im.EPC, im.ProductName, im.ProductDescription, im.BarcodeNumber, im.BrandName, im.CategoryName
                    , im.ItemStatus, im.StoreName);

            }
            // we now have a list of ItemMain objects with all its info, we can now use this list to just fill in the datagridview
            

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

        //after a brand is added in the small panel you need to update the combobox


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

        private void button4_Click(object sender, EventArgs e)
        {
            string epc = textBox3.Text;
            if (epc != "")
            {
                ItemMain find = imList.Where(i => i.EPC == epc).FirstOrDefault();
                int index =imList.IndexOf(find);
                //dataGridView2.SelectedRows.Clear();
                dataGridView2.Rows[index].Selected = true;
            }
        }
    }
}
