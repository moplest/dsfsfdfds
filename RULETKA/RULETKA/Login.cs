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
        public string currency;
        public Login()
        {
            LoginInstance = this;        
            InitializeComponent();
            tbPassword.Text = "";
            tbPassword.PasswordChar = '*';
            tbPassword.MaxLength = 10;
            lblError.Text = "";
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            p = pc.getPlayerByName(tbUser.Text);
            currency = cbCurrancy.Text;
            if (p != null)
            {
                if (p.password == tbPassword.Text)
                {
                    if (currency != "")
                    {
                        int cash;
                        if (tbInputMoney.Text != "")
                        {
                            cash = int.Parse(tbInputMoney.Text);
                        }
                        else
                        {
                            lblError.Text = "An error has occured! Please select valid \ncash4play amount!";
                            return;
                        }
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
                                lblError.Text += "more than the money you have \nin your card!";
                            }
                        }
                    }
                   else  lblError.Text = "Please select currency ! ";
                }
                    else
                    {
                        lblError.Text = "Wrong password please try again !";
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

        private void tbInputMoney_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(tbInputMoney.Text, out parsedValue))
            {
                lblError.Text = "Please enter numbers only!";
                tbInputMoney.Text = "";
            }
            else
            {
                lblError.Text = "";
            }
        }
    }
}