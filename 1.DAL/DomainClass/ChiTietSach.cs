using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Table("ChiTietSach")]
    [Index(nameof(Ma), Name = "UQ__ChiTietS__3214CC9E1D516602", IsUnique = true)]
    public partial class ChiTietSach
    {
        public ChiTietSach()
        {
            ChiTietKhuyenMais = new HashSet<ChiTietKhuyenMai>();
            ChiTietTheLoais = new HashSet<ChiTietTheLoai>();
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid? IdSach { get; set; }
        [Column("IdNXB")]
        public Guid? IdNxb { get; set; }
        public Guid? IdTacGia { get; set; }
        public Guid? IdNhaPhatHanh { get; set; }
        public Guid? IdLoaiBia { get; set; }
        [StringLength(50)]
        public string Ma { get; set; }
        [Column(TypeName = "image")]
        public byte[] Anh { get; set; }
        public string MaVach { get; set; }
        [StringLength(20)]
        public string KichThuoc { get; set; }
        public int? SoTrang { get; set; }
        public int? NamXuatBan { get; set; }
        [StringLength(255)]
        public string MoTa { get; set; }
        public int? SoLuong { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? GiaNhap { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? GiaBan { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(IdLoaiBia))]
        [InverseProperty(nameof(LoaiBium.ChiTietSaches))]
        public virtual LoaiBium IdLoaiBiaNavigation { get; set; }
        [ForeignKey(nameof(IdNhaPhatHanh))]
        [InverseProperty(nameof(NhaPhatHanh.ChiTietSaches))]
        public virtual NhaPhatHanh IdNhaPhatHanhNavigation { get; set; }
        [ForeignKey(nameof(IdNxb))]
        [InverseProperty(nameof(Nxb.ChiTietSaches))]
        public virtual Nxb IdNxbNavigation { get; set; }
        [ForeignKey(nameof(IdSach))]
        [InverseProperty(nameof(Sach.ChiTietSaches))]
        public virtual Sach IdSachNavigation { get; set; }
        [ForeignKey(nameof(IdTacGia))]
        [InverseProperty(nameof(TacGium.ChiTietSaches))]
        public virtual TacGium IdTacGiaNavigation { get; set; }
        [InverseProperty(nameof(ChiTietKhuyenMai.IdChiTietSachNavigation))]
        public virtual ICollection<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
        [InverseProperty(nameof(ChiTietTheLoai.IdChiTietSachNavigation))]
        public virtual ICollection<ChiTietTheLoai> ChiTietTheLoais { get; set; }
        [InverseProperty(nameof(HoaDonChiTiet.IdChiTietSachNavigation))]
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
