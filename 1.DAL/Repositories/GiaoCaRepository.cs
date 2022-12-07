using _1.DAL.Context;
using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositories
{
    public class GiaoCaRepository : IGiaoCaRepository
    {
        public FpolyDBContext _DbContext = new FpolyDBContext();
        public bool Add(GiaoCa obj)
        {
            if (obj == null) return false;
            _DbContext.GiaoCas.Add(obj);
            _DbContext.SaveChanges();
            return true;
        }

        public List<GiaoCa> GetAll()
        {
            return _DbContext.GiaoCas.AsNoTracking().ToList();
        }

        public bool Update(GiaoCa obj)
        {
            if (obj == null) return false;
            var temp = _DbContext.GiaoCas.FirstOrDefault(c => c.Id == obj.Id);
            temp.ThoiGianGiaoCa = obj.ThoiGianGiaoCa;
            temp.IdNhanVienCaTiep = obj.IdNhanVienCaTiep;
            temp.TongTienTrongCa = obj.TongTienTrongCa;
            temp.TongTienMat = obj.TongTienMat;
            temp.TongTienKhac = obj.TongTienKhac;
            temp.TongTienMatCaTruoc = obj.TongTienMatCaTruoc;
            temp.ThoiGianReset = obj.ThoiGianReset;
            _DbContext.GiaoCas.Update(temp);
            _DbContext.SaveChanges();
            return true;
        }

        public bool UpdateRutTien(GiaoCa obj)
        {
            if (obj == null) return false;
            var temp = _DbContext.GiaoCas.FirstOrDefault(c => c.Id == obj.Id);
            temp.TongTienMatRut += obj.TongTienMatRut;
            temp.TongTienTrongCa -= obj.TongTienMatRut;
            _DbContext.GiaoCas.Update(temp);
            _DbContext.SaveChanges();
            return true;
        }

        public bool UpdateTienPhatSinh(GiaoCa obj)
        {
            if (obj == null) return false;
            var temp = _DbContext.GiaoCas.FirstOrDefault(c => c.Id == obj.Id);
            temp.TongTienTrongCa -= obj.TienPhatSinh;
            temp.GhiChuPhatSinh += obj.GhiChuPhatSinh;
            _DbContext.GiaoCas.Update(temp);
            _DbContext.SaveChanges();
            return true;
        }
    }
}
