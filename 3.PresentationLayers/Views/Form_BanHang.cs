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
        private IChiTietSachService chiTietSachService;

        private ISachService sachService;
        private IHoaDonChiTietService hoaDonChiTietService;
        
        public Form_BanHang()
        {
            InitializeComponent();
            hoaDonService = new HoaDonService();
            chiTietSachService = new ChiTietSachService();
            sachService = new SachService();
            hoaDonChiTietService = new HoaDonChiTietService();
        }


        public void LoadSach()
        {
            int i=0;
            dtg_SanPham.ColumnCount = 18;
            dtg_SanPham.Columns[0].Name = "Stt";
            dtg_SanPham.Columns[1].Name = "ID";
            dtg_SanPham.Columns[1].Visible = false;
            dtg_SanPham.Columns[2].Name = "Sách";
            dtg_SanPham.Columns[3].Name = "Nhà xuất bản";
            dtg_SanPham.Columns[4].Name = "Tác giả";
            dtg_SanPham.Columns[5].Name = "Nhà phát hành";
            dtg_SanPham.Columns[6].Name = "Loại bìa";
            dtg_SanPham.Columns[7].Name = "Mã";
            dtg_SanPham.Columns[8].Name = "";
            dtg_SanPham.Columns[9].Name = "Stt";
            dtg_SanPham.Columns[10].Name = "Stt";
            dtg_SanPham.Columns[11].Name = "Stt";
            dtg_SanPham.Columns[12].Name = "Stt";
            dtg_SanPham.Columns[13].Name = "Stt";
            dtg_SanPham.Columns[14].Name = "Stt";
            dtg_SanPham.Columns[15].Name = "Stt";
            dtg_SanPham.Columns[16].Name = "Stt";
            dtg_SanPham.Columns[17].Name = "Stt";
            
            
        }

        public void LoadHoaDon()
        {
            

        }

        public void LoadHoaDonChiTiet()
        {
            int i = 1;
            dtg_HoaDonChiTiet.ColumnCount = 10;
            dtg_HoaDonChiTiet.Columns[0].Name = "Stt";
        }

      
    }
}
