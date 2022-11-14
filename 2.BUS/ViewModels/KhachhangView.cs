using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class KhachhangView
    {
        public Guid ID { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string  Sodt { get; set; }
        public Guid Idiemtieudung { get; set; }
        public string Madiemtieudung { get; set; }
        public int? Trangthai { get; set; }
    }
}
