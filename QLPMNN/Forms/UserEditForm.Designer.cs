namespace QLPMNN.Forms
{
    partial class UserEditForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            lblTitle=new Label(); lblUsername=new Label(); txtUsername=new TextBox();
            lblPassword=new Label(); txtPassword=new TextBox(); lblEmail=new Label(); txtEmail=new TextBox();
            lblRole=new Label(); cmbRole=new ComboBox(); lblStatus=new Label(); cmbStatus=new ComboBox();
            btnLuu=new Button(); btnHuy=new Button();
            SuspendLayout();

            lblTitle.Text="THÊM NGƯỜI DÙNG MỚI"; lblTitle.Font=new Font("Segoe UI",13,FontStyle.Bold);
            lblTitle.ForeColor=Color.FromArgb(46, 125, 50); lblTitle.Location=new Point(20,15); lblTitle.Size=new Size(360,35);
            lblTitle.TextAlign=ContentAlignment.MiddleCenter;

            int y=60;
            void F(Label l, Control ctrl, string cap, bool readOnly=false) {
                l.Text=cap; l.Font=new Font("Segoe UI",9,FontStyle.Bold); l.Location=new Point(20,y); l.Size=new Size(360,20);
                ctrl.Font=new Font("Segoe UI",10); ctrl.Location=new Point(20,y+22); ctrl.Size=new Size(360,28);
                if (ctrl is TextBox t) { t.BorderStyle=BorderStyle.FixedSingle; t.ReadOnly=readOnly; }
                if (ctrl is ComboBox c) { c.DropDownStyle=ComboBoxStyle.DropDownList; c.FlatStyle=FlatStyle.Flat; }
                y+=58;
            }
            F(lblUsername,txtUsername,"Tên đăng nhập: *");
            F(lblPassword,txtPassword,"Mật khẩu: *");
            F(lblEmail,txtEmail,"Email:");
            F(lblRole,cmbRole,"Vai trò:");
            F(lblStatus,cmbStatus,"Trạng thái:");
            y+=10;

            btnLuu.Text="💾 LƯU"; btnLuu.Font=new Font("Segoe UI",10,FontStyle.Bold);
            btnLuu.BackColor=Color.FromArgb(46, 125, 50); btnLuu.ForeColor=Color.White;
            btnLuu.FlatStyle=FlatStyle.Flat; btnLuu.FlatAppearance.BorderSize=0;
            btnLuu.Location=new Point(20,y); btnLuu.Size=new Size(170,38); btnLuu.Cursor=Cursors.Hand;
            btnLuu.Click+=btnLuu_Click;

            btnHuy.Text="HỦY"; btnHuy.Font=new Font("Segoe UI",10);
            btnHuy.FlatStyle=FlatStyle.Flat; btnHuy.Location=new Point(210,y); btnHuy.Size=new Size(170,38); btnHuy.Cursor=Cursors.Hand;
            btnHuy.Click+=btnHuy_Click;

            AutoScaleDimensions=new SizeF(7F,15F); AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(400,y+58);
            Controls.AddRange(new Control[] { lblTitle,lblUsername,txtUsername,lblPassword,txtPassword,lblEmail,txtEmail,lblRole,cmbRole,lblStatus,cmbStatus,btnLuu,btnHuy });
            FormBorderStyle=FormBorderStyle.FixedDialog; MaximizeBox=false;
            StartPosition=FormStartPosition.CenterParent; Text="Người dùng";
            Load+=Form_Load; ResumeLayout(false);
        }
        private Label lblTitle, lblUsername, lblPassword, lblEmail, lblRole, lblStatus;
        private TextBox txtUsername, txtPassword, txtEmail;
        private ComboBox cmbRole, cmbStatus;
        private Button btnLuu, btnHuy;
    }
}
