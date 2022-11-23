﻿namespace _3.PresentationLayers.Views
{
    partial class Form_BanHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BanHang));
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lb_HoaDonChiTiet = new System.Windows.Forms.Label();
            this.dtg_HoaDonChiTiet = new System.Windows.Forms.DataGridView();
            this.IDHDct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.masp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tensp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tru = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cong = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Dongia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thanhtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Xoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lb_SanPham = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dtg_SanPham = new System.Windows.Forms.DataGridView();
            this.btn_taohoadon = new System.Windows.Forms.Button();
            this.tabHoaDon = new System.Windows.Forms.TabControl();
            this.rd_dahuy = new System.Windows.Forms.RadioButton();
            this.rd_chothanhtoan = new System.Windows.Forms.RadioButton();
            this.rd_dathanhtoan = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_tientralai = new System.Windows.Forms.TextBox();
            this.tb_tienkhachdua = new System.Windows.Forms.TextBox();
            this.tb_tongtien = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fl_ChuaThanhToan = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fl_DaThanhToan = new System.Windows.Forms.FlowLayoutPanel();
            this.cbb_nhanvien = new System.Windows.Forms.ComboBox();
            this.cbb_nganhang = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lbdtghdct = new System.Windows.Forms.Label();
            this.lb_TienCoc = new System.Windows.Forms.Label();
            this.lb_TienShip = new System.Windows.Forms.Label();
            this.tbx_TienCoc = new System.Windows.Forms.TextBox();
            this.tbx_TienShip = new System.Windows.Forms.TextBox();
            this.btn_DatHang = new System.Windows.Forms.Button();
            this.btn_TaiQuay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_HoaDonChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_SanPham)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(1252, 483);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(127, 50);
            this.button5.TabIndex = 23;
            this.button5.Text = "Hủy ";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(1087, 483);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 50);
            this.button4.TabIndex = 22;
            this.button4.Text = "Thanh Toán";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // lb_HoaDonChiTiet
            // 
            this.lb_HoaDonChiTiet.AutoSize = true;
            this.lb_HoaDonChiTiet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_HoaDonChiTiet.Location = new System.Drawing.Point(47, 15);
            this.lb_HoaDonChiTiet.Name = "lb_HoaDonChiTiet";
            this.lb_HoaDonChiTiet.Size = new System.Drawing.Size(144, 23);
            this.lb_HoaDonChiTiet.TabIndex = 41;
            this.lb_HoaDonChiTiet.Text = "Hóa đơn chi tiết";
            // 
            // dtg_HoaDonChiTiet
            // 
            this.dtg_HoaDonChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_HoaDonChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDHDct,
            this.masp,
            this.Tensp,
            this.tru,
            this.Soluong,
            this.Cong,
            this.Dongia,
            this.Thanhtien,
            this.Xoa});
            this.dtg_HoaDonChiTiet.Location = new System.Drawing.Point(21, 53);
            this.dtg_HoaDonChiTiet.Name = "dtg_HoaDonChiTiet";
            this.dtg_HoaDonChiTiet.RowHeadersWidth = 51;
            this.dtg_HoaDonChiTiet.RowTemplate.Height = 29;
            this.dtg_HoaDonChiTiet.Size = new System.Drawing.Size(649, 441);
            this.dtg_HoaDonChiTiet.TabIndex = 40;
            this.dtg_HoaDonChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_HoaDonChiTiet_CellClick);
            // 
            // IDHDct
            // 
            this.IDHDct.HeaderText = "Idhdct";
            this.IDHDct.MinimumWidth = 6;
            this.IDHDct.Name = "IDHDct";
            this.IDHDct.Visible = false;
            this.IDHDct.Width = 125;
            // 
            // masp
            // 
            this.masp.HeaderText = "Mã sản phẩm";
            this.masp.MinimumWidth = 6;
            this.masp.Name = "masp";
            this.masp.Width = 125;
            // 
            // Tensp
            // 
            this.Tensp.HeaderText = "Tên sản phẩm";
            this.Tensp.MinimumWidth = 6;
            this.Tensp.Name = "Tensp";
            this.Tensp.Width = 125;
            // 
            // tru
            // 
            this.tru.HeaderText = "Trừ";
            this.tru.MinimumWidth = 6;
            this.tru.Name = "tru";
            this.tru.Width = 125;
            // 
            // Soluong
            // 
            this.Soluong.HeaderText = "Số lượng";
            this.Soluong.MinimumWidth = 6;
            this.Soluong.Name = "Soluong";
            this.Soluong.Width = 125;
            // 
            // Cong
            // 
            this.Cong.HeaderText = "Cộng";
            this.Cong.MinimumWidth = 6;
            this.Cong.Name = "Cong";
            this.Cong.Width = 125;
            // 
            // Dongia
            // 
            this.Dongia.HeaderText = "Đơn giá";
            this.Dongia.MinimumWidth = 6;
            this.Dongia.Name = "Dongia";
            this.Dongia.Width = 125;
            // 
            // Thanhtien
            // 
            this.Thanhtien.HeaderText = "Thành tiền";
            this.Thanhtien.MinimumWidth = 6;
            this.Thanhtien.Name = "Thanhtien";
            this.Thanhtien.Width = 125;
            // 
            // Xoa
            // 
            this.Xoa.HeaderText = "X";
            this.Xoa.MinimumWidth = 6;
            this.Xoa.Name = "Xoa";
            this.Xoa.Width = 125;
            // 
            // lb_SanPham
            // 
            this.lb_SanPham.AutoSize = true;
            this.lb_SanPham.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_SanPham.Location = new System.Drawing.Point(47, 525);
            this.lb_SanPham.Name = "lb_SanPham";
            this.lb_SanPham.Size = new System.Drawing.Size(91, 23);
            this.lb_SanPham.TabIndex = 44;
            this.lb_SanPham.Text = "Sản phẩm";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 525);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 27);
            this.textBox1.TabIndex = 43;
            this.textBox1.Text = "Tìm kiếm sản phẩm";
            // 
            // dtg_SanPham
            // 
            this.dtg_SanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_SanPham.Location = new System.Drawing.Point(21, 554);
            this.dtg_SanPham.Name = "dtg_SanPham";
            this.dtg_SanPham.RowHeadersWidth = 51;
            this.dtg_SanPham.RowTemplate.Height = 29;
            this.dtg_SanPham.Size = new System.Drawing.Size(649, 397);
            this.dtg_SanPham.TabIndex = 42;
            this.dtg_SanPham.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_SanPham_CellDoubleClick);
            // 
            // btn_taohoadon
            // 
            this.btn_taohoadon.FlatAppearance.BorderSize = 0;
            this.btn_taohoadon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_taohoadon.Image = ((System.Drawing.Image)(resources.GetObject("btn_taohoadon.Image")));
            this.btn_taohoadon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_taohoadon.Location = new System.Drawing.Point(629, 2);
            this.btn_taohoadon.Name = "btn_taohoadon";
            this.btn_taohoadon.Size = new System.Drawing.Size(41, 45);
            this.btn_taohoadon.TabIndex = 46;
            this.btn_taohoadon.Tag = "";
            this.btn_taohoadon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_taohoadon.UseVisualStyleBackColor = true;
            this.btn_taohoadon.Click += new System.EventHandler(this.btn_taohoadon_Click);
            // 
            // tabHoaDon
            // 
            this.tabHoaDon.Location = new System.Drawing.Point(674, 12);
            this.tabHoaDon.Name = "tabHoaDon";
            this.tabHoaDon.SelectedIndex = 0;
            this.tabHoaDon.Size = new System.Drawing.Size(255, 24);
            this.tabHoaDon.TabIndex = 47;
            this.tabHoaDon.SelectedIndexChanged += new System.EventHandler(this.tabHoaDon_SelectedIndexChanged);
            this.tabHoaDon.TabIndexChanged += new System.EventHandler(this.tabHoaDon_TabIndexChanged);
            this.tabHoaDon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabHoaDon_MouseClick);
            // 
            // rd_dahuy
            // 
            this.rd_dahuy.AutoSize = true;
            this.rd_dahuy.Location = new System.Drawing.Point(1438, 90);
            this.rd_dahuy.Name = "rd_dahuy";
            this.rd_dahuy.Size = new System.Drawing.Size(79, 24);
            this.rd_dahuy.TabIndex = 71;
            this.rd_dahuy.TabStop = true;
            this.rd_dahuy.Text = "Đã hủy";
            this.rd_dahuy.UseVisualStyleBackColor = true;
            // 
            // rd_chothanhtoan
            // 
            this.rd_chothanhtoan.AutoSize = true;
            this.rd_chothanhtoan.Location = new System.Drawing.Point(1283, 88);
            this.rd_chothanhtoan.Name = "rd_chothanhtoan";
            this.rd_chothanhtoan.Size = new System.Drawing.Size(138, 24);
            this.rd_chothanhtoan.TabIndex = 70;
            this.rd_chothanhtoan.TabStop = true;
            this.rd_chothanhtoan.Text = "Chờ thanh toán";
            this.rd_chothanhtoan.UseVisualStyleBackColor = true;
            // 
            // rd_dathanhtoan
            // 
            this.rd_dathanhtoan.AutoSize = true;
            this.rd_dathanhtoan.Location = new System.Drawing.Point(1137, 88);
            this.rd_dathanhtoan.Name = "rd_dathanhtoan";
            this.rd_dathanhtoan.Size = new System.Drawing.Size(130, 24);
            this.rd_dathanhtoan.TabIndex = 69;
            this.rd_dathanhtoan.TabStop = true;
            this.rd_dathanhtoan.Text = "Đã thanh toán";
            this.rd_dathanhtoan.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1045, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 68;
            this.label8.Text = "Trạng thái";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1054, 343);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 67;
            this.label6.Text = "Tiền trả lại";
            // 
            // tb_tientralai
            // 
            this.tb_tientralai.Location = new System.Drawing.Point(1170, 340);
            this.tb_tientralai.Name = "tb_tientralai";
            this.tb_tientralai.Size = new System.Drawing.Size(249, 27);
            this.tb_tientralai.TabIndex = 66;
            // 
            // tb_tienkhachdua
            // 
            this.tb_tienkhachdua.Location = new System.Drawing.Point(1170, 295);
            this.tb_tienkhachdua.Name = "tb_tienkhachdua";
            this.tb_tienkhachdua.Size = new System.Drawing.Size(249, 27);
            this.tb_tienkhachdua.TabIndex = 64;
            // 
            // tb_tongtien
            // 
            this.tb_tongtien.Location = new System.Drawing.Point(1170, 252);
            this.tb_tongtien.Name = "tb_tongtien";
            this.tb_tongtien.Size = new System.Drawing.Size(249, 27);
            this.tb_tongtien.TabIndex = 62;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1040, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 20);
            this.label7.TabIndex = 65;
            this.label7.Text = "Tiền khách đưa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1046, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "Nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1049, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 63;
            this.label4.Text = "Tổng tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1046, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 59;
            this.label3.Text = "Khách hàng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1052, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 61;
            this.label5.Text = "Ngày tạo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fl_ChuaThanhToan);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(702, 554);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 400);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hóa đơn chưa thanh toán";
            // 
            // fl_ChuaThanhToan
            // 
            this.fl_ChuaThanhToan.AutoScroll = true;
            this.fl_ChuaThanhToan.BackColor = System.Drawing.SystemColors.Info;
            this.fl_ChuaThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fl_ChuaThanhToan.Location = new System.Drawing.Point(3, 21);
            this.fl_ChuaThanhToan.Name = "fl_ChuaThanhToan";
            this.fl_ChuaThanhToan.Size = new System.Drawing.Size(194, 376);
            this.fl_ChuaThanhToan.TabIndex = 74;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fl_DaThanhToan);
            this.groupBox2.Location = new System.Drawing.Point(908, 554);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 400);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hóa đơn đã thanh toán";
            // 
            // fl_DaThanhToan
            // 
            this.fl_DaThanhToan.AutoScroll = true;
            this.fl_DaThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.fl_DaThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fl_DaThanhToan.Location = new System.Drawing.Point(3, 23);
            this.fl_DaThanhToan.Name = "fl_DaThanhToan";
            this.fl_DaThanhToan.Size = new System.Drawing.Size(194, 374);
            this.fl_DaThanhToan.TabIndex = 73;
            // 
            // cbb_nhanvien
            // 
            this.cbb_nhanvien.FormattingEnabled = true;
            this.cbb_nhanvien.Location = new System.Drawing.Point(1170, 118);
            this.cbb_nhanvien.Name = "cbb_nhanvien";
            this.cbb_nhanvien.Size = new System.Drawing.Size(251, 28);
            this.cbb_nhanvien.TabIndex = 78;
            // 
            // cbb_nganhang
            // 
            this.cbb_nganhang.FormattingEnabled = true;
            this.cbb_nganhang.Location = new System.Drawing.Point(1170, 166);
            this.cbb_nganhang.Name = "cbb_nganhang";
            this.cbb_nganhang.Size = new System.Drawing.Size(251, 28);
            this.cbb_nganhang.TabIndex = 79;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(1169, 209);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(250, 27);
            this.dateTimePicker1.TabIndex = 80;
            // 
            // lbdtghdct
            // 
            this.lbdtghdct.AutoSize = true;
            this.lbdtghdct.Location = new System.Drawing.Point(263, 279);
            this.lbdtghdct.Name = "lbdtghdct";
            this.lbdtghdct.Size = new System.Drawing.Size(0, 20);
            this.lbdtghdct.TabIndex = 81;
            // 
            // lb_TienCoc
            // 
            this.lb_TienCoc.AutoSize = true;
            this.lb_TienCoc.Location = new System.Drawing.Point(1069, 383);
            this.lb_TienCoc.Name = "lb_TienCoc";
            this.lb_TienCoc.Size = new System.Drawing.Size(66, 20);
            this.lb_TienCoc.TabIndex = 82;
            this.lb_TienCoc.Text = "Tiền cọc";
            // 
            // lb_TienShip
            // 
            this.lb_TienShip.AutoSize = true;
            this.lb_TienShip.Location = new System.Drawing.Point(1069, 425);
            this.lb_TienShip.Name = "lb_TienShip";
            this.lb_TienShip.Size = new System.Drawing.Size(72, 20);
            this.lb_TienShip.TabIndex = 83;
            this.lb_TienShip.Text = "Tiền ship";
            // 
            // tbx_TienCoc
            // 
            this.tbx_TienCoc.Location = new System.Drawing.Point(1170, 380);
            this.tbx_TienCoc.Name = "tbx_TienCoc";
            this.tbx_TienCoc.Size = new System.Drawing.Size(251, 27);
            this.tbx_TienCoc.TabIndex = 84;
            // 
            // tbx_TienShip
            // 
            this.tbx_TienShip.Location = new System.Drawing.Point(1169, 422);
            this.tbx_TienShip.Name = "tbx_TienShip";
            this.tbx_TienShip.Size = new System.Drawing.Size(252, 27);
            this.tbx_TienShip.TabIndex = 85;
            // 
            // btn_DatHang
            // 
            this.btn_DatHang.Location = new System.Drawing.Point(1159, 20);
            this.btn_DatHang.Name = "btn_DatHang";
            this.btn_DatHang.Size = new System.Drawing.Size(122, 51);
            this.btn_DatHang.TabIndex = 86;
            this.btn_DatHang.Text = "Đặt Hàng";
            this.btn_DatHang.UseVisualStyleBackColor = true;
            this.btn_DatHang.Click += new System.EventHandler(this.btn_DatHang_Click);
            // 
            // btn_TaiQuay
            // 
            this.btn_TaiQuay.Location = new System.Drawing.Point(1323, 20);
            this.btn_TaiQuay.Name = "btn_TaiQuay";
            this.btn_TaiQuay.Size = new System.Drawing.Size(113, 51);
            this.btn_TaiQuay.TabIndex = 87;
            this.btn_TaiQuay.Text = "Tại Quầy";
            this.btn_TaiQuay.UseVisualStyleBackColor = true;
            this.btn_TaiQuay.Click += new System.EventHandler(this.btn_TaiQuay_Click);
            // 
            // Form_BanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1679, 1055);
            this.Controls.Add(this.btn_TaiQuay);
            this.Controls.Add(this.btn_DatHang);
            this.Controls.Add(this.tbx_TienShip);
            this.Controls.Add(this.tbx_TienCoc);
            this.Controls.Add(this.lb_TienShip);
            this.Controls.Add(this.lb_TienCoc);
            this.Controls.Add(this.lbdtghdct);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cbb_nganhang);
            this.Controls.Add(this.cbb_nhanvien);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rd_dahuy);
            this.Controls.Add(this.rd_chothanhtoan);
            this.Controls.Add(this.rd_dathanhtoan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_tientralai);
            this.Controls.Add(this.tb_tienkhachdua);
            this.Controls.Add(this.tb_tongtien);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabHoaDon);
            this.Controls.Add(this.btn_taohoadon);
            this.Controls.Add(this.lb_SanPham);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dtg_SanPham);
            this.Controls.Add(this.lb_HoaDonChiTiet);
            this.Controls.Add(this.dtg_HoaDonChiTiet);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form_BanHang";
            this.Load += new System.EventHandler(this.Form_BanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_HoaDonChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_SanPham)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lb_HoaDonChiTiet;
        private System.Windows.Forms.DataGridView dtg_HoaDonChiTiet;
        private System.Windows.Forms.Label lb_SanPham;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dtg_SanPham;
        private System.Windows.Forms.Button btn_taohoadon;
        private System.Windows.Forms.TabControl tabHoaDon;
        private System.Windows.Forms.RadioButton rd_dahuy;
        private System.Windows.Forms.RadioButton rd_chothanhtoan;
        private System.Windows.Forms.RadioButton rd_dathanhtoan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_tientralai;
        private System.Windows.Forms.TextBox tb_tienkhachdua;
        private System.Windows.Forms.TextBox tb_tongtien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel fl_ChuaThanhToan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel fl_DaThanhToan;
        private System.Windows.Forms.ComboBox cbb_nhanvien;
        private System.Windows.Forms.ComboBox cbb_nganhang;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDHDct;
        private System.Windows.Forms.DataGridViewTextBoxColumn masp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tensp;
        private System.Windows.Forms.DataGridViewButtonColumn tru;
        private System.Windows.Forms.DataGridViewTextBoxColumn Soluong;
        private System.Windows.Forms.DataGridViewButtonColumn Cong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dongia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thanhtien;
        private System.Windows.Forms.DataGridViewButtonColumn Xoa;
        private System.Windows.Forms.Label lbdtghdct;
        private System.Windows.Forms.Label lb_TienCoc;
        private System.Windows.Forms.Label lb_TienShip;
        private System.Windows.Forms.TextBox tbx_TienCoc;
        private System.Windows.Forms.TextBox tbx_TienShip;
        private System.Windows.Forms.Button btn_DatHang;
        private System.Windows.Forms.Button btn_TaiQuay;
    }
}