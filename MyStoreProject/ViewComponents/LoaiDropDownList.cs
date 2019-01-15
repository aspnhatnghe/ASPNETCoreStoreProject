using Microsoft.AspNetCore.Mvc;
using MyStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStoreProject.ViewComponents
{
    public class LoaiDropDownList : ViewComponent
    {
        private readonly MyDbContext db;
        public LoaiDropDownList(MyDbContext ctx)
        {
            db = ctx;
        }

        public IViewComponentResult Invoke()
        {
            var dsLoai = db.Loais.OrderBy(p => p.TenLoai);
            return View(dsLoai);
        }
    }
}
