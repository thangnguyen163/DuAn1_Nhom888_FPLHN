using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class LichSuDiemDungView
    {
        public Guid Id { get; set; }
        public Guid Idcongthuc { get; set; }
        public string MaKh { get; set; }
        public string Macongthuc { get; set; }
        public string Ma { get; set; }
        public int ?Sodiemdung { get; set; }
        public DateTime? Ngaysudung { get; set; }
        public decimal? Tongtien { get; set; }
        public int? Trangthai { get; set; }
    }
}
