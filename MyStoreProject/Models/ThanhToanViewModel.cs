using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStoreProject.Models
{
    public class ThanhToanViewModel
    {
        //Người mua
        [MaxLength(10, ErrorMessage = "Tối đa 10 kí tự")]
        public string MaKH { get; set; }
        [Required(ErrorMessage = "*")]
        [MaxLength(50, ErrorMessage = "Tối đa 50 kí tự")]
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }

        //thông tin giao hàng
        public string NguoiNhan { get; set; }
        public string DiaChiGiao { get; set; }
    }
}
