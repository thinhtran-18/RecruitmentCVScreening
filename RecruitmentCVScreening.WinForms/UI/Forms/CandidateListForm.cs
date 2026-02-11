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
        }
        private readonly ApplicationService _applicationService = new();

        private void CandidateListForm_Load(object sender, EventArgs e)
        {
            LoadCandidates();
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
                Width = 60
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
            List<ApplicationDto> list = _applicationService.GetCandidateScores();

            // Xếp hạng theo điểm
            var rankedList = list
                .OrderByDescending(x => x.Score)
                .Select((x, index) =>
                {
                    x.Rank = index + 1;
                    return x;
                })
                .ToList();

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
            LoadCandidates();
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
