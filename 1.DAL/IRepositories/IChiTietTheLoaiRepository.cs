using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositoties
{
    public interface IChiTietTheLoaiRepository
    {
        bool AddCTTheLoai(ChiTietTheLoai obj);
        bool UpdateCTTheLoai(ChiTietTheLoai obj);
        bool DeleteCTTheLoai(ChiTietTheLoai obj);
        List<ChiTietTheLoai> GetAllCTTheLoai();

    }
}
