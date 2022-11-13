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
    public class TheLoaiService : ITheLoaiService
    {
        ITheLoaiRepository _itheLoaiRepository;
        public TheLoaiService()
        {
            _itheLoaiRepository = new TheLoaiRepository();
        }
        public string Add(TheLoai obj)
        {
            if (obj == null) return "Thêm không thành công";
            if (_itheLoaiRepository.AddTheLoai(obj)) return "Thêm thành công";
            return "Thêm không thành công";
        }

        public string Delete(TheLoai obj)
        {
            if (obj == null) return "Xóa không thành công";
            if (_itheLoaiRepository.DeleteTheLoai(obj)) return "Xóa thành công";
            return "Xóa không thành công";
        }

        public List<TheLoaiView> GetAll()
        {
            List<TheLoaiView> lsttlv = new List<TheLoaiView>();
            lsttlv =
                (from a in _itheLoaiRepository.GetAllTheLoai()
                 select new TheLoaiView()
                 {
                     Id = a.Id,
                     Ma = a.Ma,
                     Ten = a.Ten,
                     TrangThai = a.TrangThai
                 }).ToList();
            return lsttlv;
        }

        public string Update(TheLoai obj)
        {
            if (obj == null) return "Cập nhật không thành công";
            if (_itheLoaiRepository.UpdateTheLoai(obj)) return "Cập nhật thành công";
            return "Cập nhật không thành công";
        }
    }
}
