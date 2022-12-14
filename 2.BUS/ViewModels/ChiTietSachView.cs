using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class ChiTietSachView
    {
        //testáds
        public Guid Id { get; set; }
        public string TenSach { get; set; }
        public string TenNxb { get; set; }
        public string TenTacGia { get; set; }
        public string TenNhaPhatHanh { get; set; }
        public string TenLoaiBia { get; set; }
        public string TenTheLoai { get; set; }
        public Guid? TenTheLoai2 { get; set; }
        public string Ma { get; set; }
        public byte[] Anh { get; set; }
        public string MaVach { get; set; }
        public string KichThuoc { get; set; }
        public int? NamXuatBan { get; set; }
        public string MoTa { get; set; }
        public int? SoLuong { get; set; }
        public decimal? GiaNhap { get; set; }
        public decimal? GiaBan { get; set; }
        public int? SoTrang { get; set; }
        public int? TrangThai { get; set; }
    }
}
