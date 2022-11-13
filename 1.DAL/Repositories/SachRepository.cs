using _1.DAL.Context;
using _1.DAL.DomainClass;
using _1.DAL.IRepositoties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositoties
{
    public class SachRepository : ISachRepository
    {
        FpolyDBContext _context;
        public SachRepository()
        {
            _context = new FpolyDBContext();
        }
        public bool AddSach(Sach obj)
        {
            if (obj == null) return false;
            _context.Saches.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteSach(Sach obj)
        {
            if (obj == null) return false;
            var temp = _context.Saches.FirstOrDefault(c => c.Id == obj.Id);
            temp.TrangThai = 0;
            _context.Update(temp);
            _context.SaveChanges();
            return true;
        }

        public List<Sach> GetAllSach()
        {
            return _context.Saches.ToList();
        }

        public bool UpdateSach(Sach obj)
        {
            //public Guid Id { get; set; }
            //public string Ma { get; set; }
            //public string Ten { get; set; }
            //public int? TrangThai { get; set; }
            if (obj == null) return false;
            var temp = _context.Saches.FirstOrDefault(c => c.Id == obj.Id);
            temp.Ma = obj.Ma;
            temp.Ten = obj.Ten;
            temp.TrangThai = obj.TrangThai;
            _context.Update(temp);
            _context.SaveChanges();
            return true;
        }
    }
}
