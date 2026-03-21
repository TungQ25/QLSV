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
            btnRefresh.Click += btnRefresh_Click;
            txtKhoa.SelectedIndexChanged += txtKhoa_SelectedIndexChanged;
            InitializeSelectionInputs();
            ConfigureDataGrid();
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
            SetRoundedRegion(pnlTongSV, 14);
            SetRoundedRegion(pnlSoLop, 14);
            SetRoundedRegion(pnlSVmoi, 14);
            SetRoundedRegion(pnlActions, 14);
            SetRoundedRegion(pnlStudentList, 14);

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

        private void InitializeSelectionInputs()
        {
            txtNgaySinh.Format = DateTimePickerFormat.Custom;
            txtNgaySinh.CustomFormat = "dd/MM/yyyy";

            txtLop.DropDownStyle = ComboBoxStyle.DropDownList;
            txtTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            txtGioitinh.DropDownStyle = ComboBoxStyle.DropDownList;
            txtKhoa.DropDownStyle = ComboBoxStyle.DropDownList;

            txtGioitinh.Items.Clear();
            txtGioitinh.Items.Add("Nam");
            txtGioitinh.Items.Add("Nữ");
            txtGioitinh.SelectedIndex = 0;
        }

        private void ConfigureDataGrid()
        {
            dataGridDSSV.AutoGenerateColumns = false;
            dataGridDSSV.AllowUserToAddRows = false;
            dataGridDSSV.AllowUserToDeleteRows = false;
            dataGridDSSV.ReadOnly = true;
            dataGridDSSV.MultiSelect = false;
            dataGridDSSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadComboBoxData()
        {
            LoadKhoaComboBox();
            LoadTrangThaiComboBox();
            LoadLopBySelectedKhoa();
        }

        private void LoadKhoaComboBox()
        {
            string currentText = txtKhoa.Text;
            DataTable data = DatabaseHelper.ExecuteQuery("SELECT MaKhoa, TenKhoa FROM Khoa ORDER BY TenKhoa");

            txtKhoa.DataSource = data;
            txtKhoa.DisplayMember = "TenKhoa";
            txtKhoa.ValueMember = "MaKhoa";

            if (!string.IsNullOrWhiteSpace(currentText))
            {
                int index = txtKhoa.FindStringExact(currentText);
                if (index >= 0)
                {
                    txtKhoa.SelectedIndex = index;
                }
            }
        }

        private void LoadTrangThaiComboBox()
        {
            string currentValue = txtTrangThai.Text;
            DataTable data = DatabaseHelper.ExecuteQuery("SELECT DISTINCT TrangThai FROM SinhVien " +
                             "WHERE TrangThai IS NOT NULL AND LTRIM(RTRIM(TrangThai)) <> '' ORDER BY TrangThai");

            txtTrangThai.Items.Clear();
            foreach (DataRow row in data.Rows)
            {
                txtTrangThai.Items.Add(Convert.ToString(row[0]));
            }

            string[] defaultTrangThai = { "Đang học", "Nghỉ học" };
            foreach (string trangThai in defaultTrangThai)
            {
                if (!txtTrangThai.Items.Contains(trangThai))
                {
                    txtTrangThai.Items.Add(trangThai);
                }
            }

            if (!string.IsNullOrWhiteSpace(currentValue) && txtTrangThai.Items.Contains(currentValue))
            {
                txtTrangThai.SelectedItem = currentValue;
            }
            else if (txtTrangThai.Items.Count > 0)
            {
                txtTrangThai.SelectedIndex = 0;
            }
        }

        private void LoadLopBySelectedKhoa()
        {
            string maKhoa = GetComboSelectedValue(txtKhoa);
            string currentText = txtLop.Text;

            txtLop.DataSource = null;

            if (string.IsNullOrWhiteSpace(maKhoa))
            {
                return;
            }

            SqlParameter[] parameters = { new SqlParameter("@MaKhoa", maKhoa) };
            DataTable data = DatabaseHelper.ExecuteQuery(
                "SELECT MaLop, TenLop FROM Lop WHERE MaKhoa = @MaKhoa ORDER BY TenLop",
                parameters);

            txtLop.DataSource = data;
            txtLop.DisplayMember = "TenLop";
            txtLop.ValueMember = "MaLop";

            if (!string.IsNullOrWhiteSpace(currentText))
            {
                int index = txtLop.FindStringExact(currentText);
                if (index >= 0)
                {
                    txtLop.SelectedIndex = index;
                }
            }
        }

        private static string GetComboValue(ComboBox comboBox)
        {
            return Convert.ToString(comboBox.SelectedItem ?? comboBox.Text)?.Trim();
        }

        private static string GetComboSelectedValue(ComboBox comboBox)
        {
            return Convert.ToString(comboBox.SelectedValue)?.Trim();
        }

        private static void SetComboValue(ComboBox comboBox, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (comboBox.Items.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }

                return;
            }

            int index = comboBox.FindStringExact(value);
            if (index >= 0)
            {
                comboBox.SelectedIndex = index;
            }
        }

        private void LoadSinhVien()
        {
            try
            {
                // Map cột DataGridView với cột trong database
                MSSV.DataPropertyName = "MSSV";
                fullname.DataPropertyName = "HoTen";
                gioitinh.DataPropertyName = "GioiTinh";
                Ngaysinh.DataPropertyName = "NgaySinh";
                Ngaysinh.DefaultCellStyle.Format = "dd/MM/yyyy";
                lop.DataPropertyName = "Lop";
                khoa.DataPropertyName = "Khoa";
                trangthai.DataPropertyName = "TrangThai";
                dataGridDSSV.AutoGenerateColumns = false;

                string query = @"SELECT sv.MSSV,
                                        sv.HoTen,
                                        sv.GioiTinh,
                                        sv.NgaySinh,
                                        l.TenLop AS Lop,
                                        k.TenKhoa AS Khoa,
                                        sv.TrangThai,
                                        sv.MaLop,
                                        k.MaKhoa
                                 FROM SinhVien sv
                                 LEFT JOIN Lop l ON sv.MaLop = l.MaLop
                                 LEFT JOIN Khoa k ON l.MaKhoa = k.MaKhoa";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dataGridDSSV.DataSource = dt;
                LoadComboBoxData();

                if (dataGridDSSV.Rows.Count > 0)
                {
                    dataGridDSSV.Rows[0].Selected = true;
                    LoadRowToTextBoxes(dataGridDSSV.Rows[0]);
                }
                else
                {
                    txtMssv.Clear();
                    txtFullname.Clear();
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
            string hoTen = txtFullname.Text.Trim();
            string gioiTinhValue = GetComboValue(txtGioitinh);
            DateTime ngaySinh = txtNgaySinh.Value.Date;
            string maLop = GetComboSelectedValue(txtLop);
            string khoaValue = GetComboValue(txtKhoa);
            string trangThaiValue = GetComboValue(txtTrangThai);

            if (string.IsNullOrWhiteSpace(mssv) ||
                string.IsNullOrWhiteSpace(hoTen) ||
                string.IsNullOrWhiteSpace(gioiTinhValue) ||
                string.IsNullOrWhiteSpace(maLop) ||
                string.IsNullOrWhiteSpace(khoaValue) ||
                string.IsNullOrWhiteSpace(trangThaiValue))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"UPDATE SinhVien
                                 SET HoTen = @HoTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, MaLop = @MaLop, TrangThai = @TrangThai
                                 WHERE MSSV = @MSSV";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MSSV", mssv),
                    new SqlParameter("@HoTen", hoTen),
                    new SqlParameter("@GioiTinh", gioiTinhValue),
                    new SqlParameter("@NgaySinh", ngaySinh),
                    new SqlParameter("@MaLop", maLop),
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

        // Hàm để load dữ liệu từ DataGridViewRow vào các control nhập liệu
        private void LoadRowToTextBoxes(DataGridViewRow row)
        {
            txtMssv.Text = Convert.ToString(row.Cells["MSSV"].Value);
            txtFullname.Text = Convert.ToString(row.Cells["fullname"].Value);
            object ngaySinhValue = row.Cells["Ngaysinh"].Value;
            if (ngaySinhValue != null && DateTime.TryParse(Convert.ToString(ngaySinhValue), out DateTime ngaySinh))
            {
                txtNgaySinh.Value = ngaySinh;
            }

            SetComboValue(txtLop, Convert.ToString(row.Cells["lop"].Value));
            SetComboValue(txtGioitinh, Convert.ToString(row.Cells["gioitinh"].Value));
            SetComboValue(txtKhoa, Convert.ToString(row.Cells["khoa"].Value));
            SetComboValue(txtTrangThai, Convert.ToString(row.Cells["trangthai"].Value));

            DataRowView dataRow = row.DataBoundItem as DataRowView;
            if (dataRow != null)
            {
                string maKhoa = Convert.ToString(dataRow["MaKhoa"]);
                string maLop = Convert.ToString(dataRow["MaLop"]);

                SelectKhoaByMaKhoa(maKhoa);
                LoadLopBySelectedKhoa();
                SelectLopByMaLop(maLop);
            }
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
            string hoTen = txtFullname.Text.Trim();
            string gioiTinhValue = GetComboValue(txtGioitinh);
            DateTime ngaySinh = txtNgaySinh.Value.Date;
            string maLop = GetComboSelectedValue(txtLop);
            string khoaValue = GetComboValue(txtKhoa);
            string trangThaiValue = GetComboValue(txtTrangThai);

            if (string.IsNullOrWhiteSpace(mssv) ||
                string.IsNullOrWhiteSpace(hoTen) ||
                string.IsNullOrWhiteSpace(gioiTinhValue) ||
                string.IsNullOrWhiteSpace(maLop) ||
                string.IsNullOrWhiteSpace(khoaValue) ||
                string.IsNullOrWhiteSpace(trangThaiValue))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"INSERT INTO SinhVien (MSSV, HoTen, GioiTinh, NgaySinh, MaLop, TrangThai)
                                 VALUES (@MSSV, @HoTen, @GioiTinh, @NgaySinh, @MaLop, @TrangThai)";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MSSV", mssv),
                    new SqlParameter("@HoTen", hoTen),
                    new SqlParameter("@GioiTinh", gioiTinhValue),
                    new SqlParameter("@NgaySinh", ngaySinh),
                    new SqlParameter("@MaLop", maLop),
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSinhVien();
        }

        private void txtKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLopBySelectedKhoa();
        }

        private void SelectKhoaByMaKhoa(string maKhoa)
        {
            if (string.IsNullOrWhiteSpace(maKhoa))
            {
                return;
            }

            for (int i = 0; i < txtKhoa.Items.Count; i++)
            {
                DataRowView rowView = txtKhoa.Items[i] as DataRowView;
                if (rowView != null && string.Equals(Convert.ToString(rowView["MaKhoa"]), maKhoa, StringComparison.OrdinalIgnoreCase))
                {
                    txtKhoa.SelectedIndex = i;
                    return;
                }
            }
        }

        private void SelectLopByMaLop(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop))
            {
                return;
            }

            for (int i = 0; i < txtLop.Items.Count; i++)
            {
                DataRowView rowView = txtLop.Items[i] as DataRowView;
                if (rowView != null && string.Equals(Convert.ToString(rowView["MaLop"]), maLop, StringComparison.OrdinalIgnoreCase))
                {
                    txtLop.SelectedIndex = i;
                    return;
                }
            }
        }

        private void imgNotification_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
