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
                       select new HoadonView()
                       {
                           Id = a.Id,
                           Makh = b.Ma,
                           Manv = c.Ma,
                           Mahd = a.MaHd,
                           Ngaytao = a.NgayTao,
                           Thue = a.Thue,
                           Giamgia = a.GiamGia,
                           tongtien = a.TongTien,
                           ghichu = a.GhiChu,
                           Tenkh = b.Ten,
                           Tennv = c.Ten,
                           Trangthai = a.TrangThai
                           
                       }).ToList();
            return lst;
        }

        public string Remove(HoaDon obj)
        {
            if (obj == null) return "Thêm hóa đơn thất bại";
            if (_ihoaDonRepository.Remove(obj)) return "Thêm thành công";
            return "Thêm thất bại";
        }

        public string Update(HoaDon obj)
        {
            if (obj == null) return "Thêm hóa đơn thất bại";
            if (_ihoaDonRepository.Update(obj)) return "Thêm thành công";
            return "Thêm thất bại";
        }
    }
}
