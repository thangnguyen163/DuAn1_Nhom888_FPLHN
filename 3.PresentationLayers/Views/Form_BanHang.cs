using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using _2.BUS.IService;
using _2.BUS.IServices;
using _2.BUS.Serivces;
using _2.BUS.Service;
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
    public partial class Form_BanHang : Form
    {
        private IHoaDonService hoaDonService;
        private IChiTietSachService _iChiTietSachService;

        private ISachService sachService;
        private IHoaDonChiTietService hoaDonChiTietService;
        
        public Form_BanHang()
        {
            InitializeComponent();
            hoaDonService = new HoaDonService();
            _iChiTietSachService = new ChiTietSachService();
            sachService = new SachService();
            hoaDonChiTietService = new HoaDonChiTietService();
            LoadSach();
            LoadHoaDonChoThanhToan();
            LoadHoaDonDaThanhToan();
        }


        public void LoadSach()
        {
            int stt = 0;
            dtg_SanPham.ColumnCount = 16;
            dtg_SanPham.Columns[0].Name = "STT";
            dtg_SanPham.Columns[1].Name = "Id";
            dtg_SanPham.Columns[1].Visible = false;
            dtg_SanPham.Columns[2].Name = "Sách";
            dtg_SanPham.Columns[3].Name = "NXB";
            dtg_SanPham.Columns[4].Name = "Tác giả";
            dtg_SanPham.Columns[5].Name = "NPH";
            dtg_SanPham.Columns[6].Name = "Loại bìa";
            dtg_SanPham.Columns[7].Name = "Mã";
            dtg_SanPham.Columns[8].Name = "Kích thước";
            dtg_SanPham.Columns[9].Name = "Năm xuất bản";
            dtg_SanPham.Columns[10].Name = "Mô tả";
            dtg_SanPham.Columns[11].Name = "Số trang";
            dtg_SanPham.Columns[12].Name = "Số lượng";
            dtg_SanPham.Columns[13].Name = "Giá nhập";
            dtg_SanPham.Columns[14].Name = "Giá bán";
            dtg_SanPham.Columns[15].Name = "Trạng thái";
            dtg_SanPham.Rows.Clear();
            foreach (var a in _iChiTietSachService.GetAllChiTietSachView())
            {
                dtg_SanPham.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Hết sách" : "Còn bán");
            }
        }

        public void LoadHoaDonChoThanhToan()
        {
            try
            {
                fl_ChuaThanhToan.Controls.Clear();
                foreach (var a in hoaDonService.GetAll().Where(p => p.Trangthai == 0))
                {
                    Button btn = new Button() { Width = 80, Height = 80 };
                    fl_ChuaThanhToan.Controls.Add(btn);

                    btn.Text = a.Mahd + Environment.NewLine + (a.Trangthai == 1 ? "Đã thanh toán" : "Chưa thanh toán");
                    btn.Tag = a;
                    
                    btn.ForeColor = Color.White;
                    switch (a.Trangthai)
                    {
                        case 0:
                            {
                                btn.BackColor = Color.DarkRed;
                                break;
                            }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ");
                return;
            }


        }
        private void btnsender_Click(object sender, EventArgs e)
        {
            Guid id = ((sender as Button).Tag as HoaDon).Id;
            MessageBox.Show(Convert.ToString(id));
        }
        public void LoadHoaDonDaThanhToan()
        {
            try
            {
                fl_DaThanhToan.Controls.Clear();
                foreach (var a in hoaDonService.GetAllHoaDon().Where(p => p.TrangThai == 1))
                {
                    Button btn1 = new Button() { Width = 80, Height = 60 };
                    

                    btn1.Text = a.MaHd + Environment.NewLine + (a.TrangThai == 1 ? "Đã thanh toán" : "Chưa thanh toán");
                    btn1.Tag = a;
                    btn1.Click += btnsender_Click;
                    btn1.ForeColor = Color.Blue;
                    switch (a.TrangThai)
                    {
                        case 0:
                            {
                                btn1.BackColor = Color.Green;
                                break;
                            }
                    }
                    fl_DaThanhToan.Controls.Add(btn1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ");
                return;
            }


        }
        public void LoadHoaDon()
        {
            int i = 1;
            dtg_HoaDon.Rows.Clear();
            dtg_HoaDon.ColumnCount = 13;
            dtg_HoaDon.Columns[0].Name = "STT";
            dtg_HoaDon.Columns[1].Name = "ID";
            dtg_HoaDon.Columns[2].Name = "IDKH";
            dtg_HoaDon.Columns[3].Name = "IDNV";
            dtg_HoaDon.Columns[4].Name = "DIEMTICH";
            dtg_HoaDon.Columns[5].Name = "DIENDUNG";
            dtg_HoaDon.Columns[6].Name = "MAHD";
            dtg_HoaDon.Columns[7].Name = "NGAYTAO";
            dtg_HoaDon.Columns[8].Name = "THUE";
            dtg_HoaDon.Columns[9].Name = "GIAMGIA";
            dtg_HoaDon.Columns[10].Name = "TONGTIEN";
            dtg_HoaDon.Columns[11].Name = "GHICHU";
            dtg_HoaDon.Columns[12].Name = "TRANGTHAI";
            foreach(var x in hoaDonService.GetAll())
            {
                dtg_HoaDon.Rows.Add(i++,x.Id,x.Mahd,x.Manv,x.sodiemtich,x.Sodiemdung,x.Mahd,x.Ngaytao,x.Thue,x.Giamgia,x.tongtien,x.ghichu,x.Trangthai==0?"Chưa thanh toán" :"Đã thanh toán");
            }

        }

        public void LoadHoaDonChiTiet()
        {
            
        }

        private void dtg_SanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //int i = 100;
            //Guid a = Guid.Parse(Convert.ToString(dtg_sanpham.CurrentRow.Cells[1].Value));
            //var data = _ihoaDonChiTietService.GetAll().FirstOrDefault(x => x.Idchitietsp == a);
            //int count = _ihoaDonChiTietService.GetAll().Count;
            //if (data == null)
            //{
            //    var add = new HoaDonChiTiet();
            //    add.Id = Guid.NewGuid();
            //    add.IdHoaDon = SelectID;
            //    add.IdChiTietSach = Guid.Parse(Convert.ToString(dtg_sanpham.CurrentRow.Cells[1].Value));
            //    add.Ma = Convert.ToString(dtg_hoadon.CurrentRow.Cells[2].Value.ToString() + "" + Convert.ToString(count++));
            //    add.SoLuong = 1;
            //    add.DonGia = Convert.ToInt32(dtg_sanpham.CurrentRow.Cells[14].Value);
            //    add.ThanhTien = Convert.ToInt32(1 * Convert.ToInt32(dtg_sanpham.CurrentRow.Cells[14].Value));
            //    _ihoaDonChiTietService.Add(add);
            //}
            //else
            //{
            //    var add = new HoaDonChiTiet();
            //    add.SoLuong++;
            //    add.ThanhTien = add.SoLuong * add.DonGia;
            //    _ihoaDonChiTietService.Update(add);
            //}
            //// LoaddataToHoadon();
            //LoaddataToChitietHoadon(SelectID);
        }

        private void btn_taohoadon_Click(object sender, EventArgs e)
        {

            
            TabPage tpage = new TabPage();
            tabHoaDon.TabPages.Add(tpage);

            DialogResult dialogResult = MessageBox.Show("Bạn muốn tạo hóa đơn chứ", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                HoaDon hd = new HoaDon();
                hd.Id = Guid.NewGuid();
                hd.MaHd = "HD" + "" + Convert.ToString(hoaDonService.GetAll().Count + 1);

                hd.Idnv = Guid.Parse("8f6fdc53-1d3a-403f-8074-28ebf0f6405f");
                hd.Idkh = Guid.Parse("56303832-7163-464a-99a8-72973ed09c21");
                MessageBox.Show(hoaDonService.Add(hd));
                tpage.Text = Convert.ToString(hd.MaHd);
                tpage.Name = Convert.ToString(hd.MaHd);
                tabHoaDon.SelectedIndex = tabHoaDon.TabCount;
            }
            LoadHoaDonChoThanhToan();
        }

      
    }
}
