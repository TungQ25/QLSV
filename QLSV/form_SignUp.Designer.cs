namespace QLSV
{
    partial class Sign_up
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
            this.panel_signUp = new QLSV.RoundedPanel();
            this.link_SignIn = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.rePassword = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.SignUp = new System.Windows.Forms.Button();
            this.textBox_re_password = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.panel_signUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_signUp
            // 
            this.panel_signUp.AutoScroll = true;
            this.panel_signUp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_signUp.BorderColor = System.Drawing.Color.Gray;
            this.panel_signUp.BorderRadius = 30;
            this.panel_signUp.BorderSize = 0;
            this.panel_signUp.Controls.Add(this.link_SignIn);
            this.panel_signUp.Controls.Add(this.label2);
            this.panel_signUp.Controls.Add(this.rePassword);
            this.panel_signUp.Controls.Add(this.password);
            this.panel_signUp.Controls.Add(this.label1);
            this.panel_signUp.Controls.Add(this.username);
            this.panel_signUp.Controls.Add(this.SignUp);
            this.panel_signUp.Controls.Add(this.textBox_re_password);
            this.panel_signUp.Controls.Add(this.textBox_password);
            this.panel_signUp.Controls.Add(this.textBox_username);
            this.panel_signUp.ForeColor = System.Drawing.Color.Black;
            this.panel_signUp.Location = new System.Drawing.Point(180, 40);
            this.panel_signUp.Name = "panel_signUp";
            this.panel_signUp.Size = new System.Drawing.Size(353, 469);
            this.panel_signUp.TabIndex = 0;
            this.panel_signUp.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // link_SignIn
            // 
            this.link_SignIn.AutoSize = true;
            this.link_SignIn.Location = new System.Drawing.Point(189, 370);
            this.link_SignIn.Name = "link_SignIn";
            this.link_SignIn.Size = new System.Drawing.Size(60, 13);
            this.link_SignIn.TabIndex = 3;
            this.link_SignIn.TabStop = true;
            this.link_SignIn.Text = "Đăng nhập";
            this.link_SignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đã có tài khoản? ";
            this.label2.Click += new System.EventHandler(this.label3_Click);
            // 
            // rePassword
            // 
            this.rePassword.AutoSize = true;
            this.rePassword.Location = new System.Drawing.Point(55, 257);
            this.rePassword.Name = "rePassword";
            this.rePassword.Size = new System.Drawing.Size(93, 13);
            this.rePassword.TabIndex = 2;
            this.rePassword.Text = "Nhập lại mật khẩu";
            this.rePassword.Click += new System.EventHandler(this.label3_Click);
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(55, 188);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(52, 13);
            this.password.TabIndex = 2;
            this.password.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đăng ký";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(55, 116);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(68, 13);
            this.username.TabIndex = 2;
            this.username.Text = "Tên đăng ký";
            this.username.Click += new System.EventHandler(this.label1_Click);
            // 
            // SignUp
            // 
            this.SignUp.Location = new System.Drawing.Point(93, 327);
            this.SignUp.Name = "SignUp";
            this.SignUp.Size = new System.Drawing.Size(161, 40);
            this.SignUp.TabIndex = 1;
            this.SignUp.Text = "Đăng ký";
            this.SignUp.UseVisualStyleBackColor = true;
            this.SignUp.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_re_password
            // 
            this.textBox_re_password.Location = new System.Drawing.Point(55, 273);
            this.textBox_re_password.Name = "textBox_re_password";
            this.textBox_re_password.Size = new System.Drawing.Size(237, 20);
            this.textBox_re_password.TabIndex = 0;
            this.textBox_re_password.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(55, 204);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(237, 20);
            this.textBox_password.TabIndex = 0;
            this.textBox_password.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(55, 135);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(237, 20);
            this.textBox_username.TabIndex = 0;
            this.textBox_username.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Sign_up
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(717, 551);
            this.Controls.Add(this.panel_signUp);
            this.Name = "Sign_up";
            this.Text = "Đăng ký";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_signUp.ResumeLayout(false);
            this.panel_signUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private QLSV.RoundedPanel panel_signUp;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Button SignUp;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label rePassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_re_password;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel link_SignIn;
    }
}

