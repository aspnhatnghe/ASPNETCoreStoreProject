using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStoreProject.Models
{
    public class CartItem1
    {
        public HangHoa Product { get; set; }
        public int Count { get; set; }
        public double Total => Count * Product.DonGia * (1 - Product.GiamGia);
    }

    public class CartItem2
    {
        public HangHoaView Product { get; set; }
        public int Count { get; set; }
        public double Total => Count * Product.GiaBan;
    }
    public class CartItem : HangHoaView
    {       
        public int SoLuong { get; set; }
        public double ThanhTien => SoLuong * GiaBan;
    }
}
