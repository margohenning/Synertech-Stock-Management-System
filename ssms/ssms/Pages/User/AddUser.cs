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
using System.Text.RegularExpressions;

namespace ssms.Pages
{
    public partial class lblID : UserControl
    {
        List<LTS.User> listUser;
        public lblID()
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           
        }

        //Devon
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                label11.Visible = false;
                lblName.Visible = false;
                lblSurname.Visible = false;
                lblEmail.Visible = false;
                lblPassword.Visible = false;
                bool itsOK = false;

                try
                {
                    if (txtName.Text == "" || txtName.Text.Length<13 ||!IsDigitsOnly(txtName.Text))
                    {
                        label11.Visible = true;
                    }

                    if (txtSur.Text == "")
                    {
                        lblName.Visible = true;
                    }

                    if (txtEmail.Text == "")
                    {
                        lblSurname.Visible = true;
                    }

                    if (txtUsername.Text == ""|| !Regex.IsMatch(txtUsername.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                    {
                        lblEmail.Visible = true;
                    }

                    if (textBox1.Text == "")
                    {
                        lblPassword.Visible = true;
                    }

                    if (label11.Visible == false && lblName.Visible == false && lblSurname.Visible == false && lblEmail.Visible == false && lblPassword.Visible == false)
                    {
                        LTS.User user = new LTS.User();
                        LTS.User checkID = DAT.DataAccess.GetUser().Where(u => u.UserIdentityNumber == txtName.Text).FirstOrDefault();
                        if (checkID == null)
                        {
                            user.UserIdentityNumber = txtName.Text;
                            label3.Visible = false;

                        }
                        else
                        {
                            label3.Visible = true;
                            itsOK = true;
                        }

                        LTS.User checkEmail = DAT.DataAccess.GetUser().Where(u => u.UserEmail.ToString() == txtUsername.Text).FirstOrDefault();
                        if (checkEmail == null)
                        {
                            label4.Visible = false;
                            user.UserEmail = txtUsername.Text;

                        }
                        else
                        {
                            label4.Visible = true;
                            itsOK = true;
                        }

                        user.UserName = txtSur.Text;
                        user.UserSurname = txtEmail.Text;
                        user.UserPassword = textBox1.Text;

                        if (comboBoxAdmin.SelectedItem.Equals("Yes"))
                        {
                            user.UserAdmin = true;
                        }
                        else
                        {
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

                        if (itsOK == false)
                        {
                            int userID = DAT.DataAccess.AddUser(user);
                            if (userID == -1)
                            {
                                if (DialogResult.OK == MessageBox.Show("Sorry something went wrong, the User was not Added!"))
                                {
                                }

                            }
                            else
                            {
                                MessageBox.Show("The User was added successfully!");
                                ((Main)this.Parent.Parent).ChangeView<Pages.Users>();

                            }
                        }


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sorry Something went wrong, the action was not completed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           

        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
