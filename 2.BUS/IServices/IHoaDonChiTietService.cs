using _1.DAL.DomainClass;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IHoaDonChiTietService
    {
        public string Add(HoaDonChiTiet obj);
        public string Remove(HoaDonChiTiet obj);
        public string Update(HoaDonChiTiet obj);
        public List<HoaDonChiTietView> GetAll();
        public List<HoaDonChiTietView> GetAllbanhang(Guid id);
        
    }
}
