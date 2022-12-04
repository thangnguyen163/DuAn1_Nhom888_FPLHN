using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using _1.DAL.IRepositoties;
using _1.DAL.Repositories;
using _1.DAL.Repositoties;
using _2.BUS.IServices;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Serivces
{
    public class HoaDonChiTietService : IHoaDonChiTietService
    {
        private IChitietHoadonRepository _ichitietHoadonRepository = new HoaDonChiTietRepository();
        private IChiTietSachRepository _ichiTietSachRepository = new ChiTietSachRepository();        
        private INhaPhatHanhRepository _inhaPhatHanhRepository = new NhaPhatHanhRepository();
        private ILoaiBiaRepository _iloaiBiaRepository = new LoaiBiaRepository();
        private ITacGiaRepository _itacGiaRepository = new TacGiaRepository();
        private ISachRepository _isachRepository = new SachRepository();
        private IHoadonRepository _ihoadonRepository = new HoadonRepository();
        private INXBRepository _inXBRepository = new NXBRepository();
        List<HoaDonChiTietView> _lst = new List<HoaDonChiTietView>();
        public HoaDonChiTietService()
        {

        }
        public string Add(HoaDonChiTiet obj)
        {
            if (obj == null) return "Thêm Thất bại";
            if (_ichitietHoadonRepository.Add(obj)) return "Thêm thành công";
            return "Thêm thất bại";                    
        }

        public List<HoaDonChiTietView> GetAll()
        {
            var templst = (from a in _ichitietHoadonRepository.GetAll()
                           join b in _ihoadonRepository.GetAll() on a.IdHoaDon equals b.Id
                           join c in _ichiTietSachRepository.GetAll() on a.IdChiTietSach equals c.Id
                           join d in _inhaPhatHanhRepository.GetNhaPhatHanhs() on c.IdNhaPhatHanh equals d.Id
                           join e in _iloaiBiaRepository.GetLoaiBia() on c.IdLoaiBia equals e.Id
                           join f in _inXBRepository.GetAllNSX() on c.IdNxb equals f.Id
                           join g in _itacGiaRepository.GetTacGia() on c.IdTacGia equals g.Id
                           join j in _isachRepository.GetAllSach() on c.IdSach equals j.Id
                           select new HoaDonChiTietView
                           {
                               ID = a.Id,
                               MaHd = b.MaHd,
                               MactSach = c.Ma,
                               Ma = a.Ma,
                               tenbia = e.Ten,
                               tennxb = f.Ten,
                               tentg = g.Ten,
                               Tensach = j.Ten,
                               Soluong = a.SoLuong,
                               Dongia = a.DonGia,
                               Thanhtien = a.ThanhTien,
                               Trangthai = a.TrangThai,
                               Idchitietsp = c.Id,
                               IDhoadon = a.IdHoaDon,
                           }).ToList();
            return templst;
        }

        public List<HoaDonChiTietView> GetAllbanhang(Guid id)
        {

            var templst1 = (from a in _ichitietHoadonRepository.GetAll()
                            join b in _ihoadonRepository.GetAll() on a.IdHoaDon equals b.Id
                            join c in _ichiTietSachRepository.GetAll() on a.IdChiTietSach equals c.Id
                            join d in _inhaPhatHanhRepository.GetNhaPhatHanhs() on c.IdNhaPhatHanh equals d.Id
                            join e in _iloaiBiaRepository.GetLoaiBia() on c.IdLoaiBia equals e.Id
                            join f in _inXBRepository.GetAllNSX() on c.IdNxb equals f.Id
                            join g in _itacGiaRepository.GetTacGia() on c.IdTacGia equals g.Id
                            join j in _isachRepository.GetAllSach() on c.IdSach equals j.Id
                            where b.Id == id
                            select new HoaDonChiTietView
                            {
                                ID = a.Id,
                                MaHd = b.MaHd,
                                MactSach = c.Ma,
                                Ma = a.Ma,
                                tenbia = e.Ten,
                                tennxb = f.Ten,
                                tentg = g.Ten,
                                Tensach = j.Ten,
                                Soluong = a.SoLuong,
                                Dongia = a.DonGia,
                                Thanhtien = a.ThanhTien,
                                Trangthai = a.TrangThai,
                                Idchitietsp = a.IdChiTietSach,
                                IDhoadon = a.IdHoaDon,

                            }).ToList();
            return templst1;
        }

        public List<HoaDonChiTiet> GetAllloadformsp()
        {
            return _ichitietHoadonRepository.GetAll().ToList();
        }

        public string Remove(HoaDonChiTiet obj)
        {
            if (obj == null) return "Xóa Thất bại";
            if (_ichitietHoadonRepository.Remove(obj)) return "Xóa thành công";
            return "Thêm thất bại";
        }

        public string Update(HoaDonChiTiet obj)
        {
            if (obj == null) return "Sửa Thất bại";
            if (_ichitietHoadonRepository.Update(obj)) return "Sửa thành công";
            return "Sửa thất bại";
        }
    }
}
