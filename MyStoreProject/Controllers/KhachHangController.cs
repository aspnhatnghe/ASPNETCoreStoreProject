using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyStoreProject.Models;

namespace MyStoreProject.Controllers
{
    public class KhachHangController : Controller
    {
        MyDbContext db;
        public KhachHangController(MyDbContext ctx) { db = ctx; }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CheckUserName(string TenDangNhap)
        {
            KhachHang kh = db.KhachHangs.SingleOrDefault(p => p.TenDangNhap == TenDangNhap);
            if(kh != null)
            {
                return Json(data:"Đã có tên này");
            }
            return Json(data: true); //hợp lệ
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Register(KhachHang model)
        {
            //Guid.NewGuid() <--- MaKH
            if(ModelState.IsValid)
            {
                //chưa xét tới mật khẩu
                db.KhachHangs.Add(model);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Login(string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl = null)
        {
            KhachHang kh = db.KhachHangs.SingleOrDefault(p => p.TenDangNhap == model.TenDangNhap && p.MatKhau == model.MatKhau);
            if(kh == null)
            {
                ViewBag.ThongBaoLoi = "Sai thông tin đăng nhập";
                return View();
            }

            //ghi nhận đăng nhập thành công
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name,kh.HoTen),
                new Claim(ClaimTypes.Email, kh.Email),
                //gắn Role
                new Claim(ClaimTypes.Role, "Customers")
            };
            // create identity
            ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);

            //Lưu session
            HttpContext.Session.Set("KhachHang", kh);

            //Lấy lại trang yêu cầu (nếu có)
            if (Url.IsLocalUrl(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }
            else
            {
                return RedirectToAction("Index", "HangHoa");//default
            }
            
        }

        [Authorize(Roles = "Administrator, Customers")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");//default
        }

        [Authorize(Roles = "Administrator, Customers")]
        public IActionResult Profile()
        {
            return View();
        }

        [Authorize(Roles = "Administrator, Customers")]
        public IActionResult Purchase()
        {
            //Danh sách các dơn hàng đã đặt
            KhachHang kh = HttpContext.Session.Get<KhachHang>("KhachHang");
            var dsDonHang = db.DonHangs.Where(p => p.MaKH == kh.MaKH);
            return View(dsDonHang);
        }

        public IActionResult ActiveMember(string MaKH, string Code)
        {
            KhachHang khachHang = db.KhachHangs.SingleOrDefault(p => p.MaKH == MaKH);
            //kiểm tra mã code đúng ko? & còn hạn của code
            //nếu có
            khachHang.DangHoatDong = true;
            db.SaveChanges();
            return View();
        }
    }
}

