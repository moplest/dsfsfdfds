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
        PlayersContainer pc = new PlayersContainer();
        public Player p = null;
        public Login()
        {
            LoginInstance = this;
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            double cash = double.Parse(tbInputMoney.Text);
            p = pc.getPlayerByName(tbUser.Text);
            if (p != null)
            {
                if (p.password == "1234")
                {
                    if (cash >= 100 && cash <= p.cardMoney)
                    {
                        p.cash4play = cash;
                        p.cardMoney -= cash;
                        lblError.Text = "";
                        this.Hide();
                        var ruletkaForm = new Ruletka();
                        ruletkaForm.Show();
                    }
                    else
                    {
                        lblError.Text = "An error has occured! The selected cash4play \namount is ";
                        if (cash < 100)
                        {
                            lblError.Text += "below the minimum!";
                        }
                        else
                        {
                            lblError.Text += "more than the money you have in your card!";
                        }
                    }
                }
            }
            else
            {
                lblError.Text = "Invalid username! Please try again.";
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
