
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
        public UpdateStore()
        {
            InitializeComponent();

        }
        //Tiaan
        private void UpdateStore_Load(object sender, EventArgs e)
        {
            listS = DAT.DataAccess.GetStore().ToList();
            List<string> S = new List<string>();

            for (int x = 0; x < listS.Count; x++)
            {
                S.Add(listS[x].StoreID.ToString());
                S.Add(listS[x].StoreName);
                S.Add(listS[x].StoreLocation);
            }

            List<LTS.Store> store = new List<LTS.Store>();

            store = DAT.DataAccess.GetStore().ToList();

            for (int i = 0; i < store.Count; i++)
            {
                dataGridView1.Rows.Add(store[i].StoreID, store[i].StoreName, store[i].StoreLocation);
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            LTS.Store store = new LTS.Store(); 
            if (txtName.Text == "")
            {
                labelError1.Text = "Please enter store name!";
                labelError1.Visible = true;

            }
            else if (txtSur.Text == "")
            {
                labelError2.Text = "Please enter store location!";
                labelError2.Visible = true;
            }
            else
            {
                try
                {
                    int UStoreID;
                    using (DataGridViewRow item = this.dataGridView1.SelectedRows[0])
                    {
                        int i = item.Index;
                        int oldStoreID = (int)dataGridView1.Rows[i].Cells[0].Value;
                        string ooldStoreID = oldStoreID.ToString();
                        UStoreID = DAT.DataAccess.GetStore().Where(o => o.StoreID == oldStoreID).FirstOrDefault().StoreID;
                    }
                    try
                    {
                        LTS.Store Ustore = new LTS.Store();
                        Ustore.StoreID = DAT.DataAccess.GetStore().Where(o => o.StoreID == UStoreID).FirstOrDefault().StoreID;
                        Ustore.StoreName = txtName.Text;
                        Ustore.StoreLocation = txtSur.Text;

                        bool update = DAT.DataAccess.UpdateStore(Ustore);
                        if (update)
                        {
                            if (DialogResult.OK == MessageBox.Show("Store Updated Successfully"))
                            {
                                this.Visible = false;
                                UpdateStore f1 = new UpdateStore();
                                f1.Show();
                                ((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();
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
                    MessageBox.Show("Please select data from the list");
                }
            }
        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();
        }

        private void UpdateStore_Load_1(object sender, EventArgs e)
        {
            store = DAT.DataAccess.GetStore().ToList();

            for (int i = 0; i < store.Count; i++)
            {
                dataGridView1.Rows.Add(store[i].StoreID, store[i].StoreName, store[i].StoreLocation);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                using (DataGridViewRow index = this.dataGridView1.SelectedRows[0])
                {
                    int i = index.Index;

                    label2.Text = store[i].StoreID.ToString();
                    txtName.Text = store[i].StoreName;
                    txtSur.Text = store[i].StoreLocation;
                }
            }
            else {}
        }
    }
}
