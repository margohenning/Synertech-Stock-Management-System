
﻿using System;
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
    public partial class UpdateStore : UserControl
    {
        List<LTS.Store> listS;
        List<LTS.Store> store = new List<LTS.Store>();
        LTS.Store current = new LTS.Store();
        public UpdateStore()
        {
            InitializeComponent();

        }
        

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                labelError1.Visible = false;
                labelError2.Visible = false;
                labelError3.Visible = false;
                txterror.Visible = false;
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

                if (current == null)
                {
                    txterror.Visible = true;
                    check = false;
                }

                if (check)
                {
                    bool update = false;
                    if (current.StoreName == txtName.Text)
                    {
                        current.StoreName = txtName.Text;
                        current.StoreLocation = txtSur.Text;
                        update = DAT.DataAccess.UpdateStore(current);
                        if (update)
                        {
                            MessageBox.Show("The store updated successfully");
                            ((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();

                        }
                        else
                        {
                            MessageBox.Show("The store was not updated successfully");
                            ((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();
                        }

                    }
                    else
                    {
                        LTS.Store s = DAT.DataAccess.GetStore().Where(y => y.StoreName == txtName.Text).FirstOrDefault();
                        if (s == null)
                        {
                            current.StoreName = txtName.Text;
                            current.StoreLocation = txtSur.Text;
                            update = DAT.DataAccess.UpdateStore(current);
                            if (update)
                            {
                                MessageBox.Show("The store updated successfully");
                                ((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();

                            }
                            else
                            {
                                MessageBox.Show("The store was not updated successfully");
                                ((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();
                            }
                        }
                        else
                        {
                            labelError3.Visible = true;
                        }
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

        private void UpdateStore_Load_1(object sender, EventArgs e)
        {
            try
            {
                store = DAT.DataAccess.GetStore().ToList();

                for (int i = 0; i < store.Count; i++)
                {
                    dataGridView1.Rows.Add(store[i].StoreID, store[i].StoreName, store[i].StoreLocation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count >= 1)
                {
                    using (DataGridViewRow index = this.dataGridView1.SelectedRows[0])
                    {
                        int i = index.Index;
                        current = store[i];
                        label2.Text = store[i].StoreID.ToString();
                        txtName.Text = store[i].StoreName;
                        txtSur.Text = store[i].StoreLocation;
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
