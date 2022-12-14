using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Table("TheLoai")]
    [Index(nameof(Ma), Name = "UQ__TheLoai__3214CC9EE2E8F737", IsUnique = true)]
    public partial class TheLoai
    {
        public TheLoai()
        {
            ChiTietSaches = new HashSet<ChiTietSach>();
            InverseIdChaNavigation = new HashSet<TheLoai>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(50)]
        public string Ten { get; set; }
        public Guid? IdCha { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(IdCha))]
        [InverseProperty(nameof(TheLoai.InverseIdChaNavigation))]
        public virtual TheLoai IdChaNavigation { get; set; }
        [InverseProperty(nameof(ChiTietSach.IdTheLoaiNavigation))]
        public virtual ICollection<ChiTietSach> ChiTietSaches { get; set; }
        [InverseProperty(nameof(TheLoai.IdChaNavigation))]
        public virtual ICollection<TheLoai> InverseIdChaNavigation { get; set; }
    }
}
