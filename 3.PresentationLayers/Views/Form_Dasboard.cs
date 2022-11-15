﻿using _1.DAL.DomainClass;
using _2.BUS.IService;
using _2.BUS.IServices;
using _2.BUS.Serivces;
using _2.BUS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PresentationLayers.Views
{
    public partial class Form_Dasboard : Form
    {
        private IHoaDonService _ihoaDonService = new HoaDonService();
        private IHoaDonChiTietService _ihoaDonChiTietService = new HoaDonChiTietService();
        private IChiTietSachService _ichiTietSachService = new ChiTietSachService();
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public Guid SelectID { get; set; }
        public Form_Dasboard()
        {
            InitializeComponent();
            random = new Random();
            LoaddataToHoadon();
            // LoaddataToChitietHoadon();
            LoadDataToSanPham();

        }
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisabelButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
        }
        private void DisabelButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
        }
        public void LoaddataToHoadon()
        {
            int i = 1;
            dtg_hoadon.ColumnCount = 4;
            dtg_hoadon.Columns[0].Name = "STT";
            dtg_hoadon.Columns[0].Width = 50;
            dtg_hoadon.Columns[1].Name = "ID";
            dtg_hoadon.Columns[1].Visible = false;
            dtg_hoadon.Columns[2].Name = "Mã";
            dtg_hoadon.Columns[2].Width = 90;
            dtg_hoadon.Columns[3].Name = "Mã khách hàng";
            dtg_hoadon.Columns[3].Width = 120;
            dtg_hoadon.Rows.Clear();
            foreach (var x in _ihoaDonService.GetAll())
            {
                dtg_hoadon.Rows.Add(i++, x.Id, x.Mahd, x.Makh);
            }
        }
        public void LoaddataToChitietHoadon(Guid a)
        {
            int i = 1;
            dtg_hdct.ColumnCount = 9;
            dtg_hdct.Columns[1].Name = "STT";
            dtg_hdct.Columns[1].Width = 30;
            dtg_hdct.Columns[0].Name = "ID";
            dtg_hdct.Columns[1].Visible = false;
            dtg_hdct.Columns[2].Name = "Mã sách";
            dtg_hdct.Columns[3].Name = "Tên bìa";
            dtg_hdct.Columns[4].Name = "Tên Nxb";
            dtg_hdct.Columns[5].Name = "Tác giả";
            dtg_hdct.Columns[6].Name = "Số lượng";
            dtg_hdct.Columns[7].Name = "Đơn giá";
            dtg_hdct.Columns[8].Name = "Thành tiền";
            // dtg_hoadon.Columns[9].Name = "Trạng thái";
            dtg_hdct.Rows.Clear();
            foreach (var x in _ihoaDonChiTietService.GetAllbanhang(a))
            {
                dtg_hdct.Rows.Add(i++, x.ID, x.MactSach, x.tenbia, x.tennxb, x.tentg, x.Soluong, x.Dongia, x.Thanhtien);
            }

        }
        public void LoadDataToSanPham()
        {
            int stt = 1;
            dtg_sanpham.ColumnCount = 16;
            dtg_sanpham.Columns[0].Name = "STT";
            dtg_sanpham.Columns[1].Name = "Id";
            dtg_sanpham.Columns[1].Visible = false;
            dtg_sanpham.Columns[2].Name = "Sách";
            dtg_sanpham.Columns[3].Name = "NXB";
            dtg_sanpham.Columns[4].Name = "Tác giả";
            dtg_sanpham.Columns[5].Name = "NPH";
            dtg_sanpham.Columns[6].Name = "Loại bìa";
            dtg_sanpham.Columns[7].Name = "Mã";
            dtg_sanpham.Columns[8].Name = "Kích thước";
            dtg_sanpham.Columns[9].Name = "Năm xuất bản";
            dtg_sanpham.Columns[10].Name = "Mô tả";
            dtg_sanpham.Columns[11].Name = "Số trang";
            dtg_sanpham.Columns[12].Name = "Số lượng";
            dtg_sanpham.Columns[13].Name = "Giá nhập";
            dtg_sanpham.Columns[14].Name = "Giá bán";
            dtg_sanpham.Columns[15].Name = "Trạng thái";
            dtg_sanpham.Rows.Clear();
            foreach (var a in _ichiTietSachService.GetAllChiTietSachView())
            {
                dtg_sanpham.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Hết sách" : "Còn bán");
            }
        }
        private void btn_shopping_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btn_manage_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void dtg_hoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectID = Guid.Parse(Convert.ToString(dtg_hoadon.CurrentRow.Cells[1].Value.ToString()));
            LoaddataToChitietHoadon(SelectID);
        }

        private void dtg_sanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = 100;
            Guid a = Guid.Parse(Convert.ToString(dtg_sanpham.CurrentRow.Cells[1].Value.ToString()));
            var data = _ihoaDonChiTietService.GetAll().FirstOrDefault(x => x.Idchitietsp == a);
            int count = _ihoaDonChiTietService.GetAll().Count;
            if (data == null)
            {
                var add = new HoaDonChiTiet();
                add.Id = Guid.NewGuid();
                add.IdHoaDon = SelectID;
                add.IdChiTietSach = Guid.Parse(Convert.ToString(dtg_sanpham.CurrentRow.Cells[1].Value.ToString()));
                add.Ma = Convert.ToString(dtg_hoadon.CurrentRow.Cells[2].Value.ToString() + "" + Convert.ToString(count++));
                add.SoLuong = 1;
                add.DonGia = Convert.ToInt32(dtg_sanpham.CurrentRow.Cells[14].Value);
                add.ThanhTien = Convert.ToInt32(1 * Convert.ToInt32(dtg_sanpham.CurrentRow.Cells[14].Value));
                _ihoaDonChiTietService.Add(add);
            }
            else
            {
                var add = new HoaDonChiTiet();
                add.SoLuong++;
                add.ThanhTien = data.Soluong * data.Dongia;
                _ihoaDonChiTietService.Update(add);
            }
          //  LoaddataToHoadon();
            LoaddataToChitietHoadon(SelectID);
        }

        private void bt_taohoadon_Click(object sender, EventArgs e)
        {
            Guid a = Guid.NewGuid();
            var hoadon = new HoaDon();
            hoadon.Id = a;
            int count = _ihoaDonService.GetAll().Count + 666;
            hoadon.Idkh = Guid.Parse("b118fa3c-d95d-49c9-bb95-2720e280a0b4");
            hoadon.Idnv = Guid.Parse("afe66273-5235-4868-9f42-b65daa741f4a");
            hoadon.IddiemTich = Guid.Parse("b7a6a7b7-e65b-42fb-a771-819f1df4787e");
            hoadon.IddiemDung = Guid.Parse("50a3d851-bfef-4878-8e15-b7539e63a51d");
            hoadon.MaHd = Convert.ToString("HDTest" + "" + Convert.ToString(count + 10));
            _ihoaDonService.Add(hoadon);

            var hdct = new HoaDonChiTiet();
            hdct.Id = Guid.NewGuid();
            hdct.IdHoaDon = a;
            hdct.IdChiTietSach = Guid.Parse("74063671-cf31-4b50-94e5-09dfc62b9c5b");
            int count1 = _ihoaDonChiTietService.GetAll().Count + 100;
            hdct.Ma = Convert.ToString("HDCTTest" + Convert.ToString(count1));
            hdct.SoLuong = 1;
            _ihoaDonChiTietService.Add(hdct);

           // LoaddataToHoadon();
            LoaddataToChitietHoadon(a);

        }
    }
}
