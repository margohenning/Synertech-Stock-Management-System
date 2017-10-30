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
    public partial class UpdateMyAccount : UserControl
    {
        string emailUpdateCheck;
        string emailUpdateCheckCompare;
        public UpdateMyAccount()
        {
            InitializeComponent();
        }


        //Marius
        private void UpdateMyAccount_Load(object sender, EventArgs e)
        {
            //Margo
            if (((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserAdmin == false)
            {
                cbAdmin.Enabled = false;
                cbActivated.Enabled = false;

            }

            lblEmail.Visible = false;
            lblIdentityNo.Visible = false;
            lblName.Visible = false;
            lblPassword.Visible = false;
            lblSurname.Visible = false;

            List<string> ComboVal = new List<string>();
            ComboVal.Add("Yes");
            ComboVal.Add("No");

            List<string> ComboVal2 = new List<string>();
            ComboVal2.Add("Yes");
            ComboVal2.Add("No");

            cbAdmin.DataSource = ComboVal;
            cbActivated.DataSource = ComboVal2;

            lblUserID.Text = ((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserID.ToString();

            LTS.User user = DAT.DataAccess.GetUser().Where(o => o.UserID == int.Parse(lblUserID.Text)).FirstOrDefault();
            tbPassword.Text = user.UserPassword;
            tbIdentityNo.Text = user.UserIdentityNumber;
            tbName.Text = user.UserName;
            tbSurname.Text = user.UserEmail;
            tbEmail.Text = user.UserEmail;

            string isAdminActivated = "";
            string isUserActivated = "";

            if (user.UserAdmin == true) { isAdminActivated = "Yes"; } else { isAdminActivated = "No"; }
            if (user.UserActivated == true) { isUserActivated = "Yes"; } else { isUserActivated = "No"; }

            cbAdmin.Text = isAdminActivated;
            cbActivated.Text = isUserActivated;

            emailUpdateCheckCompare = tbEmail.Text;
        }

        //Margo
        private void buttonBack_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<MyAccount>();
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
                user.UserIdentityNumber = tbIdentityNo.Text;
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
                if (tbIdentityNo.Text == "") { lblIdentityNo.Visible = true; lblIdentityNo.Text = "Please enter a valid ID number"; }
                if (tbName.Text == "") { lblName.Visible = true; lblName.Text = "Please enter a name"; }
                if (tbSurname.Text == "") { lblSurname.Visible = true; lblSurname.Text = "Please enter a surname"; }
                if (tbEmail.Text == "") { lblEmail.Visible = true; lblEmail.Text = "Please enter a valid email"; }
                if (tbPassword.Text == "") { lblPassword.Visible = true; lblPassword.Text = "Please enter a valid password"; }

                bool ok = false;
                if (lblEmail.Visible == false && lblIdentityNo.Visible == false && lblName.Visible == false && lblSurname.Visible == false && lblPassword.Visible == false)
                {
                    ok = DAT.DataAccess.UpdateUser(user);
                }

                if (ok == false)
                {
                    if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the User was not Updated!"))
                    {
                        
                    }
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The User was updated successfully!"))
                    {
                        ((Main)this.Parent.Parent).ChangeView<UpdateMyAccount>();
                    }
                }

            }
            catch (Exception ex)
            {
                if (DialogResult.OK == MessageBox.Show("The User was not updated successfully!"))
                {
                    ((Main)this.Parent.Parent).ChangeView<UpdateMyAccount>();
                }
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
