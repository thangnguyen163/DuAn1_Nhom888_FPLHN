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
    public class ChiTietTheLoaiRepository : IChiTietTheLoaiRepository
    {
        private FpolyDBContext _context;
        public ChiTietTheLoaiRepository()
        {
            _context = new FpolyDBContext();
        }
        public bool AddCTTheLoai(ChiTietTheLoai obj)
        {
            if (obj == null) return false;
            _context.ChiTietTheLoais.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteCTTheLoai(ChiTietTheLoai obj)
        {
            if (obj == null) return false;
            var tempobj = _context.ChiTietTheLoais.FirstOrDefault(c => c.Id == obj.Id);
            tempobj.TrangThai = 0;
            _context.Update(tempobj);
            _context.SaveChanges();
            return true;
        }

        public List<ChiTietTheLoai> GetAllCTTheLoai()
        {
            return _context.ChiTietTheLoais.ToList();
        }

        public bool UpdateCTTheLoai(ChiTietTheLoai obj)
        {
            //public Guid Id { get; set; }
            //public Guid? IdTheLoai { get; set; }
            //public Guid? IdChiTietSach { get; set; }
            //public string Ma { get; set; }
            //public string Ten { get; set; }
            //public int? TrangThai { get; set; }
            if (obj == null) return false;
            var tempobj = _context.ChiTietTheLoais.FirstOrDefault(c => c.Id == obj.Id);
            tempobj.IdTheLoai = obj.IdTheLoai;
            tempobj.IdChiTietSach = obj.IdChiTietSach;
            tempobj.Ma = obj.Ma;
            tempobj.Ten = obj.Ten;
            tempobj.TrangThai = obj.TrangThai;
            _context.Update(tempobj);
            _context.SaveChanges();
            return true;
        }
    }
}
