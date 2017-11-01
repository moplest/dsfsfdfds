namespace RULETKA
{
    partial class Ruletka
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExit = new System.Windows.Forms.Label();
            this.n1 = new System.Windows.Forms.Label();
            this.emptyChipPicture = new System.Windows.Forms.Label();
            this.n2 = new System.Windows.Forms.Label();
            this.n0 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Location = new System.Drawing.Point(12, 382);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 46);
            this.btnExit.TabIndex = 0;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // n1
            // 
            this.n1.BackColor = System.Drawing.Color.Transparent;
            this.n1.Location = new System.Drawing.Point(268, 540);
            this.n1.Name = "n1";
            this.n1.Size = new System.Drawing.Size(74, 67);
            this.n1.TabIndex = 1;
            this.n1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.n1.Click += new System.EventHandler(this.n1_Click);
            // 
            // emptyChipPicture
            // 
            this.emptyChipPicture.BackColor = System.Drawing.Color.Transparent;
            this.emptyChipPicture.Image = global::RULETKA.Properties.Resources.goodChip2;
            this.emptyChipPicture.Location = new System.Drawing.Point(99, 520);
            this.emptyChipPicture.Name = "emptyChipPicture";
            this.emptyChipPicture.Size = new System.Drawing.Size(109, 76);
            this.emptyChipPicture.TabIndex = 2;
            // 
            // n2
            // 
            this.n2.BackColor = System.Drawing.Color.Transparent;
            this.n2.Location = new System.Drawing.Point(268, 471);
            this.n2.Name = "n2";
            this.n2.Size = new System.Drawing.Size(74, 67);
            this.n2.TabIndex = 3;
            this.n2.Click += new System.EventHandler(this.n2_Click);
            // 
            // n0
            // 
            this.n0.BackColor = System.Drawing.Color.Transparent;
            this.n0.Location = new System.Drawing.Point(194, 403);
            this.n0.Name = "n0";
            this.n0.Size = new System.Drawing.Size(77, 203);
            this.n0.TabIndex = 4;
            this.n0.Click += new System.EventHandler(this.n0_Click);
            // 
            // Ruletka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::RULETKA.Properties.Resources.RULETKATA;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.n0);
            this.Controls.Add(this.n2);
            this.Controls.Add(this.emptyChipPicture);
            this.Controls.Add(this.n1);
            this.Controls.Add(this.btnExit);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Ruletka";
            this.Text = "Casino Roulette";
            this.Load += new System.EventHandler(this.Ruletka_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label btnExit;
        private System.Windows.Forms.Label n1;
        private System.Windows.Forms.Label emptyChipPicture;
        private System.Windows.Forms.Label n2;
        private System.Windows.Forms.Label n0;
    }
}

