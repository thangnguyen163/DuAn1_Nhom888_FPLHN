using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface ICongThucTinhDiemRepository
    {
        public bool Add(CongThucTinhDiem obj);
        public bool Update(CongThucTinhDiem obj);
        public bool Remove(CongThucTinhDiem obj);
        public List<CongThucTinhDiem> GetAll();
    }
}
