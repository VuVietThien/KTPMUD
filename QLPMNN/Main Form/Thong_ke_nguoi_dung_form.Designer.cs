namespace QLPMNN
{
    partial class Thong_ke_nguoi_dung_form
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
            this.lblTotal = new Label();
            this.lblActive = new Label();
            this.lblNhom = new Label();
            this.grpRole = new GroupBox();
            this.dgvRole = new DataGridView();
            this.grpStatus = new GroupBox();
            this.dgvStatus = new DataGridView();
            this.btnClose = new Button();
            this.SuspendLayout();

            this.lblTitle.Text = "THỐNG KÊ NGƯỜI DÙNG";
            this.lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(46, 125, 50);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Size = new Size(560, 35);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            this.lblTotal.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblTotal.Location = new Point(30, 60); this.lblTotal.Size = new Size(200, 28);
            this.lblActive.Font = new Font("Segoe UI", 11);
            this.lblActive.Location = new Point(240, 60); this.lblActive.Size = new Size(200, 28);
            this.lblNhom.Font = new Font("Segoe UI", 11);
            this.lblNhom.Location = new Point(450, 60); this.lblNhom.Size = new Size(150, 28);

            this.grpRole.Text = "Phân bố theo vai trò";
            this.grpRole.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.grpRole.Location = new Point(20, 100);
            this.grpRole.Size = new Size(270, 200);
            this.dgvRole.Dock = DockStyle.Fill;
            this.dgvRole.ReadOnly = true;
            this.dgvRole.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRole.BackgroundColor = Color.White;
            this.dgvRole.RowHeadersVisible = false;
            this.dgvRole.AllowUserToAddRows = false;
            this.grpRole.Controls.Add(dgvRole);

            this.grpStatus.Text = "Phân bố theo trạng thái";
            this.grpStatus.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.grpStatus.Location = new Point(310, 100);
            this.grpStatus.Size = new Size(270, 200);
            this.dgvStatus.Dock = DockStyle.Fill;
            this.dgvStatus.ReadOnly = true;
            this.dgvStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatus.BackgroundColor = Color.White;
            this.dgvStatus.RowHeadersVisible = false;
            this.dgvStatus.AllowUserToAddRows = false;
            this.grpStatus.Controls.Add(dgvStatus);

            this.btnClose.Text = "Đóng";
            this.btnClose.Font = new Font("Segoe UI", 10);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Location = new Point(250, 320);
            this.btnClose.Size = new Size(100, 36);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += btnClose_Click;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(600, 375);
            this.Controls.AddRange(new Control[] { lblTitle, lblTotal, lblActive, lblNhom, grpRole, grpStatus, btnClose });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Thống kê người dùng";
            this.Load += Thong_ke_nguoi_dung_form_Load;
            this.ResumeLayout(false);
        }

        private Label lblTitle, lblTotal, lblActive, lblNhom;
        private GroupBox grpRole, grpStatus;
        private DataGridView dgvRole, dgvStatus;
        private Button btnClose;
    }
}
