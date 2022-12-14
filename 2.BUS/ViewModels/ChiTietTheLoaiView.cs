﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.ViewModels
{
    public class ChiTietTheLoaiView
    {
        public Guid Id { get; set; }
        public Guid IDCTS { get; set; }
        public Guid IDTL { get; set; }
        public string TheLoai { get; set; }
        public string TenSach { get; set; }
        public string Ma { get; set; }
        public string ChiTietTheLoai { get; set; }
        public int? TrangThai { get; set; }
    }
}