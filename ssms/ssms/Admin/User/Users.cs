using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Admin
{
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((AdminMain)this.Parent.Parent).ChangeView<AddStore>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((AdminMain)this.Parent.Parent).ChangeView<UpdateUser>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((AdminMain)this.Parent.Parent).ChangeView<DeactivateUser>();
        }
    }
}
