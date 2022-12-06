using _1.DAL.DomainClass;
using _2.BUS.IServices;
using _2.BUS.Serivces;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
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
            label3.Visible = false;
            label4.Visible = false;
            tb_matkhau.Visible= false;
            tb_nhaplaimatkhau.Visible= false;
            cb_pass1.Visible=false;
            cb_pass2.Visible=false;
            btn_xacnhan.Visible=false;
            
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

        private void button1_Click(object sender, EventArgs e)
        {

            int nv = _inhanVienService.getNhanViensFromDB().Where(x => x.Email == tb_ten.Text || x.Sdt==tb_sdt.Text).Count();
            if (nv > 0)
            {
                NhanVien nhanvien = new NhanVien();
                nhanvien = _inhanVienService.getNhanViensFromDB().Where(x => x.Email == tb_ten.Text).FirstOrDefault();

                string emailAddress = nhanvien.Email;

                //User u = db.Users.Single(x => x.EmailAddress == emailAddress);

                Random r = new Random();

                // lblMessage.ForeColor = System.Drawing.Color.LimeGreen;
                MailMessage mailMessage = new MailMessage();
                int a = r.Next(100000, 1000000);
                StringBuilder sbEmailBody = new StringBuilder();
                sbEmailBody.Append("Dear " + nhanvien.Ten + ",<br/><br/>");
                sbEmailBody.Append("Mật khẩu mới của bạn là: " + a);
                //sbEmailBody.Append("<br/>"); sbEmailBody.Append("http://localhost/Assignment/Registration/ChangePwd.aspx?uid=" );
                sbEmailBody.Append("<br/><br/>");
                sbEmailBody.Append("<b>Pragim Technologies</b>");

                mailMessage.IsBodyHtml = true;

                mailMessage.Body = sbEmailBody.ToString();
                mailMessage.Subject = "Hệ thống bán sách BeeBooks";
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = "thaitdph26029@fpt.edu.vn",
                    Password = "tranduythai010305"
                };
                string to = emailAddress;
                string from = "thaitdph26029@fpt.edu.vn";

                smtpClient.EnableSsl = true;

                mailMessage.From = new MailAddress(from);
                mailMessage.To.Add(to);
                smtpClient.Send(mailMessage);
                smtpClient.UseDefaultCredentials = false;
                nhanvien.MatKhau = Convert.ToString(a);
                _inhanVienService.updateNhanVien(nhanvien.Id,nhanvien);
                MessageBox.Show("Khôi phục mật khẩu thành công,Vui lòng kiểm tra Email của bạn");
                this.Close();
            }
            else
            {
                MessageBox.Show("Email hoặc số điện thoại không chính xác");
                return;
            }    
        }
    }
}
