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
        private bool[] IsItFirstClick = new bool[50];
        private Label[] chipForNumber = new Label[50];
        private Label[] rouletteNumber = new Label[50];
        public Ruletka()
        {
            InitializeComponent();
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
                chipForNumber[lblNo].Text = chipAmount.ToString();
                chipForNumber[lblNo].Location = putNewChipLocation(chipForNumber[lblNo], lbl);
                IsItFirstClick[lblNo] = false;
            }
            else
            {
                chipForNumber[lblNo].Text = bet(chipForNumber[lblNo]).ToString();
            }
        }
        private double bet(Label lbl)
        {
            double currentBet = double.Parse(lbl.Text);
            double newBet = currentBet + chipAmount;
            return newBet;
        }
        private void n0_Click(object sender, EventArgs e)
        {
            clickANumber(n0);
            chipForNumber[0].Click += n0_Click;
        }

        private void n1_Click(object sender, EventArgs e)
        {
            clickANumber(n1);
            chipForNumber[1].Click += n1_Click;
        }

        private void n2_Click(object sender, EventArgs e)
        {
            clickANumber(n2);
            chipForNumber[2].Click += n2_Click;
        }

        private void n3_Click(object sender, EventArgs e)
        {
            clickANumber(n3);
            chipForNumber[3].Click += n3_Click;
        }

        private void n4_Click(object sender, EventArgs e)
        {
            clickANumber(n4);
            chipForNumber[4].Click += n4_Click;
        }

        private void n5_Click(object sender, EventArgs e)
        {
            clickANumber(n5);
            chipForNumber[5].Click += n5_Click;
        }

        private void n6_Click(object sender, EventArgs e)
        {
            clickANumber(n6);
            chipForNumber[6].Click += n6_Click;
        }

        private void n7_Click(object sender, EventArgs e)
        {
            clickANumber(n7);
            chipForNumber[7].Click += n7_Click;
        }

        private void n8_Click(object sender, EventArgs e)
        {
            clickANumber(n8);
            chipForNumber[8].Click += n8_Click;
        }

        private void n9_Click(object sender, EventArgs e)
        {
            clickANumber(n9);
            chipForNumber[9].Click += n9_Click;
        }

        private void n10_Click(object sender, EventArgs e)
        {
            clickANumber(n10);
            chipForNumber[10].Click += n10_Click;
        }

        private void n11_Click(object sender, EventArgs e)
        {
            clickANumber(n11);
            chipForNumber[11].Click += n11_Click;
        }

        private void n12_Click(object sender, EventArgs e)
        {
            clickANumber(n12);
            chipForNumber[12].Click += n12_Click;
        }

        private void n13_Click(object sender, EventArgs e)
        {
            clickANumber(n13);
            chipForNumber[13].Click += n13_Click;
        }

        private void n37_Click(object sender, EventArgs e)
        {
            clickANumber(n37);
            chipForNumber[37].Click += n37_Click;
        }
    }
}
