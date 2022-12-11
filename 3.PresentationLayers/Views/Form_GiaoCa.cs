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
    public partial class Form_GiaoCa : Form
    {
        public static decimal TongTien;
        IGiaoCaService _iGiaoCaServicel;
        INhanVienService _iNhanVienServicel;
        GiaoCa _gc;
        Form_Dasboard frm = new Form_Dasboard();
        public Form_Dasboard MyForm { get; set; }

        public Form_GiaoCa()
        {
            InitializeComponent();
            _iGiaoCaServicel = new GiaoCaService();
            _iNhanVienServicel = new NhanVienService();
            _gc = new GiaoCa();
            var caht = _iGiaoCaServicel.GetAll().Where(c => c.Ma == "GC" + _iGiaoCaServicel.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString()).FirstOrDefault();
            lb_tongtien.Text = caht.TongTienTrongCa.ToString();
            lb_tienmat.Text = caht.TongTienMat.ToString();
            lb_tienkhac.Text = caht.TongTienKhac.ToString();

        }

        private GiaoCa KetCa()
        {
            _gc = new GiaoCa();
            {
                var ID = _iGiaoCaServicel.GetAll().FirstOrDefault(c => c.Ma == "GC" + _iGiaoCaServicel.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString()).Id;
                var nv = _iNhanVienServicel.getNhanViensFromDB().FirstOrDefault(c => c.Email == tb_email.Text);
                _gc.Id = ID;
                _gc.ThoiGianGiaoCa = DateTime.Now;
                _gc.TongTienMat = Convert.ToDecimal(lb_tienmat.Text);
                _gc.TongTienKhac = Convert.ToDecimal(lb_tienkhac.Text);
                _gc.TongTienTrongCa = Convert.ToDecimal(lb_tongtien.Text);
                _gc.IdNhanVienCaTiep = nv.Id;
                _gc.ThoiGianReset = DateTime.Now;
            };
            return _gc;
        }

        private GiaoCa CaMoi()
        {
            _gc = new GiaoCa();
            {
                var cacu = _iGiaoCaServicel.GetAll().Where(c => c.Ma == "GC" + _iGiaoCaServicel.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString()).FirstOrDefault();
                var idnv = _iNhanVienServicel.getNhanViensFromDB().Where(c => c.Email == tb_email.Text).Select(c => c.Id).FirstOrDefault();
                _gc.Id = Guid.NewGuid();
                _gc.Ma = "GC" + _iGiaoCaServicel.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))+1).ToString();
                _gc.ThoiGianNhanCa = DateTime.Now;
                _gc.IdNhanVien = idnv;
                _gc.TongTienMat = Convert.ToDecimal(cacu.TongTienMat);
                _gc.TongTienKhac = Convert.ToDecimal(cacu.TongTienKhac);
                _gc.TongTienTrongCa = Convert.ToDecimal(cacu.TongTienTrongCa);
                _gc.TongTienMatCaTruoc = Convert.ToDecimal(cacu.TongTienTrongCa);
                _gc.TienPhatSinh = 0;
                _gc.TongTienMatRut = 0;
                _gc.TrangThai = 1;
            };
            return _gc;
        }
        private GiaoCa TienPhatSinh()
        {
            _gc = new GiaoCa();
            {
                var gcht = _iGiaoCaServicel.GetAll().FirstOrDefault(c => c.Ma == "GC" + _iGiaoCaServicel.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString());
                var nv = _iNhanVienServicel.getNhanViensFromDB().FirstOrDefault(c => c.Email == tb_email.Text);
                _gc.Id = gcht.Id;
                _gc.TienPhatSinh = gcht.TienPhatSinh + Convert.ToDecimal(tb_phatsinhtienmat.Text);
                _gc.GhiChuPhatSinh = tbx_ghichu.Text + "|" + gcht.GhiChuPhatSinh;
                _gc.TongTienMat = gcht.TongTienMat - Convert.ToDecimal(tb_phatsinhtienmat.Text);
                _gc.TongTienTrongCa = gcht.TongTienTrongCa - Convert.ToDecimal(tb_phatsinhtienmat.Text);
            };
            return _gc;
        }
        public static string emailgiao;
        public static string passgiao;
        public static decimal TienGiao;
        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn hãy đếm lại số tiền có trong két đã đủ" + lb_tongtien.Text, "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_iGiaoCaServicel.Update(KetCa()));
                for (int i = 0; i <= _iNhanVienServicel.getNhanViensFromDB().Count(); i++)
                {
                    if (_iNhanVienServicel.getNhanViensFromDB().Where(c => c.Email == tb_email.Text).ToList().Count == 0 || tb_email.Text == _iNhanVienServicel.getNhanViensFromDB()[i].Email && tb_matkhau.Text != _iNhanVienServicel.getNhanViensFromDB()[i].MatKhau)
                    {
                        MessageBox.Show("Email hoặc mật khẩu không hợp lệ", "Thất bại", MessageBoxButtons.OK);
                        return;
                    }
                    if (tb_email.Text == _iNhanVienServicel.getNhanViensFromDB()[i].Email && tb_matkhau.Text == _iNhanVienServicel.getNhanViensFromDB()[i].MatKhau)
                    {
                        var nv = _iNhanVienServicel.getNhanViensFromDB().FirstOrDefault(c => c.Email == tb_email.Text);
                        emailgiao = tb_email.Text;
                        passgiao = tb_matkhau.Text;
                        TienGiao = Convert.ToDecimal(lb_tongtien.Text);
                        _iGiaoCaServicel.Add(CaMoi());
                        MessageBox.Show($"Xin chào {nv.Ten}", "Giao ca thành công", MessageBoxButtons.OK);
                        this.Close();
                        //Form_DangNhap form_DangNhap = new Form_DangNhap(tb_email.Text, tb_matkhau.Text);
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
            if (tb_phatsinhtienmat.Text == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập tiền phát sinh", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (Convert.ToDecimal(lb_tienmat.Text) < Convert.ToDecimal(tb_phatsinhtienmat.Text == string.Empty ? 0 : tb_phatsinhtienmat.Text))
            {
                MessageBox.Show("Tổng số tiền mặt không đủ", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (tbx_ghichu.Text == String.Empty)
            {
                MessageBox.Show("Bạn phải nhập ghi chú cho tiền phát sinh này", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (ck_confirm.Checked==false)
            {
                MessageBox.Show("Bạn chưa xác nhận thông tin trên", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            MessageBox.Show(_iGiaoCaServicel.UpdateTienPhatSinh(TienPhatSinh()));
            var capnhat = _iGiaoCaServicel.GetAll().Where(c => c.Ma == "GC" + _iGiaoCaServicel.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString()).FirstOrDefault();
            lb_tongtien.Text = capnhat.TongTienTrongCa.ToString();
            lb_tienmat.Text = capnhat.TongTienMat.ToString();
            lb_tienkhac.Text = capnhat.TongTienKhac.ToString();
            tb_phatsinhtienmat.Text=string.Empty;
            tbx_ghichu.Text = string.Empty;
        }

        private void tb_tienphatsinh_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ck_confirm_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_confirm.Checked == true)
            {
                tbx_ghichu.Enabled = false;
                tb_phatsinhtienmat.Enabled = false;
            }
            else
            {
                tbx_ghichu.Enabled = true;
                tb_phatsinhtienmat.Enabled = true;
            }

        }
    }
}
