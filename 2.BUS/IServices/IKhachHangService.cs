using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IKhachHangService
    {
        bool addKhachHang (KhachHang khachHang);
        bool updateKhachHang(KhachHang khachHang);
        bool deleteKhachHang (KhachHang khachHang); 
        List<KhachHang> getKhachHangFromDB();
    }
}
