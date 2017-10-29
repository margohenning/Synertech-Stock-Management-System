using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ssms.DataClasses;

namespace ssms.Pages
{
    public partial class AddUser : UserControl
    {
        List<LTS.User> listUser;
        public AddUser()
        {
            InitializeComponent();
        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Users>();
        }

        //Devon
        private void AddUser_Load(object sender, EventArgs e)
        {
            comboBoxActiv.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAdmin.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxAdmin.Items.Add("Yes");
            comboBoxAdmin.Items.Add("No");
            comboBoxAdmin.SelectedIndex = 0;

            comboBoxActiv.Items.Add("Yes");
            comboBoxActiv.Items.Add("No");
            comboBoxActiv.SelectedIndex = 0;
        }

        //Devon
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                LTS.User user = new LTS.User();
                LTS.User checkID = DAT.DataAccess.GetUser().Where(u => u.UserIdentityNumber == txtName.Text).FirstOrDefault();
                if (checkID != null)
                {
                    label3.Visible = true;
                }
                else
                {
                    user.UserIdentityNumber = txtName.Text;
                    label3.Visible = false;
                }

                LTS.User checkEmail = DAT.DataAccess.GetUser().Where(u => u.UserEmail.ToString() == txtUsername.Text).FirstOrDefault();
                if (checkEmail != null)
                {
                    label4.Visible = true;
                }
                else
                {
                    label4.Visible = false;
                    user.UserEmail = txtUsername.Text;
                }

                user.UserName = txtSur.Text;
                user.UserSurname = txtEmail.Text;
                user.UserPassword = textBox1.Text;

                if (comboBoxAdmin.SelectedItem.Equals("Yes"))
                {
                    user.UserAdmin = true;
                }
                else {
                    user.UserAdmin = false;
                }

                if (comboBoxActiv.SelectedItem.Equals("Yes"))
                {
                    user.UserActivated = true;
                }
                else
                {
                    user.UserActivated = false;
                }

                if (txtName.Text != "" && txtSur.Text != "" && txtEmail.Text != "" && txtUsername.Text != "" && textBox1.Text != "")
                {
                    int userID = DAT.DataAccess.AddUser(user);
                    label16.Visible = false;
                    txtSur.Text = "";
                    txtEmail.Text = "";
                    txtUsername.Text = "";
                    textBox1.Text = "";
                    txtName.Text = "";

                    if (userID == -1)
                    {
                        if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the User was not Added!"))
                        {
                        }

                    }
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show("The User was added successfully!"))
                        {
                            ((Main)this.Parent.Parent).ChangeView<Pages.Users>();
                        }
                    }
                }
                else {
                    label16.Text = "All fields need to be completed!";
                    label16.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
