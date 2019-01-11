using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyStoreProject.Models
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        [Display(Name ="Mã loại")]
        public int MaLoai { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Tên loại")]
        [MaxLength(50, ErrorMessage ="Tối đa 50 kí tự")]
        public string TenLoai { get; set; }
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        [Display(Name = "Loại cha")]
        public int MaLoaiCha { get; set; }
        //[ForeignKey("MaLoaiCha")]
        //public Loai LoaiCha { get; set; }
    }
}
