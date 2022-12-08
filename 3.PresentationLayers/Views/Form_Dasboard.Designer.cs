namespace _3.PresentationLayers.Views
{
    partial class Form_Dasboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Dasboard));
            this.PanelTitel = new System.Windows.Forms.Panel();
            this.btn_LamMoi = new System.Windows.Forms.Button();
            this.lb_TongTien = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_date = new System.Windows.Forms.Label();
            this.lb_time = new System.Windows.Forms.Label();
            this.labelTite = new System.Windows.Forms.Label();
            this.lb_XinChao = new System.Windows.Forms.Label();
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.PanelDesktopPanel = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_chucvu = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btn_LogOut = new System.Windows.Forms.Button();
            this.btn_NhanCa = new System.Windows.Forms.Button();
            this.btn_RutTien = new System.Windows.Forms.Button();
            this.btn_KetCa = new System.Windows.Forms.Button();
            this.btn_KhachHang = new System.Windows.Forms.Button();
            this.btn_NhanVien = new System.Windows.Forms.Button();
            this.btn_HoaDon = new System.Windows.Forms.Button();
            this.btn_sanpham = new System.Windows.Forms.Button();
            this.btn_shopping = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PanelTitel.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTitel
            // 
            this.PanelTitel.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.PanelTitel.Controls.Add(this.btn_LamMoi);
            this.PanelTitel.Controls.Add(this.lb_TongTien);
            this.PanelTitel.Controls.Add(this.label2);
            this.PanelTitel.Controls.Add(this.lb_date);
            this.PanelTitel.Controls.Add(this.lb_time);
            this.PanelTitel.Controls.Add(this.labelTite);
            this.PanelTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitel.Location = new System.Drawing.Point(228, 0);
            this.PanelTitel.Name = "PanelTitel";
            this.PanelTitel.Size = new System.Drawing.Size(1158, 100);
            this.PanelTitel.TabIndex = 1;
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LamMoi.ForeColor = System.Drawing.Color.White;
            this.btn_LamMoi.Location = new System.Drawing.Point(18, 55);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(137, 39);
            this.btn_LamMoi.TabIndex = 6;
            this.btn_LamMoi.Text = "Làm mới";
            this.btn_LamMoi.UseVisualStyleBackColor = true;
            this.btn_LamMoi.Click += new System.EventHandler(this.btn_LamMoi_Click);
            // 
            // lb_TongTien
            // 
            this.lb_TongTien.AutoSize = true;
            this.lb_TongTien.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_TongTien.ForeColor = System.Drawing.Color.White;
            this.lb_TongTien.Location = new System.Drawing.Point(182, 12);
            this.lb_TongTien.Name = "lb_TongTien";
            this.lb_TongTien.Size = new System.Drawing.Size(0, 31);
            this.lb_TongTien.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tiền trong ca :";
            // 
            // lb_date
            // 
            this.lb_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_date.AutoSize = true;
            this.lb_date.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_date.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_date.Location = new System.Drawing.Point(984, 69);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(50, 20);
            this.lb_date.TabIndex = 3;
            this.lb_date.Text = "label2";
            // 
            // lb_time
            // 
            this.lb_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_time.AutoSize = true;
            this.lb_time.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_time.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_time.Location = new System.Drawing.Point(984, 49);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(50, 20);
            this.lb_time.TabIndex = 2;
            this.lb_time.Text = "label2";
            // 
            // labelTite
            // 
            this.labelTite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTite.AutoSize = true;
            this.labelTite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTite.ForeColor = System.Drawing.Color.White;
            this.labelTite.Location = new System.Drawing.Point(549, 44);
            this.labelTite.Name = "labelTite";
            this.labelTite.Size = new System.Drawing.Size(76, 25);
            this.labelTite.TabIndex = 0;
            this.labelTite.Text = "HOME";
            // 
            // lb_XinChao
            // 
            this.lb_XinChao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_XinChao.AutoSize = true;
            this.lb_XinChao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.lb_XinChao.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_XinChao.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_XinChao.Location = new System.Drawing.Point(54, 3);
            this.lb_XinChao.Name = "lb_XinChao";
            this.lb_XinChao.Size = new System.Drawing.Size(76, 20);
            this.lb_XinChao.TabIndex = 1;
            this.lb_XinChao.Text = "Nhanvien";
            this.lb_XinChao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandTimeout = 30;
            this.sqlCommand1.Connection = null;
            this.sqlCommand1.Notification = null;
            this.sqlCommand1.Transaction = null;
            // 
            // PanelDesktopPanel
            // 
            this.PanelDesktopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelDesktopPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PanelDesktopPanel.Location = new System.Drawing.Point(228, 100);
            this.PanelDesktopPanel.Name = "PanelDesktopPanel";
            this.PanelDesktopPanel.Size = new System.Drawing.Size(1158, 673);
            this.PanelDesktopPanel.TabIndex = 2;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.panel2);
            this.panelLogo.Controls.Add(this.panel1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(228, 234);
            this.panelLogo.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lb_XinChao);
            this.panel2.Controls.Add(this.lb_chucvu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 66);
            this.panel2.TabIndex = 1;
            // 
            // lb_chucvu
            // 
            this.lb_chucvu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_chucvu.AutoSize = true;
            this.lb_chucvu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.lb_chucvu.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_chucvu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_chucvu.Location = new System.Drawing.Point(78, 37);
            this.lb_chucvu.Name = "lb_chucvu";
            this.lb_chucvu.Size = new System.Drawing.Size(68, 20);
            this.lb_chucvu.TabIndex = 2;
            this.lb_chucvu.Text = "Chức vụ ";
            this.lb_chucvu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 168);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(26, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(180, 168);
            this.panel6.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 168);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(206, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(22, 168);
            this.panel5.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(26, 168);
            this.panel3.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btn_LogOut);
            this.panelMenu.Controls.Add(this.btn_NhanCa);
            this.panelMenu.Controls.Add(this.btn_RutTien);
            this.panelMenu.Controls.Add(this.btn_KetCa);
            this.panelMenu.Controls.Add(this.btn_KhachHang);
            this.panelMenu.Controls.Add(this.btn_NhanVien);
            this.panelMenu.Controls.Add(this.btn_HoaDon);
            this.panelMenu.Controls.Add(this.btn_sanpham);
            this.panelMenu.Controls.Add(this.btn_shopping);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(228, 773);
            this.panelMenu.TabIndex = 0;
            // 
            // btn_LogOut
            // 
            this.btn_LogOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_LogOut.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_LogOut.FlatAppearance.BorderSize = 0;
            this.btn_LogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LogOut.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_LogOut.ForeColor = System.Drawing.Color.White;
            this.btn_LogOut.Image = ((System.Drawing.Image)(resources.GetObject("btn_LogOut.Image")));
            this.btn_LogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LogOut.Location = new System.Drawing.Point(0, 794);
            this.btn_LogOut.Name = "btn_LogOut";
            this.btn_LogOut.Size = new System.Drawing.Size(228, 70);
            this.btn_LogOut.TabIndex = 11;
            this.btn_LogOut.Text = "Thoát";
            this.btn_LogOut.UseVisualStyleBackColor = true;
            this.btn_LogOut.Click += new System.EventHandler(this.btn_LogOut_Click);
            // 
            // btn_NhanCa
            // 
            this.btn_NhanCa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_NhanCa.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_NhanCa.FlatAppearance.BorderSize = 0;
            this.btn_NhanCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NhanCa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_NhanCa.ForeColor = System.Drawing.Color.White;
            this.btn_NhanCa.Image = ((System.Drawing.Image)(resources.GetObject("btn_NhanCa.Image")));
            this.btn_NhanCa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_NhanCa.Location = new System.Drawing.Point(0, 724);
            this.btn_NhanCa.Name = "btn_NhanCa";
            this.btn_NhanCa.Size = new System.Drawing.Size(228, 70);
            this.btn_NhanCa.TabIndex = 12;
            this.btn_NhanCa.Text = "Nhận Ca";
            this.btn_NhanCa.UseVisualStyleBackColor = true;
            this.btn_NhanCa.Click += new System.EventHandler(this.btn_NhanCa_Click);
            // 
            // btn_RutTien
            // 
            this.btn_RutTien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_RutTien.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_RutTien.FlatAppearance.BorderSize = 0;
            this.btn_RutTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RutTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_RutTien.ForeColor = System.Drawing.Color.White;
            this.btn_RutTien.Image = ((System.Drawing.Image)(resources.GetObject("btn_RutTien.Image")));
            this.btn_RutTien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_RutTien.Location = new System.Drawing.Point(0, 654);
            this.btn_RutTien.Name = "btn_RutTien";
            this.btn_RutTien.Size = new System.Drawing.Size(228, 70);
            this.btn_RutTien.TabIndex = 13;
            this.btn_RutTien.Text = "Rút tiền";
            this.btn_RutTien.UseVisualStyleBackColor = true;
            this.btn_RutTien.Click += new System.EventHandler(this.btn_RutTien_Click);
            // 
            // btn_KetCa
            // 
            this.btn_KetCa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_KetCa.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_KetCa.FlatAppearance.BorderSize = 0;
            this.btn_KetCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_KetCa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_KetCa.ForeColor = System.Drawing.Color.White;
            this.btn_KetCa.Image = ((System.Drawing.Image)(resources.GetObject("btn_KetCa.Image")));
            this.btn_KetCa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_KetCa.Location = new System.Drawing.Point(0, 584);
            this.btn_KetCa.Name = "btn_KetCa";
            this.btn_KetCa.Size = new System.Drawing.Size(228, 70);
            this.btn_KetCa.TabIndex = 12;
            this.btn_KetCa.Text = "Kết Ca";
            this.btn_KetCa.UseVisualStyleBackColor = true;
            this.btn_KetCa.Click += new System.EventHandler(this.btn_KetCa_Click);
            // 
            // btn_KhachHang
            // 
            this.btn_KhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_KhachHang.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_KhachHang.FlatAppearance.BorderSize = 0;
            this.btn_KhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_KhachHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_KhachHang.ForeColor = System.Drawing.Color.White;
            this.btn_KhachHang.Image = ((System.Drawing.Image)(resources.GetObject("btn_KhachHang.Image")));
            this.btn_KhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_KhachHang.Location = new System.Drawing.Point(0, 514);
            this.btn_KhachHang.Name = "btn_KhachHang";
            this.btn_KhachHang.Size = new System.Drawing.Size(228, 70);
            this.btn_KhachHang.TabIndex = 7;
            this.btn_KhachHang.Text = "Khách Hàng";
            this.btn_KhachHang.UseVisualStyleBackColor = true;
            this.btn_KhachHang.Click += new System.EventHandler(this.btn_KhachHang_Click);
            // 
            // btn_NhanVien
            // 
            this.btn_NhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_NhanVien.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_NhanVien.FlatAppearance.BorderSize = 0;
            this.btn_NhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NhanVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_NhanVien.ForeColor = System.Drawing.Color.White;
            this.btn_NhanVien.Image = ((System.Drawing.Image)(resources.GetObject("btn_NhanVien.Image")));
            this.btn_NhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_NhanVien.Location = new System.Drawing.Point(0, 444);
            this.btn_NhanVien.Name = "btn_NhanVien";
            this.btn_NhanVien.Size = new System.Drawing.Size(228, 70);
            this.btn_NhanVien.TabIndex = 6;
            this.btn_NhanVien.Text = "Nhân Viên";
            this.btn_NhanVien.UseVisualStyleBackColor = true;
            this.btn_NhanVien.Click += new System.EventHandler(this.btn_NhanVien_Click);
            // 
            // btn_HoaDon
            // 
            this.btn_HoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_HoaDon.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_HoaDon.FlatAppearance.BorderSize = 0;
            this.btn_HoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_HoaDon.ForeColor = System.Drawing.Color.White;
            this.btn_HoaDon.Image = ((System.Drawing.Image)(resources.GetObject("btn_HoaDon.Image")));
            this.btn_HoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_HoaDon.Location = new System.Drawing.Point(0, 374);
            this.btn_HoaDon.Name = "btn_HoaDon";
            this.btn_HoaDon.Size = new System.Drawing.Size(228, 70);
            this.btn_HoaDon.TabIndex = 5;
            this.btn_HoaDon.Text = "Hoá đơn";
            this.btn_HoaDon.UseVisualStyleBackColor = true;
            this.btn_HoaDon.Click += new System.EventHandler(this.btn_HoaDon_Click);
            // 
            // btn_sanpham
            // 
            this.btn_sanpham.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_sanpham.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_sanpham.FlatAppearance.BorderSize = 0;
            this.btn_sanpham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sanpham.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_sanpham.ForeColor = System.Drawing.Color.White;
            this.btn_sanpham.Image = ((System.Drawing.Image)(resources.GetObject("btn_sanpham.Image")));
            this.btn_sanpham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sanpham.Location = new System.Drawing.Point(0, 304);
            this.btn_sanpham.Name = "btn_sanpham";
            this.btn_sanpham.Size = new System.Drawing.Size(228, 70);
            this.btn_sanpham.TabIndex = 3;
            this.btn_sanpham.Text = "Sản Phẩm";
            this.btn_sanpham.UseVisualStyleBackColor = true;
            this.btn_sanpham.Click += new System.EventHandler(this.btn_sanpham_Click);
            // 
            // btn_shopping
            // 
            this.btn_shopping.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_shopping.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_shopping.FlatAppearance.BorderSize = 0;
            this.btn_shopping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_shopping.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_shopping.ForeColor = System.Drawing.Color.White;
            this.btn_shopping.Image = ((System.Drawing.Image)(resources.GetObject("btn_shopping.Image")));
            this.btn_shopping.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_shopping.Location = new System.Drawing.Point(0, 234);
            this.btn_shopping.Name = "btn_shopping";
            this.btn_shopping.Size = new System.Drawing.Size(228, 70);
            this.btn_shopping.TabIndex = 1;
            this.btn_shopping.Text = "Bán Hàng";
            this.btn_shopping.UseVisualStyleBackColor = true;
            this.btn_shopping.Click += new System.EventHandler(this.btn_shopping_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_Dasboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1386, 773);
            this.Controls.Add(this.PanelDesktopPanel);
            this.Controls.Add(this.PanelTitel);
            this.Controls.Add(this.panelMenu);
            this.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.Name = "Form_Dasboard";
            this.Text = "Form_Dasboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Dasboard_Load);
            this.PanelTitel.ResumeLayout(false);
            this.PanelTitel.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelTitel;
        private System.Windows.Forms.Label labelTite;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.Panel PanelDesktopPanel;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btn_sanpham;
        private System.Windows.Forms.Button btn_shopping;
        private System.Windows.Forms.Button btn_KhachHang;
        private System.Windows.Forms.Button btn_NhanVien;
        private System.Windows.Forms.Button btn_HoaDon;
        private System.Windows.Forms.Button btn_LogOut;
        private System.Windows.Forms.Label lb_XinChao;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_date;
        private System.Windows.Forms.Label lb_time;
        private System.Windows.Forms.Button btn_NhanCa;
        private System.Windows.Forms.Label lb_TongTien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_RutTien;
        private System.Windows.Forms.Button btn_KetCa;
        private System.Windows.Forms.Button btn_LamMoi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lb_chucvu;
    }
}