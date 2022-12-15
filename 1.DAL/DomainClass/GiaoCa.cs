using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Table("GiaoCa")]
    [Index(nameof(Ma), Name = "UQ__GiaoCa__3214CC9E2045F7E0", IsUnique = true)]
    public partial class GiaoCa
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianNhanCa { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianGiaoCa { get; set; }
        public Guid? IdNhanVien { get; set; }
        public Guid? IdNhanVienCaTiep { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? TienBanDau { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? TongTienTrongCa { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? TongTienMat { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? TongTienKhac { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? TienPhatSinh { get; set; }
        [StringLength(255)]
        public string GhiChuPhatSinh { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? TongTienMatCaTruoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianReset { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? TongTienMatRut { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(IdNhanVien))]
        [InverseProperty(nameof(NhanVien.GiaoCas))]
        public virtual NhanVien IdNhanVienNavigation { get; set; }
    }
}
