using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Pages.StockOut
{
    public partial class StockOutUpdate : UserControl
    {
        List<string> itemString = new List<string>();
        List<string> storeString = new List<string>();
        List<string> barcodeString = new List<string>();

        List<LTS.Item> item = new List<LTS.Item>();
        List<LTS.Store> store = new List<LTS.Store>();
        List<LTS.Barcode> barcodeList = new List<LTS.Barcode>();
        public StockOutUpdate()
        {
            InitializeComponent();

        }

        private void StockOutUpdate_Load(object sender, EventArgs e)
        {/*
            store = DAT.DataAccess.GetStore().ToList();
            barcodeList = DAT.DataAccess.GetBarcode().ToList();
            item = DAT.DataAccess.GetItem().Where(o => o.ItemStatus == false).ToList();
            for (int i = 0; i < store.Count; i++)
            {
                storeString.Add(store[i].StoreName);
            }
            comboBoxStore.DataSource = storeString;

            for (int i = 0; i < barcodeList.Count; i++)
            {
                barcodeString.Add(barcodeList[i].BarcodeNumber);
            }
            comboBox1.DataSource = barcodeString;

            for (int i = 0; i < item.Count; i++)
            {
                itemString.Add(item[i].TagEPC);
            }
            comboBox2.DataSource = itemString;
        */}

       /* private void comboBoxStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sIndex = comboBoxStore.SelectedIndex;
            LTS.Store selectedStore = new LTS.Store();
            selectedStore = store[sIndex];
            storeName.Text = comboBoxStore.GetItemText(comboBoxStore.SelectedValue);
            StoreLoc.Text = selectedStore.StoreLocation;

            comboBoxStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBoxStore.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxStore.AutoCompleteSource = AutoCompleteSource.ListItems;
        }*/

       /* private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

            barcode.Text = comboBox1.GetItemText(comboBox1.SelectedValue);

            int barIndex = comboBox1.SelectedIndex;
            LTS.Product p = new LTS.Product();
            p = DAT.DataAccess.GetProduct().Where(y => y.BarcodeID == barcodeList[barIndex].BarcodeID).FirstOrDefault();
            if (p != null)
            {
                productName.Text = p.ProductName;
                ProductDesc.Text = p.ProductDescription;
                ProductBrand.Text = p.BrandID.ToString();
                ProductCat.Text = p.CategoryID.ToString();
            }
            else
            {
                //error
            }
        }

        /*private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;

            int EPCIndex = comboBox2.SelectedIndex;
            LTS.Item p = new LTS.Item();
            LTS.BookOut b = new LTS.BookOut();
            b = DAT.DataAccess.GetBookOut().Where(y => y.ItemID == item[EPCIndex].ItemID).FirstOrDefault();
            p = DAT.DataAccess.GetItem().Where(y => y.ItemID == item[EPCIndex].ItemID).FirstOrDefault();
            EPC.Text = p.TagEPC;
            label15.Text = b.Reason;
            label12.Text = b.Project;
        }*/

        /*private void btnlogin_Click(object sender, EventArgs e)
        { 
            if (comboBoxStore.Text == "")
            {
                //error
            }
            else if (comboBox1.Text == "")
            {
                //error
            }
            else if (comboBox2.Text == "")
            {
                //error
            }
            else if (textBox1.Text == "")
            {
                //error
            }
            else if (textBox2.Text == "")
            {
                //error
            }
            else
            {
                LTS.BookOut update = new LTS.BookOut();

                update.Reason = textBox1.Text;
                update.Project = textBox2.Text;

                int itemIndex = EPC.Text.Count();
                LTS.Item p = new LTS.Item();
                p = DAT.DataAccess.GetItem().Where(y => y.ItemID == item[itemIndex].ItemID).FirstOrDefault();
                update.ItemID = p.ItemID;


                bool edit = DAT.DataAccess.UpdateBookOut(update);
                if (!edit)
                {
                    if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the product was not updated!"))
                    {
                        ((Main)this.Parent.Parent).ChangeView<BookStockOut>();
                    }
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The product was successfully updated!"))
                    {
                        edit = DAT.DataAccess.UpdateBookOut(update);
                    }
                }
            }
        }*/
         //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.StockOut.StockOut>();
        }
    }
}
