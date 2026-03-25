namespace RecruitmentCVScreening.WinForms.UI.Forms
{
    partial class LoginForm
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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            button2 = new Button();
            groupBox1 = new GroupBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.BackColor = SystemColors.HighlightText;
            txtUsername.Location = new Point(74, 203);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(266, 46);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.HighlightText;
            txtPassword.Location = new Point(74, 280);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(266, 38);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.RoyalBlue;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.HighlightText;
            btnLogin.Location = new Point(74, 345);
            btnLogin.Margin = new Padding(4, 5, 4, 5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(219, 50);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += button1_Click;
            btnLogin.Paint += btnLogin_Paint;
            btnLogin.MouseEnter += button1_MouseEnter;
            btnLogin.MouseLeave += button1_MouseLeave;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.HighlightText;
            button2.Location = new Point(133, 405);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(97, 57);
            button2.TabIndex = 5;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            button2.Paint += button2_Paint;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.InactiveBorder;
            groupBox1.Controls.Add(pictureBox3);
            groupBox1.Controls.Add(pictureBox2);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Location = new Point(328, 97);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(397, 493);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.pass;
            pictureBox3.Location = new Point(9, 280);
            pictureBox3.Margin = new Padding(4, 5, 4, 5);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(41, 38);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.user2;
            pictureBox2.Location = new Point(9, 203);
            pictureBox2.Margin = new Padding(4, 5, 4, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(41, 38);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._65fec143c1e52ce63a34faf852bbb0e0;
            pictureBox1.Location = new Point(117, 18);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(174, 175);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            BackgroundImage = Properties.Resources.background2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1060, 673);
            Controls.Add(groupBox1);
            ForeColor = SystemColors.Desktop;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 5, 4, 5);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập Hệ Thống";
            Load += LoginForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button button2;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
    }
}