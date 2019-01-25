using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyStoreProject.Models
{
    [Table("ChiTietDonHang")]
    public class ChiTietDonHang
    {
        [Key]
        public int MaCT { get; set; }
        public int MaDH { get; set; }
        public int MaHH { get; set; }
        [ForeignKey("MaDH")]
        public DonHang DonHang { get; set; }
        [ForeignKey("MaHH")]
        public HangHoa HangHoa{ get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double GiamGia { get; set; }
        public double GiaBan => DonGia * (1 - GiamGia);
        public double ThanhTien => SoLuong * GiaBan;
    }
}
