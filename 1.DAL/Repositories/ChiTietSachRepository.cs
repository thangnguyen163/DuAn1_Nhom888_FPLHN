using _1.DAL.Context;
using _1.DAL.DomainClass;
using _1.DAL.IRepositoties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositoties
{
    public class ChiTietSachRepository : IChiTietSachRepository
    {
        private FpolyDBContext _dbContext = new FpolyDBContext();
        private List<ChiTietSach> _lstChiTietSach;
        public ChiTietSachRepository()
        {
            _dbContext = new FpolyDBContext();
            _lstChiTietSach = new List<ChiTietSach>();
        }
        public bool Add(ChiTietSach chiTietSach)
        {
            if (chiTietSach == null) return false;
            _dbContext.Add(chiTietSach);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(Guid? id, ChiTietSach chiTietSach)
        {
            if (chiTietSach == null) return false;
            var a = _dbContext.ChiTietSaches.FirstOrDefault(c => c.Id == id);
            a.TrangThai = 0;
            _dbContext.Update(a);
            _dbContext.SaveChanges();
            return true;
        }

        public List<ChiTietSach> GetAll()
        {
            return _dbContext.ChiTietSaches.ToList();
        }

        public bool Update(Guid? id, ChiTietSach chiTietSach)
        {
            if (chiTietSach == null) return false;
            var a = _dbContext.ChiTietSaches.FirstOrDefault(c => c.Id == id);
            a.IdSach = chiTietSach.IdSach;
            a.IdNxb = chiTietSach.IdNxb;
            a.IdTacGia = chiTietSach.IdTacGia;
            a.IdNhaPhatHanh = chiTietSach.IdNhaPhatHanh;
            a.IdLoaiBia = chiTietSach.IdLoaiBia;
            a.Ma = chiTietSach.Ma;
            a.Anh = chiTietSach.Anh;
            a.MaVach = chiTietSach.MaVach;
            a.KichThuoc = chiTietSach.KichThuoc;
            a.NamXuatBan = chiTietSach.NamXuatBan;
            a.MoTa = chiTietSach.MoTa;
            a.SoLuong = chiTietSach.SoLuong;
            a.GiaNhap = chiTietSach.GiaNhap;
            a.GiaBan = chiTietSach.GiaBan;
            a.TrangThai = chiTietSach.TrangThai;
            _dbContext.Update(a);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
