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
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<AddUser>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<UpdateUser>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<DeactivateUser>();
        }

        //Devon
        private void Users_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        //Devon
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                List<LTS.User> user = new List<LTS.User>();
                user = DAT.DataAccess.GetUser().ToList();
                for (int i = 0; i < user.Count; i++)
                {
                    dataGridView1.Rows.Add(user[i].UserID, user[i].UserIdentityNumber, user[i].UserName, user[i].UserSurname,
                        user[i].UserEmail, user[i].UserAdmin, user[i].UserActivated);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        //Devon
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                List<LTS.User> user = new List<LTS.User>();
                user = DAT.DataAccess.GetUser().Where(s => s.UserActivated == true).ToList();//list from db
                for (int i = 0; i < user.Count; i++)
                {
                    dataGridView1.Rows.Add(user[i].UserID, user[i].UserIdentityNumber, user[i].UserName, user[i].UserSurname,
                        user[i].UserEmail, user[i].UserAdmin, user[i].UserActivated);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        //Devon
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                List<LTS.User> user = new List<LTS.User>();
                user = DAT.DataAccess.GetUser().Where(s => s.UserActivated == false).ToList();//list from db
                for (int i = 0; i < user.Count; i++)
                {
                    dataGridView1.Rows.Add(user[i].UserID, user[i].UserIdentityNumber, user[i].UserName, user[i].UserSurname,
                        user[i].UserEmail, user[i].UserAdmin, user[i].UserActivated);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }
    }
}
