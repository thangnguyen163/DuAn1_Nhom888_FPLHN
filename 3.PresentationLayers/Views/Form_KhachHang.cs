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
    public partial class Form_KhachHang : Form
    {
        private IKhachHangService _ikhachHangService = new KhachHangService();
        private IDiemTieuDungService _idiemTieuDungService = new DiemTieuDungService();
        public Guid SelectID { get; set; }
        public Form_KhachHang()
        {
            InitializeComponent();
            Loaddata();


        }
        public void Loaddata()
        {
            int i = 1;
            dtg_Show.ColumnCount = 7;
            dtg_Show.Columns[0].Name = "STT";
            dtg_Show.Columns[1].Name = "Id Khách hàng";
            dtg_Show.Columns[1].Visible = false;
            dtg_Show.Columns[2].Name = "Mã khách hàng";
            dtg_Show.Columns[3].Name = "Tên ";
            dtg_Show.Columns[4].Name = "Số điện thoại";
            dtg_Show.Columns[5].Name = "Mã điểm tiêu dùng";
            dtg_Show.Columns[6].Name = "Trạng thái";
            dtg_Show.Rows.Clear();
            foreach (var x in _ikhachHangService.getKhachHangFromDB())
            {
                dtg_Show.Rows.Add(i++, x.ID, x.Ma, x.Ten, x.Sodt, x.Madiemtieudung, x.Trangthai == 1 ? "Còn hoạt động" : "Đã tạm dừng");
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            var a = Guid.NewGuid();
            var kh = new KhachHang();
            kh.Id = Guid.NewGuid();
            kh.Ma = tb_ma.Text;
            kh.Ten = tb_ten.Text;
            kh.Sdt = tb_sdt.Text;
            kh.IddiemTieuDung = a;
            if (rd_conhd.Checked == true)
            {
                kh.TrangThai = 1;
            }
            else
            {
                kh.TrangThai = 0;
            }
            var diemtieudung = new DiemTieuDung();
            diemtieudung.Id = a;
            diemtieudung.Ma = Convert.ToString(tb_ma.Text + "" + tb_sdt.Text); 
            diemtieudung.SoDiem = 0;
            diemtieudung.TrangThai = 1;
            //  diemtieudung.IdKh = a;
            MessageBox.Show(_ikhachHangService.addKhachHang(kh, diemtieudung));
            Loaddata();
        }

        private void dtg_Show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_ma.Text = dtg_Show.CurrentRow.Cells[2].Value.ToString();
            tb_ten.Text = dtg_Show.CurrentRow.Cells[3].Value.ToString();
            tb_sdt.Text = dtg_Show.CurrentRow.Cells[4].Value.ToString();
            cbb_iddtd.Text = dtg_Show.CurrentRow.Cells[5].Value.ToString();
            if (Convert.ToString(dtg_Show.CurrentRow.Cells[6].Value.ToString())== "Còn hoạt động")
            {
                rd_conhd.Checked = true;
            }
            else
            {
                rd_dadung.Checked = true;
            }
            SelectID = Guid.Parse(Convert.ToString(dtg_Show.CurrentRow.Cells[1].Value.ToString()));
        }

        private void Form_KhachHang_Load(object sender, EventArgs e)
        {
            foreach (var x in _idiemTieuDungService.GetAll())
            {
                cbb_iddtd.Items.Add(x.Ma);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
           
            var kh = new KhachHang();
            kh.Id = SelectID;
            kh.Ma = tb_ma.Text;
            kh.Ten = tb_ten.Text;
            kh.Sdt = tb_sdt.Text;
           // kh.IddiemTieuDung = a;
            if (rd_conhd.Checked == true)
            {
                kh.TrangThai = 1;
            }
            else
            {
                kh.TrangThai = 0;
            }
            
            MessageBox.Show(_ikhachHangService.updateKhachHang(kh));
            Loaddata();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            var kh = new KhachHang();
            kh.Id = SelectID;         
            MessageBox.Show(_ikhachHangService.deleteKhachHang(kh));
            Loaddata();
        }
    }
}
