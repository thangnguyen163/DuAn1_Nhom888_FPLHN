using _1.DAL.DomainClass;
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
        public string Add(CongThucTinhDiem obj);
        public string Remove(CongThucTinhDiem obj);
        public string Update(CongThucTinhDiem obj);
        public List<CongThucTinhDiem> GetAll();
        public List<CongThucTInhDiemView> GetAllView();
    }
}
