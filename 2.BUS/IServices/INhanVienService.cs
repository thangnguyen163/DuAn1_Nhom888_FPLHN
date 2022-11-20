using _1.DAL.DomainClass;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface INhanVienService
    {
        public string addNhanVien(NhanVien nhanVien);
        public string updateNhanVien(Guid Id, NhanVien nhanVien);
        public string deleteNhanVien(Guid Id);
        List<NhanVien> getNhanViensFromDB();
        List<NhanVienView> getViewNhanViens();
        public string QuenMatKhau(NhanVien nhanVien);
    }
}
