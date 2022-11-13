using _1.DAL.DomainClass;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IService
{
    public interface IChiTietSachService
    {
        string Add(ChiTietSach chiTietSach);
        string Delete(Guid? id,ChiTietSach chiTietSach);
        string Update(Guid? id, ChiTietSach chiTietSach);
        List<ChiTietSach> GetAll();
        List<ChiTietSachView> GetAllChiTietSachView();
    }
}
