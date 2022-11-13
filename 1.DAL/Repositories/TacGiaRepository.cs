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
    public class TacGiaRepository : ITacGiaRepository
    {
        private FpolyDBContext context;
        public TacGiaRepository()
        {
            context = new FpolyDBContext();
        }

        public bool AddTacGia(TacGium Tg)
        {
            if (Tg == null) return false;
            context.TacGia.Add(Tg); ;
            context.SaveChanges(); ;
            return true;
        }

        public bool DeleteTacGia(Guid id)
        {
            if (id == null) return false;
            var a = context.TacGia.FirstOrDefault(p => p.Id == id);
            a.TrangThai = 0;
            context.SaveChanges();
            return true;

        }

        public List<TacGium> GetTacGia()
        {
            return context.TacGia.ToList();
        }

        public bool UpdateTacGia(Guid id, TacGium Tg)
        {
            if (id == null) return false;
            var a = context.TacGia.FirstOrDefault(p => p.Id == id);
            a.Ma = Tg.Ma;
            a.Ten = Tg.Ten;
            a.TrangThai = Tg.TrangThai;
            context.TacGia.Update(a);
            context.SaveChanges();
            return true;
        }
    }
}
