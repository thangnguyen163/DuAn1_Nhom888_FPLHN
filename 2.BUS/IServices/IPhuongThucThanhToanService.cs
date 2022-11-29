using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IPhuongThucThanhToanService
    {
        string Add(PhuongThucThanhToan obj);
        string Update(PhuongThucThanhToan obj);
        string Delete(PhuongThucThanhToan obj);       
        List<PhuongThucThanhToan> GetAllNoView();
    }
}
