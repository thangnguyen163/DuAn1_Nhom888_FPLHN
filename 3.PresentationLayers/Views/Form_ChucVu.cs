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
    public partial class Form_ChucVu : Form
    {
        public IChucVuService _chucVuService;
        public ChucVu _cv;
        public Form_ChucVu()
        {
            InitializeComponent();
            _chucVuService = new ChucVuServivce();
            loadData();
        }
        public void loadData()
        {
            dtg_Show.ColumnCount = 4;
            dtg_Show.Columns[0].Name = "Id";
            dtg_Show.Columns[0].Visible = false;
            dtg_Show.Columns[1].Name = "Mã";
            dtg_Show.Columns[2].Name = "Tên";
            dtg_Show.Columns[3].Name = "Trạng Thái";
            dtg_Show.Rows.Clear();
            var lstChucVu = _chucVuService.getChucVusFromDB();
            foreach (var item in lstChucVu)
            {
                dtg_Show.Rows.Add(item.Id, item.Ma, item.Ten, item.TrangThai);
                dtg_Show.Rows.Add(item.Id, item.Ma, item.Ten, item.TrangThai == 1 ? "Hoạt Động" : "Không Hoạt Động");
            }
        }
        public void resetForm()
        {
            loadData();
            _cv = null;
            tb_ma.Text = "";
            tb_ten.Text = "";
            rB_hd.Checked = true;
            rB_khd.Checked = false;

        }

        private void dtg_Show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_Show.Rows[e.RowIndex];
                _cv = _chucVuService.getChucVusFromDB().FirstOrDefault(x => x.Id == Guid.Parse(r.Cells[0].Value.ToString()));
                tb_ma.Text = r.Cells[1].Value.ToString();
                tb_ten.Text = r.Cells[2].Value.ToString();
                rB_hd.Checked = _cv.TrangThai == 1;
                rB_khd.Checked = _cv.TrangThai == 0;

            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (tb_ma.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã chức vụ");
            }
            else if (_chucVuService.getChucVusFromDB().Any(x => x.Ma == tb_ma.Text))
            {
                MessageBox.Show("Mã chức vụ đã tồn tại");
            }
            else
            {
                var cv = new ChucVu()
                {
                    Id = new Guid(),
                    Ma = tb_ma.Text,
                    Ten = tb_ten.Text,
                    TrangThai = rB_hd.Checked ? 1 : 0
                };
                _chucVuService.addChucVu(cv);
                MessageBox.Show("Thêm mới thành công");
                resetForm();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (tb_ma.Text == "")
            {
                MessageBox.Show("Nhập Mã Chức Vụ");

            }
            else if (_cv == null)
            {
                MessageBox.Show("Chọn Chức Vụ");
            }
            else
            {
                if (_cv.Ma == tb_ma.Text || (_cv.Ma != tb_ma.Text && _chucVuService.getChucVusFromDB().FirstOrDefault(x => x.Ma == tb_ma.Text) == null))
                {
                    _cv.Ma = tb_ma.Text;
                    _cv.Ten = tb_ten.Text;
                    _cv.TrangThai = rB_hd.Checked ? 1 : 0;
                    _chucVuService.updateChucVu(_cv);
                    MessageBox.Show("Sửa chức vụ thành công");
                    resetForm();

                }
                else
                {
                    MessageBox.Show("Chức vụ đã tồn tại");
                }
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (_cv == null)
            {
                MessageBox.Show("Vui Lòng chọn mã chức vụ");
            }
            else
            {
                _chucVuService.deleteChucVu(_cv);
                MessageBox.Show("Xóa Thành Công");
                resetForm();
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            resetForm();
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
    }
}
