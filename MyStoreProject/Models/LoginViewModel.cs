using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStoreProject.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*")]        
        [Display(Name ="Tên đăng nhập")]
        public string TenDangNhap { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
    }
}
