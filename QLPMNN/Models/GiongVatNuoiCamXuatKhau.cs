namespace QLPMNN.Models
{
    public class GiongVatNuoiCamXuatKhau
    {
        public int ID { get; set; }
        public string TenGiong { get; set; } = "";
        public string? LoaiVatNuoi { get; set; }
        public string? LyDoCam { get; set; }
        public DateTime? NgayBanHanh { get; set; }
        public string? CoQuanBanHanh { get; set; }
        public string? GhiChu { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
