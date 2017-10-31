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

namespace ssms.Pages.Products
{
    public partial class UpdateProduct : UserControl
    {
        List<ProductMain> pm = new List<ProductMain>();


        List<LTS.Brand> listB;
        List<LTS.Category> listC;
        List<LTS.Barcode> listBar;
        List<string> Brand = new List<string>();
        List<string> Category = new List<string>();
        string barcodeUpdateCheck;
        string barcodeUpdateCheckCompare;
        public UpdateProduct()
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
            button3.Enabled = false;

            cbBrandName.Enabled = false;
            cbCategoryName.Enabled = false;

            button2.Enabled = false;
            dgvUpdateProduct.Enabled = false;

            
            

            ChangeView<Items.AddBrandSmall>();
        }

        //Margo
        private void button6_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            cbBrandName.Enabled = false;
            cbCategoryName.Enabled = false;
            

            
            
            button2.Enabled = false;
            dgvUpdateProduct.Enabled = false;


            ChangeView<Items.AddCategorySmall>();
        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Products.Product>();
        }

        //Marius
        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            listB = new List<LTS.Brand>();
            listB = DAT.DataAccess.GetBrand().ToList();
            for (int a = 0; a < listB.Count; a++)
            {
                Brand.Add(listB[a].BrandName);
            }


            listC = new List<LTS.Category>();
            listC = DAT.DataAccess.GetCategory().ToList();
            for (int b = 0; b < listC.Count; b++)
            {
                Category.Add(listC[b].CategoryName);
            }

            cbBrandName.DataSource = Brand;
            cbCategoryName.DataSource = Category;

            lblBarVal.Visible = false;
            lblDesVal.Visible = false;
            lblNameVal.Visible = false;

            List<LTS.Product> prod = new List<LTS.Product>();
            prod = DAT.DataAccess.GetProduct().ToList();

            for (int i = 0; i < prod.Count; i++)
            {
                ProductMain pmThis = new ProductMain();
                pmThis.ProductID = prod[i].ProductID;
                pmThis.ProductName = prod[i].ProductName;
                pmThis.ProductDescription = prod[i].ProductDescription;
                pmThis.CategoryID = prod[i].CategoryID;
                pmThis.BrandID = prod[i].BrandID;
                pmThis.BarcodeID = prod[i].BarcodeID;

                LTS.Category c = DAT.DataAccess.GetCategory().Where(o => o.CategoryID == prod[i].CategoryID).FirstOrDefault();
                pmThis.CategoryName = c.CategoryName;
                pmThis.CategoryDescription = c.CategoryDescription;

                LTS.Brand b = DAT.DataAccess.GetBrand().Where(o => o.BrandID == prod[i].BrandID).FirstOrDefault();
                pmThis.BrandName = b.BrandName;
                pmThis.BrandDescription = b.BrandDescription;

                LTS.Barcode bar = DAT.DataAccess.GetBarcode().Where(o => o.BarcodeID == prod[i].BarcodeID).FirstOrDefault();
                pmThis.BarcodeNumber = bar.BarcodeNumber;

                pm.Add(pmThis);

                dgvUpdateProduct.Rows.Add(pmThis.ProductID, pmThis.ProductName, pmThis.ProductDescription, pmThis.BarcodeNumber, pmThis.BrandName, pmThis.CategoryName);

            }
            foreach (DataGridViewColumn column in dgvUpdateProduct.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        //after a brand is added in the small panel you need to update the combobox
        //Margo
        public void doneBrand()
        {
            panel1.Controls.Clear();
            cbBrandName.DataSource = null;
            
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
            cbBrandName.DataSource = B;

            button3.Enabled = true;

            cbBrandName.Enabled = true;
            cbCategoryName.Enabled = true;
           
            button2.Enabled = true;
            dgvUpdateProduct.Enabled = true;
            
        }

        //after a category is added in the small panel you need to update the combobox
        //Margo
        public void doneCategory()
        {
            panel1.Controls.Clear();

            cbCategoryName.DataSource = null;

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
            cbCategoryName.DataSource = C;

            button3.Enabled = true;

            cbBrandName.Enabled = true;
            cbCategoryName.Enabled = true;
            
            button2.Enabled = true;
            dgvUpdateProduct.Enabled = true;
        }

        //Marius
        private void button2_Click(object sender, EventArgs e)
        {
            //Search field
            string searchValue = tbSearch.Text;
            bool foundSearch = false;
            dgvUpdateProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (tbSearch.Text == "") { MessageBox.Show("A barcode was not entered");}
            try
            {
                foreach (DataGridViewRow row in dgvUpdateProduct.Rows)
                {
                    if (row.Cells[3].Value.ToString().Equals(searchValue))
                    {
                        dgvUpdateProduct.ClearSelection();
                        row.Selected = true;
                        foundSearch = true;
                        tbSearch.Text = "";
                        break;
                    }
                }
                if (foundSearch == false) { MessageBox.Show("No product found"); }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvUpdateProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUpdateProduct.SelectedRows.Count == 1)
            {
                int index = dgvUpdateProduct.SelectedRows[0].Index;

                ProductMain p = new ProductMain();
                p = pm[index];

                lblProdID.Text = p.ProductID.ToString();
                tbProdName.Text = p.ProductName.ToString();
                tbProdDescr.Text = p.ProductDescription.ToString();
                tbBarcode.Text = p.BarcodeNumber.ToString();

                LTS.Category cat = new LTS.Category();
                cat = listC.Where(o => o.CategoryID == p.CategoryID).FirstOrDefault();
                if (cat != null)
                {
                    int catIndex = listC.IndexOf(cat);
                    cbCategoryName.SelectedIndex = catIndex;
                }

                LTS.Brand brand = new LTS.Brand();
                brand = listB.Where(z => z.BrandID == p.BrandID).FirstOrDefault();
                if (brand != null) {
                    int brandInd = listB.IndexOf(brand);
                    cbBrandName.SelectedIndex = brandInd;
                }
            }

            barcodeUpdateCheckCompare = tbBarcode.Text;
        }

        //Marius
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                lblBarVal.Visible = false;
                lblDesVal.Visible = false;
                lblNameVal.Visible = false;

                LTS.Product prod = new LTS.Product();

                int getBarcodeID = 0;
                List<string> b = new List<string>();
                listBar = DAT.DataAccess.GetBarcode().ToList();
                for (int i = 0; i < listBar.Count; i++)
                {
                    b.Add(listBar[i].BarcodeNumber);
                }

                LTS.Brand brand = new LTS.Brand();
                brand = DAT.DataAccess.GetBrand().Where(o => o.BrandName == cbBrandName.SelectedItem.ToString()).FirstOrDefault();

                LTS.Category cat = new LTS.Category();
                cat = DAT.DataAccess.GetCategory().Where(o => o.CategoryName == cbCategoryName.SelectedItem.ToString()).FirstOrDefault();

                prod.ProductID = Convert.ToInt32(lblProdID.Text);
                prod.ProductName = tbProdName.Text;
                prod.ProductDescription = tbProdDescr.Text;
                prod.BrandID = brand.BrandID;
                prod.CategoryID = cat.CategoryID;

                //int barcodeCheck = int.Parse(tbBarcode.Text);
                LTS.Barcode barc = new LTS.Barcode();
                if (!(b.Contains(tbBarcode.Text)) || barcodeUpdateCheck == barcodeUpdateCheckCompare)
                {
                    barc.BarcodeNumber = tbBarcode.Text;
                    DAT.DataAccess.AddBarcode(barc);
                    barc = DAT.DataAccess.GetBarcode().Where(o => o.BarcodeNumber == tbBarcode.Text).FirstOrDefault();
                    getBarcodeID = barc.BarcodeID;
                    prod.BarcodeID = getBarcodeID;
                }
                else
                {
                    lblBarVal.Visible = true;
                    lblBarVal.Text = "The barcode value is already in use";
                }

                //Validation checks
                if (tbProdName.Text == "") { lblNameVal.Visible = true; lblNameVal.Text = "Please enter a product name"; }
                if (tbProdDescr.Text == "") { lblDesVal.Visible = true; lblDesVal.Text = "Please enter a product description"; }
                if (tbBarcode.Text == "") { lblBarVal.Visible = true; lblBarVal.Text = "Please enter a barcode number"; }

                bool ok = false;
                if (lblBarVal.Visible == false && lblDesVal.Visible == false && lblNameVal.Visible == false)
                {
                    ok = DAT.DataAccess.UpdateProduct(prod);
                    //((Main)this.Parent.Parent).ChangeView<Pages.Products.Product>();
                }

                if (ok == false)
                {
                    if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the Product was not Updated!"))
                    {
                        
                    }
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The Product was updated successfully!"))
                    {
                        ((Main)this.Parent.Parent).ChangeView<Pages.Products.Product>();
                    }
                }
            }
            catch (Exception ex)
            {
                if (DialogResult.OK == MessageBox.Show("The Product was not updated successfully!"))
                {
                    
                }
            }
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (tbBarcode.Text != "") {
                barcodeUpdateCheck = tbBarcode.Text;
            }
        }

        private void dgvUpdateProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
