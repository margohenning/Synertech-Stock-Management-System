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
    public partial class StockOutUpdate : UserControl
    {
        public StockOutUpdate()
        {
            InitializeComponent();

        }

        private void StockOutUpdate_Load(object sender, EventArgs e)
        {
            List<LTS.Item> item = new List<LTS.Item>();
            List<string> s = new List<string>();
            List<LTS.Store> store = new List<LTS.Store>();
            List<LTS.Barcode> barcode = new List<LTS.Barcode>();

            store = DAT.DataAccess.GetStore().ToList();
            barcode = DAT.DataAccess.GetBarcode().ToList();
            item = DAT.DataAccess.GetItem().Where(o => o.ItemStatus == true).ToList();
            for (int i = 0; i < s.Count; i++)
            {
                s.Add(store[i].StoreName + barcode[i].BarcodeNumber + item[i].TagEPC);
            }
            comboBoxStore.DataSource = storeName;
            comboBox1.DataSource = barcode;
            comboBox2.DataSource = item;
        }

        private void comboBoxStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<LTS.Product> product = new List<LTS.Product>();
            product = DAT.DataAccess.GetProduct().ToList();
            storeName.Text = comboBoxStore.GetItemText(comboBoxStore.SelectedValue);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            barcode.Text = comboBox1.GetItemText(comboBox1.SelectedValue);
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            EPC.Text = comboBox2.GetItemText(comboBox2.SelectedValue);
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
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
