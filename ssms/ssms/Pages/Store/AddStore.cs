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
    public partial class AddStore : UserControl
    {
        public AddStore()
        {
            InitializeComponent();
        }
        //Tiaan
        private void btnlogin_Click(object sender, EventArgs e)
        {
            LTS.Store store = new LTS.Store();
            if (txtName.Text == "")
            {
                //error
            }
            else if (txtSur.Text == "")
            {
                //error
            }
            else
            {
                store.StoreName = txtName.Text;
                store.StoreLocation = txtSur.Text;
            }
            int storeID = DAT.DataAccess.AddStore(store);
            if (storeID == -1)
            {
                if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the store was not added"))
                { }
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show("The store was added successfully"))
                { }
            }
        }
    }
}
