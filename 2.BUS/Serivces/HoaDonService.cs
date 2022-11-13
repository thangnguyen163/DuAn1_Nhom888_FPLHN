using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Serivces
{
    public class HoaDonService : IHoaDonService
    {
        private IHoadonRepository hoaDonRepository = new HoadonRepository();
        public string Add(HoaDon obj)
        {
            throw new NotImplementedException();
        }

        public List<HoadonView> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Remove(HoaDon obj)
        {
            throw new NotImplementedException();
        }

        public string Update(HoaDon obj)
        {
            throw new NotImplementedException();
        }
    }
}
