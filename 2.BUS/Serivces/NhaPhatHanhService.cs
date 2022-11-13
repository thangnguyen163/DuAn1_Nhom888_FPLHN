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
    public class NhaPhatHanhService : INhaPhatHanhService
    {
        private INhaPhatHanhRepository nhaPhatHanhRepository;
        public NhaPhatHanhService()
        {
            nhaPhatHanhRepository = new NhaPhatHanhRepository();
        }
        public string Add(NhaPhatHanh nhaPhatHanh)
        {
            if (nhaPhatHanh == null) return "Thêm không thành công";
            else
            {
                nhaPhatHanhRepository.AddNhaPhatHanh(nhaPhatHanh);
                return "Thêm thành công";
            }
        }

        public string Delete(Guid id)
        {
            if (id== null) return "Xóa không thành công";
            else
            {
                nhaPhatHanhRepository.DeleteNhaPhatHanh(id);
                return "Xóa thành công";
            }
        }

        public List<NhaPhatHanh> GetAll()
        {
            return nhaPhatHanhRepository.GetNhaPhatHanhs();
        }

        public string Update(Guid id, NhaPhatHanh nhaPhatHanh)
        {
            if (nhaPhatHanh == null) return "Sửa không thành công";
            else
            {
                nhaPhatHanhRepository.UpdateNhaPhatHanh(id,nhaPhatHanh);
                return "Sửa thành công";
            }
        }
    }
}
