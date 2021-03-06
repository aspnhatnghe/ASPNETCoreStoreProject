﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyStoreProject.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        [MaxLength(50, ErrorMessage = "Tối đa 50 kí tự")]
        public string MaKH { get; set; }
        [Required(ErrorMessage ="*")]
        [MaxLength(50, ErrorMessage = "Tối đa 50 kí tự")]
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        [Required(ErrorMessage = "*")]
        [Remote(action:"CheckUserName", controller:"KhachHang" )]
        public string TenDangNhap { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
        public bool DangHoatDong { get; set; }
    }
}
