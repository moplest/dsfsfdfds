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
    public partial class Ruletka : Form
    {
        private int chipAmount = 1;
        private Login loginForm = Login.LoginInstance;
        private Player player;
        private bool canBetOnNumber = false;
        private bool[] IsItFirstClick = new bool[37];
        private Label[] chipForNumber = new Label[37];
        private Label[] rouletteNumber = new Label[49];
        private Label[] chipForAmount = new Label[6];
        private Label[] lastNumbers = new Label[12];
        private int[] redNumbers = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        private int[] blackNumbers = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
        private int timeLeft = 60;
        private Random random = new Random();
        public Ruletka()
        {
            InitializeComponent();
            player = loginForm.p;
            lblCurrency.Text = loginForm.currency;
            lblPlayerName.Text = player.username;
            lblCurrentCash.Text = player.cash4play.ToString();
            lblBet.Text = "0";
            lblWin.Text = "0";
            lblMaxWin.Text = "0";
            lblLastWin.Text = "0";
            lblLastBet.Text = "0";
            pbRedLine.Width = 0;
            for (int i = 0; i < IsItFirstClick.Length; i++)
            {
                IsItFirstClick[i] = true;
            }
            for (int i = 0; i < chipForNumber.Length; i++)
            {
                chipForNumber[i] = InitializeChipClone(i);
            }
            for (int i = 0; i < rouletteNumber.Length; i++)
            {
                Label lbl = this.Controls.Find("n" + i.ToString(), true).FirstOrDefault() as Label;
                rouletteNumber[i] = lbl;
            }
            for (int i = 0; i < chipForAmount.Length; i++)
            {
                Label lbl = this.Controls.Find("ch" + (i + 1).ToString(), true).FirstOrDefault() as Label;
                chipForAmount[i] = lbl;
            }
            for (int i = 0; i < lastNumbers.Length; i++)
            {       //lwn = last wining number
                Label lbl = this.Controls.Find("lwn" + i.ToString(), true).FirstOrDefault() as Label;
                lastNumbers[i] = lbl;
            }
            addClickEvents();
            tm.Start();
            tmPicture.Start();
        }
        private void bettingSystemLogic(Label lbl)
        {
            if (timeLeft >= 0)
            {
                int counter = 0;
                List<Label> theseNumbers = new List<Label>();
                int lblNo = int.Parse(lbl.Name.Substring(1));
                bool needed = false;
                if (lblNo < 37)
                {
                    needed = false;
                    clickANumber(lbl, lblNo);
                }
                else if (lblNo > 36 && lblNo < 40)
                {
                    needed = true;
                    for (int i = 1; i < 37; i++)
                    {
                        if (lbl.Location.Y == rouletteNumber[i].Location.Y)
                        {
                            counter++;
                            theseNumbers.Add(rouletteNumber[i]);
                        }
                    }
                }
                else
                {
                    needed = true;
                    switch (lblNo)
                    {
                        case 40:
                            {
                                for (int i = 19; i < 37; i++)
                                {
                                    counter++;
                                    theseNumbers.Add(rouletteNumber[i]);
                                }
                            }
                            break;
                        case 41:
                            {
                                for (int i = 1; i < 37; i += 2)
                                {
                                    counter++;
                                    theseNumbers.Add(rouletteNumber[i]);
                                }
                            }
                            break;
                        case 42:
                            {
                                for (int i = 0; i < blackNumbers.Length; i++)
                                {
                                    counter++;
                                    theseNumbers.Add(rouletteNumber[blackNumbers[i]]);
                                }
                            }
                            break;
                        case 43:
                            {
                                for (int i = 0; i < redNumbers.Length; i++)
                                {
                                    counter++;
                                    theseNumbers.Add(rouletteNumber[redNumbers[i]]);
                                }
                            }
                            break;
                        case 44:
                            {
                                for (int i = 2; i < 37; i += 2)
                                {
                                    counter++;
                                    theseNumbers.Add(rouletteNumber[i]);
                                }
                            }
                            break;
                        case 45:
                            {
                                for (int i = 1; i < 19; i++)
                                {
                                    counter++;
                                    theseNumbers.Add(rouletteNumber[i]);
                                }
                            }
                            break;
                        case 46:
                            {
                                for (int i = 1; i < 13; i++)
                                {
                                    counter++;
                                    theseNumbers.Add(rouletteNumber[i]);
                                }
                            }
                            break;
                        case 47:
                            {
                                for (int i = 13; i < 25; i++)
                                {
                                    counter++;
                                    theseNumbers.Add(rouletteNumber[i]);
                                }
                            }
                            break;
                        case 48:
                            {
                                for (int i = 25; i < 37; i++)
                                {
                                    counter++;
                                    theseNumbers.Add(rouletteNumber[i]);
                                }
                            }
                            break;
                    } //end switch
                }            //end else
                if (needed)
                {
                    bool flag = false;
                    int i = 0;
                    while (i < theseNumbers.Count && !flag)
                    {
                        if ((int.Parse(chipForNumber[int.Parse(theseNumbers[i].Name.Substring(1))].Text))
                            + chipAmount > 200)
                        {
                            flag = true;
                        }
                        i++;
                    }
                    if (counter * chipAmount <= player.cash4play && !flag)
                    {                      
                        foreach (var n in theseNumbers)
                        {
                            clickANumber(n, int.Parse(n.Name.Substring(1)));
                        }
                        theseNumbers.Clear();
                        counter = 0;
                    }
                }
                lblMaxWin.Text = calculateMaxWin();
            }
        }
        private void clickANumber(Label lbl, int lblNo)
        {
            chipForNumber[lblNo].Text = bet(chipForNumber[lblNo]).ToString();
            if (IsItFirstClick[lblNo] && canBetOnNumber)
            {
                chipForNumber[lblNo].Visible = true;
                chipForNumber[lblNo].BringToFront();
                chipForNumber[lblNo].Location = putNewChipLocation(chipForNumber[lblNo], lbl);
                IsItFirstClick[lblNo] = false;
            }
            canBetOnNumber = false;
        }
        private int bet(Label lbl)
        {
            int currentBet = int.Parse(lbl.Text);
            int newBet = currentBet;
            int betNow = int.Parse(lblBet.Text);
            if (chipAmount <= player.cash4play && newBet + chipAmount <= 200)
            {
                betNow += chipAmount;
                newBet = currentBet + chipAmount;
                lblBet.Text = betNow.ToString();
                player.cash4play -= chipAmount;
                lblCurrentCash.Text = player.cash4play.ToString();
                canBetOnNumber = true;
            }
            return newBet;
        }
        private string calculateMaxWin()
        {
            int max = 0;
            for (int i = 0; i < chipForNumber.Length; i++)
            {
                int currentBetOnNumber = int.Parse(chipForNumber[i].Text);
                if (currentBetOnNumber > max)
                {
                    max = currentBetOnNumber;
                }
            }
            max *= 36;
            return max.ToString();
        }
        //********************TIMER*********************
        private void tm_Tick(object sender, EventArgs e)
        {
            //timer is set to 60 seconds at start
            if (timeLeft == 60)
            {
                lblText.Text = "Please Place Your Bets !!";
            }
            else if (timeLeft == 20)
            {
                lblText.Text = "Last Bets !";
            }
            else if (timeLeft == -1)
            {
                lblText.Text = "No More Bets";
            }
                        
            if (timeLeft ==5)
            {
                tmRandomNumber.Start();
            }
            if (timeLeft == -5) //show results
            {
                tmRandomNumber.Stop();
                newWiningNumber(lblRollNumber.Text);
                lblWin.Text = calculateWin(int.Parse(lwn0.Text));
                lblText.Text = lwn0.Text + " ";
                if (lwn0.BackColor==Color.Black)
                {
                    lblText.Text += "Black";
                }
                else if (lwn0.BackColor==Color.Red)
                {
                    lblText.Text += "Red";
                }
                else
                {
                    lblText.Text += "Green";
                }
            }
            timeLeft--;
            if (timeLeft== -10) //restart
            {
                restartGame();
            }            
        }
        private void tmRandomNumber_Tick(object sender, EventArgs e)
        {
            int randomNumber = random.Next(0, 36);
            lblRollNumber.Text = randomNumber.ToString();
            fontAndColor(lblRollNumber);
            if (tmRandomNumber.Interval < 500)
            {
                tmRandomNumber.Interval += 10;
            }
            else
            {
                tmRandomNumber.Interval += 100;
            }
        }
        private void newWiningNumber(string number)
        {
            for (int i = lastNumbers.Length - 1; i > 0; i--)
            {
                lastNumbers[i].Text = lastNumbers[i - 1].Text;
                fontAndColor(lastNumbers[i]);
            }
            lastNumbers[0].Text = number;
            fontAndColor(lastNumbers[0]);
        }
        private string calculateWin(int winingNumber)
        {
            int win;
            win = int.Parse(chipForNumber[winingNumber].Text) * 36;
            return win.ToString();
        }
        private void restartGame()
        {
            player.cash4play += int.Parse(lblWin.Text);
            lblCurrentCash.Text = player.cash4play.ToString();
            lblLastWin.Text = lblWin.Text;
            lblWin.Text = "0";
            lblLastBet.Text = lblBet.Text;
            lblRollNumber.Text = "";
            lblRollNumber.BackColor = Color.Black;
            timeLeft = 60;
            pbRedLine.Width = 0;
            tmPicture.Start();
            removeAllChips(false);
        }
        public Label InitializeChipClone(int number)
        {
            Label pb = new Label();
            // emptyChipPicture
            pb.BackColor = System.Drawing.Color.Transparent;
            pb.BackgroundImage = global::RULETKA.Properties.Resources.goodChip;
            pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pb.Size = new System.Drawing.Size(44, 44);
            pb.Location = new Point(0, 0);
            pb.Name = "ECP" + number.ToString();
            pb.Text = "0";
            pb.TextAlign = ContentAlignment.MiddleCenter;
            pb.TabIndex = 2;
            pb.TabStop = false;
            this.Controls.Add(pb);
            pb.Visible = false;
            return pb;
        }
        private Point putNewChipLocation(Label chip, Label lbl)
        {
            Point pnt = new System.Drawing.Point(
              (lbl.Location.X + (lbl.Width / 2) - (chip.Width / 2)),
              (lbl.Location.Y + (lbl.Height / 2) - (chip.Width / 2)));
            return pnt;
        }
        private void removeAllChips(bool returnMoney)
        {
            int cash4return = 0;                
            foreach (var c in chipForNumber)
            {
                if (returnMoney)
                {
                    cash4return += int.Parse(c.Text);
                }
                c.Text = "0";
                c.Visible = false;
            }
            for (int i = 0; i < IsItFirstClick.Length; i++)
            {
                IsItFirstClick[i] = true;
            }
            player.cash4play += cash4return;
            lblCurrentCash.Text = player.cash4play.ToString();
            lblMaxWin.Text = "0";
            lblBet.Text = "0";
        }
        private void fontAndColor(Label lbl)
        {
            if (lbl.Text != "")
            {
                if (int.Parse(lbl.Text) == 0)
                {
                    lbl.BackColor = Color.Green;
                    lbl.ForeColor = Color.White;
                    return;
                }
                bool blackFlag = false;
                int i = 0;
                while (i < blackNumbers.Length && !blackFlag)
                {
                    if (blackNumbers[i] == int.Parse(lbl.Text))
                    {
                        blackFlag = true;
                    }
                    i++;
                }
                if (blackFlag)
                {
                    lbl.BackColor = Color.Black;
                    lbl.ForeColor = Color.White;
                }
                else
                {
                    lbl.BackColor = Color.Red;
                    lbl.ForeColor = Color.Black;
                }
            }
        }
        private void clickAChipForAmount(Label lbl)
        {
            int lblNo = int.Parse(lbl.Name.Substring(2));
            lblChosenOne.Location = lbl.Location;
            switch (lblNo)
            {
                case 1:
                    {
                        lblChosenOne.Text = "1";
                        chipAmount = 1;
                    }
                    break;
                case 2:
                    {
                        lblChosenOne.Text = "2";
                        chipAmount = 2;
                    }
                    break;
                case 3:
                    {
                        lblChosenOne.Text = "5";
                        chipAmount = 5;
                    }
                    break;
                case 4:
                    {
                        lblChosenOne.Text = "10";
                        chipAmount = 10;
                    }
                    break;
                case 5:
                    {
                        lblChosenOne.Text = "20";
                        chipAmount = 20;
                    }
                    break;
                case 6:
                    {
                        lblChosenOne.Text = "50";
                        chipAmount = 50;
                    }
                    break;
            }
        }
        private void tmPicture_Tick(object sender, EventArgs e)
        {
            if (pbRedLine.Width == 329)
            {
                tmPicture.Stop();
            }
            pbRedLine.Width++;
        }
        private void goToLoginForm()
        {
            Login.LoginInstance.Show();
            player.cardMoney += player.cash4play;
            this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {//метод при който при натискане на "Х" 
         //освен че затваря прозореца, ни отваря обратно логин формата
            if (e.CloseReason == CloseReason.WindowsShutDown
                || e.CloseReason == CloseReason.ApplicationExitCall
                || e.CloseReason == CloseReason.TaskManagerClosing)
            {
                return;
            }
            Login.LoginInstance.Show();
            player.cardMoney += player.cash4play;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            goToLoginForm();
        }
        private void lblTestRestart_Click(object sender, EventArgs e)
        {
            restartGame();
        }
        private void lblCancelBet_Click(object sender, EventArgs e)
        {
            removeAllChips(true);
        }
        private void n0_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n0);
        }
        private void n1_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n1);
        }
        private void n2_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n2);
        }
        private void n3_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n3);
        }
        private void n4_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n4);
        }
        private void n5_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n5);
        }
        private void n6_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n6);
        }
        private void n7_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n7);
        }
        private void n8_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n8);
        }
        private void n9_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n9);
        }
        private void n10_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n10);
        }
        private void n11_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n11);
        }
        private void n12_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n12);
        }
        private void n13_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n13);
        }
        private void n14_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n14);
        }
        private void n15_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n15);
        }
        private void n16_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n16);
        }
        private void n17_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n17);
        }
        private void n18_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n18);
        }
        private void n19_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n19);
        }
        private void n20_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n20);
        }
        private void n21_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n21);
        }
        private void n22_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n22);
        }
        private void n23_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n23);
        }
        private void n24_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n24);
        }
        private void n25_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n25);
        }
        private void n26_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n26);
        }
        private void n27_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n27);
        }
        private void n28_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n28);
        }
        private void n29_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n29);
        }
        private void n30_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n30);
        }
        private void n31_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n31);
        }
        private void n32_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n32);
        }
        private void n33_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n33);
        }
        private void n34_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n34);
        }
        private void n35_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n35);
        }
        private void n36_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n36);
        }
        private void n37_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n37);
        }
        private void n38_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n38);
        }
        private void n39_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n39);
        }
        private void n40_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n40);
        }
        private void n41_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n41);
        }
        private void n42_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n42);
        }
        private void n43_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n43);
        }
        private void n44_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n44);
        }
        private void n45_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n45);
        }
        private void n46_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n46);
        }
        private void n47_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n47);
        }
        private void n48_Click(object sender, EventArgs e)
        {
            bettingSystemLogic(n48);
        }
        private void ch1_Click(object sender, EventArgs e)
        {
            clickAChipForAmount(ch1);
        }
        private void ch2_Click(object sender, EventArgs e)
        {
            clickAChipForAmount(ch2);
        }
        private void ch3_Click(object sender, EventArgs e)
        {
            clickAChipForAmount(ch3);
        }
        private void ch4_Click(object sender, EventArgs e)
        {
            clickAChipForAmount(ch4);
        }
        private void ch5_Click(object sender, EventArgs e)
        {
            clickAChipForAmount(ch5);
        }
        private void ch6_Click(object sender, EventArgs e)
        {
            clickAChipForAmount(ch6);
        }
        private void Ruletka_Load(object sender, EventArgs e)
        {

        }
        private void addClickEvents()
        {
            chipForNumber[0].Click += n0_Click;
            chipForNumber[1].Click += n1_Click;
            chipForNumber[2].Click += n2_Click;
            chipForNumber[3].Click += n3_Click;
            chipForNumber[4].Click += n4_Click;
            chipForNumber[5].Click += n5_Click;
            chipForNumber[6].Click += n6_Click;
            chipForNumber[7].Click += n7_Click;
            chipForNumber[8].Click += n8_Click;
            chipForNumber[9].Click += n9_Click;
            chipForNumber[10].Click += n10_Click;
            chipForNumber[11].Click += n11_Click;
            chipForNumber[12].Click += n12_Click;
            chipForNumber[13].Click += n13_Click;
            chipForNumber[14].Click += n14_Click;
            chipForNumber[15].Click += n15_Click;
            chipForNumber[16].Click += n16_Click;
            chipForNumber[17].Click += n17_Click;
            chipForNumber[18].Click += n18_Click;
            chipForNumber[19].Click += n19_Click;
            chipForNumber[20].Click += n20_Click;
            chipForNumber[21].Click += n21_Click;
            chipForNumber[22].Click += n22_Click;
            chipForNumber[23].Click += n23_Click;
            chipForNumber[24].Click += n24_Click;
            chipForNumber[25].Click += n25_Click;
            chipForNumber[26].Click += n26_Click;
            chipForNumber[27].Click += n27_Click;
            chipForNumber[28].Click += n28_Click;
            chipForNumber[29].Click += n29_Click;
            chipForNumber[30].Click += n30_Click;
            chipForNumber[31].Click += n31_Click;
            chipForNumber[32].Click += n32_Click;
            chipForNumber[33].Click += n33_Click;
            chipForNumber[34].Click += n34_Click;
            chipForNumber[35].Click += n35_Click;
            chipForNumber[36].Click += n36_Click;
        }
    }
}