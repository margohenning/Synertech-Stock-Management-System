using System;
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
    public partial class UpdateUser : UserControl
    {
        bool activated;
        string emailUpdateCheck;
        string emailUpdateCheckCompare;
        List<LTS.User> us = new List<LTS.User>();

        public UpdateUser()
        {
            InitializeComponent();
        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Users>();
        }

        //Marius
        private void UpdateUser_Load(object sender, EventArgs e)
        {
            us = DAT.DataAccess.GetUser().ToList();
            List<string> ComboVal = new List<string>();
            ComboVal.Add("Yes");
            ComboVal.Add("No");

            List<string> ComboVal2 = new List<string>();
            ComboVal2.Add("Yes");
            ComboVal2.Add("No");

            cbAdmin.DataSource = ComboVal;
            cbActivated.DataSource = ComboVal2;
            rbAll.Select();
            lblSurname.Visible = false;
            lblPassword.Visible = false;
            lblName.Visible = false;
            lblIdentityNo.Visible = false;
            lblEmail.Visible = false;

        }

        //Marius
        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAll.Checked)
            {
                string isAdminActivated = "";
                string isUserActivated = "";

                
                List<LTS.User> user = new List<LTS.User>();
                user = DAT.DataAccess.GetUser().ToList();
                for (int i = 0; i < user.Count; i++)
                {
                    if (((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserID != user[i].UserID)
                    {
                        if (user[i].UserAdmin == true) { isAdminActivated = "Yes"; } else { isAdminActivated = "No"; }
                        if (user[i].UserActivated == true) { isUserActivated = "Yes"; } else { isUserActivated = "No"; }
                        dgvUser.Rows.Add(user[i].UserID, user[i].UserIdentityNumber, user[i].UserName, user[i].UserSurname, user[i].UserEmail, isAdminActivated, isUserActivated);
                    }
                    

                }
            }
            else
            {
                dgvUser.Rows.Clear();
            }
            foreach (DataGridViewColumn column in dgvUser.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        //Marius
        private void rbActivated_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivated.Checked)
            {
                string isAdminActivated = "";
                string isUserActivated = "";
                activated = true;
                List<LTS.User> user = new List<LTS.User>();
                user = DAT.DataAccess.GetUser().Where(o => o.UserActivated.Equals(activated)).ToList();
                for (int i = 0; i < user.Count; i++)
                {
                    if (((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserID != user[i].UserID)
                    {
                        if (user[i].UserAdmin == true) { isAdminActivated = "Yes"; } else { isAdminActivated = "No"; }
                        if (user[i].UserActivated == true) { isUserActivated = "Yes"; } else { isUserActivated = "No"; }

                        dgvUser.Rows.Add(user[i].UserID, user[i].UserIdentityNumber, user[i].UserName, user[i].UserSurname, user[i].UserEmail, isAdminActivated, isUserActivated);
                    }
                   

                }
                            foreach (DataGridViewColumn column in dgvUser.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            }
            else
            {
                dgvUser.Rows.Clear();
            }
            foreach (DataGridViewColumn column in dgvUser.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        //Marius
        private void rbDeactivated_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDeactivated.Checked)
            {
                string isAdminActivated = "";
                string isUserActivated = "";
                activated = false;
                List<LTS.User> user = new List<LTS.User>();
                user = DAT.DataAccess.GetUser().Where(o => o.UserActivated.Equals(activated)).ToList();
                for (int i = 0; i < user.Count; i++)
                {
                    if (((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserID != user[i].UserID)
                    {
                        if (user[i].UserAdmin == true) { isAdminActivated = "Yes"; } else { isAdminActivated = "No"; }
                        if (user[i].UserActivated == true) { isUserActivated = "Yes"; } else { isUserActivated = "No"; }
                        dgvUser.Rows.Add(user[i].UserID, user[i].UserIdentityNumber, user[i].UserName, user[i].UserSurname, user[i].UserEmail, isAdminActivated, isUserActivated);
                    }
                    
                }
            }
            else
            {
                dgvUser.Rows.Clear();
            }
            foreach (DataGridViewColumn column in dgvUser.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        //Marius
        private void button2_Click(object sender, EventArgs e)
        {
            //ID Search button clicked
            string searchValue = tbSearch.Text;
            bool foundSearch = false;
            if (tbSearch.Text == "") { MessageBox.Show("No User Identity number was entered"); }
            dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dgvUser.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(searchValue))
                    {
                        dgvUser.ClearSelection();
                        row.Selected = true;
                        tbSearch.Text = "";
                        foundSearch = true;
                        break;
                    }
                }
                if (foundSearch == false) { MessageBox.Show("No user was found"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The user could not be found");
            }
        }

        //Marius
        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            lblAdmin.Visible = false;
            cbAdmin.Enabled = true;
            cbActivated.Enabled = true;
            if (dgvUser.SelectedRows.Count == 1)
            {
                using (DataGridViewRow item = this.dgvUser.SelectedRows[0])
                {
                    int i = item.Index;

                    lblUserID.Text = dgvUser.Rows[i].Cells[0].Value.ToString();
                    List<LTS.User> getPass = DAT.DataAccess.GetUser().Where(o => o.UserID == int.Parse(lblUserID.Text)).ToList();
                    tbIDentityNo.Text = dgvUser.Rows[i].Cells[1].Value.ToString();
                    tbName.Text = dgvUser.Rows[i].Cells[2].Value.ToString();
                    tbSurname.Text = dgvUser.Rows[i].Cells[3].Value.ToString();
                    tbEmail.Text = dgvUser.Rows[i].Cells[4].Value.ToString();
                    tbPassword.Text = getPass[0].UserPassword;
                    cbAdmin.SelectedItem = dgvUser.Rows[i].Cells[5].Value.ToString();
                    cbActivated.SelectedItem = dgvUser.Rows[i].Cells[6].Value.ToString();

                    int amountAdmin = us.Where(u => u.UserActivated == true && u.UserAdmin == true).ToList().Count;
                    if (amountAdmin <= 2 && cbAdmin.SelectedItem.ToString()=="Yes" && cbActivated.SelectedItem.ToString()=="Yes")
                    {
                        cbAdmin.Enabled = false;
                        cbActivated.Enabled = false;
                        lblAdmin.Visible = true;
                    }
                }
            }
            emailUpdateCheckCompare = tbEmail.Text;
        }

        //Marius
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                lblSurname.Visible = false;
                lblPassword.Visible = false;
                lblName.Visible = false;
                lblIdentityNo.Visible = false;
                lblEmail.Visible = false;

                LTS.User user = new LTS.User();

                user.UserID = int.Parse(lblUserID.Text);
                user.UserName = tbName.Text;
                user.UserIdentityNumber = tbIDentityNo.Text;
                user.UserSurname = tbSurname.Text;
                
                user.UserPassword = tbPassword.Text;

                List<string> emailList = new List<string>();

                List<LTS.User> listEmail = new List<LTS.User>();
                listEmail = DAT.DataAccess.GetUser().ToList();
                for (int b = 0; b < listEmail.Count; b++)
                {
                    emailList.Add(listEmail[b].UserEmail);
                }


                if (!(emailList.Contains(tbEmail.Text)) || emailUpdateCheck == emailUpdateCheckCompare)
                {
                    user.UserEmail = tbEmail.Text;
                }
                else
                {
                    lblEmail.Visible = true;
                    lblEmail.Text = "The email already exists";
                }


                if (cbAdmin.SelectedItem.Equals("Yes")) { user.UserAdmin = true; } else { user.UserAdmin = false; }
                if (cbActivated.SelectedItem.Equals("Yes")) { user.UserActivated = true; } else { user.UserActivated = false; }

                //Validation checks
                if (tbIDentityNo.Text == "") { lblIdentityNo.Visible = true; lblIdentityNo.Text = "Please enter a valid ID number"; }
                if (tbName.Text == "") { lblName.Visible = true; lblName.Text = "Please enter a name"; }
                if (tbSurname.Text == "") { lblSurname.Visible = true; lblSurname.Text = "Please enter a surname"; }
                if (tbEmail.Text == "") { lblEmail.Visible = true; lblEmail.Text = "Please enter a valid email"; }
                if (tbPassword.Text == "") { lblPassword.Visible = true; lblPassword.Text = "Please enter a valid password"; }

                bool ok = false;
                if (lblEmail.Visible == false && lblIdentityNo.Visible == false && lblName.Visible == false && lblSurname.Visible == false && lblPassword.Visible == false)
                {
                    ok = DAT.DataAccess.UpdateUser(user);
                    if (ok == false)
                    {
                        MessageBox.Show("Sorry something went wrong, the User was not Updated!");
                        ((Main)this.Parent.Parent).ChangeView<Users>();
                       
                    }
                    else
                    {
                        MessageBox.Show("The User was updated successfully!");
                        ((Main)this.Parent.Parent).ChangeView<Users>();
                        
                    }
                }

                

            }
            catch(Exception ex)
            {
                MessageBox.Show("The User was not updated successfully!");
                ((Main)this.Parent.Parent).ChangeView<Users>();
                
            }
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            //Search button clicked
            string searchValue = tbSearchName.Text;
            bool foundSearch = false;
            if (tbSearchName.Text == "") { MessageBox.Show("No User name was entered"); }
            dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dgvUser.Rows)
                {
                    if (row.Cells[2].Value.ToString().Equals(searchValue))
                    {
                        dgvUser.ClearSelection();
                        row.Selected = true;
                        tbSearchName.Text = "";
                        foundSearch = true;
                        break;
                    }
                }
                if (foundSearch == false) { MessageBox.Show("No user was found"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The user could not be found");
            }
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            if (tbEmail.Text != "")
            {
                emailUpdateCheck = tbEmail.Text;
            }
        }
    }
}

