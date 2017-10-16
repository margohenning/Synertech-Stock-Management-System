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
        public string ProductBarcode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }

        public ShowProductDetails(string pBarcode,string pName,string pDescription,string pBrand, string pCategory)
        {
            InitializeComponent();
            ProductBarcode = pBarcode;
            ProductName = pName;
            ProductDescription = pDescription;
            Brand = pBrand;
            Category = pCategory;
            

        }

        private void ShowProductDetails_Load(object sender, EventArgs e)
        {
            barcode.Text = ProductBarcode; 
        }
    }
}
