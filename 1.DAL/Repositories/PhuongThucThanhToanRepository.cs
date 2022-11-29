using _1.DAL.Context;
using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositories
{
    public class PhuongThucThanhToanRepository : IPhuongThucThanhToanRepositrory
    {
        private FpolyDBContext context = new FpolyDBContext();
        public PhuongThucThanhToanRepository()
        {

        }
        public bool Add(PhuongThucThanhToan obj)
        {
            if (obj == null) return false;
            context.PhuongThucThanhToans.Add(obj);
            context.SaveChanges();
            return true;
        }

        public List<PhuongThucThanhToan> GetAll()
        {
            return context.PhuongThucThanhToans.ToList();
        }

        public bool Remove(PhuongThucThanhToan obj)
        {
            if (obj == null) return false;
            var tempobj = context.PhuongThucThanhToans.FirstOrDefault(x => x.Id == obj.Id);
            context.PhuongThucThanhToans.Remove(tempobj);
            context.SaveChanges();
            return true;
        }

        public bool Update(PhuongThucThanhToan obj)
        {
            if (obj == null) return false;
            var tempobj = context.PhuongThucThanhToans.FirstOrDefault(x => x.Id == obj.Id);
            tempobj = obj;
            context.PhuongThucThanhToans.Update(tempobj);
            context.SaveChanges();
            return true;
        }
    }
}
