using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using _1.DAL.DomainClass;

#nullable disable

namespace _1.DAL.Context
{
    public partial class FpolyDBContext : DbContext
    {
        public FpolyDBContext()
        {
        }

        public FpolyDBContext(DbContextOptions<FpolyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
        public virtual DbSet<ChiTietSach> ChiTietSaches { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<CongThucTinhDiem> CongThucTinhDiems { get; set; }
        public virtual DbSet<DiemTieuDung> DiemTieuDungs { get; set; }
        public virtual DbSet<GiaoCa> GiaoCas { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<LichSuDiemDung> LichSuDiemDungs { get; set; }
        public virtual DbSet<LichSuDiemTich> LichSuDiemTiches { get; set; }
        public virtual DbSet<LoaiBium> LoaiBia { get; set; }
        public virtual DbSet<NhaPhatHanh> NhaPhatHanhs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Nxb> Nxbs { get; set; }
        public virtual DbSet<PhuongThucThanhToan> PhuongThucThanhToans { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<TacGium> TacGia { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-FL10PIN\\SQLEXPRESS;Initial Catalog=DuAn1_Nhom888_FPLHN;Persist Security Info=True;User ID=thang;Password=12345678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChiTietKhuyenMai>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdChiTietSachNavigation)
                    .WithMany(p => p.ChiTietKhuyenMais)
                    .HasForeignKey(d => d.IdChiTietSach)
                    .HasConstraintName("FK__ChiTietKh__IdChi__634EBE90");

                entity.HasOne(d => d.IdKhuyenMaiNavigation)
                    .WithMany(p => p.ChiTietKhuyenMais)
                    .HasForeignKey(d => d.IdKhuyenMai)
                    .HasConstraintName("FK__ChiTietKh__IdKhu__671F4F74");
            });

            modelBuilder.Entity<ChiTietSach>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.GiaBan).HasDefaultValueSql("((0))");

                entity.Property(e => e.GiaNhap).HasDefaultValueSql("((0))");

                entity.Property(e => e.KichThuoc).IsUnicode(false);

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.MaVach).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdLoaiBiaNavigation)
                    .WithMany(p => p.ChiTietSaches)
                    .HasForeignKey(d => d.IdLoaiBia)
                    .HasConstraintName("FK__ChiTietSa__IdLoa__65370702");

                entity.HasOne(d => d.IdNhaPhatHanhNavigation)
                    .WithMany(p => p.ChiTietSaches)
                    .HasForeignKey(d => d.IdNhaPhatHanh)
                    .HasConstraintName("FK__ChiTietSa__IdNha__6442E2C9");

                entity.HasOne(d => d.IdNxbNavigation)
                    .WithMany(p => p.ChiTietSaches)
                    .HasForeignKey(d => d.IdNxb)
                    .HasConstraintName("FK__ChiTietSa__IdNXB__607251E5");

                entity.HasOne(d => d.IdSachNavigation)
                    .WithMany(p => p.ChiTietSaches)
                    .HasForeignKey(d => d.IdSach)
                    .HasConstraintName("FK__ChiTietSa__IdSac__5F7E2DAC");

                entity.HasOne(d => d.IdTacGiaNavigation)
                    .WithMany(p => p.ChiTietSaches)
                    .HasForeignKey(d => d.IdTacGia)
                    .HasConstraintName("FK__ChiTietSa__IdTac__6166761E");

