using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class DiemTieuDungView
    {
        public Guid ID { get; set; }
        public Guid? IDkhachhang { get; set; }
        public string Makh { get; set; }
        public string  Madiemtieudung { get; set; }
        public int? Sodiem { get; set; }
        public int? Trangthai { get; set; }
    }
}
