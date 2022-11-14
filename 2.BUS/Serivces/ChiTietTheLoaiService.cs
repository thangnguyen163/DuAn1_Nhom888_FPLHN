using _1.DAL.DomainClass;
using _1.DAL.IRepositoties;
using _1.DAL.Repositoties;
using _2.BUS.IService;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Service
{
    public class ChiTietTheLoaiService : IChiTietTheLoaiService
    {
        IChiTietTheLoaiRepository _ichiTietTheLoaiRepository;
        ITheLoaiRepository _itheLoaiRepository;
        IChiTietSachRepository _iChiTietSachRepository;
        ISachRepository _isachRepository;
        public ChiTietTheLoaiService()
        {
            _ichiTietTheLoaiRepository = new ChiTietTheLoaiRepository();
            _itheLoaiRepository = new TheLoaiRepository();
            _iChiTietSachRepository = new ChiTietSachRepository();
            _isachRepository = new SachRepository();
        }
        public string Add(ChiTietTheLoai obj)
        {
            if (obj == null) return "Thêm không thành công";
            if (_ichiTietTheLoaiRepository.AddCTTheLoai(obj)) return "Thêm thành công";
            return "Thêm không thành công";
        }

        public string Delete(ChiTietTheLoai obj)
        {
            if (obj == null) return "Xóa không thành công";
            if (_ichiTietTheLoaiRepository.DeleteCTTheLoai(obj)) return "Xóa thành công";
            return "Xóa không thành công";
        }

        public List<ChiTietTheLoaiView> GetAll()
        {
            List<ChiTietTheLoaiView> lstcttl = new List<ChiTietTheLoaiView>();
            lstcttl =
                (from cttl in _ichiTietTheLoaiRepository.GetAllCTTheLoai()
                 join tl in _itheLoaiRepository.GetAllTheLoai() on cttl.IdTheLoai equals tl.Id
                 join cts in _iChiTietSachRepository.GetAll() on cttl.IdChiTietSach equals cts.Id
                 join sach in _isachRepository.GetAllSach() on cts.IdSach equals sach.Id
                 select new ChiTietTheLoaiView()
                 {
                     Id = cttl.Id,
                     TheLoai = tl.Ten,
                     TenSach = sach.Ten,
                     Ma = cttl.Ma,
                     ChiTietTheLoai = cttl.Ten,
                     TrangThai = cttl.TrangThai
                 }).ToList();
            return lstcttl;
        }

        public List<ChiTietTheLoai> GetAllNoView()
        {
            return _ichiTietTheLoaiRepository.GetAllCTTheLoai();
        }

        public string Update(ChiTietTheLoai obj)
        {
            if (obj == null) return "Cập nhật không thành công";
            if (_ichiTietTheLoaiRepository.UpdateCTTheLoai(obj)) return "Cập nhật thành công";
            return "Cập nhật không thành công";
        }
    }
}
