using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class HoaDonChiTietView
    {
        public Guid ID { get; set; }
        public  string MaHd { get; set; }
        public string MactSach { get; set; }
        public string Ma { get; set; }
        public Guid? Idchitietsp { get; set; }
        public Guid? IDhoadon { get; set; }
        public string tenbia { get; set; }
        public string tennxb { get; set; }
        public string tentg { get; set; }
        public string tentl { get; set; }
        public string tennph { get; set; }
        public string Tensach { get; set; }       
        public int? Soluong { get; set; }
        public int ?Dongia { get; set; }
        public decimal? Thanhtien { get; set; }
        public int? Trangthai { get; set; }
        public int? GiamGia { get; set; }
        public Guid? Idnv { get; set; }
    }
}
