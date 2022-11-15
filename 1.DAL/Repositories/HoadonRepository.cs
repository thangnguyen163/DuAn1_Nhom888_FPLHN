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
            return dBContext.HoaDons.ToList();
        }

        public bool Remove(HoaDon obj)
        {
            if (obj == null) return false;
            var tempobj = dBContext.HoaDons.FirstOrDefault(x => x.Id == obj.Id);
            dBContext.HoaDons.Remove(tempobj);
            dBContext.SaveChanges();
            return true;

        }

        public bool Update(HoaDon obj)
        {
            if (obj == null) return false;
            var tempobj = dBContext.HoaDons.FirstOrDefault(x => x.Id == obj.Id);
            tempobj.Idkh = obj.Idkh;
            tempobj.Idnv = obj.Idnv;
            tempobj.IddiemTich = obj.IddiemTich;
            tempobj.IddiemDung = obj.IddiemDung;
            tempobj.MaHd = obj.MaHd;
            tempobj.NgayTao = obj.NgayTao;
            tempobj.Thue = obj.Thue;
            tempobj.GiamGia = obj.GiamGia;
            tempobj.TongTien = obj.TongTien;
            tempobj.GhiChu = obj.GhiChu;
            tempobj.TrangThai = obj.TrangThai;
            dBContext.HoaDons.Update(tempobj);
            dBContext.SaveChanges();
            return true;
        }
    }
}
