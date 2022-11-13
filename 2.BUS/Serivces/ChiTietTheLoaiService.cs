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
        public ChiTietTheLoaiService()
        {
            _ichiTietTheLoaiRepository = new ChiTietTheLoaiRepository();
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
            throw new NotImplementedException();
        }

        public string Update(ChiTietTheLoai obj)
        {
            if (obj == null) return "Cập nhật không thành công";
            if (_ichiTietTheLoaiRepository.UpdateCTTheLoai(obj)) return "Cập nhật thành công";
            return "Cập nhật không thành công";
        }
    }
}
