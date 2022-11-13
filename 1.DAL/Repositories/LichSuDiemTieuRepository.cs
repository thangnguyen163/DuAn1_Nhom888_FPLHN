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
    public class LichSuDiemTieuRepository : ILichSuDiemTieuRepository
    {
        public FpolyDBContext _DbContext = new FpolyDBContext();
        public LichSuDiemTieuRepository()
        {

        }
        public bool Add(LichSuDiemTich obj)
        {
            if (obj == null) return false;
            _DbContext.LichSuDiemTiches.Add(obj);
            _DbContext.SaveChanges();
            return true;
        }

        public List<LichSuDiemTich> GetAll()
        {
            return _DbContext.LichSuDiemTiches.ToList();
        }

        public bool Remove(LichSuDiemTich obj)
        {
            if (obj == null) return false;
            var tempobj = _DbContext.LichSuDiemTiches.FirstOrDefault(x => x.Id == obj.Id);
            tempobj.TrangThai = 0;
            _DbContext.LichSuDiemTiches.Update(tempobj);
            _DbContext.SaveChanges();
            return true;
        }

        public bool Update(LichSuDiemTich obj)
        {
            if (obj == null) return false;
            var tempobj = _DbContext.LichSuDiemTiches.FirstOrDefault(x => x.Id == obj.Id);
            tempobj.IdCttinh = obj.IdCttinh;
            tempobj.Ma = obj.Ma;
            tempobj.SoDiemTich = obj.SoDiemTich;
            tempobj.NgaySuDung = obj.NgaySuDung;
            tempobj.TongTien = obj.TongTien;
            tempobj.TrangThai = obj.TrangThai;          
            _DbContext.LichSuDiemTiches.Update(tempobj);
            _DbContext.SaveChanges();
            return true;
        }
    }
}
