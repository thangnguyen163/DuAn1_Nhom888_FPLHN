using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using _2.BUS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Serivces
{
    public class KhachHangService : IKhachHangService
    {
        private IKhachHangRepository khachHangRepository;
        public KhachHangService()
        {
            khachHangRepository = new KhachHangRepository();
        }

        public bool addKhachHang(KhachHang khachHang)
        {
            throw new NotImplementedException();
        }

        public bool deleteKhachHang(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<KhachHang> getKhachHangFromDB()
        {
            throw new NotImplementedException();
        }

        public bool updateKhachHang(Guid id, KhachHang khachHang)
        {
            throw new NotImplementedException();
        }
    }
}
