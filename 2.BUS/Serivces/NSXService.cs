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
    public class NSXService : INSXService
    {
        INSXRepository _iNSXRepository;
        public NSXService()
        {
            _iNSXRepository = new NSXRepository();
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

        public List<NSXView> GetAll()
        {
            List<NSXView> lstnxbv = new List<NSXView>();
            lstnxbv =
                (from a in _iNSXRepository.GetAllNSX()
                 select new NSXView
                 {
                     Id = a.Id,
                     Ma = a.Ma,
                     Ten = a.Ten,
                     TrangThai = a.TrangThai
                 }).ToList();
            return lstnxbv;
        }

        public string Update(Nxb obj)
        {
            if (obj == null) return "Cập nhật không thành công";
            if (_iNSXRepository.UpdateNSX(obj)) return "Cập nhật thành công";
            return "Cập nhật không thành công";
        }
    }
}
