using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public  interface ILichSuDiemTieuRepository
    {
        public bool Add(LichSuDiemTich obj);
        public bool Update(LichSuDiemTich obj);
        public bool Remove(LichSuDiemTich obj);
        public List<LichSuDiemTich> GetAll();
    }
}
