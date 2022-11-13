using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IService
{
    public interface INhaPhatHanhService
    {
        public string Add(NhaPhatHanh nhaPhatHanh);
        public string Update(Guid id,NhaPhatHanh nhaPhatHanh);
        public string Delete(Guid id);
        List<NhaPhatHanh> GetAll();
    }
}
