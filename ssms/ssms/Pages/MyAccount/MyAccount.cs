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
    public partial class MyAccount : UserControl
    {
        public MyAccount()
        {
            InitializeComponent();
        }

        //Margo
        private void MyAccount_Load(object sender, EventArgs e)
        {
            
            id.Text = ((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserID.ToString();
            idNum.Text = ((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserIdentityNumber.ToString();
            name.Text = ((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserName.ToString();
            surname.Text = ((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserSurname.ToString();
            email.Text = ((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserEmail.ToString();
            Pages.Text = ((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserAdmin.ToString();
            activated.Text = ((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserActivated.ToString();

        }

        //Margo
        private void button3_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<UpdateMyAccount>();
        }
    }
}
