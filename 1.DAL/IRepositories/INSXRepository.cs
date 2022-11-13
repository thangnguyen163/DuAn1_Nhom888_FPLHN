using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositoties
{
    public interface INSXRepository
    {
        bool AddNSX(Nxb obj);
        bool UpdateNSX(Nxb obj);
        bool DeleteNSX(Nxb obj);
        List<Nxb> GetAllNSX();
    }
}
