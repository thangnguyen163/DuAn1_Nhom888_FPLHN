using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IChitietHoadonRepository
    {
        public bool Add(HoaDonChiTiet obj);
        public bool Update(HoaDonChiTiet obj);
        public bool Remove(HoaDonChiTiet obj);
        public List<HoaDonChiTiet> GetAll();
        // test
    }
}
