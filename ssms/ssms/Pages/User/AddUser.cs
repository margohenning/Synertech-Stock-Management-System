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

        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Users>();
        }

        //Devon
        private void AddUser_Load(object sender, EventArgs e)
        {
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

                user.UserIdentityNumber = txtName.Text;
                user.UserName = txtSur.Text;
                user.UserSurname = txtEmail.Text;
                user.UserEmail = txtUsername.Text;
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
