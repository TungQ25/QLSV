using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QLSV
{
    public partial class Sign_up : Form
    {
        public Sign_up()
        {
            InitializeComponent();
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            panel_signUp.BorderRadius = 20;
            panel_signUp.BorderSize = 2;
            panel_signUp.BorderColor = Color.FromArgb(100, 100, 100);
            panel_signUp.BackColor = Color.White;
            textBox_password.UseSystemPasswordChar = true;
            textBox_re_password.UseSystemPasswordChar = true;

            AcceptButton = btnSignUp; // Nhấn Enter sẽ kích hoạt nút đăng ký
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
            string rePassword = textBox_re_password.Text;

            // In thông báo nếu thiếu thông tin tương ứng
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(rePassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.Equals(password, rePassword, StringComparison.Ordinal))
            {
                MessageBox.Show("Mật khẩu nhập lại phải trùng với mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string checkUserQuery = "SELECT COUNT(1) FROM Account WHERE Username = @Username";
                SqlParameter[] checkParameters = { new SqlParameter("@Username", username) };
                object countResult = DatabaseHelper.ExecuteScalar(checkUserQuery, checkParameters);
                int existingCount = countResult != null ? Convert.ToInt32(countResult) : 0;

                if (existingCount > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string passwordHash = DatabaseHelper.HashPassword(password);
                string insertQuery = @"INSERT INTO Account (Username, Password, Role, IsActive)
                                       VALUES (@Username, @Password, @Role, @IsActive)";

                SqlParameter[] insertParameters =
                {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", passwordHash),
                    new SqlParameter("@Role", "user"),
                    new SqlParameter("@IsActive", true)
                };

                int affectedRows = DatabaseHelper.ExecuteNonQuery(insertQuery, insertParameters);

                if (affectedRows > 0)
                {
                    MessageBox.Show("Đăng ký thành công. Vui lòng đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    Sign_in signInForm = new Sign_in();
                    signInForm.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Không thể đăng ký tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Sign_in signInForm = new Sign_in();
            signInForm.ShowDialog();
            this.Close();
        }
    }
}
