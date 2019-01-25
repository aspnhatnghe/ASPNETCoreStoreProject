using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStoreProject.Models
{
    public interface IShoppingCart
    {
        bool AddToCart(int maHh, int ? soLuong);
        bool Clear();
        bool Remove(int maHh);
        void Test(IServiceProvider service);
    }
    public class ShoppingCart : IShoppingCart
    {
        private readonly MyDbContext db;
        private readonly IHttpContextAccessor httpContext;
        public ShoppingCart(MyDbContext ctx, IHttpContextAccessor http)
        {
            db = ctx;
            httpContext = http;
        }

        public List<CartItem> Carts
        {
            get
            {
                List<CartItem> cart = httpContext.HttpContext.Session.Get<List<CartItem>>("GioHang");

                if (cart == default(List<CartItem>))
                    cart = new List<CartItem>();
                return cart;
            }
        }

        public bool AddToCart(int maHh, int? soLuong)
        {
            try
            {
                //Lấy thông tin giỏ hàng (trong session)
                List<CartItem> cartItems = Carts;

                //tìm xem đã có trong giỏ hay chưa
                CartItem item = cartItems.SingleOrDefault(p => p.MaHh == maHh);
                //nếu có update lại cột số lượng
                if (item != null)
                {
                    item.SoLuong = soLuong.HasValue ? soLuong.Value : item.SoLuong + 1;
                }
                else //nếu chưa thì thêm mới
                {
                    HangHoa hh = db.HangHoas.SingleOrDefault(p => p.MaHh == maHh);
                    item = new CartItem
                    {
                        SoLuong = 1,
                        MaHh = hh.MaHh,
                        DonGia = hh.DonGia,
                        GiamGia = hh.GiamGia,
                        Hinh = hh.Hinh,
                        TenHH = hh.TenHH
                    };
                    cartItems.Add(item);
                }

                //update lại Session
                httpContext.HttpContext.Session.Set("GioHang", cartItems);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Clear()
        {
            try
            {
                httpContext.HttpContext.Session.Remove("GioHang");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(int maHh)
        {
            try
            {
                //Lấy thông tin giỏ hàng (trong session)
                List<CartItem> cartItems = Carts;

                //tìm xem đã có trong giỏ hay chưa
                CartItem item = cartItems.SingleOrDefault(p => p.MaHh == maHh);
                if (item != null)
                {
                    cartItems.Remove(item);
                    //update lại Session
                    httpContext.HttpContext.Session.Set("GioHang", cartItems);
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public void Test(IServiceProvider service)
        {
            //ISession session = service.GetService<IHttpContextAccessor>()?.HttpContext.Session;
        }
    }
}
