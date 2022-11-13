using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositoties
{
    public interface IKhuyenMaiRepository
    {
        bool AddKhuyenMai(KhuyenMai km);
        bool UpdateKhuyenMai(Guid id, KhuyenMai km);
        bool DeleteKhuyenMai(Guid id);
        List<KhuyenMai> GetKhuyenMais();
    }
}
