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
    public class CongThucTinhDiemService : ICongThucTinhDiemService
    {
        private ICongThucTinhDiemRepository _icongThucTinhDiemRepository = new CongThucTinhDiemRepository();
        public CongThucTinhDiemService()
        {

        }
        public string Add(CongThucTinhDiem obj)
        {
            if (obj == null) return "Thêm thất bại";
            if (_icongThucTinhDiemRepository.Add(obj)) return "Thêm thành công";
            return "Thêm thất bại";
        }

        public List<CongThucTInhDiemView> GetAll()
        {
            var templst = (from a in _icongThucTinhDiemRepository.GetAll()
                           select new CongThucTInhDiemView
                           {
                               Id = a.Id,
                               Ma = a.Ma,
                               TongDiem = a.TongDiem,
                               Tongtien = a.TongTien,
                               Heso = a.HeSo,
                               Giamgia = a.GiamGia,
                               Trangthai = a.TrangThai
                           }).ToList();
            return templst;
        }

        public string Remove(CongThucTinhDiem obj)
        {
            if (obj == null) return "Chuyển trạng thái thất bại";
            if (_icongThucTinhDiemRepository.Remove(obj)) return "Chuyển trạng thái thành công";
            return "Chuyển trạng thái thất bại";
        }

        public string Update(CongThucTinhDiem obj)
        {
            if (obj == null) return "Sửa thất bại";
            if (_icongThucTinhDiemRepository.Update(obj)) return "Sửa thành công";
            return "Sửa thất bại";
        }
    }
}
