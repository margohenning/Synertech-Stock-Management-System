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

namespace ssms.Pages.StockOut
{
    public partial class BookStockOut : UserControl
    {
        //Tiaan
        List<string> storeNameString = new List<string>();
        List<string> barcodeString = new List<string>();
        List<string> tagEPCString = new List<string>();

        List<DataClasses.ItemMain> imList = new List<ItemMain>();
        List<LTS.Store> store = new List<LTS.Store>();
        List<LTS.Item> item = new List<LTS.Item>();
        List<LTS.Barcode> barcodeList = new List<LTS.Barcode>();
        List<LTS.Product> product = new List<LTS.Product>();
        List<LTS.BookOut> bookOut = new List<LTS.BookOut>();
        ItemMain current = new ItemMain();
        public BookStockOut()
        {
            InitializeComponent();
        }
        //Tiaan
        private void btnlogin_Click(object sender, EventArgs e)
        {
            //change item status to false
            //make bookOut record
            if (textBox1.Text == "")
            {
                labelError1.Text = "Please enter Booking Out Reason!";
                labelError1.Visible = true;
            }
            else if (textBox2.Text == "")
            {
                labelError2.Text = "Please enter Project Name!";
                labelError2.Visible = true;
            }
            else if (dataGridView1.SelectedRows.Count == 0)
            {
                labelError3.Text = "Please select a row from the list!";
                labelError3.Visible = true;
            }
            else
            {
                current = imList[this.dataGridView1.SelectedRows[0].Index];
                LTS.BookOut checkOut = new LTS.BookOut();

                LTS.Item p = new LTS.Item();
                p = DAT.DataAccess.GetItem().Where(y => y.ItemID == current.itemID).FirstOrDefault();
                
                if (p != null)
                {
                    checkOut.Reason = textBox1.Text;
                    checkOut.Project = textBox2.Text;
                    checkOut.Date = DateTime.Today;
                    checkOut.UserID = ((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserID;
                    checkOut.ItemID = p.ItemID;
                    
                    int check = DAT.DataAccess.AddBookOut(checkOut);
                    if (check != -1)
                    {
                        p.ItemStatus = false;

                        bool itemUpdate = DAT.DataAccess.UpdateItem(p);
                        if (itemUpdate)
                        {
                            MessageBox.Show("The product was successfully booked out!");
                        }
                        else
                        {
                            MessageBox.Show("Sorry something went wrong, the product was not booked out!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry something went wrong, the product was not booked out!");
                        ((Main)this.Parent.Parent).ChangeView<BookStockOut>();
                    }
                }
            }
        }

        private void name_Click(object sender, EventArgs e)
        {

        }
        //Tiaan
        private void BookStockOut_Load(object sender, EventArgs e)
        {
            product = DAT.DataAccess.GetProduct().ToList();
            store = DAT.DataAccess.GetStore().ToList();
            barcodeList = DAT.DataAccess.GetBarcode().ToList();
            item = DAT.DataAccess.GetItem().Where(o => o.ItemStatus == true).ToList();
            bookOut = DAT.DataAccess.GetBookOut().ToList();
            imList = new List<ItemMain>();
            

            for (int x = 0; x < item.Count; x++)
            {
                ItemMain im = new ItemMain();
                //assign the item info to the ItemMain object
                im.itemID = item[x].ItemID;
                im.EPC = item[x].TagEPC;
                im.ItemStatus = item[x].ItemStatus;
                im.ProductID = item[x].ProductID;
                im.StoreID = item[x].StoreID;

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
        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.StockOut.StockOut>();
        }
        //Tiaan
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                {
                    ItemMain itemi = new ItemMain();
                    itemi = imList[this.dataGridView1.SelectedRows[0].Index];

                    
                    storeName.Text = itemi.StoreName;
                    StoreLoc.Text = itemi.StoreLocation;
                    barcode.Text = itemi.BarcodeNumber;
                    productName.Text = itemi.ProductName;
                    ProductDesc.Text = itemi.ProductDescription;
                    ProductBrand.Text = itemi.BrandName;
                    ProductCat.Text = itemi.ProductDescription;
                    EPC.Text = itemi.EPC;
                }
            }
            else { }
        }
    }
}
