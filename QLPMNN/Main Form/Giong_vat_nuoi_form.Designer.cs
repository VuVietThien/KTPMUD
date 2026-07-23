namespace QLPMNN
{
    partial class Giong_vat_nuoi_form
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.pnlButtons = new Panel();
            this.btnTinhPhoi = new Button();
            this.btnConGiong = new Button();
            this.btnDucGiong = new Button();
            this.btnMuaBan = new Button();
            this.btnKhaoNghiem = new Button();
            this.btnGiongBaoTon = new Button();
            this.btnGiongCam = new Button();
            this.btnBack = new Button();
            this.SuspendLayout();

            this.pnlHeader.BackColor = Color.FromArgb(46, 125, 50);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.lblTitle.Text = "QUẢN LÝ GIỐNG VẬT NUÔI";
            this.lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = DockStyle.Fill;
            this.pnlHeader.Controls.Add(lblTitle);

            this.pnlButtons.Dock = DockStyle.Fill;
            this.pnlButtons.BackColor = Color.FromArgb(241, 248, 233);

            void AddMenuBtn(Button btn, string text, int top, EventHandler handler)
            {
                btn.Text = text;
                btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                btn.BackColor = Color.FromArgb(46, 125, 50);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Location = new Point(60, top);
                btn.Size = new Size(560, 50);
                btn.Cursor = Cursors.Hand;
                btn.Click += handler;
                btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(102, 187, 106);
                btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(46, 125, 50);
                this.pnlButtons.Controls.Add(btn);
            }

            AddMenuBtn(btnTinhPhoi, "💉  Tổ chức Sản xuất Tinh/Phôi", 30, btnTinhPhoi_Click);
            AddMenuBtn(btnConGiong, "🐣  Tổ chức Sản xuất Con Giống", 90, btnConGiong_Click);
            AddMenuBtn(btnDucGiong, "🐂  Tổ chức Sở hữu Đực Giống", 150, btnDucGiong_Click);
            AddMenuBtn(btnMuaBan, "🏪  Tổ chức Mua Bán Giống", 210, btnMuaBan_Click);
            AddMenuBtn(btnKhaoNghiem, "🔭  Cơ sở Khảo Nghiệm", 270, btnKhaoNghiem_Click);
            AddMenuBtn(btnGiongBaoTon, "🛡  Giống Vật Nuôi Cần Bảo Tồn", 330, btnGiongBaoTon_Click);
            AddMenuBtn(btnGiongCam, "🚫  Giống Vật Nuôi Cấm Xuất Khẩu", 390, btnGiongCam_Click);

            this.btnBack.Text = "← Quay lại";
            this.btnBack.Font = new Font("Segoe UI", 10);
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.Location = new Point(60, 460);
            this.btnBack.Size = new Size(130, 36);
            this.btnBack.Cursor = Cursors.Hand;
            this.btnBack.Click += btnBack_Click;
            this.pnlButtons.Controls.Add(btnBack);

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(680, 630);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Giống Vật Nuôi";
            this.ResumeLayout(false);
        }

        private Panel pnlHeader, pnlButtons;
        private Label lblTitle;
        private Button btnTinhPhoi, btnConGiong, btnDucGiong, btnMuaBan, btnKhaoNghiem, btnGiongBaoTon, btnGiongCam, btnBack;
    }
}
