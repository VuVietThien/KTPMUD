namespace QLPMNN.Forms
{
    partial class GiongVatNuoiBaoTonManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            pnlHeader=new Panel(); lblTitle=new Label(); pnlInput=new Panel();
            lblTen=new Label(); txtTen=new TextBox(); lblLoai=new Label(); txtLoai=new TextBox();
            lblMoTa=new Label(); txtMoTa=new TextBox(); lblTinhTrang=new Label(); txtTinhTrang=new TextBox();
            lblDiaDiem=new Label(); txtDiaDiem=new TextBox(); lblGhiChu=new Label(); txtGhiChu=new TextBox();
            pnlToolbar=new Panel(); txtTimKiem=new TextBox();
            btnTimKiem=new Button(); btnThem=new Button(); btnSua=new Button(); btnXoa=new Button();
            btnLamMoi=new Button(); btnBack=new Button(); dgv=new DataGridView();
            SuspendLayout();

            pnlHeader.BackColor=Color.FromArgb(46, 125, 50); pnlHeader.Dock=DockStyle.Top; pnlHeader.Height=55;
            lblTitle.Text="GIỐNG VẬT NUÔI CẦN BẢO TỒN"; lblTitle.Font=new Font("Segoe UI",13,FontStyle.Bold);
            lblTitle.ForeColor=Color.White; lblTitle.TextAlign=ContentAlignment.MiddleCenter; lblTitle.Dock=DockStyle.Fill;
            pnlHeader.Controls.Add(lblTitle);

            pnlInput.BackColor=Color.White; pnlInput.Dock=DockStyle.Top; pnlInput.Height=125;
            void F(Label l, TextBox t, string cap, int x, int y, int w) {
                l.Text=cap; l.Font=new Font("Segoe UI",9,FontStyle.Bold); l.Location=new Point(x,y); l.Size=new Size(w,18);
                t.Font=new Font("Segoe UI",10); t.BorderStyle=BorderStyle.FixedSingle; t.Location=new Point(x,y+20); t.Size=new Size(w,28);
                pnlInput.Controls.AddRange(new Control[] { l, t });
            }
            F(lblTen,txtTen,"Tên giống *",10,5,220); F(lblLoai,txtLoai,"Loại vật nuôi",240,5,180);
            F(lblTinhTrang,txtTinhTrang,"Tình trạng",430,5,180); F(lblDiaDiem,txtDiaDiem,"Địa điểm bảo tồn",620,5,250);
            F(lblMoTa,txtMoTa,"Mô tả",10,65,380); F(lblGhiChu,txtGhiChu,"Ghi chú",400,65,480);

            pnlToolbar.BackColor=Color.FromArgb(241, 248, 233); pnlToolbar.Dock=DockStyle.Top; pnlToolbar.Height=45;
            txtTimKiem.Location=new Point(10,8); txtTimKiem.Size=new Size(220,28);
            txtTimKiem.Font=new Font("Segoe UI",10); txtTimKiem.BorderStyle=BorderStyle.FixedSingle; txtTimKiem.PlaceholderText="Tìm kiếm...";
            void B(Button b, string t, int x, Color c, EventHandler h) {
                b.Text=t; b.Font=new Font("Segoe UI",9,FontStyle.Bold); b.BackColor=c; b.ForeColor=Color.White;
                b.FlatStyle=FlatStyle.Flat; b.FlatAppearance.BorderSize=0; b.Location=new Point(x,8); b.Size=new Size(80,28); b.Cursor=Cursors.Hand; b.Click+=h;
            }
            B(btnTimKiem,"🔍 Tìm",240,Color.SteelBlue,btnTimKiem_Click); B(btnThem,"➕ Thêm",335,Color.SeaGreen,btnThem_Click);
            B(btnSua,"✏ Sửa",425,Color.DarkOrange,btnSua_Click); B(btnXoa,"🗑 Xóa",515,Color.Firebrick,btnXoa_Click);
            B(btnLamMoi,"🔄 Mới",605,Color.Gray,btnLamMoi_Click); B(btnBack,"← Quay lại",700,Color.DimGray,btnBack_Click);
            pnlToolbar.Controls.AddRange(new Control[] { txtTimKiem,btnTimKiem,btnThem,btnSua,btnXoa,btnLamMoi,btnBack });

            dgv.Dock=DockStyle.Fill; dgv.ReadOnly=true; dgv.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill; dgv.BackgroundColor=Color.White;
            dgv.BorderStyle=BorderStyle.None; dgv.RowHeadersVisible=false; dgv.AllowUserToAddRows=false;
            dgv.CellClick+=dgv_CellClick;

            AutoScaleDimensions=new SizeF(7F,15F); AutoScaleMode=AutoScaleMode.Font; ClientSize=new Size(1100,600);
            Controls.Add(dgv); Controls.Add(pnlToolbar); Controls.Add(pnlInput); Controls.Add(pnlHeader);
            StartPosition=FormStartPosition.CenterScreen; Text="Giống Vật Nuôi Cần Bảo Tồn"; Load+=Form_Load; ResumeLayout(false);
        }
        private Panel pnlHeader, pnlInput, pnlToolbar;
        private Label lblTitle, lblTen, lblLoai, lblMoTa, lblTinhTrang, lblDiaDiem, lblGhiChu;
        private TextBox txtTen, txtLoai, txtMoTa, txtTinhTrang, txtDiaDiem, txtGhiChu, txtTimKiem;
        private Button btnTimKiem, btnThem, btnSua, btnXoa, btnLamMoi, btnBack;
        private DataGridView dgv;
    }
}
