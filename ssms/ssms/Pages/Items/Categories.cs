using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Pages.Items
{
    public partial class Categories : UserControl
    {
        public Categories()
        {
            InitializeComponent();
        }

        private void Categories_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Items>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.AddCategory>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.UpdateCategory>();
        }
    }
}
