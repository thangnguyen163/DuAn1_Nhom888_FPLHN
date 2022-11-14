using _1.DAL.DomainClass;
using _2.BUS.IService;
using _1.DAL.Repositoties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.IRepositoties;
using _1.DAL.Repositories;

namespace _2.BUS.Service
{
    public class ChucVuServivce : IChucVuService
    {
        private IChucVuRepository _IchucVuRepository;
        private List<ChucVu> _lstChucVu;

        public ChucVuServivce()
        {
            _IchucVuRepository = new ChucVuRepository();
            _lstChucVu = new List<ChucVu>();
        }
        public bool addChucVu(ChucVu chucVu)
        {
            _IchucVuRepository.addChucVu(chucVu);
            return true;
        }

        public bool deleteChucVu(ChucVu chucVu)
        {
            _IchucVuRepository.deleteChucVu(chucVu);
            return true;
        }

        public List<ChucVu> getChucVusFromDB()
        {
            _lstChucVu = _IchucVuRepository.getChucVusFromDB();
            return _lstChucVu;
        }

        public bool updateChucVu(ChucVu chucVu)
        {
            _IchucVuRepository.updateChucVu(chucVu);
            return true;
        }
    }
}
