using RecruitmentCVScreening.WinForms.Business.Services;
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
using RecruitmentCVScreening.WinForms.Business.DTOs;
namespace RecruitmentCVScreening.WinForms.UI.Forms
{
    public partial class CandidateListForm : Form
    {
        public CandidateListForm()
        {
            InitializeComponent();
            InitGrid();
            InitDetailTextbox();
            InitUI();
            StyleDetailUI();
            RoundControl(groupBox1, 15);
        }
        private readonly ApplicationService _applicationService = new();

        private List<ApplicationDto> _allData = new List<ApplicationDto>();

        private void CandidateListForm_Load(object sender, EventArgs e)
        {
            LoadCandidates();
            SetRoundButton(btnReload, 20);
            SetRoundButton(btnSearch, 20);
            SetRoundButton(btnDelete, 20);
            LoadJobFilter();

        }
        private void InitGrid()
        {
            dgvCandidates.AutoGenerateColumns = false;
            dgvCandidates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCandidates.MultiSelect = false;
            dgvCandidates.ReadOnly = true;
            dgvCandidates.AllowUserToAddRows = false;
            dgvCandidates.Columns.Clear();

            dgvCandidates.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Hạng",
                DataPropertyName = "Rank",
                Width = 20
            });

            dgvCandidates.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Họ tên",
                DataPropertyName = "FullName",
                Width = 250
            });

            dgvCandidates.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 300
            });

            dgvCandidates.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "JobTitle",
                HeaderText = "Vị trí",
                DataPropertyName = "JobTitle"
            });

            dgvCandidates.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Điểm",
                DataPropertyName = "Score",
                Width = 100
            });

            dgvCandidates.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Kết quả",
                DataPropertyName = "Status",
                Width = 150
            });

            dgvCandidates.SelectionChanged += dgvCandidates_SelectionChanged;
        }

        private void InitDetailTextbox()
        {
            txtName.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtScore.ReadOnly = true;
            txtDecision.ReadOnly = true;
        }

        private void LoadCandidates()
        {
            _allData = _applicationService.GetCandidateScores();

            // Xếp hạng theo điểm
            var rankedList = _allData
                .OrderByDescending(x => x.Score)
                .Select((x, index) =>
                {
                    x.Rank = index + 1;
                    return x;
                })
                .ToList();

            dgvCandidates.DataSource = null; // tránh bug binding
            dgvCandidates.DataSource = rankedList;

            // Clear chi tiết nếu chưa chọn dòng
            ClearDetail();
        }

        private void dgvCandidates_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCandidates.CurrentRow?.DataBoundItem is ApplicationDto dto)
            {
                ShowDetail(dto);
            }
        }

        private void ShowDetail(ApplicationDto dto)
        {
            txtName.Text = dto.FullName;
            txtEmail.Text = dto.Email;
            txtScore.Text = dto.Score.ToString("0.##");
            txtDecision.Text = dto.Status;



        }

        private void ClearDetail()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtScore.Text = "";
            txtDecision.Text = "";

            txtEmail.ForeColor = Color.Black;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtSearchName.Text = "";
            LoadCandidates();
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void LoadJobFilter()
        {
            var jobs = _allData
                .Select(x => x.JobTitle)
                .Distinct()
                .ToList();

            jobs.Insert(0, "All..."); // thêm option ALL

            cmbJob.DataSource = jobs;
        }
        private void ApplyFilter()
        {
            string keyword = txtSearchName.Text.Trim().ToLower();
            string selectedJob = cmbJob.SelectedItem?.ToString();

            var filtered = _allData
                .Where(x =>
                    // 🔍 SEARCH
                    (string.IsNullOrEmpty(keyword) ||
                     (x.FullName != null && x.FullName.ToLower().Contains(keyword)))

                    // 🎯 JOB FILTER
                    &&
                    (selectedJob == "All..." || x.JobTitle == selectedJob)
                )
                .OrderByDescending(x => x.Score)
                .Select((x, index) =>
                {
                    x.Rank = index + 1;
                    return x;
                })
                .ToList();

            dgvCandidates.DataSource = null;
            dgvCandidates.DataSource = filtered;

            if (dgvCandidates.Rows.Count > 0)
            {
                var dto = dgvCandidates.Rows[0].DataBoundItem as ApplicationDto;
                if (dto != null)
                    ShowDetail(dto);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCandidates.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn ứng viên!");
                return;
            }

            var dto = dgvCandidates.CurrentRow.DataBoundItem as ApplicationDto;

            if (dto == null) return;

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa ứng viên:\n{dto.FullName}?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.No) return;

            try
            {
                _applicationService.DeleteApplication(dto.ApplicationId);

                MessageBox.Show("Xóa thành công!");

                // reload lại data
                LoadCandidates();
                LoadJobFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void InitUI()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);

            // ===== STYLE DATAGRIDVIEW CHUẨN =====
            dgvCandidates.BorderStyle = BorderStyle.None;
            dgvCandidates.BackgroundColor = Color.White;
            dgvCandidates.EnableHeadersVisualStyles = false;
            dgvCandidates.RowHeadersVisible = false;

            // ===== HEADER =====
            dgvCandidates.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvCandidates.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCandidates.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCandidates.ColumnHeadersHeight = 40;

            // ===== ROW =====
            dgvCandidates.DefaultCellStyle.BackColor = Color.White;
            dgvCandidates.DefaultCellStyle.ForeColor = Color.Black;
            dgvCandidates.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvCandidates.RowTemplate.Height = 35;

            // ===== XEN KẼ MÀU NHẸ =====
            dgvCandidates.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);

            // ===== SELECT =====
            dgvCandidates.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvCandidates.DefaultCellStyle.SelectionForeColor = Color.White;

            // ===== GRID LINE =====
            dgvCandidates.GridColor = Color.FromArgb(230, 230, 230);

            // ===== AUTO SIZE =====
            dgvCandidates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCandidates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCandidates.MultiSelect = false;
            dgvCandidates.ReadOnly = true;



            // ===== STYLE BUTTON =====
            btnReload.BackColor = Color.FromArgb(0, 120, 215);
            btnReload.ForeColor = Color.White;
            btnReload.FlatStyle = FlatStyle.Flat;
            btnReload.FlatAppearance.BorderSize = 0;
            btnReload.MouseEnter += (s, e) => btnReload.BackColor = Color.FromArgb(41, 128, 185);
            btnReload.MouseLeave += (s, e) => btnReload.BackColor = Color.FromArgb(0, 120, 215);



            btnSearch.BackColor = Color.FromArgb(39, 174, 96);
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderSize = 0;

            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;


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


        private void StyleDetailUI()
        {
            // 👉 Tên
            txtName.BorderStyle = BorderStyle.None;
            txtName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            txtName.BackColor = Color.White;

            // 👉 Email
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 11);
            txtEmail.ForeColor = Color.Gray;

            // 👉 Score (TO + ĐẸP)
            txtScore.BorderStyle = BorderStyle.None;
            txtScore.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            txtScore.ForeColor = Color.FromArgb(52, 152, 219); // xanh

            // 👉 Status (badge fake)
            txtDecision.BorderStyle = BorderStyle.None;
            txtDecision.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,

                Color.FromArgb(240, 242, 245),
                Color.FromArgb(220, 220, 220),


                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void RoundControl(Control control, int radius)
        {
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();

                control.Region = new Region(path);
            }
        }

        
    }

}
