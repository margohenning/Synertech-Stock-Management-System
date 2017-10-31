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
            string name = txtName.Text;
            if (txtName.Text == "")
            {
                labelError1.Text = "Please enter store name!";
                labelError1.Visible = true;
            }
            else if (txtSur.Text == "")
            {
                labelError2.Text = "Please enter store location!";
                labelError2.Visible = true;
            }
            else if (txtName.Text == name)
            {
                labelError3.Text = "Store already exists";
                labelError3.Visible = true;
            }
            else
            {
                store.StoreName = txtName.Text;
                store.StoreLocation = txtSur.Text;

                int storeID = DAT.DataAccess.AddStore(store);
                if (storeID == -1)
                {
                    if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the store was not added"))
                    {
                        ((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();
                    }
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The store was added successfully"))
                    { }
                }
            }
        }
        
         //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();
        }

    }
}
