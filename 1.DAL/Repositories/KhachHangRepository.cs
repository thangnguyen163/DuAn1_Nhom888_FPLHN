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
    public class KhachHangRepository : IKhachHangRepository
    {
        private FpolyDBContext _DBContext;
        private List<KhachHang> _lstkhachhang;
        public KhachHangRepository()
        {
            _DBContext = new FpolyDBContext();
            _lstkhachhang = new List<KhachHang>();
        }
        public bool addKhachHang(KhachHang khachHang)
        {
            _DBContext.KhachHangs.Add(khachHang);
            _DBContext.SaveChanges();
            return true;    
        }

        public bool deleteKhachHang(KhachHang khachHang)
        {
            _DBContext.KhachHangs.Remove(khachHang);
            _DBContext.SaveChanges();
            return true;
        }

        public List<KhachHang> getall()
        {
            _lstkhachhang = _DBContext.KhachHangs.ToList();
            return _lstkhachhang;
        }

        public bool updateKhachHang(KhachHang khachHang)
        {
            _DBContext.KhachHangs.Update(khachHang);
            _DBContext.SaveChanges();
            return true;
        }
    }
}
