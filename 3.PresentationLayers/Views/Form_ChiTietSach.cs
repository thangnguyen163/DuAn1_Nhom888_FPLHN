using _1.DAL.DomainClass;
using _2.BUS.IService;
using _2.BUS.Service;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using FontAwesome.Sharp;

namespace _3.PresentationLayers.Views
{
    public partial class Form_ChiTietSach : Form
    {
        private IChiTietSachService _iChiTietSachService;
        private List<ChiTietSach> _lstChiTietSach;
        private List<ChiTietSachView> _lstChiTietSachView;
        private Guid? SelectedID;
        public Form_ChiTietSach()
        {
            InitializeComponent();
            _iChiTietSachService = new ChiTietSachService();
            _lstChiTietSach = new List<ChiTietSach>();
            _lstChiTietSachView = new List<ChiTietSachView>();
        }
        void LoadData()
        {
            int stt = 0;
            dtg_Show.ColumnCount = 18;
            dtg_Show.Columns[0].Name = "STT";
            dtg_Show.Columns[1].Name = "Id";
            dtg_Show.Columns[1].Visible = false;
            dtg_Show.Columns[2].Name = "Sách";
            dtg_Show.Columns[3].Name = "NXB";
            dtg_Show.Columns[4].Name = "Tác giả";
            dtg_Show.Columns[5].Name = "NPH";
            dtg_Show.Columns[6].Name = "Loại bìa";
            dtg_Show.Columns[7].Name = "Mã";
            dtg_Show.Columns[8].Name = "Thể loại 1";
            dtg_Show.Columns[9].Name = "Thể loại 2";
            dtg_Show.Columns[10].Name = "Kích thước";
            dtg_Show.Columns[11].Name = "Năm xuất bản";
            dtg_Show.Columns[12].Name = "Mô tả";
            dtg_Show.Columns[13].Name = "Số lượng";
            dtg_Show.Columns[14].Name = "Giá nhập";
            dtg_Show.Columns[15].Name = "Giá bán";
            dtg_Show.Columns[16].Name = "Trạng thái";
            dtg_Show.Columns[17].Name = "Id";
            foreach (var a in _iChiTietSachService.GetAllChiTietSachView())
            {
                dtg_Show.Rows.Add(stt++);
            }


        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tbt_Search_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
