using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositoties
{
    public interface IChiTietKhuyenMaiRepository
    {
        bool AddCTKhuyenMai(ChiTietKhuyenMai chiTietKhuyenMai);
        bool UpdateCTKhuyenMai(Guid id,ChiTietKhuyenMai chiTietKhuyenMai);

        bool DeleteCTKhuyenMai(Guid id);
        
        List<ChiTietKhuyenMai> GetAllCTKhuyenMai();
    }
}
