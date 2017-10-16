using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Pages.Store
{
    public partial class AddStoreSmall : UserControl
    {
        string what;
        public AddStoreSmall()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            goBack();
            
        }

        private void AddStoreSmall_Load(object sender, EventArgs e)
        {
            what = this.Parent.Parent.ToString(); 
        }

        private void goBack()
        {
            if (what == "ssms.Pages.Items.AddStock")
            {
                ((Items.AddStock)this.Parent.Parent).doneStore();
            }
            else
            {
                ((Items.UpdateStock)this.Parent.Parent).doneStore();
            }
        }
    }
}
