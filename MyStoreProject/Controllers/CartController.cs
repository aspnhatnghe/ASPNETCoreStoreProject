using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStoreProject.Models;

namespace MyStoreProject.Controllers
{
    public class CartController : Controller
    {
        private readonly ShoppingCart _cart;
        private readonly MyDbContext db;
        private readonly IHttpContextAccessor httpContext;
        public CartController(MyDbContext ctx, IHttpContextAccessor httpCtx)
        {
            db = ctx;
            httpContext = httpCtx;
            _cart = new ShoppingCart(ctx, httpContext);
        }
        public IActionResult Demo()
        {
            return Json(_cart.Carts);
        }

        public IActionResult Index()
        {
            return View(_cart.Carts);
        }

        public IActionResult AddToCart(int maHh)
        {
            _cart.AddToCart(maHh, null);

            //chuyển Index để trình bày giỏ hàng
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCart(int maHh, int soLuong)
        {
            _cart.AddToCart(maHh, soLuong);

            return Json(new
            {
                TongTien = _cart.Carts.Sum(p => p.ThanhTien),
                SoLuong = _cart.Carts.Sum(p => p.SoLuong)
            });
        }

        public IActionResult Purchase()
        {
            ThanhToanViewModel model = new ThanhToanViewModel();

            if (User.Identity.IsAuthenticated)
            {
                KhachHang kh = HttpContext.Session.Get<KhachHang>("KhachHang");
                model.MaKH = kh.MaKH;
                model.HoTen = kh.HoTen;
                model.Email = kh.Email;
                model.DienThoai = kh.DienThoai;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Purchase(ThanhToanViewModel model)
        {
            //process order
            KhachHang kh = null;
            if (!User.Identity.IsAuthenticated)
            {
                kh = new KhachHang()
                {
                    HoTen = model.HoTen,
                    Email = model.Email,
                    DienThoai = model.DienThoai,
                    TenDangNhap = $"KH{DateTime.Now.Ticks}",
                    MatKhau = new Random().Next(1000, 10000).ToString()
                };
                db.Add(kh);
                db.SaveChanges();
            }
            else
            {
                kh = HttpContext.Session.Get<KhachHang>("KhachHang");
            }

            DonHang dh = new DonHang()
            {
                MaKH = kh.MaKH,
                NgayDat = DateTime.Now,
                NguoiNhan = model.NguoiNhan,
                DiaChiGiao = model.DiaChiGiao,
                MaTrangThai = 1
            };
            db.Add(dh);
            db.SaveChanges();

            ChiTietDonHang cthd = null;
            foreach (CartItem item in _cart.Carts)
            {
                cthd = new ChiTietDonHang
                {
                    MaDH = dh.MaDH,
                    MaHH = item.MaHh,
                    DonGia = item.DonGia,
                    GiamGia = item.GiamGia,
                    SoLuong = item.SoLuong
                };
                db.Add(cthd);
            }
            db.SaveChanges();

            //hủy giỏ hàng
            _cart.Clear();

            //chuyển trang
            return View("ThongBao");
        }

        public IActionResult ThongBao()
        {
            return View();
        }
    }
}