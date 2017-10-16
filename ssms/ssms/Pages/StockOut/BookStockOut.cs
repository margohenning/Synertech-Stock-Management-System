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
    public partial class BookStockOut : UserControl
    {
        public BookStockOut()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //change item status to false
            //make bookOut record
        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.StockOut.StockOut>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
