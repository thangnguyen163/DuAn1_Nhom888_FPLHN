using _1.DAL.Context;
using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositories
{
    public class HoadonRepository: IHoadonRepository
    {
        public FpolyDBContext dBContext = new FpolyDBContext();

        public bool Add(HoaDon obj)
        {
            if (obj == null) return false;
            dBContext.HoaDons.Add(obj);
            dBContext.SaveChanges();
            return true;
        }

        public List<HoaDon> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(HoaDon obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(HoaDon obj)
        {
            throw new NotImplementedException();
        }
    }
}
