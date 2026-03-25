using RecruitmentCVScreening.WinForms.Business.Services;
using RecruitmentCVScreening.WinForms.Core.Models;
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
    public partial class MainForm : Form
    {
        private Panel panelSidebar, panelHeader, panelDesktop; private Label lblTitle; private Button btnDashboard, btnManageJobs, btnManageCandidates, btnManageApplications, btnExit;

        private Form currentChildForm;
        public MainForm()
        {
            // 1. Gọi hàm này để giữ cho Visual Studio Designer không bị lỗi (nó nằm trong file MainForm.Designer.cs)
            InitializeComponent();
            BuildCustomUI();
        }

        // Đổi tên từ InitializeComponent thành BuildCustomUI để tránh xung đột (Lỗi CS0111)
        private void BuildCustomUI()
        {
            this.panelSidebar = new Panel();
            this.panelHeader = new Panel();
            this.panelDesktop = new Panel();
            this.lblTitle = new Label();
            this.btnDashboard = new Button();
            this.btnManageJobs = new Button();
            this.btnManageCandidates = new Button();
            this.btnManageApplications = new Button();
            this.btnExit = new Button();

            // Cấu hình Form chính
            this.Text = "Hệ Thống Quản Lý Tuyển Dụng  - Nhóm 4";
            this.Size = new Size(1700, 820);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            // panelSidebar
            this.panelSidebar.BackColor = Color.FromArgb(44, 62, 80);
            this.panelSidebar.Dock = DockStyle.Left;
            this.panelSidebar.Width = 250;

            this.panelSidebar.Controls.Add(this.btnExit);
            this.panelSidebar.Controls.Add(this.btnManageApplications);
            this.panelSidebar.Controls.Add(this.btnManageCandidates);
            this.panelSidebar.Controls.Add(this.btnManageJobs);
            this.panelSidebar.Controls.Add(this.btnDashboard);

            // Định dạng Nút bấm
            Button[] menuButtons = { btnDashboard, btnManageJobs, btnManageCandidates, btnManageApplications, btnExit };
            foreach (Button btn in menuButtons)
            {
                btn.Dock = DockStyle.Top;
                btn.Height = 120;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Padding = new Padding(20, 0, 0, 0);
                btn.Cursor = Cursors.Hand;
            }

            this.btnDashboard.Text = "📊 Giao Diện Chính";
            this.btnDashboard.Click += (s, e) => OpenChildForm(new DashboardForm());

            this.btnManageJobs.Text = "💼 Quản Lý Vị Trí";
            this.btnManageJobs.Click += (s, e) => OpenChildForm(new JobManagementForm());

            this.btnManageCandidates.Text = "🧑‍💻 Quản Lý Ứng Viên";
            this.btnManageCandidates.Click += (s, e) => OpenChildForm(new CandidateListForm());

            this.btnManageApplications.Text = "📝 Đơn Ứng Tuyển";
            this.btnManageApplications.Click += (s, e) => OpenChildForm(new UploadCVForm());

            this.btnExit.Text = "🚪 Thoát Hệ Thống";
            this.btnExit.Dock = DockStyle.Bottom;
            this.btnExit.BackColor = Color.FromArgb(192, 57, 43);

            // Khắc phục lỗi CS0104: Gọi tường minh System.Windows.Forms.Application
            this.btnExit.Click += (s, e) => System.Windows.Forms.Application.Exit();

            // panelHeader
            this.panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 80;
            this.panelHeader.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ TUYỂN DỤNG ";
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // panelDesktop
            this.panelDesktop.Dock = DockStyle.Fill;
            this.panelDesktop.BackColor = Color.White;

            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            lblTitle.Text = childForm.Text.ToUpper();
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }
    }

    /* =========================================================================
     * CÁC CLASS GIẢ LẬP (MOCK FORMS) ĐỂ CHẠY THỬ
     * Nhóm trưởng phân công cho các thành viên tạo các Form thật, sau đó xóa
* các class này đi. Giao diện chính sẽ tự động liên kết với Form thật.
     * ========================================================================= */
    public class DashboardForm : Form
    {
        public DashboardForm()
        {
            this.Text = "Giao diện chính - Thống kê";
            this.BackColor = Color.White;
            this.Controls.Add(new Label { Text = "Đây là khu vực hiển thị các Biểu đồ thống kê.", AutoSize = true, Location = new Point(50, 50), Font = new Font("Segoe UI", 12F) });
        }
    }
    public class JobManagementForm : Form
    {
        public JobManagementForm()
        {
            this.Text = "Quản lý Vị trí Tuyển dụng";
            this.BackColor = Color.White;
            this.Controls.Add(new Label { Text = "Giao diện Thêm/Sửa/Xóa Vị trí Tuyển dụng.", AutoSize = true, Location = new Point(50, 50), Font = new Font("Segoe UI", 12F) });
        }
    }

    
  }