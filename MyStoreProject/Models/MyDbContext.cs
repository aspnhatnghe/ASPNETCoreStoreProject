using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStoreProject.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Loai> Loais { get; set; }        
        public DbSet<HangHoa> HangHoas { get; set; }        
        public DbSet<KhachHang> KhachHangs { get; set; }        
        public DbSet<DanhGia> DanhGias { get; set; }        
        public DbSet<DonHang> DonHangs { get; set; }        
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }        
        public DbSet<TrangThai> TrangThais { get; set; }        

        public MyDbContext(DbContextOptions opt) : base(opt)
        {
        }

        public MyDbContext(){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //lấy chuỗi kết nối từ file appsettings.json
        }
    }
}
