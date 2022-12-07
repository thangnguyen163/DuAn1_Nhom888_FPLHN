using _1.DAL.DomainClass;
using _2.BUS.IServices;
using _2.BUS.Serivces;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace _3.PresentationLayers.Views
{
    public partial class Form_KetCa : Form
    {
        public static decimal TongTien;
        IGiaoCaService _iGiaoCaServicel;
        INhanVienService _iNhanVienServicel;
        GiaoCa _gc;
        Form_Dasboard frm = new Form_Dasboard();
        public Form_Dasboard MyForm { get; set; }
     
        public Form_KetCa()
        {
            InitializeComponent();
            _iGiaoCaServicel = new GiaoCaService();
            _iNhanVienServicel = new NhanVienService();
            _gc = new GiaoCa();
            lb_tongtien.Text = Form_Dasboard.TienKetCa.ToString();
            
        }
       
        private GiaoCa NhanCa()
        {
            _gc = new GiaoCa();
            {
                var ID = _iGiaoCaServicel.GetAll().FirstOrDefault(c => c.Ma == "GC" + (_iGiaoCaServicel.GetAll().Count).ToString()).Id;
                var nv = _iNhanVienServicel.getNhanViensFromDB().FirstOrDefault(c => c.Email == tb_email.Text);
                _gc.Id = ID;
                _gc.ThoiGianGiaoCa = DateTime.Now;
                _gc.IdNhanVienCaTiep = nv.Id;
                _gc.TongTienTrongCa = Form_Dasboard.TienKetCa;
                _gc.ThoiGianReset = DateTime.Now;
            };
            return _gc;
        }
        private GiaoCa TienPhatSinh()
        {
            _gc = new GiaoCa();
            {
                var ID = _iGiaoCaServicel.GetAll().FirstOrDefault(c => c.Ma == "GC" + (_iGiaoCaServicel.GetAll().Count).ToString()).Id;
                var nv = _iNhanVienServicel.getNhanViensFromDB().FirstOrDefault(c => c.Email == tb_email.Text);
                _gc.Id = ID;
                _gc.TienPhatSinh = Convert.ToDecimal(_gc.TienPhatSinh) + Convert.ToDecimal(tb_tienphatsinh.Text);
                _gc.GhiChuPhatSinh = Convert.ToString(_gc.GhiChuPhatSinh + "," + tbx_ghichu.Text);
            };
            return _gc;
        }
        
        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn hãy đếm lại số tiền có trong két đã đủ" + lb_tongtien.Text, "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_iGiaoCaServicel.Update(NhanCa()));
                for (int i = 0; i <= _iNhanVienServicel.getNhanViensFromDB().Count(); i++)
                {
                    if (_iNhanVienServicel.getNhanViensFromDB().Where(c => c.Email == tb_email.Text).ToList().Count == 0 || tb_email.Text == _iNhanVienServicel.getNhanViensFromDB()[i].Email && tb_matkhau.Text != _iNhanVienServicel.getNhanViensFromDB()[i].MatKhau)
                    {
                        MessageBox.Show("Email hoặc mật khẩu không hợp lệ", "Thất bại", MessageBoxButtons.OK);
                        return;
                    }
                    if (tb_email.Text == _iNhanVienServicel.getNhanViensFromDB()[i].Email && tb_matkhau.Text == _iNhanVienServicel.getNhanViensFromDB()[i].MatKhau)
                    {
                        
                        //MessageBox.Show($"Xin chào: {_iNhanVienServicel.getNhanViensFromDB()[i].Ten}", "Giao ca thành công", MessageBoxButtons.OK);
                        //Form_Dasboard fdb = new Form_Dasboard();
                        //fdb.Show();
                        //Form_DangNhap form_DangNhap = new Form_DangNhap(tb_email.Text, tb_matkhau.Text);
                        //Application.Restart();
                        Form_Dasboard frm = new Form_Dasboard(0);
                        ///form_Dasboard.Close();
                        //frm.Show();
                        frm.closeForm();
                        this.Close();
                        return;
                    }
                }
            }
            else return;


        }
        private void tb_tienphatsinh_TextChanged(object sender, EventArgs e)
        {
            //    if (tb_tienphatsinh.Text == string.Empty)
            //    {
            //        lb_TongTienCaTruoc.Text = lb_tienketca.Text;
            //        return;
            //    }
            //    lb_tienketca.Text = (Convert.ToDecimal(lb_TongTienCaTruoc.Text) - Convert.ToDecimal(tb_tienphatsinh.Text)).ToString();
        }

        private void tb_email_TextChanged(object sender, EventArgs e)
        {
            if (tb_email.Text != string.Empty)
            {
                var nv = _iNhanVienServicel.getNhanViensFromDB().FirstOrDefault(c => c.Email == tb_email.Text);
                if (nv == null) return;
                lb_mavaten.Text = $"({nv.Ma} - {nv.Ten})";
            }
            else lb_mavaten.Text = "";
        }
        public static decimal TongTienHienTai;
        private void btn_tienphatsinh_Click(object sender, EventArgs e)
        {
            if (tb_tienphatsinh.Text == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập tiền phát sinh", "Thông báo", MessageBoxButtons.OK);
                return;

            }
            if (Convert.ToDecimal(lb_TongTienCaTruoc.Text) < Convert.ToDecimal(tb_tienphatsinh.Text))
            {
                MessageBox.Show("Số tiền trong ca không đủ cho tiền phát sinh", "Thông báo", MessageBoxButtons.OK);
                return;

            }
            if (tbx_ghichu.Text == String.Empty)
            {
                MessageBox.Show("Bạn phải nhập ghi chú cho tiền phát sinh này", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            MessageBox.Show(_iGiaoCaServicel.UpdateTienPhatSinh(TienPhatSinh()));
            lb_TongTienCaTruoc.Text = (Convert.ToDecimal(lb_TongTienCaTruoc.Text) - Convert.ToDecimal(tb_tienphatsinh.Text)).ToString();
            TongTienHienTai = Convert.ToDecimal(lb_TongTienCaTruoc.Text);
        }

        private void tb_tienphatsinh_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        
    }
}
