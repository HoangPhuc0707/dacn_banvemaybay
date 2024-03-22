using System.ComponentModel.DataAnnotations;

namespace DemoMayBayCN.Areas.Admin.ModelView
{
    public class flightRequest
    {
        [Required(ErrorMessage ="Vui lòng chọn ngày khởi hành")]
        public string? DepartureDay { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn thời gian khởi hành")]
        public TimeSpan? ArrivalTime { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn thời gian đến")]
        public TimeSpan? DepartureTime { get; set; }
        [Required]
        public int? ArrivalCity { get; set; }
        [Required]
        public int? DepartureCity { get; set; }
        [Required(ErrorMessage = "Vui lòng nhấp số lượng")]
        public int? TotalSeats { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá")]
        public Decimal? PhoThong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá")]
        public Decimal? ThuongGia { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn hình ảnh")]
        public IFormFile HinhAnh { get; set; }
    }
}
