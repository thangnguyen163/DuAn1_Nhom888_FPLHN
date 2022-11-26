using _2.BUS.IService;
using _2.BUS.Service;
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
        ISachService _iSachService;
        public Form_QuetMaSach()
        {
            InitializeComponent();
            _ichiTietSachService = new ChiTietSachService();
            _iSachService = new SachService();
        }
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice videoCaptureDevice;
        public static string mavach;
        public static string tensach;
        private void Lammoi()
        {
            try
            {
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

        private void button1_Click(object sender, EventArgs e)
        {
            tb_mavach.Text = "";
            tb_tensach.Text = "";
            Lammoi();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            mavach = tb_mavach.Text;
            tensach= tb_tensach.Text;
            this.Close();
        }

        private void Form_QuetMaSach_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
            {
                cbb_tenmay.Items.Add(device.Name);
            }
            cbb_tenmay.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbb_tenmay.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
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
                if (videoCaptureDevice != null)
                {
                    if (videoCaptureDevice.IsRunning == true) videoCaptureDevice.SignalToStop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tb_mavach_TextChanged(object sender, EventArgs e)
        {

                string x = _ichiTietSachService.GetAllChiTietSachView().Where(c => c.MaVach == tb_mavach.Text).Select(x => x.TenSach).FirstOrDefault();
                tb_tensach.Text = x;
            
        }
    }
}
