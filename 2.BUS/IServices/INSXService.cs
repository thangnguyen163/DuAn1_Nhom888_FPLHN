using _1.DAL.DomainClass;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IService
{
    public interface INSXService
    {
        string Add(Nxb obj);
        string Update(Nxb obj);
        string Delete(Nxb obj);
        List<NSXView> GetAll();
    }
}
