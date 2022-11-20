using _1.DAL.DomainClass;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IHoaDonService 
    {
        public string Add(HoaDon obj);
        public string Update(HoaDon obj);
        public string Remove(HoaDon obj);
        public List<HoadonView> GetAll();
        public List<HoaDon> GetAllHoaDon();
    }
}
