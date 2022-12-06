using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Table("NhanVien")]
    [Index(nameof(Ma), Name = "UQ__NhanVien__3214CC9ED07725BD", IsUnique = true)]
    public partial class NhanVien
    {
        public NhanVien()
        {
            GiaoCas = new HashSet<GiaoCa>();
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(50)]
        public string Ten { get; set; }
        public int? GioiTinh { get; set; }
        public int? NamSinh { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string DiaChi { get; set; }
        [Column("SDT")]
        [StringLength(30)]
        public string Sdt { get; set; }
        [Column("CCCD", TypeName = "decimal(20, 0)")]
        public decimal? Cccd { get; set; }
        public string MatKhau { get; set; }
        [Column(TypeName = "image")]
        public byte[] Anh { get; set; }
        [Column("IDChucVu")]
        public Guid? IdchucVu { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(IdchucVu))]
        [InverseProperty(nameof(ChucVu.NhanViens))]
        public virtual ChucVu IdchucVuNavigation { get; set; }
        [InverseProperty(nameof(GiaoCa.IdNhanVienNavigation))]
        public virtual ICollection<GiaoCa> GiaoCas { get; set; }
        [InverseProperty(nameof(HoaDon.IdnvNavigation))]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
