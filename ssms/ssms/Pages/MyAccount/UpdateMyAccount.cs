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
        public UpdateMyAccount()
        {
            InitializeComponent();
        }


        private void UpdateMyAccount_Load(object sender, EventArgs e)
        {
            //Margo
            if (((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserAdmin == false)
            {
                comboBoxAdmin.Enabled = false;
                comboBoxActiv.Enabled = false;

            }
        }

        //Margo
        private void buttonBack_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<MyAccount>();
        }
    }
}
