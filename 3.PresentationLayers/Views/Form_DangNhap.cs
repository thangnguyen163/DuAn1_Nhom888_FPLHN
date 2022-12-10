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
        IGiaoCaService _igiaoCaService;
        public static string Email;
        public Form_DangNhap()
        {
            InitializeComponent();
            _iNhanVienSercvice = new NhanVienService();
            _igiaoCaService = new GiaoCaService();
            tb_tendangnhap.Text = Properties.Settings.Default.Username;
            tb_matkhau.Text = Properties.Settings.Default.Password;
            if(Properties.Settings.Default.Username==string.Empty)
                cb_NhoMk.Checked = false;
            else cb_NhoMk.Checked = true;
        }
        public Form_DangNhap(string email,string pass)
        {
            InitializeComponent();
            _iNhanVienSercvice = new NhanVienService();
            tb_tendangnhap.Text = Properties.Settings.Default.Username;
            tb_matkhau.Text = Properties.Settings.Default.Password;
            if (Properties.Settings.Default.Username == string.Empty)
                cb_NhoMk.Checked = false;
            else cb_NhoMk.Checked = true;
            tb_tendangnhap.Text = email;
            tb_matkhau.Text = pass;
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
                    InforLogin();
                    Email = tb_tendangnhap.Text;
                    Form_Dasboard fdb = new Form_Dasboard(tb_tendangnhap.Text);
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


        private void Form_DangNhap_Load_1(object sender, EventArgs e)
        {

        }

        private void lb_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void InforLogin()
        {
            if (cb_NhoMk.Checked == true)
            {
                Properties.Settings.Default.Username= tb_tendangnhap.Text;
                Properties.Settings.Default.Password= tb_matkhau.Text ;
                Properties.Settings.Default.UserLogin = tb_tendangnhap.Text;
                Properties.Settings.Default.Password = tb_matkhau.Text;
                Properties.Settings.Default.Save();
                cb_NhoMk.Checked=true;
            }
            else
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.UserLogin = tb_tendangnhap.Text;
                Properties.Settings.Default.PassLogin = tb_matkhau.Text;
                Properties.Settings.Default.Save();
            }
        }
    }
}