using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Pages.Products
{
    public partial class AddProduct : UserControl
    {
        List<LTS.Brand> listB;
        List<LTS.Category> listC;
        List<LTS.Barcode> listBar;
        
        public AddProduct()
        {
            InitializeComponent();
        }

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

       

        private void button4_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            comboBoxBrand.Enabled = false;
            comboBoxCategory.Enabled = false;
           

            ChangeView<Items.AddBrandSmall>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            comboBoxBrand.Enabled = false;
            comboBoxCategory.Enabled = false;
            
            ChangeView<Items.AddCategorySmall>();
        }

        //Marius
        private void AddProduct_Load(object sender, EventArgs e)
        {

            lblBarcodeVal.Visible = false;
            lblDescVal.Visible = false;
            lblNameVal.Visible = false;

            //load brand names into combo box from db
            listB = DAT.DataAccess.GetBrand().ToList();
            List<string> B = new List<string>();

            for (int x = 0; x < listB.Count; x++)
            {
                B.Add(listB[x].BrandName);
            }
            comboBoxBrand.DataSource = B;

            //load category names into combo box from db
            listC = DAT.DataAccess.GetCategory().ToList();
            List<string> C = new List<string>();

            for (int x = 0; x < listC.Count; x++)
            {
                C.Add(listC[x].CategoryName);
            }
            comboBoxCategory.DataSource = C;

            
        }

        //after a brand is added in the small panel you need to update the combobox
        public void doneBrand()
        {
            panel1.Controls.Clear();
            comboBoxBrand.DataSource = null;
            listB.Clear();
            listB = DAT.DataAccess.GetBrand().ToList();
            List<string> B = new List<string>();

            for (int x = 0; x < listB.Count; x++)
            {
                B.Add(listB[x].BrandName);
            }
            comboBoxBrand.DataSource = B;

            btnAdd.Enabled = true;
            comboBoxBrand.Enabled = true;
            comboBoxCategory.Enabled = true;
            
        }

        //after a category is added in the small panel you need to update the combobox
        public void doneCategory()
        {
            panel1.Controls.Clear();
            comboBoxCategory.DataSource = null;
            listC.Clear();
            listC = DAT.DataAccess.GetCategory().ToList();
            List<string> C = new List<string>();

            for (int x = 0; x < listC.Count; x++)
            {
                C.Add(listC[x].CategoryName);
            }
            comboBoxCategory.DataSource = C;

            btnAdd.Enabled = true;
            comboBoxBrand.Enabled = true;
            comboBoxCategory.Enabled = true;
           
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Products.Product>();
        }

        //Marius
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LTS.Product prod = new LTS.Product();

                int getBarcodeID = 0;
                List<string> b = new List<string>();
                listBar = DAT.DataAccess.GetBarcode().ToList();
                for (int i = 0; i < listBar.Count; i++)
                {
                    b.Add(listBar[i].BarcodeNumber);
                }

                LTS.Brand brand = new LTS.Brand();
                brand = DAT.DataAccess.GetBrand().Where(o => o.BrandName == comboBoxBrand.SelectedItem.ToString()).FirstOrDefault();

                LTS.Category cat = new LTS.Category();
                cat = DAT.DataAccess.GetCategory().Where(o => o.CategoryName == comboBoxCategory.SelectedItem.ToString()).FirstOrDefault();

                prod.ProductName = tbProdName.Text;
                prod.ProductDescription = tbProdDesc.Text;
                prod.BrandID = brand.BrandID;
                prod.CategoryID = cat.CategoryID;

                LTS.Barcode barc = new LTS.Barcode();
                if (!(b.Contains(tbBarcode.Text)))
                {
                    barc.BarcodeNumber = tbBarcode.Text;
                    DAT.DataAccess.AddBarcode(barc);
                    barc = DAT.DataAccess.GetBarcode().Where(o => o.BarcodeNumber == tbBarcode.Text).FirstOrDefault();
                    getBarcodeID = barc.BarcodeID;
                    prod.BarcodeID = getBarcodeID;
                }
                else
                {
                    lblBarcodeVal.Visible = true;
                    lblBarcodeVal.Text = "The barcode value is already in use";
                }

                //validation
                if (tbProdName.Text == "")
                {
                    lblNameVal.Visible = true;
                    lblNameVal.Text = "Please enter a product name";

                }if (tbProdDesc.Text == ""){

                    lblDescVal.Visible = true;
                    lblDescVal.Text = "Please enter a product description";
                }if (tbBarcode.Text == "")
                {
                    lblBarcodeVal.Visible = true;
                    lblBarcodeVal.Text = "Please enter a barcode number";
                }

                int ok = -1;
                if (lblBarcodeVal.Visible == false || lblDescVal.Visible == false || lblNameVal.Visible == false)
                {
                    ok = DAT.DataAccess.AddProduct(prod);
                }
           


                if (ok == -1)
                {
                    if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the Product was not Added!"))
                    {
                        //navigate to page
                    }
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The Product was added successfully!"))
                    {
                        
                        ChangeView<Products.Product>();
                    }
                }
            }
            catch (Exception ex)
            {
                if (DialogResult.OK == MessageBox.Show("The Product was not added successfully!"))
                {
                    //navigate to page
                }
            }
        }
    }
}
