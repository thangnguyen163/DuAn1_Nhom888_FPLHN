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
    public class LichSuDiemDungRepository: ILichsudiemdungRepository
    {
        public FpolyDBContext _DbContext = new FpolyDBContext();
        public LichSuDiemDungRepository()
        {

        }
        public bool Add(LichSuDiemDung obj)
        {
            if (obj == null) return false;
            _DbContext.LichSuDiemDungs.Add(obj);
            _DbContext.SaveChanges();
            return true;
        }

        public List<LichSuDiemDung> GetAll()
        {
            return _DbContext.LichSuDiemDungs.ToList();
        }

        public bool Remove(LichSuDiemDung obj)
        {
            if (obj == null) return false;
            var tempobj = _DbContext.LichSuDiemDungs.FirstOrDefault(x => x.Id == obj.Id);
            tempobj.TrangThai = 0;
            _DbContext.LichSuDiemDungs.Remove(tempobj);
            _DbContext.SaveChanges();
            return true;
        }

        public bool Update(LichSuDiemDung obj)
        {
            if (obj == null) return false;
            var tempobj = _DbContext.LichSuDiemDungs.FirstOrDefault(x => x.Id == obj.Id);
            tempobj.IdCttinh = obj.IdCttinh;
            tempobj.Ma = obj.Ma;
            tempobj.SoDiemDung = obj.SoDiemDung;
            tempobj.NgaySuDung = obj.NgaySuDung;
            tempobj.TongTien = obj.TongTien;          
            tempobj.TrangThai = obj.TrangThai;
            _DbContext.LichSuDiemDungs.Update(tempobj);
            _DbContext.SaveChanges();
            return true;
        }
    }
}
