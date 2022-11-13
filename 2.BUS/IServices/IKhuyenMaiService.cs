using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IService
{
    public interface IKhuyenMaiService
    {
        public string Add(KhuyenMai km);
        public string Update(Guid id,KhuyenMai km);
        public string Delete(Guid id);
        List<KhuyenMai> GetAll();
    }
}
