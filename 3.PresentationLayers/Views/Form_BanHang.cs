using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using _2.BUS.IService;
using _2.BUS.IServices;
using _2.BUS.Serivces;
using _2.BUS.Service;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media;
using XAct;
using Brushes = System.Drawing.Brushes;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;

namespace _3.PresentationLayers.Views
{
    public partial class Form_BanHang : Form
    {
        private IHoaDonService hoaDonService;
        private IChiTietSachService _iChiTietSachService;
        private INhanVienService _inhanvienService;
        private IKhachHangService _ikhachHangService;
        private ISachService sachService;
        private IHoaDonChiTietService hoaDonChiTietService;
        private ILichSuDiemDungService _ilichSuDiemDungService = new LichSuDiemDungService();
        private ILichSuDiemTichService _ilichSuDiemTichService = new LichSuDiemTichService();
        private IDiemTieuDungService _idiemTieuDungService = new DiemTieuDungService();
        private ICongThucTinhDiemService _icongThucTinhDiemService = new CongThucTinhDiemService();
        private IPhuongThucThanhToanService _iphuongThucThanhToanService = new PhuongThucThanhToanService();
        private IGiaoCaService _igiaocaservice = new GiaoCaService();
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public Guid SelectID { get; set; }
        public Guid SelectIDSp { get; set; }
        private HoaDonChiTiet hoaDonChiTiet;
        private ChiTietSach ChiTietSach;
        private Guid SelectNhanVien;
        public int dem { get; set; }

        public Form_BanHang()
        {
            InitializeComponent();
            hoaDonService = new HoaDonService();
            _iChiTietSachService = new ChiTietSachService();
            sachService = new SachService();
            hoaDonChiTietService = new HoaDonChiTietService();
            hoaDonChiTiet = new HoaDonChiTiet();
            _inhanvienService = new NhanVienService();
            _ikhachHangService = new KhachHangService();
            ChiTietSach = new ChiTietSach();

            LoadHoaDonChoThanhToan();
            //LoadHoaDonDaThanhToan();
            Tabhoadondcmm();
            tabHoaDon.Visible = false;
            Locktextboxfrombanhang();
            LoadSanphamtoFl();
            cbx_Loc.SelectedIndex = 1;
            rd_chogiao.Checked = true;
            panel_tiencoc.Visible = false;
            panel_capnhat.Visible = false;
            tabHoaDon.SelectedIndex = -1;
            cbb_phuongthucthanhtoan.SelectedIndex = -1;
        }
        public Form_BanHang(string a)
        {
            InitializeComponent();
            hoaDonService = new HoaDonService();
            _iChiTietSachService = new ChiTietSachService();
            sachService = new SachService();
            hoaDonChiTietService = new HoaDonChiTietService();
            hoaDonChiTiet = new HoaDonChiTiet();
            _inhanvienService = new NhanVienService();
            _ikhachHangService = new KhachHangService();
            ChiTietSach = new ChiTietSach();

            LoadHoaDonChoThanhToan();
            //LoadHoaDonDaThanhToan();
            Tabhoadondcmm();
            tabHoaDon.Visible = false;
            Locktextboxfrombanhang();
            LoadSanphamtoFl();
            cbx_Loc.SelectedIndex = 1;
            panel_tiencoc.Visible = false;
            panel_capnhat.Visible = false;
            this.cbb_nhanvien.Text = _inhanvienService.getNhanViensFromDB().Where(x => x.Ten == a).Select(a => a.Ma).FirstOrDefault();
            SelectNhanVien = Guid.Parse(Convert.ToString(_inhanvienService.getNhanViensFromDB().Where(x => x.Ten == a).Select(a => a.Id).FirstOrDefault()));

            //panel_chuyenkhoan.Visible = false;
            //panel_tienmat.Visible = false;
            //panel10.Visible = false;

        }
        private void Locktextboxfrombanhang()
        {
            if (tabHoaDon.SelectedIndex < 0)
            {
                tb_dungdiem.ReadOnly = true;
                cbb_phuongthucthanhtoan.SelectedIndex = -1;
                tb_tientralai.ReadOnly = true;
            }
        }
        private void LoadBtnQuet()
        {
            if (lbdtghdct.Text == "Chưa có hóa đơn nào được chọn")
            {
                btn_quetma.Enabled = false;
                return;
            }
            if (lbdtghdct.Text == "")
            {
                btn_quetma.Enabled = true;
                return;
            }
        }
        public void LoaddataToHoadonChitiet()
        {
            HoaDon hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            SelectID = hd.Id;
            dtg_HoaDonChiTiet.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // căn giữa 
            dtg_HoaDonChiTiet.Columns[3].Width = 39;
            dtg_HoaDonChiTiet.Columns[2].Width = 215;
            dtg_HoaDonChiTiet.Columns[5].Width = 39;
            dtg_HoaDonChiTiet.Columns[4].Width = 79;
            dtg_HoaDonChiTiet.Columns[8].Width = 39;
            dtg_HoaDonChiTiet.Rows.Clear();
            foreach (var x in hoaDonChiTietService.GetAll().Where(x => x.IDhoadon == SelectID))
            {
                dtg_HoaDonChiTiet.Rows.Add(x.ID, x.MactSach, x.Tensach, "-", x.Soluong, "+", x.Dongia, x.Thanhtien, "X");
            }
            if (hd.TrangThai == 1)
            {
                if (hd.TienCoc != null)
                {
                    tabtrangthaimuahang.SelectedIndex = 1;
                }
                else if (hd.TienCoc == null)
                {
                    tabtrangthaimuahang.SelectedIndex = 0;
                }
            }
            else if (hd.TrangThai == 2 || hd.TrangThai == 3)
            {
                tabtrangthaimuahang.SelectedIndex = 1;
            }
            else if (hd.TrangThai == 0)
            {
                if (hd.TienCoc != null)
                {
                    tabtrangthaimuahang.SelectedIndex = 1;
                }
                else
                {
                    tabtrangthaimuahang.SelectedIndex = 0;
                }
            }
            LoaddataToTextbox(SelectID);
        }


