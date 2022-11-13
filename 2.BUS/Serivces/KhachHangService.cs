using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Serivces
{
    public class KhachHangService : IKhachHangService
    {
        private IKhachHangRepository _IKhachHangRepository;
        private List<KhachHang> _lstKhachHang;
        public KhachHangService()
        {
            _IKhachHangRepository = new KhachHangRepository();
            _lstKhachHang = new List<KhachHang>();
        }
        public bool addKhachHang(KhachHang khachHang)
        {
            _IKhachHangRepository.addKhachHang(khachHang);
            return true;
        }

        public bool deleteKhachHang(KhachHang khachHang)
        {
            _IKhachHangRepository.deleteKhachHang(khachHang);
            return true;
        }

        public List<KhachHang> getKhachHangFromDB()
        {
            _lstKhachHang = _IKhachHangRepository.getall();
            return _lstKhachHang;
        }

        public bool updateKhachHang(KhachHang khachHang)
        {
            _IKhachHangRepository.updateKhachHang(khachHang);
            return true;
        }
    }
}