                entity.HasOne(d => d.IdTheLoaiNavigation)
                    .WithMany(p => p.ChiTietSaches)
                    .HasForeignKey(d => d.IdTheLoai)
                    .HasConstraintName("FK__ChiTietSa__IdThe__625A9A57");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<CongThucTinhDiem>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<DiemTieuDung>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.SoDiem).HasDefaultValueSql("((0))");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<GiaoCa>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.TienBanDau).HasDefaultValueSql("((0))");

                entity.Property(e => e.TienPhatSinh).HasDefaultValueSql("((0))");

                entity.Property(e => e.TongTienKhac).HasDefaultValueSql("((0))");

                entity.Property(e => e.TongTienMat).HasDefaultValueSql("((0))");

                entity.Property(e => e.TongTienMatCaTruoc).HasDefaultValueSql("((0))");

                entity.Property(e => e.TongTienTrongCa).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdNhanVienNavigation)
                    .WithMany(p => p.GiaoCas)
                    .HasForeignKey(d => d.IdNhanVien)
                    .HasConstraintName("FK__GiaoCa__IdNhanVi__74794A92");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DiaChi).IsUnicode(false);

                entity.Property(e => e.MaHd).IsUnicode(false);

                entity.Property(e => e.SdtNguoiNhan).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IddiemDungNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.IddiemDung)
                    .HasConstraintName("FK__HoaDon__IDDiemDu__6CD828CA");

                entity.HasOne(d => d.IddiemTichNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.IddiemTich)
                    .HasConstraintName("FK__HoaDon__IDDiemTi__6BE40491");

                entity.HasOne(d => d.IdkhNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.Idkh)
                    .HasConstraintName("FK__HoaDon__IDKH__6DCC4D03");

                entity.HasOne(d => d.IdnvNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.Idnv)
                    .HasConstraintName("FK__HoaDon__IDNV__6EC0713C");

                entity.HasOne(d => d.IdphuongThucThanhToanNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.IdphuongThucThanhToan)
                    .HasConstraintName("FK__HoaDon__IDPhuong__73852659");
            });

            modelBuilder.Entity<HoaDonChiTiet>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdChiTietSachNavigation)
                    .WithMany(p => p.HoaDonChiTiets)
                    .HasForeignKey(d => d.IdChiTietSach)
                    .HasConstraintName("FK__HoaDonChi__IdChi__70A8B9AE");

                entity.HasOne(d => d.IdHoaDonNavigation)
                    .WithMany(p => p.HoaDonChiTiets)
                    .HasForeignKey(d => d.IdHoaDon)
                    .HasConstraintName("FK__HoaDonChi__IdHoa__719CDDE7");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.Sdt).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IddiemTieuDungNavigation)
                    .WithMany(p => p.KhachHangs)
                    .HasForeignKey(d => d.IddiemTieuDung)
                    .HasConstraintName("FK__KhachHang__IDDie__72910220");
            });

            modelBuilder.Entity<KhuyenMai>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<LichSuDiemDung>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdCttinhNavigation)
                    .WithMany(p => p.LichSuDiemDungs)
                    .HasForeignKey(d => d.IdCttinh)
                    .HasConstraintName("FK__LichSuDie__IdCTT__6AEFE058");

                entity.HasOne(d => d.IddiemTieuDungNavigation)
                    .WithMany(p => p.LichSuDiemDungs)
                    .HasForeignKey(d => d.IddiemTieuDung)
                    .HasConstraintName("FK__LichSuDie__IDDie__69FBBC1F");
            });

            modelBuilder.Entity<LichSuDiemTich>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdCttinhNavigation)
                    .WithMany(p => p.LichSuDiemTiches)
                    .HasForeignKey(d => d.IdCttinh)
                    .HasConstraintName("FK__LichSuDie__IdCTT__690797E6");

                entity.HasOne(d => d.IddiemTieuDungNavigation)
                    .WithMany(p => p.LichSuDiemTiches)
                    .HasForeignKey(d => d.IddiemTieuDung)
                    .HasConstraintName("FK__LichSuDie__IDDie__681373AD");
            });

            modelBuilder.Entity<LoaiBium>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<NhaPhatHanh>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.GioiTinh).HasDefaultValueSql("((0))");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.MatKhau).IsUnicode(false);

                entity.Property(e => e.Sdt).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdchucVuNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.IdchucVu)
                    .HasConstraintName("FK__NhanVien__IDChuc__6FB49575");
            });

            modelBuilder.Entity<Nxb>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PhuongThucThanhToan>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TacGium>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TheLoai>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma).IsUnicode(false);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdChaNavigation)
                    .WithMany(p => p.InverseIdChaNavigation)
                    .HasForeignKey(d => d.IdCha)
                    .HasConstraintName("FK__TheLoai__IdCha__662B2B3B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
