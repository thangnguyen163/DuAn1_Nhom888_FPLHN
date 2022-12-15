using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Table("HoaDonChiTiet")]
    [Index(nameof(Ma), Name = "UQ__HoaDonCh__3214CC9EE18833C1", IsUnique = true)]
    public partial class HoaDonChiTiet
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? IdHoaDon { get; set; }
        public Guid? IdChiTietSach { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        public int? GiamGia { get; set; }
        public int? SoLuong { get; set; }
        public int? DonGia { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? ThanhTien { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(IdChiTietSach))]
        [InverseProperty(nameof(ChiTietSach.HoaDonChiTiets))]
        public virtual ChiTietSach IdChiTietSachNavigation { get; set; }
        [ForeignKey(nameof(IdHoaDon))]
        [InverseProperty(nameof(HoaDon.HoaDonChiTiets))]
        public virtual HoaDon IdHoaDonNavigation { get; set; }
    }
}
