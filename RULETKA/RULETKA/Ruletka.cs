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
        private double chipAmount = 1;
        private Login loginForm = Login.LoginInstance;
        private Player player;
        private bool[] IsItFirstClick = new bool[49];
        private Label[] chipForNumber = new Label[49];
        private Label[] rouletteNumber = new Label[49];
        private Label[] chipForAmount = new Label[6];
        public Ruletka()
        {
            InitializeComponent();
            lblBet.Text = "0";
            player = loginForm.p;
            lblPlayerName.Text = player.username;
            lblCurrentCash.Text = player.cash4play.ToString();       
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
            addClickEvents();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
              goToLoginForm();
        }

        private void Ruletka_Load(object sender, EventArgs e)
        {

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
            //pb.BringToFront();
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
        private void clickANumber(Label lbl)
        {
            int lblNo = int.Parse(lbl.Name.Substring(1));
            if (IsItFirstClick[lblNo])
            {
                chipForNumber[lblNo].Visible = true;
                chipForNumber[lblNo].BringToFront();               
                chipForNumber[lblNo].Location = putNewChipLocation(chipForNumber[lblNo], lbl);
                IsItFirstClick[lblNo] = false;
            }            
            
                chipForNumber[lblNo].Text = bet(chipForNumber[lblNo]).ToString();          
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
        private double bet(Label lbl)
        {
            double currentCash = double.Parse(lblCurrentCash.Text);
            double currentBet = double.Parse(lbl.Text);
            double newBet = currentBet;
            double betNow = double.Parse(lblBet.Text);                          
            if (chipAmount <= currentCash)
            {
              betNow += chipAmount;
              newBet = currentBet + chipAmount;
              lblBet.Text = betNow.ToString();
              currentCash -= chipAmount;
              lblCurrentCash.Text = currentCash.ToString();                  
            }      
            return newBet;                 
        }
        //********************TIMER*********************
        private void tm_Tick(object sender, EventArgs e)
        {

        }
        private void n0_Click(object sender, EventArgs e)
        {
            clickANumber(n0);
        }
        private void n1_Click(object sender, EventArgs e)
        {
            clickANumber(n1);            
        }
        private void n2_Click(object sender, EventArgs e)
        {
            clickANumber(n2);
        }
        private void n3_Click(object sender, EventArgs e)
        {
            clickANumber(n3);
        }
        private void n4_Click(object sender, EventArgs e)
        {
            clickANumber(n4);
        }
        private void n5_Click(object sender, EventArgs e)
        {
            clickANumber(n5);
        }
        private void n6_Click(object sender, EventArgs e)
        {
            clickANumber(n6);
        }
        private void n7_Click(object sender, EventArgs e)
        {
            clickANumber(n7);
        }
        private void n8_Click(object sender, EventArgs e)
        {
            clickANumber(n8);
        }
        private void n9_Click(object sender, EventArgs e)
        {
            clickANumber(n9);
        }
        private void n10_Click(object sender, EventArgs e)
        {
            clickANumber(n10);
        }
        private void n11_Click(object sender, EventArgs e)
        {
            clickANumber(n11);
        }
        private void n12_Click(object sender, EventArgs e)
        {
            clickANumber(n12);
        }
        private void n13_Click(object sender, EventArgs e)
        {
            clickANumber(n13);
        }
        private void n14_Click(object sender, EventArgs e)
        {
            clickANumber(n14);
        }
        private void n15_Click(object sender, EventArgs e)
        {
            clickANumber(n15);
        }
        private void n16_Click(object sender, EventArgs e)
        {
            clickANumber(n16);
        }
        private void n17_Click(object sender, EventArgs e)
        {
            clickANumber(n17);
        }
        private void n18_Click(object sender, EventArgs e)
        {
            clickANumber(n18);
        }
        private void n19_Click(object sender, EventArgs e)
        {
            clickANumber(n19);
        }
        private void n20_Click(object sender, EventArgs e)
        {
            clickANumber(n20);
        }
        private void n21_Click(object sender, EventArgs e)
        {
            clickANumber(n21);
        }
        private void n22_Click(object sender, EventArgs e)
        {
            clickANumber(n22);
        }
        private void n23_Click(object sender, EventArgs e)
        {
            clickANumber(n23);
        }
        private void n24_Click(object sender, EventArgs e)
        {
            clickANumber(n24);
        }
        private void n25_Click(object sender, EventArgs e)
        {
            clickANumber(n25);
        }
        private void n26_Click(object sender, EventArgs e)
        {
            clickANumber(n26);
        }
        private void n27_Click(object sender, EventArgs e)
        {
            clickANumber(n27);
        }
        private void n28_Click(object sender, EventArgs e)
        {
            clickANumber(n28);
        }
        private void n29_Click(object sender, EventArgs e)
        {
            clickANumber(n29);
        }
        private void n30_Click(object sender, EventArgs e)
        {
            clickANumber(n30);
        }
        private void n31_Click(object sender, EventArgs e)
        {
            clickANumber(n31);
        }
        private void n32_Click(object sender, EventArgs e)
        {
            clickANumber(n32);
        }
        private void n33_Click(object sender, EventArgs e)
        {
            clickANumber(n33);
        }
        private void n34_Click(object sender, EventArgs e)
        {
            clickANumber(n34);
        }
        private void n35_Click(object sender, EventArgs e)
        {
            clickANumber(n35);
        }
        private void n36_Click(object sender, EventArgs e)
        {
            clickANumber(n36);
        }
        private void n37_Click(object sender, EventArgs e)
        {
            clickANumber(n37);
        }
        private void n38_Click(object sender, EventArgs e)
        {
            clickANumber(n38);
        }
        private void n39_Click(object sender, EventArgs e)
        {
            clickANumber(n39);
        }
        private void n40_Click(object sender, EventArgs e)
        {
            clickANumber(n40);
        }
        private void n41_Click(object sender, EventArgs e)
        {
            clickANumber(n41);
        }
        private void n42_Click(object sender, EventArgs e)
        {
            clickANumber(n42);
        }
        private void n43_Click(object sender, EventArgs e)
        {
            clickANumber(n43);
        }
        private void n44_Click(object sender, EventArgs e)
        {
            clickANumber(n44);
        }
        private void n45_Click(object sender, EventArgs e)
        {
            clickANumber(n45);
        }
        private void n46_Click(object sender, EventArgs e)
        {
            clickANumber(n46);
        }
        private void n47_Click(object sender, EventArgs e)
        {
            clickANumber(n47);
        }
        private void n48_Click(object sender, EventArgs e)
        {
            clickANumber(n48);
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
            chipForNumber[37].Click += n37_Click;
            chipForNumber[38].Click += n38_Click;
            chipForNumber[39].Click += n39_Click;
            chipForNumber[40].Click += n40_Click;
            chipForNumber[41].Click += n41_Click;
            chipForNumber[42].Click += n42_Click;
            chipForNumber[43].Click += n43_Click;
            chipForNumber[44].Click += n44_Click;
            chipForNumber[45].Click += n45_Click;
            chipForNumber[46].Click += n46_Click;
            chipForNumber[47].Click += n47_Click;
            chipForNumber[48].Click += n48_Click;
        }
    }
}
