using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IPhuongThucThanhToanRepositrory
    {
        public bool Add(PhuongThucThanhToan obj);
        public bool Update(PhuongThucThanhToan obj);
        public bool Remove(PhuongThucThanhToan obj);
        public List<PhuongThucThanhToan> GetAll();
    }
}
