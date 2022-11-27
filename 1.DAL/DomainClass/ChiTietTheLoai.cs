using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Table("ChiTietTheLoai")]
    [Index(nameof(Ma), Name = "UQ__ChiTietT__3214CC9E7269769D", IsUnique = true)]
    public partial class ChiTietTheLoai
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? IdTheLoai { get; set; }
        public Guid? IdChiTietSach { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(50)]
        public string Ten { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(IdChiTietSach))]
        [InverseProperty(nameof(ChiTietSach.ChiTietTheLoais))]
        public virtual ChiTietSach IdChiTietSachNavigation { get; set; }
        [ForeignKey(nameof(IdTheLoai))]
        [InverseProperty(nameof(TheLoai.ChiTietTheLoais))]
        public virtual TheLoai IdTheLoaiNavigation { get; set; }
    }
}
