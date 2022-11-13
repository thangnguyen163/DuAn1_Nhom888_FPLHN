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
    public class NXBService : INXBService
    {
        INXBRepository _iNSXRepository;
        public NXBService()
        {
            _iNSXRepository = new NXBRepository();
        }

        public string Add(Nxb obj)
        {
            if (obj == null) return "Thêm không thành công";
            if (_iNSXRepository.AddNSX(obj)) return "Thêm thành công";
            return "Thêm không thành công";
        }

        public string Delete(Nxb obj)
        {
            if (obj == null) return "Xóa không thành công";
            if (_iNSXRepository.DeleteNSX(obj)) return "Xóa thành công";
            return "Xóa không thành công";
        }

        public List<NXBView> GetAll()
        {
            List<NXBView> lstnxbv = new List<NXBView>();
            lstnxbv =
                (from a in _iNSXRepository.GetAllNSX()
                 select new NXBView
                 {
                     Id = a.Id,
                     Ma = a.Ma,
                     Ten = a.Ten,
                     TrangThai = a.TrangThai
                 }).ToList();
            return lstnxbv;
        }

        public List<NXBView> TimKiemTheoTen(string s)
        {
            List<NXBView> lsttimkiem = new List<NXBView>();
            lsttimkiem =
                (from a in _iNSXRepository.TimKiemTheoTen(s)
                 select new NXBView
                 {
                     Id = a.Id,
                     Ma = a.Ma,
                     Ten = a.Ten,
                     TrangThai = a.TrangThai
                 }).ToList();
            return lsttimkiem;
        }

        public string Update(Nxb obj)
        {
            if (obj == null) return "Cập nhật không thành công";
            if (_iNSXRepository.UpdateNSX(obj)) return "Cập nhật thành công";
            return "Cập nhật không thành công";
        }
    }
}
