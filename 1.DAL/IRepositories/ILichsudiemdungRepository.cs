using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface ILichsudiemdungRepository
    {
        public bool Add(LichSuDiemDung obj);
        public bool Update(LichSuDiemDung obj);
        public bool Remove(LichSuDiemDung obj);
        public List<LichSuDiemDung> GetAll();
    }
}
