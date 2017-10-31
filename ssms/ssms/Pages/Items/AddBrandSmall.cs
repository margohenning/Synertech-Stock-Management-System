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
    public partial class AddBrandSmall : UserControl
    {
        string what;
        public AddBrandSmall()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            goBack();
        }

        private void goBack()
        {
            if (what == "ssms.Pages.Products.AddProduct")
            {
                ((Products.AddProduct)this.Parent.Parent).doneBrand();
            }
            else
            {
                ((Products.UpdateProduct)this.Parent.Parent).doneBrand();
            }
        }

        private void AddBrandSmall_Load(object sender, EventArgs e)
        {
            what = this.Parent.Parent.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            label2.Text = "";

            if (txtBrandName.Text == "")
            {
                label2.Text = "Please add a Brand Name";

            }

            if (txtBrandDesc.Text == "")
            {
                label3.Text = "Please add a Brand Description";
            }


            if (label2.Text == "" && label3.Text == "")
            {
                LTS.Brand c = DAT.DataAccess.GetBrand().Where(i => i.BrandName == txtBrandName.Text).FirstOrDefault();
                if (c == null)
                {
                    try
                    {
                        LTS.Brand b = new LTS.Brand();
                        b.BrandName = txtBrandName.Text;
                        b.BrandDescription = txtBrandDesc.Text;
                        int bID = DAT.DataAccess.AddBrand(b);
                        if (bID == -1)
                        {
                            MessageBox.Show("An Error Has Occured, Please try Again");
                            txtBrandName.Text = "";
                            txtBrandDesc.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Added Successfully!");
                            goBack();
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
                    label2.Text = "Sorry, this brand name already exists";
                }


            }

        }
    }
}
