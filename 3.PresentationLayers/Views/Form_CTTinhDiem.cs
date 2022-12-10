using _1.DAL.DomainClass;
using _2.BUS.IServices;
using _2.BUS.Serivces;
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
    public partial class Form_CTTinhDiem : Form
    {
        private ICongThucTinhDiemService _congThucTinhDiemService;
        private CongThucTinhDiem _cttd;
        public Form_CTTinhDiem()
        {
            InitializeComponent();
            _congThucTinhDiemService = new CongThucTinhDiemService();
            _cttd = new CongThucTinhDiem();
            loadData();
        }
        public void loadData()
        {
            dtg_Show.ColumnCount = 7;
            dtg_Show.Columns[0].Name = "Id";
            dtg_Show.Columns[0].Visible = false;
            dtg_Show.Columns[1].Name = "Mã";
            dtg_Show.Columns[2].Name = "Tổng tiền ";
            dtg_Show.Columns[3].Name = "Hệ Số";
            dtg_Show.Columns[4].Name = "Giảm giá ";
            dtg_Show.Columns[5].Name = "Tổng Điểm ";
            dtg_Show.Columns[6].Name = "Trạng thái";
            dtg_Show.Rows.Clear();
            var lstCttd = _congThucTinhDiemService.GetAll();
            foreach (var x in lstCttd)
            {
                dtg_Show.Rows.Add(x.Id,x.Ma,x.TongDiem,x.HeSo,x.GiamGia,x.TongDiem,x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");
            }    
        }

        private void dtg_Show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_Show.Rows[e.RowIndex];
                _cttd = _congThucTinhDiemService.GetAll().FirstOrDefault(x => x.Id == Guid.Parse(r.Cells[0].Value.ToString()));
                tb_ma.Text = r.Cells[1].Value.ToString();
                tb_tongtien.Text = r.Cells[2].Value.ToString();
                tb_heso.Text = r.Cells[3].Value.ToString();
                tb_giamgia.Text = r.Cells[4].Value.ToString();
                tb_tongdiem.Text = r.Cells[5].Value.ToString();
                cbb_trangthai.Text = r.Cells[6].Value.ToString();
            }    
        }
    }
}
