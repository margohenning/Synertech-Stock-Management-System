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
        public UpdateBrand()
        {
            InitializeComponent();
        }

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
            List<string> brandID = new List<string>();
            if (txtName.Text == "" || txtSur.Text == "")
            {
                label3.Text = "Please add a brand Name";
                label4.Text = "Please add a brand Description";
            }
            else
            {
                try
                {
                    int UbrandID;
                    using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                    {
                        int i = item.Index;
                        int oldbrandID = (int)dataGridView1.Rows[i].Cells[0].Value;
                        string ooldbrandID = oldbrandID.ToString();
                        UbrandID = DAT.DataAccess.GetBrand().Where(o => o.BrandID == oldbrandID).FirstOrDefault().BrandID;
                    }
                    try
                    {
                        LTS.Brand Ubrand = new LTS.Brand();
                        Ubrand.BrandID = DAT.DataAccess.GetCategory().Where(o => o.CategoryID == UbrandID).FirstOrDefault().CategoryID;
                        Ubrand.BrandName = txtName.Text;
                        Ubrand.BrandDescription = txtSur.Text;

                        bool update = DAT.DataAccess.UpdateBrand(Ubrand);
                        if (update)
                        {
                            if (DialogResult.OK == MessageBox.Show("Brand Updated Successfully"))
                            {
                                this.Visible = false;
                                UpdateBrand f1 = new UpdateBrand();
                                f1.Show();
                            }
                        }
                    }
                    catch (Exception eex)
                    {
                        MessageBox.Show("Something went wrong, Please try again.");
                    }
                }


                catch (Exception eex)
                {
                    MessageBox.Show("Please try Again");
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            label2.Text = selectedrow.Cells[0].Value.ToString();
            txtName.Text = selectedrow.Cells[1].Value.ToString();
            txtSur.Text = selectedrow.Cells[2].Value.ToString();
        }
    }
    }
