using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyStoreProject.Models
{
    [Table("DanhGia")]
    public class DanhGia
    {
        public int Id { get; set; }
        public int MaHH { get; set; }
        [MaxLength(50, ErrorMessage = "Tối đa 50 kí tự")]
        public string MaKH { get; set; }
        public int Diem { get; set; }
        public DateTime NgayDanhGia { get; set; }
        [ForeignKey("MaHH")]
        public HangHoa HangHoa { get; set; }
        [ForeignKey("MaKH")]
        public KhachHang KhachHang { get; set; }

    }
}
