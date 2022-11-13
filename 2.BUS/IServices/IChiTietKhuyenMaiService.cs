using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IService
{
    public interface IChiTietKhuyenMaiService
    {
        public string Add(ChiTietKhuyenMai chiTietKhuyenMai);
        public string Update(Guid id, ChiTietKhuyenMai chiTietKhuyenMai);
        public string Delete(Guid id);
        List<ChiTietKhuyenMai> GetAll();
    }
}
