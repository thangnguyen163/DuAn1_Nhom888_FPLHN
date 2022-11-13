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
    public class KhuyenMaiService : IKhuyenMaiService
    {
        private IKhuyenMaiRepository _khuyenMai;
        public KhuyenMaiService()
        {
            _khuyenMai = new KhuyenMaiRepository();
        }
       
        public string Add(KhuyenMai km)
        {
            if (km == null) return "Thêm không thành công";
            else
            {
                _khuyenMai.AddKhuyenMai(km);
                return "Thêm thành công";
            }
        }

        public string Delete(Guid id)
        {
            if (id == null) return "Xóa không thành công";
            else
            {
                _khuyenMai.DeleteKhuyenMai(id);
                return "Xóa thành công";
            }
        }

        public List<KhuyenMai> GetAll()
        {
            return _khuyenMai.GetKhuyenMais();
        }

        public string Update(Guid id, KhuyenMai km)
        {
            if (id == null) return "Sửa không thành công";
            else
            {
                _khuyenMai.UpdateKhuyenMai(id, km);
                return "Sửa thành công ";
            }
        }
    }
}
