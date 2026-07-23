namespace QLPMNN.Forms
{
    partial class QuanLyThucAn_Form
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            pnlHeader=new Panel(); lblTitle=new Label(); pnlInput=new Panel();
            lblMa=new Label(); txtMa=new TextBox(); lblTen=new Label(); txtTen=new TextBox();
            lblLoai=new Label(); txtLoai=new TextBox(); lblThanhPhan=new Label(); txtThanhPhan=new TextBox();
            lblHamLuong=new Label(); txtHamLuong=new TextBox(); lblDonViTinh=new Label(); txtDonViTinh=new TextBox();
            lblGia=new Label(); txtGia=new TextBox(); lblNhaCungCap=new Label(); txtNhaCungCap=new TextBox();
            lblGhiChu=new Label(); txtGhiChu=new TextBox();
            pnlToolbar=new Panel(); txtTimKiem=new TextBox();
            btnTimKiem=new Button(); btnThem=new Button(); btnSua=new Button(); btnXoa=new Button();
            btnLamMoi=new Button(); btnBack=new Button(); dgv=new DataGridView();
            SuspendLayout();

            pnlHeader.BackColor=Color.FromArgb(46, 125, 50); pnlHeader.Dock=DockStyle.Top; pnlHeader.Height=55;
            lblTitle.Text="QUẢN LÝ THỨC ĂN CHĂN NUÔI"; lblTitle.Font=new Font("Segoe UI",13,FontStyle.Bold);
            lblTitle.ForeColor=Color.White; lblTitle.TextAlign=ContentAlignment.MiddleCenter; lblTitle.Dock=DockStyle.Fill;
            pnlHeader.Controls.Add(lblTitle);

            pnlInput.BackColor=Color.White; pnlInput.Dock=DockStyle.Top; pnlInput.Height=175;
            void F(Label l, TextBox t, string cap, int x, int y, int w) {
                l.Text=cap; l.Font=new Font("Segoe UI",9,FontStyle.Bold); l.Location=new Point(x,y); l.Size=new Size(w,18);
                t.Font=new Font("Segoe UI",10); t.BorderStyle=BorderStyle.FixedSingle; t.Location=new Point(x,y+20); t.Size=new Size(w,28);
                pnlInput.Controls.AddRange(new Control[] { l, t });
            }
            F(lblMa,txtMa,"Mã *",10,5,110); F(lblTen,txtTen,"Tên thức ăn *",130,5,230);
            F(lblLoai,txtLoai,"Loại thức ăn",370,5,180); F(lblDonViTinh,txtDonViTinh,"Đơn vị tính",560,5,120);
            F(lblGia,txtGia,"Giá tham khảo",690,5,150);
            F(lblThanhPhan,txtThanhPhan,"Thành phần",10,65,280);
            F(lblHamLuong,txtHamLuong,"Hàm lượng dinh dưỡng",300,65,250);
            F(lblNhaCungCap,txtNhaCungCap,"Nhà cung cấp",560,65,220);
            F(lblGhiChu,txtGhiChu,"Ghi chú",10,125,760);

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

            AutoScaleDimensions=new SizeF(7F,15F); AutoScaleMode=AutoScaleMode.Font; ClientSize=new Size(1000,650);
            Controls.Add(dgv); Controls.Add(pnlToolbar); Controls.Add(pnlInput); Controls.Add(pnlHeader);
            StartPosition=FormStartPosition.CenterScreen; Text="Quản lý Thức ăn chăn nuôi"; Load+=Form_Load; ResumeLayout(false);
        }

        private Panel pnlHeader, pnlInput, pnlToolbar;
        private Label lblTitle, lblMa, lblTen, lblLoai, lblThanhPhan, lblHamLuong, lblDonViTinh, lblGia, lblNhaCungCap, lblGhiChu;
        private TextBox txtMa, txtTen, txtLoai, txtThanhPhan, txtHamLuong, txtDonViTinh, txtGia, txtNhaCungCap, txtGhiChu, txtTimKiem;
        private Button btnTimKiem, btnThem, btnSua, btnXoa, btnLamMoi, btnBack;
        private DataGridView dgv;
    }
}
