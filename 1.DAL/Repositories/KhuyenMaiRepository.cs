using _1.DAL.Context;
using _1.DAL.DomainClass;
using _1.DAL.IRepositoties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositoties
{
    public class KhuyenMaiRepository : IKhuyenMaiRepository
    {
        private FpolyDBContext context;
        public KhuyenMaiRepository()
        {
            context= new FpolyDBContext();
        }
        public bool AddKhuyenMai(KhuyenMai km)
        {
            if (km == null) return false;
            context.KhuyenMais.Add(km);
            context.SaveChanges();
            return true;
        }

        public bool DeleteKhuyenMai(Guid id)
        {
            if (id == null) return false;
            var a = context.KhuyenMais.FirstOrDefault(p => p.Id == id);
            a.TrangThai = 0;
            context.SaveChanges();
            return true;
        }

        public List<KhuyenMai> GetKhuyenMais()
        {
            return context.KhuyenMais.ToList();
        }

        public bool UpdateKhuyenMai(Guid id, KhuyenMai km)
        {
            if (id == null) return false;
            var a = context.KhuyenMais.FirstOrDefault(p => p.Id == id);
            a.Ma = km.Ma;
            a.Ten = km.Ten;
            a.MoTa = km.MoTa;
            a.TrangThai = km.TrangThai;
            context.KhuyenMais.Update(a);
            context.SaveChanges();
            return true;
        }
    }
}
