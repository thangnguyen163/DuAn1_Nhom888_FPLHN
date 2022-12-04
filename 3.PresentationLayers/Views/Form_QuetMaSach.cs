using _2.BUS.IService;
using _2.BUS.Service;
using _2.BUS.ViewModels;
using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace _3.PresentationLayers.Views
{
    public partial class Form_QuetMaSach : Form
    {
        IChiTietSachService _ichiTietSachService;
        List<ChiTietSachView> _listSachTheoMa;
        public Form_QuetMaSach()
        {
            InitializeComponent();
            _ichiTietSachService = new ChiTietSachService();


        }
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice videoCaptureDevice;
        public static string mavach;
        public static string tensach;
        public void BatCam()
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbb_tenmay.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }
        public void GetBookByMa()
        {
            if (_ichiTietSachService.GetAllChiTietSachView().Where(p => p.MaVach == tb_mavach.Text).ToList().Count == 0)
            {
                Lammoi();
                DialogResult dialogResult = MessageBox.Show("Chưa có sản phẩm này, bạn có muốn thêm sản phẩm mới không ", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Lammoi();
                    Form_ChiTietSach form = new Form_ChiTietSach(tb_mavach.Text);
                    form.ShowDialog();
                    tb_tensach.Text = String.Empty;
                    tb_mavach.Text = String.Empty;
                    return;
                }
                else/* (dialogResult == DialogResult.No) */
                {
                    tb_mavach.Text = string.Empty;
                    tb_tensach.Text = string.Empty;
                    return;
                }
            }
        }
        private void Lammoi()
        {
            try
            {
                videoCaptureDevice.SignalToStop();
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(Lammoi));
                    return;
                }
                if (ptb_barcode.Image != null)
                {
                    ptb_barcode.Image = null;
                    ptb_barcode.ImageLocation = null;
                    //pic_cam.Image = null;
                    ptb_barcode.Update();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "123");
                return;

            }
        }
        private void Form_QuetMaSach_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
            {
                cbb_tenmay.Items.Add(device.Name);
            }
            cbb_tenmay.SelectedIndex = 0;
            BatCam();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            if (result != null)
            {
                tb_mavach.Invoke(new MethodInvoker(delegate ()
                {
                    tb_mavach.Text = result.ToString();

                }));
            }
            ptb_barcode.Image = bitmap;
        }

        private void Form_QuetMaSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                videoCaptureDevice.SignalToStop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tb_mavach_TextChanged(object sender, EventArgs e)
        {
            videoCaptureDevice.SignalToStop();
            string x = _ichiTietSachService.GetAllChiTietSachView().Where(c => c.MaVach == tb_mavach.Text).Select(x => x.TenSach).FirstOrDefault();
            tb_tensach.Text = x;
            if (tb_tensach.Text != String.Empty)
            {
                mavach = tb_mavach.Text;
                tensach = tb_tensach.Text;
                this.Close();
                return;
            }
            if (tb_tensach.Text == String.Empty && tb_mavach.Text != String.Empty)
            {
                GetBookByMa();
                return;
            }
            if (tb_tensach.Text == String.Empty && tb_mavach.Text == String.Empty)
            {
                BatCam();
                return;
            }
        }
    }
}
