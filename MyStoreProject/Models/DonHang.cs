using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyStoreProject.Models
{
    [Table("DonHang")]
    public class DonHang
    {
        [Key]
        public int MaDH { get; set; }
        public DateTime NgayDat { get; set; }
        [MaxLength(50, ErrorMessage = "Tối đa 50 kí tự")]
        public string MaKH { get; set; }
        [ForeignKey("MaKH")]
        public KhachHang KhachHang { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChiGiao { get; set; }
        public int MaTrangThai { get; set; }
        [ForeignKey("MaTrangThai")]
        public TrangThai TrangThai { get; set; }
    }
    [Table("TrangThai")]
    public class TrangThai
    {
        [Key]
        public int MaTrangThai { get; set; }
        public string TenTrangThai { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
