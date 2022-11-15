﻿using _1.DAL.DomainClass;
using _2.BUS.IService;
using _2.BUS.Service;
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
//using FontAwesome.Sharp;

namespace _3.PresentationLayers.Views
{
    public partial class Form_ChiTietSach : Form
    {
        private IChiTietSachService _iChiTietSachService;
        private List<ChiTietSach> _lstChiTietSach;
        private List<ChiTietSachView> _lstChiTietSachView;
        private Guid? SelectedID;
        private ISachService _iSachService;
        private ITacGiaService _iTacGiaService;
        private ITheLoaiService _iTheLoaiService;
        private IChiTietTheLoaiService _iTietTheLoaiService;
        private INXBService _iNXBService;
        private ILoaiBiaService _iLoaiBiaService;
        private INhaPhatHanhService _iNhaPhatHanhService;

        public Form_ChiTietSach()
        {
            InitializeComponent();
            _iChiTietSachService = new ChiTietSachService();
            _lstChiTietSach = new List<ChiTietSach>();
            _lstChiTietSachView = new List<ChiTietSachView>();
            _iSachService = new SachService();
            _iTacGiaService = new TacGiaService();
            _iTheLoaiService = new TheLoaiService();
            _iNXBService = new NXBService();
            _iLoaiBiaService = new LoaiBiaService();
            _iNhaPhatHanhService = new NhaPhatHanhService();
            LoadData();
            LoadCbb();
        }
        void LoadData()
        {
            int stt = 0;
            dtg_Show.ColumnCount = 16;
            dtg_Show.Columns[0].Name = "STT";
            dtg_Show.Columns[1].Name = "Id";
            dtg_Show.Columns[1].Visible = false;
            dtg_Show.Columns[2].Name = "Sách";
            dtg_Show.Columns[3].Name = "NXB";
            dtg_Show.Columns[4].Name = "Tác giả";
            dtg_Show.Columns[5].Name = "NPH";
            dtg_Show.Columns[6].Name = "Loại bìa";
            dtg_Show.Columns[7].Name = "Mã";
            dtg_Show.Columns[8].Name = "Kích thước";
            dtg_Show.Columns[9].Name = "Năm xuất bản";
            dtg_Show.Columns[10].Name = "Mô tả";
            dtg_Show.Columns[11].Name = "Số trang";
            dtg_Show.Columns[12].Name = "Số lượng";
            dtg_Show.Columns[13].Name = "Giá nhập";
            dtg_Show.Columns[14].Name = "Giá bán";
            dtg_Show.Columns[15].Name = "Trạng thái";
            dtg_Show.Rows.Clear();
            foreach (var a in _iChiTietSachService.GetAllChiTietSachView())
            {
                dtg_Show.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Hết sách" : "Còn bán");
            }
        }
        void LoadCbb()
        {
            foreach (var a in _iSachService.GetAll())
            {
                cbb_Sach.Items.Add(a.Ten);
            }
            foreach (var a in _iNXBService.GetAllNoView())
            {
                cbb_NXB.Items.Add(a.Ten);
            }
            foreach (var a in _iTacGiaService.GetAll())
            {
                cbb_TacGia.Items.Add(a.Ten);
            }
            foreach (var a in _iNhaPhatHanhService.GetAll())
            {
                cbb_NhaPhatHanh.Items.Add(a.Ten);
            }
            foreach (var a in _iLoaiBiaService.GetLoaiBia())
            {
                cbb_LoaiBia.Items.Add(a.Ten);
            }
        }
        private void dtg_Show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == -1) return;
            SelectedID = Guid.Parse(Convert.ToString(dtg_Show.Rows[rd].Cells[1].Value));
            cbb_Sach.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[2].Value);
            cbb_NXB.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[3].Value);
            cbb_TacGia.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[4].Value);
            cbb_NhaPhatHanh.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[5].Value);
            cbb_LoaiBia.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[6].Value);
            tbt_Ma.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[7].Value);
            tbt_KichThuoc.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[8].Value);
            tbt_NamXuatBan.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[9].Value);
            tbt_MoTa.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[10].Value);
            tbt_SoTrang.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[11].Value);
            tbt_SoLuong.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[12].Value);
            tbt_GiaNhap.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[13].Value);
            tbt_GiaBan.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[14].Value);
            rdt_ConBan.Checked = Convert.ToString(dtg_Show.Rows[rd].Cells[15].Value) == "Còn bán";
            rdt_KhongBan.Checked = Convert.ToString(dtg_Show.Rows[rd].Cells[15].Value) == "Hết sách";

        }

        private void tbt_Search_TextChanged(object sender, EventArgs e)
        {

        }


        private void label8_Click(object sender, EventArgs e)
        {

        }





        private void btn_Add_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốnt thêm chi tiết cho sách", "Thông báo ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_iChiTietSachService.Add(new ChiTietSach()
                {
                    Id = Guid.NewGuid(),
                    IdSach = _iSachService.GetAllNoView().Where(x => x.Ten == Convert.ToString(cbb_Sach.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdNxb = _iNXBService.GetAllNoView().Where(x => x.Ten == Convert.ToString(cbb_NXB.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdTacGia = _iTacGiaService.GetAll().Where(x => x.Ten == Convert.ToString(cbb_TacGia.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdNhaPhatHanh = _iNhaPhatHanhService.GetAll().Where(x => x.Ten == Convert.ToString(cbb_NhaPhatHanh.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdLoaiBia = _iLoaiBiaService.GetLoaiBia().Where(x => x.Ten == Convert.ToString(cbb_LoaiBia.Text)).Select(x => x.Id).FirstOrDefault(),
                    Ma = tbt_Ma.Text,
                    KichThuoc = tbt_KichThuoc.Text,
                    NamXuatBan = Convert.ToInt32(tbt_NamXuatBan.Text),
                    MoTa = tbt_MoTa.Text,
                    SoTrang = Convert.ToInt32(tbt_SoTrang.Text),
                    SoLuong = Convert.ToInt32(tbt_SoLuong.Text),
                    GiaNhap = Convert.ToInt32(tbt_GiaNhap.Text),
                    GiaBan = Convert.ToInt32(tbt_GiaBan.Text),
                    TrangThai = rdt_ConBan.Checked == true ? 1 : 0,

                }));
                LoadData();
            }
            if (dialogResult == DialogResult.No) return;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốnt Update chi tiết cho sách", "Thông báo ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_iChiTietSachService.Update(SelectedID,new ChiTietSach()
                {

                    IdSach = _iSachService.GetAllNoView().Where(x => x.Ten == Convert.ToString(cbb_Sach.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdNxb = _iNXBService.GetAllNoView().Where(x => x.Ten == Convert.ToString(cbb_NXB.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdTacGia = _iTacGiaService.GetAll().Where(x => x.Ten == Convert.ToString(cbb_TacGia.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdNhaPhatHanh = _iNhaPhatHanhService.GetAll().Where(x => x.Ten == Convert.ToString(cbb_NhaPhatHanh.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdLoaiBia = _iLoaiBiaService.GetLoaiBia().Where(x => x.Ten == Convert.ToString(cbb_LoaiBia.Text)).Select(x => x.Id).FirstOrDefault(),
                    Ma = tbt_Ma.Text,
                    KichThuoc = tbt_KichThuoc.Text,
                    NamXuatBan = Convert.ToInt32(tbt_NamXuatBan.Text),
                    MoTa = tbt_MoTa.Text,
                    SoTrang = Convert.ToInt32(tbt_SoTrang.Text),
                    SoLuong = Convert.ToInt32(tbt_SoLuong.Text),
                    GiaNhap = Convert.ToInt32(tbt_GiaNhap.Text),
                    GiaBan = Convert.ToInt32(tbt_GiaBan.Text),
                    TrangThai = rdt_ConBan.Checked == true ? 1 : 0,

                }));
                LoadData();
            }
            if (dialogResult == DialogResult.No) return;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốnt thêm chi tiết cho sách", "Thông báo ", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    MessageBox.Show(_iChiTietSachService.Add(new ChiTietSach()
            //    {
            //        TrangThai = rdt_ConBan.Checked == true ? 1 : 0,

            //    }));
            //    LoadData();
            //}
            //if (dialogResult == DialogResult.No) return;
        }
    }
}