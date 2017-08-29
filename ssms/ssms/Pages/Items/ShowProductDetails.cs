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
    public partial class ShowProductDetails : UserControl
    {
        public string ProductBarcode { get { return barcode.Text; } set { barcode.Text = value; } }
        public string ProductName { get { return productName.Text; } set { productName.Text = value; } }
        public string ProductDescription { get { return ProductDesc.Text; } set { ProductDesc.Text = value; } }
        public string Brand { get { return ProductBrand.Text; } set { ProductBrand.Text = value; } }
        public string Category { get { return ProductCat.Text; } set { ProductCat.Text = value; } }
        public ShowProductDetails()
        {
            InitializeComponent();
        }
    }
}
