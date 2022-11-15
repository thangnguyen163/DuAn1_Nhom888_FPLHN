using _2.BUS.IService;
using _2.BUS.IServices;
using _2.BUS.Serivces;
using _2.BUS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PresentationLayers.Views
{
    public partial class Form_Dasboard : Form
    {
        private IHoaDonService _ihoaDonService = new HoaDonService();
        private IHoaDonChiTietService _ihoaDonChiTietService = new HoaDonChiTietService();
        private IChiTietSachService chiTietSachService = new ChiTietSachService();
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public Form_Dasboard()
        {
            InitializeComponent();
            random = new Random();
            LoaddataToHoadon();
            LoaddataToChitietHoadon();

        }
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while(tempIndex== index)
            {
              index=  random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisabelButton();
                    Color color = SelectThemeColor();
                    currentButton= (Button)btnSender;
                    currentButton.BackColor=color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font= new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
        }
        private void DisabelButton()
        {
            foreach(Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor= Color.Gainsboro;
                    previousBtn.Font= new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
        }
        public void LoaddataToHoadon()
        {
            int i = 1;
            dtg_hoadon.ColumnCount = 4;
            dtg_hoadon.Columns[0].Name = "STT";
            dtg_hoadon.Columns[0].Width = 50;

            dtg_hoadon.Columns[1].Name = "ID";
            dtg_hoadon.Columns[1].Visible = false;
            dtg_hoadon.Columns[2].Name = "Mã";
            dtg_hoadon.Columns[2].Width = 90;
            dtg_hoadon.Columns[3].Name = "Mã khách hàng";
            dtg_hoadon.Columns[3].Width = 120;
            dtg_hoadon.Rows.Clear();
            foreach (var x in _ihoaDonService.GetAll())
            {
                dtg_hoadon.Rows.Add(i++, x.Id, x.Mahd, x.Makh);
            }
        }
        public void LoaddataToChitietHoadon()
        {
            int i = 1;
            dtg_hdct.ColumnCount = 9;
            dtg_hdct.Columns[1].Name = "STT";
            dtg_hdct.Columns[1].Width = 30;
            dtg_hdct.Columns[0].Name = "ID";
            dtg_hdct.Columns[1].Visible =false;
            dtg_hdct.Columns[2].Name = "Mã sách";
            dtg_hdct.Columns[3].Name = "Tên bìa";
            dtg_hdct.Columns[4].Name = "Tên Nxb";
            dtg_hdct.Columns[5].Name = "Tác giả";
            dtg_hdct.Columns[6].Name = "Số lượng";
            dtg_hdct.Columns[7].Name = "Đơn giá";
            dtg_hdct.Columns[8].Name = "Thành tiền";
            // dtg_hoadon.Columns[9].Name = "Trạng thái";
            dtg_hdct.Rows.Clear();
            foreach (var x in _ihoaDonChiTietService.GetAll())
            {
                dtg_hdct.Rows.Add(i++,x.ID,x.MactSach,x.tenbia,x.tennxb,x.tentg,x.Soluong,x.Dongia,x.Thanhtien);
            }
            
        }
        private void btn_shopping_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btn_manage_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

       
    }
}
