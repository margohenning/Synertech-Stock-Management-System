using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Admin.Stock
{
    public partial class AddStock : UserControl
    {
        List<LTS.Brand> listB;
        List<LTS.Category> listC;
        List<LTS.Store> listS;
        public AddStock()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtSur_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnlogin.Enabled = false;
            comboBoxBrand.Enabled = false;
            comboBoxCategory.Enabled = false;
            comboBoxStore.Enabled = false;

            ChangeView<AddBrandSmall>();
        }

        //to change the content of the small panel
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

        private void button3_Click(object sender, EventArgs e)
        {
            btnlogin.Enabled = false;
            comboBoxBrand.Enabled = false;
            comboBoxCategory.Enabled = false;
            comboBoxStore.Enabled = false;
            ChangeView<AddCategorySmall>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            btnlogin.Enabled = false;
            comboBoxBrand.Enabled = false;
            comboBoxCategory.Enabled = false;
            comboBoxStore.Enabled = false;
            ChangeView<Store.AddStoreSmall>();
        }

        //after a brand is added in the small panel you need to update the combobox
        public void doneBrand()
        {
            panel1.Controls.Clear();
            comboBoxBrand.DataSource = null;
            listB.Clear();
            listB = DAT.DataAccess.GetBrand().ToList();
            List<string> B = new List<string>();

            for (int x = 0; x < listB.Count; x++)
            {
                B.Add(listB[x].BrandName);
            }
            comboBoxBrand.DataSource = B;

            btnlogin.Enabled = true;
            comboBoxBrand.Enabled = true;
            comboBoxCategory.Enabled = true;
            comboBoxStore.Enabled = true;
        }

        //after a category is added in the small panel you need to update the combobox
        public void doneCategory()
        {
            panel1.Controls.Clear();
            comboBoxCategory.DataSource = null;
            listC.Clear();
            listC = DAT.DataAccess.GetCategory().ToList();
            List<string> C = new List<string>();

            for (int x = 0; x < listC.Count; x++)
            {
                C.Add(listC[x].CategoryName);
            }
            comboBoxCategory.DataSource = C;

            btnlogin.Enabled = true;
            comboBoxBrand.Enabled = true;
            comboBoxCategory.Enabled = true;
            comboBoxStore.Enabled = true;
        }

        //after a store is added in the small panel you need to update the combobox
        public void doneStore()
        {
            panel1.Controls.Clear();
            comboBoxStore.DataSource = null;
            listS.Clear();
            listS = DAT.DataAccess.GetStore().ToList();
            List<string> S = new List<string>();

            for (int x = 0; x < listS.Count; x++)
            {
                S.Add(listS[x].StoreName);
            }
            comboBoxStore.DataSource = S;

            btnlogin.Enabled = true;
            comboBoxBrand.Enabled = true;
            comboBoxCategory.Enabled = true;
            comboBoxStore.Enabled = true;
        }

        private void AddStock_Load(object sender, EventArgs e)
        {
            //load brand names into combo box from db
            listB = DAT.DataAccess.GetBrand().ToList();
            List<string> B = new List<string>();

            for (int x = 0; x < listB.Count; x++)
            {
                B.Add(listB[x].BrandName);
            }
            comboBoxBrand.DataSource = B;

            //load category names into combo box from db
            listC = DAT.DataAccess.GetCategory().ToList();
            List<string> C = new List<string>();

            for (int x = 0; x < listC.Count; x++)
            {
                C.Add(listC[x].CategoryName);
            }
            comboBoxCategory.DataSource = C;

            //load store names into combo box from db
            listS = DAT.DataAccess.GetStore().ToList();
            List<string> S = new List<string>();

            for (int x = 0; x < listS.Count; x++)
            {
                S.Add(listS[x].StoreName);
            }
            comboBoxStore.DataSource = S;
        }
    }
}
