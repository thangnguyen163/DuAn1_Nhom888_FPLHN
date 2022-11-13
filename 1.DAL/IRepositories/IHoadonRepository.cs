using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IHoadonRepository
    {
        public bool Add(HoaDon obj);
        public bool Update(HoaDon obj);
        public bool Remove(HoaDon obj);
        public List<HoaDon> GetAll();
    }
}
