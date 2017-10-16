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
    public partial class Items : UserControl
    {
        public Items()
        {
            InitializeComponent();
        }

        //Devon
        private void Stock_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<AddStock>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<UpdateStock>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.ViewItemsPerStore>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.ScanItemsInStore>();
        }

        //Devon
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                List<LTS.Item> i = new List<LTS.Item>();
                i = DAT.DataAccess.GetItem().ToList();//list from db
                List<ItemMain> imList = new List<ItemMain>();

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
                    dataGridView1.Rows.Add(im.itemID, im.EPC, im.ProductName, im.ProductDescription, im.BarcodeNumber, im.BrandName, im.CategoryName
                        , im.ItemStatus, im.StoreName);

                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        //Devon
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                List<LTS.Item> i = new List<LTS.Item>();
                i = DAT.DataAccess.GetItem().Where(s => s.ItemStatus == true).ToList();//list from db
                List<ItemMain> imList = new List<ItemMain>();

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
                    dataGridView1.Rows.Add(im.itemID, im.EPC, im.ProductName, im.ProductDescription, im.BarcodeNumber, im.BrandName, im.CategoryName
                        , im.ItemStatus, im.StoreName);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        //Devon
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                List<LTS.Item> i = new List<LTS.Item>();
                i = DAT.DataAccess.GetItem().Where(s => s.ItemStatus == false).ToList();//list from db
                List<ItemMain> imList = new List<ItemMain>();

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
                    dataGridView1.Rows.Add(im.itemID, im.EPC, im.ProductName, im.ProductDescription, im.BarcodeNumber, im.BrandName, im.CategoryName
                        , im.ItemStatus, im.StoreName);

                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }
    }
}
