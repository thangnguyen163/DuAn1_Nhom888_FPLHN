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
    public class LoaiBiaService : ILoaiBiaService
    {
        private ILoaiBiaRepository _loaiBiaRepository;
        public LoaiBiaService()
        {
            _loaiBiaRepository = new LoaiBiaRepository();
        }
        public string Add(LoaiBium lb)
        {
            if (lb == null) return "thêm không thành công";
            else
            {
                _loaiBiaRepository.AddLoaiBia(lb);
                return "Thêm thành công";
            }
        }

        public string Delete(Guid id)
        {
            if (id == null) return "Xóa không thành công";
            else
            {
                _loaiBiaRepository.DeleteLoaiBia(id);
                return "Xóa thành công";

            }
        }

        public List<LoaiBium> GetLoaiBia()
        {
            return _loaiBiaRepository.GetLoaiBia();
        }

        public string Update(Guid id, LoaiBium lb)
        {
            if (id == null) return "Sửa không thành công";
            else
            {
                _loaiBiaRepository.UpadteLoaiBia(id, lb);
                return "Sửa thành công";
            }
        }
    }
}
