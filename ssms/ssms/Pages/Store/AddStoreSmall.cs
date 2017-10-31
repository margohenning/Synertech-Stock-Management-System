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
    public partial class AddStoreSmall : UserControl
    {
        string what;
        public AddStoreSmall()
        {
            InitializeComponent();

        }
        //Tiaan
        private void btnlogin_Click(object sender, EventArgs e)
        {
                LTS.Store store = new LTS.Store();
                if (txtName.Text == "")
                {
                labelError1.Text = "Please enter store name!"; //validation
                labelError1.Visible = true;
            }
                else if (txtSur.Text == "")
                {
                labelError2.Text = "Please enter store location!";
                labelError2.Visible = true;
            }
                else
                {
                    store.StoreName = txtName.Text;
                    store.StoreLocation = txtSur.Text;
                }
                int storeID = DAT.DataAccess.AddStore(store);
                if (storeID == -1)
                {
                    if(DialogResult.OK == MessageBox.Show("Sorry something went wrong, the store was not added"))
                {}
                }
                else
            {
                    if(DialogResult.OK == MessageBox.Show("The store was added successfully"))
                { }
            }
        }

              

        private void button2_Click(object sender, EventArgs e)
        {
            goBack();
            
        }

        private void AddStoreSmall_Load(object sender, EventArgs e)
        {
            what = this.Parent.Parent.ToString(); 
        }

        private void goBack()
        {
            if (what == "ssms.Pages.Items.AddStock")
            {
                ((Items.AddStock)this.Parent.Parent).doneStore();
            }
            else
            {
                ((Items.UpdateStock)this.Parent.Parent).doneStore();
            }
        }

    }
}
