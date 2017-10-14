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
    public partial class Product : UserControl
    {
        public Product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           ((Main)this.Parent.Parent).ChangeView<AddProduct>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<UpdateProduct>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Items.Categories>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Items.Brands>();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            List<LTS.Product> prod = new List<LTS.Product>();
            prod = DAT.DataAccess.GetProduct().ToList();

            for (int i = 0; i < prod.Count; i++)
            {
                String barcodeNumb = DAT.DataAccess.GetBarcode().Where(o => o.BarcodeID == prod[i].BarcodeID).FirstOrDefault().BarcodeNumber;
                String brandName = DAT.DataAccess.GetBrand().Where(o => o.BrandID == prod[i].BrandID).FirstOrDefault().BrandName;
                String categoryName = DAT.DataAccess.GetCategory().Where(o => o.CategoryID == prod[i].CategoryID).FirstOrDefault().CategoryName;
                dgvProducts.Rows.Add(prod[i].ProductID, prod[i].ProductName, prod[i].ProductDescription, barcodeNumb, brandName, categoryName);
            }
        }
    }
}
