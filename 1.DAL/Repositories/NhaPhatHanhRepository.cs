using _1.DAL.Context;
using _1.DAL.DomainClass;
using _1.DAL.IRepositoties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _1.DAL.Repositoties
{
    public class NhaPhatHanhRepository : INhaPhatHanhRepository
    {
        private FpolyDBContext context;
        public NhaPhatHanhRepository()
        {
            context = new FpolyDBContext();
        }
        public bool AddNhaPhatHanh(NhaPhatHanh nhaPhatHanh)
        {
            if(nhaPhatHanh == null) return false;
            context.NhaPhatHanhs.Add(nhaPhatHanh);
            context.SaveChanges();
            return true;

        }

        public bool DeleteNhaPhatHanh(Guid id)
        {
            if (id == null) return false;
            var a = context.NhaPhatHanhs.FirstOrDefault(p => p.Id == id);
            a.TrangThai = 0;
            context.SaveChanges();
            return true;
        }

        public List<NhaPhatHanh> GetNhaPhatHanhs()
        {
            return context.NhaPhatHanhs.ToList();

        }

        public bool UpdateNhaPhatHanh(Guid id, NhaPhatHanh nhaPhatHanh)
        {
            if (id == null) return false;
            var a = context.NhaPhatHanhs.FirstOrDefault(p => p.Id == id);
            a.Ma = nhaPhatHanh.Ma;
            a.Ten = nhaPhatHanh.Ten;
            a.TrangThai= nhaPhatHanh.TrangThai;
            context.NhaPhatHanhs.Update(a);
            context.SaveChanges();
            return true;
        }
    }
}
