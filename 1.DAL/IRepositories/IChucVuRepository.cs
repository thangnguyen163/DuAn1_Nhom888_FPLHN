using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositoties
{
    public interface IChucVuRepository
    {
        bool addChucVu(ChucVu chucVu);
        bool updateChucVu(ChucVu chucVu);
        bool deleteChucVu(ChucVu chucVu);
        List<ChucVu> getChucVusFromDB();
    }
}
