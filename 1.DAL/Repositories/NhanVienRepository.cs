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
        public NhanVienRepository()
        {
            _DBContext = new FpolyDBContext();
        }
        public bool addNhanVien(NhanVien nhanVien)
        {
            if (nhanVien == null) return false;
            _DBContext.Add(nhanVien);
            _DBContext.SaveChanges();
            return true;
        }

        public bool deleteNhanVien(Guid? Id)
        {
            if (Id == null) return false;
            var a = _DBContext.NhanViens.FirstOrDefault(p => p.Id == Id);
            _DBContext.Remove(a);
            _DBContext.SaveChanges();
            return true;
        }

        public bool QuenMatKhau(NhanVien nhanVien)
        {
            if (nhanVien == null) return false;
            var x = _DBContext.NhanViens.FirstOrDefault(p => p.Id == nhanVien.Id);
            x.MatKhau = nhanVien.MatKhau;
            _DBContext.NhanViens.Update(x);
            _DBContext.SaveChanges();
            return true;
        }

        public List<NhanVien> GetAllNhanVien()
        {
            return _DBContext.NhanViens.ToList();
        }

        public bool updateNhanVien(Guid? Id, NhanVien nhanVien)
        {
            if (nhanVien == null) return false;
            var a = _DBContext.NhanViens.FirstOrDefault(p => p.Id == Id);
            a.Ma=nhanVien.Ma;
            a.Ten=nhanVien.Ten;
            a.GioiTinh=nhanVien.GioiTinh;
            a.NamSinh = nhanVien.NamSinh;
            a.Email = nhanVien.Email;
            a.DiaChi=nhanVien.DiaChi;
            a.Sdt=nhanVien.Sdt;
            a.Cccd = nhanVien.Cccd;
            a.MatKhau=nhanVien.MatKhau;
            a.Anh=nhanVien.Anh;
            a.IdchucVu=nhanVien.IdchucVu;
            a.TrangThai = nhanVien.TrangThai;
           
            _DBContext.Update(a);
            _DBContext.SaveChanges();
            return true;
        }

        public bool save(NhanVien nhanVien)
        {
            _DBContext.SaveChanges();
            return true;
        }
    }
}
