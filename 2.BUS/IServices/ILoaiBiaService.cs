using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IService
{
    public interface ILoaiBiaService
    {
        public string Add(LoaiBium lb);
        public string Update(Guid id,LoaiBium lb);
        public string Delete(Guid id);
        List<LoaiBium> GetLoaiBia();
    }
}
