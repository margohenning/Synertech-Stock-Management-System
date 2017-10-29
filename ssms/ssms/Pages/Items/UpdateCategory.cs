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
        string oldName;
        List<LTS.Category> cat = new List<LTS.Category>();
        public UpdateCategory()
        {
            InitializeComponent();
        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Categories>();
        }

        private void UpdateCategory_Load(object sender, EventArgs e)
        {
            
            if (cat != null)
            {
                cat.Clear();
                cat = DAT.DataAccess.GetCategory().ToList();
                for (int i = 0; i < cat.Count; i++)
                {
                    dataGridView1.Rows.Add(cat[i].CategoryID, cat[i].CategoryName, cat[i].CategoryDescription);
                }
                
            }
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
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

            if(label4.Text == "" && label3.Text == "")
            {
                if(txtName.Text == oldName)
                {
                    try
                    {
                        int CatID;
                        CatID = Int32.Parse(label2.Text);

                        LTS.Category Ucat = new LTS.Category();
                        Ucat.CategoryID = CatID;
                        Ucat.CategoryName = txtName.Text; 
                        Ucat.CategoryDescription = txtSur.Text;

                        bool update = DAT.DataAccess.UpdateCategory(Ucat);
                        if (update)
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
                    LTS.Category c = DAT.DataAccess.GetCategory().Where(i => i.CategoryName == txtName.Text).FirstOrDefault();
                    if (c == null)
                    {
                        try
                        {
                            int CatID;
                            CatID = Int32.Parse(label2.Text);

                            LTS.Category Ucat = new LTS.Category();
                            Ucat.CategoryID = CatID;
                            Ucat.CategoryName = txtName.Text;
                            Ucat.CategoryDescription = txtSur.Text;

                            bool update = DAT.DataAccess.UpdateCategory(Ucat);
                            if (update)
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
                        label3.Text = "Sorry, the newly entered category name already exists";
                    }

                }
              
            }
           

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                {
                    int index = item.Index;

                    label2.Text = cat[index].CategoryID.ToString();
                    txtName.Text = cat[index].CategoryName;
                    txtSur.Text = cat[index].CategoryDescription;
                    oldName = cat[index].CategoryName;

                }
            }

            
        }
    }
    }

