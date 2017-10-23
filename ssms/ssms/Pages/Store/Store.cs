using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Pages.Store
{
    public partial class Store : UserControl
    {
        public Store()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<AddStore>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<UpdateStore>();
        }
        //Tiaan
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<string> count = new List<string>();
            List<LTS.Store> store = new List<LTS.Store>();
            List<LTS.Item> item = new List<LTS.Item>();

            store = DAT.DataAccess.GetStore().ToList();
            item = DAT.DataAccess.GetItem().Where(o => o.ItemID.).ToList();

            for (int i = 0; i < item.Count; i++)
            {
                dataGridView1.Rows.Add(store[i].StoreID, store[i].StoreName, store[i].StoreLocation, ;
            }
        }
    }
}
