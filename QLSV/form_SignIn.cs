using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QLSV
{
    public partial class Sign_in : Form
    {
        public Sign_in()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel_signIn.BorderRadius = 20;
            panel_signIn.BorderSize = 2;
            panel_signIn.BorderColor = Color.FromArgb(100, 100, 100);
            panel_signIn.BackColor = Color.White;
            textBox_password.UseSystemPasswordChar = true;

            AcceptButton = btnSignIn; // Nhấn Enter sẽ kích hoạt nút đăng nhập
            textBox_username.Focus(); // Đặt con trỏ vào ô nhập tên đăng nhập khi form được tải
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox_username.Text.Trim();
            string password = textBox_password.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string passwordHash = DatabaseHelper.HashPassword(password);
                string query = @"SELECT COUNT(1)
                                 FROM Account
                                 WHERE Username = @Username
                                   AND IsActive = 1
                                   AND (Password = @Password OR Password = @PasswordHash)";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", password),
                    new SqlParameter("@PasswordHash", passwordHash)
                };

                object result = DatabaseHelper.ExecuteScalar(query, parameters);
                int accountCount = result != null ? Convert.ToInt32(result) : 0;

                if (accountCount > 0)
                {
                    Hide();
                    Dashboard dashboardForm = new Dashboard();
                    dashboardForm.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void link_SignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Sign_up signUpForm = new Sign_up();
            signUpForm.ShowDialog();
            this.Close();
        }
    }
}
