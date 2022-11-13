using _1.DAL.DomainClass;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IService
{
    public interface ITheLoaiService
    {
        string Add(TheLoai obj);
        string Update(TheLoai obj);
        string Delete(TheLoai obj);
        List<TheLoaiView> GetAll();
    }
}
