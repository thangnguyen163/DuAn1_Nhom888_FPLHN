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
        public string Add(LichSuDiemTichView obj);
        public string Remove(LichSuDiemTichView obj);
        public string Update(LichSuDiemTichView obj);
        public List<LichSuDiemTichView> GetAll();
    }
}
