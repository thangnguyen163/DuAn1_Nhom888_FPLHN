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
    public class LichSuDiemDungService : ILichSuDiemDungService
    {
        private ILichsudiemdungRepository _ilichSuDiemdungRepository = new LichSuDiemDungRepository();
        private IDiemtieudungRepository __idiemtieudungRepository = new DiemtieudungRepository();
        private ICongThucTinhDiemRepository _icongThucTinhDiemRepository = new CongThucTinhDiemRepository();
        private IKhachHangRepository _ikhachHangRepository = new KhachHangRepository();
        public LichSuDiemDungService()
        {

        }
        public string Add(LichSuDiemDung obj)
        {
            if (obj == null) return "Thêm thất bại";
            if (_ilichSuDiemdungRepository.Add(obj)) return "Thêm thành công";
            return "Thêm thất bại";
        }

        public List<LichSuDiemDung> GetAll()
        {
           return _ilichSuDiemdungRepository.GetAll();
        }

        public List<LichSuDiemDungView> GetAllView()
        {
            var templist = (from a in _ilichSuDiemdungRepository.GetAll()
                            join b in _icongThucTinhDiemRepository.GetAll() on a.IdCttinh equals b.Id
                            join c in __idiemtieudungRepository.GetAll() on a.IddiemTieuDung equals c.Id
                            join d in _ikhachHangRepository.getall() on c.IdKh equals d.Id
                            select new LichSuDiemDungView
                            {
                                Id = a.Id,
                                Idcongthuc = b.Id,
                                MaKh = d.Ma,
                                Macongthuc = b.Ma,
                                Ma = a.Ma,
                                Sodiemdung = a.SoDiemDung,
                                Ngaysudung = a.NgaySuDung,
                                Tongtien = a.TongTien,
                                Trangthai = a.TrangThai,
                            }).ToList();
            return templist;
        }

        public string Remove(LichSuDiemDung obj)
        {
            if (obj == null) return "Chuyển trạng thái thất bại";
            if (_ilichSuDiemdungRepository.Remove(obj)) return "Chuyển trạng thái thành công";
            return "Thêm thất bại";
        }

        public string Update(LichSuDiemDung obj)
        {
            if (obj == null) return "Sửa thất bại";
            if (_ilichSuDiemdungRepository.Update(obj)) return "Sửa thành công";
            return "Sửa thất bại";
        }
    }
}
