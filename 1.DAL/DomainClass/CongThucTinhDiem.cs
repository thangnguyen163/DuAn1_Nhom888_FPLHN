using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Table("CongThucTinhDiem")]
    [Index(nameof(Ma), Name = "UQ__CongThuc__3214CC9E8273C052", IsUnique = true)]
    public partial class CongThucTinhDiem
    {
        public CongThucTinhDiem()
        {
            LichSuDiemDungs = new HashSet<LichSuDiemDung>();
            LichSuDiemTiches = new HashSet<LichSuDiemTich>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? TongTien { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? HeSo { get; set; }
        public int? GiamGia { get; set; }
        public int? TongDiem { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(LichSuDiemDung.IdCttinhNavigation))]
        public virtual ICollection<LichSuDiemDung> LichSuDiemDungs { get; set; }
        [InverseProperty(nameof(LichSuDiemTich.IdCttinhNavigation))]
        public virtual ICollection<LichSuDiemTich> LichSuDiemTiches { get; set; }
    }
}
