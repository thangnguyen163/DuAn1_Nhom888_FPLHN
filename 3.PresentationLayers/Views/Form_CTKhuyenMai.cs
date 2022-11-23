
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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace _3.PresentationLayers.Views
{
    public partial class Form_CTKhuyenMai : Form
    {
        private Guid SelectId;
        private IChiTietKhuyenMaiService chiTietKhuyenMaiService;
        private IChiTietSachService chiTietSachService;
        private IKhuyenMaiService khuyenMaiService;
        private ISachService sachService;
        List<ChiTietKhuyenMaiView> _lstchiTietKhuyenMaiList = new List<ChiTietKhuyenMaiView>();

        public Form_CTKhuyenMai()
        {
            InitializeComponent();
            chiTietKhuyenMaiService = new ChiTietKhuyenMaiService();
            chiTietSachService = new ChiTietSachService();
            khuyenMaiService = new KhuyenMaiService();
            sachService = new SachService();
            chiTietKhuyenMaiService = new ChiTietKhuyenMaiService();
            LoadData();
            LoadCombobox();
        }


        public void LoadData()
        {
            int i = 0;
            dtg_show.ColumnCount = 8;
            dtg_show.Columns[0].Name = "STT";
            dtg_show.Columns[1].Name = "ID";
            dtg_show.Columns[1].Visible = false;
            dtg_show.Columns[2].Name = "Sách";
            dtg_show.Columns[3].Name = "Khuyến mãi";
            dtg_show.Columns[4].Name = "Mã chi tiết khuyến mãi";
            dtg_show.Columns[5].Name = "Tên chi tiết khuyễn mãi";
            dtg_show.Columns[6].Name = "Mô tả";
            dtg_show.Columns[7].Name = "Trạng thái";
            dtg_show.Rows.Clear();
            _lstchiTietKhuyenMaiList = chiTietKhuyenMaiService.GetChiTietKhuyenMaiViews();
            if (tb_timkiem.Text != "")
            {
                _lstchiTietKhuyenMaiList = _lstchiTietKhuyenMaiList.Where(x => x.TenKhuyenMai.Contains(tb_timkiem.Text)).ToList();
            }
            foreach (var a in _lstchiTietKhuyenMaiList)
            {
                dtg_show.Rows.Add(i++, a.Id, a.TenSach, a.KhuyenMai, a.MaCTKuyenMai, a.TenKhuyenMai, a.MoTa, a.TrangThai == 1 ? "Đang diễn ra" : "Hết hạn");
            }
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn muốn thêm chứ", "Thông báo", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                MessageBox.Show(chiTietKhuyenMaiService.Add(new ChiTietKhuyenMai()
                {
                    Id = Guid.NewGuid(),
                    IdChiTietSach = sachService.GetAll().Where(p => p.Ten == Convert.ToString(cbx_Sach.Text)).Select(p => p.Id).FirstOrDefault(),
                    IdKhuyenMai = khuyenMaiService.GetAll().Where(p => p.Ten == Convert.ToString(cbx_KhuyenMai.Text)).Select(p => p.Id).FirstOrDefault(),
                    Ma = tbx_ma.Text,
                    Ten = tbx_ten.Text,
                    MoTa = tbx_mota.Text,
                    TrangThai = rdo_HoatDong.Checked == true ? 0 : 1
                }));
                LoadData();

            }
            else
            {
                return;
            }

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn muốn sửa chứ", "Thông báo", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                MessageBox.Show(chiTietKhuyenMaiService.Update(SelectId, new ChiTietKhuyenMai()
                {

                    IdChiTietSach = sachService.GetAll().Where(p => p.Ten == Convert.ToString(cbx_Sach.Text)).Select(p => p.Id).FirstOrDefault(),
                    IdKhuyenMai = khuyenMaiService.GetAll().Where(p => p.Ten == Convert.ToString(cbx_KhuyenMai.Text)).Select(p => p.Id).FirstOrDefault(),
                    Ma = tbx_ma.Text,
                    Ten = tbx_ten.Text,
                    MoTa = tbx_mota.Text,
                    TrangThai = rdo_HoatDong.Checked == true ? 0 : 1
                }));

            }
            else return;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn muốn thêm chứ", "Thông báo", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                MessageBox.Show(chiTietKhuyenMaiService.Delete(SelectId));
                LoadData();
            }
            else { return; }
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtg_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == -1) return;
            SelectId = Guid.Parse(Convert.ToString(dtg_show.Rows[rd].Cells[1].Value));
            cbx_Sach.Text = Convert.ToString(dtg_show.Rows[rd].Cells[2].Value);
            cbx_KhuyenMai.Text = Convert.ToString(dtg_show.Rows[rd].Cells[3].Value);
            tbx_ma.Text = Convert.ToString(dtg_show.Rows[rd].Cells[4].Value);
            tbx_ten.Text = Convert.ToString(dtg_show.Rows[rd].Cells[5].Value);
            tbx_mota.Text = Convert.ToString(dtg_show.Rows[rd].Cells[6].Value);
            rdo_HoatDong.Checked = Convert.ToString(dtg_show.Rows[rd].Cells[7].Value) == "Đang diễn ra";
            rdo_HetHan.Checked = Convert.ToString(dtg_show.Rows[rd].Cells[7].Value) == "Hết hạn";

        }

        public void LoadCombobox()
        {
            foreach (var a in sachService.GetAll())
            {
                cbx_Sach.Items.Add(a.Ten);
            }
            foreach (var a in khuyenMaiService.GetAll())
            {
                cbx_KhuyenMai.Items.Add(a.Ten);
            }

        }

        private void tb_timkiem_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

