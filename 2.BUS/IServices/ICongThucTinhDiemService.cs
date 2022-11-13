using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface ICongThucTinhDiemService
    {
        public string Add(CongThucTInhDiemView obj);
        public string Remove(CongThucTInhDiemView obj);
        public string Update(CongThucTInhDiemView obj);
        public List<CongThucTInhDiemView> GetAll();
    }
}