        private void btnsender_Click(object sender, EventArgs e)
        {
            tabHoaDon.Visible = true;
            SelectID = ((sender as Button).Tag as HoaDon).Id; // lấy Id từ button                                          
            dtg_HoaDonChiTiet.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // căn giữa 
            dtg_HoaDonChiTiet.Columns[3].Width = 39;
            dtg_HoaDonChiTiet.Columns[5].Width = 39;
            dtg_HoaDonChiTiet.Columns[4].Width = 79;
            dtg_HoaDonChiTiet.Columns[8].Width = 39;
            //css dtg
            dtg_HoaDonChiTiet.Rows.Clear();
            foreach (var x in hoaDonChiTietService.GetAll().Where(x => x.IDhoadon == SelectID))
            {
                dtg_HoaDonChiTiet.Rows.Add(x.ID, x.MactSach, x.Tensach, "-", x.Soluong, "+", x.Dongia, x.Thanhtien, "X");
            }
            // tạo tabpage từ button ==>V
            HoaDon hd = new HoaDon();
            hd = hoaDonService.GetAllHoaDon().FirstOrDefault(x => x.Id == SelectID);
            int count = 0;
            for (int i = 0; i < tabHoaDon.TabCount; i++)
            {
                if (hd.MaHd == tabHoaDon.TabPages[i].Name)
                {
                    count = 1;
                    tabHoaDon.SelectedTab = tabHoaDon.TabPages[i];
                    break;
                }
            }
            if (count == 0)
            {
                TabPage tpage = new TabPage();
                tabHoaDon.TabPages.Add(tpage);
                tpage.Text = Convert.ToString(hd.MaHd);
                tpage.Name = Convert.ToString(hd.MaHd);
                dem = tabHoaDon.TabCount - 1;
                tabHoaDon.SelectedIndex = dem;
            }
            if (hd.TrangThai == 2 || hd.TrangThai == 3)
            {
                tabtrangthaimuahang.SelectedIndex = 1;
            }
            if (hd.TrangThai == 0)
            {
                if (hd.TienCoc != null)
                {
                    tabtrangthaimuahang.SelectedIndex = 1;
                }
                else
                {
                    tabtrangthaimuahang.SelectedIndex = 0;
                }

            }
            if (hd.TrangThai == 0)
            {
                fl_KhachHang.Visible = true;
            }
            else
            {
                fl_KhachHang.Visible = false;
            }
            cleartextbox();
            Tabhoadondcmm();
        }
        private void btnsender_Click1(object sender, EventArgs e)
        {
            if (dtg_HoaDonChiTiet.Visible == false)
            {
                DialogResult hoi = MessageBox.Show("Bạn chưa chọn hóa đơn, Bạn có muốn tạo hóa đơn mới không", "Tạo hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == hoi)
                {
                    tabHoaDon.Visible = true;
                    TabPage tpage = new TabPage();
                    tabHoaDon.TabPages.Add(tpage);
                    HoaDon hd = new HoaDon();
                    hd.Id = Guid.NewGuid();
                    hd.MaHd = "HD" + Convert.ToString(hoaDonService.GetAllHoaDon().Max(c => Convert.ToInt32(c.MaHd.Substring(2, c.MaHd.Length - 2)) + 1));
                    hd.Idnv = SelectNhanVien;
                    //hd.Idkh = Guid.Parse("56303832-7163-464a-99a8-72973ed09c21");
                    hd.NgayTao = DateTime.Now;
                    MessageBox.Show(hoaDonService.Add(hd));
                    tpage.Text = Convert.ToString(hd.MaHd);
                    tpage.Name = Convert.ToString(hd.MaHd);
                    tabHoaDon.SelectedIndex = tabHoaDon.TabCount;
                    LoaddataToHoadonChitiet();
                    LoadHoaDonChiTiet();
                    LoaddataToTextbox(hd.Id);
                    Tabhoadondcmm();
                    LoadHoaDonChoThanhToan();

                    // thêm sản phẩm lên hóa đơn vừa tạo
                    var x = ((sender as Button).Tag as ChiTietSach).Id;
                    SelectIDSp = x;
                    //HoaDon hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
                    SelectID = hd.Id;
                    HoaDonChiTiet data = hoaDonChiTietService.GetAllloadformsp().FirstOrDefault(x => x.IdChiTietSach == SelectIDSp && x.IdHoaDon == SelectID);
                    string ctsclick = _iChiTietSachService.GetAllChiTietSachView().FirstOrDefault(c => c.Id == x).Ma;
                    string tenclick = _iChiTietSachService.GetAllChiTietSachView().FirstOrDefault(c => c.Id == x).TenSach;
                    decimal giabanclick = Convert.ToDecimal(_iChiTietSachService.GetAllChiTietSachView().FirstOrDefault(c => c.Id == x).GiaBan);
                    string Content = Interaction.InputBox($"Mã: {ctsclick}" + Environment.NewLine + $"Tên: {tenclick}" + Environment.NewLine + $"Giá bán: {giabanclick}" + Environment.NewLine + "Nhập số lượng ", "Bạn muốn thêm bao nhiêu", "1", 500, 300);//nhập số lượng ở màn bán hàng
                    if (Content == string.Empty) return;

                    if (Regex.IsMatch(Content, @"^[a-zA-Z0-9 ]*$") == false)
                    {

                        MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                        return;
                    }
                    if (Regex.IsMatch(Content, @"^\d+$") == false)
                    {

                        MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                        return;
                    }
                    if (Content.Length > 6)
                    {
                        MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                        return;
                    }
                    if (Convert.ToInt32(Content) <= 0)
                    {
                        MessageBox.Show("Số Lượng Phải Lớn Hơn 0", "ERR");
                        return;
                    }
                    if (Content != null)
                    {
                        if (data == null)
                        {
                            HoaDonChiTiet hdct = new HoaDonChiTiet();
                            hdct.Id = Guid.NewGuid();
                            hdct.IdHoaDon = SelectID;
                            hdct.IdChiTietSach = SelectIDSp;
                            ChiTietSach cts = new ChiTietSach();
                            cts = _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).FirstOrDefault();
                            if (cts.SoLuong >= Convert.ToInt32(Content))
                            {
                                hdct.Ma = "HDCT" + Convert.ToString(hoaDonChiTietService.GetAllloadformsp()
                                  .Max(c => Convert.ToInt32(c.Ma.Substring(4, c.Ma.Length - 4)) + 1));
                                hdct.SoLuong = Convert.ToInt32(Content);
                                hdct.DonGia = Convert.ToInt32(cts.GiaBan);
                                hdct.ThanhTien = Convert.ToInt32(hdct.SoLuong * cts.GiaBan);
                                hoaDonChiTietService.Add(hdct);
                                //update số lượng còn lại 
                                cts.IdSach = cts.IdSach;
                                cts.IdSach = cts.IdSach;
                                cts.IdNxb = cts.IdNxb;
                                cts.IdTacGia = cts.IdTacGia;
                                cts.IdNhaPhatHanh = cts.IdNhaPhatHanh;
                                cts.IdLoaiBia = cts.IdLoaiBia;
                                cts.Ma = cts.Ma;
                                cts.Anh = cts.Anh;
                                cts.MaVach = cts.MaVach;
                                cts.KichThuoc = cts.KichThuoc;
                                cts.SoTrang = cts.SoTrang;
                                cts.NamXuatBan = cts.NamXuatBan;
                                cts.MoTa = cts.MoTa;
                                cts.GiaNhap = cts.GiaNhap;
                                cts.GiaBan = cts.GiaBan;
                                cts.TrangThai = cts.TrangThai;
                                cts.SoLuong = cts.SoLuong - Convert.ToInt32(Content);
                                _iChiTietSachService.Update(hdct.IdChiTietSach, cts);
                                //het update
                                LoadSanphamtoFl();
                            }
                            else
                            {
                                MessageBox.Show("Số lượng bạn nhập kho hàng không đáp ứng đủ, số lượng còn lại là:" + " " + cts.SoLuong);
                            }
                        }
                        else
                        {
                            HoaDonChiTiet hdct = new HoaDonChiTiet();
                            hdct = hoaDonChiTietService.GetAllloadformsp().FirstOrDefault(x => x.IdHoaDon == SelectID && x.IdChiTietSach == SelectIDSp);
                            hdct.SoLuong = data.SoLuong + Convert.ToInt32(Content);
                            hdct.ThanhTien = hdct.SoLuong * _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).Select(x => x.GiaBan).FirstOrDefault();
                            ChiTietSach cts = new ChiTietSach();
                            cts = _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).FirstOrDefault();
                            hdct.DonGia = Convert.ToInt32(cts.GiaBan);
                            if (cts.SoLuong > Convert.ToInt32(Content))//check so luong con lai
                            {
                                hoaDonChiTietService.Update(hdct);
                                //update so luong sach con lai
                                cts.IdSach = cts.IdSach;
                                cts.IdSach = cts.IdSach;
                                cts.IdNxb = cts.IdNxb;
                                cts.IdTacGia = cts.IdTacGia;
                                cts.IdNhaPhatHanh = cts.IdNhaPhatHanh;
                                cts.IdLoaiBia = cts.IdLoaiBia;
                                cts.Ma = cts.Ma;
                                cts.Anh = cts.Anh;
                                cts.MaVach = cts.MaVach;
                                cts.KichThuoc = cts.KichThuoc;
                                cts.SoTrang = cts.SoTrang;
                                cts.NamXuatBan = cts.NamXuatBan;
                                cts.MoTa = cts.MoTa;
                                cts.GiaNhap = cts.GiaNhap;
                                cts.GiaBan = cts.GiaBan;
                                cts.TrangThai = cts.TrangThai;
                                cts.SoLuong = cts.SoLuong - Convert.ToInt32(Content);
                                _iChiTietSachService.Update(hdct.IdChiTietSach, cts);
                                //het update
                                LoadSanphamtoFl();
                            }
                            else
                            {
                                MessageBox.Show("Số lượng bạn nhập kho hàng không đáp ứng đủ, số lượng còn lại là:" + " " + cts.SoLuong);
                            }
                        }
                    }
                    LoaddataToHoadonChitiet();
                    LoadHoaDonChiTiet();
                    LoadSanphamtoFl();
                }
                else if (DialogResult.No == hoi)
                {
                    return;
                }

            }
            else
            {
                var x = ((sender as Button).Tag as ChiTietSach).Id;
                SelectIDSp = x;
                HoaDon hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
                SelectID = hd.Id;
                if (hd.TrangThai == 0)
                {
                    HoaDonChiTiet data = hoaDonChiTietService.GetAllloadformsp().FirstOrDefault(x => x.IdChiTietSach == SelectIDSp && x.IdHoaDon == SelectID);
                    string ctsclick = _iChiTietSachService.GetAllChiTietSachView().FirstOrDefault(c => c.Id == x).Ma;
                    string tenclick = _iChiTietSachService.GetAllChiTietSachView().FirstOrDefault(c => c.Id == x).TenSach;
                    decimal giabanclick = Convert.ToDecimal(_iChiTietSachService.GetAllChiTietSachView().FirstOrDefault(c => c.Id == x).GiaBan);
                    string Content = Interaction.InputBox($"Mã: {ctsclick}" + Environment.NewLine + $"Tên: {tenclick}" + Environment.NewLine + $"Giá bán: {giabanclick}" + Environment.NewLine + "Nhập số lượng ", "Bạn muốn thêm bao nhiêu", "1", 500, 300);//nhập số lượng ở màn bán hàng
                    if (Content == string.Empty) return;

                    if (Regex.IsMatch(Content, @"^[a-zA-Z0-9 ]*$") == false)
                    {

                        MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                        return;
                    }
                    if (Regex.IsMatch(Content, @"^\d+$") == false)
                    {

                        MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                        return;
                    }
                    if (Content.Length > 6)
                    {
                        MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                        return;
                    }
                    if (Convert.ToInt32(Content) <= 0)
                    {
                        MessageBox.Show("Số Lượng Phải Lớn Hơn 0", "ERR");
                        return;
                    }
                    if (Content != null)
                    {
                        if (data == null)
                        {
                            HoaDonChiTiet hdct = new HoaDonChiTiet();
                            hdct.Id = Guid.NewGuid();
                            hdct.IdHoaDon = SelectID;
                            hdct.IdChiTietSach = SelectIDSp;
                            ChiTietSach cts = new ChiTietSach();
                            cts = _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).FirstOrDefault();
                            if (cts.SoLuong >= Convert.ToInt32(Content))
                            {
                                hdct.Ma = "HDCT" + Convert.ToString(hoaDonChiTietService.GetAllloadformsp()
                                  .Max(c => Convert.ToInt32(c.Ma.Substring(4, c.Ma.Length - 4)) + 1));
                                hdct.SoLuong = Convert.ToInt32(Content);
                                hdct.DonGia = Convert.ToInt32(cts.GiaBan);
                                hdct.ThanhTien = Convert.ToInt32(hdct.SoLuong * cts.GiaBan);
                                hoaDonChiTietService.Add(hdct);
                                //update số lượng còn lại 
                                cts.IdSach = cts.IdSach;
                                cts.IdSach = cts.IdSach;
                                cts.IdNxb = cts.IdNxb;
                                cts.IdTacGia = cts.IdTacGia;
                                cts.IdNhaPhatHanh = cts.IdNhaPhatHanh;
                                cts.IdLoaiBia = cts.IdLoaiBia;
                                cts.Ma = cts.Ma;
                                cts.Anh = cts.Anh;
                                cts.MaVach = cts.MaVach;
                                cts.KichThuoc = cts.KichThuoc;
                                cts.SoTrang = cts.SoTrang;
                                cts.NamXuatBan = cts.NamXuatBan;
                                cts.MoTa = cts.MoTa;
                                cts.GiaNhap = cts.GiaNhap;
                                cts.GiaBan = cts.GiaBan;
                                cts.TrangThai = cts.TrangThai;
                                cts.SoLuong = cts.SoLuong - Convert.ToInt32(Content);
                                _iChiTietSachService.Update(hdct.IdChiTietSach, cts);
                                //het update
                                LoadSanphamtoFl();
                            }
                            else
                            {
                                MessageBox.Show("Số lượng bạn nhập kho hàng không đáp ứng đủ, số lượng còn lại là:" + " " + cts.SoLuong);
                            }
                        }
                        else
                        {
                            HoaDonChiTiet hdct = new HoaDonChiTiet();
                            hdct = hoaDonChiTietService.GetAllloadformsp().FirstOrDefault(x => x.IdHoaDon == SelectID && x.IdChiTietSach == SelectIDSp);
                            hdct.SoLuong = data.SoLuong + Convert.ToInt32(Content);
                            hdct.ThanhTien = hdct.SoLuong * _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).Select(x => x.GiaBan).FirstOrDefault();
                            ChiTietSach cts = new ChiTietSach();
                            cts = _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).FirstOrDefault();
                            hdct.DonGia = Convert.ToInt32(cts.GiaBan);
                            if (cts.SoLuong > Convert.ToInt32(Content))//check so luong con lai
                            {
                                hoaDonChiTietService.Update(hdct);
                                //update so luong sach con lai
                                cts.IdSach = cts.IdSach;
                                cts.IdSach = cts.IdSach;
                                cts.IdNxb = cts.IdNxb;
                                cts.IdTacGia = cts.IdTacGia;
                                cts.IdNhaPhatHanh = cts.IdNhaPhatHanh;
                                cts.IdLoaiBia = cts.IdLoaiBia;
                                cts.Ma = cts.Ma;
                                cts.Anh = cts.Anh;
                                cts.MaVach = cts.MaVach;
                                cts.KichThuoc = cts.KichThuoc;
                                cts.SoTrang = cts.SoTrang;
                                cts.NamXuatBan = cts.NamXuatBan;
                                cts.MoTa = cts.MoTa;
                                cts.GiaNhap = cts.GiaNhap;
                                cts.GiaBan = cts.GiaBan;
                                cts.TrangThai = cts.TrangThai;
                                cts.SoLuong = cts.SoLuong - Convert.ToInt32(Content);
                                _iChiTietSachService.Update(hdct.IdChiTietSach, cts);
                                //het update
                                LoadSanphamtoFl();
                            }
                            else
                            {
                                MessageBox.Show("Số lượng bạn nhập kho hàng không đáp ứng đủ, số lượng còn lại là:" + " " + cts.SoLuong);
                            }
                        }
                    }
                    LoaddataToHoadonChitiet();
                    LoadHoaDonChiTiet();
                    LoadSanphamtoFl();
                    Tabhoadondcmm();
                }
                else if (hd.TrangThai == 1)
                {
                    AlertFail("Hóa đơn này đã được thanh toán");
                    return;
                }
                else if (hd.TrangThai == 2)
                {
                    AlertFail("Hóa đơn này đã thanh toán và chờ di chuyển");
                    return;
                }
                else if (hd.TrangThai == 3)
                {
                    AlertFail("Hóa đơn này đang giao");
                    return;
                }
            }
            LoaddataToHoadonChitiet();
        }
        public void LoadHoaDonDaThanhToan()
        {
            //try
            //{
            //    fl_DaThanhToan.Controls.Clear();
            //    foreach (var a in hoaDonService.GetAllHoaDon().Where(p => p.TrangThai == 1))
            //    {
            //        Button btn1 = new Button() { Width = 80, Height = 60 };
            //        btn1.Text = a.MaHd + Environment.NewLine + (a.TrangThai == 1 ? "Đã thanh toán" : "Chưa thanh toán");
            //        btn1.Tag = a;
            //        btn1.Click += btnsender_Click;
            //        btn1.ForeColor = Color.FromArgb(255, 114, 86);
            //        switch (a.TrangThai)
            //        {
            //            case 1:
            //                {
            //                    btn1.BackColor = Color.FromArgb(205, 201, 201);
            //                    break;
            //                }
            //        }
            //        fl_DaThanhToan.Controls.Add(btn1);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(Convert.ToString(ex), "Liên hệ");
            //    return;
            //}
        }
        private Image ByteToImg(string byteString)
        {
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        public Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        public void LoadSanphamtoFl()
        {

            fl_sanpham.Controls.Clear();
            foreach (var x in _iChiTietSachService.GetAll().OrderBy(x => x.Ma))
            {
                var Ten = _iChiTietSachService.GetAllChiTietSachView().Where(b => b.Id == x.Id).Select(c => c.TenSach).FirstOrDefault();
                Button btn1 = new Button() { Width = 260, Height = 180 };
                btn1.Text = x.Ma + Environment.NewLine + "Tên: " + Ten + Environment.NewLine + "Gía bán:" + x.GiaBan + Environment.NewLine + "Số lượng:" + x.SoLuong;
                btn1.ForeColor = System.Drawing.Color.FromArgb(1, 102, 207);
                btn1.BackColor = Color.FromArgb(228, 241, 240);
                btn1.TextAlign = ContentAlignment.MiddleLeft;
                Image img2 = byteArrayToImage(x.Anh);
                img2 = resizeImage(img2, new Size(80, 110));
                btn1.Image = img2;
                btn1.Tag = x;
                btn1.ImageAlign = ContentAlignment.MiddleRight;
                btn1.ForeColor = Color.Black;
                btn1.Click += btnsender_Click1;
                fl_sanpham.Controls.Add(btn1);
            }
            //Button btn2 = new Button() { Width = 200, Height = 150 };
            //btn2.Text = "+";
            //btn2.TextAlign = ContentAlignment.TopCenter;
            //btn2.Font = new Font(btn2.Font.FontFamily, 69);
            //btn2.Click += btnsender_click3;
            //fl_sanpham.Controls.Add(btn2);

        }
        private void btnsender_click3(object sender, EventArgs e)
        {
            Form form = new Form_ChiTietSach();
            form.ShowDialog();
            LoadSanphamtoFl();
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public void LoadHoaDonChoThanhToan()
        {

            fl_ChuaThanhToan.Controls.Clear();
            foreach (var a in hoaDonService.GetAllHoaDon().Where(p => p.TrangThai == 0).OrderBy(x => x.MaHd))
            {
                Button btn1 = new Button() { Width = 80, Height = 60 };
                btn1.Text = a.MaHd + Environment.NewLine + (a.TrangThai == 0 ? "Chờ thanh toán" : "Chưa thanh toán");
                btn1.Tag = a;
                btn1.Click += btnsender_Click;
                btn1.ForeColor = Color.FromArgb(224, 238, 224);
                switch (a.TrangThai)
                {
                    case 0:
                        {
                            btn1.BackColor = Color.FromArgb(238, 121, 159);
                            break;
                        }
                }
                fl_ChuaThanhToan.Controls.Add(btn1);
            }

        }
        public void LoadHoaDonChiTiet()
        {
        }

        private void btn_taohoadon_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn tạo hóa đơn chứ", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                tabHoaDon.Visible = true;
                TabPage tpage = new TabPage();
                tabHoaDon.TabPages.Add(tpage);
                HoaDon hd = new HoaDon();
                hd.Id = Guid.NewGuid();
                hd.MaHd = "HD" + Convert.ToString(hoaDonService.GetAllHoaDon().Max(c => Convert.ToInt32(c.MaHd.Substring(2, c.MaHd.Length - 2)) + 1));

                hd.Idnv = SelectNhanVien;
                //hd.Idkh = Guid.Parse("56303832-7163-464a-99a8-72973ed09c21");
                hd.NgayTao = DateTime.Now;
                MessageBox.Show(hoaDonService.Add(hd));
                tpage.Text = Convert.ToString(hd.MaHd);
                tpage.Name = Convert.ToString(hd.MaHd);
                tabHoaDon.SelectedIndex = tabHoaDon.TabCount - 1;
                LoaddataToTextbox(hd.Id);
                Tabhoadondcmm();
            }
            LoadHoaDonChoThanhToan();
        }
        public int Index { get; set; }
        public string NameIndex { get; set; }
        public string NameIndex1 { get; set; }
        private void tabHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabHoaDon.SelectedIndex >= 0)
            {

                //if (tabHoaDon.SelectedTab.Name != NameIndex1)
                //{
                //    HoaDon hd = new HoaDon();
                //    hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == NameIndex1);
                //    if (hd != null)
                //    {
                //        if (hd.TrangThai == 2 || hd.TrangThai == 3)
                //        {
                //            if (!string.IsNullOrEmpty(tb_tongtien.Text))
                //            {
                //                if (hd.TongTien != Convert.ToInt32(tb_tongtien.Text))
                //                {
                //                    AlertFail("Vui lòng cập nhật");
                //                    return;
                //                }
                //            }
                //        }
                //    }
                //}
                //NameIndex1 = tabHoaDon.SelectedTab.Name;
                if (tabHoaDon.SelectedTab.Name != NameIndex)
                {
                    //LoaddataToTextbox(hoaDonService.GetAllHoaDon().Where(x => x.MaHd == tabHoaDon.SelectedTab.Name).Select(x => x.Id).FirstOrDefault());
                    HoaDon hd = new HoaDon();
                    hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == NameIndex);
                    if (hd != null)
                    {
                        if (hd.TrangThai == 0)
                        {

                            if (hd.Idkh != _ikhachHangService.getKhachHangFromDB().Where(x => x.Ma == cbb_nganhang.SelectedItem).Select(x => x.ID).FirstOrDefault())
                            {
                                hd.Idnv = SelectNhanVien;
                                if (cbb_nganhang.SelectedIndex > 0)
                                {
                                    if (_ikhachHangService.getAll().Where(x=>x.Ma == cbb_nganhang.Text).Count()==1)
                                    {
                                        hd.Idkh = _ikhachHangService.getKhachHangFromDB().Where(x => x.Ma == cbb_nganhang.SelectedItem).Select(x => x.ID).FirstOrDefault();
                                    }
                                    
                                }
                                if (cbb_nganhang.SelectedIndex == 0)
                                {
                                    hd.Idkh = null;
                                }
                            }


                            if (!string.IsNullOrEmpty(tb_tongtienhang.Text))
                            {
                                hd.TongTien = Convert.ToInt32(tb_tongtienhang.Text);
                            }
                            hoaDonService.Update(hd);
                            Tabhoadondcmm();
                        }
                        else
                        {
                            Tabhoadondcmm();
                        }


                    }

                }

                Index = tabHoaDon.SelectedIndex;
                NameIndex = tabHoaDon.SelectedTab.Name;

            }
        }
        private void Tabhoadondcmm()
        {
            int a = tabHoaDon.TabCount;
            if (a >= 1)
            {
                lbdtghdct.Visible = false;
                lbdtghdct.Text = "";
                dtg_HoaDonChiTiet.Visible = true;
                LoaddataToHoadonChitiet();
            }
            else if (a < 1)
            {
                dtg_HoaDonChiTiet.Visible = false;
                lbdtghdct.Visible = true;
                lbdtghdct.Text = "Chưa có hóa đơn nào được chọn";
            }
        }
        private void Form_BanHang_Load(object sender, EventArgs e)
        {
            foreach (var x in _inhanvienService.getNhanViensFromDB().Where(x => x.TrangThai == 0))
            {
                cbb_nhanvien.Items.Add(x.Ma);
            }

            foreach (var x in _ikhachHangService.getKhachHangFromDB().Where(x => x.Trangthai == 1))
            {
                cbb_nganhang.Items.Add(x.Ma);
            }
            cbb_nganhang.Items.Insert(0, "");
            foreach (var x in _iphuongThucThanhToanService.GetAllNoView())
            {
                cbb_phuongthucthanhtoan.Items.Add(x.Ten);
            }
            cbb_phuongthucthanhtoan.DropDownStyle = ComboBoxStyle.DropDownList;
            fl_KhachHang.Visible = false;
            cbb_phuongthucthanhtoan.SelectedIndex = 2;
            //panel24.BackColor= Color.FromArgb(189, 189, 189);
            //panel2.BackColor = Color.FromArgb(102, 187, 106);
            //fl_sanpham.BackColor = Color.FromArgb(189, 189, 189);
            //panel5.BackColor = Color.FromArgb(102, 187, 106);
            //panel6.BackColor= Color.FromArgb(189, 189, 189);
            //panel4.BackColor = Color.FromArgb(189, 189, 189);
            //panel_tienmat.BackColor = Color.FromArgb(189, 189, 189);
            //panel_chuyenkhoan.BackColor = Color.FromArgb(189, 189, 189);
            //panel10.BackColor = Color.FromArgb(189, 189, 189);
            //panel25.BackColor = Color.FromArgb(189, 189, 189);
            //panel_thanhtoan.BackColor = Color.FromArgb(189, 189, 189);
            //panel_capnhat.BackColor = Color.FromArgb(189, 189, 189);
            //groupBox3.BackColor = Color.FromArgb(189, 189, 189);
            //button4.BackColor = Color.FromArgb(102, 187, 106);
            //dtg_HoaDonChiTiet.BackgroundColor = Color.FromArgb(189, 189, 189);
        }

        private void dtg_HoaDonChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtg_HoaDonChiTiet.Columns["tru"].Index)
            {
                HoaDon hd = new HoaDon();
                hd = hoaDonService.GetAllHoaDon().Where(z => z.MaHd == tabHoaDon.SelectedTab.Name).FirstOrDefault();
                if (hd.TrangThai == 0)
                {
                    HoaDonChiTiet hdct = new HoaDonChiTiet();
                    Guid id = Guid.Parse(dtg_HoaDonChiTiet.CurrentRow.Cells[0].Value.ToString());
                    hdct = hoaDonChiTietService.GetAllloadformsp().FirstOrDefault(x => x.Id == id);

                    if (hdct.SoLuong == 1)
                    {
                        DialogResult hoi = MessageBox.Show("Bạn có muốn xóa sản phẩm khỏi giỏ hàng hay không", "Xóa sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (hoi == DialogResult.Yes)
                        {
                            hoaDonChiTietService.Remove(hdct);
                            // cộng lại số lượng vào sp 
                            ChiTietSach cts = new ChiTietSach();
                            cts = _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).FirstOrDefault();
                            cts.IdSach = cts.IdSach;
                            cts.IdSach = cts.IdSach;
                            cts.IdNxb = cts.IdNxb;
                            cts.IdTacGia = cts.IdTacGia;
                            cts.IdNhaPhatHanh = cts.IdNhaPhatHanh;
                            cts.IdLoaiBia = cts.IdLoaiBia;
                            cts.Ma = cts.Ma;
                            cts.Anh = cts.Anh;
                            cts.MaVach = cts.MaVach;
                            cts.KichThuoc = cts.KichThuoc;
                            cts.SoTrang = cts.SoTrang;
                            cts.NamXuatBan = cts.NamXuatBan;
                            cts.MoTa = cts.MoTa;
                            cts.GiaNhap = cts.GiaNhap;
                            cts.GiaBan = cts.GiaBan;
                            cts.TrangThai = cts.TrangThai;
                            cts.SoLuong = cts.SoLuong + 1;
                            _iChiTietSachService.Update(hdct.IdChiTietSach, cts);
                            //loadhdct
                            string a = tabHoaDon.SelectedTab.Text;
                            SelectID = hoaDonService.GetAllHoaDon().Where(x => x.MaHd == a).Select(x => x.Id).FirstOrDefault();
                            dtg_HoaDonChiTiet.Rows.Clear();
                            foreach (var x in hoaDonChiTietService.GetAll().Where(x => x.IDhoadon == SelectID))
                            {
                                dtg_HoaDonChiTiet.Rows.Add(x.ID, x.MactSach, x.Tensach, "-", x.Soluong, "+", x.Dongia, x.Thanhtien, "X");
                            }
                            LoadSanphamtoFl();
                        }
                    }
                    else
                    {
                        hdct.SoLuong = hdct.SoLuong - 1;
                        hdct.ThanhTien = hdct.SoLuong * hdct.DonGia;
                        hoaDonChiTietService.Update(hdct);
                        // cộng lại số lượng vào sp 
                        ChiTietSach cts = new ChiTietSach();
                        cts = _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).FirstOrDefault();
                        cts.IdSach = cts.IdSach;
                        cts.IdSach = cts.IdSach;
                        cts.IdNxb = cts.IdNxb;
                        cts.IdTacGia = cts.IdTacGia;
                        cts.IdNhaPhatHanh = cts.IdNhaPhatHanh;
                        cts.IdLoaiBia = cts.IdLoaiBia;
                        cts.Ma = cts.Ma;
                        cts.Anh = cts.Anh;
                        cts.MaVach = cts.MaVach;
                        cts.KichThuoc = cts.KichThuoc;
                        cts.SoTrang = cts.SoTrang;
                        cts.NamXuatBan = cts.NamXuatBan;
                        cts.MoTa = cts.MoTa;
                        cts.GiaNhap = cts.GiaNhap;
                        cts.GiaBan = cts.GiaBan;
                        cts.TrangThai = cts.TrangThai;
                        cts.SoLuong = cts.SoLuong + 1;
                        _iChiTietSachService.Update(hdct.IdChiTietSach, cts);
                        //loadhdct
                        LoaddataToHoadonChitiet();
                        LoadSanphamtoFl();
                    }
                    LoadSanphamtoFl();
                }
                else if (hd.TrangThai == 1)
                {
                    AlertFail("Hóa đơn này đã được thanh toán");
                    return;
                }
                else if (hd.TrangThai == 2)
                {
                    AlertFail("Hóa đơn này đã thanh toán và chờ di chuyển");
                    return;
                }
                else if (hd.TrangThai == 3)
                {
                    AlertFail("Hóa đơn này đang giao");
                    return;
                }
            }
            if (e.ColumnIndex == dtg_HoaDonChiTiet.Columns["Cong"].Index)
            {
                HoaDon hd = new HoaDon();
                hd = hoaDonService.GetAllHoaDon().Where(x => x.MaHd == tabHoaDon.SelectedTab.Name).FirstOrDefault();
                if (hd.TrangThai == 0)
                {

                    {
                        HoaDonChiTiet hdct = new HoaDonChiTiet();
                        Guid id = Guid.Parse(dtg_HoaDonChiTiet.CurrentRow.Cells[0].Value.ToString());
                        hdct = hoaDonChiTietService.GetAllloadformsp().FirstOrDefault(x => x.Id == id);
                        ChiTietSach cts = new ChiTietSach();
                        cts = _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).FirstOrDefault();
                        //
                        if (cts.SoLuong == 0)
                        {
                            MessageBox.Show("Số lượng sản phẩm trong kho đã hết!");
                            return;
                        }
                        else
                        {
                            hdct.SoLuong = hdct.SoLuong + 1;
                            hdct.ThanhTien = hdct.SoLuong * hdct.DonGia;
                            hoaDonChiTietService.Update(hdct);
                            // cộng lại số lượng vào sp                    
                            cts.IdSach = cts.IdSach;
                            cts.IdSach = cts.IdSach;
                            cts.IdNxb = cts.IdNxb;
                            cts.IdTacGia = cts.IdTacGia;
                            cts.IdNhaPhatHanh = cts.IdNhaPhatHanh;
                            cts.IdLoaiBia = cts.IdLoaiBia;
                            cts.Ma = cts.Ma;
                            cts.Anh = cts.Anh;
                            cts.MaVach = cts.MaVach;
                            cts.KichThuoc = cts.KichThuoc;
                            cts.SoTrang = cts.SoTrang;
                            cts.NamXuatBan = cts.NamXuatBan;
                            cts.MoTa = cts.MoTa;
                            cts.GiaNhap = cts.GiaNhap;
                            cts.GiaBan = cts.GiaBan;
                            cts.TrangThai = cts.TrangThai;
                            cts.SoLuong = cts.SoLuong - 1;
                            _iChiTietSachService.Update(hdct.IdChiTietSach, cts);

                            //loadhdct
                            LoaddataToHoadonChitiet();
                            LoadSanphamtoFl();
                        }
                        LoadSanphamtoFl();
                    }
                }
                else if (hd.TrangThai == 1)
                {
                    AlertFail("Hóa đơn này đã được thanh toán");
                    return;
                }
                else if (hd.TrangThai == 2)
                {
                    AlertFail("Hóa đơn này đã thanh toán và chờ di chuyển");
                    return;
                }
                else if (hd.TrangThai == 3)
                {
                    AlertFail("Hóa đơn này đang giao");
                    return;
                }
            }
            if (e.ColumnIndex == dtg_HoaDonChiTiet.Columns["Xoa"].Index)
            {
                HoaDon hd = new HoaDon();
                hd = hoaDonService.GetAllHoaDon().Where(x => x.MaHd == tabHoaDon.SelectedTab.Name).FirstOrDefault();
                if (hd.TrangThai == 0)
                {

                    {
                        HoaDonChiTiet hdct = new HoaDonChiTiet();
                        Guid id = Guid.Parse(dtg_HoaDonChiTiet.CurrentRow.Cells[0].Value.ToString());
                        hdct = hoaDonChiTietService.GetAllloadformsp().FirstOrDefault(x => x.Id == id);
                        ChiTietSach cts = new ChiTietSach();
                        cts = _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).FirstOrDefault();
                        DialogResult hoi = MessageBox.Show("Bạn có muốn xóa hay không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult.Yes == hoi)
                        {

                            cts.IdSach = cts.IdSach;
                            cts.IdSach = cts.IdSach;
                            cts.IdNxb = cts.IdNxb;
                            cts.IdTacGia = cts.IdTacGia;
                            cts.IdNhaPhatHanh = cts.IdNhaPhatHanh;
                            cts.IdLoaiBia = cts.IdLoaiBia;
                            cts.Ma = cts.Ma;
                            cts.Anh = cts.Anh;
                            cts.MaVach = cts.MaVach;
                            cts.KichThuoc = cts.KichThuoc;
                            cts.SoTrang = cts.SoTrang;
                            cts.NamXuatBan = cts.NamXuatBan;
                            cts.MoTa = cts.MoTa;
                            cts.GiaNhap = cts.GiaNhap;
                            cts.GiaBan = cts.GiaBan;
                            cts.TrangThai = cts.TrangThai;
                            cts.SoLuong = cts.SoLuong + hdct.SoLuong;
                            _iChiTietSachService.Update(hdct.IdChiTietSach, cts);
                            hoaDonChiTietService.Remove(hdct);

                        }
                        LoadSanphamtoFl();
                        LoaddataToHoadonChitiet();
                        Tabhoadondcmm();
                    }
                }
                else if (hd.TrangThai == 1)
                {
                    AlertFail("Hóa đơn này đã được thanh toán");
                    return;
                }
                else if (hd.TrangThai == 2)
                {
                    AlertFail("Hóa đơn này đã thanh toán và chờ di chuyển");
                    return;
                }
                else if (hd.TrangThai == 3)
                {
                    AlertFail("Hóa đơn này đang giao");
                    return;
                }
            }

        }

        private void tabHoaDon_MouseClick(object sender, MouseEventArgs e)
        {

            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                if (tabHoaDon.TabCount > 1)
                {
                    tabHoaDon.TabPages.Remove(tabHoaDon.SelectedTab);
                    tabHoaDon.SelectedIndex = 0;
                }
                else
                {
                    tabHoaDon.TabPages.Remove(tabHoaDon.SelectedTab);
                    tabHoaDon.SelectedIndex = -1;
                    tabHoaDon.Visible = false;
                    // clearform
                    cbb_nhanvien.SelectedIndex = -1;
                    cbb_nganhang.SelectedIndex = -1;
                    cleartextbox();
                }
                Tabhoadondcmm();
            }
        }
        private void cleartextbox()
        {
            tb_vidiem.Clear();
            tb_dungdiem.Clear();
            cbb_nganhang.SelectedIndex = -1;
            tb_tongtien.Clear();
            cbb_phuongthucthanhtoan.SelectedIndex = -1;
            tb_tientralai.Clear();
            tbx_TienCoc.Clear();
            tbx_TienShip.Clear();
            tb_dungdiem.Clear();
            tb_tienmat.Clear();
            tb_chuyenkhoan.Clear();
            tb_tongtienhang.Clear();
            tb_diachi.Clear();
            cbb_nhanvien.SelectedIndex = -1;
            tb_ghichu.Clear();
            tb_sodienthoai.Clear();
            tb_nguoinhan.Clear();
        }
        private void LoaddataToTextbox(Guid id)
        {
            //  HoaDon hd = new HoaDon();
            var hd = hoaDonService.GetAllHoaDon().Where(x => x.Id == id).FirstOrDefault();
            cbb_nhanvien.SelectedItem = _inhanvienService.getNhanViensFromDB().Where(x => x.Id == hd.Idnv).Select(x => x.Ma).FirstOrDefault();
            /*khach hang*/
            var kh = _ikhachHangService.getAll().Where(x => x.Id == hd.Idkh).FirstOrDefault();
            if (hd.Idkh != null)
            {
                cbb_nganhang.SelectedItem = _ikhachHangService.getAll().Where(x => x.Id == hd.Idkh).Select(x => x.Ma).FirstOrDefault();
                tb_vidiem.Text = Convert.ToString(_idiemTieuDungService.GetAll().Where(x => x.Id == kh.IddiemTieuDung).Select(x => x.SoDiem).FirstOrDefault());
            }
            else if (hd.Idkh == null)
            {
                cbb_nganhang.SelectedIndex = 0;
                fl_KhachHang.Visible = false;
            }

            if (hd.IddiemDung != null)
            {
                tb_dungdiem.Text = Convert.ToString(_ilichSuDiemDungService.GetAll().Where(x => x.Id == hd.IddiemDung).Select(x => x.SoDiemDung).FirstOrDefault());
                // tb_tongtien.Text = Convert.ToString(hd.TongTien);
                CongThucTinhDiem cttd = new CongThucTinhDiem();
                cttd = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT1").FirstOrDefault();
                tb_diemquydoi.Text = Convert.ToString(Convert.ToInt32(cttd.HeSo) * Convert.ToInt32(tb_dungdiem.Text));
            }
            int count = 0;
            foreach (var x in hoaDonChiTietService.GetAllloadformsp().Where(x => x.IdHoaDon == id))
            {
                count = count + Convert.ToInt32(x.ThanhTien);
            }
            tb_tongtienhang.Text = Convert.ToString(count);
            tbx_TienCoc.Text = Convert.ToString(hd.TienCoc);
            tbx_TienShip.Text = Convert.ToString(hd.TienShip);
            tb_diachi.Text = Convert.ToString(hd.DiaChi);

            if (hd.TrangThai == 0)
            {
                tb_tongtien.Text = tb_tongtienhang.Text;
            }
            else if (hd.TrangThai != 0)
            {
                tb_tongtien.Text = Convert.ToString(hd.TongTien);
            }
            tbt_MaHD.Text = hd.MaHd;
            if (hd.TrangThai != null)
            {
                if (hd.TrangThai == 2)
                {
                    rd_chogiao.Checked = true;
                }
                else if (hd.TrangThai == 3)
                {
                    rd_danggiao.Checked = true;
                }
                else if (hd.TrangThai == 1)
                {
                    rd_dathanhtoan.Checked = true;
                }
                else if (hd.TrangThai == 0)
                {
                    rd_chothanhtoan.Checked = true;
                }
            }
            if (hd.TienCoc == null)
            {
                if (hd.TienMat != null && hd.TienChuyenKhoan == null)
                {
                    cbb_phuongthucthanhtoan.SelectedIndex = 0;
                    tb_tienmat.Text = Convert.ToString(hd.TienMat);
                    tb_tientralai.Text = Convert.ToString(hd.TienMat - hd.TongTien);
                }
                else if (hd.TienMat == null && hd.TienChuyenKhoan != null)
                {
                    cbb_phuongthucthanhtoan.SelectedIndex = 1;
                    tb_chuyenkhoan.Text = Convert.ToString(hd.TienChuyenKhoan);
                    tb_tientralai.Text = Convert.ToString(hd.TienChuyenKhoan - hd.TongTien);
                }
                else if (hd.TienMat != null && hd.TienChuyenKhoan != null)
                {
                    cbb_phuongthucthanhtoan.SelectedIndex = 2;
                    tb_chuyenkhoan.Text = Convert.ToString(hd.TienChuyenKhoan);
                    tb_tienmat.Text = Convert.ToString(hd.TienMat);
                    tb_tientralai.Text = Convert.ToString(hd.TienMat + hd.TienChuyenKhoan - hd.TongTien);
                }
            }
            else
            {
                if (hd.TienMat != null && hd.TienChuyenKhoan == null)
                {
                    cbb_phuongthucthanhtoan.SelectedIndex = 0;
                    tb_tienmat.Text = Convert.ToString(hd.TienMat);
                    tb_tientralai.Text = Convert.ToString(hd.TienMat - hd.TongTien + hd.TienCoc - hd.TienShip);
                }
                else if (hd.TienMat == null && hd.TienChuyenKhoan != null)
                {
                    cbb_phuongthucthanhtoan.SelectedIndex = 1;
                    tb_tienmat.Text = Convert.ToString(hd.TienChuyenKhoan);
                    tb_tientralai.Text = Convert.ToString(hd.TienChuyenKhoan - hd.TongTien + hd.TienCoc - hd.TienShip);
                }
                else if (hd.TienMat != null && hd.TienChuyenKhoan != null)
                {
                    cbb_phuongthucthanhtoan.SelectedIndex = 2;
                    tb_chuyenkhoan.Text = Convert.ToString(hd.TienChuyenKhoan);
                    tb_tienmat.Text = Convert.ToString(hd.TienMat);
                    tb_tientralai.Text = Convert.ToString(hd.TienMat + hd.TienChuyenKhoan - hd.TongTien + hd.TienCoc - hd.TienShip);
                }
            }



            if (hd.TrangThai != 0)
            {
                tb_dungdiem.ReadOnly = true;
                tb_tienmat.ReadOnly = true;
                tb_chuyenkhoan.ReadOnly = true;
                tbx_TienCoc.ReadOnly = true;
                tbx_TienShip.ReadOnly = true;
                tb_diachi.ReadOnly = true;
                cbb_nganhang.Enabled = false;
                cbb_phuongthucthanhtoan.Enabled = false;
                cbb_nhanvien.Enabled = false;
            }
            else
            {
                cbb_nhanvien.Enabled = false;
                tb_dungdiem.ReadOnly = false;
                tb_tienmat.ReadOnly = false;
                tb_chuyenkhoan.ReadOnly = false;
                tbx_TienCoc.ReadOnly = false;
                tbx_TienShip.ReadOnly = false;
                tb_diachi.ReadOnly = false;
                cbb_nganhang.Enabled = true;
                cbb_phuongthucthanhtoan.Enabled = true;
            }
            if (hd.TrangThai == 1)
            {
                tb_diachi.ReadOnly = true;
            }
            else
            {
                tb_diachi.ReadOnly = false;
            }
           
                tb_ghichu.Text = hd.GhiChu;
            
            dtp_ngaytao.Value = Convert.ToDateTime(hd.NgayTao);
            tb_diachi.Text = hd.DiaChi;
            tb_sodienthoai.Text = hd.SdtNguoiNhan;
            tb_nguoinhan.Text = hd.TenNguoiNhan;
        }

        private void cb_dungdiem_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_dungdiem.Checked == true)
            {
                if (cbb_nganhang.SelectedIndex <= 0)
                {
                    tb_dungdiem.ReadOnly = true;
                    tb_dungdiem.Clear();
                }
                else
                {
                    tb_dungdiem.ReadOnly = false;
                }

            }
            else
            {
                tb_dungdiem.ReadOnly = true;
                tb_diemquydoi.Clear();
                tb_tongtien.Text = tb_tongtienhang.Text;
            }

        }

        private void bt_thanhtoan_Click(object sender, EventArgs e)
        {
            if (dtg_HoaDonChiTiet.Visible == false)
            {
                AlertFail("Vui lòng chọn hóa đơn cần thanh toán");
                return;
            }
            else if (hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name).TrangThai != 0)
            {
                AlertFail("Hóa đơn này đã được thanh toán trước đó");
                return;
            }
            //else if (cbb_nhanvien.SelectedIndex < 0)
            //{
            //    AlertFail("Vui lòng thêm nhân viên");
            //    return;
            //}
            else if (tb_tongtienhang.Text == "0")
            {
                AlertFail("Hóa đơn chưa có sản phẩm");
                return;
            }
            else if (cbb_phuongthucthanhtoan.SelectedIndex < 0)
            {
                AlertFail("Vui lòng chọn phương thức thanh toán");
                return;
            }
            else
            {
                BanTaiQuay();
            }
            //InHoaDon();
        }
        private void BanTaiQuay()
        {
            HoaDon hd = new HoaDon();
            LichSuDiemDung lichsudiemdung = new LichSuDiemDung();
            LichSuDiemTich lichSuDiemTich = new LichSuDiemTich();
            DiemTieuDung diemtieudung = new DiemTieuDung();
            CongThucTinhDiem cttd1, cttd2 = new CongThucTinhDiem();
            cttd1 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT1").FirstOrDefault();
            cttd2 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT2").FirstOrDefault();
            hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            //Khách hàng
            KhachHang kh = new KhachHang();

            if (!string.IsNullOrEmpty(tb_vidiem.Text))
            {
                //k/*h = _ikhachHangService.getAll().FirstOrDefault(x => x.Id == _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault());*/
                kh = _ikhachHangService.getAll().Where(x => x.Ma == cbb_nganhang.SelectedItem).FirstOrDefault();

                lichsudiemdung.SoDiemDung = 0;
                if (cbb_phuongthucthanhtoan.SelectedIndex == 0)
                {
                    if (string.IsNullOrEmpty(tb_tienmat.Text))
                    {
                        AlertFail("Vui lòng nhập số tiền");
                        return;

                    }
                    else if (Convert.ToInt32(tb_tientralai.Text) < 0)
                    {
                        AlertFail("Số tiền chưa thỏa mãn");
                        return;
                    }
                    else
                    {
                        hd.TienMat = Convert.ToInt32(tb_tienmat.Text);
                    }

                }
                else if (cbb_phuongthucthanhtoan.SelectedIndex == 1)
                {
                    if (string.IsNullOrEmpty(tb_chuyenkhoan.Text))
                    {
                        AlertFail("Vui lòng nhập số tiền");
                        return;
                    }
                    else if (Convert.ToInt32(tb_tientralai.Text) < 0)
                    {
                        AlertFail("Số tiền chưa thỏa mãn");
                        return;
                    }
                    else
                    {
                        hd.TienChuyenKhoan = Convert.ToInt32(tb_chuyenkhoan.Text);
                    }

                }
                else if (cbb_phuongthucthanhtoan.SelectedIndex == 2)
                {
                    if (string.IsNullOrEmpty(tb_chuyenkhoan.Text))
                    {
                        AlertFail("Vui lòng nhập số tiền");
                        return;
                    }
                    else if (string.IsNullOrEmpty(tb_tienmat.Text))
                    {
                        AlertFail("Vui lòng nhập số tiền");
                        return;
                    }
                    else if (Convert.ToInt32(tb_tientralai.Text) < 0)
                    {
                        AlertFail("Số tiền chưa thỏa mãn");
                        return;
                    }

                    else
                    {
                        hd.TienMat = Convert.ToInt32(tb_tienmat.Text);
                        hd.TienChuyenKhoan = Convert.ToInt32(tb_chuyenkhoan.Text);
                    }
                }
                if (cb_dungdiem.Checked == true && !String.IsNullOrEmpty(tb_dungdiem.Text))
                {

                    // lish sử điểm dùng
                    lichsudiemdung.Id = Guid.NewGuid();
                    lichsudiemdung.IddiemTieuDung = kh.IddiemTieuDung;
                    lichsudiemdung.Ma = "LSD" + Convert.ToString(_ilichSuDiemTichService.GetAll()
                              .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
                    lichsudiemdung.SoDiemDung = Convert.ToInt32(tb_dungdiem.Text);
                    lichsudiemdung.NgaySuDung = DateTime.Now;
                    lichsudiemdung.TongTien = Convert.ToInt32(tb_diemquydoi.Text);
                    lichsudiemdung.TrangThai = 1;
                    _ilichSuDiemDungService.Add(lichsudiemdung);
                    hd.IddiemDung = lichsudiemdung.Id;
                }
                var cahientai = _igiaocaservice.GetAll().FirstOrDefault(c => c.Ma == "GC" + _igiaocaservice.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString());
                if (cahientai.TongTienTrongCa<Convert.ToInt32(tb_tientralai.Text))
                {
                    AlertFail("Không đủ tiền trả lại");
                    return;
                }
                lichSuDiemTich.Id = Guid.NewGuid();
                lichSuDiemTich.IddiemTieuDung = kh.IddiemTieuDung;
                lichSuDiemTich.Ma = "LST" + Convert.ToString(_ilichSuDiemTichService.GetAll()
                          .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
                lichSuDiemTich.SoDiemTich = Convert.ToInt32(tb_tongtien.Text) / Convert.ToInt32(cttd2.HeSo);
                lichSuDiemTich.NgaySuDung = DateTime.Now;
                lichSuDiemTich.TongTien = Convert.ToInt32(tb_tongtien.Text);
                lichSuDiemTich.TrangThai = 1;
                _ilichSuDiemTichService.Add(lichSuDiemTich);
                DiemTieuDung dtd = new DiemTieuDung();
                dtd = _idiemTieuDungService.GetAll().FirstOrDefault(z => z.Id == kh.IddiemTieuDung);
                dtd.SoDiem = dtd.SoDiem - Convert.ToInt32(lichsudiemdung.SoDiemDung) + Convert.ToInt32(lichSuDiemTich.SoDiemTich);
                _idiemTieuDungService.Update(dtd);


                hd.Id = hd.Id;
                hd.MaHd = tabHoaDon.SelectedTab.Name;
                hd.Idnv = SelectNhanVien;
                hd.Idkh = _ikhachHangService.getAll().Where(c => c.Ma == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault();
                hd.IddiemTich = lichSuDiemTich.Id;
                hd.IdphuongThucThanhToan = _iphuongThucThanhToanService.GetAllNoView().Where(x => x.Ten == cbb_phuongthucthanhtoan.SelectedItem).Select(x => x.Id).FirstOrDefault();
                hd.TongTien = Convert.ToInt32(tb_tongtien.Text);
                if (!string.IsNullOrEmpty(tb_diachi.Text))
                {
                    hd.GhiChu = tb_diachi.Text;
                }
                hd.TrangThai = 1; // hóa đơn đã thanh toán
                hoaDonService.Update(hd);
                InHoaDonTaiQuay();
                GiaoCa gc = new GiaoCa();
                 cahientai = _igiaocaservice.GetAll().FirstOrDefault(c => c.Ma == "GC" + _igiaocaservice.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString());
                gc.Id = cahientai.Id;
                gc.TongTienMat = cahientai.TongTienMat + Convert.ToDecimal(tb_tienmat.Text == string.Empty ? 0 : tb_tienmat.Text) - Convert.ToDecimal(tb_tientralai.Text);
                gc.TongTienKhac = cahientai.TongTienKhac + Convert.ToDecimal(tb_chuyenkhoan.Text == string.Empty ? 0 : tb_chuyenkhoan.Text);
                gc.TongTienTrongCa = cahientai.TongTienTrongCa + Convert.ToDecimal(tb_tienmat.Text == string.Empty ? 0 : tb_tienmat.Text) - Convert.ToDecimal(tb_tientralai.Text);
                _igiaocaservice.Update(gc);
                AlertSuccess("Thanh toán thành công");
            }
            else
            {
                if (cbb_phuongthucthanhtoan.SelectedIndex == 0)
                {
                    if (string.IsNullOrEmpty(tb_tienmat.Text))
                    {
                        AlertFail("Vui lòng nhập số tiền");
                        return;

                    }
                    else if (Convert.ToInt32(tb_tientralai.Text) < 0)
                    {
                        AlertFail("Số tiền chưa thỏa mãn");
                        return;
                    }
                    else
                    {
                        hd.TienMat = Convert.ToInt32(tb_tienmat.Text);
                    }

                }
                else if (cbb_phuongthucthanhtoan.SelectedIndex == 1)
                {
                    if (string.IsNullOrEmpty(tb_chuyenkhoan.Text))
                    {
                        AlertFail("Vui lòng nhập số tiền");
                        return;
                    }
                    else if (Convert.ToInt32(tb_tientralai.Text) < 0)
                    {
                        AlertFail("Số tiền chưa thỏa mãn");
                        return;
                    }
                    else
                    {
                        hd.TienChuyenKhoan = Convert.ToInt32(tb_chuyenkhoan.Text);
                    }

                }
                else if (cbb_phuongthucthanhtoan.SelectedIndex == 2)
                {
                    if (string.IsNullOrEmpty(tb_chuyenkhoan.Text))
                    {
                        AlertFail("Vui lòng nhập số tiền");
                        return;
                    }
                    else if (string.IsNullOrEmpty(tb_tienmat.Text))
                    {
                        AlertFail("Vui lòng nhập số tiền");
                        return;
                    }
                    else if (Convert.ToInt32(tb_tientralai.Text) < 0)
                    {
                        AlertFail("Số tiền chưa thỏa mãn");
                        return;
                    }
                    else
                    {
                        hd.TienMat = Convert.ToInt32(tb_tienmat.Text);
                        hd.TienChuyenKhoan = Convert.ToInt32(tb_chuyenkhoan.Text);
                    }
                }
                var cahientai = _igiaocaservice.GetAll().FirstOrDefault(c => c.Ma == "GC" + _igiaocaservice.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString());
                if (cahientai.TongTienTrongCa < Convert.ToInt32(tb_tientralai.Text))
                {
                    AlertFail("Không đủ tiền trả lại");
                    return;
                }
                //hóa đơn

                hd.Id = hd.Id;
                hd.MaHd = tabHoaDon.SelectedTab.Name;
                hd.Idnv = SelectNhanVien;
                hd.Idkh = null;
                hd.IdphuongThucThanhToan = _iphuongThucThanhToanService.GetAllNoView().Where(x => x.Ten == cbb_phuongthucthanhtoan.SelectedItem).Select(x => x.Id).FirstOrDefault();
                hd.TongTien = Convert.ToInt32(tb_tongtien.Text);
                if (!string.IsNullOrEmpty(tb_diachi.Text))
                {
                    hd.GhiChu = tb_diachi.Text;
                }
                hd.TrangThai = 1; // hóa đơn đã thanh toán
                hoaDonService.Update(hd);
                InHoaDonTaiQuay();
                GiaoCa gc = new GiaoCa();
                 cahientai = _igiaocaservice.GetAll().FirstOrDefault(c => c.Ma == "GC" + _igiaocaservice.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString());
                gc.Id = cahientai.Id;
                gc.TongTienMat = cahientai.TongTienMat + Convert.ToDecimal(tb_tienmat.Text == string.Empty ? 0 : tb_tienmat.Text) - Convert.ToDecimal(tb_tientralai.Text);
                gc.TongTienKhac = cahientai.TongTienKhac + Convert.ToDecimal(tb_chuyenkhoan.Text == string.Empty ? 0 : tb_chuyenkhoan.Text);
                gc.TongTienTrongCa = cahientai.TongTienTrongCa + Convert.ToDecimal(tb_tienmat.Text == string.Empty ? 0 : tb_tienmat.Text) - Convert.ToDecimal(tb_tientralai.Text);
                _igiaocaservice.Update(gc);
                AlertSuccess("Thanh toán thành công");
            }


            LoadHoaDonChoThanhToan();
            LoadHoaDonDaThanhToan();
            Tabhoadondcmm();
        }
        private void bt_capnhat_Click(object sender, EventArgs e)
        {
            if (dtg_HoaDonChiTiet.Visible == false)
            {
                AlertFail("Vui lòng chọn hóa đơn cần thanh toán");
                return;
            }
            else if (hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name).TrangThai == 1)
            {
                AlertFail("Hóa đơn này đã được thanh toán trước đó");
                return;
            }
            //else if (cbb_nhanvien.SelectedIndex < 0)
            //{
            //    AlertFail("Vui lòng thêm nhân viên");
            //    return;
            //}
            else if (tb_tongtienhang.Text == "0")
            {
                AlertFail("Hóa đơn chưa có sản phẩm");
                return;
            }
            else if (cbb_phuongthucthanhtoan.SelectedIndex < 0)
            {
                AlertFail("Vui lòng chọn phương thức thanh toán");
                return;
            }
            else if (hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name).TrangThai != 1)
            {
                BanShipHang();
                return;
            }

        }
        private void CapnhatTrangthaihoadon()
        {

            HoaDon hd = new HoaDon();
            LichSuDiemDung lichsudiemdung = new LichSuDiemDung();
            LichSuDiemTich lichSuDiemTich = new LichSuDiemTich();
            DiemTieuDung diemtieudung = new DiemTieuDung();
            CongThucTinhDiem cttd1, cttd2 = new CongThucTinhDiem();
            cttd1 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT1").FirstOrDefault();
            cttd2 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT2").FirstOrDefault();
            hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            //Khách hàng
            KhachHang kh = new KhachHang();
            if (hd.Idkh != null)
            {
                kh = _ikhachHangService.getAll().Where(x => x.Id == hd.Idkh).FirstOrDefault();

                if (hd.IddiemDung != null)
                {
                    lichsudiemdung = _ilichSuDiemDungService.GetAll().Where(x => x.Id == hd.IddiemDung).FirstOrDefault();
                    lichSuDiemTich = _ilichSuDiemTichService.GetAll().Where(x => x.Id == hd.IddiemTich).FirstOrDefault();
                    diemtieudung = _idiemTieuDungService.GetAll().Where(x => x.Id == kh.IddiemTieuDung).FirstOrDefault();
                    diemtieudung.SoDiem = diemtieudung.SoDiem + lichsudiemdung.SoDiemDung - lichSuDiemTich.SoDiemTich;
                    _idiemTieuDungService.Update(diemtieudung);
                    _ilichSuDiemDungService.Remove(lichsudiemdung);
                    _ilichSuDiemTichService.Remove(lichSuDiemTich);
                }
                else if (hd.IddiemDung == null)
                {
                    lichSuDiemTich = _ilichSuDiemTichService.GetAll().Where(x => x.Id == hd.IddiemTich).FirstOrDefault();
                    diemtieudung = _idiemTieuDungService.GetAll().Where(x => x.Id == kh.IddiemTieuDung).FirstOrDefault();
                    diemtieudung.SoDiem = diemtieudung.SoDiem - lichSuDiemTich.SoDiemTich;
                    _idiemTieuDungService.Update(diemtieudung);
                    _ilichSuDiemTichService.Remove(lichSuDiemTich);
                }
            }
            else if (hd.Idkh == null)
            {

            }

            LoadHoaDonChoThanhToan();
            LoadHoaDonDaThanhToan();
            cbx_Loc.SelectedIndex = 1;



        }
        private void BanShipHang()
        {
            HoaDon hd = new HoaDon();
            LichSuDiemDung lichsudiemdung = new LichSuDiemDung();
            LichSuDiemTich lichSuDiemTich = new LichSuDiemTich();
            DiemTieuDung diemtieudung = new DiemTieuDung();
            CongThucTinhDiem cttd1, cttd2 = new CongThucTinhDiem();
            cttd1 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT1").FirstOrDefault();
            cttd2 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT2").FirstOrDefault();
            hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            //Khách hàng
            KhachHang kh = new KhachHang();

            if (hd.TrangThai == 0)
            {
                if (!string.IsNullOrEmpty(tb_vidiem.Text))
                {
                    //k/*h = _ikhachHangService.getAll().FirstOrDefault(x => x.Id == _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault());*/
                    kh = _ikhachHangService.getAll().Where(x => x.Ma == cbb_nganhang.SelectedItem).FirstOrDefault();
                    if (string.IsNullOrEmpty(tb_ghichu.Text))
                    {
                        AlertFail("Vui lòng nhập ghi chú");
                        return;
                    }
                    if (cbb_phuongthucthanhtoan.SelectedIndex == 0)
                    {
                        if (string.IsNullOrEmpty(tb_tienmat.Text))
                        {
                            AlertFail("Vui lòng nhập số tiền");
                            return;
                        }
                        else if ((Convert.ToInt32(Convert.ToInt32(tb_tienmat.Text) - Convert.ToInt32(tb_tongtien.Text) + Convert.ToInt32(tbx_TienCoc.Text) - Convert.ToInt32(tbx_TienShip.Text))) < 0)
                        {
                            AlertFail("Số tiền chưa thỏa mãn");
                            return;
                        }
                        else
                        {
                            hd.TienMat = Convert.ToInt32(tb_tienmat.Text);
                        }
                    }
                    else if (cbb_phuongthucthanhtoan.SelectedIndex == 1)
                    {
                        if (string.IsNullOrEmpty(tb_chuyenkhoan.Text))
                        {
                            AlertFail("Vui lòng nhập số tiền");
                            return;
                        }
                        else if ((Convert.ToInt32(Convert.ToInt32(tb_chuyenkhoan.Text) - Convert.ToInt32(tb_tongtien.Text) + Convert.ToInt32(tbx_TienCoc.Text) - Convert.ToInt32(tbx_TienShip.Text))) < 0)
                        {
                            AlertFail("Số tiền chưa thỏa mãn");
                            return;
                        }
                        else
                        {
                            hd.TienChuyenKhoan = Convert.ToInt32(tb_chuyenkhoan.Text);
                        }

                    }
                    else if (cbb_phuongthucthanhtoan.SelectedIndex == 2)
                    {
                        if (string.IsNullOrEmpty(tb_chuyenkhoan.Text))
                        {
                            AlertFail("Vui lòng nhập số tiền");
                            return;
                        }
                        else if (string.IsNullOrEmpty(tb_tienmat.Text))
                        {
                            AlertFail("Vui lòng nhập số tiền");
                            return;
                        }
                        else if (Convert.ToInt32(Convert.ToInt32(tb_tienmat.Text) + Convert.ToInt32(tb_chuyenkhoan.Text) - Convert.ToInt32(tb_tongtien.Text) + Convert.ToInt32(tbx_TienCoc.Text) - Convert.ToInt32(tbx_TienShip.Text)) < 0)
                        {
                            AlertFail("Số tiền chưa thỏa mãn");
                            return;
                        }

                        else
                        {
                            hd.TienMat = Convert.ToInt32(tb_tienmat.Text);
                            hd.TienChuyenKhoan = Convert.ToInt32(tb_chuyenkhoan.Text);
                        }
                    }

                    if (!string.IsNullOrEmpty(tb_diachi.Text))
                    {
                        hd.GhiChu = tb_diachi.Text;
                    }
                    if (string.IsNullOrEmpty(tbx_TienCoc.Text))
                    {
                        AlertFail("Vui lòng nhập tiền cọc");
                        return;
                    }
                    else if (string.IsNullOrEmpty(tbx_TienShip.Text))
                    {
                        AlertFail("Vui lòng nhập tiền ship");
                        return;
                    }
                    else if (string.IsNullOrEmpty(tb_diachi.Text))
                    {
                        AlertFail("Vui lòng nhập địa chỉ giao hàng");
                        return;
                    }
                    else if (Convert.ToInt32(tbx_TienCoc.Text) < Convert.ToInt32(tbx_TienShip.Text))
                    {
                        AlertFail("Tiền cọc phải lớn hơn tiền ship");
                        return;
                    }
                    if (string.IsNullOrEmpty(tb_nguoinhan.Text))
                    {
                        AlertFail("Vui lòng nhập tên người nhận");
                        return;
                    }
                    else if (!string.IsNullOrEmpty(tb_sodienthoai.Text))
                    {
                        if (tb_sodienthoai.Text.Length > 10)
                        {
                            AlertFail("Số điện thoại sai");
                            return;
                        }
                    }
                    var cahientai = _igiaocaservice.GetAll().FirstOrDefault(c => c.Ma == "GC" + _igiaocaservice.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString());
                    if (cahientai.TongTienTrongCa < Convert.ToInt32(tb_tientralai.Text))
                    {
                        AlertFail("Không đủ tiền trả lại");
                        return;
                    }
                    lichsudiemdung.SoDiemDung = 0;
                    if (cb_dungdiem.Checked == true && !String.IsNullOrEmpty(tb_dungdiem.Text))
                    {
                        // lish sử điểm dùng
                        lichsudiemdung.Id = Guid.NewGuid();
                        lichsudiemdung.IddiemTieuDung = kh.IddiemTieuDung;
                        lichsudiemdung.Ma = "LSD" + Convert.ToString(_ilichSuDiemTichService.GetAll()
                                  .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
                        lichsudiemdung.SoDiemDung = Convert.ToInt32(tb_dungdiem.Text);
                        lichsudiemdung.NgaySuDung = DateTime.Now;
                        lichsudiemdung.TongTien = Convert.ToInt32(tb_diemquydoi.Text);
                        lichsudiemdung.TrangThai = 1;
                        _ilichSuDiemDungService.Add(lichsudiemdung);
                        hd.IddiemDung = lichsudiemdung.Id;

                    }
                    lichSuDiemTich.Id = Guid.NewGuid();
                    lichSuDiemTich.IddiemTieuDung = kh.IddiemTieuDung;
                    lichSuDiemTich.Ma = "LST" + Convert.ToString(_ilichSuDiemTichService.GetAll()
                              .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
                    lichSuDiemTich.SoDiemTich = Convert.ToInt32(tb_tongtien.Text) / Convert.ToInt32(cttd2.HeSo);
                    lichSuDiemTich.NgaySuDung = DateTime.Now;
                    lichSuDiemTich.TongTien = Convert.ToInt32(tb_tongtien.Text);
                    lichSuDiemTich.TrangThai = 1;
                    _ilichSuDiemTichService.Add(lichSuDiemTich);
                    DiemTieuDung dtd = new DiemTieuDung();
                    dtd = _idiemTieuDungService.GetAll().FirstOrDefault(z => z.Id == kh.IddiemTieuDung);
                    dtd.SoDiem = dtd.SoDiem - Convert.ToInt32(lichsudiemdung.SoDiemDung) + Convert.ToInt32(lichSuDiemTich.SoDiemTich);
                    _idiemTieuDungService.Update(dtd);

                    hd.TenNguoiNhan = tb_nguoinhan.Text;
                    hd.SdtNguoiNhan = tb_sodienthoai.Text;
                    hd.Id = hd.Id;
                    hd.TrangThai = 2;
                    hd.MaHd = tabHoaDon.SelectedTab.Name;
                    hd.Idnv = SelectNhanVien;
                    hd.Idkh = _ikhachHangService.getAll().Where(c => c.Ma == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault();
                    hd.IddiemTich = lichSuDiemTich.Id;
                    hd.TienCoc = Convert.ToInt32(tbx_TienCoc.Text);
                    hd.TienShip = Convert.ToInt32(tbx_TienShip.Text);
                    hd.DiaChi = tb_diachi.Text;
                    hd.GhiChu = tb_ghichu.Text;
                    hd.IdphuongThucThanhToan = _iphuongThucThanhToanService.GetAllNoView().Where(x => x.Ten == cbb_phuongthucthanhtoan.SelectedItem).Select(x => x.Id).FirstOrDefault();
                    hd.TongTien = Convert.ToInt32(tb_tongtien.Text);

                    // hóa đơn đã thanh toán
                    hoaDonService.Update(hd);
                    GiaoCa gc = new GiaoCa();
                     cahientai = _igiaocaservice.GetAll().FirstOrDefault(c => c.Ma == "GC" + _igiaocaservice.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString());
                    gc.Id = cahientai.Id;
                    gc.TongTienMat = cahientai.TongTienMat + Convert.ToDecimal(tb_tienmat.Text == string.Empty ? 0 : tb_tienmat.Text) - Convert.ToDecimal(tb_tientralai.Text);
                    gc.TongTienKhac = cahientai.TongTienKhac + Convert.ToDecimal(tb_chuyenkhoan.Text == string.Empty ? 0 : tb_chuyenkhoan.Text);
                    gc.TongTienTrongCa = cahientai.TongTienTrongCa + Convert.ToDecimal(tb_tienmat.Text == string.Empty ? 0 : tb_tienmat.Text) - Convert.ToDecimal(tb_tientralai.Text);
                    _igiaocaservice.Update(gc);
                    InHoaDonGiaoHang();
                    AlertSuccess("Cập nhật thành công");
                    LoadHoaDonChoThanhToan();
                    LoadHoaDonDatHang();
                    Tabhoadondcmm();
                }
                else
                {
                    if (cbb_phuongthucthanhtoan.SelectedIndex == 0)
                    {
                        if (string.IsNullOrEmpty(tb_tienmat.Text))
                        {
                            AlertFail("Vui lòng nhập số tiền");
                            return;

                        }
                        else if (Convert.ToInt32(tb_tientralai.Text) < 0)
                        {
                            AlertFail("Số tiền chưa thỏa mãn");
                            return;
                        }
                        else
                        {
                            hd.TienMat = Convert.ToInt32(tb_tienmat.Text);

                        }

                    }
                    else if (cbb_phuongthucthanhtoan.SelectedIndex == 1)
                    {
                        if (string.IsNullOrEmpty(tb_chuyenkhoan.Text))
                        {
                            AlertFail("Vui lòng nhập số tiền");
                            return;
                        }
                        else if (Convert.ToInt32(tb_tientralai.Text) < 0)
                        {
                            AlertFail("Số tiền chưa thỏa mãn");
                            return;
                        }
                        else
                        {
                            hd.TienChuyenKhoan = Convert.ToInt32(tb_chuyenkhoan.Text);

                        }

                    }
                    else if (cbb_phuongthucthanhtoan.SelectedIndex == 2)
                    {
                        if (string.IsNullOrEmpty(tb_chuyenkhoan.Text))
                        {
                            AlertFail("Vui lòng nhập số tiền");
                            return;
                        }
                        else if (string.IsNullOrEmpty(tb_tienmat.Text))
                        {
                            AlertFail("Vui lòng nhập số tiền");
                            return;
                        }
                        else if (Convert.ToInt32(tb_tientralai.Text) < 0)
                        {
                            AlertFail("Số tiền chưa thỏa mãn");
                            return;
                        }

                        else
                        {
                            hd.TienMat = Convert.ToInt32(tb_tienmat.Text);
                            hd.TienChuyenKhoan = Convert.ToInt32(tb_chuyenkhoan.Text);

                        }
                    }

                    if (string.IsNullOrEmpty(tbx_TienCoc.Text))
                    {
                        AlertFail("Vui lòng nhập tiền cọc");
                        return;
                    }
                    else if (string.IsNullOrEmpty(tbx_TienShip.Text))
                    {
                        AlertFail("Vui lòng nhập tiền ship");
                        return;
                    }
                    else if (string.IsNullOrEmpty(tb_diachi.Text))
                    {
                        AlertFail("Vui lòng nhập địa chỉ giao hàng");
                        return;
                    }
                    else if (Convert.ToInt32(tbx_TienCoc.Text) < Convert.ToInt32(tbx_TienShip.Text))
                    {
                        AlertFail("Tiền cọc phải lớn hơn tiền ship");
                        return;
                    }

                    if (rd_chogiao.Checked == true)
                    {
                        hd.TrangThai = 2;
                    }
                    else if (rd_danggiao.Checked == true)
                    {
                        hd.TrangThai = 3;
                    }
                    else if (rd_dathanhtoan.Checked == true)
                    {
                        hd.TrangThai = 1;
                    }

                    if (string.IsNullOrEmpty(tb_nguoinhan.Text))
                    {
                        AlertFail("Vui lòng nhập tên người nhận");
                        return;
                    }
                    else if (!string.IsNullOrEmpty(tb_sodienthoai.Text))
                    {
                        if (tb_sodienthoai.Text.Length < 10)
                        {
                            AlertFail("Số điện thoại sai");
                            return;
                        }
                    }
                    var cahientai = _igiaocaservice.GetAll().FirstOrDefault(c => c.Ma == "GC" + _igiaocaservice.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString());
                    if (cahientai.TongTienTrongCa < Convert.ToInt32(tb_tientralai.Text))
                    {
                        AlertFail("Không đủ tiền trả lại");
                        return;
                    }
                    hd.Id = hd.Id;
                    hd.MaHd = tabHoaDon.SelectedTab.Name;
                    hd.Idnv = SelectNhanVien;
                    hd.TienCoc = Convert.ToInt32(tbx_TienCoc.Text);
                    hd.TienShip = Convert.ToInt32(tbx_TienShip.Text);
                    hd.DiaChi = tb_diachi.Text;
                    hd.SdtNguoiNhan = tb_sodienthoai.Text;
                    hd.TenNguoiNhan = tb_nguoinhan.Text;
                    hd.IdphuongThucThanhToan = _iphuongThucThanhToanService.GetAllNoView().Where(x => x.Ten == cbb_phuongthucthanhtoan.SelectedItem).Select(x => x.Id).FirstOrDefault();
                    hd.TongTien = Convert.ToInt32(tb_tongtien.Text);
                    hd.GhiChu = tb_diachi.Text;
                    // hd.TrangThai = a; // hóa đơn đã thanh toán
                    hoaDonService.Update(hd);
                    GiaoCa gc = new GiaoCa();
                     cahientai = _igiaocaservice.GetAll().FirstOrDefault(c => c.Ma == "GC" + _igiaocaservice.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString());
                    gc.Id = cahientai.Id;
                    gc.TongTienMat = cahientai.TongTienMat + Convert.ToDecimal(tb_tienmat.Text == string.Empty ? 0 : tb_tienmat.Text) - Convert.ToDecimal(tb_tientralai.Text);
                    gc.TongTienKhac = cahientai.TongTienKhac + Convert.ToDecimal(tb_chuyenkhoan.Text == string.Empty ? 0 : tb_chuyenkhoan.Text);
                    gc.TongTienTrongCa = cahientai.TongTienTrongCa + Convert.ToDecimal(tb_tienmat.Text == string.Empty ? 0 : tb_tienmat.Text) - Convert.ToDecimal(tb_tientralai.Text);
                    _igiaocaservice.Update(gc);
                    InHoaDonGiaoHang();
                    AlertSuccess("Cập nhật thành công");
                    LoadHoaDonChoThanhToan();
                    LoadHoaDonDaThanhToan();
                    Tabhoadondcmm();
                    if (rd_chogiao.Checked == true)
                    {
                        cbx_Loc.SelectedIndex = 2;
                    }
                    else if (rd_danggiao.Checked == true)
                    {
                        cbx_Loc.SelectedIndex = 3;
                    }
                    else if (rd_dathanhtoan.Checked == true)
                    {
                        cbx_Loc.SelectedIndex = 1;
                    }

                }
            }
            else if (hd.TrangThai == 2 || hd.TrangThai == 3)
            {
                if (tb_vidiem.Text != string.Empty)
                {

                    int a = 0;
                    if (rd_chogiao.Checked == true)
                    {
                        a = 2;
                    }
                    else if (rd_danggiao.Checked == true)
                    {
                        a = 3;
                    }
                    else if (rd_dathanhtoan.Checked == true)
                    {
                        a = 1;
                    }
                    else if (rd_chothanhtoan.Checked == true)
                    {
                        a = 0;
                    }
                    //if (hd.TrangThai == a)
                    //{
                    //    AlertFail("Bạn chưa có sự thay đổi");
                    //    return;
                    //}
                    if (hd.TrangThai != a || hd.TrangThai == a)
                    {
                        if (a == 0)
                        {
                            if (string.IsNullOrEmpty(tb_diachi.Text))
                            {
                                AlertFail("Vui lòng nhập ghi chú");
                                return;
                            }
                            else
                            {
                                hd.GhiChu = tb_diachi.Text;
                            }
                            lichsudiemdung = _ilichSuDiemDungService.GetAll().Where(x => x.Id == hd.IddiemDung).FirstOrDefault();
                            lichSuDiemTich = _ilichSuDiemTichService.GetAll().Where(x => x.Id == hd.IddiemTich).FirstOrDefault();
                            hd.IddiemDung = null;
                            hd.IddiemTich = null;
                            kh = _ikhachHangService.getAll().Where(x => x.Id == hd.Idkh).FirstOrDefault();
                            diemtieudung = _idiemTieuDungService.GetAll().Where(x => x.Id == kh.IddiemTieuDung).FirstOrDefault();
                            if (hd.Idkh != null)
                            {
                                if (hd.IddiemDung != null)
                                {
                                    diemtieudung.SoDiem = diemtieudung.SoDiem + lichsudiemdung.SoDiemDung - lichSuDiemTich.SoDiemTich;
                                    _idiemTieuDungService.Update(diemtieudung);
                                    _ilichSuDiemDungService.Remove(lichsudiemdung);

                                }
                                else
                                {
                                    diemtieudung.SoDiem = diemtieudung.SoDiem - lichSuDiemTich.SoDiemTich;
                                    _idiemTieuDungService.Update(diemtieudung);
                                    _ilichSuDiemTichService.Remove(lichSuDiemTich);
                                }

                            }

                            hd.TrangThai = a;


                            hoaDonService.Update(hd);
                         
                            AlertSuccess("Update trạng thái thành công");
                            return;
                        }
                        else if (a == 3 || a == 2)
                        {
                            if (string.IsNullOrEmpty(tb_diachi.Text))
                            {
                                AlertFail("Vui lòng nhập ghi chú");
                                return;
                            }
                            else
                            {
                                hd.GhiChu = tb_diachi.Text;
                            }
                            hd.TrangThai = a;
                            hd.GhiChu = tb_ghichu.Text;
                            hd.TenNguoiNhan = tb_nguoinhan.Text;
                            hd.SdtNguoiNhan = tb_sodienthoai.Text;
                            hd.DiaChi = tb_diachi.Text;
                            hoaDonService.Update(hd);
                            AlertSuccess("Update trạng thái thành công");
                            LoadHoaDonChoThanhToan();
                            LoadHoaDonDaThanhToan();
                            Tabhoadondcmm();
                            return;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(tb_diachi.Text))
                            {
                                AlertFail("Vui lòng nhập ghi chú");
                                return;
                            }
                            else
                            {
                                hd.GhiChu = tb_diachi.Text;
                            }
                            hd.TrangThai = a;
                            hd.GhiChu = tb_ghichu.Text;
                            hd.TenNguoiNhan = tb_nguoinhan.Text;
                            hd.SdtNguoiNhan = tb_sodienthoai.Text;
                            hd.DiaChi = tb_diachi.Text;
                            hoaDonService.Update(hd);
                            AlertSuccess("Update trạng thái thành công");
                            LoadHoaDonChoThanhToan();
                            LoadHoaDonDaThanhToan();
                            Tabhoadondcmm();
                            return;
                        }

                    }
                }
                else if (tb_vidiem.Text == string.Empty)
                {
                    int a = 0;
                    if (rd_chogiao.Checked == true)
                    {
                        a = 2;
                    }
                    else if (rd_danggiao.Checked == true)
                    {
                        a = 3;
                    }
                    else if (rd_dathanhtoan.Checked == true)
                    {
                        a = 1;
                    }
                    else if (rd_chothanhtoan.Checked == true)
                    {
                        a = 0;
                    }
                    //if (hd.TrangThai == a)
                    //{

                    //    AlertFail("Bạn chưa có sự thay đổi");
                    //    return;
                    //}
                    if (hd.TrangThai != a || hd.TrangThai == a)
                    {

                        if (string.IsNullOrEmpty(tb_diachi.Text))
                        {
                            AlertFail("Vui lòng nhập ghi chú");
                            return;
                        }
                        else
                        {
                            hd.GhiChu = tb_diachi.Text;
                        }
                        hd.TrangThai = a;
                        hd.GhiChu = tb_ghichu.Text;
                        hd.DiaChi = tb_diachi.Text;
                        hd.SdtNguoiNhan = tb_sodienthoai.Text;
                        hd.TenNguoiNhan = tb_nguoinhan.Text;
                        hoaDonService.Update(hd);
                        AlertSuccess("Update trạng thái thành công");
                        return;

                    }
                }



                if (rd_chogiao.Checked == true)
                {
                    cbx_Loc.SelectedIndex = 1;
                }
                else if (rd_danggiao.Checked == true)
                {
                    cbx_Loc.SelectedIndex = 2;
                }
                else if (rd_dathanhtoan.Checked == true)
                {
                    cbx_Loc.SelectedIndex = 0;
                }
            }
            else if (hd.TrangThai == 1)
            {
                AlertFail("Bạn không thể cập nhật");
                return;
            }


            LoadHoaDonChoThanhToan();
            LoadHoaDonDatHang();
            Tabhoadondcmm();
        }
        private void btn_quetma_Click(object sender, EventArgs e)
        {
            
                HoaDon hdcheck = new HoaDon();
                hdcheck = hoaDonService.GetAllHoaDon().FirstOrDefault(z => z.MaHd == tabHoaDon.SelectedTab.Name);
                if (hdcheck.TrangThai == 0)
                {
                    Form_QuetMaSach.mavach = string.Empty;
                    Form_QuetMaSach qms = new Form_QuetMaSach();
                    qms.ShowDialog();
                    if (Form_QuetMaSach.mavach == string.Empty)
                    {
                        //Form_QuetMaSach.mavach = null;
                        //qms.ShowDialog();
                        return;
                    }
                    if (Form_QuetMaSach.mavach != string.Empty && Form_QuetMaSach.tensach != null)
                    {
                        if (dtg_HoaDonChiTiet.Visible == false)
                        {
                            DialogResult hoi = MessageBox.Show("Bạn chưa chọn hóa đơn, Bạn có muốn tạo hóa đơn mới không", "Tạo hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult.Yes == hoi)
                            {
                                tabHoaDon.Visible = true;
                                TabPage tpage = new TabPage();
                                tabHoaDon.TabPages.Add(tpage);
                                HoaDon hd = new HoaDon();
                                hd.Id = Guid.NewGuid();
                                hd.MaHd = "HD" + Convert.ToString(hoaDonService.GetAllHoaDon().Max(c => Convert.ToInt32(c.MaHd.Substring(2, c.MaHd.Length - 2)) + 1));
                                hd.Idnv = SelectNhanVien;
                                //hd.Idkh = Guid.Parse("56303832-7163-464a-99a8-72973ed09c21");
                                hd.NgayTao = DateTime.Now;
                                MessageBox.Show(hoaDonService.Add(hd));
                                tpage.Text = Convert.ToString(hd.MaHd);
                                tpage.Name = Convert.ToString(hd.MaHd);
                                tabHoaDon.SelectedIndex = tabHoaDon.TabCount;
                                LoaddataToHoadonChitiet();
                                LoadHoaDonChiTiet();
                                LoaddataToTextbox(hd.Id);
                                Tabhoadondcmm();
                                LoadHoaDonChoThanhToan();

                                // thêm sản phẩm lên hóa đơn vừa tạo
                                var x = _iChiTietSachService.GetAll().Where(c => c.MaVach == Form_QuetMaSach.mavach).Select(x => x.Id).FirstOrDefault();
                                SelectIDSp = x;
                                //HoaDon hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
                                SelectID = hd.Id;
                                HoaDonChiTiet data = hoaDonChiTietService.GetAllloadformsp().FirstOrDefault(x => x.IdChiTietSach == SelectIDSp && x.IdHoaDon == SelectID);
                                string ctsclick = _iChiTietSachService.GetAllChiTietSachView().FirstOrDefault(c => c.Id == x).Ma;
                                string tenclick = _iChiTietSachService.GetAllChiTietSachView().FirstOrDefault(c => c.Id == x).TenSach;
                                decimal giabanclick = Convert.ToDecimal(_iChiTietSachService.GetAllChiTietSachView().FirstOrDefault(c => c.Id == x).GiaBan);
                                string Content = Interaction.InputBox($"Mã: {ctsclick}" + Environment.NewLine + $"Tên: {tenclick}" + Environment.NewLine + $"Giá bán: {giabanclick}" + Environment.NewLine + "Nhập số lượng ", "Bạn muốn thêm bao nhiêu", "1", 500, 300);//nhập số lượng ở màn bán hàng
                                if (Content == string.Empty) return;

                                if (Regex.IsMatch(Content, @"^[a-zA-Z0-9 ]*$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                                    return;
                                }
                                if (Regex.IsMatch(Content, @"^\d+$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                                    return;
                                }
                                if (Content.Length > 6)
                                {
                                    MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                                    return;
                                }
                                if (Convert.ToInt32(Content) <= 0)
                                {
                                    MessageBox.Show("Số Lượng Phải Lớn Hơn 0", "ERR");
                                    return;
                                }
                                if (Content != null)
                                {
                                    if (data == null)
                                    {
                                        HoaDonChiTiet hdct = new HoaDonChiTiet();
                                        hdct.Id = Guid.NewGuid();
                                        hdct.IdHoaDon = SelectID;
                                        hdct.IdChiTietSach = SelectIDSp;
                                        ChiTietSach cts = new ChiTietSach();
                                        cts = _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).FirstOrDefault();
                                        if (cts.SoLuong >= Convert.ToInt32(Content))
                                        {
                                            hdct.Ma = "HDCT" + Convert.ToString(hoaDonChiTietService.GetAllloadformsp()
                                              .Max(c => Convert.ToInt32(c.Ma.Substring(4, c.Ma.Length - 4)) + 1));
                                            hdct.SoLuong = Convert.ToInt32(Content);
                                            hdct.DonGia = Convert.ToInt32(cts.GiaBan);
                                            hdct.ThanhTien = Convert.ToInt32(hdct.SoLuong * cts.GiaBan);
                                            hoaDonChiTietService.Add(hdct);
                                            //update số lượng còn lại 
                                            cts.IdSach = cts.IdSach;
                                            cts.IdSach = cts.IdSach;
                                            cts.IdNxb = cts.IdNxb;
                                            cts.IdTacGia = cts.IdTacGia;
                                            cts.IdNhaPhatHanh = cts.IdNhaPhatHanh;
                                            cts.IdLoaiBia = cts.IdLoaiBia;
                                            cts.Ma = cts.Ma;
                                            cts.Anh = cts.Anh;
                                            cts.MaVach = cts.MaVach;
                                            cts.KichThuoc = cts.KichThuoc;
                                            cts.SoTrang = cts.SoTrang;
                                            cts.NamXuatBan = cts.NamXuatBan;
                                            cts.MoTa = cts.MoTa;
                                            cts.GiaNhap = cts.GiaNhap;
                                            cts.GiaBan = cts.GiaBan;
                                            cts.TrangThai = cts.TrangThai;
                                            cts.SoLuong = cts.SoLuong - Convert.ToInt32(Content);
                                            _iChiTietSachService.Update(hdct.IdChiTietSach, cts);
                                            //het update
                                            LoadSanphamtoFl();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Số lượng bạn nhập kho hàng không đáp ứng đủ, số lượng còn lại là:" + " " + cts.SoLuong);
                                        }
                                    }
                                    else
                                    {
                                        HoaDonChiTiet hdct = new HoaDonChiTiet();
                                        hdct = hoaDonChiTietService.GetAllloadformsp().FirstOrDefault(x => x.IdHoaDon == SelectID && x.IdChiTietSach == SelectIDSp);
                                        hdct.SoLuong = data.SoLuong + Convert.ToInt32(Content);
                                        hdct.ThanhTien = hdct.SoLuong * _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).Select(x => x.GiaBan).FirstOrDefault();
                                        ChiTietSach cts = new ChiTietSach();
                                        cts = _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).FirstOrDefault();
                                        hdct.DonGia = Convert.ToInt32(cts.GiaBan);
                                        if (cts.SoLuong > Convert.ToInt32(Content))//check so luong con lai
                                        {
                                            hoaDonChiTietService.Update(hdct);
                                            //update so luong sach con lai
                                            cts.IdSach = cts.IdSach;
                                            cts.IdSach = cts.IdSach;
                                            cts.IdNxb = cts.IdNxb;
                                            cts.IdTacGia = cts.IdTacGia;
                                            cts.IdNhaPhatHanh = cts.IdNhaPhatHanh;
                                            cts.IdLoaiBia = cts.IdLoaiBia;
                                            cts.Ma = cts.Ma;
                                            cts.Anh = cts.Anh;
                                            cts.MaVach = cts.MaVach;
                                            cts.KichThuoc = cts.KichThuoc;
                                            cts.SoTrang = cts.SoTrang;
                                            cts.NamXuatBan = cts.NamXuatBan;
                                            cts.MoTa = cts.MoTa;
                                            cts.GiaNhap = cts.GiaNhap;
                                            cts.GiaBan = cts.GiaBan;
                                            cts.TrangThai = cts.TrangThai;
                                            cts.SoLuong = cts.SoLuong - Convert.ToInt32(Content);
                                            _iChiTietSachService.Update(hdct.IdChiTietSach, cts);
                                            //het update
                                            LoadSanphamtoFl();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Số lượng bạn nhập kho hàng không đáp ứng đủ, số lượng còn lại là:" + " " + cts.SoLuong);
                                        }
                                    }
                                }
                                LoaddataToHoadonChitiet();
                                LoadHoaDonChiTiet();
                                LoadSanphamtoFl();
                            }
                            else if (DialogResult.No == hoi)
                            {
                                return;
                            }

                        }
                        else
                        {
                            var x = _iChiTietSachService.GetAll().Where(c => c.MaVach == Form_QuetMaSach.mavach).Select(x => x.Id).FirstOrDefault();
                            SelectIDSp = x;
                            HoaDon hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
                            SelectID = hd.Id;
                            if (hd.TrangThai == 0)
                            {
                                HoaDonChiTiet data = hoaDonChiTietService.GetAllloadformsp().FirstOrDefault(x => x.IdChiTietSach == SelectIDSp && x.IdHoaDon == SelectID);
                                string ctsclick = _iChiTietSachService.GetAllChiTietSachView().FirstOrDefault(c => c.Id == x).Ma;
                                string tenclick = _iChiTietSachService.GetAllChiTietSachView().FirstOrDefault(c => c.Id == x).TenSach;
                                decimal giabanclick = Convert.ToDecimal(_iChiTietSachService.GetAllChiTietSachView().FirstOrDefault(c => c.Id == x).GiaBan);
                                string Content = Interaction.InputBox($"Mã: {ctsclick}" + Environment.NewLine + $"Tên: {tenclick}" + Environment.NewLine + $"Giá bán: {giabanclick}" + Environment.NewLine + "Nhập số lượng ", "Bạn muốn thêm bao nhiêu", "1", 500, 300);//nhập số lượng ở màn bán hàng
                                if (Content == string.Empty) return;

                                if (Regex.IsMatch(Content, @"^[a-zA-Z0-9 ]*$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                                    return;
                                }
                                if (Regex.IsMatch(Content, @"^\d+$") == false)
                                {

                                    MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                                    return;
                                }
                                if (Content.Length > 6)
                                {
                                    MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                                    return;
                                }
                                if (Convert.ToInt32(Content) <= 0)
                                {
                                    MessageBox.Show("Số Lượng Phải Lớn Hơn 0", "ERR");
                                    return;
                                }
                                if (Content != null)
                                {
                                    if (data == null)
                                    {
                                        HoaDonChiTiet hdct = new HoaDonChiTiet();
                                        hdct.Id = Guid.NewGuid();
                                        hdct.IdHoaDon = SelectID;
                                        hdct.IdChiTietSach = SelectIDSp;
                                        ChiTietSach cts = new ChiTietSach();
                                        cts = _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).FirstOrDefault();
                                        if (cts.SoLuong >= Convert.ToInt32(Content))
                                        {
                                            hdct.Ma = "HDCT" + Convert.ToString(hoaDonChiTietService.GetAllloadformsp()
                                              .Max(c => Convert.ToInt32(c.Ma.Substring(4, c.Ma.Length - 4)) + 2));
                                            hdct.SoLuong = Convert.ToInt32(Content);
                                            hdct.DonGia = Convert.ToInt32(cts.GiaBan);
                                            hdct.ThanhTien = Convert.ToInt32(hdct.SoLuong * cts.GiaBan);
                                            hoaDonChiTietService.Add(hdct);
                                            //update số lượng còn lại 
                                            cts.IdSach = cts.IdSach;
                                            cts.IdSach = cts.IdSach;
                                            cts.IdNxb = cts.IdNxb;
                                            cts.IdTacGia = cts.IdTacGia;
                                            cts.IdNhaPhatHanh = cts.IdNhaPhatHanh;
                                            cts.IdLoaiBia = cts.IdLoaiBia;
                                            cts.Ma = cts.Ma;
                                            cts.Anh = cts.Anh;
                                            cts.MaVach = cts.MaVach;
                                            cts.KichThuoc = cts.KichThuoc;
                                            cts.SoTrang = cts.SoTrang;
                                            cts.NamXuatBan = cts.NamXuatBan;
                                            cts.MoTa = cts.MoTa;
                                            cts.GiaNhap = cts.GiaNhap;
                                            cts.GiaBan = cts.GiaBan;
                                            cts.TrangThai = cts.TrangThai;
                                            cts.SoLuong = cts.SoLuong - Convert.ToInt32(Content);
                                            _iChiTietSachService.Update(hdct.IdChiTietSach, cts);
                                            //het update
                                            LoadSanphamtoFl();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Số lượng bạn nhập kho hàng không đáp ứng đủ, số lượng còn lại là:" + " " + cts.SoLuong);
                                        }
                                    }
                                    else
                                    {
                                        HoaDonChiTiet hdct = new HoaDonChiTiet();
                                        hdct = hoaDonChiTietService.GetAllloadformsp().FirstOrDefault(x => x.IdHoaDon == SelectID && x.IdChiTietSach == SelectIDSp);
                                        hdct.SoLuong = data.SoLuong + Convert.ToInt32(Content);
                                        hdct.ThanhTien = hdct.SoLuong * _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).Select(x => x.GiaBan).FirstOrDefault();
                                        ChiTietSach cts = new ChiTietSach();
                                        cts = _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).FirstOrDefault();
                                        hdct.DonGia = Convert.ToInt32(cts.GiaBan);
                                        if (cts.SoLuong > Convert.ToInt32(Content))//check so luong con lai
                                        {
                                            hoaDonChiTietService.Update(hdct);
                                            //update so luong sach con lai
                                            cts.IdSach = cts.IdSach;
                                            cts.IdSach = cts.IdSach;
                                            cts.IdNxb = cts.IdNxb;
                                            cts.IdTacGia = cts.IdTacGia;
                                            cts.IdNhaPhatHanh = cts.IdNhaPhatHanh;
                                            cts.IdLoaiBia = cts.IdLoaiBia;
                                            cts.Ma = cts.Ma;
                                            cts.Anh = cts.Anh;
                                            cts.MaVach = cts.MaVach;
                                            cts.KichThuoc = cts.KichThuoc;
                                            cts.SoTrang = cts.SoTrang;
                                            cts.NamXuatBan = cts.NamXuatBan;
                                            cts.MoTa = cts.MoTa;
                                            cts.GiaNhap = cts.GiaNhap;
                                            cts.GiaBan = cts.GiaBan;
                                            cts.TrangThai = cts.TrangThai;
                                            cts.SoLuong = cts.SoLuong - Convert.ToInt32(Content);
                                            _iChiTietSachService.Update(hdct.IdChiTietSach, cts);
                                            //het update
                                            LoadSanphamtoFl();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Số lượng bạn nhập kho hàng không đáp ứng đủ, số lượng còn lại là:" + " " + cts.SoLuong);
                                        }
                                    }
                                }
                                LoaddataToHoadonChitiet();
                                LoadHoaDonChiTiet();
                                LoadSanphamtoFl();
                                Tabhoadondcmm();
                            }
                            else if (hd.TrangThai == 1)
                            {
                                AlertFail("Hóa đơn này đã được thanh toán");
                                return;
                            }
                            else if (hd.TrangThai == 2)
                            {
                                AlertFail("Hóa đơn này đã thanh toán và chờ di chuyển");
                                return;
                            }
                            else if (hd.TrangThai == 3)
                            {
                                AlertFail("Hóa đơn này đang giao");
                                return;
                            }
                        }
                        LoaddataToHoadonChitiet();
                    }
                }
                else
                {
                    AlertFail("Không thể thêm sản phẩm");
                }
            

        }


        private void tb_tienkhachdua_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]*$");
            if (tabHoaDon.SelectedIndex>=0)
            {
                if (dtg_HoaDonChiTiet.Visible == true)
                {
                    HoaDon hd = new HoaDon();
                    hd = hoaDonService.GetAllHoaDon().Where(x => x.MaHd == tabHoaDon.SelectedTab.Name).FirstOrDefault();
                    if (hd.TrangThai == 0)
                    {
                        if (tabtrangthaimuahang.SelectedIndex == 0)
                        {
                            if (cbb_phuongthucthanhtoan.SelectedIndex == 0)
                            {
                                if (Regex.IsMatch(tb_tienmat.Text, @"^[a-zA-Z0-9 ]*$") == false)
                                {
                                    MessageBox.Show("Không được chứa ký tự đặc biệt");
                                }
                                else if (tb_tienmat.Text == "")
                                {
                                    tb_tienmat.Clear();
                                    tb_tientralai.Clear();
                                    return;
                                }
                                else if (regex.IsMatch(tb_tienmat.Text))
                                {
                                    tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_tienmat.Text) - Convert.ToInt32(tb_tongtien.Text));
                                }
                            }
                            else if (cbb_phuongthucthanhtoan.SelectedIndex == 1)
                            {

                                if (Regex.IsMatch(tb_chuyenkhoan.Text, @"^[a-zA-Z0-9 ]*$") == false)
                                {
                                    MessageBox.Show("Không được chứa ký tự đặc biệt");
                                }
                                else if (tb_tienmat.Text == "")
                                {
                                    tb_tienmat.Clear();
                                    tb_tientralai.Clear();
                                    return;
                                }
                                else if (regex.IsMatch(tb_chuyenkhoan.Text))
                                {
                                    tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_chuyenkhoan.Text) - Convert.ToInt32(tb_tongtien.Text));
                                }

                            }
                            else if (cbb_phuongthucthanhtoan.SelectedIndex == 2)
                            {
                                if (Regex.IsMatch(tb_tienmat.Text, @"^[a-zA-Z0-9 ]*$") == false)
                                {
                                    MessageBox.Show("Không được chứa ký tự đặc biệt");
                                }
                                else if (tb_tienmat.Text == "")
                                {
                                    tb_tienmat.Clear();
                                    tb_tientralai.Clear();
                                    return;
                                }
                                //else if (Regex.IsMatch(tb_tienmat.Text, @"^\d+$") == false)
                                //{
                                //    MessageBox.Show("Không được chứa chữ cái");
                                //}
                                else if (!string.IsNullOrEmpty(tb_chuyenkhoan.Text) && !string.IsNullOrEmpty(tb_tienmat.Text))
                                {
                                    tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_tienmat.Text) - Convert.ToInt32(tb_tongtien.Text) + Convert.ToInt32(tb_chuyenkhoan.Text));
                                }
                            }
                        }
                        else if (tabtrangthaimuahang.SelectedIndex == 1)
                        {
                            if (cbb_phuongthucthanhtoan.SelectedIndex == 0)
                            {
                                if (Regex.IsMatch(tb_tienmat.Text, @"^[a-zA-Z0-9 ]*$") == false)
                                {
                                    MessageBox.Show("Không được chứa ký tự đặc biệt");
                                }
                                else if (tb_tienmat.Text == "")
                                {
                                    tb_tienmat.Clear();
                                    tb_tientralai.Clear();
                                    return;
                                }
                                //else if (Regex.IsMatch(tb_tienmat.Text, @"^\d+$") == false)
                                //{
                                //    MessageBox.Show("Không được chứa chữ cái");
                                //}
                                else if (string.IsNullOrEmpty(tbx_TienCoc.Text))
                                {
                                    return;
                                }
                                else if (string.IsNullOrEmpty(tbx_TienShip.Text))
                                {
                                    return;
                                }
                                else if (regex.IsMatch(tb_tienmat.Text))
                                {
                                    tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_tienmat.Text) - Convert.ToInt32(tb_tongtien.Text) + Convert.ToInt32(tbx_TienCoc.Text) - Convert.ToInt32(tbx_TienShip.Text));
                                }
                            }
                            else if (cbb_phuongthucthanhtoan.SelectedIndex == 1)
                            {

                                if (Regex.IsMatch(tb_chuyenkhoan.Text, @"^[a-zA-Z0-9 ]*$") == false)
                                {
                                    MessageBox.Show("Không được chứa ký tự đặc biệt");
                                }
                                else if (tb_tienmat.Text == "")
                                {
                                    tb_tienmat.Clear();
                                    tb_tientralai.Clear();
                                    return;
                                }
                                //else if (Regex.IsMatch(tb_chuyenkhoan.Text, @"^\d+$") == false)
                                //{
                                //    MessageBox.Show("Không được chứa chữ cái");
                                //}
                                else if (string.IsNullOrEmpty(tbx_TienCoc.Text))
                                {
                                    return;
                                }
                                else if (string.IsNullOrEmpty(tbx_TienShip.Text))
                                {
                                    return;
                                }
                                else if (regex.IsMatch(tb_chuyenkhoan.Text))
                                {
                                    tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_chuyenkhoan.Text) - Convert.ToInt32(tb_tongtien.Text) + Convert.ToInt32(tbx_TienCoc.Text) - Convert.ToInt32(tbx_TienShip.Text));
                                }

                            }
                            else if (cbb_phuongthucthanhtoan.SelectedIndex == 2)
                            {
                                if (Regex.IsMatch(tb_tienmat.Text, @"^[a-zA-Z0-9 ]*$") == false)
                                {
                                    MessageBox.Show("Không được chứa ký tự đặc biệt");
                                }
                                else if (tb_tienmat.Text == "")
                                {
                                    tb_tienmat.Clear();
                                    tb_tientralai.Clear();
                                    return;
                                }
                                //else if (Regex.IsMatch(tb_tienmat.Text, @"^\d+$") == false)
                                //{
                                //    MessageBox.Show("Không được chứa chữ cái");
                                //}
                                else if (string.IsNullOrEmpty(tbx_TienCoc.Text))
                                {
                                    return;
                                }
                                else if (string.IsNullOrEmpty(tbx_TienShip.Text))
                                {
                                    return;
                                }
                                else if (!string.IsNullOrEmpty(tb_chuyenkhoan.Text) && !string.IsNullOrEmpty(tb_tienmat.Text))
                                {
                                    tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_tienmat.Text) + Convert.ToInt32(tb_chuyenkhoan.Text) - Convert.ToInt32(tb_tongtien.Text) + Convert.ToInt32(tbx_TienCoc.Text) - Convert.ToInt32(tbx_TienShip.Text));
                                }
                            }
                        }

                    }

                }
            }
        }

        private void tb_tienkhachdua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_dungdiem_TextChanged(object sender, EventArgs e)
        {
            if (dtg_HoaDonChiTiet.Visible != false)
            {
                if (!string.IsNullOrEmpty(tb_vidiem.Text))
                {
                    HoaDon hd = new HoaDon();
                    hd = hoaDonService.GetAllHoaDon().Where(x => x.MaHd == tabHoaDon.SelectedTab.Name).FirstOrDefault();
                    if (hd.TrangThai == 0)
                    {
                        if (cb_dungdiem.Checked == true && string.IsNullOrEmpty(tb_dungdiem.Text))
                        {
                            tb_dungdiem.Clear();
                            tb_diemquydoi.Clear();
                            //tb_tongtien.Text = tb_tongtienhang.Text;
                            return;
                        }
                        if (cb_dungdiem.Checked == true && !string.IsNullOrEmpty(tb_dungdiem.Text))
                        {
                            if (Convert.ToInt32(tb_dungdiem.Text) > Convert.ToInt32(tb_vidiem.Text))
                            {
                                MessageBox.Show("Số điểm nhập đang lớn hơn số điểm hiện có");
                                tb_dungdiem.Clear();
                                tb_diemquydoi.Clear();
                                tb_tongtien.Text = tb_tongtienhang.Text;
                                return;
                            }
                        }
                        if (cb_dungdiem.Checked == true && !string.IsNullOrEmpty(tb_dungdiem.Text))
                        {
                            CongThucTinhDiem cttd = new CongThucTinhDiem();
                            cttd = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT1").FirstOrDefault();
                            tb_diemquydoi.Text = Convert.ToString(Convert.ToInt32(cttd.HeSo) * Convert.ToInt32(tb_dungdiem.Text));
                            if (Convert.ToInt32(tb_tongtienhang.Text) - Convert.ToInt32(tb_diemquydoi.Text) >= 0)
                            {
                                tb_tongtien.Text = Convert.ToString(Convert.ToInt32(tb_tongtienhang.Text) - Convert.ToInt32(tb_diemquydoi.Text));
                            }
                            else
                            {
                                MessageBox.Show("Điểm quy đổi không thể lớn hơn tổng tiền hàng");
                                tb_dungdiem.Clear();
                                tb_diemquydoi.Clear();
                                tb_tongtien.Text = tb_tongtienhang.Text;
                                return;
                            }


                        }
                    }
                    if (hd.TrangThai != 0)
                    {
                        if (hd.IddiemDung != null)
                        {
                            cb_dungdiem.Checked = true;
                        }
                        else
                        {
                            cb_dungdiem.Checked = false;
                        }
                    }



                }
            }
            else
            {
                tb_dungdiem.Clear();
                tb_diemquydoi.Clear();
            }


        }

        private void tb_dungdiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tabHoaDon_MouseLeave(object sender, EventArgs e)
        {
            // hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            // MessageBox.Show(tabHoaDon.SelectedTab.Name);
        }

        private void tabHoaDon_Leave(object sender, EventArgs e)
        {
            //lb_checkdungdiem.Text = "oke";
        }

        private void tabHoaDon_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void tabHoaDon_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void lbdtghdct_TextChanged(object sender, EventArgs e)
        {
            //LoadBtnQuet();
        }
        public void LoadHoaDonDatHang()
        {
            if (cbx_Loc.Text == "Đã thanh toán")
            {
                groupBox2.Text = "Hóa đã thanh toán";
                fl_DaThanhToan.Controls.Clear();

                foreach (var a in hoaDonService.GetAllHoaDon().Where(p => p.TrangThai == 1).OrderBy(x => x.MaHd).Where(x => x.Idnv == SelectNhanVien))
                {
                    Button btn1 = new Button() { Width = 80, Height = 60 };
                    btn1.Text = a.MaHd + Environment.NewLine + (a.TrangThai == 1 ? "Đã thanh toán" : "");
                    btn1.Tag = a;
                    btn1.Click += btnsender_Click;
                    btn1.ForeColor = Color.FromArgb(255, 114, 86);
                    switch (a.TrangThai)
                    {
                        case 1:
                            {
                                btn1.BackColor = Color.FromArgb(205, 201, 201);
                                break;
                            }
                    }
                    fl_DaThanhToan.Controls.Add(btn1);
                }
            }
            else if (cbx_Loc.Text == "Chờ giao")
            {
                fl_DaThanhToan.Controls.Clear();
                groupBox2.Text = "Hóa đơn chờ giao";
                foreach (var a in hoaDonService.GetAllHoaDon().Where(p => p.TrangThai == 2).OrderBy(x => x.MaHd))
                {
                    Button btn1 = new Button() { Width = 80, Height = 60 };
                    btn1.Text = a.MaHd + Environment.NewLine + (a.TrangThai == 2 ? "Chờ giao" : "");
                    btn1.Tag = a;
                    btn1.Click += btnsender_Click;
                    btn1.ForeColor = Color.FromArgb(255, 114, 86);
                    switch (a.TrangThai)
                    {
                        case 1:
                            {
                                btn1.BackColor = Color.FromArgb(205, 201, 201);
                                break;
                            }
                    }
                    fl_DaThanhToan.Controls.Add(btn1);
                }
            }
            else
            {
                groupBox2.Text = "Hóa đơn đang giao";
                fl_DaThanhToan.Controls.Clear();
                foreach (var a in hoaDonService.GetAllHoaDon().Where(p => p.TrangThai == 3).OrderBy(x => x.MaHd))
                {
                    Button btn1 = new Button() { Width = 80, Height = 60 };
                    btn1.Text = a.MaHd + Environment.NewLine + (a.TrangThai == 3 ? "Đang giao" : "");
                    btn1.Tag = a;
                    btn1.Click += btnsender_Click;
                    btn1.ForeColor = Color.FromArgb(255, 114, 86);
                    switch (a.TrangThai)
                    {
                        case 1:
                            {
                                btn1.BackColor = Color.FromArgb(205, 201, 201);
                                break;
                            }
                    }
                    fl_DaThanhToan.Controls.Add(btn1);
                }
            }
        }

        private void cbx_Loc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHoaDonDatHang();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tabtrangthaimuahang_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabtrangthaimuahang.SelectedIndex == 0)
            {
                panel_tiencoc.Visible = false;
                panel_capnhat.Visible = false;
                panel_thanhtoan.Visible = true;

            }
            else if (tabtrangthaimuahang.SelectedIndex == 1)
            {
                panel_tiencoc.Visible = true;
                panel_capnhat.Visible = true;
                panel_thanhtoan.Visible = false;

            }

            //if (dtg_HoaDonChiTiet.Visible != false)
            //{
            //    HoaDon hd = new HoaDon();
            //    hd = hoaDonService.GetAllHoaDon().Where(x => x.MaHd == tabHoaDon.SelectedTab.Name).FirstOrDefault();
            //    if (hd.TrangThai == 1)
            //    {
            //        panel_tiencoc.Visible = true;
            //        panel_capnhat.Visible = false;
            //        panel_thanhtoan.Visible = false;
            //    }
            //    else if (hd.TrangThai == 2 || hd.TrangThai == 3)
            //    {
            //        panel_tiencoc.Visible = true;
            //        panel_capnhat.Visible = true;
            //        panel_thanhtoan.Visible = false;
            //    }
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tabHoaDon.SelectedIndex >= 0)
            {
                DialogResult hoi = MessageBox.Show("Bạn có chắn chắn muốn hủy không", "Hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == hoi)
                {
                    if (string.IsNullOrEmpty(tb_diachi.Text))
                    {
                        AlertFail("Vui lòng nhập lý do hủy đơn hàng");
                        return;
                    }
                    HoaDon hd = new HoaDon();
                    hd = hoaDonService.GetAllHoaDon().Where(x => x.MaHd == tabHoaDon.SelectedTab.Name).FirstOrDefault();
                    if (hd.TrangThai != 0)
                    {
                        AlertFail("Bạn không thể hủy hóa đơn, Vui lòng chuyển về chờ thanh toán");
                        return;
                    }
                    if (Convert.ToInt32(hoaDonChiTietService.GetAllloadformsp().Where(x => x.IdHoaDon == hd.Id).Count()) > 0)
                    {
                        foreach (var x in hoaDonChiTietService.GetAllloadformsp().Where(a => a.IdHoaDon == hd.Id))
                        {
                            foreach (var v in _iChiTietSachService.GetAll().Where(z => z.Id == x.IdChiTietSach))
                            {
                                var c = hoaDonChiTietService.GetAllloadformsp().Where(a => a.IdHoaDon == hd.Id && a.IdChiTietSach == v.Id).FirstOrDefault();
                                v.SoLuong = v.SoLuong + c.SoLuong;
                                _iChiTietSachService.Update(v.Id, v);
                            }
                        }
                    }
                    hd.TrangThai = 4;
                    hd.GhiChu = tb_diachi.Text;
                    hoaDonService.Update(hd);
                    AlertSuccess("Hủy hóa đơn thành công");
                    LoadHoaDonChoThanhToan();
                    LoadHoaDonDatHang();
                    Tabhoadondcmm();
                    LoadSanphamtoFl();
                }
                else { return; }
            }
            else
            {
                AlertFail("Vui lòng chọn hóa đơn");
            }
        }
        private void AlertSuccess(string msg)
        {
            Notification dialog = new Notification();
            dialog.showAlert(msg, Color.Green);
        }
        private void AlertFail(string msg)
        {
            Notification dialog = new Notification();
            dialog.showAlert(msg, Color.Red);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
        }
        private void cbb_phuongthucthanhtoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // panel10.Visible = false;
            if (cbb_phuongthucthanhtoan.SelectedIndex == 0)
            {
                // panel10.Visible = true;
                panel_chuyenkhoan.Visible = false;
                panel_tienmat.Visible = true;

                tb_tientralai.Clear();

            }
            else if (cbb_phuongthucthanhtoan.SelectedIndex == 1)
            {
                // panel10.Visible = true;
                panel_tienmat.Visible = false;
                panel_chuyenkhoan.Visible = true;

                tb_tientralai.Clear();
            }
            else
            {
                //  panel10.Visible = true;
                tb_tientralai.Clear();
                panel_tienmat.Visible = true;
                panel_chuyenkhoan.Visible = true;

            }
        }

        private void cbb_nganhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var hd = hoaDonService.GetAllHoaDon().Where(x => x.MaHd == tabHoaDon.SelectedTab.Name).FirstOrDefault();
            //cbb_nhanvien.SelectedItem = _inhanvienService.getNhanViensFromDB().Where(x => x.Id == hd.Idnv).Select(x => x.Ma).FirstOrDefault();
            /*khach hang*/

            if (cbb_nganhang.SelectedIndex >= 0)
            {
                fl_KhachHang.Visible = false;
            }
            else
            {
                fl_KhachHang.Visible = true;
            }
            var kh = _ikhachHangService.getAll().Where(x => x.Ma == cbb_nganhang.SelectedItem).FirstOrDefault();
            if (cbb_nganhang.SelectedIndex > 0)
            {
                cb_dungdiem.Checked = false;
                tb_dungdiem.Clear();
                tb_diemquydoi.Clear();
                tb_vidiem.Text = Convert.ToString(_idiemTieuDungService.GetAll().Where(x => x.Id == kh.IddiemTieuDung).Select(x => x.SoDiem).FirstOrDefault());
            }
            else
            {
                tb_vidiem.Clear();
            }
            if (string.IsNullOrEmpty(cbb_nganhang.Text))
            {
                tb_vidiem.Clear();
            }
        }

        private void tb_chuyenkhoan_TextChanged(object sender, EventArgs e)
        {
           
            Regex regex = new Regex(@"^[0-9]*$");
            if (dtg_HoaDonChiTiet.Visible ==true)
            {
                HoaDon hd = new HoaDon();
                hd = hoaDonService.GetAllHoaDon().Where(x => x.MaHd == tabHoaDon.SelectedTab.Name).FirstOrDefault();
                if (hd.TrangThai == 0)
                {
                    if (tabtrangthaimuahang.SelectedIndex == 0)
                    {
                        if (cbb_phuongthucthanhtoan.SelectedIndex == 0)
                        {
                            if (Regex.IsMatch(tb_tienmat.Text, @"^[a-zA-Z0-9 ]*$") == false)
                            {
                                MessageBox.Show("Không được chứa ký tự đặc biệt");
                            }
                            else if (tb_tienmat.Text == "")
                            {
                                tb_tienmat.Clear();
                                tb_tientralai.Clear();
                                return;
                            }
                            else if (regex.IsMatch(tb_tienmat.Text))
                            {
                                tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_tienmat.Text) - Convert.ToInt32(tb_tongtien.Text));
                            }
                        }
                        else if (cbb_phuongthucthanhtoan.SelectedIndex == 1)
                        {

                            if (Regex.IsMatch(tb_chuyenkhoan.Text, @"^[a-zA-Z0-9 ]*$") == false)
                            {
                                MessageBox.Show("Không được chứa ký tự đặc biệt");
                            }
                            else if (tb_chuyenkhoan.Text == "")
                            {
                                tb_chuyenkhoan.Clear();
                                tb_tientralai.Clear();
                                return;
                            }
                            //else if (Regex.IsMatch(tb_chuyenkhoan.Text, @"^\d+$") == false)
                            //{
                            //    MessageBox.Show("Không được chứa chữ cái");
                            //}
                            else if (regex.IsMatch(tb_chuyenkhoan.Text))
                            {
                                tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_chuyenkhoan.Text) - Convert.ToInt32(tb_tongtien.Text));
                            }

                        }
                        else if (cbb_phuongthucthanhtoan.SelectedIndex == 2)
                        {
                            if (Regex.IsMatch(tb_tienmat.Text, @"^[a-zA-Z0-9 ]*$") == false)
                            {
                                MessageBox.Show("Không được chứa ký tự đặc biệt");
                            }
                            else if (tb_tienmat.Text == "")
                            {
                                tb_tienmat.Clear();
                                tb_tientralai.Clear();
                                return;
                            }
                            //else if (Regex.IsMatch(tb_tienmat.Text, @"^\d+$") == false)
                            //{
                            //    MessageBox.Show("Không được chứa chữ cái");
                            //}
                            else if (!string.IsNullOrEmpty(tb_chuyenkhoan.Text) && !string.IsNullOrEmpty(tb_tienmat.Text))
                            {
                                tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_tienmat.Text) - Convert.ToInt32(tb_tongtien.Text) + Convert.ToInt32(tb_chuyenkhoan.Text));
                            }
                        }
                    }
                    else if (tabtrangthaimuahang.SelectedIndex == 1)
                    {
                        if (cbb_phuongthucthanhtoan.SelectedIndex == 0)
                        {
                            if (Regex.IsMatch(tb_tienmat.Text, @"^[a-zA-Z0-9 ]*$") == false)
                            {
                                MessageBox.Show("Không được chứa ký tự đặc biệt");
                            }
                            else if (tb_tienmat.Text == "")
                            {
                                tb_tienmat.Clear();
                                tb_tientralai.Clear();
                                return;
                            }
                            //else if (Regex.IsMatch(tb_tienmat.Text, @"^\d+$") == false)
                            //{
                            //    MessageBox.Show("Không được chứa chữ cái");
                            //}
                            else if (string.IsNullOrEmpty(tbx_TienCoc.Text))
                            {
                                return;
                            }
                            else if (string.IsNullOrEmpty(tbx_TienShip.Text))
                            {
                                return;
                            }
                            else if (regex.IsMatch(tb_tienmat.Text))
                            {
                                tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_tienmat.Text) - Convert.ToInt32(tb_tongtien.Text) + Convert.ToInt32(tbx_TienCoc.Text) - Convert.ToInt32(tbx_TienShip.Text));
                            }
                        }
                        else if (cbb_phuongthucthanhtoan.SelectedIndex == 1)
                        {

                            if (Regex.IsMatch(tb_chuyenkhoan.Text, @"^[a-zA-Z0-9 ]*$") == false)
                            {
                                MessageBox.Show("Không được chứa ký tự đặc biệt");
                            }
                            else if (tb_chuyenkhoan.Text == "")
                            {
                                tb_tienmat.Clear();
                                tb_tientralai.Clear();
                                return;
                            }
                            //else if (Regex.IsMatch(tb_chuyenkhoan.Text, @"^\d+$") == false)
                            //{
                            //    MessageBox.Show("Không được chứa chữ cái");
                            //}
                            else if (string.IsNullOrEmpty(tbx_TienCoc.Text))
                            {
                                return;
                            }
                            else if (string.IsNullOrEmpty(tbx_TienShip.Text))
                            {
                                return;
                            }
                            else if (regex.IsMatch(tb_chuyenkhoan.Text))
                            {
                                tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_chuyenkhoan.Text) - Convert.ToInt32(tb_tongtien.Text) + Convert.ToInt32(tbx_TienCoc.Text) - Convert.ToInt32(tbx_TienShip.Text));
                            }

                        }
                        else if (cbb_phuongthucthanhtoan.SelectedIndex == 2)
                        {
                            if (Regex.IsMatch(tb_tienmat.Text, @"^[a-zA-Z0-9 ]*$") == false)
                            {
                                MessageBox.Show("Không được chứa ký tự đặc biệt");
                            }
                            else if (tb_tienmat.Text == "")
                            {
                                tb_tienmat.Clear();
                                tb_tientralai.Clear();
                                return;
                            }
                            //else if (Regex.IsMatch(tb_tienmat.Text, @"^\d+$") == false)
                            //{
                            //    MessageBox.Show("Không được chứa chữ cái");
                            //}
                            else if (string.IsNullOrEmpty(tbx_TienCoc.Text))
                            {
                                return;
                            }
                            else if (string.IsNullOrEmpty(tbx_TienShip.Text))
                            {
                                return;
                            }
                            else if (!string.IsNullOrEmpty(tb_chuyenkhoan.Text) && !string.IsNullOrEmpty(tb_tienmat.Text))
                            {
                                tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_tienmat.Text) + Convert.ToInt32(tb_chuyenkhoan.Text) - Convert.ToInt32(tb_tongtien.Text) + Convert.ToInt32(tbx_TienCoc.Text) - Convert.ToInt32(tbx_TienShip.Text));
                            }
                        }
                    }
                }

            }
        }

        private void tb_tienmat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_chuyenkhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_tongtien_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]*$");
            if (tabHoaDon.SelectedIndex >= 0)
            {
                HoaDon hd = new HoaDon();
                hd = hoaDonService.GetAllHoaDon().Where(x => x.MaHd == tabHoaDon.SelectedTab.Name).FirstOrDefault();
                if (hd.TrangThai != 1)
                {
                    if (tabtrangthaimuahang.SelectedIndex == 0)
                    {
                        if (cbb_phuongthucthanhtoan.SelectedIndex == 0)
                        {
                            if (Regex.IsMatch(tb_tienmat.Text, @"^[a-zA-Z0-9 ]*$") == false)
                            {
                                MessageBox.Show("Không được chứa ký tự đặc biệt");
                            }
                            else if (tb_tienmat.Text == string.Empty)
                            {
                                tb_tienmat.Clear();
                                tb_tientralai.Clear();
                                return;
                            }
                            //else if (Regex.IsMatch(tb_tienmat.Text, @"^\d+$") == false)
                            //{
                            //    MessageBox.Show("Không được chứa chữ cái");
                            //}
                            else if (string.IsNullOrEmpty(tb_tongtien.Text))
                            {
                                return;
                            }
                            else if (regex.IsMatch(tb_tienmat.Text))
                            {
                                tb_tientralai.Text = Convert.ToString(hd.TienMat - Convert.ToInt32(tb_tongtien.Text));
                            }
                        }
                        else if (cbb_phuongthucthanhtoan.SelectedIndex == 1)
                        {

                            if (Regex.IsMatch(tb_chuyenkhoan.Text, @"^[a-zA-Z0-9 ]*$") == false)
                            {
                                MessageBox.Show("Không được chứa ký tự đặc biệt");
                            }
                            else if (tb_tienmat.Text == string.Empty)
                            {
                                tb_tienmat.Clear();
                                tb_tientralai.Clear();
                                return;
                            }
                            //else if (Regex.IsMatch(tb_chuyenkhoan.Text, @"^\d+$") == false)
                            //{
                            //    MessageBox.Show("Không được chứa chữ cái");
                            //}
                            else if (string.IsNullOrEmpty(tb_tongtien.Text))
                            {
                                return;
                            }
                            else if (regex.IsMatch(tb_chuyenkhoan.Text))
                            {
                                tb_tientralai.Text = Convert.ToString(hd.TienChuyenKhoan - Convert.ToInt32(tb_tongtien.Text));
                            }

                        }
                        else if (cbb_phuongthucthanhtoan.SelectedIndex == 2)
                        {
                            if (Regex.IsMatch(tb_tienmat.Text, @"^[a-zA-Z0-9 ]*$") == false)
                            {
                                MessageBox.Show("Không được chứa ký tự đặc biệt");
                            }
                            else if (tb_tienmat.Text == string.Empty)
                            {
                                tb_tienmat.Clear();
                                tb_tientralai.Clear();
                                return;
                            }
                            //else if (Regex.IsMatch(tb_tienmat.Text, @"^\d+$") == false)
                            //{
                            //    MessageBox.Show("Không được chứa chữ cái");
                            //}
                            else if (string.IsNullOrEmpty(tb_tongtien.Text))
                            {
                                return;
                            }
                            else if (!string.IsNullOrEmpty(tb_chuyenkhoan.Text) && !string.IsNullOrEmpty(tb_tienmat.Text))
                            {
                                tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_tienmat.Text) - Convert.ToInt32(tb_tongtien.Text) + Convert.ToInt32(tb_chuyenkhoan.Text));
                            }
                        }
                    }
                    else if (tabtrangthaimuahang.SelectedIndex == 1)
                    {
                        if (cbb_phuongthucthanhtoan.SelectedIndex == 0)
                        {
                            if (Regex.IsMatch(tb_tienmat.Text, @"^[a-zA-Z0-9 ]*$") == false)
                            {
                                MessageBox.Show("Không được chứa ký tự đặc biệt");
                            }
                            else if (tb_tienmat.Text == "")
                            {
                                tb_tienmat.Clear();
                                tb_tientralai.Clear();
                                return;
                            }
                            //else if (Regex.IsMatch(tb_tienmat.Text, @"^\d+$") == false)
                            //{
                            //    MessageBox.Show("Không được chứa chữ cái");
                            //}
                            else if (string.IsNullOrEmpty(tbx_TienCoc.Text))
                            {
                                return;
                            }
                            else if (string.IsNullOrEmpty(tbx_TienShip.Text))
                            {
                                return;
                            }
                            else if (string.IsNullOrEmpty(tb_tongtien.Text))
                            {
                                return;
                            }
                            else if (regex.IsMatch(tb_tienmat.Text))
                            {
                                tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_tienmat.Text) - Convert.ToInt32(tb_tongtien.Text) + Convert.ToInt32(tbx_TienCoc.Text) - Convert.ToInt32(tbx_TienShip.Text));
                            }
                        }
                        else if (cbb_phuongthucthanhtoan.SelectedIndex == 1)
                        {

                            if (Regex.IsMatch(tb_chuyenkhoan.Text, @"^[a-zA-Z0-9 ]*$") == false)
                            {
                                MessageBox.Show("Không được chứa ký tự đặc biệt");
                            }
                            else if (tb_tienmat.Text == "")
                            {
                                tb_tienmat.Clear();
                                tb_tientralai.Clear();
                                return;
                            }
                            //else if (Regex.IsMatch(tb_chuyenkhoan.Text, @"^\d+$") == false)
                            //{
                            //    MessageBox.Show("Không được chứa chữ cái");
                            //}
                            else if (string.IsNullOrEmpty(tbx_TienCoc.Text))
                            {
                                return;
                            }
                            else if (string.IsNullOrEmpty(tbx_TienShip.Text))
                            {
                                return;
                            }
                            else if (string.IsNullOrEmpty(tb_tongtien.Text))
                            {
                                return;
                            }
                            else if (regex.IsMatch(tb_chuyenkhoan.Text))
                            {
                                tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_chuyenkhoan.Text) - Convert.ToInt32(tb_tongtien.Text) + Convert.ToInt32(tbx_TienCoc.Text) - Convert.ToInt32(tbx_TienShip.Text));
                            }

                        }
                        else if (cbb_phuongthucthanhtoan.SelectedIndex == 2)
                        {
                            if (Regex.IsMatch(tb_tienmat.Text, @"^[a-zA-Z0-9 ]*$") == false)
                            {
                                MessageBox.Show("Không được chứa ký tự đặc biệt");
                            }
                            else if (tb_tienmat.Text == "")
                            {
                                tb_tienmat.Clear();
                                tb_tientralai.Clear();
                                return;
                            }
                            //else if (Regex.IsMatch(tb_tienmat.Text, @"^\d+$") == false)
                            //{
                            //    MessageBox.Show("Không được chứa chữ cái");
                            //}
                            else if (string.IsNullOrEmpty(tbx_TienCoc.Text))
                            {
                                return;
                            }
                            else if (string.IsNullOrEmpty(tbx_TienShip.Text))
                            {
                                return;
                            }
                            else if (string.IsNullOrEmpty(tb_tongtien.Text))
                            {
                                return;
                            }
                            else if (!string.IsNullOrEmpty(tb_chuyenkhoan.Text) && !string.IsNullOrEmpty(tb_tienmat.Text))
                            {
                                tb_tientralai.Text = Convert.ToString(Convert.ToInt32(tb_tienmat.Text) + Convert.ToInt32(tbx_TienShip.Text) - Convert.ToInt32(tb_tongtien.Text) + Convert.ToInt32(tbx_TienCoc.Text) - Convert.ToInt32(tbx_TienShip.Text));
                            }
                        }
                    }

                }

            }
        }
        void LoadKhachHang()
        {

            fl_KhachHang.Controls.Clear();
            foreach (var x in _ikhachHangService.getAll().Where(x => x.Sdt.Contains(cbb_nganhang.Text)))
            {
                Button btn1 = new Button() { Width = 200, Height = 70 };
                btn1.Text = x.Ten + Environment.NewLine + "SĐT " + x.Sdt;
                btn1.ForeColor = System.Drawing.Color.FromArgb(1, 102, 207);
                btn1.BackColor = Color.FromArgb(1, 90, 90);
                btn1.TextAlign = ContentAlignment.MiddleLeft;
                btn1.Tag = x;
                btn1.ForeColor = Color.FromArgb(224, 238, 224);
                btn1.Click += ClickKhachHang;
                fl_KhachHang.Controls.Add(btn1);
            }
        }

        private void cbb_nganhang_TextChanged(object sender, EventArgs e)
        {

            if (cbb_nganhang.Text == string.Empty)
            {
                fl_KhachHang.Visible = false;
                tb_vidiem.Clear();
                cbb_nganhang.SelectedIndex = 0;
            }
            else
            {
                fl_KhachHang.Visible = true;
                LoadKhachHang();
            }
            if (_ikhachHangService.getKhachHangFromDB().Where(z => z.Sodt.Contains(cbb_nganhang.Text)).Count() == 0)
            {
                fl_KhachHang.Visible = false;
            }
            else
            {
                fl_KhachHang.Visible = true;
            }

        }
        private void ClickKhachHang(object sender, EventArgs e)
        {
            cbb_nganhang.SelectedItem = ((sender as Button).Tag as KhachHang).Ma;
            tb_diachi.Text = ((sender as Button).Tag as KhachHang).DiaChi;
            tb_sodienthoai.Text = ((sender as Button).Tag as KhachHang).Sdt;
            tb_nguoinhan.Text = ((sender as Button).Tag as KhachHang).Ten;
            fl_KhachHang.Visible = false;
        }

        private void tbt_SearchProducts_TextChanged(object sender, EventArgs e)
        {

            fl_sanpham.Controls.Clear();
            foreach (var x in _iChiTietSachService.GetAllChiTietSachView().Where(a => a.TenSach.Contains(tbt_SearchProducts.Text)).OrderBy(x => x.Ma))
            {
                var Ten = _iChiTietSachService.GetAllChiTietSachView().Where(b => b.Id == x.Id).Select(c => c.TenSach).FirstOrDefault();
                Button btn1 = new Button() { Width = 260, Height = 180 };
                btn1.Text = x.Ma + Environment.NewLine + "Tên: " + Ten + Environment.NewLine + "Gía bán:" + x.GiaBan + Environment.NewLine + "Số lượng:" + x.SoLuong;
                btn1.ForeColor = System.Drawing.Color.FromArgb(1, 102, 207);
                btn1.BackColor = Color.FromArgb(228, 241, 240);
                btn1.TextAlign = ContentAlignment.MiddleLeft;
                Image img2 = byteArrayToImage(x.Anh);
                img2 = resizeImage(img2, new Size(80, 110));
                btn1.Image = img2;
                btn1.Tag = x;
                btn1.ImageAlign = ContentAlignment.MiddleRight;
                btn1.ForeColor = Color.Black;
                btn1.Click += btnsender_Click1;
                fl_sanpham.Controls.Add(btn1);
            }

        }

        private void panel_nel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_tiencoc_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tb_tongtienhang_TextChanged(object sender, EventArgs e)
        {

            if (tabHoaDon.Visible != false)
            {
                if (cb_dungdiem.Checked == true)
                {
                    if (!string.IsNullOrEmpty(tb_dungdiem.Text))
                    {
                        tb_tongtien.Text = Convert.ToString(Convert.ToInt32(tb_tongtienhang.Text) - Convert.ToInt32(tb_diemquydoi.Text));
                    }
                }
                else if (cb_dungdiem.Checked == false)
                {
                    if (!string.IsNullOrEmpty(tb_dungdiem.Text))
                    {
                        tb_tongtien.Text = Convert.ToString(Convert.ToInt32(tb_tongtienhang.Text));
                    }
                }
            }

        }

        private void tbx_TienCoc_TextChanged(object sender, EventArgs e)
        {

            if (cbb_phuongthucthanhtoan.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(tb_tienmat.Text))
                {
                    tb_tienmat.Clear();
                }
            }
            else if (cbb_phuongthucthanhtoan.SelectedIndex == 1)
            {
                if (!string.IsNullOrEmpty(tb_chuyenkhoan.Text))
                {
                    tb_chuyenkhoan.Clear();
                }
            }
            else if (cbb_phuongthucthanhtoan.SelectedIndex == 3)
            {
                tb_tienmat.Clear();
                tb_chuyenkhoan.Clear();
            }


        }

        private void tbx_TienShip_TextChanged(object sender, EventArgs e)
        {

            if (cbb_phuongthucthanhtoan.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(tb_tienmat.Text))
                {
                    tb_tienmat.Clear();
                }
            }
            else if (cbb_phuongthucthanhtoan.SelectedIndex == 1)
            {
                if (!string.IsNullOrEmpty(tb_chuyenkhoan.Text))
                {
                    tb_chuyenkhoan.Clear();
                }
            }
            else if (cbb_phuongthucthanhtoan.SelectedIndex == 3)
            {
                tb_tienmat.Clear();
                tb_chuyenkhoan.Clear();
            }
            tb_tienmat.Clear();
            tb_chuyenkhoan.Clear();

        }

        private void ipb_AddSach_Click(object sender, EventArgs e)
        {
            Form_KhachHang kh = new Form_KhachHang();
            kh.ShowDialog();
        }

        private void dtg_HoaDonChiTiet_Click(object sender, EventArgs e)
        {

        }

        private void dtg_HoaDonChiTiet_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                HoaDon selecthd = new HoaDon();
                selecthd = hoaDonService.GetAllHoaDon().FirstOrDefault(x => x.MaHd == tabHoaDon.SelectedTab.Name);
                if (selecthd.TrangThai == 2 || selecthd.TrangThai == 3)
                {
                    ContextMenuStrip menu = new System.Windows.Forms.ContextMenuStrip();
                    int position = dtg_HoaDonChiTiet.HitTest(e.X, e.Y).RowIndex;
                    if (position >= 0)
                    {
                        menu.Items.Add("Trả hàng").Name = "Trả hàng";
                    }
                    menu.Show(dtg_HoaDonChiTiet, new Point(e.X, e.Y));
                    menu.ItemClicked += new ToolStripItemClickedEventHandler(menu_ItemCLicked);
                }

            }
        }

        private void menu_ItemCLicked(object sender, ToolStripItemClickedEventArgs e)
        {
            HoaDon selecthd = new HoaDon();
            selecthd = hoaDonService.GetAllHoaDon().FirstOrDefault(x => x.MaHd == tabHoaDon.SelectedTab.Name);
            if (selecthd.TrangThai == 2 || selecthd.TrangThai == 3)
            {
                string ctsclick = dtg_HoaDonChiTiet.CurrentRow.Cells[1].Value.ToString();
                string tenclick = dtg_HoaDonChiTiet.CurrentRow.Cells[2].Value.ToString();
                int thanhtien = Convert.ToInt32(dtg_HoaDonChiTiet.CurrentRow.Cells[7].Value.ToString());
                decimal giabanclick = Convert.ToInt32(dtg_HoaDonChiTiet.CurrentRow.Cells[6].Value.ToString());
                string Content = Interaction.InputBox($"Mã: {ctsclick}" + Environment.NewLine + $"Tên: {tenclick}" + Environment.NewLine + $"Giá bán: {giabanclick}" + Environment.NewLine + "Nhập số lượng ", "Bạn muốn thêm bao nhiêu", "1", 500, 300);//nhập số lượng ở màn bán hàng
                if (Content == string.Empty) return;
                if (Convert.ToInt32(dtg_HoaDonChiTiet.CurrentRow.Cells[7].Value.ToString()) == 0)
                {
                    return;
                }
                if (Regex.IsMatch(Content, @"^[a-zA-Z0-9 ]*$") == false)
                {

                    MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                    return;
                }
                if (Regex.IsMatch(Content, @"^\d+$") == false)
                {

                    MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                    return;
                }
                if (Content.Length > 6)
                {
                    MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                    return;
                }
                if (Convert.ToInt32(Content) <= 0)
                {
                    MessageBox.Show("Số Lượng Phải Lớn Hơn 0", "ERR");
                    return;
                }
                if (Content != null)
                {
                    DialogResult hoi = MessageBox.Show("Bạn có muốn trả hàng không", "Trả hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == hoi)
                    {

                        HoaDon hd = new HoaDon();
                        hd = hoaDonService.GetAllHoaDon().FirstOrDefault(x => x.MaHd == tabHoaDon.SelectedTab.Name);
                        ChiTietSach cts = new ChiTietSach();
                        cts = _iChiTietSachService.GetAll().FirstOrDefault(q => q.Ma == ctsclick);

                        HoaDonChiTiet hdct = new HoaDonChiTiet();

                        hdct = hoaDonChiTietService.GetAllloadformsp().Where(z => z.IdHoaDon == hd.Id && z.IdChiTietSach == cts.Id && z.ThanhTien > 5).FirstOrDefault();

                        int hdctcheck = hoaDonChiTietService.GetAllloadformsp().Where(z => z.IdHoaDon == hd.Id && z.IdChiTietSach == cts.Id && z.ThanhTien == 0).Count();

                        if (Convert.ToInt32(Content) > hdct.SoLuong)
                        {
                            MessageBox.Show("Số sách không tồn tại");
                            return;
                        }
                        else if (Convert.ToInt32(Content) == hdct.SoLuong)
                        {
                            hdct.TrangThai = 0;
                            hdct.ThanhTien = 0;
                            hoaDonChiTietService.Update(hdct);
                            if (tb_dungdiem.Text != string.Empty)
                            {
                                tb_tongtien.Text = Convert.ToString(Convert.ToInt32(tb_tongtienhang.Text) - Convert.ToInt32(tb_diemquydoi.Text));
                            }
                            else
                            {
                                tb_tongtien.Text = Convert.ToString(Convert.ToInt32(tb_tongtienhang.Text));
                            }
                            return;
                        }
                        else if (Convert.ToInt32(Content) < hdct.SoLuong)
                        {
                            //Update số lượng giao tiếp
                            hdct.SoLuong = hdct.SoLuong - Convert.ToInt32(Content);
                            hdct.TrangThai = 1;
                            hdct.ThanhTien = hdct.SoLuong * cts.GiaBan;
                            hoaDonChiTietService.Update(hdct);

                            // check hoan tra đã có hay chưa
                            if (hdctcheck > 0)
                            {
                                HoaDonChiTiet hdctupdatetrung = new HoaDonChiTiet();
                                hdctupdatetrung = hoaDonChiTietService.GetAllloadformsp().FirstOrDefault(z => z.IdHoaDon == hd.Id && z.IdChiTietSach == cts.Id && z.ThanhTien == 0);
                                hdctupdatetrung.SoLuong = hdctupdatetrung.SoLuong + Convert.ToInt32(Content);
                                hdctupdatetrung.TrangThai = 0;
                                hdctupdatetrung.ThanhTien = 0;
                                hoaDonChiTietService.Update(hdctupdatetrung);
                            }
                            else
                            {
                                // Thêm mới hàng hoàn trả
                                HoaDonChiTiet hdctnew = new HoaDonChiTiet();
                                hdctnew.Id = Guid.NewGuid();
                                hdctnew.Ma = "HDCT" + Convert.ToString(hoaDonChiTietService.GetAllloadformsp()
                                      .Max(c => Convert.ToInt32(c.Ma.Substring(4, c.Ma.Length - 4)) + 2));
                                hdctnew.IdHoaDon = hd.Id;
                                hdctnew.IdChiTietSach = cts.Id;
                                hdctnew.SoLuong = Convert.ToInt32(Content);
                                hdctnew.DonGia = Convert.ToInt32(cts.GiaBan);
                                hdctnew.ThanhTien = 0;
                                hdctnew.TrangThai = 0;
                                hoaDonChiTietService.Add(hdctnew);
                            }

                            //Cập nhật lại số lượng của sách trong kho;
                            cts.SoLuong = cts.SoLuong + Convert.ToInt32(Content);
                            cts.IdSach = cts.IdSach;
                            cts.IdNxb = cts.IdNxb;
                            cts.IdTacGia = cts.IdTacGia;
                            cts.IdNhaPhatHanh = cts.IdNhaPhatHanh;
                            cts.IdLoaiBia = cts.IdLoaiBia;
                            cts.Ma = cts.Ma;
                            cts.Anh = cts.Anh;
                            cts.MaVach = cts.MaVach;
                            cts.KichThuoc = cts.KichThuoc;
                            cts.SoTrang = cts.SoTrang;
                            cts.NamXuatBan = cts.NamXuatBan;
                            cts.MoTa = cts.MoTa;
                            cts.GiaNhap = cts.GiaNhap;
                            cts.GiaBan = cts.GiaBan;
                            _iChiTietSachService.Update(cts.Id, cts);
                            if (tb_dungdiem.Text != string.Empty)
                            {
                                int count = 0;
                                foreach (var x in hoaDonChiTietService.GetAllloadformsp().Where(x => x.IdHoaDon == hd.Id))
                                {
                                    count = count + Convert.ToInt32(x.ThanhTien);
                                }
                                hd.TongTien = Convert.ToInt32(Convert.ToInt32(count) - Convert.ToInt32(tb_diemquydoi.Text));
                            }
                            else
                            {
                                int count = 0;
                                foreach (var x in hoaDonChiTietService.GetAllloadformsp().Where(x => x.IdHoaDon == hd.Id))
                                {
                                    count = count + Convert.ToInt32(x.ThanhTien);
                                }
                                //tb_tongtienhang.Text = Convert.ToString(count);
                                hd.TongTien = Convert.ToInt32(Convert.ToInt32(count));
                            }
                            hoaDonService.Update(hd);
                        }
                        dtg_HoaDonChiTiet.Rows.Clear();
                        foreach (var x in hoaDonChiTietService.GetAll().Where(x => x.IDhoadon == hd.Id))
                        {
                            dtg_HoaDonChiTiet.Rows.Add(x.ID, x.MactSach, x.Tensach, "-", x.Soluong, "+", x.Dongia, x.Thanhtien, "X");
                        }
                        LoadSanphamtoFl();
                        Tabhoadondcmm();
                        //LoaddataToHoadonChitiet();
                    }
                }
            }

        }

        private void tb_tongtienhang_TextChanged_1(object sender, EventArgs e)
        {
            //if (tabHoaDon.SelectedIndex>=0)
            //{
            //    HoaDon hd = new HoaDon();
            //    hd = hoaDonService.GetAllHoaDon().FirstOrDefault(x=>x.MaHd==tabHoaDon.SelectedTab.Name);
            //    if (hd.TrangThai != 1)
            //    {
            //        if (cb_dungdiem.Checked == true)
            //        {
            //            tb_tongtien.Text = Convert.ToString(Convert.ToInt32(tb_tongtienhang.Text) - Convert.ToInt32(tb_diemquydoi.Text));
            //        }
            //        tb_tongtien.Text =Convert.ToString(Convert.ToInt32(tb_tongtienhang.Text));

            //    }
            //}
        }

        private void pd_HoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string TenCuaHang = "Nhà sách BeeBooks";
            string DiaChi = "Phố Trịnh Văn Bô, Nam Từ Liêm, Hà Nội";
            string Sdt = "0367180646";
            string TenHoaDon = "Hoá đơn bán hàng";
            string MaHD = tbt_MaHD.Text;
            string TenNhanVien = cbb_nhanvien.Text;
            string KhachHang = string.Empty;
            if (cbb_nganhang.Text == string.Empty) KhachHang = "Khách lẻ";
            else KhachHang = cbb_nganhang.Text;
            string TongTien = tb_tongtien.Text;
            string LoiCamOn = "Xin cảm ơn Quý khách !! Hẹn gặp lại.";
            string TienKhachDua = tb_tienmat.Text;
            string TienTraLai = tb_tientralai.Text;
            string TienChuyenKhoan = tb_chuyenkhoan.Text;
            string GiamGia = tb_diemquydoi.Text;
            var width = pd_HoaDon.DefaultPageSettings.PaperSize.Width;
            Pen blachPen = new Pen(Color.Black, 1);
            var y = 240;// toạ độ theo chiều dọc
            Point p3 = new Point(160, y + 17);
            Point p4 = new Point(width - 130, y + 17);
            e.Graphics.DrawLine(blachPen, p3, p4);

            e.Graphics.DrawString(TenCuaHang.ToUpper(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new PointF(width / 2 - 120, 40));
            e.Graphics.DrawString(String.Format("{0} - {1}", DiaChi, Sdt), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(215, 70));
            e.Graphics.DrawString(String.Format(TenHoaDon.ToUpper()), new Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new PointF(width / 2 - 110, 110));
            e.Graphics.DrawString(String.Format("Mã hoá đơn: {0}", MaHD.ToUpper()), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(160, 150));
            e.Graphics.DrawString(String.Format("Ngày: {0} ", DateTime.Now.ToString("dd/MM/yyyy HH:mm")), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(500, 150));
            e.Graphics.DrawString(String.Format("Tên nhân viên: {0}", TenNhanVien), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(160, 175));
            e.Graphics.DrawString(String.Format("Khách hàng: {0}", KhachHang), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(160, 200));


            e.Graphics.DrawString(String.Format("STT"), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(160, y));
            e.Graphics.DrawString(String.Format("Tên sản phẩm"), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(210, y));
            e.Graphics.DrawString(String.Format("Số lượng"), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(430, y));
            e.Graphics.DrawString(String.Format("Đơn giá"), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(530, y));
            e.Graphics.DrawString(String.Format("Thành tiền"), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(620, y));
            int i = 1;

            y += 22;
            foreach (var a in hoaDonChiTietService.GetAll().Where(a => a.MaHd == MaHD))
            {
                e.Graphics.DrawString(String.Format("{0}", i++), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(160, y));
                e.Graphics.DrawString(String.Format(a.Tensach), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(210, y));
                e.Graphics.DrawString(String.Format(Convert.ToString(a.Soluong)), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(430, y));
                e.Graphics.DrawString(String.Format(Convert.ToString(a.Dongia)), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(530, y));
                e.Graphics.DrawString(String.Format(Convert.ToString(a.Thanhtien)), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(620, y));
                y += 20;
            }
            y += 40;

            // cách lề trái và lề phải 10
            Point p1 = new Point(160, y);
            Point p2 = new Point(width - 130, y);
            e.Graphics.DrawLine(blachPen, p1, p2); // kẻ đường thẳng 

            //// Tổng tiền
            e.Graphics.DrawString(String.Format("Tổng tiền:      {0} VND", TongTien), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(480, y += 20));
            // Tiền khách đưa  
            //e.Graphics.DrawString(String.Format("Tiền khách đưa: {0} VND", TienKhachDua), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(450, y += 30));


            if (cbb_phuongthucthanhtoan.Text == "Tiền Mặt")
            {
                e.Graphics.DrawString(String.Format("Tiền khách đưa: {0} VND", TienKhachDua), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(480, y += 30));
            }
            else if (cbb_phuongthucthanhtoan.Text == "Chuyển khoản")
            {
                e.Graphics.DrawString(String.Format("Chuyển khoản:   {0} VND", TienChuyenKhoan), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(480, y += 30));
            }
            else if (cbb_phuongthucthanhtoan.Text == "Tiền Mặt và Chuyển khoản")
            {
                e.Graphics.DrawString(String.Format("Tiền khách đưa: {0} VND", TienKhachDua), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(480, y += 30));
                e.Graphics.DrawString(String.Format("Chuyển khoản:   {0} VND", TienChuyenKhoan), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(480, y += 30));
            }
            if (cb_dungdiem.Checked == true)
                e.Graphics.DrawString(String.Format("Giảm giá:       {0} VND", GiamGia), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(480, y += 30));

            // Tiền thối
            e.Graphics.DrawString(String.Format("Tiền trả lại:   {0} VND", TienTraLai), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(480, y += 30));
            // Xin cảm ơn
            e.Graphics.DrawString(String.Format(LoiCamOn), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(250, y += 30));

        }
        void InHoaDonTaiQuay()
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn in hoá đơn hay không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                pdd_ReviewHoaDon.Document = pd_HoaDon;
                pdd_ReviewHoaDon.ShowDialog();
            }
            if (dialogResult == DialogResult.No) return;
        }
        void InHoaDonGiaoHang()
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn in hoá đơn hay không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                pdd_ReviewHoaDon.Document = pd_HoaDonGiaoHang;
                pdd_ReviewHoaDon.ShowDialog();
            }
            if (dialogResult == DialogResult.No) return;
        }

        private void pd_HoaDonGiaoHang_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string TenCuaHang = "Nhà sách BeeBooks";
            string DiaChi = "Phố Trịnh Văn Bô, Nam Từ Liêm, Hà Nội";
            string Sdt = "0367180646";
            string TenHoaDon = "Hoá đơn bán hàng";
            string MaHD = tbt_MaHD.Text;
            string TenNhanVien = cbb_nhanvien.Text;
            string KhachHang = string.Empty;
            if (cbb_nganhang.Text == string.Empty) KhachHang = "Khách lẻ";
            else KhachHang = cbb_nganhang.Text;
            string TongTien = tb_tongtien.Text;
            string LoiCamOn = "Xin cảm ơn Quý khách !! Hẹn gặp lại.";
            string TienKhachDua = tb_tienmat.Text;
            string TienTraLai = tb_tientralai.Text;
            string TienChuyenKhoan = tb_chuyenkhoan.Text;
            string GiamGia = tb_diemquydoi.Text;
            string NguoiNhan = tb_nguoinhan.Text;
            string SdtNN = tb_sodienthoai.Text;
            string Diachi = tb_diachi.Text;
            string TienCoc = tbx_TienCoc.Text;
            string TienShip = tbx_TienShip.Text;
            var width = pd_HoaDon.DefaultPageSettings.PaperSize.Width;
            Pen blachPen = new Pen(Color.Black, 1);
            var y = 290;// toạ độ theo chiều dọc
            Point p3 = new Point(160, y + 17);
            Point p4 = new Point(width - 160, y + 17);
            e.Graphics.DrawLine(blachPen, p3, p4);

            e.Graphics.DrawString(TenCuaHang.ToUpper(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new PointF(width / 2 - 120, 40));
            e.Graphics.DrawString(String.Format("{0} - {1}", DiaChi, Sdt), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(215, 70));
            e.Graphics.DrawString(String.Format(TenHoaDon.ToUpper()), new Font("Courier New", 15, FontStyle.Bold), Brushes.Black, new PointF(width / 2 - 110, 110));
            e.Graphics.DrawString(String.Format("Mã hoá đơn: {0}", MaHD.ToUpper()), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(160, 150));
            e.Graphics.DrawString(String.Format("Ngày: {0} ", DateTime.Now.ToString("dd/MM/yyyy HH:mm")), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(450, 150));
            e.Graphics.DrawString(String.Format("Tên nhân viên: {0}", TenNhanVien), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(160, 175));
            e.Graphics.DrawString(String.Format("Khách hàng: {0}", KhachHang), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(160, 200));
            e.Graphics.DrawString(String.Format("Người nhận: {0}", NguoiNhan), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(160, 225));
            e.Graphics.DrawString(String.Format("SĐT: {0}", SdtNN), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(450, 225));
            e.Graphics.DrawString(String.Format("Địa chỉ: {0}", Diachi), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(160, 250));


            e.Graphics.DrawString(String.Format("STT"), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(160, y));
            e.Graphics.DrawString(String.Format("Tên sản phẩm"), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(210, y));
            e.Graphics.DrawString(String.Format("Số lượng"), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(430, y));
            e.Graphics.DrawString(String.Format("Đơn giá"), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(520, y));
            e.Graphics.DrawString(String.Format("Thành tiền"), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(600, y));
            int i = 1;

            y += 22;
            foreach (var a in hoaDonChiTietService.GetAll().Where(a => a.MaHd == MaHD))
            {
                e.Graphics.DrawString(String.Format("{0}", i++), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(200, y));
                e.Graphics.DrawString(String.Format(a.Tensach), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(240, y));
                e.Graphics.DrawString(String.Format(Convert.ToString(a.Soluong)), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(450, y));
                e.Graphics.DrawString(String.Format(Convert.ToString(a.Dongia)), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(550, y));
                e.Graphics.DrawString(String.Format(Convert.ToString(a.Thanhtien)), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(650, y));
                y += 20;
            }
            y += 40;

            // cách lề trái và lề phải 10
            Point p1 = new Point(160, y);
            Point p2 = new Point(width - 160, y);
            e.Graphics.DrawLine(blachPen, p1, p2); // kẻ đường thẳng 

            //// Tổng tiền
            e.Graphics.DrawString(String.Format("Tổng tiền:      {0} VND", TongTien), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(450, y += 20));
            // Tiền khách đưa  
            //e.Graphics.DrawString(String.Format("Tiền khách đưa: {0} VND", TienKhachDua), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(450, y += 30));


            if (cbb_phuongthucthanhtoan.Text == "Tiền Mặt")
            {
                e.Graphics.DrawString(String.Format("Tiền khách đưa: {0} VND", TienKhachDua), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(450, y += 30));
            }
            else if (cbb_phuongthucthanhtoan.Text == "Chuyển khoản")
            {
                e.Graphics.DrawString(String.Format("Chuyển khoản:   {0} VND", TienChuyenKhoan), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(450, y += 30));
            }
            else if (cbb_phuongthucthanhtoan.Text == "Tiền Mặt và Chuyển khoản")
            {
                e.Graphics.DrawString(String.Format("Tiền khách đưa: {0} VND", TienKhachDua), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(450, y += 30));
                e.Graphics.DrawString(String.Format("Chuyển khoản:   {0} VND", TienChuyenKhoan), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(450, y += 30));
            }
            if (cb_dungdiem.Checked == true)
                e.Graphics.DrawString(String.Format("Giảm giá:       {0} VND", GiamGia), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(450, y += 30));

            // Tiền thối
            e.Graphics.DrawString(String.Format("Tiền trả lại:   {0} VND", TienTraLai), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(450, y += 30));
            e.Graphics.DrawString(String.Format("Tiền cọc:       {0} VND", TienCoc), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(450, y += 30));
            e.Graphics.DrawString(String.Format("Phí ship:       {0} VND", TienShip), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(450, y += 30));
            // Xin cảm ơn
            e.Graphics.DrawString(String.Format(LoiCamOn), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new PointF(250, y += 30));
        }

        private void tbx_TienCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbx_TienShip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_sodienthoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbb_nganhang_MouseLeave(object sender, EventArgs e)
        {
            //fl_KhachHang.Visible = false;
        }

        private void cbb_nganhang_MouseMove(object sender, MouseEventArgs e)
        {
            //fl_KhachHang.Visible = false;
        }

        private void cbb_nganhang_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void cbb_nganhang_Leave(object sender, EventArgs e)
        {
            //fl_KhachHang.Visible = false;
        }

        private void bt_huyship_Click(object sender, EventArgs e)
        {
            if (dtg_HoaDonChiTiet.Visible == true)
            {
                DialogResult hoi = MessageBox.Show("Bạn có chắc chắn muốn hủy không", "Hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == hoi)
                {
                    if (string.IsNullOrEmpty(tb_ghichu.Text))
                    {
                        AlertFail("Vui lòng nhập ghi chú");
                        return;
                    }
                    HoaDon hd = new HoaDon();
                    hd = hoaDonService.GetAllHoaDon().FirstOrDefault(x => x.MaHd == tabHoaDon.SelectedTab.Name);
                    if (hd.Idkh != null)
                    {
                        LichSuDiemDung lsdd = new LichSuDiemDung();
                        LichSuDiemTich lsdt = new LichSuDiemTich();
                        KhachHang kh = new KhachHang();
                        DiemTieuDung dtd = new DiemTieuDung();
                        kh = _ikhachHangService.getAll().FirstOrDefault(x => x.Id == hd.Idkh);

                        lsdt = _ilichSuDiemTichService.GetAll().FirstOrDefault(x => x.Id == hd.IddiemTich);
                        dtd = _idiemTieuDungService.GetAll().FirstOrDefault(x => x.Id == kh.IddiemTieuDung);
                        if (hd.IddiemDung != null)
                        {
                            hd.IddiemDung = null;
                            hd.IddiemTich = null;
                            lsdd = _ilichSuDiemDungService.GetAll().FirstOrDefault(x => x.Id == hd.IddiemDung);
                            dtd.SoDiem = dtd.SoDiem + lsdd.SoDiemDung - lsdt.SoDiemTich;
                            _idiemTieuDungService.Update(dtd);
                            hoaDonService.Update(hd);
                            _ilichSuDiemDungService.Remove(lsdd);
                            _ilichSuDiemTichService.Remove(lsdt);

                        }
                        else if (hd.IddiemDung == null)
                        {
                            hd.IddiemDung = null;
                            hd.IddiemTich = null;
                            hoaDonService.Update(hd);
                            dtd.SoDiem = dtd.SoDiem - lsdt.SoDiemTich;
                            _idiemTieuDungService.Update(dtd);
                            _ilichSuDiemTichService.Remove(lsdt);

                        }

                    }
                    foreach (var x in hoaDonChiTietService.GetAllloadformsp().Where(a => a.IdHoaDon == hd.Id))
                    {
                        foreach (var v in _iChiTietSachService.GetAll().Where(z => z.Id == x.IdChiTietSach))
                        {
                            var c = hoaDonChiTietService.GetAllloadformsp().Where(a => a.IdHoaDon == hd.Id && a.IdChiTietSach == v.Id).FirstOrDefault();
                            v.SoLuong = v.SoLuong + c.SoLuong;
                            _iChiTietSachService.Update(v.Id, v);
                        }
                    }
                    hd.TrangThai = 4;
                    hd.GhiChu = tb_ghichu.Text;
                    hoaDonService.Update(hd);
                    AlertSuccess("Hủy thành công");
                    LoadHoaDonDatHang();
                    LoadHoaDonChoThanhToan();
                }
                else
                {
                    return;
                }    
            }
        }
    }
}
