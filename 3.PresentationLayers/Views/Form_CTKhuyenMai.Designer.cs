namespace _3.PresentationLayers.Views
{
    partial class Form_CTKhuyenMai
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
            this.tbx_mota = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_ten = new System.Windows.Forms.TextBox();
            this.tbx_ma = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_show = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.dtg_show = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.lable6 = new System.Windows.Forms.Label();
            this.cbx_Sach = new System.Windows.Forms.ComboBox();
            this.cbx_KhuyenMai = new System.Windows.Forms.ComboBox();
            this.rdo_HoatDong = new System.Windows.Forms.RadioButton();
            this.rdo_HetHan = new System.Windows.Forms.RadioButton();
            this.tb_timkiem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_show)).BeginInit();
            this.SuspendLayout();
            // 
            // tbx_mota
            // 
            this.tbx_mota.Location = new System.Drawing.Point(675, 246);
            this.tbx_mota.Name = "tbx_mota";
            this.tbx_mota.Size = new System.Drawing.Size(181, 27);
            this.tbx_mota.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(552, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Mô tả";
            // 
            // tbx_ten
            // 
            this.tbx_ten.Location = new System.Drawing.Point(675, 193);
            this.tbx_ten.Name = "tbx_ten";
            this.tbx_ten.Size = new System.Drawing.Size(181, 27);
            this.tbx_ten.TabIndex = 33;
            // 
            // tbx_ma
            // 
            this.tbx_ma.Location = new System.Drawing.Point(675, 150);
            this.tbx_ma.Name = "tbx_ma";
            this.tbx_ma.Size = new System.Drawing.Size(181, 27);
            this.tbx_ma.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(552, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Trạng thái";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(552, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Mã";
            // 
            // btn_show
            // 
            this.btn_show.Location = new System.Drawing.Point(930, 257);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(94, 29);
            this.btn_show.TabIndex = 28;
            this.btn_show.Text = "Hiển thị";
            this.btn_show.UseVisualStyleBackColor = true;
            this.btn_show.Click += new System.EventHandler(this.btn_show_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(930, 186);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(94, 29);
            this.btn_xoa.TabIndex = 27;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(930, 122);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(94, 29);
            this.btn_sua.TabIndex = 26;
            this.btn_sua.Text = "Sửa ";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(930, 61);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(94, 29);
            this.btn_them.TabIndex = 25;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // dtg_show
            // 
            this.dtg_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_show.Location = new System.Drawing.Point(3, 16);
            this.dtg_show.Name = "dtg_show";
            this.dtg_show.RowHeadersWidth = 51;
            this.dtg_show.RowTemplate.Height = 29;
            this.dtg_show.Size = new System.Drawing.Size(519, 474);
            this.dtg_show.TabIndex = 24;
            this.dtg_show.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_show_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(550, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "Khuyến mãi";
            // 
            // lable6
            // 
            this.lable6.AutoSize = true;
            this.lable6.Location = new System.Drawing.Point(552, 61);
            this.lable6.Name = "lable6";
            this.lable6.Size = new System.Drawing.Size(40, 20);
            this.lable6.TabIndex = 38;
            this.lable6.Text = "Sách";
            // 
            // cbx_Sach
            // 
            this.cbx_Sach.FormattingEnabled = true;
            this.cbx_Sach.Items.AddRange(new object[] {
            "Tồn tại",
            "Không tồn tại"});
            this.cbx_Sach.Location = new System.Drawing.Point(675, 53);
            this.cbx_Sach.Name = "cbx_Sach";
            this.cbx_Sach.Size = new System.Drawing.Size(151, 28);
            this.cbx_Sach.TabIndex = 39;
            // 
            // cbx_KhuyenMai
            // 
            this.cbx_KhuyenMai.FormattingEnabled = true;
            this.cbx_KhuyenMai.Items.AddRange(new object[] {
            "Tồn tại",
            "Không tồn tại"});
            this.cbx_KhuyenMai.Location = new System.Drawing.Point(675, 100);
            this.cbx_KhuyenMai.Name = "cbx_KhuyenMai";
            this.cbx_KhuyenMai.Size = new System.Drawing.Size(151, 28);
            this.cbx_KhuyenMai.TabIndex = 40;
            // 
            // rdo_HoatDong
            // 
            this.rdo_HoatDong.AutoSize = true;
            this.rdo_HoatDong.Location = new System.Drawing.Point(665, 291);
            this.rdo_HoatDong.Name = "rdo_HoatDong";
            this.rdo_HoatDong.Size = new System.Drawing.Size(116, 24);
            this.rdo_HoatDong.TabIndex = 41;
            this.rdo_HoatDong.TabStop = true;
            this.rdo_HoatDong.Text = "Đang diễn ra";
            this.rdo_HoatDong.UseVisualStyleBackColor = true;
            // 
            // rdo_HetHan
            // 
            this.rdo_HetHan.AutoSize = true;
            this.rdo_HetHan.Location = new System.Drawing.Point(802, 291);
            this.rdo_HetHan.Name = "rdo_HetHan";
            this.rdo_HetHan.Size = new System.Drawing.Size(84, 24);
            this.rdo_HetHan.TabIndex = 42;
            this.rdo_HetHan.TabStop = true;
            this.rdo_HetHan.Text = "Kết thúc";
            this.rdo_HetHan.UseVisualStyleBackColor = true;
            // 
            // tb_timkiem
            // 
            this.tb_timkiem.Location = new System.Drawing.Point(665, 376);
            this.tb_timkiem.Name = "tb_timkiem";
            this.tb_timkiem.Size = new System.Drawing.Size(181, 27);
            this.tb_timkiem.TabIndex = 44;
            this.tb_timkiem.TextChanged += new System.EventHandler(this.tb_timkiem_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(552, 383);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 43;
            this.label6.Text = "Tìm kiếm";
            // 
            // Form_CTKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 518);
            this.Controls.Add(this.tb_timkiem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rdo_HetHan);
            this.Controls.Add(this.rdo_HoatDong);
            this.Controls.Add(this.cbx_KhuyenMai);
            this.Controls.Add(this.cbx_Sach);
            this.Controls.Add(this.lable6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbx_mota);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbx_ten);
            this.Controls.Add(this.tbx_ma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_show);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.dtg_show);
            this.Name = "Form_CTKhuyenMai";
            this.Text = "Form_CTKhuyenMai";
            ((System.ComponentModel.ISupportInitialize)(this.dtg_show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_mota;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_ten;
        private System.Windows.Forms.TextBox tbx_ma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.DataGridView dtg_show;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lable6;
        private System.Windows.Forms.ComboBox cbx_Sach;
        private System.Windows.Forms.ComboBox cbx_KhuyenMai;
        private System.Windows.Forms.RadioButton rdo_HoatDong;
        private System.Windows.Forms.RadioButton rdo_HetHan;
        private System.Windows.Forms.TextBox tb_timkiem;
        private System.Windows.Forms.Label label6;
    }
}