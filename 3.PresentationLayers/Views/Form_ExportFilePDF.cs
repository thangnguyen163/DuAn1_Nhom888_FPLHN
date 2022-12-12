using _2.BUS.Service;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.html.simpleparser;
using _2.BUS.IService;

namespace _3_GUI_PresentaionLayers
{
    public partial class Form_ExportFilePDF : Form
    {
        private IChiTietSachService _ichiTietSachService;
        public Form_ExportFilePDF()
        {
            InitializeComponent();
            _ichiTietSachService = new ChiTietSachService();
            LoadData();
        }
        void LoadData()
        {
            int stt = 1;
            dtg_Show.ColumnCount = 19;
            dtg_Show.Columns[0].Name = "STT";
            dtg_Show.Columns[1].Name = "Id";
            dtg_Show.Columns[1].Visible = false;
            dtg_Show.Columns[2].Name = "Sách";
            dtg_Show.Columns[3].Name = "NXB";
            dtg_Show.Columns[4].Name = "Tác giả";
            dtg_Show.Columns[5].Name = "NPH";
            dtg_Show.Columns[6].Name = "Loại bìa";
            dtg_Show.Columns[7].Name = "Mã";
            dtg_Show.Columns[8].Name = "Kích thước";
            dtg_Show.Columns[9].Name = "Năm xuất bản";
            dtg_Show.Columns[10].Name = "Mô tả";
            dtg_Show.Columns[11].Name = "Số trang";
            dtg_Show.Columns[12].Name = "Số lượng";
            dtg_Show.Columns[13].Name = "Giá nhập";
            dtg_Show.Columns[14].Name = "Giá bán";
            dtg_Show.Columns[15].Name = "Trạng thái";
            dtg_Show.Columns[16].Name = "Đường Dẫn";
            dtg_Show.Columns[16].Visible = false;
            dtg_Show.Columns[17].Name = "Mã vạch";
            dtg_Show.Columns[18].Name = "Thể loại ";
            dtg_Show.Rows.Clear();
            foreach (var a in _ichiTietSachService.GetAllChiTietSachView().OrderBy(x => x.Ma))
            {
                dtg_Show.Rows.Add(stt++, a.Id, a.TenSach, a.TenNxb, a.TenTacGia, a.TenNhaPhatHanh, a.TenLoaiBia, a.Ma, a.KichThuoc, a.NamXuatBan, a.MoTa, a.SoTrang, a.SoLuong, a.GiaNhap, a.GiaBan, a.TrangThai == 0 ? "Ngừng kinh doanh" : "Còn bán", a.Anh, a.MaVach, a.TenTheLoai);
            }
        }
        public void exportdata(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfPTable = new PdfPTable(dgw.Columns.Count);
            pdfPTable.DefaultCell.Padding = 3;
            pdfPTable.WidthPercentage = 100;
            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPTable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            //Add header;
            foreach (DataGridViewColumn col in dtg_Show.Columns)
            {
                PdfPCell pdfPCell = new PdfPCell(new Phrase(col.HeaderText));
                pdfPTable.AddCell(pdfPCell);
            }
            foreach (DataGridViewRow row in dtg_Show.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfPTable.AddCell(new Phrase(Convert.ToString(cell.Value), text));
                }
            }
            var savefiledialog = new SaveFileDialog();
            savefiledialog.FileName = filename;
            savefiledialog.DefaultExt = ".pdf";
            if (savefiledialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialog.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A1, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdfPTable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn Xuất Ra File PDF Hay Không", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    exportdata(dtg_Show, "Sản phẩm của BEEBOOKS");
                    MessageBox.Show("Xuất Ra File PDF Thành Công");
                    return;
                }
                if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Xuất Ra File PDF Thất Bại");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Rồi" + ex.Message);
                return;
            }
        }
    }
}
