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
            this.lblDacotk = new System.Windows.Forms.Label();
            this.rePassword = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.lblDangKy = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.textBox_re_password = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_signUp.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_signUp
            // 
            this.panel_signUp.AutoScroll = true;
            this.panel_signUp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_signUp.BorderColor = System.Drawing.Color.Gray;
            this.panel_signUp.BorderRadius = 14;
            this.panel_signUp.BorderSize = 0;
            this.panel_signUp.Controls.Add(this.link_SignIn);
            this.panel_signUp.Controls.Add(this.lblDacotk);
            this.panel_signUp.Controls.Add(this.rePassword);
            this.panel_signUp.Controls.Add(this.password);
            this.panel_signUp.Controls.Add(this.lblDangKy);
            this.panel_signUp.Controls.Add(this.username);
            this.panel_signUp.Controls.Add(this.btnSignUp);
            this.panel_signUp.Controls.Add(this.textBox_re_password);
            this.panel_signUp.Controls.Add(this.textBox_password);
            this.panel_signUp.Controls.Add(this.textBox_username);
            this.panel_signUp.ForeColor = System.Drawing.Color.Black;
            this.panel_signUp.Location = new System.Drawing.Point(186, 43);
            this.panel_signUp.Name = "panel_signUp";
            this.panel_signUp.Size = new System.Drawing.Size(344, 444);
            this.panel_signUp.TabIndex = 0;
            this.panel_signUp.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // link_SignIn
            // 
            this.link_SignIn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.link_SignIn.AutoSize = true;
            this.link_SignIn.Location = new System.Drawing.Point(189, 370);
            this.link_SignIn.Name = "link_SignIn";
            this.link_SignIn.Size = new System.Drawing.Size(60, 13);
            this.link_SignIn.TabIndex = 4;
            this.link_SignIn.TabStop = true;
            this.link_SignIn.Text = "Đăng nhập";
            this.link_SignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblDacotk
            // 
            this.lblDacotk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDacotk.AutoSize = true;
            this.lblDacotk.Location = new System.Drawing.Point(99, 370);
            this.lblDacotk.Name = "lblDacotk";
            this.lblDacotk.Size = new System.Drawing.Size(92, 13);
            this.lblDacotk.TabIndex = 2;
            this.lblDacotk.Text = "Đã có tài khoản? ";
            this.lblDacotk.Click += new System.EventHandler(this.label3_Click);
            // 
            // rePassword
            // 
            this.rePassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(55, 188);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(52, 13);
            this.password.TabIndex = 2;
            this.password.Text = "Mật khẩu";
            // 
            // lblDangKy
            // 
            this.lblDangKy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDangKy.AutoSize = true;
            this.lblDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangKy.Location = new System.Drawing.Point(115, 50);
            this.lblDangKy.Name = "lblDangKy";
            this.lblDangKy.Size = new System.Drawing.Size(129, 33);
            this.lblDangKy.TabIndex = 2;
            this.lblDangKy.Text = "Đăng ký";
            this.lblDangKy.Click += new System.EventHandler(this.label1_Click);
            // 
            // username
            // 
            this.username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(55, 116);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(68, 13);
            this.username.TabIndex = 2;
            this.username.Text = "Tên đăng ký";
            this.username.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSignUp
            // 
            this.btnSignUp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSignUp.Location = new System.Drawing.Point(95, 327);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(161, 40);
            this.btnSignUp.TabIndex = 3;
            this.btnSignUp.Text = "Đăng ký";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_re_password
            // 
            this.textBox_re_password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox_re_password.Location = new System.Drawing.Point(55, 273);
            this.textBox_re_password.Name = "textBox_re_password";
            this.textBox_re_password.Size = new System.Drawing.Size(237, 20);
            this.textBox_re_password.TabIndex = 2;
            this.textBox_re_password.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_password
            // 
            this.textBox_password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox_password.Location = new System.Drawing.Point(55, 204);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(237, 20);
            this.textBox_password.TabIndex = 1;
            this.textBox_password.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_username
            // 
            this.textBox_username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox_username.Location = new System.Drawing.Point(55, 135);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(237, 20);
            this.textBox_username.TabIndex = 0;
            this.textBox_username.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel_signUp, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(717, 551);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Sign_up
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(717, 551);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Sign_up";
            this.Text = "Đăng ký";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_signUp.ResumeLayout(false);
            this.panel_signUp.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QLSV.RoundedPanel panel_signUp;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label rePassword;
        private System.Windows.Forms.Label lblDangKy;
        private System.Windows.Forms.TextBox textBox_re_password;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label lblDacotk;
        private System.Windows.Forms.LinkLabel link_SignIn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

