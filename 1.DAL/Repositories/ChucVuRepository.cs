using _1.DAL.Context;
using _1.DAL.DomainClass;
using _1.DAL.IRepositoties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositories
{
    public class ChucVuRepository : IChucVuRepository
    {
        private FpolyDBContext _DBcontext;
        private List<ChucVu> _lstChucVu;
        public ChucVuRepository()
        {
            _DBcontext = new FpolyDBContext();
            _lstChucVu = new List<ChucVu>();
        }
        int a;
        public bool addChucVu(ChucVu chucVu)
        {
            _DBcontext.ChucVus.Add(chucVu);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deleteChucVu(ChucVu chucVu)
        {
            _DBcontext.ChucVus.Remove(chucVu);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<ChucVu> getChucVusFromDB()
        {
            _lstChucVu = _DBcontext.ChucVus.ToList();
            return _lstChucVu;
        }

        public bool updateChucVu(ChucVu chucVu)
        {
            _DBcontext.ChucVus.Update(chucVu);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}
