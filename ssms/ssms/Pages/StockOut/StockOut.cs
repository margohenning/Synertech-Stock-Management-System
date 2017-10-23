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
            List<LTS.Item> item = new List<LTS.Item>();
            List<LTS.Barcode> barcode = new List<LTS.Barcode>();
            List<LTS.BookOut> bookOut = new List<LTS.BookOut>();
            List<LTS.Product> product = new List<LTS.Product>();
            List<LTS.User> user = new List<LTS.User>();
            item = DAT.DataAccess.GetItem().ToList();
            barcode = DAT.DataAccess.GetBarcode().ToList();
            bookOut = DAT.DataAccess.GetBookOut().ToList();
            product = DAT.DataAccess.GetProduct();
            user = DAT.DataAccess.GetUser().ToList();
            for (int i = 0; i < item.Count; i++)
            {
                dataGridView1.Rows.Add(bookOut[i].BookOutID, item[i].TagEPC, barcode[i].BarcodeNumber, product[i].ProductName,
                                       bookOut[i].Reason, bookOut[i].Project, bookOut[i].Date, user[i].UserName, user[i].UserSurname);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.StockOut.StockOutUpdate>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.StockOut.StockBookOutRemoval>();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
