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
    public class NhanVienRepository : INhanVienRepository
    {
        private FpolyDBContext _DBContext;
        private List<NhanVien> _lstNhanVien;
        public NhanVienRepository()
        {
            _DBContext = new FpolyDBContext();
            _lstNhanVien = new List<NhanVien>();
        }
        public bool addNhanVien(NhanVien nhanVien)
        {
            _DBContext.NhanViens.Add(nhanVien);
            _DBContext.SaveChanges();
            return true;
        }

        public bool deleteNhanVien(NhanVien nhanVien)
        {
            _DBContext.NhanViens.Remove(nhanVien);
            _DBContext.SaveChanges();
            return true;
        }

        public List<NhanVien> GetAllNhanVien()
        {
            _lstNhanVien = _DBContext.NhanViens.ToList();
            return _lstNhanVien;
        }

        public bool updateNhanVien(NhanVien nhanVien)
        {
            _DBContext.NhanViens.Update(nhanVien);
            _DBContext.SaveChanges();
            return true;
        }
    }
}
