using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IDiemtieudungRepository
    {
        public bool Add(DiemTieuDung obj);
        public bool Update(DiemTieuDung obj);
        public bool Remove(DiemTieuDung obj);
        public List<DiemTieuDung> GetAll();
    }
}
