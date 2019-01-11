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
        public int MaHh { get; set; }
        [MaxLength(50, ErrorMessage ="Tối đa 50 kí tự")]
        [Required(ErrorMessage = "*")]
        public string TenHH { get; set; }
        public double DonGia { get; set; }
        public string Hinh { get; set; }
        public double GiamGia { get; set; }
        public string MoTa { get; set; }
        public string ChiTiet { get; set; } 
        
        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }
    }
}
