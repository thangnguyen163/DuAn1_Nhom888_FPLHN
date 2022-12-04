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
        public Form_Hoadon()
        {
            InitializeComponent();
            _ihoaDonService = new HoaDonService();
            _ihoaDonCTService = new HoaDonChiTietService();
            LoadDataToHD(_ihoaDonService.GetAll().OrderBy(c => c.Mahd).ToList());
            LoadDataToHDCT(_ihoaDonCTService.GetAll().OrderBy(c => c.MaHd).ToList());
        }

        public void LoadDataToHD(List<HoadonView> lst)
        {
            int stt = 1;
            dtg_hd.Rows.Clear();
            dtg_hd.ColumnCount = 20;
            dtg_hd.Columns[0].Name = "STT";
            dtg_hd.Columns[1].Name = "ID";
            dtg_hd.Columns[1].Visible = false;
            dtg_hd.Columns[2].Name= "Mã hóa đơn";
            dtg_hd.Columns[3].Name= "Mã khách hàng";
            dtg_hd.Columns[4].Name= "Mã nhân viên";
            dtg_hd.Columns[5].Name= "Điểm tích";
            dtg_hd.Columns[6].Name= "Điểm dùng";
            dtg_hd.Columns[7].Name= "Phương thức thanh toán";
            dtg_hd.Columns[8].Name= "Ngày tạo";
            dtg_hd.Columns[9].Name= "Ngày ship";
            dtg_hd.Columns[10].Name= "Tiền cọc";
            dtg_hd.Columns[11].Name= "Tiền ship";
            dtg_hd.Columns[12].Name= "Địa chỉ";
            dtg_hd.Columns[13].Name= "Thuế";
            dtg_hd.Columns[14].Name= "Giảm giá";
            dtg_hd.Columns[15].Name = "Tổng tiền";
            dtg_hd.Columns[16].Name= "Tiền mặt";
            dtg_hd.Columns[17].Name= "Tiền chuyển khoản";
            dtg_hd.Columns[18].Name= "Ghi chú";
            dtg_hd.Columns[19].Name= "Trạng thái";
            foreach (var x in lst)
            {
                dtg_hd.Rows.Add(stt++, x.Id,x.Mahd, x.Makh, x.Manv, x.sodiemtich, x.Sodiemdung, x.TenPTTT, x.Ngaytao, x.NgayShip, x.tiencoc, x.tienship, x.DiaChi, x.Thue, x.Giamgia, x.tongtien, x.TienMat, x.TienCK, x.ghichu, x.Trangthai == 0 ? "Chưa thanh toán" : "Đã thanh toán");
            }
            dtg_hd.AllowUserToAddRows = false;
        }
        public void LoadDataToHDCT(List<HoaDonChiTietView> lst)
        {
            int stt = 1;
            dtg_hdct.Rows.Clear();
            dtg_hdct.ColumnCount = 10;
            dtg_hdct.Columns[0].Name = "STT";
            dtg_hdct.Columns[1].Name = "ID";
            dtg_hdct.Columns[1].Visible=false;
            dtg_hdct.Columns[2].Name = "Mã hóa đơn";
            dtg_hdct.Columns[3].Name = "Mã hóa đơn chi tiết";
            dtg_hdct.Columns[4].Name = "Mã chi tiết sách";
            dtg_hdct.Columns[5].Name = "Đơn giá";
            dtg_hdct.Columns[6].Name = "Số lượng";
            dtg_hdct.Columns[7].Name = "Giảm giá";
            dtg_hdct.Columns[8].Name = "Thành tiền";
            dtg_hdct.Columns[9].Name = "Trạng thái";
            foreach (var x in lst)
            {
                dtg_hdct.Rows.Add(stt++, x.ID, x.MaHd, x.Ma, x.MactSach, x.Dongia, x.Soluong, x.GiamGia, x.Thanhtien, x.Trangthai == 0 ? "Chưa thanh toán" : "Đã thanh toán");
            }
            dtg_hdct.AllowUserToAddRows = false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadDataToHDCT(_ihoaDonCTService.GetAll().Where(c=>c.MaHd.ToLower().Contains(textBox1.Text.ToLower())).ToList());
        }

        private void dtp_time_ValueChanged(object sender, EventArgs e)
        {
            LoadDataToHD(_ihoaDonService.GetAll().Where(c => c.Ngaytao.Value.Date == Convert.ToDateTime(dtp_time.Value).Date).ToList());
        }
    }
}
