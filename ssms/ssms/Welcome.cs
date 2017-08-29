using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms
{
    public partial class Welcome : UserControl
    {
        public Welcome()
        {
            InitializeComponent();
        }

        

        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                label4.Visible = true;
            }
            else
            {
                label4.Visible = false;
                string username = textBox1.Text;
                string pass = textBox2.Text;

                int exist = DAT.DataAccess.GetUser().Where(i => i.UserEmail == username).ToList().Count;
                if (exist == 0)
                {
                    label4.Visible = true;
                }
                else
                {
                    int correct = DAT.DataAccess.GetUser().Where(i => i.UserEmail == username && i.UserPassword == pass && i.UserActivated == true).ToList().Count;
                    if (correct == 0)
                    {
                        label4.Visible = true;
                    }
                    else
                    {
                        LTS.User u = DAT.DataAccess.GetUser().Where(i => i.UserEmail == username).FirstOrDefault();
                        ((Form1)this.Parent.Parent).loggedIn = u;

                        ((Form1)this.Parent.Parent).ChangeView<Admin.AdminMain>();
                        
                    }

                }

            }
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }
    }
}
