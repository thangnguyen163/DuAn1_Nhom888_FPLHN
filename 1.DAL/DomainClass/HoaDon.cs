using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1.DAL.DomainClass
{
    [Table("HoaDon")]
    [Index(nameof(MaHd), Name = "UQ__HoaDon__2725A6E160220240", IsUnique = true)]
    public partial class HoaDon
    {
        public HoaDon()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        [Key]
        public Guid Id { get; set; }
        [Column("IDKH")]
        public Guid? Idkh { get; set; }
        [Column("IDNV")]
        public Guid? Idnv { get; set; }
        [Column("IDDiemTich")]
        public Guid? IddiemTich { get; set; }
        [Column("IDDiemDung")]
        public Guid? IddiemDung { get; set; }
        [Column("IDPhuongThucThanhToan")]
        public Guid? IdphuongThucThanhToan { get; set; }
        [Column("MaHD")]
        [StringLength(20)]
        public string MaHd { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayShip { get; set; }
        public int? TienCoc { get; set; }
        public int? TienShip { get; set; }
        public string DiaChi { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? Thue { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? GiamGia { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? TienMat { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? TienChuyenKhoan { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? TongTien { get; set; }
        [StringLength(255)]
        public string GhiChu { get; set; }
        public int? TrangThai { get; set; }
        [StringLength(100)]
        public string TenNguoiNhan { get; set; }
        [StringLength(30)]
        public string SdtNguoiNhan { get; set; }

        [ForeignKey(nameof(IddiemDung))]
        [InverseProperty(nameof(LichSuDiemDung.HoaDons))]
        public virtual LichSuDiemDung IddiemDungNavigation { get; set; }
        [ForeignKey(nameof(IddiemTich))]
        [InverseProperty(nameof(LichSuDiemTich.HoaDons))]
        public virtual LichSuDiemTich IddiemTichNavigation { get; set; }
        [ForeignKey(nameof(Idkh))]
        [InverseProperty(nameof(KhachHang.HoaDons))]
        public virtual KhachHang IdkhNavigation { get; set; }
        [ForeignKey(nameof(Idnv))]
        [InverseProperty(nameof(NhanVien.HoaDons))]
        public virtual NhanVien IdnvNavigation { get; set; }
        [ForeignKey(nameof(IdphuongThucThanhToan))]
        [InverseProperty(nameof(PhuongThucThanhToan.HoaDons))]
        public virtual PhuongThucThanhToan IdphuongThucThanhToanNavigation { get; set; }
        [InverseProperty(nameof(HoaDonChiTiet.IdHoaDonNavigation))]
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
