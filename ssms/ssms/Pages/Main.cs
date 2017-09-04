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
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();
        }

        private void AdminMain_Load(object sender, EventArgs e)
        {

        }

        public void ChangeView<T>() where T : Control, new()
        {
            try
            {

                panel2.Controls.Clear();
                T find = new T();
                find.Parent = panel2;
                find.Dock = DockStyle.Fill;
                find.BringToFront();
            }
            catch
            {

            }
        }

        private void buttonBooks_Click(object sender, EventArgs e)
        {
            ChangeView<Pages.Items.Items>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeView<StockOut.StockOut>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeView<Store.Store>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeView<Pages.Settings.Settings>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (((Form1)this.Parent.Parent).loggedIn.UserAdmin != true ) {

                MessageBox.Show("Sorry you do not have Admin Permission to access the Users section.");
                          
            }
            else {
                ChangeView<Users>();
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeView<MyAccount>();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out from the Synertech Items Management System?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ((Form1)this.Parent.Parent).loggedIn = null;
                ((Form1)this.Parent.Parent).ChangeView<Welcome>();
            }
            else
            {
                
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeView<Products.Product>();
        }
    }
}
