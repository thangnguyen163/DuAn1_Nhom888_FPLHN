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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Dasboard));
            this.PanelTitel = new System.Windows.Forms.Panel();
            this.lb_XinChao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTite = new System.Windows.Forms.Label();
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.PanelDesktopPanel = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btn_LogOut = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btn_ThongKe = new System.Windows.Forms.Button();
            this.btn_KhuyenMai = new System.Windows.Forms.Button();
            this.btn_KhachHang = new System.Windows.Forms.Button();
            this.btn_NhanVien = new System.Windows.Forms.Button();
            this.btn_HoaDon = new System.Windows.Forms.Button();
            this.btn_sanpham = new System.Windows.Forms.Button();
            this.btn_shopping = new System.Windows.Forms.Button();
            this.PanelTitel.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTitel
            // 
            this.PanelTitel.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.PanelTitel.Controls.Add(this.lb_XinChao);
            this.PanelTitel.Controls.Add(this.label1);
            this.PanelTitel.Controls.Add(this.labelTite);
            this.PanelTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitel.Location = new System.Drawing.Point(228, 0);
            this.PanelTitel.Name = "PanelTitel";
            this.PanelTitel.Size = new System.Drawing.Size(1158, 100);
            this.PanelTitel.TabIndex = 1;
            // 
            // lb_XinChao
            // 
            this.lb_XinChao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_XinChao.AutoSize = true;
            this.lb_XinChao.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_XinChao.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_XinChao.Location = new System.Drawing.Point(951, 64);
            this.lb_XinChao.Name = "lb_XinChao";
            this.lb_XinChao.Size = new System.Drawing.Size(0, 20);
            this.lb_XinChao.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(879, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Xin chào : ";
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
            this.PanelDesktopPanel.Location = new System.Drawing.Point(228, 100);
            this.PanelDesktopPanel.Name = "PanelDesktopPanel";
            this.PanelDesktopPanel.Size = new System.Drawing.Size(1158, 673);
            this.PanelDesktopPanel.TabIndex = 2;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(228, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btn_LogOut);
            this.panelMenu.Controls.Add(this.button6);
            this.panelMenu.Controls.Add(this.btn_ThongKe);
            this.panelMenu.Controls.Add(this.btn_KhuyenMai);
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
            this.btn_LogOut.Location = new System.Drawing.Point(0, 660);
            this.btn_LogOut.Name = "btn_LogOut";
            this.btn_LogOut.Size = new System.Drawing.Size(228, 70);
            this.btn_LogOut.TabIndex = 11;
            this.btn_LogOut.Text = "Thoát";
            this.btn_LogOut.UseVisualStyleBackColor = true;
            this.btn_LogOut.Click += new System.EventHandler(this.btn_LogOut_Click);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(0, 590);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(228, 70);
            this.button6.TabIndex = 10;
            this.button6.Text = "Sản Phẩm";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btn_ThongKe
            // 
            this.btn_ThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_ThongKe.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_ThongKe.FlatAppearance.BorderSize = 0;
            this.btn_ThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ThongKe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_ThongKe.ForeColor = System.Drawing.Color.White;
            this.btn_ThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btn_ThongKe.Image")));
            this.btn_ThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ThongKe.Location = new System.Drawing.Point(0, 520);
            this.btn_ThongKe.Name = "btn_ThongKe";
            this.btn_ThongKe.Size = new System.Drawing.Size(228, 70);
            this.btn_ThongKe.TabIndex = 9;
            this.btn_ThongKe.Text = "Thống Kê";
            this.btn_ThongKe.UseVisualStyleBackColor = true;
            // 
            // btn_KhuyenMai
            // 
            this.btn_KhuyenMai.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_KhuyenMai.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_KhuyenMai.FlatAppearance.BorderSize = 0;
            this.btn_KhuyenMai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_KhuyenMai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_KhuyenMai.ForeColor = System.Drawing.Color.White;
            this.btn_KhuyenMai.Image = ((System.Drawing.Image)(resources.GetObject("btn_KhuyenMai.Image")));
            this.btn_KhuyenMai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_KhuyenMai.Location = new System.Drawing.Point(0, 450);
            this.btn_KhuyenMai.Name = "btn_KhuyenMai";
            this.btn_KhuyenMai.Size = new System.Drawing.Size(228, 70);
            this.btn_KhuyenMai.TabIndex = 8;
            this.btn_KhuyenMai.Text = "Khuyến Mãi";
            this.btn_KhuyenMai.UseVisualStyleBackColor = true;
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
            this.btn_KhachHang.Location = new System.Drawing.Point(0, 380);
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
            this.btn_NhanVien.Location = new System.Drawing.Point(0, 310);
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
            this.btn_HoaDon.Location = new System.Drawing.Point(0, 240);
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
            this.btn_sanpham.Location = new System.Drawing.Point(0, 170);
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
            this.btn_shopping.Location = new System.Drawing.Point(0, 100);
            this.btn_shopping.Name = "btn_shopping";
            this.btn_shopping.Size = new System.Drawing.Size(228, 70);
            this.btn_shopping.TabIndex = 1;
            this.btn_shopping.Text = "Bán Hàng";
            this.btn_shopping.UseVisualStyleBackColor = true;
            this.btn_shopping.Click += new System.EventHandler(this.btn_shopping_Click);
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
            this.PanelTitel.ResumeLayout(false);
            this.PanelTitel.PerformLayout();
            this.panelLogo.ResumeLayout(false);
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
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btn_ThongKe;
        private System.Windows.Forms.Button btn_KhuyenMai;
        private System.Windows.Forms.Button btn_KhachHang;
        private System.Windows.Forms.Button btn_NhanVien;
        private System.Windows.Forms.Button btn_HoaDon;
        private System.Windows.Forms.Button btn_LogOut;
        private System.Windows.Forms.Label lb_XinChao;
        private System.Windows.Forms.Label label1;
    }
}