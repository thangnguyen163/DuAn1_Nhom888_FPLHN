using _1.DAL.DomainClass;
using _2.BUS.IService;
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
    public partial class Form_AddNhanh : Form
    {
        private string a1;
        private ISachService _iSachService;
        private INXBService _iNXBService;
        private INhaPhatHanhService _iNhaPhatHanhService;
        private ITacGiaService _iTacGiaService;
        private ILoaiBiaService _iLoaiBiaService;
        private ITheLoaiService _iTheLoaiService;
        private IChiTietTheLoaiService _iChiTietTheLoaiService;
        public Form_AddNhanh()
        {
            InitializeComponent();
            _iSachService = new SachService();
            _iTacGiaService = new TacGiaService();
            _iNXBService = new NXBService();
            _iNhaPhatHanhService = new NhaPhatHanhService();
            _iLoaiBiaService = new LoaiBiaService();
            _iTheLoaiService = new TheLoaiService();
            _iChiTietTheLoaiService = new ChiTietTheLoaiService();
        }
        public Form_AddNhanh(string a)
        {
            InitializeComponent();
            this.a1 = a;
            lb_ThemNhanh.Text = a1;
            lb_Ten.Text = a1;
            _iSachService = new SachService();
            _iTacGiaService = new TacGiaService();
            _iNXBService = new NXBService();
            _iNhaPhatHanhService = new NhaPhatHanhService();
            _iLoaiBiaService = new LoaiBiaService();
            _iTheLoaiService = new TheLoaiService();
            LoadNhomCha();
            
        }
        void LoadCbbCha()
        {
            foreach (var a in _iTheLoaiService.GetAll())
            {
                cbb_Cha.Items.Add(a.Ten);
            }
        }



        private void btn_BoQua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadCbbAddNhanh()
        {
            Form_ChiTietSach ChiTietSach = new Form_ChiTietSach();
            ChiTietSach.LoadCbb();

        }
        void LoadNhomCha()
        {
            if (Convert.ToString(lb_ThemNhanh.Text) == "sách"     || Convert.ToString(lb_ThemNhanh.Text) == "NXB" ||
                Convert.ToString(lb_ThemNhanh.Text) == "Tác giả"  || Convert.ToString(lb_ThemNhanh.Text) == "Nhà phát hành" ||
                Convert.ToString(lb_ThemNhanh.Text) == "Loại bìa" || Convert.ToString(lb_ThemNhanh.Text) == "Thể loại")
            {
                lb_NhomCha.Visible = false;
                cbb_Cha.Visible = false;
            }
            else
            {
                lb_NhomCha.Visible = true;
                cbb_Cha.Visible = true;
                LoadCbbCha();
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(lb_ThemNhanh.Text) == "sách")
            {

                MessageBox.Show(_iSachService.Add(new Sach()
                {

                    Id = Guid.NewGuid(),
                    Ma = "S" + Convert.ToString(_iSachService.GetAll()
                      .Max(c => Convert.ToInt32(c.Ma.Substring(1, c.Ma.Length - 1)) + 1)),
                    Ten = tbt_Ten.Text,
                    TrangThai = 1,
                }));
            }
            if (Convert.ToString(lb_ThemNhanh.Text) == "NXB")
            {

                MessageBox.Show(_iNXBService.Add(new Nxb()
                {

                    Id = Guid.NewGuid(),
                    Ma = "NXB" + Convert.ToString(_iNXBService.GetAll()
                      .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1)),
                    Ten = tbt_Ten.Text,
                    TrangThai = 1,
                }));
            }
            if (Convert.ToString(lb_ThemNhanh.Text) == "Tác giả")
            {

                MessageBox.Show(_iTacGiaService.Add(new TacGium()
                {

                    Id = Guid.NewGuid(),
                    Ma = "TG" + Convert.ToString(_iTacGiaService.GetAll()
                      .Max(c => Convert.ToInt32(c.Ma.Substring(2, c.Ma.Length - 2)) + 1)),
                    Ten = tbt_Ten.Text,
                    TrangThai = 1,
                }));
            }
            if (Convert.ToString(lb_ThemNhanh.Text) == "Nhà phát hành")
            {
                MessageBox.Show(_iNhaPhatHanhService.Add(new NhaPhatHanh()
                {

                    Id = Guid.NewGuid(),
                    Ma = "NPH" + Convert.ToString(_iNhaPhatHanhService.GetAll()
                      .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1)),
                    Ten = tbt_Ten.Text,
                    TrangThai = 1,
                }));
            }
            if (Convert.ToString(lb_ThemNhanh.Text) == "Loại bìa")
            {

                MessageBox.Show(_iLoaiBiaService.Add(new LoaiBium()
                {

                    Id = Guid.NewGuid(),
                    Ma = "S" + Convert.ToString(_iLoaiBiaService.GetLoaiBia()
                      .Max(c => Convert.ToInt32(c.Ma.Substring(1, c.Ma.Length - 1)) + 1)),
                    Ten = tbt_Ten.Text,
                    TrangThai = 1,
                }));
            }
            if (Convert.ToString(lb_ThemNhanh.Text) == "Thể loại")
            {

                MessageBox.Show(_iTheLoaiService.Add(new TheLoai()
                {

                    Id = Guid.NewGuid(),
                    Ma = "Tl" + Convert.ToString(_iLoaiBiaService.GetLoaiBia()
                      .Max(c => Convert.ToInt32(c.Ma.Substring(2, c.Ma.Length - 2)) + 1)),
                    Ten = tbt_Ten.Text,
                    TrangThai = 1,
                }));
            }
            if (Convert.ToString(lb_ThemNhanh.Text) == "Thể loại chi tiết")
            {
                MessageBox.Show(_iChiTietTheLoaiService.Add(new ChiTietTheLoai()
                {

                    Id = Guid.NewGuid(),
                    Ma = "CTTL" + Convert.ToString(_iLoaiBiaService.GetLoaiBia()
                      .Max(c => Convert.ToInt32(c.Ma.Substring(4, c.Ma.Length - 4)) + 1)),
                    IdTheLoai = _iTheLoaiService.GetAllNoView().Where(c => c.Ten == cbb_Cha.Text).Select(c => c.Id).FirstOrDefault(),
                    Ten = tbt_Ten.Text,
                    TrangThai = 1,
                }));
            }
            LoadCbbAddNhanh();
            this.Close();

        }
    }
}
