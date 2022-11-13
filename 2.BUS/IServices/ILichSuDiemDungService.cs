using _1.DAL.DomainClass;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface ILichSuDiemDungService
    {
        public string Add(LichSuDiemDung obj);
        public string Remove(LichSuDiemDung obj);
        public string Update(LichSuDiemDung obj);
        public List<LichSuDiemDungView> GetAll();
    }
}
