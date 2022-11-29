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
    public class PhuongThucThanhToanService : IPhuongThucThanhToanService
    {
        private IPhuongThucThanhToanRepositrory _iphuongThucThanhToanRepository = new PhuongThucThanhToanRepository(); 
        public string Add(PhuongThucThanhToan obj)
        {
            if (obj == null) return "Thêm thất bại";
            if (_iphuongThucThanhToanRepository.Add(obj)) return "Thêm thành công";
            return "Thêm thất bại";
        }

        public string Delete(PhuongThucThanhToan obj)
        {
            if (obj == null) return "Xóa thất bại";
            if (_iphuongThucThanhToanRepository.Remove(obj)) return "Xóa thành công";
            return "Xóa thất bại";
        }

        public List<PhuongThucThanhToan> GetAllNoView()
        {
            return _iphuongThucThanhToanRepository.GetAll();
        }

        public string Update(PhuongThucThanhToan obj)
        {
            if (obj == null) return "Sửa thất bại";
            if (_iphuongThucThanhToanRepository.Update(obj)) return "Sửa thành công";
            return "Sửa thất bại";
        }
    }
}
