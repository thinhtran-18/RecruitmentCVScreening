using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecruitmentCVScreening.WinForms.Business.Services;

namespace RecruitmentCVScreening.WinForms.UI.Forms
{
    public partial class ApplicationsForm : Form
    {
        private readonly ApplicationService _service = new ApplicationService();
        private readonly JobService _jobService = new JobService(); // Để load danh sách Job vào ComboBox lọc
        public ApplicationsForm()
        {
            InitializeComponent();
        }

        private void ApplicationsForm_Load(object sender, EventArgs e)
        {
            SetupComboBoxes();
            LoadData();
        }

        private void SetupComboBoxes()
        {
            // 1. Load trạng thái lọc
            cboStatusFilter.Items.Clear();
            cboStatusFilter.Items.AddRange(new object[] { "All", "Pending", "Interviewed", "Rejected", "Hired" });
            cboStatusFilter.SelectedIndex = 0;

            // 2. Load trạng thái để cập nhật
            cboNewStatus.Items.Clear();
            cboNewStatus.Items.AddRange(new object[] { "Pending", "Interviewed", "Rejected", "Hired" });

            // 3. Load danh sách Jobs vào bộ lọc (Sử dụng JobService có sẵn của thành viên khác)
            try
            {
                var jobs = _jobService.GetAll();
                // Thêm một lựa chọn "Tất cả công việc"
                jobs.Insert(0, new Core.Models.Job { Id = 0, Title = "-- Tất cả công việc --" });
                cboJobFilter.DataSource = jobs;
                cboJobFilter.DisplayMember = "Title";
                cboJobFilter.ValueMember = "Id";
            }
            catch { /* Xử lý nếu JobService chưa xong */ }
        }

        private void LoadData()
        {
            try
            {
                int? jobId = null;
                if (cboJobFilter.SelectedValue != null && (int)cboJobFilter.SelectedValue > 0)
                {
                    jobId = (int)cboJobFilter.SelectedValue;
                }

                string status = cboStatusFilter.SelectedItem?.ToString() ?? "All";

                var list = _service.GetList(jobId, status);
                dgvApplications.DataSource = list;

                // Cấu hình hiển thị DataGridView
                if (dgvApplications.Columns["ApplicationId"] != null) dgvApplications.Columns["ApplicationId"].HeaderText = "ID";
                if (dgvApplications.Columns["FullName"] != null) dgvApplications.Columns["FullName"].HeaderText = "Ứng viên";
                if (dgvApplications.Columns["JobTitle"] != null) dgvApplications.Columns["JobTitle"].HeaderText = "Vị trí";
                if (dgvApplications.Columns["Score"] != null) dgvApplications.Columns["Score"].HeaderText = "Điểm số";

                // Ẩn các cột ID phụ
                string[] hideCols = { "JobId", "CandidateId" };
                foreach (var col in hideCols)
                {
                    if (dgvApplications.Columns[col] != null) dgvApplications.Columns[col].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvApplications.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật!");
                return;
            }

            if (cboNewStatus.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái mới!");
                return;
            }

            int id = (int)dgvApplications.CurrentRow.Cells["ApplicationId"].Value;
            string status = cboNewStatus.SelectedItem.ToString();

            if (_service.UpdateStatus(id, status))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e) => LoadData();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtJobId.Text, out int jId) && int.TryParse(txtCandidateId.Text, out int cId))
            {
                if (_service.Create(jId, cId))
                {
                    MessageBox.Show("Thêm đơn mới thành công!");
                    txtJobId.Clear(); txtCandidateId.Clear();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại. Hãy kiểm tra lại ID!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ID là số hợp lệ!");
            }
        }

        private void cboNewStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
