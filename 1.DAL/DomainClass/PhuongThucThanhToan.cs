using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Table("PhuongThucThanhToan")]
    [Index(nameof(Ma), Name = "UQ__PhuongTh__3214CC9EAF5DB79A", IsUnique = true)]
    public partial class PhuongThucThanhToan
    {
        public PhuongThucThanhToan()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(50)]
        public string Ten { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(HoaDon.IdphuongThucThanhToanNavigation))]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
