namespace QLSV
{
    partial class Sign_in
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
            this.panel_signIn = new QLSV.RoundedPanel();
            this.link_SignIn = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.SignIn = new System.Windows.Forms.Button();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.panel_signIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_signIn
            // 
            this.panel_signIn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_signIn.Controls.Add(this.link_SignIn);
            this.panel_signIn.Controls.Add(this.label2);
            this.panel_signIn.Controls.Add(this.password);
            this.panel_signIn.Controls.Add(this.label1);
            this.panel_signIn.Controls.Add(this.username);
            this.panel_signIn.Controls.Add(this.SignIn);
            this.panel_signIn.Controls.Add(this.textBox_password);
            this.panel_signIn.Controls.Add(this.textBox_username);
            this.panel_signIn.Location = new System.Drawing.Point(180, 40);
            this.panel_signIn.Name = "panel_signIn";
            this.panel_signIn.Size = new System.Drawing.Size(353, 383);
            this.panel_signIn.TabIndex = 0;
            this.panel_signIn.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // link_SignIn
            // 
            this.link_SignIn.AutoSize = true;
            this.link_SignIn.Location = new System.Drawing.Point(194, 301);
            this.link_SignIn.Name = "link_SignIn";
            this.link_SignIn.Size = new System.Drawing.Size(47, 13);
            this.link_SignIn.TabIndex = 4;
            this.link_SignIn.TabStop = true;
            this.link_SignIn.Text = "Đăng ký";
            this.link_SignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_SignUp_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chưa có tài khoản? ";
            this.label2.Click += new System.EventHandler(this.label3_Click);
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
            this.label1.Size = new System.Drawing.Size(165, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đăng nhập";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(55, 116);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(81, 13);
            this.username.TabIndex = 2;
            this.username.Text = "Tên đăng nhập";
            this.username.Click += new System.EventHandler(this.label1_Click);
            // 
            // SignIn
            // 
            this.SignIn.Location = new System.Drawing.Point(93, 258);
            this.SignIn.Name = "SignIn";
            this.SignIn.Size = new System.Drawing.Size(161, 40);
            this.SignIn.TabIndex = 1;
            this.SignIn.Text = "Đăng nhập";
            this.SignIn.UseVisualStyleBackColor = true;
            this.SignIn.Click += new System.EventHandler(this.button1_Click);
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
            // Sign_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 551);
            this.Controls.Add(this.panel_signIn);
            this.Name = "Sign_in";
            this.Text = "Đăng ký";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_signIn.ResumeLayout(false);
            this.panel_signIn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private QLSV.RoundedPanel panel_signIn;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Button SignIn;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel link_SignIn;
    }
}

