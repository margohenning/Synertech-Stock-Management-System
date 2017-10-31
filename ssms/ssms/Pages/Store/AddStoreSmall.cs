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
        List<LTS.Store> st = new List<LTS.Store>();
        string what;
        public AddStoreSmall()
        {
            InitializeComponent();

        }
        //Tiaan
        private void btnlogin_Click(object sender, EventArgs e)
        {
            LTS.Store store = new LTS.Store();
            bool check = true;

            if (txtName.Text == "")
            {
                labelError1.Text = "Please enter store name!";
                labelError1.Visible = true;
                check = false;
            }
            if (txtSur.Text == "")
            {
                labelError2.Text = "Please enter store location!";
                labelError2.Visible = true;
                check = false;
            }
            if (st != null)
            {
                if (st.Where(u => u.StoreName == txtName.Text).FirstOrDefault() != null)
                {
                    labelError3.Text = "Store already exists";
                    labelError3.Visible = true;
                    check = false;
                }

            }

            if (check)
            {
                store.StoreName = txtName.Text;
                store.StoreLocation = txtSur.Text;

                int storeID = DAT.DataAccess.AddStore(store);
                if (storeID == -1)
                {
                    MessageBox.Show("Sorry something went wrong, the store was not added");
                    

                }
                else
                {
                    MessageBox.Show("The store was added successfully");
                    goBack();

                }
            }
        }

              
        //Margo
        private void button2_Click(object sender, EventArgs e)
        {
            goBack();
            
        }

        //Margo
        private void AddStoreSmall_Load(object sender, EventArgs e)
        {
            what = this.Parent.Parent.ToString();
            st = DAT.DataAccess.GetStore().ToList();
        }

        //Margo
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
