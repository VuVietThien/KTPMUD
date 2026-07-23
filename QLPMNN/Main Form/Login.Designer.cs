namespace QLPMNN
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new Panel();
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.pnlForm = new Panel();
            this.lblUsername = new Label();
            this.txtUsername = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.btnDangNhap = new Button();
            this.btnDangKy = new Button();
            this.btnQuenMatKhau = new Button();
            this.btnThoat = new Button();
            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.BackColor = Color.FromArgb(46, 125, 50);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(this.pnlForm);
            this.pnlMain.Controls.Add(this.pnlHeader);

            // pnlHeader
            this.pnlHeader.BackColor = Color.FromArgb(27, 94, 32);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 120;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            // lblTitle
            this.lblTitle.Text = "PHẦN MỀM QUẢN LÝ CHĂN NUÔI NÔNG NGHIỆP";
            this.lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = DockStyle.Top;
            this.lblTitle.Height = 70;

            // lblSubtitle
            this.lblSubtitle.Text = "QLCNN — Đăng nhập hệ thống";
            this.lblSubtitle.Font = new Font("Segoe UI", 11);
            this.lblSubtitle.ForeColor = Color.FromArgb(200, 230, 201);
            this.lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblSubtitle.Dock = DockStyle.Fill;

            // pnlForm
            this.pnlForm.BackColor = Color.White;
            this.pnlForm.Width = 400;
            this.pnlForm.Height = 340;
            this.pnlForm.Anchor = AnchorStyles.None;
            this.pnlMain.Resize += (s, e) => {
                pnlForm.Location = new Point(
                    (pnlMain.ClientSize.Width - pnlForm.Width) / 2,
                    pnlHeader.Height + (pnlMain.ClientSize.Height - pnlHeader.Height - pnlForm.Height) / 2
                );
            };
            this.pnlForm.Controls.Add(this.btnThoat);
            this.pnlForm.Controls.Add(this.btnQuenMatKhau);
            this.pnlForm.Controls.Add(this.btnDangKy);
            this.pnlForm.Controls.Add(this.btnDangNhap);
            this.pnlForm.Controls.Add(this.txtPassword);
            this.pnlForm.Controls.Add(this.lblPassword);
            this.pnlForm.Controls.Add(this.txtUsername);
            this.pnlForm.Controls.Add(this.lblUsername);
            this.pnlForm.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(46, 125, 50), 2), 0, 0, pnlForm.Width - 1, pnlForm.Height - 1);
            };

            // lblUsername
            this.lblUsername.Text = "Tên đăng nhập:";
            this.lblUsername.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblUsername.Location = new Point(40, 30);
            this.lblUsername.Size = new Size(320, 25);

            // txtUsername
            this.txtUsername.Font = new Font("Segoe UI", 11);
            this.txtUsername.Location = new Point(40, 58);
            this.txtUsername.Size = new Size(320, 32);
            this.txtUsername.BorderStyle = BorderStyle.FixedSingle;

            // lblPassword
            this.lblPassword.Text = "Mật khẩu:";
            this.lblPassword.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblPassword.Location = new Point(40, 100);
            this.lblPassword.Size = new Size(320, 25);

            // txtPassword
            this.txtPassword.Font = new Font("Segoe UI", 11);
            this.txtPassword.Location = new Point(40, 128);
            this.txtPassword.Size = new Size(320, 32);
            this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += txtPassword_KeyDown;

            // btnDangNhap
            this.btnDangNhap.Text = "ĐĂNG NHẬP";
            this.btnDangNhap.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnDangNhap.BackColor = Color.FromArgb(46, 125, 50);
            this.btnDangNhap.ForeColor = Color.White;
            this.btnDangNhap.FlatStyle = FlatStyle.Flat;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.Location = new Point(40, 178);
            this.btnDangNhap.Size = new Size(320, 42);
            this.btnDangNhap.Cursor = Cursors.Hand;
            this.btnDangNhap.Click += btnDangNhap_Click;
            this.btnDangNhap.MouseEnter += (s, e) => btnDangNhap.BackColor = Color.FromArgb(102, 187, 106);
            this.btnDangNhap.MouseLeave += (s, e) => btnDangNhap.BackColor = Color.FromArgb(46, 125, 50);

            // btnDangKy
            this.btnDangKy.Text = "Đăng ký tài khoản";
            this.btnDangKy.Font = new Font("Segoe UI", 9);
            this.btnDangKy.FlatStyle = FlatStyle.Flat;
            this.btnDangKy.FlatAppearance.BorderSize = 0;
            this.btnDangKy.ForeColor = Color.FromArgb(46, 125, 50);
            this.btnDangKy.BackColor = Color.White;
            this.btnDangKy.Location = new Point(40, 235);
            this.btnDangKy.Size = new Size(150, 28);
            this.btnDangKy.Cursor = Cursors.Hand;
            this.btnDangKy.Click += btnDangKy_Click;

            // btnQuenMatKhau
            this.btnQuenMatKhau.Text = "Quên mật khẩu?";
            this.btnQuenMatKhau.Font = new Font("Segoe UI", 9);
            this.btnQuenMatKhau.FlatStyle = FlatStyle.Flat;
            this.btnQuenMatKhau.FlatAppearance.BorderSize = 0;
            this.btnQuenMatKhau.ForeColor = Color.Gray;
            this.btnQuenMatKhau.BackColor = Color.White;
            this.btnQuenMatKhau.Location = new Point(210, 235);
            this.btnQuenMatKhau.Size = new Size(150, 28);
            this.btnQuenMatKhau.Cursor = Cursors.Hand;
            this.btnQuenMatKhau.Click += btnQuenMatKhau_Click;

            // btnThoat
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Font = new Font("Segoe UI", 9);
            this.btnThoat.FlatStyle = FlatStyle.Flat;
            this.btnThoat.ForeColor = Color.Gray;
            this.btnThoat.BackColor = Color.White;
            this.btnThoat.Location = new Point(160, 295);
            this.btnThoat.Size = new Size(80, 28);
            this.btnThoat.Cursor = Cursors.Hand;
            this.btnThoat.Click += btnThoat_Click;

            // Login Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(700, 500);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "QLCNN - Đăng nhập";
            this.BackColor = Color.FromArgb(46, 125, 50);
            this.FormClosing += (s, e) => { if (e.CloseReason == CloseReason.UserClosing) Environment.Exit(0); };

            this.pnlForm.Location = new Point(150, 145);

            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Panel pnlMain;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlForm;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnDangNhap;
        private Button btnDangKy;
        private Button btnQuenMatKhau;
        private Button btnThoat;
    }
}
