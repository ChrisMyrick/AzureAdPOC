using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiDPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            txtDPIStatus.Text = txtDPIStatus.Text
                + Environment.NewLine
                + "Old DPI: " + e.DeviceDpiOld
                + Environment.NewLine
                + "New DPI: " + e.DeviceDpiNew;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtDPIStatus.Text = $"Device DPI:  {this.DeviceDpi}";
            lblAutoScaleMode.Text = this.AutoScaleMode.ToString();

        }

    }
}
