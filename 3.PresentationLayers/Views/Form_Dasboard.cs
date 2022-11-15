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
        public Form_Dasboard()
        {
            InitializeComponent();
            random = new Random();

         
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

       
    }
}
