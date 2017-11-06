namespace RULETKA
{
    partial class Login
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbInputMoney = new System.Windows.Forms.TextBox();
            this.lblInputMoney = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(86, 445);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(129, 30);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(57, 488);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(59, 16);
            this.lblError.TabIndex = 1;
            this.lblError.Text = "lblError";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(83, 371);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(61, 13);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Username: ";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(174, 366);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(164, 20);
            this.tbUser.TabIndex = 3;
            this.tbUser.Text = "proben user";
            // 
            // tbInputMoney
            // 
            this.tbInputMoney.Location = new System.Drawing.Point(174, 398);
            this.tbInputMoney.Name = "tbInputMoney";
            this.tbInputMoney.Size = new System.Drawing.Size(163, 20);
            this.tbInputMoney.TabIndex = 4;
            this.tbInputMoney.Text = "100.00";
            // 
            // lblInputMoney
            // 
            this.lblInputMoney.AutoSize = true;
            this.lblInputMoney.Location = new System.Drawing.Point(83, 405);
            this.lblInputMoney.Name = "lblInputMoney";
            this.lblInputMoney.Size = new System.Drawing.Size(63, 13);
            this.lblInputMoney.TabIndex = 5;
            this.lblInputMoney.Text = "Cash4Play: ";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(242, 445);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(96, 30);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::RULETKA.Properties.Resources.green_casino_background_23_2147634151;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(424, 513);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.lblInputMoney);
            this.Controls.Add(this.tbInputMoney);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.LoginButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(440, 552);
            this.MinimumSize = new System.Drawing.Size(440, 552);
            this.Name = "Login";
            this.Text = "Casino Roulette";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbInputMoney;
        private System.Windows.Forms.Label lblInputMoney;
        private System.Windows.Forms.Button ExitButton;
    }
}