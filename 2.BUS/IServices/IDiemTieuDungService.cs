using _1.DAL.DomainClass;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IDiemTieuDungService
    {
        public string Add(DiemTieuDung obj);
        public string Remove(DiemTieuDung obj);
        public string Update(DiemTieuDung obj);
        public List<DiemTieuDung> GetAll();
        public List<DiemTieuDungView> GetAllView();
    }
}
