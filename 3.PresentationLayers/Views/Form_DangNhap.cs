using _1.DAL.DomainClass;
using _2.BUS.IService;
using _2.BUS.IServices;
using _2.BUS.Serivces;
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
    public partial class Form_DangNhap : Form
    {
        INhanVienService _iNhanVienSercvice;
        IGiaoCaService _igiaoCaService;
        IChucVuService _iChucVuService;
        public static string Email;
        public Form_DangNhap()
        {
            InitializeComponent();
            _iNhanVienSercvice = new NhanVienService();
            _igiaoCaService = new GiaoCaService();
            _iChucVuService = new ChucVuServivce();
            tb_tendangnhap.Text = Properties.Settings.Default.Username;
            tb_matkhau.Text = Properties.Settings.Default.Password;
            if (Properties.Settings.Default.Username == string.Empty)
                cb_NhoMk.Checked = false;
            else cb_NhoMk.Checked = true;
        }
        public Form_DangNhap(string email, string pass)
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
            var cahientai = _igiaoCaService.GetAll().Where(c => c.Ma == "GC" + _igiaoCaService.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString()).FirstOrDefault();
            if (tb_tendangnhap.Text == String.Empty || tb_matkhau.Text == String.Empty)
            {
                MessageBox.Show("B???n c???n nh???p ?????y ????? th??ng tin ????? ????ng nh???p", "Th??ng b??o", MessageBoxButtons.OK);
                return;
            }
            for (int i = 0; i <= _iNhanVienSercvice.getNhanViensFromDB().Count(); i++)
            {
                if (_iNhanVienSercvice.getNhanViensFromDB().Where(c => c.Email == tb_tendangnhap.Text).ToList().Count == 0 || tb_tendangnhap.Text == _iNhanVienSercvice.getNhanViensFromDB()[i].Email && tb_matkhau.Text != _iNhanVienSercvice.getNhanViensFromDB()[i].MatKhau)
                {
                    MessageBox.Show("Th??ng tin ????ng nh???p kh??ng h???p l???, vui l??ng ki???m tra l???i th??ng tin ????ng nh???p", "????ng nh???p th???t b???i", MessageBoxButtons.OK);
                    return;
                }
                if (tb_tendangnhap.Text == _iNhanVienSercvice.getNhanViensFromDB()[i].Email && tb_matkhau.Text == _iNhanVienSercvice.getNhanViensFromDB()[i].MatKhau)
                {
                    var LastTK = _igiaoCaService.GetAll().Where(c => c.Ma == "GC" + _igiaoCaService.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString()).FirstOrDefault().IdNhanVien;
                    var CheckTk = _iNhanVienSercvice.getNhanViensFromDB().Where(p => p.Email == tb_tendangnhap.Text).FirstOrDefault().Id;
                    var idchucvu = _iChucVuService.getChucVusFromDB().Where(c => c.Ten.ToLower() == "Nh??n vi??n".ToLower()).Select(c => c.Id).FirstOrDefault();
                    var manvht = _iNhanVienSercvice.getNhanViensFromDB().Where(c => c.Id == cahientai.IdNhanVien).Select(c => c.Ma).FirstOrDefault();
                    var tennvht = _iNhanVienSercvice.getNhanViensFromDB().Where(c => c.Id == cahientai.IdNhanVien).Select(c => c.Ten).FirstOrDefault();
                    if ( LastTK != CheckTk && cahientai.ThoiGianReset.ToString() == string.Empty &&  _iNhanVienSercvice.getNhanViensFromDB()[i].IdchucVu == idchucvu)
                    {
                        MessageBox.Show($"Ca tr?????c ch??a k???t th??c, vui l??ng li??n h??? nh??n vi??n ca tr?????c ({manvht} - {tennvht}) ????? k???t th??c ca", "Th??ng b??o", MessageBoxButtons.OK);
                        return;
                    }
                    
                    InforLogin();
                    Email = tb_tendangnhap.Text;
                    Form_Dasboard fdb = new Form_Dasboard(tb_tendangnhap.Text);
                    fdb.Show();
                    this.Hide();
                    MessageBox.Show($"Xin ch??o:  {_iNhanVienSercvice.getNhanViensFromDB()[i].Ten}", "????ng nh???p th??nh c??ng", MessageBoxButtons.OK);
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
                Properties.Settings.Default.Username = tb_tendangnhap.Text;
                Properties.Settings.Default.Password = tb_matkhau.Text;
                Properties.Settings.Default.UserLogin = tb_tendangnhap.Text;
                Properties.Settings.Default.Password = tb_matkhau.Text;
                Properties.Settings.Default.Save();
                cb_NhoMk.Checked = true;
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