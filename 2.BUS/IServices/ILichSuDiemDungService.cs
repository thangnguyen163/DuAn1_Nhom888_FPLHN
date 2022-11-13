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
        public string Add(LichSuDiemDungView obj);
        public string Remove(LichSuDiemDungView obj);
        public string Update(LichSuDiemDungView obj);
        public List<LichSuDiemDungView> GetAll();
    }
}
