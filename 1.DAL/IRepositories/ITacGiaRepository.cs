using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositoties
{
    public interface ITacGiaRepository
    {
        bool AddTacGia(TacGium Tg);
        bool UpdateTacGia(Guid id,TacGium Tg);
        bool DeleteTacGia(Guid id);
        List<TacGium> GetTacGia();
    }
}
