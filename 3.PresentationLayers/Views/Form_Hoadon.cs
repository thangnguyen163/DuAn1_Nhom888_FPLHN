using _1.DAL.DomainClass;
using _2.BUS.IServices;
using _2.BUS.Serivces;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PresentationLayers.Views
{
    public partial class Form_Hoadon : Form
    {
        IHoaDonService _ihoaDonService;
        IHoaDonChiTietService _ihoaDonCTService;
        IKhachHangService _iKhachHangService;
        INhanVienService _iNhanVienService;
        IPhuongThucThanhToanService _iPTTTService;
        public Guid SelectID { get; set; }
        public Form_Hoadon()
        {
            InitializeComponent();
            _ihoaDonService = new HoaDonService();
            _ihoaDonCTService = new HoaDonChiTietService();
            _iKhachHangService = new KhachHangService();
            _iNhanVienService = new NhanVienService();
            _iPTTTService = new PhuongThucThanhToanService();
            LoadCbb();
            rdb_all.Checked = true;
            rdb_all1.Checked = true;
            LoadDataToHD(_ihoaDonService.GetAllHoaDon().OrderBy(c => c.MaHd).ToList());
            LoadDataToHDCT(_ihoaDonCTService.GetAll().OrderBy(c => c.MaHd).ToList());

        }

        public void LoadCbb()
        {
            cbb_manv.Items.Clear();
            cbb_manv.Items.Add("--Lọc--");
            foreach (var x in _iNhanVienService.getNhanViensFromDB().OrderBy(c => c.Ma))
            {
                cbb_manv.Items.Add(x.Ma);
            }
            cbb_manv.SelectedIndex = 0;

            cbb_locmahdct.Items.Clear();
            cbb_locmahdct.Items.Add("--Lọc--");
            foreach (var x in _iNhanVienService.getNhanViensFromDB().OrderBy(c => c.Ma))
            {
                cbb_locmahdct.Items.Add(x.Ma);
            }
            cbb_locmahdct.SelectedIndex = 0;
        }
        public void LoadDataToHD(List<HoaDon> lst)
        {

            int stt = 1;
            dtg_hd.Rows.Clear();
            dtg_hd.ColumnCount = 16;
            dtg_hd.Columns[0].Name = "STT";
            dtg_hd.Columns[1].Name = "ID";
            dtg_hd.Columns[1].Visible = false;
            dtg_hd.Columns[2].Name = "Mã hóa đơn";
            dtg_hd.Columns[3].Name = "Mã khách hàng";
            dtg_hd.Columns[4].Name = "Mã nhân viên";
            dtg_hd.Columns[5].Name = "Phương thức thanh toán";
            dtg_hd.Columns[6].Name = "Ngày tạo";
            dtg_hd.Columns[7].Name = "Ngày ship";
            dtg_hd.Columns[8].Name = "Tiền cọc";
            dtg_hd.Columns[9].Name = "Tiền ship";
            dtg_hd.Columns[10].Name = "Địa chỉ";
            dtg_hd.Columns[11].Name = "Tổng tiền";
            dtg_hd.Columns[12].Name = "Tiền mặt";
            dtg_hd.Columns[13].Name = "Tiền chuyển khoản";
            dtg_hd.Columns[14].Name = "Ghi chú";
            dtg_hd.Columns[15].Name = "Trạng thái";
            foreach (var x in lst)
            {
                var a = _iKhachHangService.getAll().Where(c => c.Id == x.Idkh).Select(c => c.Ma).FirstOrDefault();
                var b = _iNhanVienService.getNhanViensFromDB().FirstOrDefault(c => c.Id == x.Idnv);
                var c = _iPTTTService.GetAllNoView().Where(c => c.Id == x.IdphuongThucThanhToan).Select(c => c.Ten).FirstOrDefault();
                dtg_hd.Rows.Add(stt++, x.Id, x.MaHd, a == null ? "Vãng lai" : a, b.Ma, c, x.NgayTao, x.NgayShip, x.TienCoc, x.TienShip, x.DiaChi, x.TongTien, x.TienMat, x.TienChuyenKhoan, x.GhiChu, x.TrangThai == 0 ? "Chưa thanh toán" :x.TrangThai==1 ?"Đã thanh toán": x.TrangThai==2 ? "Chờ giao":"Đang giao");
            }
            dtg_hd.AllowUserToAddRows = false;
        }
        public void LoadDataToHDCT(List<HoaDonChiTietView> lst)
        {
            int stt = 1;
            dtg_hdct.Rows.Clear();
            dtg_hdct.ColumnCount = 11;
            dtg_hdct.Columns[0].Name = "STT";
            dtg_hdct.Columns[1].Name = "ID";
            dtg_hdct.Columns[1].Visible = false;
            dtg_hdct.Columns[2].Name = "Mã hóa đơn";
            dtg_hdct.Columns[3].Name = "Mã hóa đơn chi tiết";
            dtg_hdct.Columns[4].Name = "Mã nhân viên";
            dtg_hdct.Columns[5].Name = "Mã chi tiết sách";
            dtg_hdct.Columns[6].Name = "Đơn giá";
            dtg_hdct.Columns[7].Name = "Số lượng";
            dtg_hdct.Columns[8].Name = "Giảm giá";
            dtg_hdct.Columns[9].Name = "Thành tiền";
            dtg_hdct.Columns[10].Name = "Trạng thái";
            foreach (var x in lst)
            {
                var NV = _iNhanVienService.getNhanViensFromDB().FirstOrDefault(c => c.Id == x.Idnv);
                dtg_hdct.Rows.Add(stt++, x.ID, x.MaHd, x.Ma, NV.Ma, x.MactSach, x.Dongia, x.Soluong, x.GiamGia, x.Thanhtien, x.Trangthai == 0 ? "Chưa thanh toán" : "Đã thanh toán");
            }
            dtg_hdct.AllowUserToAddRows = false;
        }
        public void LoadDataToHDCT_HD(List<HoaDonChiTietView> lst)
        {
            int stt = 1;
            dtg_hdct1.Rows.Clear();
            dtg_hdct1.ColumnCount = 11;
            dtg_hdct1.Columns[0].Name = "STT";
            dtg_hdct1.Columns[1].Name = "ID";
            dtg_hdct1.Columns[1].Visible = false;
            dtg_hdct1.Columns[2].Name = "Mã hóa đơn";
            dtg_hdct1.Columns[3].Name = "Mã hóa đơn chi tiết";
            dtg_hdct1.Columns[4].Name = "Mã nhân viên";
            dtg_hdct1.Columns[5].Name = "Mã chi tiết sách";
            dtg_hdct1.Columns[6].Name = "Đơn giá";
            dtg_hdct1.Columns[7].Name = "Số lượng";
            dtg_hdct1.Columns[8].Name = "Giảm giá";
            dtg_hdct1.Columns[9].Name = "Thành tiền";
            dtg_hdct1.Columns[10].Name = "Trạng thái";
            foreach (var x in lst)
            {
                var NV = _iNhanVienService.getNhanViensFromDB().FirstOrDefault(c => c.Id == x.Idnv);
                dtg_hdct1.Rows.Add(stt++, x.ID, x.MaHd, x.Ma, NV.Ma, x.MactSach, x.Dongia, x.Soluong, x.GiamGia, x.Thanhtien, x.Trangthai == 0 ? "Chưa thanh toán" : "Đã thanh toán");
            }
            dtg_hdct1.AllowUserToAddRows = false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadDataToHDCT(_ihoaDonCTService.GetAll().Where(c => c.MaHd.ToLower().Contains(textBox1.Text.ToLower()) || c.Ma.ToLower().Contains(textBox1.Text.ToLower())).ToList());
        }

        private void dtp_time_ValueChanged(object sender, EventArgs e)
        {
            LoadDataToHD(_ihoaDonService.GetAllHoaDon().Where(c => c.NgayTao.Value.Date == Convert.ToDateTime(dtp_time.Value).Date).ToList());
        }

        private void tb_giamin_TextChanged(object sender, EventArgs e)
        {
            if (tb_giamin.Text != string.Empty && tb_giamax.Text != string.Empty)
            {
                LoadDataToHD(_ihoaDonService.GetAllHoaDon().Where(c => c.TongTien >= Convert.ToDecimal(tb_giamin.Text) && c.TongTien <= Convert.ToDecimal(tb_giamax.Text)).ToList());
            }
            if (tb_giamin.Text == string.Empty || tb_giamax.Text == string.Empty)
            {
                LoadDataToHD(_ihoaDonService.GetAllHoaDon().OrderBy(c => c.MaHd).ToList());
            }
        }

        private void tb_giamax_TextChanged(object sender, EventArgs e)
        {
            if (tb_giamin.Text != string.Empty && tb_giamax.Text != string.Empty)
            {
                LoadDataToHD(_ihoaDonService.GetAllHoaDon().Where(c => c.TongTien >= Convert.ToDecimal(tb_giamin.Text) && c.TongTien <= Convert.ToDecimal(tb_giamax.Text)).ToList());
            }
            if (tb_giamin.Text == string.Empty || tb_giamax.Text == string.Empty)
            {
                LoadDataToHD(_ihoaDonService.GetAllHoaDon().OrderBy(c => c.MaHd).ToList());
            }
        }

        private void cbb_manv_TextChanged(object sender, EventArgs e)
        {
            if (cbb_manv.Text == "--Lọc--")
            {
                LoadDataToHD(_ihoaDonService.GetAllHoaDon().OrderBy(c => c.MaHd).ToList());
                return;
            }
            var b = _iNhanVienService.getNhanViensFromDB().Where(c => c.Ma == cbb_manv.Text).Select(c => c.Id).FirstOrDefault();
            LoadDataToHD(_ihoaDonService.GetAllHoaDon().Where(c => c.Idnv == b).ToList());
        }
        private void tb_searchma_TextChanged(object sender, EventArgs e)
        {
            LoadDataToHD(_ihoaDonService.GetAllHoaDon().Where(c => c.MaHd.ToLower().Contains(tb_searchma.Text.ToLower())).ToList());
        }
        private void rdb_datt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_datt.Checked == true) LoadDataToHDCT(_ihoaDonCTService.GetAll().Where(c => c.Trangthai == 1).ToList());
        }
        private void rdb_chuatt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_chuatt.Checked == true) LoadDataToHDCT(_ihoaDonCTService.GetAll().Where(c => c.Trangthai == 0).ToList());
        }
        private void rdb_all_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_all.Checked == true) LoadDataToHDCT(_ihoaDonCTService.GetAll().ToList());
        }
        private void tb_giamax2_TextChanged(object sender, EventArgs e)
        {
            if (tb_giamin2.Text != string.Empty && tb_giamax2.Text != string.Empty)
            {
                LoadDataToHDCT(_ihoaDonCTService.GetAll().Where(c => c.Thanhtien >= Convert.ToDecimal(tb_giamin2.Text) && c.Thanhtien <= Convert.ToDecimal(tb_giamax2.Text)).ToList());
            }
            if (tb_giamin2.Text == string.Empty || tb_giamax2.Text == string.Empty)
            {
                LoadDataToHDCT(_ihoaDonCTService.GetAll().ToList());
            }
        }

        private void tb_giamin2_TextChanged_1(object sender, EventArgs e)
        {
            if (tb_giamin2.Text != string.Empty && tb_giamax2.Text != string.Empty)
            {
                LoadDataToHDCT(_ihoaDonCTService.GetAll().Where(c => c.Thanhtien >= Convert.ToDecimal(tb_giamin2.Text) && c.Thanhtien <= Convert.ToDecimal(tb_giamax2.Text)).ToList());
            }
            if (tb_giamin2.Text == string.Empty || tb_giamax2.Text == string.Empty)
            {
                LoadDataToHDCT(_ihoaDonCTService.GetAll().ToList());
            }
        }

        private void rdb_all1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_all1.Checked == true) LoadDataToHD(_ihoaDonService.GetAllHoaDon().ToList());
        }

        private void rdb_datt1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_datt1.Checked == true) LoadDataToHD(_ihoaDonService.GetAllHoaDon().Where(c => c.TrangThai == 1).ToList());
        }

        private void rdb_chuatt1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_chuatt1.Checked == true) LoadDataToHD(_ihoaDonService.GetAllHoaDon().Where(c => c.TrangThai == 0).ToList());
        }

        private void dtg_hd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            SelectID = Guid.Parse(dtg_hd.CurrentRow.Cells[1].Value.ToString());
            LoadDataToHDCT_HD(_ihoaDonCTService.GetAll().Where(c => c.IDhoadon == SelectID).ToList());
        }
        private void cbb_locmahdct_TextChanged(object sender, EventArgs e)
        {
            if (cbb_locmahdct.Text == "--Lọc--")
            {
                LoadDataToHDCT(_ihoaDonCTService.GetAll().OrderBy(c => c.MaHd).ToList());
                return;
            }
            var b = _iNhanVienService.getNhanViensFromDB().Where(c => c.Ma == cbb_locmahdct.Text).Select(c => c.Id).FirstOrDefault();
            LoadDataToHDCT(_ihoaDonCTService.GetAll().Where(c => c.Idnv == b).ToList());
        }
    }
}
