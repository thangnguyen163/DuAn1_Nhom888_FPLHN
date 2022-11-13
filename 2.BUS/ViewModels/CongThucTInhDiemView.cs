using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class CongThucTInhDiemView
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public decimal? Tongtien { get; set; }
        public decimal? Heso { get; set; }
        public int? Giamgia { get; set; }
        public decimal? TongDiem { get; set; }
        public int? Trangthai { get; set; }
    }
}
