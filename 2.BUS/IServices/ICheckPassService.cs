using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
   public interface ICheckPassService 
    {
        bool updatepass(NhanVien pass);
        List<NhanVien> getpass();
        string encryption(string password);
    }
}
