using _1.DAL.DomainClass;
using _2.BUS.IService;
using _2.BUS.IServices;
using _2.BUS.Serivces;
using _2.BUS.Service;
using _2.BUS.ViewModels;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

        private IGiaoCaService _iGiaoCaServicel = new GiaoCaService();
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        GiaoCa _gc = new GiaoCa();
        private INhanVienService _iNhanVienService;
        private IChucVuService _ichucVuService = new ChucVuServivce();
        private List<NhanVienView> _NvView = new List<NhanVienView>();
        public Guid SelectID { get; set; }
        private Guid? LastTK { get; set; }
        private Guid? CheckTk { get; set; }
        private GiaoCa LastGC { get; set; }
        public Form_Dasboard()
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;

            // LoaddataToChitietHoadon(SelectID);
            _iNhanVienService = new NhanVienService();
            _ichucVuService = new ChucVuServivce();
        }
        public Form_Dasboard(string a)
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            // LoaddataToChitietHoadon(SelectID);
            _iNhanVienService = new NhanVienService();
            this.lb_XinChao.Text = _iNhanVienService.getNhanViensFromDB().Where(x => x.Email == a).Select(a => a.Ten).FirstOrDefault();
            timer1.Enabled = true;
            NhanVien nv = new NhanVien();
            nv = _iNhanVienService.getNhanViensFromDB().FirstOrDefault(x => x.Email == a);
            MemoryStream memstr = new MemoryStream(nv.Anh);
            //Image img2 = Image.FromStream(memstr);
            //img2 = resizeImage(img2, new Size(80, 110));
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
            //pictureBox1.Image = img2;
            lb_chucvu.Text = _ichucVuService.getChucVusFromDB().Where(x => x.Id == nv.IdchucVu).Select(x => x.Ten).FirstOrDefault();
            LastTK = _iGiaoCaServicel.GetAll().Where(c => c.Ma == "GC" + _iGiaoCaServicel.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString()).FirstOrDefault().IdNhanVien;
            CheckTk = _iNhanVienService.getNhanViensFromDB().Where(p => p.Email == a).FirstOrDefault().Id;
            LastGC = _iGiaoCaServicel.GetAll().Last();
        }

        public Form_Dasboard(int b)
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            // LoaddataToChitietHoadon(SelectID);
            _iNhanVienService = new NhanVienService();
            //  this.lb_XinChao.Text = _iNhanVienService.getNhanViensFromDB().Where(x => x.Email == a).Select(a => a.Ten).FirstOrDefault();
            timer1.Enabled = true;

        }
        public Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
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
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    PanelTitel.BackColor = Color.FromArgb(127, 188, 210);
                    //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);


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




        private void OpenChildForm(Form ChildForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            this.PanelDesktopPanel.Controls.Add(ChildForm);
            this.PanelDesktopPanel.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
            labelTite.Text = ChildForm.Text;
        }


        private void btn_shopping_Click(object sender, EventArgs e)
        {
            if (btn_NhanCa.Visible == true)
            {
                MessageBox.Show("Bạn cần nhận ca để sử dụng chức năng này", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            OpenChildForm(new Form_BanHang(lb_XinChao.Text), sender);
            btn_shopping.BackColor = Color.FromArgb(63, 0, 113);
            labelTite.Text = "BÁN HÀNG";

        }


        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_NhanVien(), sender);
            btn_NhanVien.BackColor = Color.FromArgb(206, 119, 119);
            labelTite.Text = "NHÂN VIÊN";
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_KhachHang(), sender);
            btn_KhachHang.BackColor = Color.FromArgb(0, 2, 161);
            labelTite.Text = "KHÁCH HÀNG";
        }
        private void btn_sanpham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_ChiTietSach(lb_chucvu.Text), sender);
            btn_sanpham.BackColor = Color.FromArgb(251, 37, 118);
            labelTite.Text = "SẢN PHẨM";
        }
        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_Hoadon(), sender);
        }


        private void Form_Dasboard_Load(object sender, EventArgs e)
        {
            var cahientai = _iGiaoCaServicel.GetAll().Where(c => c.Ma == "GC" + _iGiaoCaServicel.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString()).FirstOrDefault();
            var idchucvu = _ichucVuService.getChucVusFromDB().Where(c => c.Ten.ToLower() == "Quản trị".ToLower()).Select(c => c.Id).FirstOrDefault();
            //Phân quyền
            foreach (var a in _iNhanVienService.getViewNhanViens())
            {
                if (a.nhanVien.Ten == lb_XinChao.Text && a.chucVu.Ten == "Nhân viên" && LastTK != CheckTk || a.nhanVien.Ten == lb_XinChao.Text && a.chucVu.Ten == "Nhân viên" && LastTK == CheckTk && cahientai.ThoiGianReset.ToString() != string.Empty)
                {
                    btn_NhanCa.Visible = true;
                    btn_HoaDon.Visible = false;
                    btn_shopping.Visible = false;
                    btn_KhachHang.Visible = false;
                    btn_NhanVien.Visible = false;
                    btn_sanpham.Visible = false;
                    btn_RutTien.Visible = false;
                    btn_KetCa.Visible = false;
                    return;
                }
                if (a.nhanVien.Ten == lb_XinChao.Text && a.chucVu.Ten == "Nhân viên" && LastTK == CheckTk && cahientai.ThoiGianReset.ToString() == string.Empty)
                {
                    btn_HoaDon.Visible = false;
                    btn_shopping.Visible = true;
                    btn_KhachHang.Visible = true;
                    btn_NhanVien.Visible = false;
                    btn_sanpham.Visible = true;
                    btn_RutTien.Visible = true;
                    btn_KetCa.Visible = true;
                    btn_NhanCa.Visible = false;
                    return;
                }
                if (a.chucVu.Ten == "Quản trị" && LastTK != CheckTk && cahientai.ThoiGianReset.ToString() == string.Empty)
                {
                    btn_HoaDon.Visible = true;
                    btn_sanpham.Visible = true;
                    btn_shopping.Visible = true;
                    btn_NhanVien.Visible = true;
                    btn_NhanCa.Visible = true;
                    btn_LogOut.Visible = true;
                    btn_RutTien.Visible = true;
                    btn_KetCa.Visible = true;
                    return;
                }
                if (a.nhanVien.Ten == lb_XinChao.Text && a.chucVu.Ten == "Quản trị" && LastTK == CheckTk && cahientai.ThoiGianReset.ToString() == string.Empty)
                {
                    btn_HoaDon.Visible = true;
                    btn_shopping.Visible = true;
                    btn_KhachHang.Visible = true;
                    btn_NhanVien.Visible = true;
                    btn_sanpham.Visible = true;
                    btn_RutTien.Visible = true;
                    btn_KetCa.Visible = true;
                    btn_NhanCa.Visible = false;
                    return;
                }
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_time.Text = DateTime.Now.ToLongTimeString();
            lb_date.Text = DateTime.Now.ToShortDateString();
            int a = _iGiaoCaServicel.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2)));
            string b = "GC" + a.ToString();
            lb_TongTien.Text = Convert.ToString(_iGiaoCaServicel.GetAll().Where(c => c.Ma == b).Select(c => c.TongTienTrongCa).FirstOrDefault());
            if (Form_GiaoCa.emailgiao == null && Form_GiaoCa.passgiao == null) return;
            if (Form_GiaoCa.emailgiao != null && Form_GiaoCa.passgiao != null)
            {
                int c = _iGiaoCaServicel.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2)));
                string d = "GC" + c.ToString();
                lb_TongTien.Text = Convert.ToString(_iGiaoCaServicel.GetAll().Where(c => c.Ma == d).Select(c => c.TongTienTrongCa).FirstOrDefault());
                //lb_TongTien.Text = Form_GiaoCa.TienGiao.ToString();
                var x = _iNhanVienService.getNhanViensFromDB().FirstOrDefault(c => c.Email == Form_GiaoCa.emailgiao);
                lb_XinChao.Text = x.Ten;
                var idqt = _ichucVuService.getChucVusFromDB().Where(c => c.Ten.ToLower() == "Quản trị".ToLower()).Select(c => c.Id).FirstOrDefault();
                var idnv = _ichucVuService.getChucVusFromDB().Where(c => c.Ten.ToLower() == "Nhân viên".ToLower()).Select(c => c.Id).FirstOrDefault();
                if (x.IdchucVu == idqt)
                {
                    btn_HoaDon.Visible = true;
                    btn_sanpham.Visible = true;
                    btn_shopping.Visible = true;
                    btn_NhanVien.Visible = true;
                    btn_NhanCa.Visible = false;
                    btn_LogOut.Visible = true;
                    btn_RutTien.Visible = true;
                    btn_KetCa.Visible = true;
                    return;
                }
                if (x.IdchucVu == idnv)
                {
                    btn_HoaDon.Visible = false;
                    btn_shopping.Visible = true;
                    btn_KhachHang.Visible = true;
                    btn_NhanVien.Visible = false;
                    btn_sanpham.Visible = true;
                    btn_RutTien.Visible = true;
                    btn_KetCa.Visible = true;
                    btn_NhanCa.Visible = false;
                    return;
                }
                Form_GiaoCa.emailgiao = null;
                Form_GiaoCa.passgiao = null;
                //Form_KetCa.TongTien = Convert.ToDecimal(null);
            }
        }

        private void btn_NhanCa_Click(object sender, EventArgs e)
        {
            var cahientai = _iGiaoCaServicel.GetAll().Where(c => c.Ma == "GC" + _iGiaoCaServicel.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString()).FirstOrDefault();
            if (cahientai.ThoiGianReset.ToString()==string.Empty)
            {
                MessageBox.Show("Bạn cần kết thúc ca cũ trước khi nhận ca mới, vui lòng liên hệ nhân viên ca cũ để kết thúc ca", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            Form_NhanCaLam.TongTien = 0;
            Form_NhanCaLam form_NhanCaLam = new Form_NhanCaLam();
            form_NhanCaLam.ShowDialog();
            if (Form_NhanCaLam.TongTien == 0) return;
            lb_TongTien.Text = Form_NhanCaLam.TongTien.ToString();
            var x = _iNhanVienService.getNhanViensFromDB().FirstOrDefault(c => c.Email == Form_DangNhap.Email);
            var idqt = _ichucVuService.getChucVusFromDB().Where(c => c.Ten.ToLower() == "Quản trị".ToLower()).Select(c => c.Id).FirstOrDefault();
            var idnv = _ichucVuService.getChucVusFromDB().Where(c => c.Ten.ToLower() == "Nhân viên".ToLower()).Select(c => c.Id).FirstOrDefault();
            if (x.IdchucVu == idqt)
            {
                btn_HoaDon.Visible = true;
                btn_sanpham.Visible = true;
                btn_shopping.Visible = true;
                btn_NhanVien.Visible = true;
                btn_NhanCa.Visible = false;
                btn_LogOut.Visible = true;
                btn_RutTien.Visible = true;
                btn_KetCa.Visible = true;
                return;
            }
            if (x.IdchucVu == idnv)
            {
                btn_HoaDon.Visible = false;
                btn_shopping.Visible = true;
                btn_KhachHang.Visible = true;
                btn_NhanVien.Visible = false;
                btn_sanpham.Visible = true;
                btn_RutTien.Visible = true;
                btn_KetCa.Visible = true;
                btn_NhanCa.Visible = false;
                return;
            }
        }

        private void btn_RutTien_Click(object sender, EventArgs e)
        {
            if (btn_NhanCa.Visible == true)
            {
                MessageBox.Show("Bạn cần nhận ca để sử dụng chức năng này", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            OpenChildForm(new Form_RutTien(), sender);
            labelTite.Text = "Rút Tiền";
        }
        public static decimal TienKetCa;
        private void btn_KetCa_Click(object sender, EventArgs e)
        {
            if (btn_NhanCa.Visible == true)
            {
                MessageBox.Show("Bạn cần nhận ca để sử dụng chức năng này", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            TienKetCa = Convert.ToDecimal(lb_TongTien.Text);
            OpenChildForm(new Form_GiaoCa(), sender);
            labelTite.Text = "Giao Ca";
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            var cahientai = _iGiaoCaServicel.GetAll().Where(c => c.Ma == "GC" + _iGiaoCaServicel.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString()).FirstOrDefault();
            GiaoCa gc = new GiaoCa();

            if (btn_NhanCa.Visible == true)
            {
                DialogResult dx = MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dx == DialogResult.Yes)
                {
                    Form_DangNhap frm = new Form_DangNhap();
                    this.Close();
                    frm.Show();
                    return;
                }
                else return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn kết thúc ca không?", "Thông báo", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                gc.Id = cahientai.Id;
                gc.ThoiGianReset = DateTime.Now;
                _iGiaoCaServicel.UpdateKetCa(gc);
                Form_DangNhap frm = new Form_DangNhap();
                this.Close();
                frm.Show();
            }
            if (dialogResult == DialogResult.No)
            {
                Form_DangNhap frm = new Form_DangNhap();
                this.Close();
                frm.Show();
                return;
            }
            if (dialogResult == DialogResult.Cancel) return;
            //Application.Exit();
        }
        //a
        private void btn_doimatkhau_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_DoiMatKhau(), sender);
            btn_doimatkhau.BackColor = Color.FromArgb(0, 2, 161);
            labelTite.Text = "ĐỔI MẬT KHẨU";
        }
    }
}
