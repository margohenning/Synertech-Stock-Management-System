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
    public partial class UpdateBrand : UserControl
    {
        string uCheck;
        string oldName;
        public UpdateBrand()
        {
            InitializeComponent();
        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Brands>();
        }

        private void UpdateBrand_Load(object sender, EventArgs e)
        {
            uCheck = "All";
            List<LTS.Brand> brand = new List<LTS.Brand>();
            brand = DAT.DataAccess.GetBrand().ToList();
            for (int i = 0; i < brand.Count; i++)
            {
                dataGridView1.Rows.Add(brand[i].BrandID, brand[i].BrandName, brand[i].BrandDescription);
            }
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            label4.Text = "";

            if (txtName.Text == "")
            {
                label3.Text = "Please add a Category Name";

            }
            if (txtSur.Text == "")
            {
                label4.Text = "Please add a Category Description";
            }

            if (label4.Text == "" && label3.Text == "")
            {
                if (txtName.Text == oldName)
                {
                    try
                    {
                        int bID;
                        bID = Int32.Parse(label2.Text);

                        LTS.Brand UB = new LTS.Brand();
                        UB.BrandID = bID;
                        UB.BrandName = txtName.Text;
                        UB.BrandDescription = txtSur.Text;

                        bool updateB = DAT.DataAccess.UpdateBrand(UB);
                        if (updateB)
                        {
                            if (DialogResult.OK == MessageBox.Show("Category Updated Successfully"))
                            {
                                ((Main)this.Parent.Parent).ChangeView<Pages.Items.Categories>();
                            }
                        }
                        else
                        {
                            if (DialogResult.OK == MessageBox.Show("Category  was not Updated Successfully"))
                            {
                                ((Main)this.Parent.Parent).ChangeView<Pages.Items.Categories>();
                            }
                        }



                    }
                    catch (Exception eex)
                    {
                        MessageBox.Show("Please try Again");
                    }
                }
                else
                {
                    LTS.Brand b = DAT.DataAccess.GetBrand().Where(i => i.BrandName == txtName.Text).FirstOrDefault();
                    if (b == null)
                    {
                        try
                        {
                            int BrandID;
                            BrandID = Int32.Parse(label2.Text);

                            LTS.Brand Ub = new LTS.Brand();
                            Ub.BrandID = BrandID;
                            Ub.BrandName = txtName.Text;
                            Ub.BrandDescription = txtSur.Text;

                            bool updateBrand = DAT.DataAccess.UpdateBrand(Ub);
                            if (updateBrand)
                            {
                                if (DialogResult.OK == MessageBox.Show("Category Updated Successfully"))
                                {
                                    ((Main)this.Parent.Parent).ChangeView<Pages.Items.Brands>();
                                }
                            }
                            else
                            {
                                if (DialogResult.OK == MessageBox.Show("Category  was not Updated Successfully"))
                                {
                                    ((Main)this.Parent.Parent).ChangeView<Pages.Items.Brands>();
                                }
                            }



                        }
                        catch (Exception eex)
                        {
                            MessageBox.Show("Please try Again");
                        }
                    }
                    else
                    {
                        label3.Text = "Sorry, the newly entered Brand name already exists";
                    }

                }

            }


        }

    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count >= 1)
            {
                using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                {
                    int index = item.Index;

                    
                    DataGridViewRow selectedrow = dataGridView1.Rows[index];
                    label2.Text = selectedrow.Cells[0].Value.ToString();
                    txtName.Text = selectedrow.Cells[1].Value.ToString();
                    txtSur.Text = selectedrow.Cells[2].Value.ToString();

                }
            }

           
        }
    }
}

