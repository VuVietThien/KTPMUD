namespace QLPMNN
{
    partial class ForgotPassword
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
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblNewPassword = new Label();
            this.txtNewPassword = new TextBox();
            this.lblConfirmPassword = new Label();
            this.txtConfirmPassword = new TextBox();
            this.btnXacNhan = new Button();
            this.btnHuy = new Button();
            this.SuspendLayout();

            this.lblTitle.Text = "KHÔI PHỤC MẬT KHẨU";
            this.lblTitle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(46, 125, 50);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Size = new Size(360, 35);

            int y = 65;
            Action<Label, TextBox, string, bool> addRow = (lbl, txt, caption, isPwd) => {
                lbl.Text = caption; lbl.Location = new Point(20, y); lbl.Size = new Size(360, 22);
                lbl.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                y += 24;
                txt.Location = new Point(20, y); txt.Size = new Size(360, 28);
                txt.Font = new Font("Segoe UI", 10); txt.BorderStyle = BorderStyle.FixedSingle;
                if (isPwd) txt.UseSystemPasswordChar = true;
                y += 38;
            };

            addRow(lblUsername, txtUsername, "Tên đăng nhập:", false);
            addRow(lblEmail, txtEmail, "Email đã đăng ký:", false);
            addRow(lblNewPassword, txtNewPassword, "Mật khẩu mới:", true);
            addRow(lblConfirmPassword, txtConfirmPassword, "Xác nhận mật khẩu mới:", true);
            y += 10;

            this.btnXacNhan.Text = "XÁC NHẬN";
            this.btnXacNhan.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnXacNhan.BackColor = Color.FromArgb(46, 125, 50);
            this.btnXacNhan.ForeColor = Color.White;
            this.btnXacNhan.FlatStyle = FlatStyle.Flat;
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.Location = new Point(20, y);
            this.btnXacNhan.Size = new Size(170, 38);
            this.btnXacNhan.Cursor = Cursors.Hand;
            this.btnXacNhan.Click += btnXacNhan_Click;

            this.btnHuy.Text = "HỦY";
            this.btnHuy.Font = new Font("Segoe UI", 10);
            this.btnHuy.FlatStyle = FlatStyle.Flat;
            this.btnHuy.Location = new Point(210, y);
            this.btnHuy.Size = new Size(170, 38);
            this.btnHuy.Cursor = Cursors.Hand;
            this.btnHuy.Click += btnHuy_Click;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, y + 58);
            this.Controls.AddRange(new Control[] {
                lblTitle, lblUsername, txtUsername, lblEmail, txtEmail,
                lblNewPassword, txtNewPassword, lblConfirmPassword, txtConfirmPassword,
                btnXacNhan, btnHuy
            });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Khôi phục mật khẩu";
            this.ResumeLayout(false);
        }

        private Label lblTitle, lblUsername, lblEmail, lblNewPassword, lblConfirmPassword;
        private TextBox txtUsername, txtEmail, txtNewPassword, txtConfirmPassword;
        private Button btnXacNhan, btnHuy;
    }
}
