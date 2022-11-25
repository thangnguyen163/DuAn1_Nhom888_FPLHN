using _1.DAL.DomainClass;
using _2.BUS.IService;
using _2.BUS.IServices;
using _2.BUS.Serivces;
using _2.BUS.Service;
using _2.BUS.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PresentationLayers.Views
{
    public partial class Form_NhanVien : Form
    {
        public INhanVienService _nhanVienService;
        public IChucVuService _chucVuService;
        public Guid SelectId;
        private string FileImageNam = "";
        public NhanVien _nv;
        public List<NhanVienView> _lstNhanVien;
        public Form_NhanVien()
        {
            InitializeComponent();
            _nhanVienService = new NhanVienService();
            _chucVuService = new ChucVuServivce();
            _lstNhanVien = new List<NhanVienView>();
            loadCombobox();
            loadData();
        }
        public void loadCombobox()
        {
            foreach (var item in _chucVuService.getChucVusFromDB())
            {
                cbb_ChucVu.Items.Add(item.Ten);
            }
        }
        public void loadData()
        {
            dtg_Show.ColumnCount = 13;
            dtg_Show.Columns[0].Name = "Id";
            dtg_Show.Columns[0].Visible = false;
            dtg_Show.Columns[1].Name = "Mã";
            dtg_Show.Columns[2].Name = "Tên";
            dtg_Show.Columns[3].Name = "Giới Tính";
            dtg_Show.Columns[4].Name = "CCCD";
            dtg_Show.Columns[5].Name = "Số ĐT";
            dtg_Show.Columns[6].Name = "Email";
            dtg_Show.Columns[7].Name = "Mật khẩu";
            dtg_Show.Columns[8].Name = "Chức vụ";
            dtg_Show.Columns[9].Name = "Ảnh";
            dtg_Show.Columns[10].Name = "Địa chỉ";
            dtg_Show.Columns[11].Name = "Năm Sinh";
            dtg_Show.Columns[12].Name = "Trạng thái";

            dtg_Show.Rows.Clear();

            foreach (var item in _nhanVienService.getViewNhanViens())
            {
                dtg_Show.Rows.Add(item.nhanVien.Id,
                    item.nhanVien.Ma,
                    item.nhanVien.Ten,
                    item.nhanVien.GioiTinh == 0 ? "Nam" : "Nữ",
                    item.nhanVien.Cccd,
                    item.nhanVien.Sdt,
                    item.nhanVien.Email,
                    item.nhanVien.MatKhau,
                    item.chucVu.Ten,
                    item.nhanVien.Anh,
                    item.nhanVien.DiaChi,
                    item.nhanVien.NamSinh,
                    item.nhanVien.TrangThai == 1 ? "Hoạt động" : "Không hoạt động"
                    );
            }
        }
        public void ResetFrom()
        {
            loadData();
            _nv = null;
            tb_ma.Text = "";
            tb_ten.Text = "";
            tb_matkhau.Text = "";
            tb_cccd.Text = "";
            tb_sdt.Text = "";
            tb_diaChi.Text = "";
            tb_email.Text = "";
            tb_Anh.Text = "";
            tb_namsinh.Text = "";
            cbb_ChucVu.Text = "";
            cb_Nam.Checked = true;
            cb_Nu.Checked = false;
            rB_hd.Checked = true;
            rB_khd.Checked = false;
        }

        private void dtg_Show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_Show.Rows[e.RowIndex];
                _nv = _nhanVienService.getNhanViensFromDB().FirstOrDefault(x => x.Id == Guid.Parse(r.Cells[0].Value.ToString()));
                SelectId=Guid.Parse(r.Cells[0].Value.ToString());
                tb_ma.Text = r.Cells[1].Value.ToString();
                tb_ten.Text = r.Cells[2].Value.ToString();
                tb_matkhau.Text = r.Cells[7].Value.ToString();
                tb_cccd.Text = r.Cells[4].Value.ToString();
                tb_sdt.Text = r.Cells[5].Value.ToString();
                tb_diaChi.Text = r.Cells[10].Value.ToString();
                tb_email.Text = r.Cells[6].Value.ToString();
                
                tb_namsinh.Text = r.Cells[11].Value.ToString();
                cbb_ChucVu.Text = _chucVuService.getChucVusFromDB().FirstOrDefault(x => x.Id == _nv.IdchucVu).Ten;
                cb_Nam.Checked = _nv.GioiTinh == 0;
                cb_Nu.Checked = _nv.GioiTinh == 1;
                rB_hd.Checked = _nv.TrangThai == 1;
                rB_khd.Checked = _nv.TrangThai == 0;
                pic_Anh.Image = Image.FromStream(new MemoryStream((byte[])r.Cells[9].Value));
               //  _nhanVienService.getNhanViensFromDB().Where(x => x.Id == Guid.Parse(r.Cells[0].Value.ToString())).Select(x => x.Anh).FirstOrDefault())
                pic_Anh.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_nhanVienService.addNhanVien(new NhanVien()
                {
                    
                    Id = Guid.NewGuid(),
                    Ma = "NV" + Convert.ToString(_nhanVienService.getNhanViensFromDB()
                      .Max(c => Convert.ToInt32(c.Ma.Substring(2, c.Ma.Length - 2)) + 1)),
                    Ten = tb_ten.Text,
                    MatKhau = tb_ma.Text,
                    Cccd = Convert.ToDecimal(tb_cccd.Text),
                    Sdt = tb_sdt.Text,
                    DiaChi = tb_diaChi.Text,
                    Email = tb_email.Text,
                    Anh = (byte[])(new ImageConverter().ConvertTo(pic_Anh.Image, typeof(byte[]))),
                    NamSinh = Convert.ToInt32(tb_namsinh.Text),
                    IdchucVu = cbb_ChucVu.Text != "" ? _chucVuService.getChucVusFromDB().FirstOrDefault(x => x.Ten == cbb_ChucVu.Text).Id : null,
                    TrangThai = rB_hd.Checked ? 1 : 0,
                }));
                loadData();
            }
            else
            {

                return;

            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn sửa không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_nhanVienService.updateNhanVien(SelectId, new NhanVien()
                {
                    Ma = tb_ma.Text,
                    Ten = tb_ten.Text,
                    MatKhau = tb_matkhau.Text,
                    Cccd = Convert.ToDecimal(tb_cccd.Text),
                    Sdt = tb_sdt.Text,
                    DiaChi = tb_diaChi.Text,
                    NamSinh = Convert.ToInt32(tb_namsinh.Text),
                    Email = tb_email.Text,
                    Anh = (byte[])(new ImageConverter().ConvertTo(pic_Anh.Image, typeof(byte[]))),
                    IdchucVu = cbb_ChucVu.Text != "" ? _chucVuService.getChucVusFromDB().FirstOrDefault(x => x.Ten == cbb_ChucVu.Text).Id : null,
                    TrangThai = rB_hd.Checked ? 1 : 0,
                }));
                loadData();
            }
            else
            {

                return;

            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_nhanVienService.deleteNhanVien(SelectId));
                loadData();
            }
            else
            {
                return;
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ResetFrom();
        }

        private void rB_hd_Click(object sender, EventArgs e)
        {
            if (rB_khd.Checked)
            {
                rB_khd.Checked = false;
            }
            rB_hd.Checked = true;
        }

        private void rB_khd_Click(object sender, EventArgs e)
        {
            if (rB_hd.Checked)
            {
                rB_hd.Checked = false;
            }
            rB_khd.Checked = true;
        }
        void loadtim_kiem(string ma)
        {
            ArrayList row = new ArrayList();
            row = new ArrayList();

            dtg_Show.ColumnCount = 13;
            dtg_Show.Columns[0].Name = "Id";
            dtg_Show.Columns[0].Visible = false;
            dtg_Show.Columns[1].Name = "Mã";
            dtg_Show.Columns[2].Name = "Tên";
            dtg_Show.Columns[3].Name = "Giới Tính";
            dtg_Show.Columns[4].Name = "CCCD";
            dtg_Show.Columns[5].Name = "Số ĐT";
            dtg_Show.Columns[6].Name = "Email";
            dtg_Show.Columns[7].Name = "Mật khẩu";
            dtg_Show.Columns[8].Name = "Chức vụ";
            dtg_Show.Columns[9].Name = "Ảnh";
            dtg_Show.Columns[10].Name = "Địa chỉ";
            dtg_Show.Columns[11].Name = "Năm Sinh";
            dtg_Show.Columns[12].Name = "Trạng thái";
            dtg_Show.Rows.Clear();
            foreach (var item in _nhanVienService.getNhanViensFromDB().Where(c => c.Ten.StartsWith(ma) || c.Email.StartsWith(ma) || c.DiaChi.StartsWith(ma)))

            {
                dtg_Show.Rows.Add(item.Id,
                                    item.Ma,
                                    item.Ten,
                                    item.GioiTinh == 0 ? "Nam" : "Nữ",
                                    item.Cccd,
                                    item.Sdt,
                                    item.Email,
                                    item.MatKhau,
                                    item.Ten,
                                    item.Anh,
                                    item.DiaChi,
                                    item.NamSinh,
                                    item.TrangThai == 1 ? "Hoạt động" : "Không hoạt động"
                                    );
            }

        }
        private void tb_Timkiem_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tb_Timkiem.Text == "")
                {
                    tb_Timkiem.Text = "Tìm kiếm theo tên, Email, Địa chỉ";
                    tb_Timkiem.ForeColor = Color.Black;
                    _nhanVienService.getNhanViensFromDB();
                    loadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }
        void loadimg(ref string imgname)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                imgname = fileDialog.FileName;
                tb_Anh.Text = fileDialog.FileName;
            }
        }
        private void btn_Anh_Click(object sender, EventArgs e)
        {
            //loadimg(ref FileImageNam);
            //pic_Anh.Image = new Bitmap(FileImageNam);
            OpenFileDialog open = new OpenFileDialog();
            try
            {

                if (open.ShowDialog() == DialogResult.OK)
                {
                    pic_Anh.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic_Anh.Image = Image.FromFile(open.FileName);
                    //LinkImage = open.FileName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ với Thắng để khắc phục");
            }
        }
        //dđ
    }
}
