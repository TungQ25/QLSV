using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QLSV
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            dataGridDSSV.CellClick += dataGridView1_CellClick;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            pnlTongSV.Resize += RoundedControls_Resize;
            pnlSoLop.Resize += RoundedControls_Resize;
            pnlSVmoi.Resize += RoundedControls_Resize;
            pnlActions.Resize += RoundedControls_Resize;
            pnlStudentList.Resize += RoundedControls_Resize;
            Shown += Dashboard_Shown;
            LoadSinhVien();
        }

        private void Dashboard_Shown(object sender, EventArgs e)
        {
            ApplyRoundedCorners();
        }

        private void RoundedControls_Resize(object sender, EventArgs e)
        {
            ApplyRoundedCorners();
        }

        private void ApplyRoundedCorners()
        {
            SetRoundedRegion(pnlTongSV, 16);
            SetRoundedRegion(pnlSoLop, 16);
            SetRoundedRegion(pnlSVmoi, 16);
            SetRoundedRegion(pnlActions, 16);
            SetRoundedRegion(pnlStudentList, 16);
        }

        private void SetRoundedRegion(Control control, int radius)
        {
            if (control.Width <= 0 || control.Height <= 0)
            {
                return;
            }

            using (var path = RoundedPanel.CreateRoundedPath(control.ClientRectangle, radius))
            {
                control.Region = new Region(path);
            }
        }

        private void LoadSinhVien()
        {
            try
            {
                // Map cột DataGridView với cột trong database
                MSSV.DataPropertyName = "MSSV";
                Ngaysinh.DataPropertyName = "NgaySinh";
                lop.DataPropertyName = "Lop";
                khoa.DataPropertyName = "Khoa";
                trangthai.DataPropertyName = "TrangThai";
                dataGridDSSV.AutoGenerateColumns = false;

                string query = "SELECT MSSV, NgaySinh, Lop, Khoa, TrangThai FROM SinhVien";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dataGridDSSV.DataSource = dt;

                if (dataGridDSSV.Rows.Count > 0)
                {
                    dataGridDSSV.Rows[0].Selected = true;
                    LoadRowToTextBoxes(dataGridDSSV.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string mssv = txtMssv.Text.Trim();
            string ngaySinhText = txtNgaySinh.Text.Trim();
            string lopValue = txtLop.Text.Trim();
            string khoaValue = txtKhoa.Text.Trim();
            string trangThaiValue = txtTrangThai.Text.Trim();

            if (string.IsNullOrWhiteSpace(mssv) ||
                string.IsNullOrWhiteSpace(ngaySinhText) ||
                string.IsNullOrWhiteSpace(lopValue) ||
                string.IsNullOrWhiteSpace(khoaValue) ||
                string.IsNullOrWhiteSpace(trangThaiValue))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParse(ngaySinhText, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"UPDATE SinhVien
                                 SET NgaySinh = @NgaySinh, Lop = @Lop, Khoa = @Khoa, TrangThai = @TrangThai
                                 WHERE MSSV = @MSSV";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MSSV", mssv),
                    new SqlParameter("@NgaySinh", ngaySinh),
                    new SqlParameter("@Lop", lopValue),
                    new SqlParameter("@Khoa", khoaValue),
                    new SqlParameter("@TrangThai", trangThaiValue)
                };

                int affectedRows = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (affectedRows > 0)
                {
                    MessageBox.Show("Sửa sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSinhVien();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy MSSV để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string mssv = txtMssv.Text.Trim();

            if (string.IsNullOrWhiteSpace(mssv))
            {
                MessageBox.Show("Vui lòng nhập MSSV trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa sinh viên này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string query = "DELETE FROM SinhVien WHERE MSSV = @MSSV";
                SqlParameter[] parameters = { new SqlParameter("@MSSV", mssv) };

                int affectedRows = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (affectedRows > 0)
                {
                    MessageBox.Show("Xóa sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSinhVien();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy MSSV để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi người dùng click vào một ô trong DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            LoadRowToTextBoxes(dataGridDSSV.Rows[e.RowIndex]);
        }

        // Hàm để load dữ liệu từ DataGridViewRow vào các TextBox
        private void LoadRowToTextBoxes(DataGridViewRow row)
        {
            txtMssv.Text = Convert.ToString(row.Cells["MSSV"].Value);
            txtNgaySinh.Text = Convert.ToString(row.Cells["Ngaysinh"].Value);
            txtLop.Text = Convert.ToString(row.Cells["lop"].Value);
            txtKhoa.Text = Convert.ToString(row.Cells["khoa"].Value);
            txtTrangThai.Text = Convert.ToString(row.Cells["trangthai"].Value);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
                    }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string mssv = txtMssv.Text.Trim();
            string ngaySinhText = txtNgaySinh.Text.Trim();
            string lopValue = txtLop.Text.Trim();
            string khoaValue = txtKhoa.Text.Trim();
            string trangThaiValue = txtTrangThai.Text.Trim();

            if (string.IsNullOrWhiteSpace(mssv) ||
                string.IsNullOrWhiteSpace(ngaySinhText) ||
                string.IsNullOrWhiteSpace(lopValue) ||
                string.IsNullOrWhiteSpace(khoaValue) ||
                string.IsNullOrWhiteSpace(trangThaiValue))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParse(ngaySinhText, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"INSERT INTO SinhVien (MSSV, NgaySinh, Lop, Khoa, TrangThai)
                                 VALUES (@MSSV, @NgaySinh, @Lop, @Khoa, @TrangThai)";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MSSV", mssv),
                    new SqlParameter("@NgaySinh", ngaySinh),
                    new SqlParameter("@Lop", lopValue),
                    new SqlParameter("@Khoa", khoaValue),
                    new SqlParameter("@TrangThai", trangThaiValue)
                };

                int affectedRows = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (affectedRows > 0)
                {
                    MessageBox.Show("Thêm sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSinhVien();
                }
                else
                {
                    MessageBox.Show("Không thể thêm sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNgaySinh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
