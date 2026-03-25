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
        public MainForm()
        {
            InitializeComponent();
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

    public class CandidateManagementForm : Form
    {
        public CandidateManagementForm()
        {
            this.Text = "Quản lý Ứng viên";
            this.BackColor = Color.White;
            this.Controls.Add(new Label { Text = "Giao diện Lưu thông tin Ứng viên & Upload CV.", AutoSize = true, Location = new Point(50, 50), Font = new Font("Segoe UI", 12F) });
        }
    }

    public class ApplicationManagementForm : Form
    {
        public ApplicationManagementForm()
        {
            this.Text = "Quản lý Đơn Ứng Tuyển";
            this.BackColor = Color.White;
            this.Controls.Add(new Label { Text = "Giao diện duyệt Đơn, chuyển trạng thái Pending -> Hired.", AutoSize = true, Location = new Point(50, 50), Font = new Font("Segoe UI", 12F) });
        }
    }
}
