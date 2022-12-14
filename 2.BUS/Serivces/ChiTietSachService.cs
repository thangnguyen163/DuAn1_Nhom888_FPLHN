using _1.DAL.DomainClass;
using _1.DAL.IRepositoties;
using _1.DAL.Repositoties;
using _2.BUS.IService;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Service
{
    public class ChiTietSachService : IChiTietSachService
    {
        private IChiTietSachRepository _iChiTietSachRepository;
        private List<ChiTietSach> _lstChiTietSach;
        private List<ChiTietSachView> _lstChiTietSachView;
        private ISachRepository _iSachRepository;
        private INXBRepository _iNXBRepository;
        private ITacGiaRepository _iTacGiaRepository;
        private ILoaiBiaRepository _iLoaiBiaRepository;
        private ITheLoaiRepository _iTheLoaiRepository;
        private INhaPhatHanhRepository _iNhaPhatHanhRepository;
        public ChiTietSachService()
        {
            _iChiTietSachRepository = new ChiTietSachRepository();
            _lstChiTietSach = new List<ChiTietSach>();
            _lstChiTietSachView = new List<ChiTietSachView>();
            _iSachRepository = new SachRepository();
            _iNXBRepository = new NXBRepository();
            _iTacGiaRepository = new TacGiaRepository();
            _iLoaiBiaRepository = new LoaiBiaRepository();
            _iNhaPhatHanhRepository = new NhaPhatHanhRepository();
            _iTheLoaiRepository = new TheLoaiRepository();
        }
        public string Add(ChiTietSach chiTietSach)
        {
            if (chiTietSach == null) return "Thêm chi tiết sách thất bại";
            _iChiTietSachRepository.Add(chiTietSach);
            return "Thêm chi tiết sách thành công";
        }

        public string Delete(Guid? id)
        {
            if (id == null) return "Chưa chọn sản phẩm muốn sửa";
            _iChiTietSachRepository.Delete(id);
            return "Chi tiết sách được xoá thành công";
        }

        public List<ChiTietSach> GetAll()
        {
            return _lstChiTietSach = _iChiTietSachRepository.GetAll();
        }

        public List<ChiTietSachView> GetAllChiTietSachView()
        {
            return _lstChiTietSachView =
                (from a in _iChiTietSachRepository.GetAll()
                 join b in _iSachRepository.GetAllSach() on a.IdSach equals b.Id
                 join c in _iLoaiBiaRepository.GetLoaiBia() on a.IdLoaiBia equals c.Id
                 join d in _iNXBRepository.GetAllNSX() on a.IdNxb equals d.Id
                 join e in _iTacGiaRepository.GetTacGia() on a.IdTacGia equals e.Id
                 join f in _iNhaPhatHanhRepository.GetNhaPhatHanhs() on a.IdNhaPhatHanh equals f.Id
                 join h in _iTheLoaiRepository.GetAllTheLoai() on a.IdTheLoai equals h.Id

                 select new ChiTietSachView()
                 {
                     Id = a.Id,
                     TenSach = b.Ten,
                     TenNxb = d.Ten,
                     TenTacGia = e.Ten,
                     TenNhaPhatHanh = f.Ten,
                     TenLoaiBia = c.Ten,
                     TenTheLoai=h.Ten,
                     TenTheLoai2= h.IdCha,
                     Ma = a.Ma,
                     Anh=a.Anh,
                     MaVach=a.MaVach,
                     KichThuoc = a.KichThuoc,
                     NamXuatBan = a.NamXuatBan,
                     MoTa=a.MoTa,
                     SoLuong = a.SoLuong,
                     GiaBan = a.GiaBan,
                     GiaNhap = a.GiaNhap,
                     SoTrang = a.SoTrang,
                     TrangThai = a.TrangThai,
                 }).ToList();

        }

        public List<ChiTietSachView> GetAllChiTietSachViewByName(string name)
        {
            return _lstChiTietSachView = GetAllChiTietSachView().Where(x => x.TenSach.Contains(name)).ToList();

        }

        public string Update(Guid? id, ChiTietSach chiTietSach)
        {
            if (id == null) return "Chưa chọn sản phẩm muốn sửa";
            _iChiTietSachRepository.Update(id, chiTietSach);
            return "Chi tiết sách được sửa thành công";
        }

        public string UpdateTrangThai(Guid? id, ChiTietSach chiTietSach)
        {
            if (id == null) return "Chưa chọn sản phẩm muốn sửa";
            _iChiTietSachRepository.UpdateTrangThai(id, chiTietSach);
            return "Sách được chuyển thành Ngừng kinh doanh";
        }
    }
}