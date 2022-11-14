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
    public class LichSuDiemTichService : ILichSuDiemTichService
    {
        private ILichSuDiemTieuRepository _ilichSuDiemTichRepository = new LichSuDiemTieuRepository();
        private IDiemtieudungRepository __idiemtieudungRepository = new DiemtieudungRepository();
        private ICongThucTinhDiemRepository _icongThucTinhDiemRepository = new CongThucTinhDiemRepository();
        private IKhachHangRepository _ikhachHangRepository = new KhachHangRepository();
        public LichSuDiemTichService()
        {

        }
        public string Add(LichSuDiemTich obj)
        {
            if (obj == null) return "Thêm thất bại";
            if (_ilichSuDiemTichRepository.Add(obj)) return "Thêm thành công";
            return "Thêm thất bại";
        }

        public List<LichSuDiemTich> GetAll()
        {
            return _ilichSuDiemTichRepository.GetAll();
        }

        public List<LichSuDiemTichView> GetAllView()
        {
            var templist = (from a in _ilichSuDiemTichRepository.GetAll()
                            join b in _icongThucTinhDiemRepository.GetAll() on a.IdCttinh equals b.Id
                            join c in __idiemtieudungRepository.GetAll() on a.IddiemTieuDung equals c.Id
                            join d in _ikhachHangRepository.getall() on c.IdKh equals d.Id
                            select new LichSuDiemTichView
                            {
                                Id = a.Id,
                                Idcongthuc = b.Id,
                                MaKh = d.Ma,
                                Macongthuc = b.Ma,
                                Ma = a.Ma,
                                Sodiemtich = a.SoDiemTich,
                                Ngaysudung = a.NgaySuDung,
                                Tongtien = a.TongTien,
                                Trangthai = a.TrangThai,
                            }).ToList();
            return templist;

        }

        public string Remove(LichSuDiemTich obj)
        {
            if (obj == null) return "Chuyển trạng thái thất bại";
            if (_ilichSuDiemTichRepository.Remove(obj)) return "Chuyển trạng thái thành công";
            return "Thêm thất bại";
        }

        public string Update(LichSuDiemTich obj)
        {
            if (obj == null) return "Sửa thất bại";
            if (_ilichSuDiemTichRepository.Update(obj)) return "Sửa thành công";
            return "Sửa thất bại";
        }
    }
}
