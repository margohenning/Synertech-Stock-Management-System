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
            if (txtBrandName.Text == "" || txtBrandDesc.Text == "")
            {
                label2.Text = "Please add a Brand name";
                label3.Text = "Please add a Brand description";
            }
            else
            {
                try
                {
                    LTS.Brand brand = new LTS.Brand();
                    brand.BrandName = txtBrandName.Text;
                    brand.BrandDescription = txtBrandDesc.Text;
                    int catID = DAT.DataAccess.AddBrand(brand);
                    if (catID == -1)
                    {
                        MessageBox.Show("An Error Has Occured, Please try Again");
                        txtBrandName.Text = "";
                        txtBrandDesc.Text = "";
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
