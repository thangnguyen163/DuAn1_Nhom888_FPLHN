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
    public class ChiTietKhuyenMaiService : IChiTietKhuyenMaiService
    {
        private IChiTietKhuyenMaiRepository _chiTietKhuyenMaiRepository;
        private IChiTietSachRepository _chiTietSachRepository;
        private IKhuyenMaiRepository _khuyenMaiRepository;
        private ISachRepository _sachRepository;
        private List<ChiTietKhuyenMaiView> listCTKhuyenMai;

        public ChiTietKhuyenMaiService()
        {
            _chiTietKhuyenMaiRepository = new ChiTietKhuyenMaiRepository();
            _chiTietSachRepository = new ChiTietSachRepository();
            _khuyenMaiRepository = new KhuyenMaiRepository();
            _sachRepository = new SachRepository();
        }
        public string Add(ChiTietKhuyenMai chiTietKhuyenMai)
        {
            if (chiTietKhuyenMai == null) return "Thêm không thành công";
            else
            {
                _chiTietKhuyenMaiRepository.AddCTKhuyenMai(chiTietKhuyenMai);
                return "Thêm thành công";

            }
        }

        public string Delete(Guid id)
        {
            if (id == null) return "Xóa không thành công ";
            else
            {
                _chiTietKhuyenMaiRepository.DeleteCTKhuyenMai(id);
                return "xóa thành công";
            }
        }

        public List<ChiTietKhuyenMai> GetAll()
        {
            return _chiTietKhuyenMaiRepository.GetAllCTKhuyenMai();
        }

        public List<ChiTietKhuyenMaiView> GetChiTietKhuyenMaiViews()
        {
            return listCTKhuyenMai =
                (
                from a in _chiTietKhuyenMaiRepository.GetAllCTKhuyenMai()
                join b in _khuyenMaiRepository.GetKhuyenMais() on a.IdKhuyenMai equals b.Id
                join c in _chiTietSachRepository.GetAll() on a.IdChiTietSach equals c.Id
                join d in _sachRepository.GetAllSach() on c.IdSach equals d.Id
                select new ChiTietKhuyenMaiView()
                {

                    IdKhuyenMai = b.Id,
                    IdChiTietSach = c.Id,
                    Id = a.Id,
                    TenSach = d.Ten,
                    KhuyenMai = b.Ten,
                    MaCTKuyenMai = a.Ma,
                    TenKhuyenMai = a.Ten,
                    MoTa = a.MoTa,
                    TrangThai = a.TrangThai,
                }).ToList();

        }
        public string Update(Guid id, ChiTietKhuyenMai chiTietKhuyenMai)
        {
            if (id == null) return "sửa không thành công";
            else
            {
                _chiTietKhuyenMaiRepository.UpdateCTKhuyenMai(id, chiTietKhuyenMai);
                return "Sửa thành công ";
            }
        }

        

        
    }


}



