namespace RecruitmentCVScreening.WinForms.UI.Forms
{
    partial class UploadCVForm
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
            grpCandidateInfo = new GroupBox();
            cboJobs = new ComboBox();
            label2 = new Label();
            txtEmail = new TextBox();
            txtFullName = new TextBox();
            lblemail = new Label();
            lblname = new Label();
            btnMenu = new Button();
            grpCV = new GroupBox();
            btnBrowse = new Button();
            txtCVPath = new TextBox();
            label1 = new Label();
            btnUpload = new Button();
            btnCancel = new Button();
            lblStatus = new Label();
            grpCandidateInfo.SuspendLayout();
            grpCV.SuspendLayout();
            SuspendLayout();
            // 
            // grpCandidateInfo
            // 
            grpCandidateInfo.Controls.Add(cboJobs);
            grpCandidateInfo.Controls.Add(label2);
            grpCandidateInfo.Controls.Add(txtEmail);
            grpCandidateInfo.Controls.Add(txtFullName);
            grpCandidateInfo.Controls.Add(lblemail);
            grpCandidateInfo.Controls.Add(lblname);
            grpCandidateInfo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpCandidateInfo.Location = new Point(0, 49);
            grpCandidateInfo.Name = "grpCandidateInfo";
            grpCandidateInfo.Size = new Size(1168, 262);
            grpCandidateInfo.TabIndex = 0;
            grpCandidateInfo.TabStop = false;
            grpCandidateInfo.Text = "Thông Tin Ứng Viên";
            // 
            // cboJobs
            // 
            cboJobs.FormattingEnabled = true;
            cboJobs.Location = new Point(155, 182);
            cboJobs.Name = "cboJobs";
            cboJobs.Size = new Size(250, 33);
            cboJobs.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 182);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 4;
            label2.Text = "Vị Trí Td :";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(155, 117);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(582, 31);
            txtEmail.TabIndex = 3;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(155, 51);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(582, 31);
            txtFullName.TabIndex = 2;
            // 
            // lblemail
            // 
            lblemail.AutoSize = true;
            lblemail.Location = new Point(63, 117);
            lblemail.Name = "lblemail";
            lblemail.Size = new Size(65, 25);
            lblemail.TabIndex = 1;
            lblemail.Text = "Email :";
            // 
            // lblname
            // 
            lblname.AutoSize = true;
            lblname.Location = new Point(63, 57);
            lblname.Name = "lblname";
            lblname.Size = new Size(79, 25);
            lblname.TabIndex = 0;
            lblname.Text = "Họ Tên :";
            // 
            // btnMenu
            // 
            btnMenu.Location = new Point(12, 2);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(67, 41);
            btnMenu.TabIndex = 5;
            btnMenu.Text = " ☰";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // grpCV
            // 
            grpCV.Controls.Add(btnBrowse);
            grpCV.Controls.Add(txtCVPath);
            grpCV.Controls.Add(label1);
            grpCV.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpCV.Location = new Point(0, 317);
            grpCV.Name = "grpCV";
            grpCV.Size = new Size(1168, 192);
            grpCV.TabIndex = 1;
            grpCV.TabStop = false;
            grpCV.Text = "CV Đính Kèm";
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(915, 77);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(158, 34);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = " 📁 Chọn File CV";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtCVPath
            // 
            txtCVPath.Location = new Point(155, 77);
            txtCVPath.Name = "txtCVPath";
            txtCVPath.Size = new Size(685, 31);
            txtCVPath.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 77);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 0;
            label1.Text = "File CV :";
            // 
            // btnUpload
            // 
            btnUpload.BackColor = SystemColors.HighlightText;
            btnUpload.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnUpload.ForeColor = SystemColors.ControlText;
            btnUpload.ImageAlign = ContentAlignment.MiddleLeft;
            btnUpload.Location = new Point(39, 543);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(160, 42);
            btnUpload.TabIndex = 2;
            btnUpload.Text = " 📤 Upload CV";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.HighlightText;
            btnCancel.Location = new Point(239, 543);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(117, 42);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblStatus.ForeColor = Color.SeaGreen;
            lblStatus.Location = new Point(737, 549);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 26);
            lblStatus.TabIndex = 4;
            lblStatus.Visible = false;
            // 
            // UploadCVForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 632);
            Controls.Add(btnMenu);
            Controls.Add(lblStatus);
            Controls.Add(btnCancel);
            Controls.Add(btnUpload);
            Controls.Add(grpCV);
            Controls.Add(grpCandidateInfo);
            Name = "UploadCVForm";
            Text = "UploadCVForm";
            Load += UploadCVForm_Load;
            grpCandidateInfo.ResumeLayout(false);
            grpCandidateInfo.PerformLayout();
            grpCV.ResumeLayout(false);
            grpCV.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpCandidateInfo;
        private GroupBox grpCV;
        private TextBox txtEmail;
        private TextBox txtFullName;
        private Label lblemail;
        private Label lblname;
        private TextBox txtCVPath;
        private Label label1;
        private Button btnBrowse;
        private Button btnUpload;
        private Button btnCancel;
        private Label lblStatus;
        private ComboBox cboJobs;
        private Label label2;
        private Button btnMenu;
    }
}