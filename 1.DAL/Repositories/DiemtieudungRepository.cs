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
    public class DiemtieudungRepository : IDiemtieudungRepository
    {
        public FpolyDBContext _DbContext  = new FpolyDBContext();
        public DiemtieudungRepository()
        {

        }
        public bool Add(DiemTieuDung obj)
        {
            if (obj == null) return false;
            _DbContext.DiemTieuDungs.Add(obj);
            _DbContext.SaveChanges();
            return true;
        }

        public List<DiemTieuDung> GetAll()
        {
            return _DbContext.DiemTieuDungs.ToList();
        }

        public bool Remove(DiemTieuDung obj)
        {
            if (obj == null) return false;
            var tempobj = _DbContext.DiemTieuDungs.FirstOrDefault(x => x.Id == obj.Id);
            tempobj.TrangThai = 0;
            _DbContext.DiemTieuDungs.Update(tempobj);
            _DbContext.SaveChanges();
            return true;
        }

        public bool Update(DiemTieuDung obj)
        {
            if (obj == null) return false;
            var tempobj = _DbContext.DiemTieuDungs.FirstOrDefault(x => x.Id == obj.Id);
            tempobj = obj;
            _DbContext.DiemTieuDungs.Update(tempobj);
            _DbContext.SaveChanges();
            return true;
        }
    }
}
