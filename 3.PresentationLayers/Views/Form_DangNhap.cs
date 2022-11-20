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
    public partial class Form_DangNhap : Form
    {
        INhanVienService _iNhanVienSercvice;
        public Form_DangNhap()
        {
            InitializeComponent();
            _iNhanVienSercvice = new NhanVienService();
        }
        private void lb_quenmk_Click(object sender, EventArgs e)
        {
            Form_QuenMatKhau qmk = new Form_QuenMatKhau();
            qmk.ShowDialog();
        }
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if (tb_tendangnhap.Text == String.Empty || tb_matkhau.Text == String.Empty)
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin để đăng nhập","Thông báo",MessageBoxButtons.OK);
                return;
            }
            for (int i = 0; i <= _iNhanVienSercvice.getNhanViensFromDB().Count(); i++)
            {
                if (_iNhanVienSercvice.getNhanViensFromDB().Where(c => c.Email == tb_tendangnhap.Text).ToList().Count == 0 || tb_tendangnhap.Text == _iNhanVienSercvice.getNhanViensFromDB()[i].Email && tb_matkhau.Text != _iNhanVienSercvice.getNhanViensFromDB()[i].MatKhau)
                {
                    MessageBox.Show("Thông tin đăng nhập không hợp lệ, vui lòng kiểm tra lại thông tin đăng nhập","Đăng nhập thất bại", MessageBoxButtons.OK);
                    return;
                }
                if (tb_tendangnhap.Text == _iNhanVienSercvice.getNhanViensFromDB()[i].Email && tb_matkhau.Text == _iNhanVienSercvice.getNhanViensFromDB()[i].MatKhau)
                {
                    Form_Dasboard fdb = new Form_Dasboard();
                    fdb.Show();
                    this.Hide();
                    MessageBox.Show($"Xin chào: {_iNhanVienSercvice.getNhanViensFromDB()[i].Ten}", "Đăng nhập thành công", MessageBoxButtons.OK);
                    return;
                }
                
            }
        }

        private void cb_hienthi_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_hienthi.Checked == true)
            {
                tb_matkhau.PasswordChar = '\0';
            }
            else
            {
                tb_matkhau.PasswordChar = '*';
            }
        }
    }
}
