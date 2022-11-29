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
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private ILichSuDiemDungService _ilichSuDiemDungService = new LichSuDiemDungService();
        private ILichSuDiemTichService _ilichSuDiemTichService = new LichSuDiemTichService();
        private IDiemTieuDungService _idiemTieuDungService = new DiemTieuDungService();
        private ICongThucTinhDiemService _icongThucTinhDiemService = new CongThucTinhDiemService();
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public Guid SelectID { get; set; }
        public Guid SelectIDSp { get; set; }
        private HoaDonChiTiet hoaDonChiTiet;
        private ChiTietSach ChiTietSach;
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
            LoadHoaDonDaThanhToan();
            Tabhoadondcmm();
            tabHoaDon.Visible = false;
            Locktextboxfrombanhang();
            LoadSanphamtoFl();

            panel_tiencoc.Visible = false;
            panel_capnhat.Visible = false;
        }
        private void Locktextboxfrombanhang()
        {
            if (tabHoaDon.SelectedIndex < 0)
            {
                tb_dungdiem.ReadOnly = true;
                tb_tienkhachdua.ReadOnly = true;
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
        //public void LoadSach()
        //{
        //    int stt = 1;
        //    dtg_SanPham.ColumnCount = 16;
        //    dtg_SanPham.Columns[0].Name = "STT";
        //    dtg_SanPham.Columns[0].Width = 39;
        //    dtg_SanPham.Columns[1].Name = "Id";
        //    dtg_SanPham.Columns[1].Visible = false;
        //    dtg_SanPham.Columns[2].Name = "Sách";
        //    dtg_SanPham.Columns[3].Name = "NXB";
        //    dtg_SanPham.Columns[4].Name = "Tác giả";
        //    dtg_SanPham.Columns[5].Name = "NPH";
        //    dtg_SanPham.Columns[6].Name = "Loại bìa";
        //    dtg_SanPham.Columns[7].Name = "Mã";
        //    dtg_SanPham.Columns[7].Width = 79;
        //    dtg_SanPham.Columns[8].Name = "Kích thước";
        //    dtg_SanPham.Columns[9].Name = "Năm xuất bản";
        //    dtg_SanPham.Columns[10].Name = "Mô tả";
        //    dtg_SanPham.Columns[11].Name = "Số trang";
        //    dtg_SanPham.Columns[12].Name = "Số lượng";
        //    dtg_SanPham.Columns[13].Name = "Giá nhập";
        //    dtg_SanPham.Columns[14].Name = "Giá bán";
        //    dtg_SanPham.Columns[15].Name = "Trạng thái";
        //    dtg_SanPham.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // căn giữa 
        //    dtg_SanPham.Rows.Clear();
        //    foreach (var a in _iChiTietSachService.GetAllChiTietSachView())
        //    {
        //        dtg_SanPham.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Hết sách" : "Còn bán");
        //    }
        //}
        public void LoaddataToHoadonChitiet()
        {
            HoaDon hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            SelectID = hd.Id;
            dtg_HoaDonChiTiet.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // căn giữa 
            dtg_HoaDonChiTiet.Columns[3].Width = 39;
            dtg_HoaDonChiTiet.Columns[5].Width = 39;
            dtg_HoaDonChiTiet.Columns[4].Width = 79;
            dtg_HoaDonChiTiet.Columns[8].Width = 39;
            dtg_HoaDonChiTiet.Rows.Clear();
            foreach (var x in hoaDonChiTietService.GetAll().Where(x => x.IDhoadon == SelectID))
            {
                dtg_HoaDonChiTiet.Rows.Add(x.ID, x.MactSach, x.Tensach, "-", x.Soluong, "+", x.Dongia, x.Thanhtien, "X");
            }
            if (hd.TrangThai == 2 || hd.TrangThai == 3)
            {
                tabtrangthaimuahang.SelectedIndex = 1;
            }
            if (hd.TrangThai == 0)
            {
                tabtrangthaimuahang.SelectedIndex = 0;
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
                tabtrangthaimuahang.SelectedIndex = 0;
            }
            cleartextbox();
            Tabhoadondcmm();
        }
        private void btnsender_Click1(object sender, EventArgs e)
        {

            if (dtg_HoaDonChiTiet.Visible == false)
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn cần thêm sản phẩm");
            }
            else
            {
                var x = ((sender as Button).Tag as ChiTietSach).Id;
                SelectIDSp = x;
                HoaDon hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
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
                if (Convert.ToInt32(Content) < 0)
                {
                    MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
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
                        hdct.IdHoaDon = SelectID;
                        hdct.IdChiTietSach = SelectIDSp;
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
                                btn1.BackColor = Color.FromArgb(205, 201, 201);
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
            try
            {
                fl_sanpham.Controls.Clear();
                foreach (var x in _iChiTietSachService.GetAll().OrderBy(x => x.Ma))
                {
                    var Ten = _iChiTietSachService.GetAllChiTietSachView().Where(b => b.Id == x.Id).Select(c => c.TenSach).FirstOrDefault();
                    Button btn1 = new Button() { Width = 200, Height = 150 };
                    btn1.Text = x.Ma + Environment.NewLine + "Tên: " + Ten + Environment.NewLine + "Gía bán:" + x.GiaBan + Environment.NewLine + "Số lượng:" + x.SoLuong;
                    btn1.ForeColor = System.Drawing.Color.FromArgb(1, 102, 207);
                    btn1.BackColor = Color.FromArgb(1, 90, 90);
                    btn1.TextAlign = ContentAlignment.MiddleLeft;
                    //Image img1= Image.FromFile(@"C:\Users\Admin\OneDrive\Desktop\fpoly\4.KI FALL22\2.Block 2\1.PRO131\Icons\purchase_order_50px.png");
                    Image img2 = byteArrayToImage(x.Anh);
                    img2 = resizeImage(img2, new Size(60, 110));
                    btn1.Image = img2;
                    btn1.Tag = x;
                    btn1.ImageAlign = ContentAlignment.MiddleRight;
                    btn1.ForeColor = Color.FromArgb(224, 238, 224);
                    btn1.Click += btnsender_Click1;
                    fl_sanpham.Controls.Add(btn1);
                }
                Button btn2 = new Button() { Width = 200, Height = 150 };
                btn2.Text = "+";
                btn2.TextAlign = ContentAlignment.TopCenter;
                btn2.Font = new Font(btn2.Font.FontFamily, 69);
                btn2.Click += btnsender_click3;
                fl_sanpham.Controls.Add(btn2);
            }
            catch (Exception)
            {

                throw;
            }
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
            try
            {
                fl_ChuaThanhToan.Controls.Clear();
                foreach (var a in hoaDonService.GetAllHoaDon().Where(p => p.TrangThai == 0))
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
                hd.MaHd = "HD" + "" + Convert.ToString(hoaDonService.GetAll().Count + 1);

                hd.Idnv = Guid.Parse("8f6fdc53-1d3a-403f-8074-28ebf0f6405f");
                hd.Idkh = Guid.Parse("56303832-7163-464a-99a8-72973ed09c21");
                hd.NgayTao = DateTime.Now;
                MessageBox.Show(hoaDonService.Add(hd));
                tpage.Text = Convert.ToString(hd.MaHd);
                tpage.Name = Convert.ToString(hd.MaHd);
                tabHoaDon.SelectedIndex = tabHoaDon.TabCount;
                LoaddataToTextbox(hd.Id);
            }
            LoadHoaDonChoThanhToan();
        }
        public int Index { get; set; }
        public string NameIndex { get; set; }
        private void tabHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabHoaDon.SelectedIndex >= 0)
            {

                if (tabHoaDon.SelectedTab.Name != NameIndex)
                {
                    //LoaddataToTextbox(hoaDonService.GetAllHoaDon().Where(x => x.MaHd == tabHoaDon.SelectedTab.Name).Select(x => x.Id).FirstOrDefault());
                    HoaDon hd = new HoaDon();
                    hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == NameIndex);
                    if (hd != null)
                    {
                        if (hd.TrangThai == 0)
                        {
                            hd.Idnv = _inhanvienService.getNhanViensFromDB().Where(x => x.Ten == cbb_nhanvien.SelectedItem).Select(x => x.Id).FirstOrDefault();
                            hd.Idkh = _ikhachHangService.getKhachHangFromDB().Where(x => x.Ten == cbb_nganhang.SelectedItem).Select(x => x.ID).FirstOrDefault();
                            hd.TongTien = Convert.ToInt32(tb_tongtienhang.Text);
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
            foreach (var x in _inhanvienService.getNhanViensFromDB())
            {
                cbb_nhanvien.Items.Add(x.Ten);
            }

            foreach (var x in _ikhachHangService.getKhachHangFromDB())
            {
                cbb_nganhang.Items.Add(x.Ten);
            }
        }

        private void dtg_HoaDonChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtg_HoaDonChiTiet.Columns["tru"].Index)
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
            if (e.ColumnIndex == dtg_HoaDonChiTiet.Columns["Cong"].Index)
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
            if (e.ColumnIndex == dtg_HoaDonChiTiet.Columns["Xoa"].Index)
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
            dtp_ngaytao.ResetText();
            tb_tongtien.Clear();
            tb_tienkhachdua.Clear();
            tb_tientralai.Clear();
            tbx_TienCoc.Clear();
            tbx_TienShip.Clear();
            tb_tongtienhang.Clear();
        }

        private void dtg_SanPham_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ////// LoaddataToHoadon();
            ////LoaddataToChitietHoadon(SelectID);
            //if (dtg_HoaDonChiTiet.Visible == false)
            //{
            //    MessageBox.Show("Bạn chưa chọn hóa đơn cần thêm sản phẩm");
            //}
            //else
            //{


            //    HoaDon hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            //    SelectID = hd.Id;
            //    Guid a = Guid.Parse(Convert.ToString(dtg_SanPham.CurrentRow.Cells[1].Value));
            //    HoaDonChiTiet data = hoaDonChiTietService.GetAllloadformsp().FirstOrDefault(x => x.IdChiTietSach == a && x.IdHoaDon == SelectID);
            //    string Content = Interaction.InputBox("Nhập số lượng ", "", "", 500, 300);   //nhập số lượng ở màn bán hàng
            //    if (Content != null)
            //    {
            //        if (data == null)
            //        {
            //            HoaDonChiTiet hdct = new HoaDonChiTiet();
            //            hdct.Id = Guid.NewGuid();
            //            hdct.IdHoaDon = SelectID;
            //            hdct.IdChiTietSach = Guid.Parse(Convert.ToString(dtg_SanPham.CurrentRow.Cells[1].Value));
            //            ChiTietSach cts = new ChiTietSach();
            //            cts = _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).FirstOrDefault();
            //            if (cts.SoLuong >= Convert.ToInt32(Content))
            //            {
            //                hdct.Ma = "HDCT" + Convert.ToString(hoaDonChiTietService.GetAllloadformsp()
            //                  .Max(c => Convert.ToInt32(c.Ma.Substring(4, c.Ma.Length - 4)) + 2));
            //                hdct.SoLuong = Convert.ToInt32(Content);
            //                hdct.DonGia = Convert.ToInt32(dtg_SanPham.CurrentRow.Cells[14].Value);
            //                hdct.ThanhTien = Convert.ToInt32(hdct.SoLuong * cts.GiaBan);
            //                hoaDonChiTietService.Add(hdct);
            //                //update số lượng còn lại 
            //                cts.IdSach = cts.IdSach;
            //                cts.IdSach = cts.IdSach;
            //                cts.IdNxb = cts.IdNxb;
            //                cts.IdTacGia = cts.IdTacGia;
            //                cts.IdNhaPhatHanh = cts.IdNhaPhatHanh;
            //                cts.IdLoaiBia = cts.IdLoaiBia;
            //                cts.Ma = cts.Ma;
            //                cts.Anh = cts.Anh;
            //                cts.MaVach = cts.MaVach;
            //                cts.KichThuoc = cts.KichThuoc;
            //                cts.SoTrang = cts.SoTrang;
            //                cts.NamXuatBan = cts.NamXuatBan;
            //                cts.MoTa = cts.MoTa;
            //                cts.GiaNhap = cts.GiaNhap;
            //                cts.GiaBan = cts.GiaBan;
            //                cts.TrangThai = cts.TrangThai;
            //                cts.SoLuong = cts.SoLuong - Convert.ToInt32(Content);
            //                _iChiTietSachService.Update(hdct.IdChiTietSach, cts);
            //                //het update
            //                LoadSach();
            //            }
            //            else
            //            {
            //                MessageBox.Show("Số lượng bạn nhập kho hàng không đáp ứng đủ, số lượng còn lại là:" + " " + cts.SoLuong);
            //            }
            //        }
            //        else
            //        {
            //            HoaDonChiTiet hdct = new HoaDonChiTiet();
            //            hdct.IdHoaDon = SelectID;
            //            hdct.IdChiTietSach = Guid.Parse(Convert.ToString(dtg_SanPham.CurrentRow.Cells[1].Value));
            //            hdct.SoLuong = data.SoLuong + Convert.ToInt32(Content);
            //            hdct.ThanhTien = hdct.SoLuong * _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).Select(x => x.GiaBan).FirstOrDefault();
            //            ChiTietSach cts = new ChiTietSach();
            //            cts = _iChiTietSachService.GetAll().Where(x => x.Id == hdct.IdChiTietSach).FirstOrDefault();
            //            if (cts.SoLuong > Convert.ToInt32(Content))//check so luong con lai
            //            {
            //                hoaDonChiTietService.Update(hdct);
            //                //update so luong sach con lai
            //                cts.IdSach = cts.IdSach;
            //                cts.IdSach = cts.IdSach;
            //                cts.IdNxb = cts.IdNxb;
            //                cts.IdTacGia = cts.IdTacGia;
            //                cts.IdNhaPhatHanh = cts.IdNhaPhatHanh;
            //                cts.IdLoaiBia = cts.IdLoaiBia;
            //                cts.Ma = cts.Ma;
            //                cts.Anh = cts.Anh;
            //                cts.MaVach = cts.MaVach;
            //                cts.KichThuoc = cts.KichThuoc;
            //                cts.SoTrang = cts.SoTrang;
            //                cts.NamXuatBan = cts.NamXuatBan;
            //                cts.MoTa = cts.MoTa;
            //                cts.GiaNhap = cts.GiaNhap;
            //                cts.GiaBan = cts.GiaBan;
            //                cts.TrangThai = cts.TrangThai;
            //                cts.SoLuong = cts.SoLuong - Convert.ToInt32(Content);
            //                _iChiTietSachService.Update(hdct.IdChiTietSach, cts);
            //                //het update
            //                LoadSach();
            //            }
            //            else
            //            {
            //                MessageBox.Show("Số lượng bạn nhập kho hàng không đáp ứng đủ, số lượng còn lại là:" + " " + cts.SoLuong);
            //            }
            //        }
            //    }
            //    LoadHoaDonChiTiet();
            //    LoaddataToHoadonChitiet();
            //}

        }
        private void LoaddataToTextbox(Guid id)
        {
            //  HoaDon hd = new HoaDon();
            var hd = hoaDonService.GetAll().Where(x => x.Id == id).FirstOrDefault();
            cbb_nhanvien.SelectedItem = hd.Tennv;
            /*khach hang*/
            cbb_nganhang.SelectedItem = hd.Tenkh;
            tb_vidiem.Text = Convert.ToString(hd.Sodiem);
            // dtp_ngaytao.Value = Convert.ToDateTime(hd.Ngaytao);
            int count = 0;
            foreach (var x in hoaDonChiTietService.GetAllloadformsp().Where(x => x.IdHoaDon == id))
            {
                count = count + Convert.ToInt32(x.ThanhTien);
            }
            tb_tongtienhang.Text = Convert.ToString(count);
            tbx_TienCoc.Text = Convert.ToString(hd.tiencoc);
            tbx_TienShip.Text = Convert.ToString(hd.tienship);
            tb_tongtien.Text = tb_tongtienhang.Text;
            tbt_MaHD.Text = hd.Mahd;
            if (hd.Trangthai == 2 || hd.Trangthai == 3)
            {
                if (hd.Trangthai == 2)
                {
                    rd_chogiao.Checked = true;
                }
                else if (hd.Trangthai == 3)
                {
                    rd_danggiao.Checked = true;
                }
            }
        }

        private void cb_dungdiem_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_dungdiem.Checked == true)
            {
                tb_dungdiem.ReadOnly = false;

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

            //if (dtg_HoaDonChiTiet.Visible == false)
            //{
            //    MessageBox.Show("Vui lòng chọn hóa đơn trước khi thanh toán");
            //    return;
            //}
            //else if (hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name).TrangThai == 1)
            //{
            //    MessageBox.Show("Hóa đơn này đã được thanh toán");
            //}
            //else if (tb_tongtien.Text == "0")
            //{
            //    MessageBox.Show("Hóa đơn của bạn chưa có sản phẩm, Vui lòng thêm sản phẩm vào hóa đơn để thanh toán");
            //}
            //else if (tabtrangthaimuahang.SelectedIndex != 0 && tabtrangthaimuahang.SelectedIndex != 1)
            //{
            //    MessageBox.Show("Vui lòng chọn trạng thái bán của đơn hàng");
            //}
            //else if (tb_tienkhachdua.Text == "")
            //{
            //    lb_checktienkhachdua.Text = "Khách chưa đưa tiền";
            //}
            //else if (tabtrangthaimuahang.SelectedIndex == 1)
            //{
            //    if (cbb_nhanvien.SelectedIndex < 0)
            //    {
            //        lb_checknhanvien.Text = "Vui lòng chọn nhân viên";
            //        lb_checknhanvien.ForeColor = Color.Red;
            //    }
            //    else if (cbb_nganhang.SelectedIndex < 0)
            //    {
            //        lb_checkkhachang.Text = "Vui lòng chọn khách hàng";
            //        lb_checkkhachang.ForeColor = Color.Red;
            //    }
            //    else if (cb_dungdiem.Checked == true)
            //    {
            //        // checked = true nma người dùng không nhập điểm
            //        if (tb_dungdiem.Text == "")
            //        {
            //            if (Convert.ToInt32(tb_tienkhachdua.Text) < Convert.ToInt32(tb_tongtien))
            //            {
            //                lb_checktienkhachdua.Text = "Tiền khách đưa không thỏa mãn";
            //            }
            //            else if (tbx_TienCoc.Text == "")
            //            {
            //                lb_CheckCoc.Text = "Vui lòng nhập tiền cọc";
            //            }
            //            else if (tbx_TienShip.Text == "")
            //            {
            //                lb_CheckShip.Text = "Vui lòng nhập tiền ship";
            //            }
            //            else if (tb_diachi.Text == "")
            //            {
            //                lb_CheckDiaChi.Text = "Vui lòng nhập địa chỉ";
            //            }
            //            else if (Convert.ToInt32(tbx_TienCoc.Text) < Convert.ToInt32(tbx_TienShip.Text))
            //            {
            //                lb_CheckCoc.Text = "Tiền cọc phải lớn hơn tiền ship";
            //            }
            //            else
            //            {
            //                //Thanh toán với hóa đơn có checked và không nhập điểm;
            //                HoaDon hd = new HoaDon();
            //                LichSuDiemDung lichsudiemdung = new LichSuDiemDung();
            //                LichSuDiemTich lichSuDiemTich = new LichSuDiemTich();
            //                DiemTieuDung diemtieudung = new DiemTieuDung();
            //                CongThucTinhDiem cttd1, cttd2 = new CongThucTinhDiem();
            //                cttd1 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT1").FirstOrDefault();
            //                cttd2 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT2").FirstOrDefault();
            //                hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            //                //Khách hàng
            //                KhachHang kh = new KhachHang();
            //                kh = _ikhachHangService.getAll().FirstOrDefault(x => x.Id == _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault());

            //                //  lichsuđiemtich
            //                lichSuDiemTich.Id = Guid.NewGuid();
            //                lichSuDiemTich.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //                lichSuDiemTich.Ma = "LST" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //                          .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //                lichSuDiemTich.SoDiemTich = Convert.ToInt32(tb_tongtien.Text) / Convert.ToInt32(cttd2.HeSo);
            //                lichSuDiemTich.NgaySuDung = DateTime.Now;
            //                lichSuDiemTich.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //                lichSuDiemTich.TrangThai = 1;
            //                _ilichSuDiemTichService.Add(lichSuDiemTich);


            //                ////  lish sử điểm dùng
            //                //lichsudiemdung.Id = Guid.NewGuid();
            //                //lichsudiemdung.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //                //lichsudiemdung.Ma = "LSD" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //                //          .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //                //lichsudiemdung.SoDiemDung = Convert.ToInt32(tb_dungdiem.Text);
            //                //lichsudiemdung.NgaySuDung = DateTime.Now;
            //                //lichsudiemdung.TongTien = Convert.ToInt32(tb_diemquydoi.Text);
            //                //lichsudiemdung.TrangThai = 1;
            //                //_ilichSuDiemDungService.Add(lichsudiemdung);


            //                // thay đổi điểm ví điểm
            //                DiemTieuDung dtd = new DiemTieuDung();
            //                dtd = _idiemTieuDungService.GetAll().FirstOrDefault(z => z.Id == kh.IddiemTieuDung);
            //                dtd.SoDiem = dtd.SoDiem + Convert.ToInt32(lichSuDiemTich.SoDiemTich);
            //                _idiemTieuDungService.Update(dtd);

            //                //hóa đơn

            //                hd.Id = hd.Id;
            //                hd.MaHd = tabHoaDon.SelectedTab.Name;
            //                hd.Idnv = _inhanvienService.getNhanViensFromDB().Where(c => c.Ten == cbb_nhanvien.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //                hd.Idkh = _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //                //hd.IddiemDung = lichsudiemdung.Id;
            //                hd.IddiemTich = lichSuDiemTich.Id;
            //                hd.NgayShip = DateTime.Now;
            //                hd.TienCoc = Convert.ToInt32(tbx_TienCoc.Text);
            //                hd.TienShip = Convert.ToInt32(tbx_TienShip.Text);
            //                hd.DiaChi = tb_diachi.Text;
            //                hd.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //                hd.TrangThai = 2;
            //                MessageBox.Show(hoaDonService.Update(hd));
            //                LoadHoaDonChoThanhToan();
            //                LoadHoaDonDaThanhToan();
            //                Tabhoadondcmm();
            //            }
            //        }
            //        else if (tb_dungdiem.Text == "0")
            //        {
            //            if (Convert.ToInt32(tb_tienkhachdua.Text) < Convert.ToInt32(tb_tongtien))
            //            {
            //                lb_checktienkhachdua.Text = "Tiền khách đưa không thỏa mãn";
            //            }
            //            else if (tbx_TienCoc.Text == "")
            //            {
            //                lb_CheckCoc.Text = "Vui lòng nhập tiền cọc";
            //            }
            //            else if (tbx_TienShip.Text == "")
            //            {
            //                lb_CheckShip.Text = "Vui lòng nhập tiền ship";
            //            }
            //            else if (tb_diachi.Text == "")
            //            {
            //                lb_CheckDiaChi.Text = "Vui lòng nhập địa chỉ";
            //            }
            //            else if (Convert.ToInt32(tbx_TienCoc.Text) < Convert.ToInt32(tbx_TienShip.Text))
            //            {
            //                lb_CheckCoc.Text = "Tiền cọc phải lớn hơn tiền ship";
            //            }
            //            else
            //            {
            //                //Thanh toán với hóa đơn có checked và Nhập điểm bằng 0;
            //                HoaDon hd = new HoaDon();
            //                LichSuDiemDung lichsudiemdung = new LichSuDiemDung();
            //                LichSuDiemTich lichSuDiemTich = new LichSuDiemTich();
            //                DiemTieuDung diemtieudung = new DiemTieuDung();
            //                CongThucTinhDiem cttd1, cttd2 = new CongThucTinhDiem();
            //                cttd1 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT1").FirstOrDefault();
            //                cttd2 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT2").FirstOrDefault();
            //                hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            //                //Khách hàng
            //                KhachHang kh = new KhachHang();
            //                kh = _ikhachHangService.getAll().FirstOrDefault(x => x.Id == _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault());

            //                //  lichsuđiemtich
            //                lichSuDiemTich.Id = Guid.NewGuid();
            //                lichSuDiemTich.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //                lichSuDiemTich.Ma = "LST" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //                          .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //                lichSuDiemTich.SoDiemTich = Convert.ToInt32(tb_tongtien.Text) / Convert.ToInt32(cttd2.HeSo);
            //                lichSuDiemTich.NgaySuDung = DateTime.Now;
            //                lichSuDiemTich.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //                lichSuDiemTich.TrangThai = 1;
            //                _ilichSuDiemTichService.Add(lichSuDiemTich);


            //                //  lish sử điểm dùng
            //                //lichsudiemdung.Id = Guid.NewGuid();
            //                //lichsudiemdung.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //                //lichsudiemdung.Ma = "LSD" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //                //          .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //                //lichsudiemdung.SoDiemDung = Convert.ToInt32(tb_dungdiem.Text);
            //                //lichsudiemdung.NgaySuDung = DateTime.Now;
            //                //lichsudiemdung.TongTien = Convert.ToInt32(tb_diemquydoi.Text);
            //                //lichsudiemdung.TrangThai = 1;
            //                //_ilichSuDiemDungService.Add(lichsudiemdung);


            //                // thay đổi điểm ví điểm
            //                DiemTieuDung dtd = new DiemTieuDung();
            //                dtd = _idiemTieuDungService.GetAll().FirstOrDefault(z => z.Id == kh.IddiemTieuDung);
            //                dtd.SoDiem = dtd.SoDiem + Convert.ToInt32(lichSuDiemTich.SoDiemTich);
            //                _idiemTieuDungService.Update(dtd);

            //                //hóa đơn

            //                hd.Id = hd.Id;
            //                hd.MaHd = tabHoaDon.SelectedTab.Name;
            //                hd.Idnv = _inhanvienService.getNhanViensFromDB().Where(c => c.Ten == cbb_nhanvien.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //                hd.Idkh = _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //                //hd.IddiemDung = lichsudiemdung.Id;
            //                hd.IddiemTich = lichSuDiemTich.Id;
            //                hd.NgayShip = DateTime.Now;
            //                hd.TienCoc = Convert.ToInt32(tbx_TienCoc.Text);
            //                hd.TienShip = Convert.ToInt32(tbx_TienShip.Text);
            //                hd.DiaChi = tb_diachi.Text;
            //                hd.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //                hd.TrangThai = 2;
            //                MessageBox.Show(hoaDonService.Update(hd));
            //                LoadHoaDonChoThanhToan();
            //                LoadHoaDonDaThanhToan();
            //                Tabhoadondcmm();
            //            }
            //        }
            //        else
            //        {
            //            if (Convert.ToInt32(tb_dungdiem.Text) > Convert.ToInt32(tb_vidiem.Text))
            //            {
            //                lb_checkdungdiem.Text = "Điểm dùng vượt quá số điểm trong ví";
            //            }
            //            else if (Convert.ToInt32(tb_diemquydoi.Text) > Convert.ToInt32(tb_tongtien.Text))
            //            {
            //                lb_checkdungdiem.Text = "Số tiền được quy đổi quá tiền hàng";
            //            }
            //            else if (Convert.ToInt32(tb_tienkhachdua.Text) < Convert.ToInt32(tb_tongtien.Text))
            //            {
            //                lb_checktienkhachdua.Text = "Tiền khách đưa không thỏa mãn";
            //            }
            //            else if (tbx_TienCoc.Text == "")
            //            {
            //                lb_CheckCoc.Text = "Vui lòng nhập tiền cọc";
            //            }
            //            else if (tbx_TienShip.Text == "")
            //            {
            //                lb_CheckShip.Text = "Vui lòng nhập tiền ship";
            //            }
            //            else if (tb_diachi.Text == "")
            //            {
            //                lb_CheckDiaChi.Text = "Vui lòng nhập địa chỉ";
            //            }
            //            else if (Convert.ToInt32(tbx_TienCoc.Text) < Convert.ToInt32(tbx_TienShip.Text))
            //            {
            //                lb_CheckCoc.Text = "Tiền cọc phải lớn hơn tiền ship";
            //            }
            //            else
            //            {
            //                //Thanh toán với hóa đơn có checked và Nhập điểm đúng;
            //                HoaDon hd = new HoaDon();
            //                LichSuDiemDung lichsudiemdung = new LichSuDiemDung();
            //                LichSuDiemTich lichSuDiemTich = new LichSuDiemTich();
            //                DiemTieuDung diemtieudung = new DiemTieuDung();
            //                CongThucTinhDiem cttd1, cttd2 = new CongThucTinhDiem();
            //                cttd1 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT1").FirstOrDefault();
            //                cttd2 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT2").FirstOrDefault();
            //                hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            //                //Khách hàng
            //                KhachHang kh = new KhachHang();
            //                kh = _ikhachHangService.getAll().FirstOrDefault(x => x.Id == _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault());

            //                //  lichsuđiemtich
            //                lichSuDiemTich.Id = Guid.NewGuid();
            //                lichSuDiemTich.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //                lichSuDiemTich.Ma = "LST" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //                          .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //                lichSuDiemTich.SoDiemTich = Convert.ToInt32(tb_tongtien.Text) / Convert.ToInt32(cttd2.HeSo);
            //                lichSuDiemTich.NgaySuDung = DateTime.Now;
            //                lichSuDiemTich.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //                lichSuDiemTich.TrangThai = 1;
            //                _ilichSuDiemTichService.Add(lichSuDiemTich);


            //                //  lish sử điểm dùng
            //                lichsudiemdung.Id = Guid.NewGuid();
            //                lichsudiemdung.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //                lichsudiemdung.Ma = "LSD" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //                          .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //                lichsudiemdung.SoDiemDung = Convert.ToInt32(tb_dungdiem.Text);
            //                lichsudiemdung.NgaySuDung = DateTime.Now;
            //                lichsudiemdung.TongTien = Convert.ToInt32(tb_diemquydoi.Text);
            //                lichsudiemdung.TrangThai = 2;
            //                _ilichSuDiemDungService.Add(lichsudiemdung);


            //                // thay đổi điểm ví điểm
            //                DiemTieuDung dtd = new DiemTieuDung();
            //                dtd = _idiemTieuDungService.GetAll().FirstOrDefault(z => z.Id == kh.IddiemTieuDung);
            //                dtd.SoDiem = dtd.SoDiem - Convert.ToInt32(lichsudiemdung.SoDiemDung) + Convert.ToInt32(lichSuDiemTich.SoDiemTich);
            //                _idiemTieuDungService.Update(dtd);

            //                //hóa đơn

            //                hd.Id = hd.Id;
            //                hd.MaHd = tabHoaDon.SelectedTab.Name;
            //                hd.Idnv = _inhanvienService.getNhanViensFromDB().Where(c => c.Ten == cbb_nhanvien.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //                hd.Idkh = _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //                hd.IddiemDung = lichsudiemdung.Id;
            //                hd.IddiemTich = lichSuDiemTich.Id;
            //                hd.NgayShip = DateTime.Now;
            //                hd.TienCoc = Convert.ToInt32(tbx_TienCoc.Text);
            //                hd.TienShip = Convert.ToInt32(tbx_TienShip.Text);
            //                hd.DiaChi = tb_diachi.Text;
            //                hd.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //                hd.TrangThai = 2;
            //                MessageBox.Show(hoaDonService.Update(hd));
            //                LoadHoaDonChoThanhToan();
            //                LoadHoaDonDaThanhToan();
            //                Tabhoadondcmm();
            //            }

            //        }
            //    }
            //    else if (cb_dungdiem.Checked == false)
            //    {
            //        // 
            //        if (Convert.ToInt32(tb_tienkhachdua.Text) < Convert.ToInt32(tb_tongtien.Text))
            //        {
            //            lb_checktienkhachdua.Text = "Tiền khách đưa không thỏa mãn";
            //        }
            //        else if (tbx_TienCoc.Text == "")
            //        {
            //            lb_CheckCoc.Text = "Vui lòng nhập tiền cọc";
            //        }
            //        else if (tbx_TienShip.Text == "")
            //        {
            //            lb_CheckShip.Text = "Vui lòng nhập tiền ship";
            //        }
            //        else if (tb_diachi.Text == "")
            //        {
            //            lb_CheckDiaChi.Text = "Vui lòng nhập địa chỉ";
            //        }
            //        else if (Convert.ToInt32(tbx_TienCoc.Text) < Convert.ToInt32(tbx_TienShip.Text))
            //        {
            //            lb_CheckCoc.Text = "Tiền cọc phải lớn hơn tiền ship";
            //        }
            //        else
            //        {
            //            //Thanh toán với hóa đơn có không có checked;
            //            HoaDon hd = new HoaDon();
            //            LichSuDiemDung lichsudiemdung = new LichSuDiemDung();
            //            LichSuDiemTich lichSuDiemTich = new LichSuDiemTich();
            //            DiemTieuDung diemtieudung = new DiemTieuDung();
            //            CongThucTinhDiem cttd1, cttd2 = new CongThucTinhDiem();
            //            cttd1 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT1").FirstOrDefault();
            //            cttd2 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT2").FirstOrDefault();
            //            hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            //            //Khách hàng
            //            KhachHang kh = new KhachHang();
            //            kh = _ikhachHangService.getAll().FirstOrDefault(x => x.Id == _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault());

            //            //  lichsuđiemtich
            //            lichSuDiemTich.Id = Guid.NewGuid();
            //            lichSuDiemTich.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //            lichSuDiemTich.Ma = "LST" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //                      .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //            lichSuDiemTich.SoDiemTich = Convert.ToInt32(tb_tongtien.Text) / Convert.ToInt32(cttd2.HeSo);
            //            lichSuDiemTich.NgaySuDung = DateTime.Now;
            //            lichSuDiemTich.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //            lichSuDiemTich.TrangThai = 1;
            //            _ilichSuDiemTichService.Add(lichSuDiemTich);


            //            //  lish sử điểm dùng
            //            //lichsudiemdung.Id = Guid.NewGuid();
            //            //lichsudiemdung.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //            //lichsudiemdung.Ma = "LSD" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //            //          .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //            //lichsudiemdung.SoDiemDung = Convert.ToInt32(tb_dungdiem.Text);
            //            //lichsudiemdung.NgaySuDung = DateTime.Now;
            //            //lichsudiemdung.TongTien = Convert.ToInt32(tb_diemquydoi.Text);
            //            //lichsudiemdung.TrangThai = 1;
            //            //_ilichSuDiemDungService.Add(lichsudiemdung);


            //            // thay đổi điểm ví điểm
            //            DiemTieuDung dtd = new DiemTieuDung();
            //            dtd = _idiemTieuDungService.GetAll().FirstOrDefault(z => z.Id == kh.IddiemTieuDung);
            //            dtd.SoDiem = dtd.SoDiem + Convert.ToInt32(lichSuDiemTich.SoDiemTich);
            //            _idiemTieuDungService.Update(dtd);

            //            //hóa đơn

            //            hd.Id = hd.Id;
            //            hd.MaHd = tabHoaDon.SelectedTab.Name;
            //            hd.Idnv = _inhanvienService.getNhanViensFromDB().Where(c => c.Ten == cbb_nhanvien.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //            hd.Idkh = _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //            //hd.IddiemDung = lichsudiemdung.Id;
            //            hd.IddiemTich = lichSuDiemTich.Id;
            //            hd.NgayShip = DateTime.Now;
            //            hd.TienCoc = Convert.ToInt32(tbx_TienCoc.Text);
            //            hd.TienShip = Convert.ToInt32(tbx_TienShip.Text);
            //            hd.DiaChi = tb_diachi.Text;
            //            hd.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //            hd.TrangThai = 2;
            //            MessageBox.Show(hoaDonService.Update(hd));
            //            LoadHoaDonChoThanhToan();
            //            LoadHoaDonDaThanhToan();
            //            Tabhoadondcmm();
            //        }
            //    }
            //    // thanh toán hóa đơn tại quầy
            //}
            //else if (tabtrangthaimuahang.SelectedIndex == 0)
            //{
            //    if (cbb_nhanvien.SelectedIndex < 0)
            //    {
            //        lb_checknhanvien.Text = "Vui lòng chọn nhân viên";
            //        lb_checknhanvien.ForeColor = Color.Red;
            //    }
            //    else if (cbb_nganhang.SelectedIndex < 0)
            //    {
            //        lb_checkkhachang.Text = "Vui lòng chọn khách hàng";
            //        lb_checkkhachang.ForeColor = Color.Red;
            //    }
            //    else if (cb_dungdiem.Checked == true)
            //    {
            //        // checked = true nma người dùng không nhập điểm
            //        if (tb_dungdiem.Text == "")
            //        {
            //            if (Convert.ToInt32(tb_tienkhachdua.Text) < Convert.ToInt32(tb_tongtien.Text))
            //            {
            //                lb_checktienkhachdua.Text = "Tiền khách đưa không thỏa mãn";
            //            }
            //            else
            //            {
            //                //Thanh toán với hóa đơn có checked và không nhập điểm;
            //                HoaDon hd = new HoaDon();
            //                LichSuDiemDung lichsudiemdung = new LichSuDiemDung();
            //                LichSuDiemTich lichSuDiemTich = new LichSuDiemTich();
            //                DiemTieuDung diemtieudung = new DiemTieuDung();
            //                CongThucTinhDiem cttd1, cttd2 = new CongThucTinhDiem();
            //                cttd1 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT1").FirstOrDefault();
            //                cttd2 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT2").FirstOrDefault();
            //                hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            //                //Khách hàng
            //                KhachHang kh = new KhachHang();
            //                kh = _ikhachHangService.getAll().FirstOrDefault(x => x.Id == _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault());

            //                //  lichsuđiemtich
            //                //lichSuDiemTich.Id = Guid.NewGuid();
            //                //lichSuDiemTich.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //                //lichSuDiemTich.Ma = "LST" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //                //          .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //                //lichSuDiemTich.SoDiemTich = Convert.ToInt32(tb_tongtien.Text) / Convert.ToInt32(cttd2.HeSo);
            //                //lichSuDiemTich.NgaySuDung = DateTime.Now;
            //                //lichSuDiemTich.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //                //lichSuDiemTich.TrangThai = 1;
            //                //_ilichSuDiemTichService.Add(lichSuDiemTich);


            //                //  lish sử điểm dùng
            //                lichsudiemdung.Id = Guid.NewGuid();
            //                lichsudiemdung.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //                lichsudiemdung.Ma = "LSD" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //                          .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //                lichsudiemdung.SoDiemDung = Convert.ToInt32(tb_dungdiem.Text);
            //                lichsudiemdung.NgaySuDung = DateTime.Now;
            //                lichsudiemdung.TongTien = Convert.ToInt32(tb_diemquydoi.Text);
            //                lichsudiemdung.TrangThai = 1;
            //                _ilichSuDiemDungService.Add(lichsudiemdung);


            //                // thay đổi điểm ví điểm
            //                DiemTieuDung dtd = new DiemTieuDung();
            //                dtd = _idiemTieuDungService.GetAll().FirstOrDefault(z => z.Id == kh.IddiemTieuDung);
            //                dtd.SoDiem = dtd.SoDiem - Convert.ToInt32(lichsudiemdung.SoDiemDung) + Convert.ToInt32(lichSuDiemTich.SoDiemTich);
            //                _idiemTieuDungService.Update(dtd);

            //                //hóa đơn

            //                hd.Id = hd.Id;
            //                hd.MaHd = tabHoaDon.SelectedTab.Name;
            //                hd.Idnv = _inhanvienService.getNhanViensFromDB().Where(c => c.Ten == cbb_nhanvien.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //                hd.Idkh = _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //                //hd.IddiemDung = lichsudiemdung.Id;
            //                hd.IddiemTich = lichSuDiemTich.Id;
            //                //hd.NgayShip = DateTime.Now;
            //                //hd.TienCoc = Convert.ToInt32(tbx_TienCoc.Text);
            //                //hd.TienShip = Convert.ToInt32(tbx_TienShip.Text);
            //                //hd.DiaChi = tb_diachi.Text;
            //                hd.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //                hd.TrangThai = 1;
            //                MessageBox.Show(hoaDonService.Update(hd));
            //                LoadHoaDonChoThanhToan();
            //                LoadHoaDonDaThanhToan();
            //                Tabhoadondcmm();
            //            }
            //        }
            //        else if (tb_dungdiem.Text == "0")
            //        {
            //            if (Convert.ToInt32(tb_tienkhachdua.Text) < Convert.ToInt32(tb_tongtien.Text))
            //            {
            //                lb_checktienkhachdua.Text = "Tiền khách đưa không thỏa mãn";
            //            }
            //            else
            //            {
            //                //Thanh toán với hóa đơn có checked và Nhập điểm bằng 0;
            //                HoaDon hd = new HoaDon();
            //                LichSuDiemDung lichsudiemdung = new LichSuDiemDung();
            //                LichSuDiemTich lichSuDiemTich = new LichSuDiemTich();
            //                DiemTieuDung diemtieudung = new DiemTieuDung();
            //                CongThucTinhDiem cttd1, cttd2 = new CongThucTinhDiem();
            //                cttd1 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT1").FirstOrDefault();
            //                cttd2 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT2").FirstOrDefault();
            //                hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            //                //Khách hàng
            //                KhachHang kh = new KhachHang();
            //                kh = _ikhachHangService.getAll().FirstOrDefault(x => x.Id == _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault());

            //                //  lichsuđiemtich
            //                lichSuDiemTich.Id = Guid.NewGuid();
            //                lichSuDiemTich.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //                lichSuDiemTich.Ma = "LST" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //                          .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //                lichSuDiemTich.SoDiemTich = Convert.ToInt32(tb_tongtien.Text) / Convert.ToInt32(cttd2.HeSo);
            //                lichSuDiemTich.NgaySuDung = DateTime.Now;
            //                lichSuDiemTich.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //                lichSuDiemTich.TrangThai = 1;
            //                _ilichSuDiemTichService.Add(lichSuDiemTich);


            //                //  lish sử điểm dùng
            //                //lichsudiemdung.Id = Guid.NewGuid();
            //                //lichsudiemdung.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //                //lichsudiemdung.Ma = "LSD" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //                //          .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //                //lichsudiemdung.SoDiemDung = Convert.ToInt32(tb_dungdiem.Text);
            //                //lichsudiemdung.NgaySuDung = DateTime.Now;
            //                //lichsudiemdung.TongTien = Convert.ToInt32(tb_diemquydoi.Text);
            //                //lichsudiemdung.TrangThai = 1;
            //                //_ilichSuDiemDungService.Add(lichsudiemdung);


            //                // thay đổi điểm ví điểm
            //                DiemTieuDung dtd = new DiemTieuDung();
            //                dtd = _idiemTieuDungService.GetAll().FirstOrDefault(z => z.Id == kh.IddiemTieuDung);
            //                dtd.SoDiem = dtd.SoDiem + Convert.ToInt32(lichSuDiemTich.SoDiemTich);
            //                _idiemTieuDungService.Update(dtd);

            //                //hóa đơn

            //                hd.Id = hd.Id;
            //                hd.MaHd = tabHoaDon.SelectedTab.Name;
            //                hd.Idnv = _inhanvienService.getNhanViensFromDB().Where(c => c.Ten == cbb_nhanvien.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //                hd.Idkh = _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //                //hd.IddiemDung = lichsudiemdung.Id;
            //                hd.IddiemTich = lichSuDiemTich.Id;
            //                //hd.NgayShip = DateTime.Now;
            //                //hd.TienCoc = Convert.ToInt32(tbx_TienCoc.Text);
            //                //hd.TienShip = Convert.ToInt32(tbx_TienShip.Text);
            //                //hd.DiaChi = tb_diachi.Text;
            //                hd.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //                hd.TrangThai = 1;
            //                MessageBox.Show(hoaDonService.Update(hd));
            //                LoadHoaDonChoThanhToan();
            //                LoadHoaDonDaThanhToan();
            //            }
            //        }
            //        else
            //        {
            //            if (Convert.ToInt32(tb_dungdiem.Text) > Convert.ToInt32(tb_vidiem.Text))
            //            {
            //                lb_checkdungdiem.Text = "Điểm dùng vượt quá số điểm trong ví";
            //            }
            //            else if (Convert.ToInt32(tb_diemquydoi.Text) > Convert.ToInt32(tb_tongtien.Text))
            //            {
            //                lb_checkdungdiem.Text = "Số tiền được quy đổi quá tiền hàng";
            //            }
            //            else if (Convert.ToInt32(tb_tienkhachdua.Text) < Convert.ToInt32(tb_tongtien.Text))
            //            {
            //                lb_checktienkhachdua.Text = "Tiền khách đưa không thỏa mãn";
            //            }
            //            else
            //            {
            //                //Thanh toán với hóa đơn có checked và Nhập điểm đúng;
            //                HoaDon hd = new HoaDon();
            //                LichSuDiemDung lichsudiemdung = new LichSuDiemDung();
            //                LichSuDiemTich lichSuDiemTich = new LichSuDiemTich();
            //                DiemTieuDung diemtieudung = new DiemTieuDung();
            //                CongThucTinhDiem cttd1, cttd2 = new CongThucTinhDiem();
            //                cttd1 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT1").FirstOrDefault();
            //                cttd2 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT2").FirstOrDefault();
            //                hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            //                //Khách hàng
            //                KhachHang kh = new KhachHang();
            //                kh = _ikhachHangService.getAll().FirstOrDefault(x => x.Id == _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault());

            //                //  lichsuđiemtich
            //                lichSuDiemTich.Id = Guid.NewGuid();
            //                lichSuDiemTich.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //                lichSuDiemTich.Ma = "LST" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //                          .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //                lichSuDiemTich.SoDiemTich = Convert.ToInt32(tb_tongtien.Text) / Convert.ToInt32(cttd2.HeSo);
            //                lichSuDiemTich.NgaySuDung = DateTime.Now;
            //                lichSuDiemTich.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //                lichSuDiemTich.TrangThai = 1;
            //                _ilichSuDiemTichService.Add(lichSuDiemTich);


            //                //  lish sử điểm dùng
            //                lichsudiemdung.Id = Guid.NewGuid();
            //                lichsudiemdung.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //                lichsudiemdung.Ma = "LSD" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //                          .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //                lichsudiemdung.SoDiemDung = Convert.ToInt32(tb_dungdiem.Text);
            //                lichsudiemdung.NgaySuDung = DateTime.Now;
            //                lichsudiemdung.TongTien = Convert.ToInt32(tb_diemquydoi.Text);
            //                lichsudiemdung.TrangThai = 1;
            //                _ilichSuDiemDungService.Add(lichsudiemdung);


            //                // thay đổi điểm ví điểm
            //                DiemTieuDung dtd = new DiemTieuDung();
            //                dtd = _idiemTieuDungService.GetAll().FirstOrDefault(z => z.Id == kh.IddiemTieuDung);
            //                dtd.SoDiem = dtd.SoDiem - Convert.ToInt32(lichsudiemdung.SoDiemDung) + Convert.ToInt32(lichSuDiemTich.SoDiemTich);
            //                _idiemTieuDungService.Update(dtd);

            //                //hóa đơn

            //                hd.Id = hd.Id;
            //                hd.MaHd = tabHoaDon.SelectedTab.Name;
            //                hd.Idnv = _inhanvienService.getNhanViensFromDB().Where(c => c.Ten == cbb_nhanvien.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //                hd.Idkh = _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //                hd.IddiemDung = lichsudiemdung.Id;
            //                hd.IddiemTich = lichSuDiemTich.Id;
            //                //hd.NgayShip = DateTime.Now;
            //                //hd.TienCoc = Convert.ToInt32(tbx_TienCoc.Text);
            //                //hd.TienShip = Convert.ToInt32(tbx_TienShip.Text);
            //                //hd.DiaChi = tb_diachi.Text;
            //                hd.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //                hd.TrangThai = 1;
            //                MessageBox.Show(hoaDonService.Update(hd));
            //                LoadHoaDonChoThanhToan();
            //                LoadHoaDonDaThanhToan();
            //            }

            //        }
            //    }
            //    else if (cb_dungdiem.Checked == false)
            //    {

            //        if (Convert.ToInt32(tb_tienkhachdua.Text) < Convert.ToInt32(tb_tongtien.Text))
            //        {
            //            lb_checktienkhachdua.Text = "Tiền khách đưa không thỏa mãn";
            //        }
            //        else
            //        {
            //            //Thanh toán với hóa đơn có checked và Nhập điểm đúng;
            //            HoaDon hd = new HoaDon();
            //            LichSuDiemDung lichsudiemdung = new LichSuDiemDung();
            //            LichSuDiemTich lichSuDiemTich = new LichSuDiemTich();
            //            DiemTieuDung diemtieudung = new DiemTieuDung();
            //            CongThucTinhDiem cttd1, cttd2 = new CongThucTinhDiem();
            //            cttd1 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT1").FirstOrDefault();
            //            cttd2 = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT2").FirstOrDefault();
            //            hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            //            //Khách hàng
            //            KhachHang kh = new KhachHang();
            //            kh = _ikhachHangService.getAll().FirstOrDefault(x => x.Id == _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault());

            //            // lichsuđiemtich
            //            lichSuDiemTich.Id = Guid.NewGuid();
            //            lichSuDiemTich.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //            lichSuDiemTich.Ma = "LST" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //                      .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //            lichSuDiemTich.SoDiemTich = Convert.ToInt32(tb_tongtien.Text) / Convert.ToInt32(cttd2.HeSo);
            //            lichSuDiemTich.NgaySuDung = DateTime.Now;
            //            lichSuDiemTich.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //            lichSuDiemTich.TrangThai = 1;
            //            _ilichSuDiemTichService.Add(lichSuDiemTich);


            //            //  lish sử điểm dùng
            //            //lichsudiemdung.Id = Guid.NewGuid();
            //            //lichsudiemdung.IddiemTieuDung = hoaDonService.GetAll().Where(x => x.Id == hd.Id).Select(x => x.Iddiemtieudung).FirstOrDefault();
            //            //lichsudiemdung.Ma = "LSD" + Convert.ToString(_ilichSuDiemTichService.GetAll()
            //            //          .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
            //            //lichsudiemdung.SoDiemDung = Convert.ToInt32(tb_dungdiem.Text);
            //            //lichsudiemdung.NgaySuDung = DateTime.Now;
            //            //lichsudiemdung.TongTien = Convert.ToInt32(tb_diemquydoi.Text);
            //            //lichsudiemdung.TrangThai = 1;
            //            //_ilichSuDiemDungService.Add(lichsudiemdung);


            //            // thay đổi điểm ví điểm
            //            DiemTieuDung dtd = new DiemTieuDung();
            //            dtd = _idiemTieuDungService.GetAll().FirstOrDefault(z => z.Id == kh.IddiemTieuDung);
            //            dtd.SoDiem = dtd.SoDiem + Convert.ToInt32(lichSuDiemTich.SoDiemTich);
            //            _idiemTieuDungService.Update(dtd);

            //            //hóa đơn

            //            hd.Id = hd.Id;
            //            hd.MaHd = tabHoaDon.SelectedTab.Name;
            //            hd.Idnv = _inhanvienService.getNhanViensFromDB().Where(c => c.Ten == cbb_nhanvien.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //            hd.Idkh = _ikhachHangService.getAll().Where(c => c.Ten == cbb_nganhang.SelectedItem).Select(x => x.Id).FirstOrDefault();
            //            // hd.IddiemDung = lichsudiemdung.Id;
            //            hd.IddiemTich = lichSuDiemTich.Id;
            //            //hd.NgayShip = DateTime.Now;
            //            //hd.TienCoc = Convert.ToInt32(tbx_TienCoc.Text);
            //            //hd.TienShip = Convert.ToInt32(tbx_TienShip.Text);
            //            //hd.DiaChi = tb_diachi.Text;
            //            hd.TongTien = Convert.ToInt32(tb_tongtien.Text);
            //            hd.TrangThai = 1;
            //            MessageBox.Show(hoaDonService.Update(hd));
            //            LoadHoaDonChoThanhToan();
            //            LoadHoaDonDaThanhToan();
            //        }
            //    }
            //}
        }
        private void btn_quetma_Click(object sender, EventArgs e)
        {
            Form_QuetMaSach.mavach = null;
            Form_QuetMaSach qms = new Form_QuetMaSach();
            qms.ShowDialog();
            if (Form_QuetMaSach.mavach == null) return;

            var x = _iChiTietSachService.GetAll().Where(c => c.MaVach == Form_QuetMaSach.mavach).Select(x => x.Id).FirstOrDefault();
            SelectIDSp = x;
            HoaDon hd = hoaDonService.GetAllHoaDon().FirstOrDefault(c => c.MaHd == tabHoaDon.SelectedTab.Name);
            SelectID = hd.Id;
            HoaDonChiTiet data = hoaDonChiTietService.GetAllloadformsp().FirstOrDefault(x => x.IdChiTietSach == SelectIDSp && x.IdHoaDon == SelectID);
            string ctsquet = _iChiTietSachService.GetAllChiTietSachView().FirstOrDefault(c => c.Id == x).Ma;
            decimal giabanquet = Convert.ToDecimal(_iChiTietSachService.GetAllChiTietSachView().FirstOrDefault(c => c.Id == x).GiaBan);
            string Content = Interaction.InputBox($"Mã: {ctsquet}" + Environment.NewLine + $"Tên: {Form_QuetMaSach.tensach}" + Environment.NewLine + $"Giá bán: {giabanquet}" + Environment.NewLine + "Nhập số lượng ", "Bạn muốn thêm bao nhiêu", "1", 500, 300);//nhập số lượng ở màn bán hàng
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
            if (Convert.ToInt32(Content) < 0)
            {
                MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
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
                    hdct.IdHoaDon = SelectID;
                    hdct.IdChiTietSach = SelectIDSp;
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


        private void tb_tienkhachdua_TextChanged(object sender, EventArgs e)
        {
            if (tb_tienkhachdua.Text != "" && tb_tongtienhang.Text != "")
            {
                tb_tientralai.Text = Convert.ToString(Convert.ToInt64(tb_tienkhachdua.Text) - Convert.ToInt64(tb_tongtien.Text));
            }
        }

        private void tb_tienkhachdua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_dungdiem_TextChanged(object sender, EventArgs e)
        {
            //if (cb_dungdiem.Checked == true && tb_dungdiem.Text != "")
            //{
            //    CongThucTinhDiem cttd = new CongThucTinhDiem();
            //    cttd = _icongThucTinhDiemService.GetAll().Where(x => x.Ma == "CTT2").FirstOrDefault();
            //    tb_diemquydoi.Text = Convert.ToString(Convert.ToInt32(cttd.HeSo) * Convert.ToInt32(tb_dungdiem.Text));
            //    if (Convert.ToInt32(tb_tongtienhang.Text) - Convert.ToInt32(tb_diemquydoi.Text) > 0)
            //    {
            //        tb_tongtien.Text = Convert.ToString(Convert.ToInt32(tb_tongtienhang.Text) - Convert.ToInt32(tb_diemquydoi.Text));
            //    }
            //    else
            //    {
            //        lb_checkdungdiem.Text = "Số tiền quy đổi không được lớn hơn tiền hàng";
            //        lb_checkdungdiem.ForeColor = Color.Red;
            //    }

            //}


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
            LoadBtnQuet();
        }
        public void LoadHoaDonDatHang()
        {
            try
            {
                if (cbx_Loc.Text == "Đã thanh toán")
                {
                    groupBox2.Text = "Hóa đã thanh toán";
                    fl_DaThanhToan.Controls.Clear();

                    foreach (var a in hoaDonService.GetAllHoaDon().Where(p => p.TrangThai == 1))
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
                    foreach (var a in hoaDonService.GetAllHoaDon().Where(p => p.TrangThai == 2))
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
                    foreach (var a in hoaDonService.GetAllHoaDon().Where(p => p.TrangThai == 3))
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
            catch (Exception e)
            {

                MessageBox.Show(Convert.ToString(e), "Liên hệ");
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

        }

        private void bt_capnhat_Click(object sender, EventArgs e)
        {
            if (tabHoaDon.SelectedIndex >= 0)
            {
                HoaDon hd = new HoaDon();
                hd = hoaDonService.GetAllHoaDon().Where(x => x.MaHd == tabHoaDon.SelectedTab.Name).FirstOrDefault();
                if (rd_chogiao.Checked == true)
                {
                    hd.TrangThai = 2;


                }
                else if (rd_danggiao.Checked == true)
                {
                    hd.TrangThai = 3;
                }
                hoaDonService.Update(hd);
                MessageBox.Show("Cập nhật trạng thái thành công");
                Tabhoadondcmm();
                LoadHoaDonChoThanhToan();
                LoadHoaDonDaThanhToan();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn");
            }
        }

        private void bt_hoanthanh_Click(object sender, EventArgs e)
        {
            if (tabHoaDon.SelectedIndex >= 0)
            {
                HoaDon hd = new HoaDon();
                hd = hoaDonService.GetAllHoaDon().Where(x => x.MaHd == tabHoaDon.SelectedTab.Name).FirstOrDefault();
                hd.TrangThai = 1;
                hoaDonService.Update(hd);
                MessageBox.Show("Đơn hàng đã hoàn thành, cảm ơn bạn");
                Tabhoadondcmm();
                LoadHoaDonChoThanhToan();
                LoadHoaDonDaThanhToan();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tabHoaDon.SelectedIndex >= 0)
            {
                HoaDon hd = new HoaDon();
                hd = hoaDonService.GetAllHoaDon().Where(x => x.MaHd == tabHoaDon.SelectedTab.Name).FirstOrDefault();
                hd.TrangThai = 4;
                MessageBox.Show("Hủy hóa đơn thành công");
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
    }
}
