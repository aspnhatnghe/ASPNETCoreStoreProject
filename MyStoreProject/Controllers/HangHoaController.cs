using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStoreProject.Models;
using PagedList.Core;

namespace MyStoreProject.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly MyDbContext db;
        public HangHoaController(MyDbContext ctx)
        {
            db = ctx;
        }
        public IActionResult Index(int maLoai, string keyword, int page = 1)
        {
            var dsHangHoa = db.HangHoas.ToList();
            var title = "Tất cả Hàng hóa";
            if (maLoai > 0)
            {
                Loai lo = db.Loais.SingleOrDefault(p => p.MaLoai == maLoai);
                if (lo == null)
                {
                    title = "Không có hàng hóa";
                    return View(new List<HangHoaView>());
                }
                dsHangHoa = dsHangHoa.Where(p => p.MaLoai == maLoai).ToList();
                title = lo.TenLoai;
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                if (maLoai > 0)
                {
                    title += $": {keyword}";
                }
                else
                    title = $"Kết quả tìm kiếm " + keyword;
                dsHangHoa = dsHangHoa.Where(p => p.TenHH.ToLower().Contains(keyword)).ToList();
            }

            var dsHHView = dsHangHoa.Select(p => new HangHoaView
            {
                MaHh = p.MaHh,
                TenHH = p.TenHH,
                Hinh = p.Hinh,
                DonGia = p.DonGia,
                GiamGia = p.GiamGia,
                MoTa = p.MoTa
            }).AsQueryable();

            ViewBag.TieuDe = title;
            ViewBag.MaLoai = maLoai;
            //return View(dsHHView);
            //Thực hiện phân trang với page là trang hiện tại, PAGE_SIZE số hàng hóa mỗi trang
            PagedList<HangHoaView> model = new PagedList<HangHoaView>(dsHHView, page, MyTools.PAGE_SIZE);
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            HangHoa hh = db.HangHoas.SingleOrDefault(p => p.MaHh == id);
            return View(hh);
        }
    }
}