using _1.DAL.DomainClass;
using _2.BUS.IService;
using _2.BUS.IServices;
using _2.BUS.Serivces;
using _2.BUS.Service;
using iTextSharp.text.pdf.codec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PresentationLayers.Views
{
    public partial class Form_DoiMatKhau : Form
    { 
        private ICheckPassService _checkPassService;
        private IChucVuService _ichucVuService;
        private INhanVienService _inhanVienService;
        private Guid SelectID;
        private NhanVien _nv;
        public Form_DoiMatKhau()
        {
            InitializeComponent();
            _ichucVuService = new ChucVuServivce();
            _inhanVienService = new NhanVienService();
            _checkPassService = new CheckPassService();
            _nv = new NhanVien();
            
        }
        private void btn_dmk_Click(object sender, EventArgs e)
        {
            if (tb_mkc.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ", "Thông Báo");
                return;
            }
            if (tb_mkm.Text == string.Empty)
            {
                MessageBox.Show("Mời bạn nhập mật khẩu mới", "Thông báo");
                return;
            }
            if (tb_nhaplai.Text == string.Empty)
            {
                MessageBox.Show("Bạn hãy nhập trùng với mật khẩu cũ đi nào", "Thông Báo");
                return;
            }
            for (int i = 0; i < _inhanVienService.getNhanViensFromDB().Count(); i++)
            {
                if (tb_mkc.Text == _inhanVienService.getNhanViensFromDB()[i].MatKhau )
                {
                    
                    if(tb_mkm.Text == tb_nhaplai.Text)
                    {
                        var x = _inhanVienService.getNhanViensFromDB()[i];
                        x.MatKhau = tb_nhaplai.Text;
                        MessageBox.Show(_inhanVienService.save(x), "Thông báo", MessageBoxButtons.OK);
                        this.Close();
                        return;
                    }
                    else if (tb_mkm.Text != tb_nhaplai.Text)
                    {
                        MessageBox.Show("Mật khẩu nhập lại chưa chính xác", "Cảnh báo", MessageBoxButtons.OK);
                        return;
                    }
                }
                else if (tb_mkc.Text != _inhanVienService.getNhanViensFromDB()[i].MatKhau)
                {
                    MessageBox.Show("Mật khẩu nhập chưa chính xác", "Thông Báo", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tb_mkc.UseSystemPasswordChar = false;
            }    
            else
            {
                tb_mkc.UseSystemPasswordChar = true;
            }    
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                tb_mkm.UseSystemPasswordChar = false;
            }
            else
            {
                tb_mkm.UseSystemPasswordChar = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                tb_nhaplai.UseSystemPasswordChar = false;
            }
            else
            {
                tb_nhaplai.UseSystemPasswordChar = true;
            }
        }
    }
}
