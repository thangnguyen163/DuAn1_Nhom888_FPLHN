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
            Image img2 = Image.FromStream(memstr);
            //img2 = resizeImage(img2, new Size(80, 110));
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
            pictureBox1.Image = img2;
            lb_chucvu.Text = _ichucVuService.getChucVusFromDB().Where(x=>x.Id==nv.IdchucVu).Select(x=>x.Ten).FirstOrDefault();
        }
        //public static Image resizeImage(Image imgToResize, Size size)
        //{
        //    return (Image)(new Bitmap(imgToResize, size));
        //}
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
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
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
            OpenChildForm(new Form_BanHang(lb_XinChao.Text), sender);
            btn_shopping.BackColor = Color.FromArgb(63, 0, 113);
            labelTite.Text = "BÁN HÀNG";

        }
        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            OpenChildForm(new Form_ChiTietSach(), sender);
            btn_sanpham.BackColor = Color.FromArgb(251, 37, 118);
            labelTite.Text = "SẢN PHẨM";
        }


        //private void logout_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        private void dtg_hoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //  SelectID = Guid.Parse(dtg_hoadon.CurrentRow.Cells[1].Value.ToString());
            ////  SelectID = Guid.Parse(dtg_showchitiet.CurrentRow.Cells[1].Value.ToString());
            //  LoaddataToChitietHoadon(SelectID);
        }

        private void dtg_sanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_Hoadon(), sender);
        }


        private void Form_Dasboard_Load(object sender, EventArgs e)
        {
            //Phân quyền
            foreach (var a in _iNhanVienService.getViewNhanViens())
            {
                if (a.nhanVien.Ten == lb_XinChao.Text && a.chucVu.Ten == "Nhân viên")
                {
                    btn_HoaDon.Visible = false;
                    btn_shopping.Visible = false;
                    btn_KhachHang.Visible = false;
                    btn_NhanVien.Visible = false;
                    btn_sanpham.Visible = false;
                    btn_RutTien.Visible = false;
                    btn_KetCa.Visible = false;

                }
                else if (a.nhanVien.Ten == lb_XinChao.Text && a.chucVu.Ten == "Quản trị")
                {
                    btn_HoaDon.Visible = true;
                    btn_sanpham.Visible = true;
                    btn_shopping.Visible = true;
                    btn_NhanVien.Visible = true;
                    btn_NhanCa.Visible = true;
                    btn_LogOut.Visible = true;
                    btn_RutTien.Visible = true;
                    btn_KetCa.Visible = true;

                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_time.Text = DateTime.Now.ToLongTimeString();
            lb_date.Text = DateTime.Now.ToShortDateString();
        }

        private void btn_NhanCa_Click(object sender, EventArgs e)
        {
            Form_NhanCaLam form_NhanCaLam = new Form_NhanCaLam();
            form_NhanCaLam.ShowDialog();
            lb_TongTien.Text = Form_NhanCaLam.TongTien.ToString();
            if (lb_TongTien.Text != String.Empty && Convert.ToDecimal(lb_TongTien.Text) > 0)
            {
                btn_KhachHang.Visible = true;
                btn_shopping.Visible = true;
                btn_HoaDon.Visible = true;
                btn_RutTien.Visible = true;
                btn_KetCa.Visible = true;
            }


            btn_NhanCa.Visible = true;
            if (btn_shopping.Visible == true)
            {
                btn_NhanCa.Visible = false;
            }
        }

        private void btn_RutTien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RutTien(), sender);
            labelTite.Text = "Rút Tiền";
        }
        public static decimal TienKetCa;
        private void btn_KetCa_Click(object sender, EventArgs e)
        {
            TienKetCa = Convert.ToDecimal(lb_TongTien.Text);
            OpenChildForm(new Form_KetCa(), sender);
            labelTite.Text = "Kết Ca";
        }

        public int tienbitru { get; set; }
        private void btn_LamMoi_Click(object sender, EventArgs e)
        {

            string b = (Convert.ToString("GC" + _iGiaoCaServicel.GetAll().Count()));
            GiaoCa tien = _iGiaoCaServicel.GetAll().FirstOrDefault(c => c.Ma == b);
            //tienbitru = Convert.ToInt32(lb_TongTien.Text) - Convert.ToInt32(tien.TongTienTrongCa.ToString());
            lb_TongTien.Text = Convert.ToString(tien.TongTienTrongCa);
            
        }
        public void closeForm()
        {
            this.Dispose();
        }

    }
}
