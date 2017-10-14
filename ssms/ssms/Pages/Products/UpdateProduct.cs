using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Pages.Products
{
    public partial class UpdateProduct : UserControl
    {
        List<LTS.Brand> listB;
        List<LTS.Category> listC;
        public UpdateProduct()
        {
            InitializeComponent();
        }

        //Margo
        public void ChangeView<T>() where T : Control, new()
        {
            try
            {

                panel1.Controls.Clear();
                T find = new T();
                find.Parent = panel1;
                find.Dock = DockStyle.Fill;
                find.BringToFront();
            }
            catch
            {

            }
        }

        //Margo
        private void button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button2.Enabled = false;
            dataGridView2.Enabled = false;

            comboBoxBrand.Enabled = false;
            comboBoxCategory.Enabled = false;
            

            ChangeView<Items.AddBrandSmall>();
        }

        //Margo
        private void button6_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            comboBoxBrand.Enabled = false;
            comboBoxCategory.Enabled = false;
            button2.Enabled = false;
            dataGridView2.Enabled = false;

            ChangeView<Items.AddCategorySmall>();
        }

        //Margo
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Products.Product>();
        }

        private void UpdateProduct_Load(object sender, EventArgs e)
        {

        }

        //after a brand is added in the small panel you need to update the combobox
        //Margo
        public void doneBrand()
        {
            panel1.Controls.Clear();
            comboBoxBrand.DataSource = null;
            if (listB != null)
            {
                listB.Clear();
            }
            listB = DAT.DataAccess.GetBrand().ToList();
            List<string> B = new List<string>();

            for (int x = 0; x < listB.Count; x++)
            {
                B.Add(listB[x].BrandName);
            }
            comboBoxBrand.DataSource = B;

            button3.Enabled = true;
            comboBoxBrand.Enabled = true;
            comboBoxCategory.Enabled = true;
           
            button2.Enabled = true;
            dataGridView2.Enabled = true;

        }

        //after a category is added in the small panel you need to update the combobox
        //Margo
        public void doneCategory()
        {
            panel1.Controls.Clear();
            comboBoxCategory.DataSource = null;
            if (listC != null)
            {
                listC.Clear();
            }
            listC = DAT.DataAccess.GetCategory().ToList();
            List<string> C = new List<string>();

            for (int x = 0; x < listC.Count; x++)
            {
                C.Add(listC[x].CategoryName);
            }
            comboBoxCategory.DataSource = C;

            button3.Enabled = true;
            comboBoxBrand.Enabled = true;
            comboBoxCategory.Enabled = true;
            button2.Enabled = true;
            dataGridView2.Enabled = true;

        }
    }
}
