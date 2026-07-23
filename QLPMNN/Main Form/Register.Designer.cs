namespace QLPMNN
{
    partial class Register
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblUsername = new Label();
            this.txtUsername = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.lblConfirmPassword = new Label();
            this.txtConfirmPassword = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.btnDangKy = new Button();
            this.btnHuy = new Button();
            this.SuspendLayout();

            this.lblTitle.Text = "ĐĂNG KÝ TÀI KHOẢN";
            this.lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(46, 125, 50);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(360, 40);

            int y = 75;
            this.lblUsername.Text = "Tên đăng nhập: *"; this.lblUsername.Location = new Point(20, y); this.lblUsername.Size = new Size(360, 22);
            this.lblUsername.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            y += 25;
            this.txtUsername.Location = new Point(20, y); this.txtUsername.Size = new Size(360, 28);
            this.txtUsername.Font = new Font("Segoe UI", 10); this.txtUsername.BorderStyle = BorderStyle.FixedSingle;
            y += 38;
            this.lblEmail.Text = "Email:"; this.lblEmail.Location = new Point(20, y); this.lblEmail.Size = new Size(360, 22);
            this.lblEmail.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            y += 25;
            this.txtEmail.Location = new Point(20, y); this.txtEmail.Size = new Size(360, 28);
            this.txtEmail.Font = new Font("Segoe UI", 10); this.txtEmail.BorderStyle = BorderStyle.FixedSingle;
            y += 38;
            this.lblPassword.Text = "Mật khẩu: *"; this.lblPassword.Location = new Point(20, y); this.lblPassword.Size = new Size(360, 22);
            this.lblPassword.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            y += 25;
            this.txtPassword.Location = new Point(20, y); this.txtPassword.Size = new Size(360, 28);
            this.txtPassword.Font = new Font("Segoe UI", 10); this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtPassword.UseSystemPasswordChar = true;
            y += 38;
            this.lblConfirmPassword.Text = "Xác nhận mật khẩu: *"; this.lblConfirmPassword.Location = new Point(20, y); this.lblConfirmPassword.Size = new Size(360, 22);
            this.lblConfirmPassword.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            y += 25;
            this.txtConfirmPassword.Location = new Point(20, y); this.txtConfirmPassword.Size = new Size(360, 28);
            this.txtConfirmPassword.Font = new Font("Segoe UI", 10); this.txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            y += 50;

            this.btnDangKy.Text = "ĐĂNG KÝ";
            this.btnDangKy.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnDangKy.BackColor = Color.FromArgb(46, 125, 50);
            this.btnDangKy.ForeColor = Color.White;
            this.btnDangKy.FlatStyle = FlatStyle.Flat;
            this.btnDangKy.FlatAppearance.BorderSize = 0;
            this.btnDangKy.Location = new Point(20, y);
            this.btnDangKy.Size = new Size(170, 38);
            this.btnDangKy.Cursor = Cursors.Hand;
            this.btnDangKy.Click += btnDangKy_Click;

            this.btnHuy.Text = "HỦY";
            this.btnHuy.Font = new Font("Segoe UI", 10);
            this.btnHuy.FlatStyle = FlatStyle.Flat;
            this.btnHuy.Location = new Point(210, y);
            this.btnHuy.Size = new Size(170, 38);
            this.btnHuy.Cursor = Cursors.Hand;
            this.btnHuy.Click += btnHuy_Click;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, y + 60);
            this.Controls.AddRange(new Control[] {
                lblTitle, lblUsername, txtUsername, lblEmail, txtEmail,
                lblPassword, txtPassword, lblConfirmPassword, txtConfirmPassword,
                btnDangKy, btnHuy
            });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Đăng ký tài khoản";
            this.ResumeLayout(false);
        }

        private Label lblTitle, lblUsername, lblPassword, lblConfirmPassword, lblEmail;
        private TextBox txtUsername, txtPassword, txtConfirmPassword, txtEmail;
        private Button btnDangKy, btnHuy;
    }
}
