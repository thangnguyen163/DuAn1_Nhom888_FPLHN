using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Index(nameof(Ma), Name = "UQ__LoaiBia__3214CC9E78664718", IsUnique = true)]
    public partial class LoaiBium
    {
        public LoaiBium()
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

        [InverseProperty(nameof(ChiTietSach.IdLoaiBiaNavigation))]
        public virtual ICollection<ChiTietSach> ChiTietSaches { get; set; }
    }
}
