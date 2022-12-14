using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using _1.DAL.IRepositoties;
using _1.DAL.Repositories;
using _1.DAL.Repositoties;
using _2.BUS.IServices;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Serivces
{
    public class NhanVienService : INhanVienService
    {
        private INhanVienRepository nhanVienRepository;
        private IChucVuRepository _chucVuRepository;
        private List<NhanVien> _lstNhanVien;
        private List<NhanVienView> _lstViewNhanVien;
        public NhanVienService()
        {
            nhanVienRepository = new NhanVienRepository();
            _chucVuRepository = new ChucVuRepository();
            _lstNhanVien = new List<NhanVien>();
        }
        public string addNhanVien(NhanVien nhanVien)
        {
            if (nhanVien == null) return "Thêm không thành công";
            else
            {
                nhanVienRepository.addNhanVien(nhanVien);
                return "Thêm thành công";
            }
        }

        public string deleteNhanVien(Guid? Id)
        {
                nhanVienRepository.deleteNhanVien(Id);
                return "Xóa thành công";
        }

        public string QuenMatKhau(NhanVien nhanVien)
        {
            if (nhanVien == null) return "Đổi mật khẩu không thành công";
            if (nhanVienRepository.QuenMatKhau(nhanVien)) return "Đổi mật khẩu thành công";
            return "Đổi mật khẩu không thành công";
        }

        public List<NhanVien> getNhanViensFromDB()
        {
            return nhanVienRepository.GetAllNhanVien();
        }

        public List<NhanVienView> getViewNhanViens()
        {
            _lstViewNhanVien = (from nv in getNhanViensFromDB()
                                join cv in _chucVuRepository.getChucVusFromDB() on nv.IdchucVu equals cv.Id
                                select new NhanVienView
                                {
                                    nhanVien = nv,
                                    chucVu = cv,

                                }).ToList();
            return _lstViewNhanVien;
        }

        public string updateNhanVien(Guid? Id, NhanVien nhanVien)
        {
            if (nhanVien == null) return "Sửa không thành công";
            else
            {
                nhanVienRepository.updateNhanVien(Id, nhanVien);
                return "Sửa thành công";
            }
            //fgfgf
        }

        public string save(NhanVien nhanVien)
        {
            nhanVienRepository.save(nhanVien);
            return "Đổi mật khẩu thành công";
        }
    }
}
