using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Table("NXB")]
    [Index(nameof(Ma), Name = "UQ__NXB__3214CC9E96C17E4F", IsUnique = true)]
    public partial class Nxb
    {
        public Nxb()
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

        [InverseProperty(nameof(ChiTietSach.IdNxbNavigation))]
        public virtual ICollection<ChiTietSach> ChiTietSaches { get; set; }
    }
}
