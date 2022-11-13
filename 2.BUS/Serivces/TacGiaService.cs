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
    public class TacGiaService : ITacGiaService
    {
        private ITacGiaRepository tacGiaRepository;
        public TacGiaService()
        {
            tacGiaRepository=new TacGiaRepository();
        }
        public string Add(TacGium Tg)
        {
            if (Tg == null) return "Thêm không thành công";
            else
            {
                tacGiaRepository.AddTacGia(Tg);
                return "Thêm thành công";
            }
        }

        public string Delete(Guid id)
        {
            if (id == null) return "Xóa không thành công";
            else
            {
                tacGiaRepository.DeleteTacGia(id);
                return "Xóa thành công";
            }
        }

        public List<TacGium> GetAll()
        {
            return tacGiaRepository.GetTacGia();
        }

        public string Update(Guid id, TacGium Tg)
        {
            if (id == null) return "Sửa không thành công";
            else
            {
                tacGiaRepository.UpdateTacGia(id,Tg);
                return "Sửa thành công";
            }
        }
    }
}
