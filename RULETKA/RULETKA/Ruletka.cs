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
        public Ruletka()
        {
            InitializeComponent();
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
        public Label GetChipClone(Label lbl)
        {
            Label pb = new Label();
            // emptyChipPicture
            pb.BackColor = System.Drawing.Color.Transparent;
            pb.BackgroundImage = global::RULETKA.Properties.Resources.goodChip;
            pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pb.Size = new System.Drawing.Size(44, 44);
            pb.Location = putNewChipLocation(pb, lbl);
            pb.Name = "emptyChipPicture2";
            pb.TextAlign = ContentAlignment.MiddleCenter;
            pb.Text = "1";
            pb.TabIndex = 2;
            pb.TabStop = false;
            this.Controls.Add(pb);
            pb.BringToFront();
            return pb;
        }
        private Point putNewChipLocation(Label chip, Label lbl)
        {
            Point pnt = new System.Drawing.Point(
                (lbl.Location.X + (lbl.Width / 2) - (chip.Width / 2)),
                (lbl.Location.Y + (lbl.Height / 2) - (chip.Width / 2)));
            return pnt;
        }
        private void n0_Click(object sender, EventArgs e)
        {
            Label newPB = GetChipClone(n0);
        }

        private void n1_Click(object sender, EventArgs e)
        {
            Label newPB = GetChipClone(n1);
        }

        private void n2_Click(object sender, EventArgs e)
        {
            Label newPB = GetChipClone(n2);
        }

        private void n3_Click(object sender, EventArgs e)
        {
            Label newPB = GetChipClone(n3);
        }

        private void n4_Click(object sender, EventArgs e)
        {
            Label newPB = GetChipClone(n4);
        }

        private void n5_Click(object sender, EventArgs e)
        {
            Label newPB = GetChipClone(n5);
        }

        private void n6_Click(object sender, EventArgs e)
        {
            Label newPB = GetChipClone(n6);
        }

        private void n7_Click(object sender, EventArgs e)
        {
            Label newPB = GetChipClone(n7);
        }

        private void n8_Click(object sender, EventArgs e)
        {
            Label newPB = GetChipClone(n8);
        }

        private void n9_Click(object sender, EventArgs e)
        {
            Label newPB = GetChipClone(n9);
        }

        private void n10_Click(object sender, EventArgs e)
        {
            Label newPB = GetChipClone(n10);
        }

        private void n11_Click(object sender, EventArgs e)
        {
            Label newPB = GetChipClone(n11);
        }

        private void n12_Click(object sender, EventArgs e)
        {
            Label newPB = GetChipClone(n12);
        }

        private void n13_Click(object sender, EventArgs e)
        {
            Label newPB = GetChipClone(n13);
        }

        private void r1_Click(object sender, EventArgs e)
        {

        }
    }
}
