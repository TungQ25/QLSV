using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QLSV
{
    public partial class Dashboard : Form
    {
        private Panel sidebarPanel;
        private Panel headerPanel;
        private Panel contentPanel;
        private Panel menuPanel;

        public Dashboard()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadSinhVien();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Quản lý Sinh viên - Dashboard";
            this.Size = new Size(1400, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 242, 245);

            //CreateSidebar();
            //CreateHeader();
            //CreateContent();
        }

        private void CreateSidebar()
        {
            sidebarPanel = new Panel
            {
                Width = 250,
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(248, 249, 250)
            };

            sidebarPanel.Controls.Add(menuPanel);

            // Settings button at bottom
            Button settingsBtn = new Button
            {
                Text = "⚙  Cài đặt",
                Height = 45,
                Dock = DockStyle.Bottom,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(248, 249, 250),
                ForeColor = Color.FromArgb(108, 117, 125),
                Font = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(35, 0, 0, 0)
            };
            settingsBtn.FlatAppearance.BorderSize = 0;
            sidebarPanel.Controls.Add(settingsBtn);

            this.Controls.Add(sidebarPanel);
        }

        private void AddMenuItem(string text, int yPos, bool isActive)
        {
            Button menuBtn = new Button
            {
                Text = text,
                Size = new Size(240, 45),
                Location = new Point(5, yPos),
                FlatStyle = FlatStyle.Flat,
                BackColor = isActive ? Color.FromArgb(13, 110, 253) : Color.Transparent,
                ForeColor = isActive ? Color.White : Color.FromArgb(108, 117, 125),
                Font = new Font("Segoe UI", 10, isActive ? FontStyle.Bold : FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(35, 0, 0, 0),
                Cursor = Cursors.Hand
            };

            menuBtn.FlatAppearance.BorderSize = 0;
            menuBtn.FlatAppearance.MouseOverBackColor = isActive ? Color.FromArgb(13, 110, 253) : Color.FromArgb(233, 236, 239);

            menuPanel.Controls.Add(menuBtn);
        }

        private void CreateHeader()
        {
            headerPanel = new Panel
            {
                Height = 70,
                Dock = DockStyle.Top,
                BackColor = Color.White
            };

            // Search box
            TextBox searchBox = new TextBox
            {
                Width = 400,
                Height = 35,
                Location = new Point(30, 20),
                Font = new Font("Segoe UI", 11),
                Text = "Tìm kiếm sinh viên...",
                ForeColor = Color.Gray
            };

            searchBox.GotFocus += (s, e) =>
            {
                if (searchBox.Text == "Tìm kiếm sinh viên...")
                {
                    searchBox.Text = "";
                    searchBox.ForeColor = Color.Black;
                }
            };

            searchBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(searchBox.Text))
                {
                    searchBox.Text = "Tìm kiếm sinh viên...";
                    searchBox.ForeColor = Color.Gray;
                }
            };

            // Admin label
            Label adminLabel = new Label
            {
                Text = "Admin ▼",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(73, 80, 87),
                AutoSize = true,
                Location = new Point(this.Width - 200, 25),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Cursor = Cursors.Hand
            };

            // Notification icon
            Label notificationIcon = new Label
            {
                Text = "🔔",
                Font = new Font("Segoe UI", 16),
                AutoSize = true,
                Location = new Point(this.Width - 280, 22),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Cursor = Cursors.Hand
            };

            headerPanel.Controls.Add(searchBox);
            headerPanel.Controls.Add(notificationIcon);
            headerPanel.Controls.Add(adminLabel);

            this.Controls.Add(headerPanel);
        }

        private void CreateContent()
        {
            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(240, 242, 245),
                Padding = new Padding(30)
            };

            // Title
            Label titleLabel = new Label
            {
                Text = "Tổng quan",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                AutoSize = true,
                Location = new Point(30, 20)
            };
            contentPanel.Controls.Add(titleLabel);

            // Statistics cards
            CreateStatisticsCards();

            // Chart section
            CreateChartSection();

            // Student list
            CreateStudentList();

            this.Controls.Add(contentPanel);
        }

        private void CreateStatisticsCards()
        {
            int xPos = 30;
            int yPos = 80;

            CreateStatCard("Tổng số Sinh viên", "1,234", xPos, yPos, Color.FromArgb(13, 110, 253));
            xPos += 380;
            CreateStatCard("Sinh viên Mới", "45", xPos, yPos, Color.FromArgb(25, 135, 84));
            xPos += 380;
            CreateStatCard("Lớp học Active", "68", xPos, yPos, Color.FromArgb(25, 135, 84));
        }

        private void CreateStatCard(string title, string value, int x, int y, Color accentColor)
        {
            RoundedPanel card = new RoundedPanel
            {
                Size = new Size(350, 120),
                Location = new Point(x, y),
                BackColor = Color.White,
                BorderRadius = 15,
                BorderSize = 0
            };

            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(108, 117, 125),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            Label valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 32, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                AutoSize = true,
                Location = new Point(20, 45)
            };

            Label iconLabel = new Label
            {
                Text = "📊",
                Font = new Font("Segoe UI", 40),
                AutoSize = true,
                Location = new Point(270, 35)
            };

            card.Controls.Add(titleLabel);
            card.Controls.Add(valueLabel);
            card.Controls.Add(iconLabel);

            contentPanel.Controls.Add(card);
        }

        private void CreateChartSection()
        {
            RoundedPanel chartPanel = new RoundedPanel
            {
                Size = new Size(1110, 300),
                Location = new Point(30, 220),
                BackColor = Color.White,
                BorderRadius = 15,
                BorderSize = 0
            };

            Label chartTitle = new Label
            {
                Text = "Số lượng sinh viên theo Khoa",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            Label chartPlaceholder = new Label
            {
                Text = "[Biểu đồ cột sẽ được render ở đây]",
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(108, 117, 125),
                AutoSize = true,
                Location = new Point(400, 130)
            };

            chartPanel.Controls.Add(chartTitle);
            chartPanel.Controls.Add(chartPlaceholder);

            contentPanel.Controls.Add(chartPanel);
        }

        private void CreateStudentList()
        {
            RoundedPanel listPanel = new RoundedPanel
            {
                Size = new Size(1110, 400),
                Location = new Point(30, 540),
                BackColor = Color.White,
                BorderRadius = 15,
                BorderSize = 0
            };

            Label listTitle = new Label
            {
                Text = "DANH SÁCH SINH VIÊN",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            Button addButton = new Button
            {
                Text = "➕ Thêm sinh viên mới",
                Size = new Size(180, 40),
                Location = new Point(800, 15),
                BackColor = Color.FromArgb(13, 110, 253),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            addButton.FlatAppearance.BorderSize = 0;

            Button exportButton = new Button
            {
                Text = "📤 Xuất dữ liệu",
                Size = new Size(140, 40),
                Location = new Point(990, 15),
                BackColor = Color.FromArgb(248, 249, 250),
                ForeColor = Color.FromArgb(73, 80, 87),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };
            exportButton.FlatAppearance.BorderSize = 1;
            exportButton.FlatAppearance.BorderColor = Color.FromArgb(206, 212, 218);

            DataGridView dataGrid = new DataGridView
            {
                Size = new Size(1070, 300),
                Location = new Point(20, 70),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(248, 249, 250),
                    ForeColor = Color.FromArgb(73, 80, 87),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Padding = new Padding(10)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.FromArgb(33, 37, 41),
                    SelectionBackColor = Color.FromArgb(233, 236, 239),
                    SelectionForeColor = Color.FromArgb(33, 37, 41),
                    Padding = new Padding(10)
                },
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeight = 45,
                RowTemplate = { Height = 50 }
            };

            // Add columns
            dataGrid.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "", Width = 40 });
            dataGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "MSSV", Name = "MSSV" });
            dataGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ và tên", Name = "HoTen" });
            dataGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày sinh", Name = "NgaySinh" });
            dataGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Lớp", Name = "Lop" });
            dataGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Khoa", Name = "Khoa" });
            dataGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng thái", Name = "TrangThai" });
            dataGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Actions", Name = "Actions" });

            // Add sample data
            dataGrid.Rows.Add(false, "SV001", "Nguyễn Văn A", "12/05/2004", "D19_TH01", "CNTT", "Đang học", "Sửa | Xóa");
            dataGrid.Rows.Add(false, "SV002", "Trần Thị B", "08/11/2003", "D20_KT02", "Kinh tế", "Đang học", "Sửa | Xóa");
            dataGrid.Rows.Add(false, "SV003", "Lê Minh C", "20/02/2005", "D19_TH01", "CNTT", "Nghỉ học", "Sửa | Xóa");

            listPanel.Controls.Add(listTitle);
            listPanel.Controls.Add(addButton);
            listPanel.Controls.Add(exportButton);
            listPanel.Controls.Add(dataGrid);

            contentPanel.Controls.Add(listPanel);
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
                dataGridView1.AutoGenerateColumns = false;

                string query = "SELECT MSSV, NgaySinh, Lop, Khoa, TrangThai FROM SinhVien";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
