using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositoties
{
    public interface IChiTietSachRepository
    {
        bool Add(ChiTietSach chiTietSach);
        bool Update(Guid? id, ChiTietSach chiTietSach);
        bool Delete(Guid? id, ChiTietSach chiTietSach);
        List<ChiTietSach> GetAll();
    }
}
