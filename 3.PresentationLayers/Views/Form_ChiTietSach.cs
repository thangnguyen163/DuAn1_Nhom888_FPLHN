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
        private ChiTietSach ChiTietSach;
        private string LinkImage ="";
        

        public Form_ChiTietSach()
        {
            InitializeComponent();
            _iChiTietSachService = new ChiTietSachService();
            _lstChiTietSach = new List<ChiTietSach>();
            _lstChiTietSachView = new List<ChiTietSachView>();
            _iSachService = new SachService();
            _iTacGiaService = new TacGiaService();
            _iTheLoaiService = new TheLoaiService();
            _iTietTheLoaiService = new ChiTietTheLoaiService();
            _iNXBService = new NXBService();
            _iLoaiBiaService = new LoaiBiaService();
            _iNhaPhatHanhService = new NhaPhatHanhService();
            LoadData();
            LoadCbb();
            ChiTietSach = new ChiTietSach();
            //ptb_AnhSach.Image = Image.FromFile(ChiTietSach.Anh);
        }
        void LoadData()
        {
            //int stt = 0;
            //dtg_Show.ColumnCount = 16;
            //dtg_Show.Columns[0].Name = "STT";
            //dtg_Show.Columns[1].Name = "Id";
            //dtg_Show.Columns[1].Visible = false;
            //dtg_Show.Columns[2].Name = "Sách";
            //dtg_Show.Columns[3].Name = "NXB";
            //dtg_Show.Columns[4].Name = "Tác giả";
            //dtg_Show.Columns[5].Name = "NPH";
            //dtg_Show.Columns[6].Name = "Loại bìa";
            //dtg_Show.Columns[7].Name = "Mã";
            //dtg_Show.Columns[8].Name = "Kích thước";
            //dtg_Show.Columns[9].Name = "Năm xuất bản";
            //dtg_Show.Columns[10].Name = "Mô tả";
            //dtg_Show.Columns[11].Name = "Số trang";
            //dtg_Show.Columns[12].Name = "Số lượng";
            //dtg_Show.Columns[13].Name = "Giá nhập";
            //dtg_Show.Columns[14].Name = "Giá bán";
            //dtg_Show.Columns[15].Name = "Trạng thái";
            //dtg_Show.Rows.Clear();
            //foreach (var a in _iChiTietSachService.GetAllChiTietSachView())
            //{
            //    dtg_Show.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Hết sách" : "Còn bán");
            //}


            int stt = 0;
            dtg_Show.ColumnCount = 17;
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
            dtg_Show.Rows.Clear();
            foreach (var a in _iChiTietSachService.GetAllChiTietSachView())
            {
                dtg_Show.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Hết sách" : "Còn bán",a.Anh);
            }
        }

     
        public void LoadCbb()
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
            foreach (var a in _iTheLoaiService.GetAllNoView())
            {
                cbb_TheLoai.Items.Add(a.Ten);
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
            ptb_AnhSach.Image = Image.FromStream(new MemoryStream((byte[])dtg_Show.Rows[rd].Cells[16].Value));
            ptb_AnhSach.SizeMode = PictureBoxSizeMode.StretchImage;
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
                //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
                //File.Copy(LinkImage, Path.Combine(projectDirectory, "Image", Path.GetFileName(LinkImage)), true);
                //LinkImage = Path.Combine(projectDirectory, "Image", Path.GetFileName(LinkImage));
                MessageBox.Show(_iChiTietSachService.Add(new ChiTietSach()
                {


                    Id = Guid.NewGuid(),
                    IdSach = _iSachService.GetAllNoView().Where(x => x.Ten == Convert.ToString(cbb_Sach.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdNxb = _iNXBService.GetAllNoView().Where(x => x.Ten == Convert.ToString(cbb_NXB.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdTacGia = _iTacGiaService.GetAll().Where(x => x.Ten == Convert.ToString(cbb_TacGia.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdNhaPhatHanh = _iNhaPhatHanhService.GetAll().Where(x => x.Ten == Convert.ToString(cbb_NhaPhatHanh.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdLoaiBia = _iLoaiBiaService.GetLoaiBia().Where(x => x.Ten == Convert.ToString(cbb_LoaiBia.Text)).Select(x => x.Id).FirstOrDefault(),
                    Ma = "CTS" + Convert.ToString(_iChiTietSachService.GetAll()
                      .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1)),
                    KichThuoc = tbt_KichThuoc.Text,
                    NamXuatBan = Convert.ToInt32(tbt_NamXuatBan.Text),
                    MoTa = tbt_MoTa.Text,
                    SoTrang = Convert.ToInt32(tbt_SoTrang.Text),
                    SoLuong = Convert.ToInt32(tbt_SoLuong.Text),
                    GiaNhap = Convert.ToInt32(tbt_GiaNhap.Text),
                    GiaBan = Convert.ToInt32(tbt_GiaBan.Text),
                    Anh=(byte[])(new ImageConverter().ConvertTo(ptb_AnhSach.Image,typeof(byte[]))),
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
                MessageBox.Show(_iChiTietSachService.Update(SelectedID, new ChiTietSach()
                {

                    IdSach = _iSachService.GetAllNoView().Where(x => x.Ten == Convert.ToString(cbb_Sach.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdNxb = _iNXBService.GetAllNoView().Where(x => x.Ten == Convert.ToString(cbb_NXB.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdTacGia = _iTacGiaService.GetAll().Where(x => x.Ten == Convert.ToString(cbb_TacGia.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdNhaPhatHanh = _iNhaPhatHanhService.GetAll().Where(x => x.Ten == Convert.ToString(cbb_NhaPhatHanh.Text)).Select(x => x.Id).FirstOrDefault(),
                    IdLoaiBia = _iLoaiBiaService.GetLoaiBia().Where(x => x.Ten == Convert.ToString(cbb_LoaiBia.Text)).Select(x => x.Id).FirstOrDefault(),
                    Ma=tbt_Ma.Text,
                    KichThuoc = tbt_KichThuoc.Text,
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void AddNhanh(string a)
        {
            Form_AddNhanh AddNhanh = new Form_AddNhanh(a);
            AddNhanh.ShowDialog();
            cbb_Sach.Items.Clear();
            cbb_NXB.Items.Clear();
            cbb_TacGia.Items.Clear();
            cbb_NhaPhatHanh.Items.Clear();
            cbb_LoaiBia.Items.Clear();
            LoadCbb();
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

        private void ipb_TheLoai2_Click(object sender, EventArgs e)
        {
            AddNhanh("Thể loại chi tiết");
        }


        private void ptb_AnhSach_DoubleClick(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "Imaga file: | *.jpg; *.png; *.jpeg";
            //ofd.ShowDialog();
            //DialogResult result = MessageBox.Show("Bạn có muốn chọn ảnh sách không? ", "Đổi ảnh sách", MessageBoxButtons.YesNo);
            //if (result == DialogResult.Yes)
            //{
            //    ptb_AnhSach.SizeMode = PictureBoxSizeMode.StretchImage; // cho vừa khung 
            //    ptb_AnhSach.Image = Image.FromFile(ofd.FileName);
            //}
            //else
            //{
            //    MessageBox.Show("Lựa chọn đúng đắn");
            //}
            // thêm cái này 
            //= ofd.FileName; // lưu đường dẫn ảnh để lát tạo đối tượng
            OpenFileDialog open = new OpenFileDialog();
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
            //ChiTietSach.Anh = open.FileName;
        }

        private void Form_ChiTietSach_Load(object sender, EventArgs e)
        {
            //LoadCbb();
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            LoadData();
            LoadCbb();
        }

        private void cbb_TheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_TheLoai2.Items.Clear();
            foreach (var a in _iTietTheLoaiService.GetAll().Where(x => x.TheLoai == cbb_TheLoai.Text))
            {
                cbb_TheLoai2.Items.Add(a.ChiTietTheLoai);
                
            }
            
        }


    }
}