using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IService
{
    public interface ITacGiaService 
    {
        public string Add(TacGium Tg);
        public string Update(Guid id, TacGium Tg);
        public string Delete(Guid id);
        List<TacGium> GetAll();
    }
}
