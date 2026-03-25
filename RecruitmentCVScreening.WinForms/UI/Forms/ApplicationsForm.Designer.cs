namespace RecruitmentCVScreening.WinForms.UI.Forms
{
    partial class ApplicationsForm
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
            cboStatusFilter = new ComboBox();
            cboNewStatus = new ComboBox();
            btnFilter = new Button();
            btnUpdateStatus = new Button();
            btnAdd = new Button();
            dgvApplications = new DataGridView();
            cboJobFilter = new ComboBox();
            txtJobId = new TextBox();
            txtCandidateId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvApplications).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // cboStatusFilter
            // 
            cboStatusFilter.FormattingEnabled = true;
            cboStatusFilter.Location = new Point(255, 78);
            cboStatusFilter.Name = "cboStatusFilter";
            cboStatusFilter.Size = new Size(382, 28);
            cboStatusFilter.TabIndex = 0;
            cboStatusFilter.Text = "Lọc theo trạng thái";
            // 
            // cboNewStatus
            // 
            cboNewStatus.FormattingEnabled = true;
            cboNewStatus.Location = new Point(255, 131);
            cboNewStatus.Name = "cboNewStatus";
            cboNewStatus.Size = new Size(382, 28);
            cboNewStatus.TabIndex = 1;
            cboNewStatus.Text = "Cập nhật trạng thái đơn";
            cboNewStatus.SelectedIndexChanged += cboNewStatus_SelectedIndexChanged;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(959, 115);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(94, 64);
            btnFilter.TabIndex = 2;
            btnFilter.Text = "Lọc";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.Location = new Point(1088, 115);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(94, 62);
            btnUpdateStatus.TabIndex = 3;
            btnUpdateStatus.Text = "Cập Nhật";
            btnUpdateStatus.UseVisualStyleBackColor = true;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(824, 115);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 62);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvApplications
            // 
            dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplications.Location = new Point(49, 360);
            dgvApplications.Name = "dgvApplications";
            dgvApplications.RowHeadersWidth = 51;
            dgvApplications.Size = new Size(1237, 342);
            dgvApplications.TabIndex = 5;
            // 
            // cboJobFilter
            // 
            cboJobFilter.FormattingEnabled = true;
            cboJobFilter.Location = new Point(255, 28);
            cboJobFilter.Name = "cboJobFilter";
            cboJobFilter.Size = new Size(382, 28);
            cboJobFilter.TabIndex = 6;
            cboJobFilter.Text = "Lọc theo công việc";
            // 
            // txtJobId
            // 
            txtJobId.Location = new Point(306, 274);
            txtJobId.Name = "txtJobId";
            txtJobId.Size = new Size(331, 27);
            txtJobId.TabIndex = 7;
            // 
            // txtCandidateId
            // 
            txtCandidateId.Location = new Point(306, 210);
            txtCandidateId.Name = "txtCandidateId";
            txtCandidateId.Size = new Size(331, 27);
            txtCandidateId.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 217);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 9;
            label1.Text = "Thêm đơn mới";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(213, 213);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 10;
            label2.Text = "ID Ứng viên";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(249, 277);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 11;
            label3.Text = "Job ID";
            // 
            // panel1
            // 
            panel1.Location = new Point(38, 199);
            panel1.Name = "panel1";
            panel1.Size = new Size(623, 132);
            panel1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGreen;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(38, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(623, 167);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightBlue;
            panel3.Location = new Point(786, 78);
            panel3.Name = "panel3";
            panel3.Size = new Size(442, 139);
            panel3.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(78, 19);
            label4.Name = "label4";
            label4.Size = new Size(133, 20);
            label4.TabIndex = 13;
            label4.Text = "Lọc theo công việc";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(77, 69);
            label5.Name = "label5";
            label5.Size = new Size(134, 20);
            label5.TabIndex = 14;
            label5.Text = "Lọc theo trạng thái";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 125);
            label6.Name = "label6";
            label6.Size = new Size(166, 20);
            label6.TabIndex = 15;
            label6.Text = "Cập nhật trạng thái đơn";
            // 
            // ApplicationsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1338, 729);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCandidateId);
            Controls.Add(txtJobId);
            Controls.Add(cboJobFilter);
            Controls.Add(dgvApplications);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdateStatus);
            Controls.Add(btnFilter);
            Controls.Add(cboNewStatus);
            Controls.Add(cboStatusFilter);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ApplicationsForm";
            Text = "ApplicationsForm";
            Load += ApplicationsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvApplications).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboStatusFilter;
        private ComboBox cboNewStatus;
        private Button btnFilter;
        private Button btnUpdateStatus;
        private Button btnAdd;
        private DataGridView dgvApplications;
        private ComboBox cboJobFilter;
        private TextBox txtJobId;
        private TextBox txtCandidateId;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}