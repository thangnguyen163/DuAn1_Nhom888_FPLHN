using _1.DAL.DomainClass;
using _2.BUS.IServices;
using _2.BUS.Serivces;
using iTextSharp.text.pdf.codec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PresentationLayers.Views
{
    public partial class Form_KhachHang : Form
    {
        private IKhachHangService _ikhachHangService = new KhachHangService();
        private IDiemTieuDungService _idiemTieuDungService = new DiemTieuDungService();
        private IHoaDonService _ihoaDonService = new HoaDonService(); 
        public Guid SelectID { get; set; }
        public Form_KhachHang()
        {
            InitializeComponent();
            Loaddata();

            rd_conhd.Checked = true;
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
            foreach (var x in _ikhachHangService.getKhachHangFromDB().OrderBy(x => x.Ma))
            {
                dtg_Show.Rows.Add(i++, x.ID, x.Ma, x.Ten, x.Sodt, x.Madiemtieudung, x.Trangthai == 1 ? "Còn hoạt động" : "Đã tạm dừng");
            }
        }
        public static string vietHoaChuCaiDau(string text)
        {
            var temp = text.ToLower();
            return temp.Substring(0, 1).ToUpper() + temp.Substring(1, temp.Length - 1);
        }
        public static string zenMaFpoly(string fullName, string number)
        {
            string[] arrNames = fullName.Split(' ');
            string msv = vietHoaChuCaiDau(arrNames[arrNames.Length - 1]);
            for (int i = 0; i < arrNames.Length - 1; i++)
            {
                
                msv += vietHoaChuCaiDau(arrNames[i][0].ToString());
            }

            return msv + number;
        }
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            Regex validatePhoneNumberRegex = new Regex("^\\+?[0-0][0-9]{7,14}$");
            if (string.IsNullOrEmpty(tb_ten.Text))
            {
                MessageBox.Show("Không được để trống tên khách hàng");
            }
            else if (string.IsNullOrEmpty(tb_sdt.Text))
            {
                MessageBox.Show("Không được để trống số điện thoại khách hàng");
            }
            else if (validatePhoneNumberRegex.IsMatch(tb_sdt.Text) == false)
            {
                MessageBox.Show("Hãy nhập đúng số điện thoại");
            }
            else
            {
                Random r = new Random();
                string ten = zenMaFpoly(convertToUnSign3(tb_ten.Text), Convert.ToString(r.Next(1000, 9999)));
                MessageBox.Show(ten);
                var a = Guid.NewGuid();
                var kh = new KhachHang();
                kh.Id = Guid.NewGuid();
                kh.Ma = ten;
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
                diemtieudung.Ma = "DTD" + Convert.ToString(_idiemTieuDungService.GetAll()
                                 .Max(c => Convert.ToInt32(c.Ma.Substring(3, c.Ma.Length - 3)) + 1));
               // diemtieudung.Ma = Convert.ToString(tb_ma.Text + "" + tb_sdt.Text);
                diemtieudung.SoDiem = 0;
                diemtieudung.TrangThai = 1;
                
                MessageBox.Show(_ikhachHangService.addKhachHang(kh, diemtieudung));
                Loaddata();
            }    
            
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

            if (SelectID != default)
            {
                Regex validatePhoneNumberRegex = new Regex("^\\+?[0-0][0-9]{7,14}$");
                //validatePhoneNumberRegex.IsMatch("+12223334444");
                if (string.IsNullOrEmpty(tb_ten.Text))
                {
                    MessageBox.Show("Không được để trống tên khách hàng");
                }
                else if (string.IsNullOrEmpty(tb_sdt.Text))
                {
                    MessageBox.Show("Không được để trống số điện thoại khách hàng");
                }
                else if (validatePhoneNumberRegex.IsMatch(tb_sdt.Text)==false)
                {
                    MessageBox.Show("hãy nhập đúng số điện thoại");
                }
                else
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
            }
        }
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (SelectID != default)
            {
                if (_ihoaDonService.GetAllHoaDon().Where(x=>x.Idkh==SelectID).Count()==0)
                {
                    var kh = new KhachHang();
                    kh.Id = SelectID;
                    MessageBox.Show(_ikhachHangService.deleteKhachHang(kh));
                    Loaddata();
                }
                else
                {
                    MessageBox.Show("Khách hàng đã có trong hóa đơn, hiện tại không thể xóa");
                }
            }
            else
            {
                return;
            }    
            
        }

        private void tb_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
