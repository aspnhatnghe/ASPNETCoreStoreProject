using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyStoreProject.Models
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        [Display(Name ="Mã hàng hóa")]
        public int MaHh { get; set; }
        [MaxLength(50, ErrorMessage ="Tối đa 50 kí tự")]
        [Required(ErrorMessage = "*")]
        [Display(Name = "Tên hàng hóa")]
        public string TenHH { get; set; }
        [Display(Name = "Đơn giá")]
        public double DonGia { get; set; }
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Display(Name = "Giảm giá")]
        public double GiamGia { get; set; }
        [Display(Name = "Mô tả")]        
        public string MoTa { get; set; }
        [Display(Name = "Chi tiết hàng hóa")]
        [DataType(DataType.MultilineText)]
        public string ChiTiet { get; set; }
        [Display(Name = "Loại")]
        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }
    }
}
