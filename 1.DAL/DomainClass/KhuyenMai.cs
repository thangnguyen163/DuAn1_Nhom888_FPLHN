using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Table("KhuyenMai")]
    [Index(nameof(Ma), Name = "UQ__KhuyenMa__3214CC9EAAD7353E", IsUnique = true)]
    public partial class KhuyenMai
    {
        public KhuyenMai()
        {
            ChiTietKhuyenMais = new HashSet<ChiTietKhuyenMai>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(50)]
        public string Ten { get; set; }
        [StringLength(255)]
        public string MoTa { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(ChiTietKhuyenMai.IdKhuyenMaiNavigation))]
        public virtual ICollection<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
    }
}
