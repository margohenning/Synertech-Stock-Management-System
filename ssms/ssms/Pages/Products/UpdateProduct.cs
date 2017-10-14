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
    public partial class UpdateProduct : UserControl
    {
        List<LTS.Brand> listB;
        List<LTS.Category> listC;
        List<LTS.Barcode> listBar;
        int barcodeUpdateCheck;
        int barcodeUpdateCheckCompare;
        public UpdateProduct()
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
            button3.Enabled = false;
            cbBrandName.Enabled = false;
            cbCategoryName.Enabled = false;
            

            ChangeView<Items.AddBrandSmall>();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            cbBrandName.Enabled = false;
            cbCategoryName.Enabled = false;
            
            ChangeView<Items.AddCategorySmall>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Products.Product>();
        }

        //Marius
        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            lblBarVal.Visible = false;
            lblDesVal.Visible = false;
            lblNameVal.Visible = false;
            List<LTS.Product> prod = new List<LTS.Product>();
            prod = DAT.DataAccess.GetProduct().ToList();

            for (int i = 0; i < prod.Count; i++)
            {
                String barcodeNumb = DAT.DataAccess.GetBarcode().Where(o => o.BarcodeID == prod[i].BarcodeID).FirstOrDefault().BarcodeNumber;
                String brandName = DAT.DataAccess.GetBrand().Where(o => o.BrandID == prod[i].BrandID).FirstOrDefault().BrandName;
                String categoryName = DAT.DataAccess.GetCategory().Where(o => o.CategoryID == prod[i].CategoryID).FirstOrDefault().CategoryName;

                dgvUpdateProduct.Rows.Add(prod[i].ProductID, prod[i].ProductName, prod[i].ProductDescription, barcodeNumb, brandName, categoryName);
            }

            List<string> BrandName = new List<string>();
            List<string> CategoryName = new List<string>();

            List<LTS.Brand> brand = new List<LTS.Brand>();
            brand = DAT.DataAccess.GetBrand().ToList();
            for (int a = 0; a < brand.Count; a++ )
            {
                BrandName.Add(brand[a].BrandName);
            }


            List<LTS.Category> cat = new List<LTS.Category>();
            cat = DAT.DataAccess.GetCategory().ToList();
            for (int b = 0; b < brand.Count; b++)
            {
                CategoryName.Add(cat[b].CategoryName);
            }

            cbBrandName.DataSource = BrandName;
            cbCategoryName.DataSource = CategoryName;
        }

        //after a brand is added in the small panel you need to update the combobox
        public void doneBrand()
        {
            panel1.Controls.Clear();
            cbBrandName.DataSource = null;
            listB.Clear();
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
            
        }

        //after a category is added in the small panel you need to update the combobox
        public void doneCategory()
        {
            panel1.Controls.Clear();
            cbCategoryName.DataSource = null;
            listC.Clear();
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
            
        }

        //Marius
        private void button2_Click(object sender, EventArgs e)
        {
            //Search field
            string searchValue = tbSearch.Text;

            dgvUpdateProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dgvUpdateProduct.Rows)
                {
                    if (row.Cells[3].Value.ToString().Equals(searchValue))
                    {
                        dgvUpdateProduct.ClearSelection();
                        row.Selected = true;
                        break;
                    }
                }
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
                using (DataGridViewRow item = this.dgvUpdateProduct.SelectedRows[0])
                {
                    int i = item.Index;

                    lblProdID.Text = dgvUpdateProduct.Rows[i].Cells[0].Value.ToString();
                    tbProdName.Text = dgvUpdateProduct.Rows[i].Cells[1].Value.ToString();
                    tbProdDescr.Text = dgvUpdateProduct.Rows[i].Cells[2].Value.ToString();
                    tbBarcode.Text = dgvUpdateProduct.Rows[i].Cells[3].Value.ToString();
                    cbBrandName.Text = dgvUpdateProduct.Rows[i].Cells[4].Value.ToString();
                    cbCategoryName.Text = dgvUpdateProduct.Rows[i].Cells[5].Value.ToString();
                }
            }
            barcodeUpdateCheckCompare = int.Parse(tbBarcode.Text);
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
                        ((Main)this.Parent.Parent).ChangeView<UpdateProduct>();
                    }
                }
            }
            catch (Exception ex)
            {
                if (DialogResult.OK == MessageBox.Show("The Product was not updated successfully!"))
                {
                    ((Main)this.Parent.Parent).ChangeView<UpdateProduct>();
                }
            }
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (tbBarcode.Text != "") {
                barcodeUpdateCheck = int.Parse(tbBarcode.Text);
            }
        }
    }
}
