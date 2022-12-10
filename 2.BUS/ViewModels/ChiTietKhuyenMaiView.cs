
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class ChiTietKhuyenMaiView
    {
        public Guid IdKhuyenMai { get; set; }
        public Guid IdChiTietSach { get; set; }
        public Guid Id { get; set; }
        public string TenSach { get; set; }
        public string KhuyenMai { get; set; }
        public string MaCTKuyenMai { get; set; }
        public string TenKhuyenMai { get; set; }
        public string MoTa { get; set; }
        public int? TrangThai { get; set; }

    }
}
