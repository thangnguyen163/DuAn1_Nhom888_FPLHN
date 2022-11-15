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
    public class HoaDonChiTietRepository : IChitietHoadonRepository
    {
        public FpolyDBContext dBContext = new FpolyDBContext();

        public bool Add(HoaDonChiTiet obj)
        {
            if (obj == null) return false;
            dBContext.HoaDonChiTiets.Add(obj);
            dBContext.SaveChanges();
            return true;

        
        }

        public List<HoaDonChiTiet> GetAll()
        {
            return dBContext.HoaDonChiTiets.ToList();
        }

        public bool Remove(HoaDonChiTiet obj)
        {
            if (obj == null) return false;
            var tempobj = dBContext.HoaDonChiTiets.FirstOrDefault(x => x.Id == obj.Id);
            dBContext.HoaDonChiTiets.Remove(tempobj);
            dBContext.SaveChanges();
            return true;
        }

        public bool Update(HoaDonChiTiet obj)
        {
            if (obj == null) return false;
            var tempobj = dBContext.HoaDonChiTiets.FirstOrDefault(x => x.IdChiTietSach == obj.IdChiTietSach && x.IdHoaDon == obj.IdHoaDon);  
            tempobj.SoLuong = obj.SoLuong;
            tempobj.ThanhTien = obj.ThanhTien;
            dBContext.HoaDonChiTiets.Update(tempobj);
            dBContext.SaveChanges();
            return true;
        }
    }
}
