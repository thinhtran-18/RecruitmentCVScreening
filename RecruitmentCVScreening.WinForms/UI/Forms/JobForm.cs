using Microsoft.Data.SqlClient;
using RecruitmentCVScreening.WinForms.Data.Connection;
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
        // Bỏ DataTable ảo đi, chỉ giữ lại biến lưu Id hiện tại
        private int currentJobId = 0;

        // UI Controls - Khu vực nhập liệu (Bên trái)
        private Panel panelInput = null!;
        private TextBox txtTitle = null!;
        private TextBox txtRequiredSkills = null!;     // Đổi tên biến cho khớp DB (RequiredSkills)
        private NumericUpDown numMinExperience = null!; // Đổi tên biến cho khớp DB (MinExperience)
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
            BuildUI();
            LoadData(); // Gọi hàm load dữ liệu thật từ SQL
        }

        private void BuildUI()
        {
            this.Text = "Quản lý Vị trí Tuyển dụng";
            this.BackColor = Color.FromArgb(245, 246, 250); // Màu nền sáng hiện đại

            // --- Cấu hình hiển thị giữa màn hình với kích thước to ---
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
                Width = 450,
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
            int spacing = 80;
            int inputWidth = 410;

            // CỘT 1: Tiêu đề (Title)
            panelInput.Controls.Add(new Label { Text = "Tiêu đề công việc (*):", Location = new Point(20, startY), AutoSize = true });
            txtTitle = new TextBox { Location = new Point(20, startY + 25), Width = inputWidth };
            panelInput.Controls.Add(txtTitle);

            // CỘT 2: Kinh nghiệm tối thiểu (MinExperience)
            startY += spacing;
            panelInput.Controls.Add(new Label { Text = "Kinh nghiệm tối thiểu (Năm):", Location = new Point(20, startY), AutoSize = true });
            numMinExperience = new NumericUpDown { Location = new Point(20, startY + 25), Width = 150, Minimum = 0, Maximum = 50 };
            panelInput.Controls.Add(numMinExperience);

            // CỘT 3: Yêu cầu kỹ năng (RequiredSkills)
            startY += spacing;
            panelInput.Controls.Add(new Label { Text = "Yêu cầu kỹ năng (*):", Location = new Point(20, startY), AutoSize = true });
            // Cho ô TextBox này cao hẳn lên để nhập được nhiều kỹ năng
            txtRequiredSkills = new TextBox { Location = new Point(20, startY + 25), Width = inputWidth, Height = 150, Multiline = true, ScrollBars = ScrollBars.Vertical };
            panelInput.Controls.Add(txtRequiredSkills);

            // CỘT 4: Các nút chức năng
            startY += 190;
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
            Panel topGridPanel = new Panel { Dock = DockStyle.Top, Height = 65 };

            btnAddNew = new Button { Text = "➕ Thêm Mới", Location = new Point(0, 10), Width = 130, Height = 45, BackColor = Color.FromArgb(40, 167, 69), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnAddNew.FlatAppearance.BorderSize = 0;
            btnAddNew.Click += (s, e) => ClearInputs();

            btnEdit = new Button { Text = "✏️ Sửa Lựa Chọn", Location = new Point(140, 10), Width = 150, Height = 45, BackColor = Color.FromArgb(23, 162, 184), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Click += BtnEdit_Click;

            btnDelete = new Button { Text = "🗑️ Xóa Lựa Chọn", Location = new Point(300, 10), Width = 150, Height = 45, BackColor = Color.FromArgb(220, 53, 69), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
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
                RowHeadersVisible = false,
                RowTemplate = { Height = 45 },
                AlternatingRowsDefaultCellStyle = { BackColor = Color.FromArgb(240, 240, 240) }
            };
            panelGrid.Controls.Add(dgvJobs);

            // Lệnh này ép DataGridView lùi lại nhường chỗ cho Top Panel, không bị chồng đè lên nhau nữa
            dgvJobs.BringToFront();
            // Thêm 2 Panel vào Form (Lưu ý: Thêm Fill trước, Left sau)
            this.Controls.Add(panelGrid);
            this.Controls.Add(panelInput);
        }

        // ==========================================
        // 3. LOGIC XỬ LÝ GIAO DIỆN VÀ DATABASE THẬT
        // ==========================================

        // Hàm Tải dữ liệu từ SQL Server (Đã CẬP NHẬT theo Database mới)
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = AppDbContext.GetConnection())
                {
                    conn.Open();
                    // Đã sửa câu truy vấn đúng với 4 cột trong DB của bạn
                    string query = "SELECT Id AS [Mã], Title AS [Tiêu đề công việc], RequiredSkills AS [Kỹ năng yêu cầu], MinExperience AS [KN tối thiểu (Năm)] FROM Jobs ORDER BY Id DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvJobs.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            currentJobId = 0;
            txtTitle.Text = "";
            txtRequiredSkills.Text = "";
            numMinExperience.Value = 0;
            txtTitle.Focus();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtRequiredSkills.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tiêu đề và Yêu cầu kỹ năng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = AppDbContext.GetConnection())
                {
                    conn.Open();
                    string query = "";

                    if (currentJobId == 0) // THÊM MỚI
                    {
                        query = "INSERT INTO Jobs (Title, RequiredSkills, MinExperience) VALUES (@Title, @RequiredSkills, @MinExperience)";
                    }
                    else // CẬP NHẬT
                    {
                        query = "UPDATE Jobs SET Title=@Title, RequiredSkills=@RequiredSkills, MinExperience=@MinExperience WHERE Id=@Id";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@RequiredSkills", txtRequiredSkills.Text);
                    cmd.Parameters.AddWithValue("@MinExperience", numMinExperience.Value);

                    if (currentJobId != 0)
                    {
                        cmd.Parameters.AddWithValue("@Id", currentJobId);
                    }

                    cmd.ExecuteNonQuery();

                    string action = currentJobId == 0 ? "thêm" : "cập nhật";
                    MessageBox.Show($"Đã {action} công việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearInputs();
            LoadData(); // Cập nhật lại lưới sau khi lưu
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
            txtTitle.Text = row.Cells["Tiêu đề công việc"].Value.ToString();
            txtRequiredSkills.Text = row.Cells["Kỹ năng yêu cầu"].Value.ToString();

            // Xử lý cẩn thận nếu cột kinh nghiệm bị NULL trong DB
            if (row.Cells["KN tối thiểu (Năm)"].Value != DBNull.Value)
            {
                numMinExperience.Value = Convert.ToInt32(row.Cells["KN tối thiểu (Năm)"].Value);
            }
            else
            {
                numMinExperience.Value = 0;
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng bên lưới để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedId = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["Mã"].Value);
            string jobTitle = dgvJobs.SelectedRows[0].Cells["Tiêu đề công việc"].Value.ToString() ?? "";

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa công việc:\n'{jobTitle}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = AppDbContext.GetConnection())
                    {
                        conn.Open();
                        string query = "DELETE FROM Jobs WHERE Id = @Id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Id", selectedId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadData(); // Cập nhật lại lưới sau khi xóa
                }
                catch (Exception ex)
                {
                    // Bắt lỗi nếu công việc này đã có ứng viên nộp đơn (vướng khóa ngoại)
                    MessageBox.Show("Lỗi xóa dữ liệu (Có thể vị trí này đang có người ứng tuyển): \n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}