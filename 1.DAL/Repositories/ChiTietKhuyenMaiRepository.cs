using _1.DAL.Context;
using _1.DAL.DomainClass;
using _1.DAL.IRepositoties;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositoties
{
    public class ChiTietKhuyenMaiRepository : IChiTietKhuyenMaiRepository
    {
        private FpolyDBContext context;
        public ChiTietKhuyenMaiRepository()
        {
            context = new FpolyDBContext();
        }
        public bool AddCTKhuyenMai(ChiTietKhuyenMai chiTietKhuyenMai)
        {
            if (chiTietKhuyenMai == null) return false;
            context.ChiTietKhuyenMais.Add(chiTietKhuyenMai);
            context.SaveChanges();
            return true;

        }

        public bool DeleteCTKhuyenMai(Guid id)
        {
            if (id == null) return false;
            var a = context.ChiTietKhuyenMais.FirstOrDefault(p => p.Id == id);
            a.TrangThai = 0;
            context.SaveChanges();
            return true;
        }

        public List<ChiTietKhuyenMai> GetAllCTKhuyenMai()
        {
            return context.ChiTietKhuyenMais.ToList();
        }

        public bool UpdateCTKhuyenMai(Guid id, ChiTietKhuyenMai chiTietKhuyenMai)
        {
            if (id == null) return false;
            var a = context.ChiTietKhuyenMais.FirstOrDefault(p => p.Id == id);
            a.IdChiTietSach=chiTietKhuyenMai.IdChiTietSach;
            a.IdKhuyenMai = chiTietKhuyenMai.IdKhuyenMai;
            a.Ma = chiTietKhuyenMai.Ma;
            a.Ten = chiTietKhuyenMai.Ten;
            a.MoTa = chiTietKhuyenMai.MoTa;
            a.TrangThai = chiTietKhuyenMai.TrangThai;
            context.ChiTietKhuyenMais.Update(a);
            context.SaveChanges();
            return true;
        }
    }
}
