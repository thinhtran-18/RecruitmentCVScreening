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
            // 1. Gọi hàm này để giữ cho Visual Studio Designer không bị lỗi (nằm trong file MainForm.Designer.cs)
            InitializeComponent();
            BuildCustomUI();
        }




        private void BuildCustomUI()
        {
            this.panelSidebar = new Panel();
            this.panelHeader = new Panel();
            this.panelDesktop = new Panel();
            this.lblTitle = new Label();
            this.btnDashboard = new Button();
            this.btnManageJobs = new Button();
            this.btnManageCandidates = new Button();
            this.btnExit = new Button();

            // Cấu hình Form chính
            this.Text = "Hệ Thống Quản Lý Tuyển Dụng HR - Nhóm 5";
            this.Size = new Size(1700, 820);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            // panelSidebar
            this.panelSidebar.BackColor = Color.FromArgb(44, 62, 80);
            this.panelSidebar.Dock = DockStyle.Left;
            this.panelSidebar.Width = 250;

            // Thứ tự thêm vào cực kỳ quan trọng đối với DockStyle.Top (Thêm sau cùng sẽ nằm trên cùng)
            this.panelSidebar.Controls.Add(this.btnExit);                // Nằm dưới cùng (Dock.Bottom)
            this.panelSidebar.Controls.Add(this.btnManageCandidates);    // Nằm ở vị trí thứ 3
            this.panelSidebar.Controls.Add(this.btnManageJobs);          // Nằm ở vị trí thứ 2
            this.panelSidebar.Controls.Add(this.btnDashboard);           // Nằm ở vị trí thứ 1

            // Tạo một khoảng trống (Spacer) để đẩy các nút lùi xuống dưới cho thoáng mắt
            Panel panelSpacer = new Panel();
            panelSpacer.Dock = DockStyle.Top;
            panelSpacer.Height = 120; // Giãn từ trên xuống 120 pixel
            this.panelSidebar.Controls.Add(panelSpacer); // Thêm vào cuối cùng nên nó sẽ chiếm vị trí cao nhất

            // Định dạng Nút bấm
            Button[] menuButtons = { btnDashboard, btnManageJobs, btnManageCandidates, btnExit };
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
            // this.btnExit.Dock = DockStyle.Bottom; // Nút Thoát luôn nằm dưới cùng
            this.btnExit.BackColor = Color.FromArgb(192, 57, 43); // Giữ màu đỏ cho nút thoát
            this.btnExit.Click += (s, e) => System.Windows.Forms.Application.Exit();

            // panelHeader (Điều chỉnh màu tự nhiên hơn)
            this.panelHeader.BackColor = Color.SteelBlue; // Sử dụng màu Xanh thép (SteelBlue) rất tự nhiên và dịu mắt
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 120;
            this.panelHeader.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ TUYỂN DỤNG";
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
     * ========================================================================= */

    // YÊU CẦU 3: Thêm ảnh minh họa vào giao diện chính
    public class DashboardForm : Form
    {
        public DashboardForm()
        {
            this.Text = "Giao diện chính - Thống kê";
            this.BackColor = Color.White;

            // Tạo tiêu đề chào mừng
            Label lblWelcome = new Label
            {
                Text = "CHÀO MỪNG ĐẾN VỚI HỆ THỐNG QUẢN LÝ TUYỂN DỤNG",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 120
            };

            // Tạo khung chứa ảnh
            PictureBox picIllustration = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom, // Tự động thu phóng ảnh giữ nguyên tỷ lệ
                BackColor = Color.White
            };

            // Tải ảnh minh họa mảng HR/Tuyển dụng từ Internet
            try
            {
                // SỬA ĐƯỜNG DẪN NÀY TRÙNG VỚI NƠI LƯU ẢNH TRÊN MÁY!
                // Nhớ giữ nguyên ký tự @ ở đầu chuỗi.
                string imagePath = @"C:\Users\Admin\OneDrive\Hình ảnh\Camera Roll\anhdaidien.jpg";
                picIllustration.Image = Image.FromFile(imagePath);
            }
            catch
            {
                // Bỏ qua nếu không tìm thấy đường dẫn ảnh
            }

            // Thêm vào Form (Thêm PictureBox trước để nó chiếm phần Fill còn lại)
            this.Controls.Add(picIllustration);
            this.Controls.Add(lblWelcome);
        }
    }
    // THÊM CLASS NÀY VÀO:
    // Class tùy chỉnh giúp ép WinForms hiển thị ảnh với chất lượng cao nhất (Khử răng cưa, làm mịn ảnh)
    public class HighQualityPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pe.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            pe.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            base.OnPaint(pe);
        }
    }

    public class JobManagementForm : Form
    {
        public JobManagementForm()
        {
            this.Text = "Quản lý Vị trí Tuyển dụng";
            this.BackColor = Color.White;
            this.Controls.Add(new Label { Text = "Giao diện Thêm/Sửa/Xóa Vị trí Tuyển dụng", AutoSize = true, Location = new Point(50, 50), Font = new Font("Segoe UI", 12F) });
        }
    }

    
    }
}
