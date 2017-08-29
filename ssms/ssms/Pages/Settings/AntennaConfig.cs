using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ssms.Pages.Settings
{
    public partial class AntennaConfig : UserControl
    {
        public string PortNumber { get { return lblPortNumber.Text; } set { lblPortNumber.Text = value; } }
        public bool AntennaEnabled { get { return cbxEnabled.Checked; } set { cbxEnabled.Checked = value; } }
        public decimal RXPower { get { return nudRX.Value; } set { nudRX.Value = value; } }
        public decimal TXPower { get { return nudTX.Value; } set { nudTX.Value = value; } }

        public AntennaConfig()
        {
            InitializeComponent();
        }

        private void lblPortNumber_Click(object sender, EventArgs e)
        {

        }

        private void nudTX_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
