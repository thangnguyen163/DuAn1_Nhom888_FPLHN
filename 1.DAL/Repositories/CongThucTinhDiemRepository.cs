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
    public class CongThucTinhDiemRepository: ICongThucTinhDiemRepository
    {
        public FpolyDBContext _DbContext = new FpolyDBContext();
        public CongThucTinhDiemRepository()
        {

        }

        public bool Add(CongThucTinhDiem obj)
        {
            if (obj == null) return false;
            _DbContext.CongThucTinhDiems.Add(obj);
            _DbContext.SaveChanges();
            return true;
        }

        public List<CongThucTinhDiem> GetAll()
        {
           return _DbContext.CongThucTinhDiems.ToList();
        }

        public bool Remove(CongThucTinhDiem obj)
        {
            if (obj == null) return false;
            var tempobj = _DbContext.CongThucTinhDiems.FirstOrDefault(x => x.Id == obj.Id);
            tempobj.TrangThai = 0;
            _DbContext.CongThucTinhDiems.Update(tempobj);
            _DbContext.SaveChanges();
            return true;
        }

        public bool Update(CongThucTinhDiem obj)
        {
            if (obj == null) return false;
            var tempobj = _DbContext.CongThucTinhDiems.FirstOrDefault(x => x.Id == obj.Id);
            tempobj.Ma = obj.Ma;
            tempobj.TongDiem = obj.TongDiem;
            tempobj.HeSo = obj.HeSo;
            tempobj.GiamGia = obj.GiamGia;
            tempobj.TongTien=obj.TongTien;
            tempobj.TrangThai = obj.TrangThai;
            _DbContext.CongThucTinhDiems.Update(tempobj);
            _DbContext.SaveChanges();
            return true;
        }
    }
}
