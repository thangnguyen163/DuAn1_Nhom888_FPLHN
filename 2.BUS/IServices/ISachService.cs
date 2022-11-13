using _1.DAL.DomainClass;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IService
{
    public interface ISachService
    {
        string Add(Sach obj);
        string Update(Sach obj);
        string Delete(Sach obj);
        List<SachView> GetAll();
    }
}
