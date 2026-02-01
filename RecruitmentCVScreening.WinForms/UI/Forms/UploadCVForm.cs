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
    public partial class UploadCVForm : Form
    {
        public UploadCVForm()
        {
            InitializeComponent();
            _applicationService = new ApplicationService();
            LoadJobs();
        }
        private string _cvPath;

        private readonly ApplicationService _applicationService;
        private readonly JobService _jobService = new();

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "CV files (*.docx;*.pdf)|*.docx;*.pdf";
            dlg.Title = "Chọn file CV";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _cvPath = dlg.FileName;
                txtCVPath.Text = _cvPath;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;
            Job selectedJob = cboJobs.SelectedItem as Job;

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

        private void UploadCVForm_Load(object sender, EventArgs e)
        {

        }
    }
}
