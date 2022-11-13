using _2.BUS.IService;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace _3.PresentationLayers.Views
{
    public partial class Form_CTKhuyenMai : Form
    {
        private Guid SelectId;
        private IChiTietKhuyenMaiService chiTietKhuyenMaiService;
        public Form_CTKhuyenMai()
        {
            InitializeComponent();
            chiTietKhuyenMaiService = new ChiTietKhuyenMaiService();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {

        }

        private void btn_show_Click(object sender, EventArgs e)
        {

        }

        private void dtg_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == -1) return;
            SelectId = Guid.Parse(Convert.ToString(dtg_show.Rows[rd].Cells[1].Value));

            tbx_ma.Text = Convert.ToString(dtg_show.Rows[rd].Cells[2].Value);
            tbx_ten.Text = Convert.ToString(dtg_show.Rows[rd].Cells[3].Value);
            cbx_trangthai.Text = Convert.ToString(dtg_show.Rows[rd].Cells[4].Value);
        }
    }
}
