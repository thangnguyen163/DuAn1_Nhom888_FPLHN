using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface INhanVienRepository
    {
        bool addNhanVien(NhanVien nhanVien);
        bool updateNhanVien(Guid? Id, NhanVien nhanVien);
        bool deleteNhanVien(Guid? Id);
        List<NhanVien> GetAllNhanVien();
        bool QuenMatKhau(NhanVien nhanVien);
    }
}
