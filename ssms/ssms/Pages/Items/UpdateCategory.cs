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
    public partial class UpdateCategory : UserControl
    {
        string uCheck;
        public UpdateCategory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Categories>();
        }

        private void UpdateCategory_Load(object sender, EventArgs e)
        {
            uCheck = "All";
            List<LTS.Category> cat = new List<LTS.Category>();
            cat = DAT.DataAccess.GetCategory().ToList();
            for (int i = 0; i < cat.Count; i++)
            {
                dataGridView1.Rows.Add(cat[i].CategoryID, cat[i].CategoryName, cat[i].CategoryDescription);
            }
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                int index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            label2.Text = selectedrow.Cells[0].Value.ToString();
            txtName.Text = selectedrow.Cells[1].Value.ToString();
            txtSur.Text = selectedrow.Cells[2].Value.ToString();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            List<string> CatID = new List<string>();
            if (txtName.Text == "" || txtSur.Text == "")
            {
                label3.Text = "Please add a Category Name";
                label4.Text = "Please add a Category Description";
            }
            else
            {
                try
                {
                    int UCatID;
                    using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                    {
                        int i = item.Index;
                        int oldCatID = (int)dataGridView1.Rows[i].Cells[0].Value;
                        string ooldCatID = oldCatID.ToString();
                        UCatID = DAT.DataAccess.GetCategory().Where(o => o.CategoryID == oldCatID).FirstOrDefault().CategoryID;
                    }
                        try
                        {
                            LTS.Category Ucat = new LTS.Category();
                            Ucat.CategoryID = DAT.DataAccess.GetCategory().Where(o => o.CategoryID == UCatID).FirstOrDefault().CategoryID;
                            Ucat.CategoryName = txtName.Text;
                            Ucat.CategoryDescription = txtSur.Text;
                            
                            bool update = DAT.DataAccess.UpdateCategory(Ucat);
                        if (update)
                        {
                            if (DialogResult.OK == MessageBox.Show("Category Updated Successfully"))
                            {
                                this.Visible = false;
                                UpdateCategory f1 = new UpdateCategory();
                                f1.Show();
                            }
                        }
                        }
                    catch(Exception eex)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    }

