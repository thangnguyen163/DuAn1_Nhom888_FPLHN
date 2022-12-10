using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Serivces
{
    public class HoaDonService : IHoaDonService
    {
        private IHoadonRepository _ihoaDonRepository = new HoadonRepository();
        private IDiemtieudungRepository _idiemtieudungRepository = new DiemtieudungRepository();
        private ILichsudiemdungRepository _ilichsudiemdungRepository = new LichSuDiemDungRepository();
        private ILichSuDiemTieuRepository _ilichSuDiemTieuRepository = new LichSuDiemTieuRepository();
        private ICongThucTinhDiemRepository _icongThucTinhDiemRepository = new CongThucTinhDiemRepository();
        private INhanVienRepository _inhanVienRepository = new NhanVienRepository();
        private IKhachHangRepository _ikhachHangRepository = new KhachHangRepository();
        private IPhuongThucThanhToanRepositrory _iphuongThucThanhToanRepositrory = new PhuongThucThanhToanRepository();
        public string Add(HoaDon obj)
        {
            if (obj == null) return "Thêm hóa đơn thất bại";
            if (_ihoaDonRepository.Add(obj)) return "Thêm thành công";
            return "Thêm thất bại";

        }

        public List<HoadonView> GetAll()
        {
            var lst = (from a in _ihoaDonRepository.GetAll()
                       join b in _ikhachHangRepository.getall() on a.Idkh equals b.Id
                       join c in _inhanVienRepository.GetAllNhanVien() on a.Idnv equals c.Id
                       join e in _idiemtieudungRepository.GetAll() on b.IddiemTieuDung equals e.Id
                       join f in _iphuongThucThanhToanRepositrory.GetAll() on a.IdphuongThucThanhToan equals f.Id
                       select new HoadonView()
                       {
                           Id = a.Id,
                           Makh = b.Ma,
                           Iddiemtieudung = e.Id,
                           Manv = c.Ma,
                           Mahd = a.MaHd,
                           Ngaytao = a.NgayTao,
                           NgayShip = a.NgayShip,
                           Thue = a.Thue,
                           Giamgia = a.GiamGia,
                           tongtien = a.TongTien,
                           ghichu = a.GhiChu,
                           Tenkh = b.Ten,
                           Tennv = c.Ten,
                           Trangthai = a.TrangThai,
                           Sodiem = e.SoDiem,
                           tiencoc = a.TienCoc,
                           tienship = a.TienShip,
                           TenPTTT = f.Ten,
                           DiaChi = a.DiaChi,
                           TienMat = a.TienMat,
                           TienCK = a.TienChuyenKhoan
                       }).ToList();
            return lst;
        }

        public List<HoaDon> GetAllHoaDon()
        {
            return _ihoaDonRepository.GetAll();
        }

        public string Remove(HoaDon obj)
        {
            if (obj == null) return "Xoa hóa đơn thất bại";
            if (_ihoaDonRepository.Remove(obj)) return "Xoa thành công";
            return "Xoa thất bại";
        }

        public string Update(HoaDon obj)
        {
            if (obj == null) return "Sua hóa đơn thất bại";
            if (_ihoaDonRepository.Update(obj)) return "Sua thành công";
            return "Sua thất bại";
        }
    }
}