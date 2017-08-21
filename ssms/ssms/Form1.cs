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
        public string loggedIn = "";
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(splash));
            t.Start();
            Thread.Sleep(6000);
            Application.EnableVisualStyles();

            InitializeComponent();

            t.Abort();
            Program.style();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // ChangeView<Welcome>();
        }

        public void splash()
        {
            Application.Run(new SPLASH());
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

            if (MessageBox.Show("Are you sure you want to exit the Synertech Stock Management System?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
            else
            {
                e.Cancel = true;
            }


        }


    }
}
