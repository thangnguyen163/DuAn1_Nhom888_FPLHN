using _1.DAL.DomainClass;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface ILichSuDiemTichService
    {
        public string Add(LichSuDiemTich obj);
        public string Remove(LichSuDiemTich obj);
        public string Update(LichSuDiemTich obj);
        public List<LichSuDiemTich> GetAll();
        public List<LichSuDiemTichView> GetAllView();
    }
}
