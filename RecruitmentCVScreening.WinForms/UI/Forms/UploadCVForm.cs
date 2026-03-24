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
using System.Drawing.Drawing2D;
namespace RecruitmentCVScreening.WinForms.UI.Forms
{
    public partial class UploadCVForm : Form
    {
        public UploadCVForm()
        {
            InitializeComponent();
            _applicationService = new ApplicationService();
            LoadJobs();
            StylePrimaryButton(btnUpload);
            StyleSecondaryButton(btnCancel);
            StyleThirButton(btnBrowse);
            StyleFourButton(btnMenu);
            SetupUX();
        }
        private string _cvPath;

        private readonly ApplicationService _applicationService;
        private readonly JobService _jobService = new();

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "CV files (*.docx;*.pdf)|*.docx;*.pdf";
            dlg.Title = "Chọn file CV";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _cvPath = dlg.FileName;
                txtCVPath.Text = Path.GetFileName(_cvPath);
            }
        }

        private void SetupUX() //nâng cấp giao diện của groupbõ chọn file từ máy
        {
            txtCVPath.Text = "Chưa chọn file...";
            txtCVPath.ForeColor = Color.Gray;

            btnUpload.MouseEnter += (s, e) =>
            {
                btnUpload.BackColor = Color.FromArgb(30, 144, 255);
            };

            btnUpload.MouseLeave += (s, e) =>
            {
                btnUpload.BackColor = Color.FromArgb(0, 120, 215);
            };
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;
            Job selectedJob = cboJobs.SelectedItem as Job;

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn upload CV không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;


            if (selectedJob == null)
            {
                MessageBox.Show("Vui lòng chọn vị trí tuyển dụng");
                return;
            }

            try
            {
                // Gọi ApplicationService (bạn đã có)
                _applicationService.UploadAndProcessCV(
                    txtFullName.Text.Trim(),
                    txtEmail.Text.Trim(),
                    _cvPath,
                    selectedJob
                );

                lblStatus.Text = "✔ Upload CV thành công!";
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Green;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên ứng viên");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email");
                return false;
            }

            if (string.IsNullOrEmpty(_cvPath))
            {
                MessageBox.Show("Vui lòng chọn file CV");
                return false;
            }

            return true;
        }
        private void LoadJobs()
        {
            var jobs = _jobService.GetAll(); // lấy từ DB

            if (jobs == null || jobs.Count == 0)
            {
                MessageBox.Show("Chưa có vị trí tuyển dụng nào");
                return;
            }

            cboJobs.DataSource = jobs;
            cboJobs.DisplayMember = "Title"; // Job.Title
            cboJobs.ValueMember = "Id";      // Job.Id
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
        "Bạn có chắc muốn xoá toàn bộ dữ liệu?",
        "Xác nhận",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
    );

            if (result == DialogResult.Yes)
            {
                txtFullName.Text = "";
                txtEmail.Text = "";
                txtCVPath.Text = "";
                cboJobs.SelectedIndex = -1;
                txtFullName.Focus();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

        }

        
        private void StylePrimaryButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(0, 120, 215);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Height = 40;
        }

        private void StyleSecondaryButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(231, 76, 60);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

        }
        private void StyleThirButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(39, 174, 96);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

        }
        private void StyleFourButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(0, 120, 215);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

        }
        void SetRoundButton(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            btn.Region = new Region(path);
        }
        private void UploadCVForm_Load(object sender, EventArgs e)
        {
            SetRoundButton(btnUpload, 20);
            SetRoundButton(btnCancel, 20);
            SetRoundButton(btnMenu, 20);
            SetRoundButton(btnBrowse, 20);
        }
    }

}
