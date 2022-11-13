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
    public class TheLoaiRepository : ITheLoaiRepository
    {
        FpolyDBContext _context;
        public TheLoaiRepository()
        {
            _context = new FpolyDBContext();
        }
        public bool AddTheLoai(TheLoai obj)
        {
            if (obj == null) return false;
            _context.TheLoais.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteTheLoai(TheLoai obj)
        {
            if (null == obj) return false;
            var temp = _context.TheLoais.FirstOrDefault(c => c.Id == obj.Id);
            temp.TrangThai = 0;
            _context.Update(temp);
            _context.SaveChanges();
            return true;
        }

        public List<TheLoai> GetAllTheLoai()
        {
            return _context.TheLoais.ToList();
        }

        public bool UpdateTheLoai(TheLoai obj)
        {
            //public Guid Id { get; set; }
            //public string Ma { get; set; }
            //public string Ten { get; set; }
            //public int? TrangThai { get; set; }
            if (null == obj) return false;
            var temp = _context.TheLoais.FirstOrDefault(c => c.Id == obj.Id);
            temp.Ma = obj.Ma;
            temp.Ten = obj.Ten;
            temp.TrangThai = obj.TrangThai;
            _context.Update(temp);
            _context.SaveChanges();
            return true;
        }
    }
}
