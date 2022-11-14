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
        bool updateKhachHang(Guid id, KhachHang khachHang);
        bool deleteKhachHang (Guid id); 
       
        List<KhachHang> getKhachHangFromDB();
    }
}
