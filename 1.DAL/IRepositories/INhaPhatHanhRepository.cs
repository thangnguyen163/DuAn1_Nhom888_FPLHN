using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositoties
{
    public interface INhaPhatHanhRepository
    {
        bool AddNhaPhatHanh(NhaPhatHanh nhaPhatHanh);
        bool UpdateNhaPhatHanh(Guid id, NhaPhatHanh nhaPhatHanh);
        bool DeleteNhaPhatHanh(Guid id);
        List<NhaPhatHanh> GetNhaPhatHanhs();
    }
}
