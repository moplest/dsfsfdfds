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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.cbCurrancy = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(86, 553);
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
            this.lblError.Font = new System.Drawing.Font("Cooper Black", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(53, 608);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(65, 15);
            this.lblError.TabIndex = 1;
            this.lblError.Text = "lblError";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(81, 441);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(61, 13);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Username: ";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(164, 434);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(164, 20);
            this.tbUser.TabIndex = 3;
            this.tbUser.Text = "proben user";
            // 
            // tbInputMoney
            // 
            this.tbInputMoney.Location = new System.Drawing.Point(164, 520);
            this.tbInputMoney.Name = "tbInputMoney";
            this.tbInputMoney.Size = new System.Drawing.Size(163, 20);
            this.tbInputMoney.TabIndex = 4;
            this.tbInputMoney.Text = "100";
            this.tbInputMoney.TextChanged += new System.EventHandler(this.tbInputMoney_TextChanged);
            // 
            // lblInputMoney
            // 
            this.lblInputMoney.AutoSize = true;
            this.lblInputMoney.Location = new System.Drawing.Point(81, 527);
            this.lblInputMoney.Name = "lblInputMoney";
            this.lblInputMoney.Size = new System.Drawing.Size(63, 13);
            this.lblInputMoney.TabIndex = 5;
            this.lblInputMoney.Text = "Cash4Play: ";
            // 
            // ExitButton
            // 
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Location = new System.Drawing.Point(233, 553);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(96, 30);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 470);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Currency: ";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(163, 463);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(164, 20);
            this.tbPassword.TabIndex = 10;
            // 
            // cbCurrancy
            // 
            this.cbCurrancy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrancy.FormattingEnabled = true;
            this.cbCurrancy.Items.AddRange(new object[] {
            "BGN",
            "EUR",
            "USD",
            "RUB",
            "CZK",
            "TRY"});
            this.cbCurrancy.Location = new System.Drawing.Point(163, 492);
            this.cbCurrancy.Name = "cbCurrancy";
            this.cbCurrancy.Size = new System.Drawing.Size(163, 21);
            this.cbCurrancy.TabIndex = 11;
            // 
            // Login
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::RULETKA.Properties.Resources.green_casino_background_23_21476341511;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(424, 681);
            this.Controls.Add(this.cbCurrancy);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.lblInputMoney);
            this.Controls.Add(this.tbInputMoney);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.LoginButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(440, 720);
            this.MinimumSize = new System.Drawing.Size(440, 720);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCurrancy;
        public System.Windows.Forms.TextBox tbPassword;
    }
}