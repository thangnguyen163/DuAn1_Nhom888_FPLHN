using _1.DAL.DomainClass;
using _2.BUS.IService;
using _2.BUS.IServices;
using _2.BUS.Serivces;
using _2.BUS.Service;
using _2.BUS.ViewModels;
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
        private INhanVienService _iNhanVienService;
        private List<NhanVienView> _NvView= new List<NhanVienView>();
        public Guid SelectID { get; set; }
        
        public Form_Dasboard()
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            // LoaddataToChitietHoadon(SelectID);
            _iNhanVienService = new NhanVienService();
        }
        public Form_Dasboard(string a)
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            // LoaddataToChitietHoadon(SelectID);
            _iNhanVienService = new NhanVienService();
            this.lb_XinChao.Text = _iNhanVienService.getNhanViensFromDB().Where(x => x.Email == a).Select(a => a.Ten).FirstOrDefault();
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

        }
        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_NhanVien(), sender);
            btn_NhanVien.BackColor = Color.FromArgb(206, 119, 119);
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_KhachHang(), sender);
            btn_KhachHang.BackColor = Color.FromArgb(0, 2, 161);
        }
        private void btn_sanpham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_ChiTietSach(), sender);
            btn_sanpham.BackColor = Color.FromArgb(251, 37, 118);
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
          foreach(var a in _iNhanVienService.getViewNhanViens())
          {
                if (a.nhanVien.Ten == lb_XinChao.Text && a.chucVu.Ten== "Nhân viên")
                {
                    btn_NhanVien.Visible = false;
                    btn_sanpham.Visible = false;
                }
          }
             
        }
    }
}
