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
    public partial class Form_QuenMatKhau : Form
    {
        INhanVienService _inhanVienService;
        public Form_QuenMatKhau()
        {
            InitializeComponent();
            _inhanVienService = new NhanVienService();
        }
        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            if (tb_ten.Text == String.Empty || tb_sdt.Text == String.Empty || tb_matkhau.Text == String.Empty || tb_nhaplaimatkhau.Text == String.Empty)
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            for (int i = 0; i < _inhanVienService.getNhanViensFromDB().Count; i++)
            {
                if (_inhanVienService.getNhanViensFromDB().Where(c => c.Ten == tb_ten.Text).ToList().Count == 0 || _inhanVienService.getNhanViensFromDB().Where(c => c.Sdt == tb_sdt.Text).ToList().Count == 0)
                {
                    MessageBox.Show("Tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (tb_ten.Text == _inhanVienService.getNhanViensFromDB()[i].Ten && tb_sdt.Text == _inhanVienService.getNhanViensFromDB()[i].Sdt)
                {
                    if (tb_matkhau.Text == tb_nhaplaimatkhau.Text)
                    {
                        var x = _inhanVienService.getNhanViensFromDB()[i];
                        x.MatKhau = tb_nhaplaimatkhau.Text;
                        MessageBox.Show(_inhanVienService.QuenMatKhau(x), "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    else if (tb_matkhau.Text != tb_nhaplaimatkhau.Text)
                    {
                        MessageBox.Show("Mật khẩu nhập lại chưa chính xác", "Cảnh báo", MessageBoxButtons.OK);
                        return;
                    }          
                }
            }
        }
        private void cb_pass1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_pass1.Checked == true)
            {
                tb_matkhau.PasswordChar = '\0';
            }
            else
            {
                tb_matkhau.PasswordChar = '*';
            }
        }

        private void cb_pass2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_pass2.Checked == true)
            {
                tb_nhaplaimatkhau.PasswordChar = '\0';
            }
            else
            {
                tb_nhaplaimatkhau.PasswordChar = '*';
            }
        }


    }
}
