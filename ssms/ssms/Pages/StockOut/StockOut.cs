using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Pages.StockOut
{
    public partial class StockOut : UserControl
    {
        public StockOut()
        {
            InitializeComponent();
        }

        private void StockOut_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.StockOut.BookStockOut>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.StockOut.StockOutUpdate>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.StockOut.StockBookOutRemoval>();
        }
    }
}
