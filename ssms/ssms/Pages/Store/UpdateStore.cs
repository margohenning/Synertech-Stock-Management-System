using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Pages
{
    public partial class UpdateStore : UserControl
    {
        List<LTS.Store> listS;
        public UpdateStore()
        {
            InitializeComponent();
        }
        //Tiaan
        private void UpdateStore_Load(object sender, EventArgs e)
        {
            listS = DAT.DataAccess.GetStore().ToList();
            List<string> S = new List<string>();

            for (int x = 0; x < listS.Count; x++)
            {
                S.Add(listS[x].StoreID.ToString());
                S.Add(listS[x].StoreName);
                S.Add(listS[x].StoreLocation);
            }

            List<LTS.Store> store = new List<LTS.Store>();

            store = DAT.DataAccess.GetStore().ToList();

            for (int i = 0; i < store.Count; i++)
            {
                dataGridView1.Rows.Add(store[i].StoreID, store[i].StoreName, store[i].StoreLocation);
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

        }
    }
}
