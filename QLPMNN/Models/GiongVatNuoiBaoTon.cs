namespace QLPMNN.Models
{
    public class GiongVatNuoiBaoTon
    {
        public int ID { get; set; }
        public string TenGiong { get; set; } = "";
        public string? LoaiVatNuoi { get; set; }
        public string? MoTa { get; set; }
        public string? TinhTrang { get; set; }
        public string? DiaDiemBaoTon { get; set; }
        public string? GhiChu { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
