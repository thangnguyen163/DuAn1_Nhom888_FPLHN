using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using _2.BUS.Service;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Serivces
{
    public class KhachHangService : IKhachHangService
    {
        private IKhachHangRepository _khachHangRepository;
        private IDiemtieudungRepository _idiemtieudungRepository;
        public KhachHangService()
        {
            _khachHangRepository = new KhachHangRepository();
            _idiemtieudungRepository = new DiemtieudungRepository();
        }
      

        public string addKhachHang(KhachHang khachHang, DiemTieuDung diemTieuDung)
        {
            if (diemTieuDung == null) return "Thêm thất bại";
            //if (_idiemtieudungRepository.Add(diemTieuDung)) return "Thêm thành công";
            //return "Thêm thất bại";

            var dtd = diemTieuDung;
            dtd.Id = diemTieuDung.Id;
            // dtd.IdKh = khachHang.Id;
            dtd.Ma = dtd.Ma;
            dtd.SoDiem = 0;
            dtd.TrangThai = 1;

            var kh = khachHang;
            kh.Id = khachHang.Id;
            kh.Ma = khachHang.Ma;
            kh.Ten = khachHang.Ten;
            kh.Sdt = khachHang.Sdt;
            kh.IddiemTieuDung = diemTieuDung.Id;
            kh.TrangThai = khachHang.TrangThai;
            if ((_idiemtieudungRepository.Add(dtd)) && _khachHangRepository.addKhachHang(kh)) return "Thêm thành công";
            return "Thêm thất bại";
        }

        public string deleteKhachHang(KhachHang khachHang)
        {
            if (khachHang == null) return "Xóa thất bại";
            if (_khachHangRepository.deleteKhachHang(khachHang)) return "Xóa thành công";
            return "Xóa thất bại";
        }

        public List<KhachHang> getAll()
        {
            return _khachHangRepository.getall();
        }

        public List<KhachhangView> getKhachHangFromDB()
        {
            var templst = (from a in _idiemtieudungRepository.GetAll()
                           join b in _khachHangRepository.getall() on a.Id equals b.IddiemTieuDung
                           select new KhachhangView
                           {
                               ID = b.Id,
                               Ma = b.Ma,
                               Ten = b.Ten,
                               Sodt = b.Sdt,
                              Madiemtieudung = a.Ma,
                               Trangthai = b.TrangThai,
                               DiaChi = b.DiaChi,
                           }).ToList();
            return templst;
        }

        public string updateKhachHang(KhachHang khachHang)
        {
            if (khachHang == null) return "Sửa thất bại";
            if (_khachHangRepository.updateKhachHang(khachHang)) return "Sửa thành công";
            return "Sửa thất bại";
        }
    }
}
