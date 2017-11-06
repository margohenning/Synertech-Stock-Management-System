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
        List<LTS.Store> st = new List<LTS.Store>();
        public AddStore()
        {
            InitializeComponent();

        }
        //Tiaan
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                labelError1.Visible = false;
                labelError2.Visible = false;
                labelError3.Visible = false;
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
                        ((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();

                    }
                    else
                    {
                        MessageBox.Show("The store was added successfully");
                        ((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            

        }
        
         //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();
        }

        private void AddStore_Load(object sender, EventArgs e)
        {
            try
            {
                st = DAT.DataAccess.GetStore().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           
        }
    }
}
