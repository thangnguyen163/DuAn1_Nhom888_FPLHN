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
    public partial class RutTien : Form
    {
        IGiaoCaService _iGiaoCaService;
        INhanVienService _iNhanVienService;
        IChucVuService _iChucVuService;
        GiaoCa _gc;
        public RutTien()
        {
            InitializeComponent();
            _iGiaoCaService = new GiaoCaService();
            _iNhanVienService = new NhanVienService();
            _iChucVuService = new ChucVuServivce();
            _gc = new GiaoCa();
        }
        private GiaoCa RutTien1()
        {
            _gc = new GiaoCa();
            {
                var GC = _iGiaoCaService.GetAll().FirstOrDefault(c => c.Ma == "GC" + _iGiaoCaService.GetAll().Max(c => Convert.ToInt32(c.Ma.Substring(2))).ToString());
                //var nv = _iNhanVienServicel.getNhanViensFromDB().FirstOrDefault(c => c.Email == tb_email.Text);
                _gc.Id = GC.Id;
                _gc.TongTienMatRut = GC.TongTienMatRut + Convert.ToDecimal(tbx_TienRut.Text);
                _gc.TongTienMat = GC.TongTienMat - Convert.ToDecimal(tbx_TienRut.Text);
                _gc.TongTienTrongCa = GC.TongTienTrongCa - Convert.ToDecimal(tbx_TienRut.Text);
            };
            return _gc;
        }
        private void btn_ruttien_Click(object sender, EventArgs e)
        {
            foreach (var a in _iNhanVienService.getViewNhanViens())
            {
                var nv = _iNhanVienService.getNhanViensFromDB().FirstOrDefault(c => c.Email == tbx_user.Text && c.MatKhau == tbx_pass.Text);
                if (a.nhanVien.Email == tbx_user.Text && a.nhanVien.MatKhau == tbx_pass.Text)
                {
                    if (a.nhanVien.IdchucVu == _iChucVuService.getChucVusFromDB().FirstOrDefault(c => c.Ten == "Nhân viên").Id)
                    {
                        MessageBox.Show("Chỉ quản trị mới có quyền rút tiền");
                        return;
                    }
                    else if (a.nhanVien.IdchucVu == _iChucVuService.getChucVusFromDB().FirstOrDefault(c => c.Ten == "Quản trị").Id)
                    {
                        DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn rút tiền không?", "Xác nhận", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            MessageBox.Show(_iGiaoCaService.UpdateRutTien(RutTien1()));
                            tbx_TienRut.Text = string.Empty;
                            tbx_pass.Text = string.Empty;
                            tbx_user.Text = string.Empty;
                            return;
                        }
                        else if (dialogResult == DialogResult.No) return;
                    }
                }
            }
        }
    }
}
