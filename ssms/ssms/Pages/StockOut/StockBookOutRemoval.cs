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
    public partial class StockBookOutRemoval : UserControl
    {
        public StockBookOutRemoval()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {


        }

        private void StockBookOutRemoval_Load(object sender, EventArgs e)
        {
            List<LTS.Store> store = new List<LTS.Store>();
            List<LTS.Barcode> barcode = new List<LTS.Barcode>();
            List<LTS.Item> item = new List<LTS.Item>();
            List<string> s = new List<string>();

            item = DAT.DataAccess.GetItem().ToList();
            barcode = DAT.DataAccess.GetBarcode().ToList();
            store = DAT.DataAccess.GetStore().ToList();

            for (int i = 0; i < s.Count; i++)
            {
                s.Add(store[i].StoreName + barcode[i].BarcodeNumber + item[i].TagEPC);
            }
            comboBoxStore.DataSource = storeName;
            comboBox1.DataSource = barcode;
            comboBox2.DataSource = item;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

        }

        
        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.StockOut.StockOut>();
        }

    }
}
