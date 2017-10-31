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
            label3.Text = "";
            label2.Text = "";

            if (txtCatName.Text == "")
            {
                label2.Text = "Please add a Category Name";

            }

            if (txtCatDesc.Text == "")
            {
                label3.Text = "Please add a Category Description";
            }


            if (label2.Text == "" && label3.Text == "")
            {
                LTS.Category c = DAT.DataAccess.GetCategory().Where(i => i.CategoryName == txtCatName.Text).FirstOrDefault();
                if (c == null)
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
                            //((Main)this.Parent.Parent).ChangeView<Categories>();

                        }
                    }
                    catch (Exception eex)
                    {
                        MessageBox.Show("Please try Again");
                    }

                }
                else
                {
                    label2.Text = "Sorry, this category name already exists";
                }


            }

        }
    }
}
