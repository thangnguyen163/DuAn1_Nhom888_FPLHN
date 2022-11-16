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
        private IChiTietSachService _ichiTietSachService = new ChiTietSachService();
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public Guid SelectID { get; set; }
        public Form_Dasboard()
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            
            
            // LoaddataToChitietHoadon(SelectID);
           

        }
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
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
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    PanelTitel.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
               

                }
            }
        }
        private void DisabelButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
        }
        



        private void OpenChildForm(Form ChildForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            this.PanelDesktopPanel.Controls.Add(ChildForm);
            this.PanelDesktopPanel.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
            labelTite.Text = ChildForm.Text;
        }


        private void btn_shopping_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_BanHang(), sender);

        }



        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender);
        }
        private void btn_sanpham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_Sach(), sender);
        }


        private void logout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dtg_hoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          //  SelectID = Guid.Parse(dtg_hoadon.CurrentRow.Cells[1].Value.ToString());
          ////  SelectID = Guid.Parse(dtg_showchitiet.CurrentRow.Cells[1].Value.ToString());
          //  LoaddataToChitietHoadon(SelectID);
        }

        private void dtg_sanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //int i = 100;
            //Guid a = Guid.Parse(Convert.ToString(dtg_sanpham.CurrentRow.Cells[1].Value));
            //var data = _ihoaDonChiTietService.GetAll().FirstOrDefault(x => x.Idchitietsp == a);
            //int count = _ihoaDonChiTietService.GetAll().Count;
            //if (data == null)
            //{
            //    var add = new HoaDonChiTiet();
            //    add.Id = Guid.NewGuid();
            //    add.IdHoaDon = SelectID;
            //    add.IdChiTietSach = Guid.Parse(Convert.ToString(dtg_sanpham.CurrentRow.Cells[1].Value));
            //    add.Ma = Convert.ToString(dtg_hoadon.CurrentRow.Cells[2].Value.ToString() + "" + Convert.ToString(count++));
            //    add.SoLuong = 1;
            //    add.DonGia = Convert.ToInt32(dtg_sanpham.CurrentRow.Cells[14].Value);
            //    add.ThanhTien = Convert.ToInt32(1 * Convert.ToInt32(dtg_sanpham.CurrentRow.Cells[14].Value));
            //    _ihoaDonChiTietService.Add(add);
            //}
            //else
            //{
            //    var add = new HoaDonChiTiet();
            //    add.SoLuong++;
            //    add.ThanhTien = add.SoLuong * add.DonGia;
            //    _ihoaDonChiTietService.Update(add);
            //}
            //// LoaddataToHoadon();
            //LoaddataToChitietHoadon(SelectID);
        }


       
      

      

     
        
    }
}
