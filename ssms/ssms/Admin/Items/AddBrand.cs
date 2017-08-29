using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Admin.Stock
{
    public partial class AddBrand : UserControl
    {
        public AddBrand()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((AdminMain)this.Parent.Parent).ChangeView<Admin.Stock.Brands>();
        }
    }
}
