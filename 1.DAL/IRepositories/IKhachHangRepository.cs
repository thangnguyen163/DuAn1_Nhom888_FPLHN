using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IKhachHangRepository
    {
        bool addKhachHang(KhachHang khachHang);
        bool updateKhachHang(KhachHang khachHang);
        bool deleteKhachHang(KhachHang khachHang);  
        List<KhachHang> getall();
    }
}
