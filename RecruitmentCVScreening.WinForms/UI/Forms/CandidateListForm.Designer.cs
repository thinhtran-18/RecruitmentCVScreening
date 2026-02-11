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
            dgvCandidates.Location = new Point(12, 12);
            dgvCandidates.Name = "dgvCandidates";
            dgvCandidates.ReadOnly = true;
            dgvCandidates.RowHeadersWidth = 62;
            dgvCandidates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCandidates.Size = new Size(942, 564);
            dgvCandidates.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtDecision);
            groupBox1.Controls.Add(txtScore);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtName);
            groupBox1.Location = new Point(988, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(479, 564);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chi Tiết Ứng Viên";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 371);
            label4.Name = "label4";
            label4.Size = new Size(84, 25);
            label4.TabIndex = 7;
            label4.Text = "Kết Quả :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 272);
            label3.Name = "label3";
            label3.Size = new Size(63, 25);
            label3.TabIndex = 6;
            label3.Text = "Điểm :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 175);
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 5;
            label2.Text = "Email :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 85);
            label1.Name = "label1";
            label1.Size = new Size(76, 25);
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
            txtDecision.TextChanged += textBox4_TextChanged;
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
            btnReload.Location = new Point(1038, 639);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(112, 34);
            btnReload.TabIndex = 2;
            btnReload.Text = "Tải Lại";
            btnReload.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(1293, 639);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 3;
            btnBack.Text = "Menu";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // CandidateListForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1467, 734);
            Controls.Add(btnBack);
            Controls.Add(btnReload);
            Controls.Add(groupBox1);
            Controls.Add(dgvCandidates);
            Name = "CandidateListForm";
            Text = "CandidateListForm";
            Load += CandidateListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCandidates).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
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
    }
}