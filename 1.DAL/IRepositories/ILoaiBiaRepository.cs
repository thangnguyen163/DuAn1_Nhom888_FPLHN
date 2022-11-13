using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositoties
{
    public interface ILoaiBiaRepository
    {
        bool AddLoaiBia(LoaiBium loaiBium);
        bool UpadteLoaiBia(Guid id, LoaiBium loaiBium);
        bool DeleteLoaiBia(Guid id);
        List<LoaiBium> GetLoaiBia();
            

    }
}
