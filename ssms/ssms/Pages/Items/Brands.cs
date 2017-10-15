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
    public partial class Brands : UserControl
    {
        string check = "";
        public Brands()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Items>();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.AddBrand>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.UpdateBrand>();
        }

        private void Brands_Load(object sender, EventArgs e)
        {
            check = "All";
            List<LTS.Brand> brand = new List<LTS.Brand>();
            brand = DAT.DataAccess.GetBrand().ToList();
            for (int i = 0; i < brand.Count; i++)
            {
                dataGridView1.Rows.Add(brand[i].BrandID, brand[i].BrandName, brand[i].BrandDescription);
            }
        }
    }
}
