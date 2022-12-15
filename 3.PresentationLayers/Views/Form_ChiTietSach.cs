using _1.DAL.DomainClass;
using _2.BUS.IService;
using _2.BUS.Service;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Microsoft.VisualBasic;
using _3_GUI_PresentaionLayers;
using _2.BUS.IServices;
using _2.BUS.Serivces;

namespace _3.PresentationLayers.Views
{
    public partial class Form_ChiTietSach : Form
    {
        private IChiTietSachService _iChiTietSachService;
        private List<ChiTietSach> _lstChiTietSach;
        private List<ChiTietSachView> _lstChiTietSachView;
        private Guid? SelectedID;
        private ISachService _iSachService;
        private IHoaDonChiTietService _ihoaDonchitietService = new HoaDonChiTietService();
        private ITacGiaService _iTacGiaService;
        private ITheLoaiService _iTheLoaiService;
        private INXBService _iNXBService;
        private ILoaiBiaService _iLoaiBiaService;
        private INhaPhatHanhService _iNhaPhatHanhService;
        private ChiTietSach ChiTietSach;
        private string LinkImage = "";


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
            ChiTietSach = new ChiTietSach();
        }
        public Form_ChiTietSach(string ChucVu)
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
            ChiTietSach = new ChiTietSach();
            if (ChucVu == "Nhân viên")
            {
                btn_Add.Visible = false;
                btn_Update.Visible = false;
                btn_Delete.Visible = false;
                btn_NgungKinhDoanh.Visible = false;
                btn_Reset.Visible = false;
            }
            else
            {
                btn_Add.Visible = true;
                btn_Update.Visible = true;
                btn_Delete.Visible = true;
                btn_NgungKinhDoanh.Visible = true;
                btn_Reset.Visible = true;
            }

        }
        void LoadData()
        {
            int stt = 1;
            dtg_Show.ColumnCount = 19;
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
            dtg_Show.Columns[16].Name = "Đường Dẫn";
            dtg_Show.Columns[16].Visible = false;
            dtg_Show.Columns[17].Name = "Mã vạch";
            dtg_Show.Columns[18].Name = "Thể loại ";
            dtg_Show.Rows.Clear();
            foreach (var a in _iChiTietSachService.GetAllChiTietSachView().OrderBy(x => x.Ma))
            {
                dtg_Show.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Ngừng kinh doanh" : "Còn bán", a.Anh, a.MaVach, a.TenTheLoai);
            }
        }


        public void LoadCbb()
        {
            try
            {
                cbb_Sach.Items.Clear();
                cbb_NXB.Items.Clear();
                cbb_TacGia.Items.Clear();
                cbb_NhaPhatHanh.Items.Clear();
                cbb_LoaiBia.Items.Clear();
                cbb_TheLoai.Items.Clear();
                cbb_TheLoai2.Items.Clear();
                foreach (var a in _iSachService.GetAll())
                {
                    cbb_Sach.Items.Add(a.Ten);

                }
                foreach (var a in _iNXBService.GetAllNoView())
                {
                    cbb_NXB.Items.Add(a.Ten);
                    cbb_LocNXB.Items.Add(a.Ten);
                }
                foreach (var a in _iTacGiaService.GetAll())
                {
                    cbb_TacGia.Items.Add(a.Ten);
                    cbb_LocTacGia.Items.Add(a.Ten);
                }
                foreach (var a in _iNhaPhatHanhService.GetAll())
                {
                    cbb_NhaPhatHanh.Items.Add(a.Ten);
                    cbb_LocNhaPhatHanh.Items.Add(a.Ten);
                }
                foreach (var a in _iLoaiBiaService.GetLoaiBia())
                {
                    cbb_LoaiBia.Items.Add(a.Ten);
                    cbb_LocLoaiBia.Items.Add(a.Ten);
                }
                foreach (var a in _iTheLoaiService.GetAllNoView().Where(x => x.IdCha == null))
                {
                    cbb_TheLoai.Items.Add(a.Ten);
                }
                cbb_LocTrangThai.Items.Add("Còn bán");
                cbb_LocTrangThai.Items.Add("Ngừng kinh doanh");

            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }


        }
        private void cbb_TheLoai_TextChanged(object sender, EventArgs e)
        {
            cbb_TheLoai2.Items.Clear();
            var idcha = _iTheLoaiService.GetAllNoView().FirstOrDefault(c => c.Ten == cbb_TheLoai.Text);
            if (idcha != null)
                foreach (var a in _iTheLoaiService.GetAllNoView().Where(x => x.IdCha == idcha.Id))
                {
                    cbb_TheLoai2.Items.Add(a.Ten);

                }
            else cbb_TheLoai2.Text = string.Empty;
        }
        private void dtg_Show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
                //tbt_KichThuoc.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[8].Value);
                tbt_NamXuatBan.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[9].Value);
                tbt_MoTa.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[10].Value);
                tbt_SoTrang.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[11].Value);
                tbt_SoLuong.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[12].Value);
                tbt_GiaNhap.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[13].Value);
                tbt_GiaBan.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[14].Value);
                rdt_ConBan.Checked = Convert.ToString(dtg_Show.Rows[rd].Cells[15].Value) == "Còn bán";
                rdt_KhongBan.Checked = Convert.ToString(dtg_Show.Rows[rd].Cells[15].Value) == "Ngừng kinh doanh";
                ptb_AnhSach.Image = Image.FromStream(new MemoryStream((byte[])dtg_Show.Rows[rd].Cells[16].Value));
                ptb_AnhSach.SizeMode = PictureBoxSizeMode.StretchImage;
                tbt_MaVach.Text = Convert.ToString(dtg_Show.Rows[rd].Cells[17].Value);
                TheLoai TheLoai = _iTheLoaiService.GetAllNoView().FirstOrDefault(x => x.Ten == Convert.ToString(dtg_Show.Rows[rd].Cells[18].Value));
                if (TheLoai.IdCha != null)
                {
                    var TheLoaiCha = _iTheLoaiService.GetAllNoView().FirstOrDefault(q => q.Id == TheLoai.IdCha).Ten;
                    cbb_TheLoai.Text = TheLoaiCha.ToString();
                    cbb_TheLoai2.Text = TheLoai.Ten.ToString();
                }
                else
                {
                    cbb_TheLoai.Text = TheLoai.Ten.ToString();
                    cbb_TheLoai2.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }
        }

        private void tbt_Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int stt = 1;
                dtg_Show.ColumnCount = 19;
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
                dtg_Show.Columns[15].Name = "Trạng thái"
                dtg_Show.Columns[16].Name = "Đường Dẫn";
                //dtg_Show.Columns[16].Visible = false;
                dtg_Show.Columns[17].Name = "Mã vạch";
                dtg_Show.Columns[18].Name = "Thể loại ";
                dtg_Show.Rows.Clear();
                foreach (var a in _iChiTietSachService.GetAllChiTietSachView().Where(x => x.TenSach.Contains(tbt_Search.Text)).OrderBy(x => x.Ma))
                {
                    dtg_Show.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Ngừng kinh doanh" : "Còn bán", a.Anh, a.MaVach, a.TenTheLoai);
                }
                cbb_LocLoaiBia.Text = string.Empty;
                cbb_LocNXB.Text = string.Empty;
                cbb_LocNhaPhatHanh.Text = string.Empty;
                cbb_LocTacGia.Text = string.Empty;
                cbb_LocTheLoai.Text = string.Empty;
                tbt_GiaMax.Text = string.Empty;
                tbt_GiaMin.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }




        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckNull
                if (cbb_Sach.Text == string.Empty)
                {
                    MessageBox.Show("Sách không được để trống!!!!", "ERROR");
                    return;
                }
                else if (cbb_TheLoai.Text == string.Empty)
                {
                    MessageBox.Show("Thể loại không được để trống!!!!", "ERROR");
                    return;
                }
                else if (cbb_NXB.Text == string.Empty)
                {
                    MessageBox.Show("NXb không được để trống!!!!", "ERROR");
                    return;
                }
                else if (cbb_TacGia.Text == string.Empty)
                {
                    MessageBox.Show("Tác giả không được để trống!!!!", "ERROR");
                    return;
                }
                else if (cbb_NhaPhatHanh.Text == string.Empty)
                {
                    MessageBox.Show("Nhà phát hành không được để trống!!!!", "ERROR");
                    return;
                }
                else if (cbb_LoaiBia.Text == string.Empty)
                {
                    MessageBox.Show("Loại bìa không được để trống!!!!", "ERROR");
                    return;
                }
                else if (tbt_MaVach.Text == string.Empty)
                {
                    MessageBox.Show("Mã vạch không được để trống!!!!", "ERROR");
                    return;
                }
                else if (tbt_NamXuatBan.Text == string.Empty)
                {
                    MessageBox.Show("Năm xuất bản không được để trống!!!!", "ERROR");
                    return;
                }
                else if (tbt_SoTrang.Text == string.Empty)
                {
                    MessageBox.Show("Số trang không được để trống!!!!", "ERROR");
                    return;
                }
                else if (tbt_SoLuong.Text == string.Empty)
                {
                    MessageBox.Show("Số lượng không được để trống!!!!", "ERROR");
                    return;
                }
                else if (tbt_GiaNhap.Text == string.Empty)
                {
                    MessageBox.Show("Giá nhập không được để trống!!!!", "ERROR");
                    return;
                }
                else if (tbt_GiaBan.Text == string.Empty)
                {
                    MessageBox.Show("Giá bán không được để trống!!!!", "ERROR");
                    return;
                }
                else if (rdt_ConBan.Checked == false && rdt_KhongBan.Checked == false)
                {
                    MessageBox.Show("Trạng thái không được để trống!!!!", "ERROR");
                    return;
                }
                else if (Convert.ToInt32(tbt_SoLuong.Text) == 0)
                {
                    MessageBox.Show("Số lượng không được = 0!!!!", "ERROR");
                    return;
                }
                else if (Convert.ToInt32(tbt_GiaBan.Text) < Convert.ToInt32(tbt_GiaNhap.Text))
                {
                    MessageBox.Show("Giá bán không được nhỏ hơn giá nhập!!!!", "ERROR");
                    return;
                }

                #endregion

                else
                {
                    Guid idTheLoai = Guid.Empty;
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm chi tiết cho sách", "Thông báo ", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (cbb_TheLoai.Text == String.Empty)
                        {
                            MessageBox.Show("Bạn chưa chọn thể loại", "Thông báo");
                            return;
                        }
                        else if (cbb_TheLoai.Text != String.Empty && cbb_TheLoai2.Text == String.Empty)
                        {
                            idTheLoai = _iTheLoaiService.GetAllNoView().FirstOrDefault(a => a.Ten == cbb_TheLoai.Text).Id;
                        }
                        else
                        {
                            idTheLoai = _iTheLoaiService.GetAllNoView().FirstOrDefault(a => a.Ten == cbb_TheLoai2.Text).Id;
                        }
                        int a = 0;
                        if (rdt_ConBan.Checked == true)
                        {
                            a = 1;
                        }
                        else if (rdt_KhongBan.Checked == true)
                        {
                            a = 0;
                        }
                        MessageBox.Show(_iChiTietSachService.Add(new ChiTietSach()
                        {

                            Id = Guid.NewGuid(),
                            IdSach = _iSachService.GetAllNoView().Where(x => x.Ten == Convert.ToString(cbb_Sach.Text)).Select(x => x.Id).FirstOrDefault(),
                            IdNxb = _iNXBService.GetAllNoView().Where(x => x.Ten == Convert.ToString(cbb_NXB.Text)).Select(x => x.Id).FirstOrDefault(),
                            IdTacGia = _iTacGiaService.GetAll().Where(x => x.Ten == Convert.ToString(cbb_TacGia.Text)).Select(x => x.Id).FirstOrDefault(),
                            IdNhaPhatHanh = _iNhaPhatHanhService.GetAll().Where(x => x.Ten == Convert.ToString(cbb_NhaPhatHanh.Text)).Select(x => x.Id).FirstOrDefault(),
                            IdLoaiBia = _iLoaiBiaService.GetLoaiBia().Where(x => x.Ten == Convert.ToString(cbb_LoaiBia.Text)).Select(x => x.Id).FirstOrDefault(),
                            IdTheLoai = idTheLoai,
                            Ma = "CTS" + Convert.ToString(_iChiTietSachService.GetAll()
                              .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1)),
                            TrangThai = a,
                            //KichThuoc = tbt_KichThuoc.Text,
                            MaVach = tbt_MaVach.Text,
                            NamXuatBan = Convert.ToInt32(tbt_NamXuatBan.Text),
                            MoTa = tbt_MoTa.Text,
                            SoTrang = Convert.ToInt32(tbt_SoTrang.Text),
                            SoLuong = Convert.ToInt32(tbt_SoLuong.Text),
                            GiaNhap = Convert.ToInt32(tbt_GiaNhap.Text),
                            GiaBan = Convert.ToInt32(tbt_GiaBan.Text),
                            Anh = (byte[])(new ImageConverter().ConvertTo(ptb_AnhSach.Image, typeof(byte[]))),

                        }));

                        LoadData();
                    }
                    if (dialogResult == DialogResult.No) return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }
        }


        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckNull
                if (cbb_Sach.Text == string.Empty)
                {
                    MessageBox.Show("Sách không được để trống!!!!", "ERROR");
                    return;
                }
                else if (cbb_TheLoai.Text == string.Empty)
                {
                    MessageBox.Show("Thể loại không được để trống!!!!", "ERROR");
                    return;
                }
                else if (cbb_NXB.Text == string.Empty)
                {
                    MessageBox.Show("NXb không được để trống!!!!", "ERROR");
                    return;
                }
                else if (cbb_TacGia.Text == string.Empty)
                {
                    MessageBox.Show("Tác giả không được để trống!!!!", "ERROR");
                    return;
                }
                else if (cbb_NhaPhatHanh.Text == string.Empty)
                {
                    MessageBox.Show("Nhà phát hành không được để trống!!!!", "ERROR");
                    return;
                }
                else if (cbb_LoaiBia.Text == string.Empty)
                {
                    MessageBox.Show("Loại bìa không được để trống!!!!", "ERROR");
                    return;
                }
                else if (tbt_MaVach.Text == string.Empty)
                {
                    MessageBox.Show("Mã vạch không được để trống!!!!", "ERROR");
                    return;
                }
                else if (tbt_NamXuatBan.Text == string.Empty)
                {
                    MessageBox.Show("Năm xuất bản không được để trống!!!!", "ERROR");
                    return;
                }
                else if (tbt_SoTrang.Text == string.Empty)
                {
                    MessageBox.Show("Số trang không được để trống!!!!", "ERROR");
                    return;
                }
                else if (tbt_SoLuong.Text == string.Empty)
                {
                    MessageBox.Show("Số lượng không được để trống!!!!", "ERROR");
                    return;
                }
                else if (tbt_GiaNhap.Text == string.Empty)
                {
                    MessageBox.Show("Giá nhập không được để trống!!!!", "ERROR");
                    return;
                }
                else if (tbt_GiaBan.Text == string.Empty)
                {
                    MessageBox.Show("Giá bán không được để trống!!!!", "ERROR");
                    return;
                }
                else if (rdt_ConBan.Checked == false && rdt_KhongBan.Checked == false)
                {
                    MessageBox.Show("Trạng thái không được để trống!!!!", "ERROR");
                    return;
                }
                else if (tbt_Ma.Text == string.Empty)
                {
                    MessageBox.Show("Chọn hoá đơn muốn sửa, PLEAR", "ERROR");
                }
                else if (Convert.ToInt32(tbt_SoLuong.Text) == 0)
                {
                    MessageBox.Show("Số lượng không được = 0!!!!", "ERROR");
                    return;
                }
                else if (Convert.ToInt32(tbt_GiaBan.Text) < Convert.ToInt32(tbt_GiaNhap.Text))
                {
                    MessageBox.Show("Giá bán không được nhỏ hơn giá nhập!!!!", "ERROR");
                    return;
                }

                #endregion
                else
                {
                    Guid idTheLoai = Guid.Empty;
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn Sửa chi tiết cho sách", "Thông báo ", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (cbb_TheLoai.Text == String.Empty)
                        {
                            MessageBox.Show("Bạn chưa chọn thể loại", "Thông báo");
                        }
                        else if (cbb_TheLoai.Text != String.Empty && cbb_TheLoai2.Text == String.Empty)
                        {
                            idTheLoai = _iTheLoaiService.GetAllNoView().FirstOrDefault(a => a.Ten == cbb_TheLoai.Text).Id;
                        }
                        else
                        {
                            idTheLoai = _iTheLoaiService.GetAllNoView().FirstOrDefault(a => a.Ten == cbb_TheLoai2.Text).Id;
                        }


                        MessageBox.Show(_iChiTietSachService.Update(SelectedID, new ChiTietSach()
                        {

                            IdSach = _iSachService.GetAllNoView().Where(x => x.Ten == Convert.ToString(cbb_Sach.Text)).Select(x => x.Id).FirstOrDefault(),
                            IdNxb = _iNXBService.GetAllNoView().Where(x => x.Ten == Convert.ToString(cbb_NXB.Text)).Select(x => x.Id).FirstOrDefault(),
                            IdTacGia = _iTacGiaService.GetAll().Where(x => x.Ten == Convert.ToString(cbb_TacGia.Text)).Select(x => x.Id).FirstOrDefault(),
                            IdNhaPhatHanh = _iNhaPhatHanhService.GetAll().Where(x => x.Ten == Convert.ToString(cbb_NhaPhatHanh.Text)).Select(x => x.Id).FirstOrDefault(),
                            IdLoaiBia = _iLoaiBiaService.GetLoaiBia().Where(x => x.Ten == Convert.ToString(cbb_LoaiBia.Text)).Select(x => x.Id).FirstOrDefault(),
                            IdTheLoai = idTheLoai,
                            Ma = tbt_Ma.Text,
                            //KichThuoc = tbt_KichThuoc.Text,
                            MaVach = tbt_MaVach.Text,
                            NamXuatBan = Convert.ToInt32(tbt_NamXuatBan.Text),
                            MoTa = tbt_MoTa.Text,
                            SoTrang = Convert.ToInt32(tbt_SoTrang.Text),
                            SoLuong = Convert.ToInt32(tbt_SoLuong.Text),
                            GiaNhap = Convert.ToInt32(tbt_GiaNhap.Text),
                            GiaBan = Convert.ToInt32(tbt_GiaBan.Text),
                            Anh = (byte[])(new ImageConverter().ConvertTo(ptb_AnhSach.Image, typeof(byte[]))),
                            TrangThai = rdt_ConBan.Checked == true ? 1 : 0,
                        }));
                        LoadData();
                    }
                    if (dialogResult == DialogResult.No) return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn  XOÁ  sách này ", "Thông báo ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (_ihoaDonchitietService.GetAllloadformsp().Where(x => x.IdChiTietSach == SelectedID).Count() == 0)
                    {
                        MessageBox.Show(_iChiTietSachService.Delete(SelectedID));
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Sách hiện tại không thể xoá");
                        return;
                    }

                }
                if (dialogResult == DialogResult.No) return;
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void btn_NgungKinhDoanh_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn  Ngừng kinh doanh  sách này ", "Thông báo ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show(_iChiTietSachService.UpdateTrangThai(SelectedID, new ChiTietSach()
                    {
                        TrangThai = 0,
                    }));
                    LoadData();
                }
                if (dialogResult == DialogResult.No) return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void AddNhanh(string a)
        {
            try
            {
                Form_AddNhanh AddNhanh = new Form_AddNhanh(a);
                AddNhanh.ShowDialog();
                cbb_Sach.Items.Clear();
                cbb_NXB.Items.Clear();
                cbb_TacGia.Items.Clear();
                cbb_NhaPhatHanh.Items.Clear();
                cbb_LoaiBia.Items.Clear();
                cbb_TheLoai.Items.Clear();
                cbb_TheLoai2.Items.Clear();
                cbb_LocLoaiBia.Items.Clear();
                cbb_LocNXB.Items.Clear();
                cbb_LocTacGia.Items.Clear();
                cbb_NhaPhatHanh.Items.Clear();
                cbb_LocTrangThai.Items.Clear();
                cbb_LocNhaPhatHanh.Items.Clear();
                LoadCbb();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }
        }
        private void ipb_AddSach_Click(object sender, EventArgs e)
        {
            AddNhanh("sách");
        }

        private void ipb_AddNXB_Click(object sender, EventArgs e)
        {
            AddNhanh("NXB");
        }

        private void ipb_AddTacGia_Click(object sender, EventArgs e)
        {
            AddNhanh("Tác giả");
        }

        private void ipb_AddNhaPhatHanh_Click(object sender, EventArgs e)
        {
            AddNhanh("Nhà phát hành");
        }

        private void ipb_AddLoaiBia_Click(object sender, EventArgs e)
        {
            AddNhanh("Loại bìa");
        }
        private void ipb_AddTheLoai_Click(object sender, EventArgs e)
        {
            AddNhanh("Thể loại");
        }



        private void ptb_AnhSach_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            DialogResult result = MessageBox.Show("Bạn có muốn chọn ảnh sách không? ", "Đổi ảnh sách", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        ptb_AnhSach.SizeMode = PictureBoxSizeMode.StretchImage;
                        ptb_AnhSach.Image = Image.FromFile(open.FileName);
                        LinkImage = open.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ với Thắng để khắc phục");
                }
            }
            else return;

        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            LoadData();
            LoadCbb();
        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                tbt_Ma.Clear();
                cbb_Sach.Text = string.Empty;
                cbb_TheLoai.Text = string.Empty;
                cbb_TheLoai2.Text = string.Empty;
                cbb_NXB.Text = string.Empty;
                cbb_TacGia.Text = string.Empty;
                cbb_NhaPhatHanh.Text = string.Empty;
                cbb_LoaiBia.Text = string.Empty;
                tbt_MaVach.Clear();
                tbt_NamXuatBan.Clear();
                tbt_MoTa.Clear();
                tbt_SoTrang.Clear();
                tbt_SoLuong.Clear();
                tbt_GiaNhap.Clear();
                tbt_GiaBan.Clear();
                tbt_GiaMin.Clear();
                tbt_GiaMax.Clear();
                //tbt_KichThuoc.Clear();
                rdt_ConBan.Checked = false;
                rdt_KhongBan.Checked = false;
                ptb_AnhSach.ImageLocation = "icon-add.png";
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }

        }

        private void cbb_LocNXB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbb_LocNXB.Text != string.Empty)
                {
                    int stt = 1;
                    dtg_Show.ColumnCount = 19;
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
                    dtg_Show.Columns[16].Name = "Đường Dẫn";
                    dtg_Show.Columns[16].Visible = false;
                    dtg_Show.Columns[17].Name = "Mã vạch";
                    dtg_Show.Columns[18].Name = "Thể loại ";
                    dtg_Show.Rows.Clear();
                    foreach (var a in _iChiTietSachService.GetAllChiTietSachView().Where(x => x.TenNxb.Contains(cbb_LocNXB.Text)).OrderBy(x => x.Ma))
                    {
                        dtg_Show.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Ngừng kinh doanh" : "Còn bán", a.Anh, a.MaVach, a.TenTheLoai);
                    }
                    cbb_LocTacGia.Text = string.Empty;
                    cbb_LocNhaPhatHanh.Text = string.Empty;
                    cbb_LocLoaiBia.Text = string.Empty;
                    cbb_LocTheLoai.Text = string.Empty;
                    cbb_LocTrangThai.Text = string.Empty;
                    tbt_GiaMax.Text = string.Empty;
                    tbt_GiaMin.Text = string.Empty;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }

        }

        private void cbb_LocTacGia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbb_LocTacGia.Text != string.Empty)
                {
                    int stt = 1;
                    dtg_Show.ColumnCount = 19;
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
                    dtg_Show.Columns[16].Name = "Đường Dẫn";
                    dtg_Show.Columns[16].Visible = false;
                    dtg_Show.Columns[17].Name = "Mã vạch";
                    dtg_Show.Columns[18].Name = "Thể loại ";
                    dtg_Show.Rows.Clear();
                    foreach (var a in _iChiTietSachService.GetAllChiTietSachView().Where(x => x.TenTacGia.Contains(cbb_LocTacGia.Text)).OrderBy(x => x.Ma))
                    {
                        dtg_Show.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Ngừng kinh doanh" : "Còn bán", a.Anh, a.MaVach, a.TenTheLoai);
                    }
                    cbb_LocNXB.Text = string.Empty;
                    cbb_LocNhaPhatHanh.Text = string.Empty;
                    cbb_LocLoaiBia.Text = string.Empty;
                    cbb_LocTheLoai.Text = string.Empty;
                    cbb_LocTrangThai.Text = string.Empty;
                    tbt_GiaMax.Text = string.Empty;
                    tbt_GiaMin.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }
        }

        private void cbb_LocNhaPhatHanh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbb_LocNhaPhatHanh.Text != string.Empty)
                {
                    int stt = 1;
                    dtg_Show.ColumnCount = 19;
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
                    dtg_Show.Columns[16].Name = "Đường Dẫn";
                    dtg_Show.Columns[16].Visible = false;
                    dtg_Show.Columns[17].Name = "Mã vạch";
                    dtg_Show.Columns[18].Name = "Thể loại ";
                    dtg_Show.Rows.Clear();
                    foreach (var a in _iChiTietSachService.GetAllChiTietSachView().Where(x => x.TenNhaPhatHanh.Contains(cbb_LocNhaPhatHanh.Text)).OrderBy(x => x.Ma))
                    {
                        dtg_Show.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Ngừng kinh doanh" : "Còn bán", a.Anh, a.MaVach, a.TenTheLoai);
                    }
                    cbb_LocNXB.Text = string.Empty;
                    cbb_LocTacGia.Text = string.Empty;
                    cbb_LocLoaiBia.Text = string.Empty;
                    cbb_LocTheLoai.Text = string.Empty;
                    cbb_LocTrangThai.Text = string.Empty;
                    tbt_GiaMax.Text = string.Empty;
                    tbt_GiaMin.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }
        }

        private void cbb_LocLoaiBia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbb_LocLoaiBia.Text != string.Empty)
                {
                    int stt = 1;
                    dtg_Show.ColumnCount = 19;
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
                    dtg_Show.Columns[16].Name = "Đường Dẫn";
                    dtg_Show.Columns[16].Visible = false;
                    dtg_Show.Columns[17].Name = "Mã vạch";
                    dtg_Show.Columns[18].Name = "Thể loại ";
                    dtg_Show.Rows.Clear();
                    foreach (var a in _iChiTietSachService.GetAllChiTietSachView().Where(x => x.TenLoaiBia.Contains(cbb_LocLoaiBia.Text)).OrderBy(x => x.Ma))
                    {
                        dtg_Show.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Ngừng kinh doanh" : "Còn bán", a.Anh, a.MaVach, a.TenTheLoai);
                    }
                    cbb_LocNXB.Text = string.Empty;
                    cbb_LocNhaPhatHanh.Text = string.Empty;
                    cbb_LocTacGia.Text = string.Empty;
                    cbb_LocTheLoai.Text = string.Empty;
                    cbb_LocTrangThai.Text = string.Empty;
                    tbt_GiaMax.Text = string.Empty;
                    tbt_GiaMin.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }
        }

        private void cbb_LocTheLoai_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbb_LocLoaiBia.Text != string.Empty)
                {
                    int stt = 1;
                    dtg_Show.ColumnCount = 19;
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
                    dtg_Show.Columns[8].Visible = false;
                    dtg_Show.Columns[9].Name = "Năm xuất bản";
                    dtg_Show.Columns[10].Name = "Mô tả";
                    dtg_Show.Columns[11].Name = "Số trang";
                    dtg_Show.Columns[12].Name = "Số lượng";
                    dtg_Show.Columns[13].Name = "Giá nhập";
                    dtg_Show.Columns[14].Name = "Giá bán";
                    dtg_Show.Columns[15].Name = "Trạng thái";
                    dtg_Show.Columns[16].Name = "Đường Dẫn";
                    dtg_Show.Columns[16].Visible = false;
                    dtg_Show.Columns[17].Name = "Mã vạch";
                    dtg_Show.Columns[18].Name = "Thể loại ";
                    dtg_Show.Rows.Clear();
                    foreach (var a in _iChiTietSachService.GetAllChiTietSachView().Where(x => x.TenTheLoai.Contains(cbb_LocTheLoai.Text)).OrderBy(x => x.Ma))
                    {
                        dtg_Show.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Ngừng kinh doanh" : "Còn bán", a.Anh, a.MaVach, a.TenTheLoai);
                    }
                    cbb_LocNXB.Text = string.Empty;
                    cbb_LocNhaPhatHanh.Text = string.Empty;
                    cbb_LocTacGia.Text = string.Empty;
                    cbb_LocTrangThai.Text = string.Empty;
                    tbt_GiaMax.Text = string.Empty;
                    tbt_GiaMin.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }
        }

        private void cbb_LocTrangThai_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbb_LocTrangThai.Text != string.Empty)
                {
                    int stt = 1;
                    dtg_Show.ColumnCount = 19;
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
                    dtg_Show.Columns[16].Name = "Đường Dẫn";
                    dtg_Show.Columns[16].Visible = false;
                    dtg_Show.Columns[17].Name = "Mã vạch";
                    dtg_Show.Columns[18].Name = "Thể loại ";
                    dtg_Show.Rows.Clear();

                    if (cbb_LocTrangThai.Text == "Còn bán")
                        foreach (var a in _iChiTietSachService.GetAllChiTietSachView().Where(x => x.TrangThai == 1).OrderBy(x => x.Ma))
                        {
                            dtg_Show.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Ngừng kinh doanh" : "Còn bán", a.Anh, a.MaVach, a.TenTheLoai);
                        }
                    else if (cbb_LocTrangThai.Text == "Ngừng kinh doanh")
                        foreach (var a in _iChiTietSachService.GetAllChiTietSachView().Where(x => x.TrangThai == 0).OrderBy(x => x.Ma))
                        {
                            dtg_Show.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Ngừng kinh doanh" : "Còn bán", a.Anh, a.MaVach, a.TenTheLoai);
                        }

                    cbb_LocNXB.Text = string.Empty;
                    cbb_LocNhaPhatHanh.Text = string.Empty;
                    cbb_LocTacGia.Text = string.Empty;
                    cbb_LocTheLoai.Text = string.Empty;
                    tbt_GiaMax.Text = string.Empty;
                    tbt_GiaMin.Text = string.Empty;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }
        }


        private void ptb_PDF_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xuất file pdf  hay không", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {

                    Form_ExportFilePDF reportFileToPDF = new Form_ExportFilePDF();
                    reportFileToPDF.Show();
                    for (int a = 0; a < 1; a++)
                    {
                    }
                };

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }
        }

        private void tbt_SoTrang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbt_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbt_GiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbt_GiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbt_GiaMax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbt_GiaMax.Text == string.Empty)
                {
                    return;
                }
                if (tbt_GiaMax.Text != string.Empty)
                {
                    int stt = 1;
                    dtg_Show.ColumnCount = 19;
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
                    dtg_Show.Columns[16].Name = "Đường Dẫn";
                    dtg_Show.Columns[16].Visible = false;
                    dtg_Show.Columns[17].Name = "Mã vạch";
                    dtg_Show.Columns[18].Name = "Thể loại ";
                    dtg_Show.Rows.Clear();
                    foreach (var a in _iChiTietSachService.GetAllChiTietSachView().Where(x => x.GiaBan <= Convert.ToInt32(tbt_GiaMax.Text) && x.GiaBan >= Convert.ToInt32(tbt_GiaMin.Text)))
                    {
                        dtg_Show.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Ngừng kinh doanh" : "Còn bán", a.Anh, a.MaVach, a.TenTheLoai);
                    }
                    cbb_LocNXB.Text = string.Empty;
                    cbb_LocNhaPhatHanh.Text = string.Empty;
                    cbb_LocTacGia.Text = string.Empty;
                    cbb_LocTrangThai.Text = string.Empty;
                }
                else if (Convert.ToInt32(tbt_GiaMax.Text) >= 0 && Convert.ToInt32(tbt_GiaMax.Text) < Convert.ToInt32(tbt_GiaMin.Text))
                {
                    MessageBox.Show("Giá max không được nhỏ hơn giá min");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên hệ Thắng để khắc phục");
                return;

            }

        }

    }
}