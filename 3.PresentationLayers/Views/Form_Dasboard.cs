using _2.BUS.IServices;
using _2.BUS.Serivces;
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
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        private IHoaDonService _ihoaDonService = new HoaDonService();
        public Form_Dasboard()
        {
            InitializeComponent();
            random = new Random();
            LoaddataToHoadon();



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
        public void LoaddataToHoadon()
        { int i = 1;
            dtg_hoadon.ColumnCount = 4;
            dtg_hoadon.Columns[0].Name = "STT";
            dtg_hoadon.Columns[0].Width = 50;

            dtg_hoadon.Columns[1].Name = "ID";
            dtg_hoadon.Columns[1].Visible =false;
            dtg_hoadon.Columns[2].Name = "Mã";
            dtg_hoadon.Columns[2].Width = 90;
            dtg_hoadon.Columns[3].Name = "Mã khách hàng";       
            dtg_hoadon.Columns[3].Width = 120;       
            dtg_hoadon.Rows.Clear();
            foreach (var x in _ihoaDonService.GetAll())
            {
                dtg_hoadon.Rows.Add(i++,x.Id,x.Mahd,x.Makh);
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtg_hdct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtg_hoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtg_sanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
