using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RULETKA
{
    public partial class Login : Form
    {
        public static Login LoginInstance;
        public Login()
        {
            LoginInstance = this;
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            double cash = double.Parse(tbInputMoney.Text);
            string[] usernames = { "probenUser", "Kalevinho", "eBacho" };
            bool flag = false;
            for (int i = 0; i < usernames.Length; i++)
            {
                if (tbUser.Text==usernames[i])
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                if (cash>=100)
                {
                    this.Hide();
                    var ruletkaForm = new Ruletka();
                    ruletkaForm.Show();
                }
                else
                {
                    lblError.Text = "Malko para si vkaral. Dai poe4e. ;)";
                }
            }
            else
            {
                lblError.Text = "Invalid username! Please try again.";
            }
        }
    }
}
