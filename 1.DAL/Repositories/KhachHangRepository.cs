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
    public class KhachHangRepository : IKhachHangRepository
    {
        private FpolyDBContext _dbContext;
        public KhachHangRepository()
        {
            _dbContext = new FpolyDBContext();
        }
        public bool addKhachHang(KhachHang khachHang)
        {
            if (khachHang == null) return false;
            _dbContext.KhachHangs.Add(khachHang);
            _dbContext.SaveChanges();
            return true;
        }

        public bool deleteKhachHang(KhachHang khachHang)
        {
            if (khachHang == null) return false;
            var a = _dbContext.KhachHangs.FirstOrDefault(x => x.Id == khachHang.Id);
            a.TrangThai = 0;
            _dbContext.KhachHangs.Update(a);
            _dbContext.SaveChanges();
            return true;
        }

        public List<KhachHang> getall()
        {
            return _dbContext.KhachHangs.ToList();
        }

        public bool updateKhachHang( KhachHang khachHang)
        {
            if (khachHang == null) return false;
            var a = _dbContext.KhachHangs.FirstOrDefault(x => x.Id == khachHang.Id);
            a.Ma = khachHang.Ma;
            a.Ten = khachHang.Ten;
            a.Sdt = khachHang.Sdt;
            //a.IddiemTieuDung = khachHang.IddiemTieuDung;
            a.TrangThai = khachHang.TrangThai;
            _dbContext.KhachHangs.Update(a);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
