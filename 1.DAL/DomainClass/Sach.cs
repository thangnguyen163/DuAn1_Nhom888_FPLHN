using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Table("Sach")]
    [Index(nameof(Ma), Name = "UQ__Sach__3214CC9ECA70A68A", IsUnique = true)]
    public partial class Sach
    {
        public Sach()
        {
            ChiTietSaches = new HashSet<ChiTietSach>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(50)]
        public string Ten { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(ChiTietSach.IdSachNavigation))]
        public virtual ICollection<ChiTietSach> ChiTietSaches { get; set; }
    }
}
