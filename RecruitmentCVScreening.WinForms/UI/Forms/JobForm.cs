using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RecruitmentCVScreening.WinForms.UI.Forms
{
    // Đã thêm từ khóa "partial" và đặt tên là JobForm cho khớp với file của bạn
    public partial class JobForm : Form
    {
        // Sử dụng DataTable để lưu dữ liệu tạm thời (Không dùng Database)
        private DataTable dtJobs = null!;
        private int currentJobId = 0;
        private int autoIncrementId = 1;

        // UI Controls - Khu vực nhập liệu (Bên trái)
        private Panel panelInput = null!;
        private TextBox txtTitle = null!;
        private TextBox txtDescription = null!;
        private TextBox txtRequirements = null!;
        private NumericUpDown numQuantity = null!;
        private ComboBox cbStatus = null!;
        private Button btnSave = null!;
        private Button btnCancel = null!;

        // UI Controls - Khu vực danh sách (Bên phải)
        private Panel panelGrid = null!;
        private DataGridView dgvJobs = null!;
        private Button btnAddNew = null!;
        private Button btnEdit = null!;
        private Button btnDelete = null!;

        public JobForm()
        {
            SetupDummyData();
            BuildUI();
        }

        // Tạo dữ liệu ảo để giao diện không bị trống
        private void SetupDummyData()
        {
            dtJobs = new DataTable();
            dtJobs.Columns.Add("Mã", typeof(int));
            dtJobs.Columns.Add("Tiêu đề", typeof(string));
            dtJobs.Columns.Add("Số lượng", typeof(int));
            dtJobs.Columns.Add("Trạng thái", typeof(string));
            dtJobs.Columns.Add("Mô tả", typeof(string));
            dtJobs.Columns.Add("Yêu cầu", typeof(string));

            // Thêm vài dòng dữ liệu mẫu
            dtJobs.Rows.Add(autoIncrementId++, "Lập trình viên C# .NET", 2, "Open", "Phát triển phần mềm WinForms", "Có kinh nghiệm 1 năm");
            dtJobs.Rows.Add(autoIncrementId++, "Thực tập sinh Tester", 5, "Open", "Kiểm thử phần mềm", "Cẩn thận, tỉ mỉ");
            dtJobs.Rows.Add(autoIncrementId++, "BA (Business Analyst)", 1, "Closed", "Lấy yêu cầu khách hàng", "Giao tiếp tốt");
        }

        private void BuildUI()
        {
            this.Text = "Quản lý Vị trí Tuyển dụng";
            this.BackColor = Color.FromArgb(245, 246, 250); // Màu nền sáng hiện đại
            
            // --- THAY ĐỔI 1: Tăng font chữ và cấu hình hiển thị giữa màn hình với kích thước to ---
            this.Font = new Font("Segoe UI", 11F); 
            this.Size = new Size(1200, 750); 
            this.StartPosition = FormStartPosition.CenterScreen; 
            this.Dock = DockStyle.Fill; // Vẫn giữ Dock để nhúng vừa vặn vào MainForm nếu cần

            // ==========================================
            // 1. KHU VỰC NHẬP LIỆU (PANEL TRÁI)
            // ==========================================
            panelInput = new Panel
            {
                Dock = DockStyle.Left,
                Width = 450, // --- THAY ĐỔI 2: Mở rộng Panel trái (từ 350 lên 450) ---
                BackColor = Color.White,
                Padding = new Padding(20)
            };
            
            // Vẽ border mờ chia tách 2 bên
            panelInput.Paint += (s, e) => {
                e.Graphics.DrawLine(Pens.LightGray, panelInput.Width - 1, 0, panelInput.Width - 1, panelInput.Height);
            };

            Label lblInputHeader = new Label { Text = "THÔNG TIN VỊ TRÍ", Font = new Font("Segoe UI", 14F, FontStyle.Bold), ForeColor = Color.FromArgb(44, 62, 80), AutoSize = true, Location = new Point(20, 20) };
            panelInput.Controls.Add(lblInputHeader);

            int startY = 70;
            int spacing = 100; // --- THAY ĐỔI 2: Tăng khoảng cách các dòng dọc (từ 60 lên 70) ---
            int inputWidth = 410; // --- THAY ĐỔI 2: Tăng độ dài TextBox (từ 300 lên 380) ---

            // Tiêu đề
            panelInput.Controls.Add(new Label { Text = "Tiêu đề công việc (*):", Location = new Point(30, startY), AutoSize = true });
            txtTitle = new TextBox { Location = new Point(20, startY+30), Width = inputWidth };
            panelInput.Controls.Add(txtTitle);

            // Số lượng
            startY += spacing;
            panelInput.Controls.Add(new Label { Text = "Số lượng:", Location = new Point(20, startY), AutoSize = true });
            numQuantity = new NumericUpDown { Location = new Point(20, startY + 30), Width = 120, Minimum = 1, Maximum = 100 };
            panelInput.Controls.Add(numQuantity);

            // Trạng thái
            panelInput.Controls.Add(new Label { Text = "Trạng thái:", Location = new Point(170, startY), AutoSize = true });
            cbStatus = new ComboBox { Location = new Point(170, startY + 30), Width = 230, DropDownStyle = ComboBoxStyle.DropDownList };
            cbStatus.Items.AddRange(new string[] { "Open", "Closed" });
            cbStatus.SelectedIndex = 0;
            panelInput.Controls.Add(cbStatus);

            // Mô tả
            startY += spacing;
            panelInput.Controls.Add(new Label { Text = "Mô tả công việc:", Location = new Point(20, startY), AutoSize = true });
            txtDescription = new TextBox { Location = new Point(20, startY + 25), Width = inputWidth, Height = 90+70, Multiline = true, ScrollBars = ScrollBars.Vertical };
            panelInput.Controls.Add(txtDescription);

            // Yêu cầu
            startY += 200;
            panelInput.Controls.Add(new Label { Text = "Yêu cầu kỹ năng:", Location = new Point(20, startY), AutoSize = true });
            txtRequirements = new TextBox { Location = new Point(20, startY + 25), Width = inputWidth, Height = 90+70, Multiline = true, ScrollBars = ScrollBars.Vertical };
            panelInput.Controls.Add(txtRequirements);

            // --- THAY ĐỔI 2: Nút Lưu và Hủy to ra hơn ---
            startY += 230;
            btnSave = new Button { Text = "💾 Lưu Dữ Liệu", Location = new Point(20, startY), Width = 200, Height = 50, BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 11F, FontStyle.Bold) };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            panelInput.Controls.Add(btnSave);

            btnCancel = new Button { Text = "❌ Xóa Form", Location = new Point(230, startY), Width = 170, Height = 50, FlatStyle = FlatStyle.Flat, BackColor = Color.WhiteSmoke };
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.Click += (s, e) => ClearInputs();
            panelInput.Controls.Add(btnCancel);

            // ==========================================
            // 2. KHU VỰC DANH SÁCH (PANEL PHẢI)
            // ==========================================
            panelGrid = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };

            // Khung chứa các nút hành động của Grid
            Panel topGridPanel = new Panel { Dock = DockStyle.Top, Height = 100 };
            
            // --- THAY ĐỔI 4: Nút bấm có màu sắc tự nhiên và hiện đại hơn ---
            btnAddNew = new Button { Text = "➕ Thêm Mới", Location = new Point(0, 10), Width = 150, Height = 45, BackColor = Color.FromArgb(40, 167, 69), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnAddNew.FlatAppearance.BorderSize = 0;
            btnAddNew.Click += (s, e) => ClearInputs();

            btnEdit = new Button { Text = "✏️ Sửa Lựa Chọn", Location = new Point(140, 10), Width = 200, Height = 45, BackColor = Color.FromArgb(23, 162, 184), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Click += BtnEdit_Click;

            btnDelete = new Button { Text = "🗑️ Xóa Lựa Chọn", Location = new Point(300, 10), Width = 200, Height = 45, BackColor = Color.FromArgb(220, 53, 69), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += BtnDelete_Click;

            topGridPanel.Controls.AddRange(new Control[] { btnAddNew, btnEdit, btnDelete });
            panelGrid.Controls.Add(topGridPanel);

            // DataGridView
            dgvJobs = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                // --- THAY ĐỔI 2: Ẩn cột trắng thừa thãi bên trái bảng ---
                RowHeadersVisible = false,
                // --- THAY ĐỔI 3: Giãn khoảng cách các dòng trong lưới ra to hơn ---
                RowTemplate = { Height = 45 }, 
                AlternatingRowsDefaultCellStyle = { BackColor = Color.FromArgb(240, 240, 240) },
                DataSource = dtJobs // Bind dữ liệu ảo vào Grid
            };
            panelGrid.Controls.Add(dgvJobs);

            // Lệnh này ép DataGridView lùi lại nhường chỗ cho Top Panel, không bị chồng đè lên nhau nữa
            dgvJobs.BringToFront();
            // Thêm 2 Panel vào Form (Lưu ý: Thêm Fill trước, Left sau)
            this.Controls.Add(panelGrid);
            this.Controls.Add(panelInput);
        }

        // ==========================================
        // 3. LOGIC XỬ LÝ GIAO DIỆN (IN-MEMORY)
        // ==========================================

        private void ClearInputs()
        {
            currentJobId = 0;
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtRequirements.Text = "";
            numQuantity.Value = 1;
            cbStatus.SelectedIndex = 0;
            txtTitle.Focus();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập Tiêu đề công việc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentJobId == 0)
            {
                // THÊM MỚI
                dtJobs.Rows.Add(autoIncrementId++, txtTitle.Text, numQuantity.Value, cbStatus.SelectedItem?.ToString(), txtDescription.Text, txtRequirements.Text);
                MessageBox.Show("Đã thêm công việc mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // CẬP NHẬT
                DataRow[] rows = dtJobs.Select($"Mã = {currentJobId}");
                if (rows.Length > 0)
                {
                    rows[0]["Tiêu đề"] = txtTitle.Text;
                    rows[0]["Số lượng"] = numQuantity.Value;
                    rows[0]["Trạng thái"] = cbStatus.SelectedItem?.ToString() ?? "Open";
                    rows[0]["Mô tả"] = txtDescription.Text;
                    rows[0]["Yêu cầu"] = txtRequirements.Text;
                    MessageBox.Show("Đã cập nhật công việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
            ClearInputs();
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng bên lưới để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy dữ liệu từ dòng đang chọn và đổ ngược sang khung nhập liệu bên trái
            DataGridViewRow row = dgvJobs.SelectedRows[0];
            currentJobId = Convert.ToInt32(row.Cells["Mã"].Value);
            txtTitle.Text = row.Cells["Tiêu đề"].Value.ToString();
            numQuantity.Value = Convert.ToInt32(row.Cells["Số lượng"].Value);
            cbStatus.SelectedItem = row.Cells["Trạng thái"].Value.ToString();
            txtDescription.Text = row.Cells["Mô tả"].Value.ToString();
            txtRequirements.Text = row.Cells["Yêu cầu"].Value.ToString();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng bên lưới để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedId = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["Mã"].Value);
            string jobTitle = dgvJobs.SelectedRows[0].Cells["Tiêu đề"].Value.ToString() ?? "";

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa công việc:\n'{jobTitle}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (confirm == DialogResult.Yes)
            {
                DataRow[] rows = dtJobs.Select($"Mã = {selectedId}");
                if (rows.Length > 0)
                {
                    dtJobs.Rows.Remove(rows[0]);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                }
            }
        }
    }
}