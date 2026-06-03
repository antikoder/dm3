namespace WindowsFormsApp.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.loginLabel = new System.Windows.Forms.Label();
            this._loginBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this._passwordBox = new System.Windows.Forms.TextBox();
            this._loginButton = new System.Windows.Forms.Button();
            this._guestButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(20, 25);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Text = "Логин:";

            this._loginBox.Location = new System.Drawing.Point(120, 22);
            this._loginBox.Name = "_loginBox";
            this._loginBox.Size = new System.Drawing.Size(200, 27);

            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(20, 65);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Text = "Пароль:";

            this._passwordBox.Location = new System.Drawing.Point(120, 62);
            this._passwordBox.Name = "_passwordBox";
            this._passwordBox.Size = new System.Drawing.Size(200, 27);
            this._passwordBox.UseSystemPasswordChar = true;

            this._loginButton.Location = new System.Drawing.Point(20, 110);
            this._loginButton.Name = "_loginButton";
            this._loginButton.Size = new System.Drawing.Size(140, 35);
            this._loginButton.Text = "Войти";
            this._loginButton.UseVisualStyleBackColor = true;
            this._loginButton.Click += new System.EventHandler(this.LoginButton_Click);

            this._guestButton.Location = new System.Drawing.Point(180, 110);
            this._guestButton.Name = "_guestButton";
            this._guestButton.Size = new System.Drawing.Size(140, 35);
            this._guestButton.Text = "Гость";
            this._guestButton.UseVisualStyleBackColor = true;
            this._guestButton.Click += new System.EventHandler(this.GuestButton_Click);

            this.AcceptButton = this._loginButton;
            this.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.ClientSize = new System.Drawing.Size(340, 165);
            this.Controls.Add(this._guestButton);
            this.Controls.Add(this._loginButton);
            this.Controls.Add(this._passwordBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this._loginBox);
            this.Controls.Add(this.loginLabel);
            this.Name = "LoginForm";
            this.Text = "Вход";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox _loginBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox _passwordBox;
        private System.Windows.Forms.Button _loginButton;
        private System.Windows.Forms.Button _guestButton;
    }
}
