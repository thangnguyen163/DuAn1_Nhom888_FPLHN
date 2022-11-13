using _1.DAL.DomainClass;
using _1.DAL.IRepositoties;
using _1.DAL.Repositoties;
using _2.BUS.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Service
{
    public class ChiTietKhuyenMaiService : IChiTietKhuyenMaiService
    {
        private IChiTietKhuyenMaiRepository _chiTietKhuyenMaiRepository;
        public ChiTietKhuyenMaiService()
        {
            _chiTietKhuyenMaiRepository = new ChiTietKhuyenMaiRepository();
        }
        public string Add(ChiTietKhuyenMai chiTietKhuyenMai)
        {
            if (chiTietKhuyenMai == null) return "Thêm không thành công";
            else
            {
                _chiTietKhuyenMaiRepository.AddCTKhuyenMai(chiTietKhuyenMai);
                return "Thêm thành công";

            }
        }

        public string Delete(Guid id)
        {
            if (id == null) return "Xóa không thành công ";
            else
            {
                _chiTietKhuyenMaiRepository.DeleteCTKhuyenMai(id);
                return "xóa thành công";
            }
        }

        public List<ChiTietKhuyenMai> GetAll()
        {
            return _chiTietKhuyenMaiRepository.GetAllCTKhuyenMai();
        }

        public string Update(Guid id, ChiTietKhuyenMai chiTietKhuyenMai)
        {
            if (id == null) return "sửa không thành công";
            else
            {
                _chiTietKhuyenMaiRepository.UpdateCTKhuyenMai(id, chiTietKhuyenMai);
                return "Sửa thành công ";
            }
        }
    }
}
