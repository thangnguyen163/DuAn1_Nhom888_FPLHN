﻿using _1.DAL.DomainClass;
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

namespace _3.PresentationLayers.Views
{
    public partial class Form_NhaPhatHanh : Form
    {
        private INhaPhatHanhService nhaPhatHanhService;
        private Guid SelectId;
        public Form_NhaPhatHanh()
        {
            InitializeComponent();
            nhaPhatHanhService = new NhaPhatHanhService();
        }
        public void LoadData()
        {
            int i = 1;
            dtg_show.ColumnCount = 5;
            dtg_show.Columns[0].Name = "STT";
            dtg_show.Columns[1].Name = "Id";
            dtg_show.Columns[1].Visible = false;
            dtg_show.Columns[2].Name = "Mã";
            dtg_show.Columns[3].Name = "Tên ";
            dtg_show.Columns[4].Name = "Trạng thái";
            dtg_show.Rows.Clear();
            foreach (var a in nhaPhatHanhService.GetAll())
            {
                dtg_show.Rows.Add(i++, a.Id, a.Ma, a.Ten, a.TrangThai == 0 ? "Không tồn tại" : "Tồn tại");
            }
        }
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(nhaPhatHanhService.Delete(SelectId));
                LoadData();
            }
            else
            {
                return;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(nhaPhatHanhService.Add(new NhaPhatHanh()
                {

                    Id = Guid.NewGuid(),
                    Ma = tbx_ma.Text,
                    Ten = tbx_ten.Text,
                    TrangThai = cbx_trangthai.Text == "Tồn tại" ? 0 : 1
                }));
                LoadData();
            }
            else
            {

                return;

            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Bạn muốn sửa không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(nhaPhatHanhService.Update(SelectId, new NhaPhatHanh()
                {


                    Ma = tbx_ma.Text,
                    Ten = tbx_ten.Text,
                    TrangThai = cbx_trangthai.Text == "Tồn tại" ? 0 : 1
                }));
                LoadData();
            }
            else
            {

                return;

            }
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            LoadData();
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
