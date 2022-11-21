using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using _2.BUS.IService;
using _2.BUS.IServices;
using _2.BUS.Serivces;
using _2.BUS.Service;
using Microsoft.VisualBasic;
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
        private INhanVienService _inhanvienService;
        private IKhachHangService _ikhachHangService;
        private ISachService sachService;
        private IHoaDonChiTietService hoaDonChiTietService;
        public Guid SelectID { get; set; }
        private HoaDonChiTiet hoaDonChiTiet;


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

        
        private void btnsender_Click(object sender, EventArgs e)
        {
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
            int count=0;
            for (int i = 0; i < tabHoaDon.TabCount; i++)
            {
                
                if (hd.MaHd == tabHoaDon.TabPages[i].Name)
                {
                    count =1;
                    tabHoaDon.SelectedTab = tabHoaDon.TabPages[i];
                    break;
                }    
                   
            }
            if (count==0)
            {
                int dem = tabHoaDon.TabCount;
                TabPage tpage = new TabPage();
                    tabHoaDon.TabPages.Add(tpage);
                    tpage.Text = Convert.ToString(hd.MaHd);
                    tpage.Name = Convert.ToString(hd.MaHd);
                    
                tabHoaDon.SelectedTab = tabHoaDon.TabPages[dem];
            }         
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
                    btn1.ForeColor = Color.FromArgb(255, 114, 86);
                    switch (a.TrangThai)
                    {
                        case 1:
                            {
                                btn1.BackColor = Color.FromArgb(205, 201 ,201);
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
        public void LoadHoaDonChoThanhToan()
        {
            try
            {
                fl_ChuaThanhToan.Controls.Clear();
                foreach (var a in hoaDonService.GetAllHoaDon().Where(p => p.TrangThai == 0))
                {
                    Button btn1 = new Button() { Width = 80, Height = 60 };
                    btn1.Text = a.MaHd + Environment.NewLine + (a.TrangThai == 0 ? "Chờ thanh toán" : "Chưa thanh toán");
                    btn1.Tag = a;
                    btn1.Click += btnsender_Click;
                    btn1.ForeColor = Color.FromArgb(224, 238 ,224);
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
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ");
                return;
            }
        }
        public void LoadHoaDon()
        {
            //int i = 1;
            //dtg_HoaDon.Rows.Clear();
            //dtg_HoaDon.ColumnCount = 13;
            //dtg_HoaDon.Columns[0].Name = "STT";
            //dtg_HoaDon.Columns[1].Name = "ID";
            //dtg_HoaDon.Columns[2].Name = "IDKH";
            //dtg_HoaDon.Columns[3].Name = "IDNV";
            //dtg_HoaDon.Columns[4].Name = "DIEMTICH";
            //dtg_HoaDon.Columns[5].Name = "DIENDUNG";
            //dtg_HoaDon.Columns[6].Name = "MAHD";
            //dtg_HoaDon.Columns[7].Name = "NGAYTAO";
            //dtg_HoaDon.Columns[8].Name = "THUE";
            //dtg_HoaDon.Columns[9].Name = "GIAMGIA";
            //dtg_HoaDon.Columns[10].Name = "TONGTIEN";
            //dtg_HoaDon.Columns[11].Name = "GHICHU";
            //dtg_HoaDon.Columns[12].Name = "TRANGTHAI";
            //foreach(var x in hoaDonService.GetAll())
            //{
            //    dtg_HoaDon.Rows.Add(i++,x.Id,x.Mahd,x.Manv,x.sodiemtich,x.Sodiemdung,x.Mahd,x.Ngaytao,x.Thue,x.Giamgia,x.tongtien,x.ghichu,x.Trangthai==0?"Chưa thanh toán" :"Đã thanh toán");
            //}

        }

        public void LoadHoaDonChiTiet()
        {
            
        }

        private void dtg_SanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //// LoaddataToHoadon();
            //LoaddataToChitietHoadon(SelectID);
            Guid a = Guid.Parse(Convert.ToString(dtg_SanPham.CurrentRow.Cells[1].Value));
            var data = hoaDonChiTietService.GetAll().FirstOrDefault(x => x.Idchitietsp == a);
            string Content = Interaction.InputBox("Nhập số lượng ", "", "", 500, 300);   //nhập số lượng ở màn bán hàng 
            if (data == null)
            {
                hoaDonChiTietService.Add(new HoaDonChiTiet()
                {
                    Id = Guid.NewGuid(),
                    IdHoaDon = SelectID,
                    IdChiTietSach = a,
                    Ma = "HDCT" + Convert.ToString(hoaDonChiTietService.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(4, c.Ma.Length - 4)) + 1)),
                    SoLuong = Convert.ToInt32(Content),
                    DonGia = Convert.ToInt32(dtg_SanPham.CurrentRow.Cells[14].Value),
                    ThanhTien = hoaDonChiTiet.SoLuong * hoaDonChiTiet.DonGia,
                });
            }
        }

        private void btn_taohoadon_Click(object sender, EventArgs e)
        {

            
            

            DialogResult dialogResult = MessageBox.Show("Bạn muốn tạo hóa đơn chứ", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                TabPage tpage = new TabPage();
                tabHoaDon.TabPages.Add(tpage);
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
        private void tabHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = tabHoaDon.SelectedTab.Text;
            SelectID = hoaDonService.GetAllHoaDon().Where(x=>x.MaHd == a).Select(x=>x.Id).FirstOrDefault();
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
            // đưa hdct vào dtg
          
        }
        private void Form_BanHang_Load(object sender, EventArgs e)
        {
            foreach (var x in _inhanvienService.getNhanViensFromDB())
            {
                cbb_nhanvien.Items.Add(x.Ten);
            }

            foreach (var x in _ikhachHangService.getKhachHangFromDB())
            {
                cbb_nganhang.Items.Add(x.Ten);
            }
        }

        
    }
}
