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
            pb.Location = lbl.Location;
            pb.Name = "emptyChipPicture2";
            pb.Size = new System.Drawing.Size(44, 44);
            pb.TabIndex = 2;
            pb.TabStop = false;
            return pb;
        }
        private void putNewChip(Label lbl, int chipNumber)
        {
            emptyChipPicture.Location = new System.Drawing.Point(
                (lbl.Location.X + (lbl.Width / 2) - (emptyChipPicture.Width / 2)),
                (lbl.Location.Y + (lbl.Height / 2) - (emptyChipPicture.Width / 2)));
        }

        private void n1_Click(object sender, EventArgs e)
        {
             putNewChip(n1, 1);
            Label newPB = GetChipClone(n1);
            this.Controls.Add(newPB);
            newPB.BringToFront();
        }
        private void n2_Click(object sender, EventArgs e)
        {
            putNewChip(n2, 1);
            Label newPB = GetChipClone(n2);
            this.Controls.Add(newPB);
            newPB.BringToFront();
        }

        private void n0_Click(object sender, EventArgs e)
        {
            putNewChip(n0, 1);
            Label newPB = GetChipClone(n0);
            this.Controls.Add(newPB);
            newPB.BringToFront();
        }
        //Метод който изключва бутона "Х" на WinForm-ата
        //private const int CP_NOCLOSE_BUTTON = 0x200;  
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams myCp = base.CreateParams;
        //        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        //        return myCp;
        //    }
        //}
    }
}
