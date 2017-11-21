using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace RULETKA
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            lblLink.BringToFront();
            lblLink.Text = "https://www.wikihow.com/Play-Roulette";
            lblInfo.Text = "For more detailed information, please visit the following site:";
            lblAboutUs.Text = "________________________________" +
                "\n RULETKA ver 1.0";
        }
        private void HelpForm_Load(object sender, EventArgs e)
        {

        }
        private void lblInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://www.wikihow.com/Play-Roulette");
            Process.Start(sInfo);
        }
    }
}