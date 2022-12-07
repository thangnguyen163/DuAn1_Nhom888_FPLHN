using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Serivces
{
    public class GiaoCaService : IGiaoCaService
    {
        IGiaoCaRepository _iGiaoCaRepository;
        public GiaoCaService()
        {
            _iGiaoCaRepository = new GiaoCaRepository();
        }
        public string Add(GiaoCa obj)
        {
            if (obj == null) return "Nhận ca thất bại";
            if (_iGiaoCaRepository.Add(obj)) return "Nhận ca thành công";
            return "Nhận ca thất bại";
        }

        public List<GiaoCa> GetAll()
        {
            return _iGiaoCaRepository.GetAll();
        }

        public string Update(GiaoCa obj)
        {
            if (obj == null) return "Kết thúc ca thất bại";
            if (_iGiaoCaRepository.Update(obj)) return "Kết thúc ca thành công";
            return "Kết thúc ca thất bại";
        }

        public string UpdateRutTien(GiaoCa obj)
        {
            if (obj == null) return "Cập nhật thất bại";
            if (_iGiaoCaRepository.UpdateRutTien(obj)) return "Cập nhật thành công";
            return "Cập nhật thất bại";
        }

        public string UpdateTienPhatSinh(GiaoCa obj)
        {
            if (obj == null) return "Cập nhật thất bại";
            if (_iGiaoCaRepository.UpdateTienPhatSinh(obj)) return "Cập nhật thành công";
            return "Cập nhật thất bại";
        }
    }
}
