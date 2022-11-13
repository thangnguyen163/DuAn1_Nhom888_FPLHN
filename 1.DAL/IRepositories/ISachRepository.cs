using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositoties
{
    public interface ISachRepository
    {
        bool AddSach(Sach obj);
        bool UpdateSach(Sach obj);
        bool DeleteSach(Sach obj);
        List<Sach> GetAllSach();
    }
}
