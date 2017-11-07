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
    public partial class AddBrand : UserControl
    {
        public AddBrand()
        {
            InitializeComponent();
        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            
                ((Main)this.Parent.Parent).ChangeView<Pages.Items.Brands>();
           
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
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
                                ((Main)this.Parent.Parent).ChangeView<Brands>();

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
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           

        }
    }
}
