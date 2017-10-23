using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Pages.Items
{
    public partial class AddCategorySmall : UserControl
    {
        string what;
        public AddCategorySmall()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            goBack();
        }

        private void goBack()
        {
            if (what == "ssms.Pages.Products.AddProduct")
            {
                ((Products.AddProduct)this.Parent.Parent).doneCategory();
            }
            else
            {
                ((Products.UpdateProduct)this.Parent.Parent).doneCategory();
            }
        }

        private void AddCategorySmall_Load(object sender, EventArgs e)
        {
            what = this.Parent.Parent.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCatName.Text == "" || txtCatDesc.Text == "")
            {
                label2.Text = "Please add a Category name";
                label3.Text = "Please add a Category description";
            }
            else
            {
                try
                {
                    LTS.Category Cat = new LTS.Category();
                    Cat.CategoryName = txtCatName.Text;
                    Cat.CategoryDescription = txtCatDesc.Text;
                    int catID = DAT.DataAccess.AddCategory(Cat);
                    if (catID == -1)
                    {
                        MessageBox.Show("An Error Has Occured, Please try Again");
                        txtCatName.Text = "";
                        txtCatDesc.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Added Successfully!");
                        goBack();
                    }
                }
                catch (Exception eex)
                {
                    MessageBox.Show("Please try Again");
                }
            }
        }
    }
}
