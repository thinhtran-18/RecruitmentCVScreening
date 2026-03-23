namespace RecruitmentCVScreening.WinForms.UI.Forms
{
    partial class CandidateListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvCandidates = new DataGridView();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtDecision = new TextBox();
            txtScore = new TextBox();
            txtEmail = new TextBox();
            txtName = new TextBox();
            btnReload = new Button();
            btnBack = new Button();
            txtSearchName = new TextBox();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCandidates).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCandidates
            // 
            dgvCandidates.AllowUserToAddRows = false;
            dgvCandidates.AllowUserToDeleteRows = false;
            dgvCandidates.BackgroundColor = SystemColors.Window;
            dgvCandidates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCandidates.Location = new Point(12, 84);
            dgvCandidates.Name = "dgvCandidates";
            dgvCandidates.ReadOnly = true;
            dgvCandidates.RowHeadersWidth = 62;
            dgvCandidates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCandidates.Size = new Size(931, 489);
            dgvCandidates.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.BackgroundImageLayout = ImageLayout.Stretch;
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtDecision);
            groupBox1.Controls.Add(txtScore);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtName);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(973, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(458, 561);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chi Tiết Ứng Viên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 371);
            label4.Name = "label4";
            label4.Size = new Size(88, 25);
            label4.TabIndex = 7;
            label4.Text = "Kết Quả :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 278);
            label3.Name = "label3";
            label3.Size = new Size(65, 25);
            label3.TabIndex = 6;
            label3.Text = "Điểm :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 175);
            label2.Name = "label2";
            label2.Size = new Size(65, 25);
            label2.TabIndex = 5;
            label2.Text = "Email :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 91);
            label1.Name = "label1";
            label1.Size = new Size(79, 25);
            label1.TabIndex = 4;
            label1.Text = "Họ Tên :";
            // 
            // txtDecision
            // 
            txtDecision.BackColor = SystemColors.ButtonHighlight;
            txtDecision.Location = new Point(117, 365);
            txtDecision.Name = "txtDecision";
            txtDecision.ReadOnly = true;
            txtDecision.Size = new Size(141, 31);
            txtDecision.TabIndex = 3;
            // 
            // txtScore
            // 
            txtScore.BackColor = SystemColors.ButtonHighlight;
            txtScore.Location = new Point(117, 272);
            txtScore.Name = "txtScore";
            txtScore.ReadOnly = true;
            txtScore.Size = new Size(141, 31);
            txtScore.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = SystemColors.ButtonHighlight;
            txtEmail.Location = new Point(117, 169);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(326, 31);
            txtEmail.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.BackColor = SystemColors.ButtonHighlight;
            txtName.Location = new Point(117, 85);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(326, 31);
            txtName.TabIndex = 0;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(1148, 629);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(146, 49);
            btnReload.TabIndex = 2;
            btnReload.Text = " 🔄  Tải Lại ";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(23, 28);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(65, 40);
            btnBack.TabIndex = 3;
            btnBack.Text = " ☰  Menu";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // txtSearchName
            // 
            txtSearchName.Location = new Point(263, 28);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.Size = new Size(680, 31);
            txtSearchName.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(107, 31);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(132, 34);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "🔍 Tìm Kiếm ";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // CandidateListForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1467, 734);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchName);
            Controls.Add(btnBack);
            Controls.Add(btnReload);
            Controls.Add(groupBox1);
            Controls.Add(dgvCandidates);
            DoubleBuffered = true;
            Name = "CandidateListForm";
            Text = "CandidateListForm";
            Load += CandidateListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCandidates).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCandidates;
        private GroupBox groupBox1;
        private Button btnReload;
        private Button btnBack;
        private TextBox txtDecision;
        private TextBox txtScore;
        private TextBox txtEmail;
        private TextBox txtName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtSearchName;
        private Button btnSearch;
    }
}