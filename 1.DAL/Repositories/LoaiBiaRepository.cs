using _1.DAL.Context;
using _1.DAL.DomainClass;
using _1.DAL.IRepositoties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositoties
{
    public class LoaiBiaRepository : ILoaiBiaRepository
    {
        private FpolyDBContext context;
        public LoaiBiaRepository()
        {
            context = new FpolyDBContext();
        }
        public bool AddLoaiBia(LoaiBium loaiBium)
        {
            if(loaiBium == null)  return false;
            context.LoaiBia.Add(loaiBium);
            context.SaveChanges();
            return true;

            
        }

        public bool DeleteLoaiBia(Guid id)
        {
            if (id == null) return false;
            var a = context.LoaiBia.FirstOrDefault(p => p.Id == id);
            a.TrangThai = 0;
            context.SaveChanges();
            return true;
        }

        public List<LoaiBium> GetLoaiBia()
        {
            return context.LoaiBia.ToList();

        }

        public bool UpadteLoaiBia(Guid id, LoaiBium loaiBium)
        {
            if (id == null) return false;
            var a = context.LoaiBia.FirstOrDefault(p => p.Id == id);
            a.Ma = loaiBium.Ma;
            a.Ten = loaiBium.Ten;
            a.TrangThai = loaiBium.TrangThai;
            context.LoaiBia.Update(a);
            context.SaveChanges();
            return true;

        }
    }
}
