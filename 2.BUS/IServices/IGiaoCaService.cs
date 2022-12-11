using _1.DAL.DomainClass;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IGiaoCaService
    {
        public string Add(GiaoCa obj);
        public string Update(GiaoCa obj);
        public string UpdateTienPhatSinh(GiaoCa obj);
        public string UpdateRutTien(GiaoCa obj);
        public string UpdateKetCa(GiaoCa obj);
        public List<GiaoCa> GetAll();
    }
}
