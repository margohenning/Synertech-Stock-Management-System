using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Admin.Products
{
    public partial class Product : UserControl
    {
        public Product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((AdminMain)this.Parent.Parent).ChangeView<AddProduct>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((AdminMain)this.Parent.Parent).ChangeView<UpdateProduct>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((AdminMain)this.Parent.Parent).ChangeView<Stock.Categories>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((AdminMain)this.Parent.Parent).ChangeView<Stock.Brands>();
        }
    }
}
