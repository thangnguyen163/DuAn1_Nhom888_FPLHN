using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositoties
{
    public interface ITheLoaiRepository
    {
        bool AddTheLoai(TheLoai obj);
        bool UpdateTheLoai(TheLoai obj);
        bool DeleteTheLoai(TheLoai obj);
        List<TheLoai> GetAllTheLoai();
    }
}
