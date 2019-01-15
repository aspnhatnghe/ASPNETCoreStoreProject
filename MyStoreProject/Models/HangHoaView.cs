using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStoreProject.Models
{
    public class HangHoaView
    {
        [Key]
        [Display(Name = "Mã hàng hóa")]
        public int MaHh { get; set; }        
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
        public double GiaBan => DonGia * (1 - GiamGia);
        public bool DangGiamGia => GiamGia > 0;
    }
}
