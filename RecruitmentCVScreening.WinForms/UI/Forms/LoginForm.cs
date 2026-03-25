using Microsoft.Data.SqlClient;
using RecruitmentCVScreening.WinForms.Data.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecruitmentCVScreening.WinForms.UI.Forms
{
    public partial class LoginForm : Form

    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Đoạn code bo tròn góc Form
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, 15, 15, 180, 90); // Top-left
            path.AddArc(this.Width - 15, 0, 15, 15, 270, 90); // Top-right
            path.AddArc(this.Width - 15, this.Height - 15, 15, 15, 0, 90); // Bottom-right
            path.AddArc(0, this.Height - 15, 15, 15, 90, 90); // Bottom-left
            this.Region = new Region(path);
        }

        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            // Bo 4 góc
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Điều kiện đăng nhập
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                // 1. Kiểm tra đầu vào trống
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Username và Password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Kiểm tra trong Database
                try
                {
                    using (SqlConnection conn = AppDbContext.GetConnection())
                    {
                        conn.Open();
                        // Truy vấn kiểm tra tài khoản (Lưu ý: Trong thực tế nên dùng Hash mật khẩu)
                        string sql = "SELECT COUNT(*) FROM Users WHERE Username = @user AND Password = @pass";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", password);

                        int result = (int)cmd.ExecuteScalar();

                        if (result > 0)
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Mở MainForm và ẩn LoginForm hiện tại
                            MainForm mainForm = new MainForm();
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        { }
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            // Khi di chuột vào: Nút đổi thành màu xanh đậm, chữ trắng
            btnLogin.BackColor = Color.FromArgb(0, 120, 215); // Màu xanh đẹp
            btnLogin.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        { }
        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            // Khi di chuột ra: Trở lại màu mặc định
            btnLogin.BackColor = SystemColors.Control;
            btnLogin.ForeColor = SystemColors.ControlText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Bo góc loGin
        private void btnLogin_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; 

            using (GraphicsPath path = GetRoundedPath(btn.ClientRectangle, 15)) 
            {
                btn.Region = new Region(path); 
            }
        }
        // Bo góc Exit
        private void button2_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedPath(btn.ClientRectangle, 15))
            {
                btn.Region = new Region(path);
            }
        }
    }


}
