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
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PresentationLayers.Views
{
    public partial class Form_NXB : Form
    {
        INXBService _iNSXService;
        Nxb _nxb;
        public string TrangThai { get; set; }
        public Guid SelectID { get; set; }
        public Form_NXB()
        {
            InitializeComponent();
            _iNSXService = new NXBService();
            _nxb = new Nxb();
            Load();
        }
        private void LoadDataToDtg(List<NXBView> lst)
        {
            int stt = 1;
            dtg_Show.Rows.Clear();
            dtg_Show.ColumnCount = 5;
            dtg_Show.Columns[0].Name = "STT";
            dtg_Show.Columns[1].Name = "ID";
            dtg_Show.Columns[1].Visible = false;
            dtg_Show.Columns[2].Name = "Mã";
            dtg_Show.Columns[3].Name = "Tên";
            dtg_Show.Columns[4].Name = "Trạng thái";
            foreach (var x in lst)
            {
                dtg_Show.Rows.Add(stt++, x.Id, x.Ma, x.Ten, x.TrangThai == 0 ? "Không hoạt động" : "Hoạt động");
            }
            dtg_Show.AllowUserToAddRows= false;
        }
        private void Load()
        {
            LoadDataToDtg(_iNSXService.GetAll());
            // Thêm trạng thái vào cbb
            List<int> lsttt = new List<int>();
            foreach (var x in _iNSXService.GetAll())
            {
                lsttt.Add((int)x.TrangThai);
            }
            cbb_trangthai.Items.Clear();
            cbb_trangthai.Items.Add("--Chọn--");
            foreach (var x in lsttt.Distinct())
            {
                cbb_trangthai.Items.Add(x == 0 ? "Không hoạt động" : "Hoạt động");
            }
            cbb_trangthai.SelectedIndex = 0;
        }
        private void ResetForm()
        {
            LoadDataToDtg(_iNSXService.GetAll());
            _nxb = null;
            tb_ma.Text = "";
            tb_ten.Text = "";
            cbb_trangthai.Text = "--Chọn--";
        }
        private Nxb GetDataFromGui_Them()
        {
            _nxb = new Nxb();
            {
                _nxb.Ma = tb_ma.Text;
                _nxb.Ten = tb_ten.Text;
                _nxb.TrangThai = cbb_trangthai.Text == "Không hoạt động" ? 0 : 1;
            };
            return _nxb;
        }
        private Nxb GetDataFromGui_Sua_Xoa()
        {
            _nxb = new Nxb();
            {
                _nxb.Id = SelectID;
                _nxb.Ma = tb_ma.Text;
                _nxb.Ten = tb_ten.Text;
                _nxb.TrangThai = Convert.ToInt32(cbb_trangthai.Text);
            };
            return _nxb;
        }
        private void dtg_Show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            SelectID = Guid.Parse(dtg_Show.CurrentRow.Cells[1].Value.ToString());
            tb_ma.Text = dtg_Show.CurrentRow.Cells[2].Value.ToString();
            tb_ten.Text = dtg_Show.CurrentRow.Cells[3].Value.ToString();
            cbb_trangthai.Text = dtg_Show.CurrentRow.Cells[4].Value.ToString();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm đối tượng không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (tb_ma.Text == "" || tb_ten.Text == "" || cbb_trangthai.Text == "--Chọn--")
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                MessageBox.Show(_iNSXService.Add(GetDataFromGui_Them()));
                ResetForm();
            }
            else return;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn cập nhật đối tượng không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (tb_ma.Text == "" || tb_ten.Text == "" || cbb_trangthai.Text == "--Chọn--")
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                MessageBox.Show(_iNSXService.Update(GetDataFromGui_Sua_Xoa()));
                ResetForm();
            }
            else return;
            
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn cập nhật đối tượng không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_iNSXService.Delete(GetDataFromGui_Sua_Xoa()));
                ResetForm();
            }
            else return;
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
