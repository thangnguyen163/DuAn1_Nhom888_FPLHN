using _1.DAL.DomainClass;
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

namespace _3.PresentationLayers.Views
{
    public partial class Form_ChiTietTheLoai : Form
    {
        IChiTietTheLoaiService _iCTTLService;
        ITheLoaiService _itheLoaiService;
        ISachService _iSachService;
        IChiTietSachService _ichiTietSachService;
        ChiTietTheLoai _cttl;
        public Guid SelectID { get; set; }
        public Form_ChiTietTheLoai()
        {
            InitializeComponent();
            _iCTTLService = new ChiTietTheLoaiService();
            _cttl = new ChiTietTheLoai();
            _itheLoaiService = new TheLoaiService();
            _iSachService = new SachService();
            _ichiTietSachService = new ChiTietSachService();
            Load();
        }
        private void LoadDataToDtg(List<ChiTietTheLoaiView> lst)
        {

            int stt = 1;
            dtg_Show.Rows.Clear();
            dtg_Show.ColumnCount = 7;
            dtg_Show.Columns[0].Name = "STT";
            dtg_Show.Columns[1].Name = "ID";
            dtg_Show.Columns[1].Visible = false;
            dtg_Show.Columns[2].Name = "Thể loại";
            dtg_Show.Columns[3].Name = "Tên sách";
            dtg_Show.Columns[4].Name = "Mã chi tiết";
            dtg_Show.Columns[5].Name = "Thể loại chi tiết";
            dtg_Show.Columns[6].Name = "Trạng thái";
            foreach (var x in lst)
            {
                dtg_Show.Rows.Add(stt++, x.Id, x.TheLoai, x.TenSach, x.Ma, x.ChiTietTheLoai, x.TrangThai == 0 ? "Không hoạt động" : "Hoạt động");
            }
            dtg_Show.AllowUserToAddRows = false;
        }
        private void Load()
        {
            LoadDataToDtg(_iCTTLService.GetAll());
            // Thêm trạng thái vào cbb
            List<int> lsttt = new List<int>();
            foreach (var x in _iCTTLService.GetAll())
            {
                lsttt.Add((int)x.TrangThai);
            }
            // Trạng thái
            cbb_trangthai.Items.Clear();
            cbb_trangthai.Items.Add("--Chọn--");
            foreach (var x in lsttt.Distinct())
            {
                cbb_trangthai.Items.Add(x == 0 ? "Không hoạt động" : "Hoạt động");
            }
            cbb_trangthai.SelectedIndex = 0;
            // Thể loại
            cbb_theloai.Items.Clear();
            cbb_theloai.Items.Add("--Chọn--");
            foreach (var x in _itheLoaiService.GetAllNoView())
            {
                cbb_theloai.Items.Add(x.Ten);
            }
            cbb_theloai.SelectedIndex = 0;
            // Tên sách
            cbb_tensach.Items.Clear();
            cbb_tensach.Items.Add("--Chọn--");
            foreach (var x in _iSachService.GetAllNoView())
            {
                cbb_tensach.Items.Add(x.Ten);
            }
            cbb_tensach.SelectedIndex = 0;
        }
        private void ResetForm()
        {
            LoadDataToDtg(_iCTTLService.GetAll());
            _cttl = null;
            cbb_theloai.Text = "--Chọn--";
            cbb_tensach.Text = "--Chọn--";
            tb_ma.Text = "";
            tb_ten.Text = "";
            cbb_trangthai.Text = "--Chọn--";
        }
        private ChiTietTheLoai GetDataFromGui_Them()
        {
            _cttl = new ChiTietTheLoai();
            {
                _cttl.IdTheLoai = _iCTTLService.GetAll().Where(c => c.TheLoai == cbb_theloai.Text).Select(x => x.IDTL).FirstOrDefault();
                _cttl.IdChiTietSach = _iCTTLService.GetAll().Where(c => c.TenSach == cbb_tensach.Text).Select(x => x.IDCTS).FirstOrDefault();
                _cttl.Ma = tb_ma.Text;
                _cttl.Ten = tb_ten.Text;
                _cttl.TrangThai = cbb_trangthai.Text == "Không hoạt động" ? 0 : 1;
            };
            return _cttl;
        }
        private ChiTietTheLoai GetDataFromGui_Sua_Xoa()
        {
            _cttl = new ChiTietTheLoai();
            {
                _cttl.Id = SelectID;
                _cttl.IdTheLoai = _iCTTLService.GetAll().Where(c => c.TheLoai == cbb_theloai.Text).Select(x => x.IDTL).FirstOrDefault();
                _cttl.IdChiTietSach = _iCTTLService.GetAll().Where(c => c.TenSach == cbb_tensach.Text).Select(x => x.IDCTS).FirstOrDefault();
                _cttl.Ma = tb_ma.Text;
                _cttl.Ten = tb_ten.Text;
                _cttl.TrangThai = cbb_trangthai.Text == "Không hoạt động" ? 0 : 1;
            };
            return _cttl;
        }
        /*==============================================================================*/
        private void dtg_Show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            SelectID = Guid.Parse(dtg_Show.CurrentRow.Cells[1].Value.ToString());
            cbb_theloai.Text = dtg_Show.CurrentRow.Cells[2].Value.ToString();
            cbb_tensach.Text = dtg_Show.CurrentRow.Cells[3].Value.ToString();
            tb_ma.Text = dtg_Show.CurrentRow.Cells[4].Value.ToString();
            tb_ten.Text = dtg_Show.CurrentRow.Cells[5].Value.ToString();
            cbb_trangthai.Text = dtg_Show.CurrentRow.Cells[6].Value.ToString();
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm đối tượng không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (cbb_theloai.Text == "--Chọn--" || cbb_tensach.Text == "--Chọn--" || tb_ma.Text == "" || tb_ten.Text == "" || cbb_trangthai.Text == "--Chọn--")
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                MessageBox.Show(_iCTTLService.Add(GetDataFromGui_Them()));
                ResetForm();
            }
            else return;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn cập nhật đối tượng không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (cbb_theloai.Text == "--Chọn--" || cbb_tensach.Text == "--Chọn--" || tb_ma.Text == "" || tb_ten.Text == "" || cbb_trangthai.Text == "--Chọn--")
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                MessageBox.Show(_iCTTLService.Update(GetDataFromGui_Sua_Xoa()));
                ResetForm();
            }
            else return;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn cập nhật đối tượng không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_iCTTLService.Delete(GetDataFromGui_Sua_Xoa()));
                ResetForm();
            }
            else return;

        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void tb_Timkiem_TextChanged(object sender, EventArgs e)
        {
            LoadDataToDtg(_iCTTLService.GetAll().Where(c => c.ChiTietTheLoai.ToLower().Contains(tb_Timkiem.Text.ToLower())).ToList());
        }
    }
}
