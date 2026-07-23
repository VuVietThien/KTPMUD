namespace QLPMNN.Models
{
    public class ToChucSoHuuDucGiong
    {
        public int ID { get; set; }
        public string TenToChuc { get; set; } = "";
        public string? LoaiHinh { get; set; }
        public string? LoaiDucGiong { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? MaSoThue { get; set; }
        public string? GiayPhepKinhDoanh { get; set; }
        public string? GhiChu { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
