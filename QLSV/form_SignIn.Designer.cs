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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_signIn = new QLSV.RoundedPanel();
            this.link_SignIn = new System.Windows.Forms.LinkLabel();
            this.lblChuacotk = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lblDangNhap = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_signIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel_signIn, 1, 1);
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
            // panel_signIn
            // 
            this.panel_signIn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_signIn.BorderColor = System.Drawing.Color.Gray;
            this.panel_signIn.BorderRadius = 14;
            this.panel_signIn.BorderSize = 0;
            this.panel_signIn.Controls.Add(this.link_SignIn);
            this.panel_signIn.Controls.Add(this.lblChuacotk);
            this.panel_signIn.Controls.Add(this.lbl_password);
            this.panel_signIn.Controls.Add(this.lblDangNhap);
            this.panel_signIn.Controls.Add(this.lbl_username);
            this.panel_signIn.Controls.Add(this.btnSignIn);
            this.panel_signIn.Controls.Add(this.textBox_password);
            this.panel_signIn.Controls.Add(this.textBox_username);
            this.panel_signIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_signIn.ForeColor = System.Drawing.Color.Black;
            this.panel_signIn.Location = new System.Drawing.Point(186, 43);
            this.panel_signIn.Name = "panel_signIn";
            this.panel_signIn.Size = new System.Drawing.Size(344, 444);
            this.panel_signIn.TabIndex = 0;
            this.panel_signIn.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // link_SignIn
            // 
            this.link_SignIn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.link_SignIn.AutoSize = true;
            this.link_SignIn.Location = new System.Drawing.Point(201, 333);
            this.link_SignIn.Name = "link_SignIn";
            this.link_SignIn.Size = new System.Drawing.Size(47, 13);
            this.link_SignIn.TabIndex = 3;
            this.link_SignIn.TabStop = true;
            this.link_SignIn.Text = "Đăng ký";
            this.link_SignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_SignUp_LinkClicked);
            // 
            // lblChuacotk
            // 
            this.lblChuacotk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblChuacotk.AutoSize = true;
            this.lblChuacotk.Location = new System.Drawing.Point(99, 333);
            this.lblChuacotk.Name = "lblChuacotk";
            this.lblChuacotk.Size = new System.Drawing.Size(103, 13);
            this.lblChuacotk.TabIndex = 2;
            this.lblChuacotk.Text = "Chưa có tài khoản? ";
            this.lblChuacotk.Click += new System.EventHandler(this.label3_Click);
            // 
            // lbl_password
            // 
            this.lbl_password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(54, 214);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(52, 13);
            this.lbl_password.TabIndex = 2;
            this.lbl_password.Text = "Mật khẩu";
            // 
            // lblDangNhap
            // 
            this.lblDangNhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDangNhap.AutoSize = true;
            this.lblDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangNhap.Location = new System.Drawing.Point(90, 75);
            this.lblDangNhap.Name = "lblDangNhap";
            this.lblDangNhap.Size = new System.Drawing.Size(165, 33);
            this.lblDangNhap.TabIndex = 2;
            this.lblDangNhap.Text = "Đăng nhập";
            this.lblDangNhap.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_username
            // 
            this.lbl_username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(54, 139);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(81, 13);
            this.lbl_username.TabIndex = 2;
            this.lbl_username.Text = "Tên đăng nhập";
            this.lbl_username.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSignIn.Location = new System.Drawing.Point(95, 290);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(161, 40);
            this.btnSignIn.TabIndex = 2;
            this.btnSignIn.Text = "Đăng nhập";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_password
            // 
            this.textBox_password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox_password.Location = new System.Drawing.Point(54, 230);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(237, 20);
            this.textBox_password.TabIndex = 1;
            this.textBox_password.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_username
            // 
            this.textBox_username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox_username.Location = new System.Drawing.Point(54, 158);
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
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Sign_in";
            this.Text = "Đăng ký";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_signIn.ResumeLayout(false);
            this.panel_signIn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RoundedPanel panel_signIn;
        private System.Windows.Forms.LinkLabel link_SignIn;
        private System.Windows.Forms.Label lblChuacotk;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lblDangNhap;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_username;
    }
}

