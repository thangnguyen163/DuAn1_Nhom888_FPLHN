using _1.DAL.DomainClass;
using _2.BUS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSystem.Security.Cryptography;

namespace _2.BUS.Serivces
{
    public class CheckPassService : ICheckPassService
    {
        private INhanVienService _nhanvienService;
        private List<NhanVien> _lstNhanVien;
        public CheckPassService()
        {
            _nhanvienService = new NhanVienService();
            _lstNhanVien = new List<NhanVien>();
            getpass();
        }
        public string encryption(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

        public List<NhanVien> getpass()
        {
            return _nhanvienService.getNhanViensFromDB();
        }

        public bool updatepass(NhanVien pass)
        {
            _nhanvienService.addNhanVien(pass);
            return true;
        }
    }
}
