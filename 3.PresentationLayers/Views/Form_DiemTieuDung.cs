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
    public partial class Form_DiemTieuDung : Form
    {
        public IDiemTieuDungService diemTieuDungService;
        public Guid SelectId;
        public DiemTieuDung dtd;
        public Form_DiemTieuDung()
        {
            InitializeComponent();
            diemTieuDungService = new DiemTieuDungService();
            Loaddata();
        }
        public void Loaddata()
        {
            dtg_show.ColumnCount = 7;
            dtg_show.Columns[0].Name = "Id";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "Mã";
            dtg_show.Columns[2].Name = "Số điểm";
            dtg_show.Columns[3].Name = "Trạng thái";
            dtg_show.Rows.Clear();
            var lstdtd = diemTieuDungService.GetAll();
            foreach (var d in lstdtd)
            {
                dtg_show.Rows.Add(d.Id,d.Ma,d.SoDiem,d.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");
            }    
        }

        private void dtg_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_show.Rows[e.RowIndex];
                dtd = diemTieuDungService.GetAll().FirstOrDefault(x => x.Id == Guid.Parse(r.Cells[0].Value.ToString()));
                tb_ma.Text = r.Cells[1].Value.ToString();
                tb_sodiem.Text = r.Cells[2].Value.ToString();
                rd_hoatdong.Checked = dtd.TrangThai == 1;
                rd_khonghoatdong.Checked = dtd.TrangThai == 0;
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(diemTieuDungService.Add(new DiemTieuDung()
                {
                    Id = Guid.NewGuid(),
                    Ma = tb_ma.Text,
                    SoDiem = Convert.ToInt16(tb_sodiem.Text),
                    TrangThai = rd_hoatdong.Checked ? 1 : 0,
                }));
                Loaddata();
            }
            else
            {
                return;
            }
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(diemTieuDungService.Update(new DiemTieuDung()
                {
                    Ma = tb_ma.Text,    
                    SoDiem= Convert.ToInt16(tb_sodiem.Text),
                    TrangThai= rd_hoatdong.Checked ? 1 : 0,
                }));
                Loaddata();
            }
            else
            {
                return;
            }
        }

        private void rd_hoatdong_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_khonghoatdong.Checked)
            {
                rd_khonghoatdong.Checked = false;
            }
            rd_hoatdong.Checked = true;
        }

        private void rd_khonghoatdong_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_hoatdong.Checked)
            {
                rd_hoatdong.Checked = false;
            }
            rd_khonghoatdong.Checked = true;
        }
        void load_timkiem(string ma )
        {
            dtg_show.ColumnCount = 7;
            dtg_show.Columns[0].Name = "Id";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "Mã";
            dtg_show.Columns[2].Name = "Số điểm";
            dtg_show.Columns[3].Name = "Trạng thái";
            dtg_show.Rows.Clear();
            foreach (var d in diemTieuDungService.GetAll().Where(c => c.Ma.StartsWith(ma)))
            {
                dtg_show.Rows.Add(d.Id, d.Ma, d.SoDiem, d.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");
            }
        }

        private void tb_timkiem_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tb_timkiem.Text == "")
                {
                    tb_timkiem.Text = "Tìm kiếm theo tên, Email, Địa chỉ";
                    tb_timkiem.ForeColor = Color.Black;
                    diemTieuDungService.GetAll();
                    Loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
