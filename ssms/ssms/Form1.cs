using ssms.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms
{
    public partial class Form1 : Form
    {
        public LTS.User loggedIn;
        public Form1()
        {
            
            Application.EnableVisualStyles();

            InitializeComponent();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           ChangeView<Welcome>();
        }

        

        public void ChangeView<T>() where T : Control, new()
        {
            try
            {
                panel.Controls.Clear();
                T find = new T();
                find.Parent = panel;
                find.Dock = DockStyle.Fill;
                find.BringToFront();
            }
            catch
            {

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to exit the Synertech Items Management System?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
            else
            {
                e.Cancel = true;
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (loggedIn != null) {
                ChangeView<Main>();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (loggedIn != null)
            {
                ChangeView<Main>();
            }
        }
    }
}
