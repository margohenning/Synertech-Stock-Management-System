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
        private void button4_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            comboBoxBrand.Enabled = false;
            comboBoxCategory.Enabled = false;
           

            ChangeView<Items.AddBrandSmall>();
        }

        //Margo
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
            try
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

                listBar = DAT.DataAccess.GetBarcode().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           

        }

        
        //Margo
        public void doneBrand()
        {
            try
            {
                panel1.Controls.Clear();
                comboBoxBrand.DataSource = null;
                if (listB != null)
                {
                    listB.Clear();
                }

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
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
            
        }

        
        //Margo
        public void doneCategory()
        {
            try
            {
                panel1.Controls.Clear();
                comboBoxCategory.DataSource = null;
                if (listC != null)
                {
                    listC.Clear();
                }
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
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
           
        }


        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Products.Product>();
        }

        //Marius
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                brandlbl.Visible = false;
                catlbl.Visible = false;
                lblBarcodeVal.Visible = false;
                lblDescVal.Visible = false;
                lblNameVal.Visible = false;
                int getBarcodeID;
                try
                {
                    LTS.Product prod = new LTS.Product();

                    LTS.Brand brand = new LTS.Brand();
                    brand = DAT.DataAccess.GetBrand().Where(o => o.BrandName == comboBoxBrand.SelectedItem.ToString()).FirstOrDefault();
                    if (brand != null)
                    {
                        prod.BrandID = brand.BrandID;

                    }
                    else
                    {
                        brandlbl.Visible = true;
                    }

                    LTS.Category cat = new LTS.Category();
                    cat = DAT.DataAccess.GetCategory().Where(o => o.CategoryName == comboBoxCategory.SelectedItem.ToString()).FirstOrDefault();

                    if (cat != null)
                    {
                        prod.CategoryID = cat.CategoryID;

                    }
                    else
                    {
                        catlbl.Visible = true;
                    }




                    LTS.Barcode barc = new LTS.Barcode();
                    if (listBar.Where(u => u.BarcodeNumber == tbBarcode.Text).FirstOrDefault() == null)
                    {
                        barc.BarcodeNumber = tbBarcode.Text;
                        getBarcodeID = DAT.DataAccess.AddBarcode(barc);
                        if (getBarcodeID != -1)
                        {
                            prod.BarcodeID = getBarcodeID;
                        }
                        else
                        {
                            lblBarcodeVal.Visible = true;
                            lblBarcodeVal.Text = "The barcode could not be created!";
                        }

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

                    }
                    if (tbProdDesc.Text == "")
                    {

                        lblDescVal.Visible = true;
                        lblDescVal.Text = "Please enter a product description";
                    }
                    if (tbBarcode.Text == "")
                    {
                        lblBarcodeVal.Visible = true;
                        lblBarcodeVal.Text = "Please enter a barcode number";
                    }

                    int ok;
                    if (lblBarcodeVal.Visible == false && lblDescVal.Visible == false && lblNameVal.Visible == false && brandlbl.Visible == false && catlbl.Visible == false)
                    {
                        prod.ProductName = tbProdName.Text;
                        prod.ProductDescription = tbProdDesc.Text;
                        ok = DAT.DataAccess.AddProduct(prod);

                        if (ok == -1)
                        {
                            MessageBox.Show("Sorry something went wrong, the Product was not Added!");
                            ((Main)this.Parent.Parent).ChangeView<Pages.Products.Product>();
                        }
                        else
                        {
                            MessageBox.Show("The Product was added successfully!");
                            ((Main)this.Parent.Parent).ChangeView<Pages.Products.Product>();

                        }
                    }




                }
                catch (Exception ex)
                {
                    if (DialogResult.OK == MessageBox.Show("The Product was not added successfully!"))
                    {
                        ((Main)this.Parent.Parent).ChangeView<Pages.Products.Product>();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
        }
    }
}
