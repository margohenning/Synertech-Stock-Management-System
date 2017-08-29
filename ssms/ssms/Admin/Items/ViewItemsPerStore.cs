using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Admin.Items
{
    public partial class ViewItemsPerStore : UserControl
    {
        public ViewItemsPerStore()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((AdminMain)this.Parent.Parent).ChangeView<Admin.Stock.Stock>();
        }
    }
}
