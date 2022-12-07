using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IGiaoCaRepository
    {
        public bool Add(GiaoCa obj);
        public bool Update(GiaoCa obj);
        public bool UpdateTienPhatSinh(GiaoCa obj);
        public bool UpdateRutTien(GiaoCa obj);
        public List<GiaoCa> GetAll();
    }
}
