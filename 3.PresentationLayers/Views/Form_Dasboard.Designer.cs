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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.logout = new System.Windows.Forms.Button();
            this.btn_manage = new System.Windows.Forms.Button();
            this.btn_ThongKe = new System.Windows.Forms.Button();
            this.btn_shopping = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtg_hdct = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtg_hoadon = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb_tongtien = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.bt_taohoadon = new System.Windows.Forms.Button();
            this.btn_thanhtoan = new System.Windows.Forms.Button();
            this.tb_tientralai = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_tienkhachdua = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_temnv = new System.Windows.Forms.TextBox();
            this.tb_manv = new System.Windows.Forms.TextBox();
            this.tb_tenkh = new System.Windows.Forms.TextBox();
            this.tb_makh = new System.Windows.Forms.TextBox();
            this.tb_mahd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtg_sanpham = new System.Windows.Forms.DataGridView();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_hdct)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_hoadon)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_sanpham)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.logout);
            this.panelMenu.Controls.Add(this.btn_manage);
            this.panelMenu.Controls.Add(this.btn_ThongKe);
            this.panelMenu.Controls.Add(this.btn_shopping);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(228, 1055);
            this.panelMenu.TabIndex = 0;
            // 
            // logout
            // 
            this.logout.Dock = System.Windows.Forms.DockStyle.Top;
            this.logout.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logout.ForeColor = System.Drawing.Color.White;
            this.logout.Image = ((System.Drawing.Image)(resources.GetObject("logout.Image")));
            this.logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout.Location = new System.Drawing.Point(0, 250);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(228, 50);
            this.logout.TabIndex = 4;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // btn_manage
            // 
            this.btn_manage.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_manage.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_manage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_manage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_manage.ForeColor = System.Drawing.Color.White;
            this.btn_manage.Image = ((System.Drawing.Image)(resources.GetObject("btn_manage.Image")));
            this.btn_manage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_manage.Location = new System.Drawing.Point(0, 200);
            this.btn_manage.Name = "btn_manage";
            this.btn_manage.Size = new System.Drawing.Size(228, 50);
            this.btn_manage.TabIndex = 3;
            this.btn_manage.Text = "Manage";
            this.btn_manage.UseVisualStyleBackColor = true;
            this.btn_manage.Click += new System.EventHandler(this.btn_manage_Click);
            // 
            // btn_ThongKe
            // 
            this.btn_ThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_ThongKe.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_ThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ThongKe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_ThongKe.ForeColor = System.Drawing.Color.White;
            this.btn_ThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btn_ThongKe.Image")));
            this.btn_ThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ThongKe.Location = new System.Drawing.Point(0, 150);
            this.btn_ThongKe.Name = "btn_ThongKe";
            this.btn_ThongKe.Size = new System.Drawing.Size(228, 50);
            this.btn_ThongKe.TabIndex = 2;
            this.btn_ThongKe.Text = "Reporting";
            this.btn_ThongKe.UseVisualStyleBackColor = true;
            this.btn_ThongKe.Click += new System.EventHandler(this.btn_ThongKe_Click);
            // 
            // btn_shopping
            // 
            this.btn_shopping.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_shopping.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_shopping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_shopping.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_shopping.ForeColor = System.Drawing.Color.White;
            this.btn_shopping.Image = ((System.Drawing.Image)(resources.GetObject("btn_shopping.Image")));
            this.btn_shopping.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_shopping.Location = new System.Drawing.Point(0, 100);
            this.btn_shopping.Name = "btn_shopping";
            this.btn_shopping.Size = new System.Drawing.Size(228, 50);
            this.btn_shopping.TabIndex = 1;
            this.btn_shopping.Text = "Shopping";
            this.btn_shopping.UseVisualStyleBackColor = true;
            this.btn_shopping.Click += new System.EventHandler(this.btn_shopping_Click);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(228, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1319, 80);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(600, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "HOME";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtg_hdct);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.groupBox1.Location = new System.Drawing.Point(266, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 431);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hóa đơn chi tiết";
            // 
            // dtg_hdct
            // 
            this.dtg_hdct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_hdct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_hdct.Location = new System.Drawing.Point(3, 26);
            this.dtg_hdct.Name = "dtg_hdct";
            this.dtg_hdct.RowHeadersWidth = 51;
            this.dtg_hdct.RowTemplate.Height = 29;
            this.dtg_hdct.Size = new System.Drawing.Size(565, 402);
            this.dtg_hdct.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dtg_hoadon);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.groupBox2.Location = new System.Drawing.Point(888, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 439);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hóa đơn";
            // 
            // dtg_hoadon
            // 
            this.dtg_hoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_hoadon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_hoadon.Location = new System.Drawing.Point(3, 26);
            this.dtg_hoadon.Name = "dtg_hoadon";
            this.dtg_hoadon.RowHeadersWidth = 51;
            this.dtg_hoadon.RowTemplate.Height = 29;
            this.dtg_hoadon.Size = new System.Drawing.Size(244, 410);
            this.dtg_hoadon.TabIndex = 0;
            this.dtg_hoadon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_hoadon_CellClick_1);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel2.Controls.Add(this.tb_tongtien);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.bt_taohoadon);
            this.panel2.Controls.Add(this.btn_thanhtoan);
            this.panel2.Controls.Add(this.tb_tientralai);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tb_tienkhachdua);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.tb_temnv);
            this.panel2.Controls.Add(this.tb_manv);
            this.panel2.Controls.Add(this.tb_tenkh);
            this.panel2.Controls.Add(this.tb_makh);
            this.panel2.Controls.Add(this.tb_mahd);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.ForeColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(1160, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(387, 609);
            this.panel2.TabIndex = 4;
            // 
            // tb_tongtien
            // 
            this.tb_tongtien.Location = new System.Drawing.Point(127, 381);
            this.tb_tongtien.Name = "tb_tongtien";
            this.tb_tongtien.Size = new System.Drawing.Size(204, 27);
            this.tb_tongtien.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 384);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Tổng tiền";
            // 
            // bt_taohoadon
            // 
            this.bt_taohoadon.BackColor = System.Drawing.Color.Teal;
            this.bt_taohoadon.Location = new System.Drawing.Point(73, 24);
            this.bt_taohoadon.Name = "bt_taohoadon";
            this.bt_taohoadon.Size = new System.Drawing.Size(258, 54);
            this.bt_taohoadon.TabIndex = 15;
            this.bt_taohoadon.Text = "Tạo hóa đơn";
            this.bt_taohoadon.UseVisualStyleBackColor = false;
            this.bt_taohoadon.Click += new System.EventHandler(this.bt_taohoadon_Click_1);
            // 
            // btn_thanhtoan
            // 
            this.btn_thanhtoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_thanhtoan.Image = ((System.Drawing.Image)(resources.GetObject("btn_thanhtoan.Image")));
            this.btn_thanhtoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_thanhtoan.Location = new System.Drawing.Point(41, 520);
            this.btn_thanhtoan.Name = "btn_thanhtoan";
            this.btn_thanhtoan.Size = new System.Drawing.Size(208, 48);
            this.btn_thanhtoan.TabIndex = 14;
            this.btn_thanhtoan.Text = "Thanh toán";
            this.btn_thanhtoan.UseVisualStyleBackColor = true;
            this.btn_thanhtoan.Click += new System.EventHandler(this.btn_thanhtoan_Click);
            // 
            // tb_tientralai
            // 
            this.tb_tientralai.Location = new System.Drawing.Point(127, 472);
            this.tb_tientralai.Name = "tb_tientralai";
            this.tb_tientralai.Size = new System.Drawing.Size(204, 27);
            this.tb_tientralai.TabIndex = 13;
            this.tb_tientralai.TextChanged += new System.EventHandler(this.tb_tientralai_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 475);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Tiền trả lại";
            // 
            // tb_tienkhachdua
            // 
            this.tb_tienkhachdua.Location = new System.Drawing.Point(127, 425);
            this.tb_tienkhachdua.Name = "tb_tienkhachdua";
            this.tb_tienkhachdua.Size = new System.Drawing.Size(204, 27);
            this.tb_tienkhachdua.TabIndex = 11;
            this.tb_tienkhachdua.TextChanged += new System.EventHandler(this.tb_tienkhachdua_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 428);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Tiền khách đưa";
            // 
            // tb_temnv
            // 
            this.tb_temnv.Location = new System.Drawing.Point(127, 337);
            this.tb_temnv.Name = "tb_temnv";
            this.tb_temnv.Size = new System.Drawing.Size(204, 27);
            this.tb_temnv.TabIndex = 9;
            // 
            // tb_manv
            // 
            this.tb_manv.Location = new System.Drawing.Point(127, 285);
            this.tb_manv.Name = "tb_manv";
            this.tb_manv.Size = new System.Drawing.Size(204, 27);
            this.tb_manv.TabIndex = 8;
            // 
            // tb_tenkh
            // 
            this.tb_tenkh.Location = new System.Drawing.Point(127, 243);
            this.tb_tenkh.Name = "tb_tenkh";
            this.tb_tenkh.Size = new System.Drawing.Size(204, 27);
            this.tb_tenkh.TabIndex = 7;
            // 
            // tb_makh
            // 
            this.tb_makh.Location = new System.Drawing.Point(127, 193);
            this.tb_makh.Name = "tb_makh";
            this.tb_makh.Size = new System.Drawing.Size(204, 27);
            this.tb_makh.TabIndex = 6;
            // 
            // tb_mahd
            // 
            this.tb_mahd.Location = new System.Drawing.Point(127, 143);
            this.tb_mahd.Name = "tb_mahd";
            this.tb_mahd.Size = new System.Drawing.Size(204, 27);
            this.tb_mahd.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tên nhân viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mã nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mã khách hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã hóa đơn";
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandTimeout = 30;
            this.sqlCommand1.Connection = null;
            this.sqlCommand1.Notification = null;
            this.sqlCommand1.Transaction = null;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dtg_sanpham);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.MenuText;
            this.groupBox3.Location = new System.Drawing.Point(266, 574);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(872, 250);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sản phẩm";
            // 
            // dtg_sanpham
            // 
            this.dtg_sanpham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtg_sanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_sanpham.Location = new System.Drawing.Point(3, 26);
            this.dtg_sanpham.Name = "dtg_sanpham";
            this.dtg_sanpham.RowHeadersWidth = 51;
            this.dtg_sanpham.RowTemplate.Height = 29;
            this.dtg_sanpham.Size = new System.Drawing.Size(866, 221);
            this.dtg_sanpham.TabIndex = 0;
            this.dtg_sanpham.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_sanpham_CellDoubleClick_1);
            // 
            // Form_Dasboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1547, 1055);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenu);
            this.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.Name = "Form_Dasboard";
            this.Text = "Form_Dasboard";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_hdct)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_hoadon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_sanpham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button btn_manage;
        private System.Windows.Forms.Button btn_ThongKe;
        private System.Windows.Forms.Button btn_shopping;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_tientralai;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_tienkhachdua;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_temnv;
        private System.Windows.Forms.TextBox tb_manv;
        private System.Windows.Forms.TextBox tb_tenkh;
        private System.Windows.Forms.TextBox tb_makh;
        private System.Windows.Forms.TextBox tb_mahd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_thanhtoan;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtg_hdct;
        private System.Windows.Forms.DataGridView dtg_hoadon;
        private System.Windows.Forms.DataGridView dtg_sanpham;
        private System.Windows.Forms.Button bt_taohoadon;
        private System.Windows.Forms.TextBox tb_tongtien;
        private System.Windows.Forms.Label label9;
    }
}