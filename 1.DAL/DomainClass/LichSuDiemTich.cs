using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Table("LichSuDiemTich")]
    [Index(nameof(Ma), Name = "UQ__LichSuDi__3214CC9EC44A4CBE", IsUnique = true)]
    public partial class LichSuDiemTich
    {
        public LichSuDiemTich()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public Guid Id { get; set; }
        [Column("IdCTTinh")]
        public Guid? IdCttinh { get; set; }
        [Column("IDDiemTieuDung")]
        public Guid? IddiemTieuDung { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        public int? SoDiemTich { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgaySuDung { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? TongTien { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(IdCttinh))]
        [InverseProperty(nameof(CongThucTinhDiem.LichSuDiemTiches))]
        public virtual CongThucTinhDiem IdCttinhNavigation { get; set; }
        [ForeignKey(nameof(IddiemTieuDung))]
        [InverseProperty(nameof(DiemTieuDung.LichSuDiemTiches))]
        public virtual DiemTieuDung IddiemTieuDungNavigation { get; set; }
        [InverseProperty(nameof(HoaDon.IddiemTichNavigation))]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
