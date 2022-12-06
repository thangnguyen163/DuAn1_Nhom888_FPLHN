using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Table("ChiTietKhuyenMai")]
    [Index(nameof(Ma), Name = "UQ__ChiTietK__3214CC9EACC5C023", IsUnique = true)]
    public partial class ChiTietKhuyenMai
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? IdChiTietSach { get; set; }
        public Guid? IdKhuyenMai { get; set; }
        [StringLength(50)]
        public string Ma { get; set; }
        [StringLength(50)]
        public string Ten { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayBatDau { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }
        [StringLength(255)]
        public string MoTa { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(IdChiTietSach))]
        [InverseProperty(nameof(ChiTietSach.ChiTietKhuyenMais))]
        public virtual ChiTietSach IdChiTietSachNavigation { get; set; }
        [ForeignKey(nameof(IdKhuyenMai))]
        [InverseProperty(nameof(KhuyenMai.ChiTietKhuyenMais))]
        public virtual KhuyenMai IdKhuyenMaiNavigation { get; set; }
    }
}
