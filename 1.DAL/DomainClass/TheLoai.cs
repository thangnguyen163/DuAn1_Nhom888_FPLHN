using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Table("TheLoai")]
    [Index(nameof(Ma), Name = "UQ__TheLoai__3214CC9E9F957BE9", IsUnique = true)]
    public partial class TheLoai
    {
        public TheLoai()
        {
            ChiTietTheLoais = new HashSet<ChiTietTheLoai>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(50)]
        public string Ten { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(ChiTietTheLoai.IdTheLoaiNavigation))]
        public virtual ICollection<ChiTietTheLoai> ChiTietTheLoais { get; set; }
    }
}
