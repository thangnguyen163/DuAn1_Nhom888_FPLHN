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
    public class DiemTieuDungService : IDiemTieuDungService
    {
        private IDiemtieudungRepository _idiemtieudungRepository = new DiemtieudungRepository();
        private IKhachHangRepository _ikhachHangRepository = new KhachHangRepository();
        public string Add(DiemTieuDung obj)
        {
            if (obj == null) return "Thêm thất bại";
            if (_idiemtieudungRepository.Add(obj)) return "Thêm thành công";
            return "Thêm thất bại";
        }

        public List<DiemTieuDung> GetAll()
        {
            return _idiemtieudungRepository.GetAll();
        }

        public List<DiemTieuDungView> GetAllView()
        {
            var templst = (from a in _idiemtieudungRepository.GetAll()
                          join b in _ikhachHangRepository.getall() on a.IdKh equals b.Id
                          select new DiemTieuDungView
                          {
                              ID = a.Id,
                              IDkhachhang = a.IdKh,
                              Makh = b.Ma,
                              Madiemtieudung = a.Ma,
                              Sodiem = a.SoDiem,
                              Trangthai = a.TrangThai,
                          }).ToList();
            return templst;
        }

        public string Remove(DiemTieuDung obj)
        {
            if (obj == null) return "Chuyển trạng thái thất bại";
            if (_idiemtieudungRepository.Remove(obj)) return "Chuyển trạng thái thành công";
            return "Chuyển trạng thái thất bại";
        }

        public string Update(DiemTieuDung obj)
        {
            if (obj == null) return "Sửa thất bại";
            if (_idiemtieudungRepository.Update(obj)) return "Sửa thành công";
            return "Sửa thất bại";
        }
    }
}
