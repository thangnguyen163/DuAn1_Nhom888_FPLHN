using _1.DAL.DomainClass;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IService
{
    public interface IChiTietTheLoaiService
    {
        string Add(ChiTietTheLoai obj);
        string Update(ChiTietTheLoai obj);
        string Delete(ChiTietTheLoai obj);
        List<ChiTietTheLoaiView> GetAll();
    }
}
