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
        private INSXRepository _iNSXRepository;
        //private ITacGiaRepository _iTacGiaRepository;
        //private ILoaiBiaRepository _iLoaiBiaRepository;
        private IChiTietTheLoaiRepository _iChiTietTheLoaiRepository;
        private ITheLoaiRepository _iTheLoaiRepository;
        //private INhaPhatHanhRepository _iNhaPhatHanhRepository;
        public ChiTietSachService()
        {
            _iChiTietSachRepository =new ChiTietSachRepository();
            _lstChiTietSach = new List<ChiTietSach>();
            _lstChiTietSachView=new List<ChiTietSachView>();
            _iSachRepository =new SachRepository();
            _iNSXRepository = new NSXRepository();
            //_iTacGiaRepository = new TacGiaRepository();
            //_iLoaiBiaRepository = new LoaiBiaRepository();
            //_iNhaPhatHanhRepository = new NhaPhatHanhRepository();
            _iTheLoaiRepository = new TheLoaiRepository();
            
        }
        public string Add(ChiTietSach chiTietSach)
        {
            if (chiTietSach == null) return "Thêm chi tiết sách thất bại";
            _iChiTietSachRepository.Add(chiTietSach);
            return "Thêm chi tiết sách thành công";
        }

        public string Delete(Guid? id, ChiTietSach chiTietSach)
        {
            _iChiTietSachRepository.Delete(id, chiTietSach);
            return "Chi tiết sách đã được chuyển thành không sử dụng";
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
                 //join c in _iChiTietTheLoaiRepository.GetAllCTTheLoai() on a.id
                 select new ChiTietSachView()
                 {

                 }).ToList();
                  
        }

        public string Update(Guid? id, ChiTietSach chiTietSach)
        {
            _iChiTietSachRepository.Update(id, chiTietSach);
            return "Chi tiết sách được sửa thành công";
        }
    }
}
