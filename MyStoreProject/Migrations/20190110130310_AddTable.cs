using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyStoreProject.Migrations
{
    public partial class AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TenLoai",
                table: "Loai",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    MaHh = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenHH = table.Column<string>(maxLength: 50, nullable: false),
                    DonGia = table.Column<double>(nullable: false),
                    Hinh = table.Column<string>(nullable: true),
                    GiamGia = table.Column<double>(nullable: false),
                    MoTa = table.Column<string>(nullable: true),
                    ChiTiet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.MaHh);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKH = table.Column<string>(maxLength: 10, nullable: false),
                    HoTen = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    DienThoai = table.Column<string>(nullable: true),
                    TenDangNhap = table.Column<string>(nullable: false),
                    MatKhau = table.Column<string>(nullable: false),
                    DangHoatDong = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "DanhGia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaHH = table.Column<int>(nullable: false),
                    MaKH = table.Column<string>(maxLength: 10, nullable: true),
                    Diem = table.Column<int>(nullable: false),
                    NgayDanhGia = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhGia_HangHoa_MaHH",
                        column: x => x.MaHH,
                        principalTable: "HangHoa",
                        principalColumn: "MaHh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhGia_KhachHang_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DanhGia_MaHH",
                table: "DanhGia",
                column: "MaHH");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGia_MaKH",
                table: "DanhGia",
                column: "MaKH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanhGia");

            migrationBuilder.DropTable(
                name: "HangHoa");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.AlterColumn<string>(
                name: "TenLoai",
                table: "Loai",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
