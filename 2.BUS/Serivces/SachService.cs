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
    public class SachService : ISachService
    {
        ISachRepository _isachRepository;
        public SachService()
        {
            _isachRepository = new SachRepository();
        }

        public string Add(Sach obj)
        {
            if (obj == null) return "Thêm không thành công";
            if (_isachRepository.AddSach(obj)) return "Thêm thành công";
            return "Thêm không thành công";
        }
        public string Update(Sach obj)
        {
            if (obj == null) return "Cập nhật không thành công";
            if (_isachRepository.UpdateSach(obj)) return "Cập nhật thành công";
            return "Cập nhật không thành công";
        }
        public string Delete(Sach obj)
        {
            if (obj == null) return "Xóa không thành công";
            if (_isachRepository.DeleteSach(obj)) return "Xóa thành công";
            return "Xóa không thành công";
        }

        public List<SachView> GetAll()
        {
            List<SachView> lstsv = new List<SachView>();
            // Viết 1 câu LinQ để gán giá trị cho từng prop của SPView
            lstsv =
                (from a in _isachRepository.GetAllSach()
                 select new SachView()
                 {
                     Id = a.Id,
                     Ma = a.Ma,
                     Ten = a.Ten,
                     TrangThai = a.TrangThai
                 }).ToList();
            return lstsv;
        }


    }
}
