﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class HoadonView
    {
        public Guid Id { get; set; }
        public string Makh { get; set; }
        public string Manv { get; set; }
        public string sodiemtich { get; set; }
        public int Sodiemdung { get; set; }
        public string tongtiendung { get; set; }
        public string Mahd { get; set; }
        public DateTime? Ngaytao { get; set; }
        public decimal? Thue { get; set; }
        public decimal? Giamgia { get; set; }       
        public decimal? tongtien { get; set; }
        public string? ghichu { get; set; }
        public int? Trangthai { get; set; }
    }
}
