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
    public partial class Form_NhanCaLam : Form
    {
        public static decimal TongTien;
        IGiaoCaService _iGiaoCaServicel;
        INhanVienService _iNhanVienServicel;
        GiaoCa _gc;
        public Form_NhanCaLam()
        {
            InitializeComponent();
            _iGiaoCaServicel = new GiaoCaService();
            _iNhanVienServicel = new NhanVienService();
            _gc = new GiaoCa();
            lb_manv.Text = _iNhanVienServicel.getNhanViensFromDB().Where(c => c.Email == Form_DangNhap.Email).Select(c => c.Ma).FirstOrDefault();
        }

        private GiaoCa NhanCa()
        {
            _gc = new GiaoCa();
            {
                var idnv = _iNhanVienServicel.getNhanViensFromDB().Where(c => c.Email == Form_DangNhap.Email).Select(c => c.Id).FirstOrDefault();
                _gc.Id = Guid.NewGuid();
                _gc.Ma = "GC" + (_iGiaoCaServicel.GetAll().Count + 1).ToString();
                _gc.ThoiGianNhanCa = DateTime.Now;
                _gc.IdNhanVien = idnv;
                _gc.TongTienTrongCa = Convert.ToDecimal(tbx_tienbandau.Text);
                _gc.TienPhatSinh = 0;
                _gc.TongTienMatRut = 0;
                _gc.TrangThai = 1;
            };
            return _gc;
        }
        private void btn_TiepNhan_Click(object sender, EventArgs e)
        {
            if (tbx_tienbandau.Text == String.Empty)
            {
                MessageBox.Show("Bạn chưa nhận số tiền ban đầu", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                TongTien = Convert.ToDecimal(tbx_tienbandau.Text);
                MessageBox.Show(_iGiaoCaServicel.Add(NhanCa()));
                this.Close();
            }
           
        }

        private void tbx_tienbandau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
