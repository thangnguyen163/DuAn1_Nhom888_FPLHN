using _1.DAL.DomainClass;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IKhachHangService
    {
        string addKhachHang (KhachHang khachHang, DiemTieuDung diemTieuDung);
        string updateKhachHang( KhachHang khachHang);
        string deleteKhachHang (KhachHang khachHang); 
       
        List<KhachhangView> getKhachHangFromDB();
        List<KhachHang> getAll();
    }
}
