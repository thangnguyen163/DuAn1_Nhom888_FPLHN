namespace _3.PresentationLayers.Views
{
    partial class Form_Hoadon
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rdb_all1 = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.rdb_chuatt1 = new System.Windows.Forms.RadioButton();
            this.rdb_datt1 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_searchma = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbb_manv = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_giamax = new System.Windows.Forms.TextBox();
            this.tb_giamin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_time = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtg_hd = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_giamax2 = new System.Windows.Forms.TextBox();
            this.tb_giamin2 = new System.Windows.Forms.TextBox();
            this.rdb_all = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.rdb_chuatt = new System.Windows.Forms.RadioButton();
            this.rdb_datt = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtg_hdct = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_hd)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_hdct)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1499, 697);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rdb_all1);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.rdb_chuatt1);
            this.tabPage1.Controls.Add(this.rdb_datt1);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.tb_searchma);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.cbb_manv);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tb_giamax);
            this.tabPage1.Controls.Add(this.tb_giamin);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dtp_time);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1491, 664);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hóa Đơn";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rdb_all1
            // 
            this.rdb_all1.AutoSize = true;
            this.rdb_all1.Location = new System.Drawing.Point(240, 9);
            this.rdb_all1.Name = "rdb_all1";
            this.rdb_all1.Size = new System.Drawing.Size(70, 24);
            this.rdb_all1.TabIndex = 18;
            this.rdb_all1.TabStop = true;
            this.rdb_all1.Text = "Tất cả";
            this.rdb_all1.UseVisualStyleBackColor = true;
            this.rdb_all1.CheckedChanged += new System.EventHandler(this.rdb_all1_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 20);
            this.label12.TabIndex = 17;
            this.label12.Text = "Lọc theo trạng thái";
            // 
            // rdb_chuatt1
            // 
            this.rdb_chuatt1.AutoSize = true;
            this.rdb_chuatt1.Location = new System.Drawing.Point(583, 9);
            this.rdb_chuatt1.Name = "rdb_chuatt1";
            this.rdb_chuatt1.Size = new System.Drawing.Size(139, 24);
            this.rdb_chuatt1.TabIndex = 16;
            this.rdb_chuatt1.TabStop = true;
            this.rdb_chuatt1.Text = "Chưa thanh toán";
            this.rdb_chuatt1.UseVisualStyleBackColor = true;
            this.rdb_chuatt1.CheckedChanged += new System.EventHandler(this.rdb_chuatt1_CheckedChanged);
            // 
            // rdb_datt1
            // 
            this.rdb_datt1.AutoSize = true;
            this.rdb_datt1.Location = new System.Drawing.Point(384, 9);
            this.rdb_datt1.Name = "rdb_datt1";
            this.rdb_datt1.Size = new System.Drawing.Size(124, 24);
            this.rdb_datt1.TabIndex = 15;
            this.rdb_datt1.TabStop = true;
            this.rdb_datt1.Text = "Đã thanh toán";
            this.rdb_datt1.UseVisualStyleBackColor = true;
            this.rdb_datt1.CheckedChanged += new System.EventHandler(this.rdb_datt1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1246, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tìm kiếm theo mã hóa đơn";
            // 
            // tb_searchma
            // 
            this.tb_searchma.Location = new System.Drawing.Point(1246, 92);
            this.tb_searchma.Name = "tb_searchma";
            this.tb_searchma.Size = new System.Drawing.Size(236, 27);
            this.tb_searchma.TabIndex = 13;
            this.tb_searchma.TextChanged += new System.EventHandler(this.tb_searchma_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(900, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Lọc theo mã nhân viên";
            // 
            // cbb_manv
            // 
            this.cbb_manv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_manv.FormattingEnabled = true;
            this.cbb_manv.Location = new System.Drawing.Point(900, 89);
            this.cbb_manv.Name = "cbb_manv";
            this.cbb_manv.Size = new System.Drawing.Size(204, 28);
            this.cbb_manv.TabIndex = 11;
            this.cbb_manv.TextChanged += new System.EventHandler(this.cbb_manv_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(579, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "đến";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Từ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(386, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Lọc theo khoảng giá";
            // 
            // tb_giamax
            // 
            this.tb_giamax.Location = new System.Drawing.Point(619, 92);
            this.tb_giamax.Name = "tb_giamax";
            this.tb_giamax.Size = new System.Drawing.Size(158, 27);
            this.tb_giamax.TabIndex = 7;
            this.tb_giamax.TextChanged += new System.EventHandler(this.tb_giamax_TextChanged);
            // 
            // tb_giamin
            // 
            this.tb_giamin.Location = new System.Drawing.Point(418, 92);
            this.tb_giamin.Name = "tb_giamin";
            this.tb_giamin.Size = new System.Drawing.Size(155, 27);
            this.tb_giamin.TabIndex = 6;
            this.tb_giamin.TextChanged += new System.EventHandler(this.tb_giamin_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lọc theo ngày";
            // 
            // dtp_time
            // 
            this.dtp_time.Location = new System.Drawing.Point(26, 87);
            this.dtp_time.Name = "dtp_time";
            this.dtp_time.Size = new System.Drawing.Size(250, 27);
            this.dtp_time.TabIndex = 4;
            this.dtp_time.ValueChanged += new System.EventHandler(this.dtp_time_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtg_hd);
            this.groupBox1.Location = new System.Drawing.Point(6, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1479, 442);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Hóa Đơn";
            // 
            // dtg_hd
            // 
            this.dtg_hd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_hd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_hd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_hd.Location = new System.Drawing.Point(3, 23);
            this.dtg_hd.Name = "dtg_hd";
            this.dtg_hd.RowHeadersWidth = 51;
            this.dtg_hd.RowTemplate.Height = 29;
            this.dtg_hd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_hd.Size = new System.Drawing.Size(1473, 416);
            this.dtg_hd.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.tb_giamax2);
            this.tabPage2.Controls.Add(this.tb_giamin2);
            this.tabPage2.Controls.Add(this.rdb_all);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.rdb_chuatt);
            this.tabPage2.Controls.Add(this.rdb_datt);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1491, 664);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hóa Đơn Chi Tiết";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(503, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "đến";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(310, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "Từ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(310, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 20);
            this.label11.TabIndex = 13;
            this.label11.Text = "Lọc theo khoảng giá";
            // 
            // tb_giamax2
            // 
            this.tb_giamax2.Location = new System.Drawing.Point(543, 89);
            this.tb_giamax2.Name = "tb_giamax2";
            this.tb_giamax2.Size = new System.Drawing.Size(158, 27);
            this.tb_giamax2.TabIndex = 12;
            this.tb_giamax2.TextChanged += new System.EventHandler(this.tb_giamax2_TextChanged);
            // 
            // tb_giamin2
            // 
            this.tb_giamin2.Location = new System.Drawing.Point(342, 89);
            this.tb_giamin2.Name = "tb_giamin2";
            this.tb_giamin2.Size = new System.Drawing.Size(155, 27);
            this.tb_giamin2.TabIndex = 11;
            this.tb_giamin2.TextChanged += new System.EventHandler(this.tb_giamin2_TextChanged_1);
            // 
            // rdb_all
            // 
            this.rdb_all.AutoSize = true;
            this.rdb_all.Location = new System.Drawing.Point(241, 11);
            this.rdb_all.Name = "rdb_all";
            this.rdb_all.Size = new System.Drawing.Size(70, 24);
            this.rdb_all.TabIndex = 10;
            this.rdb_all.TabStop = true;
            this.rdb_all.Text = "Tất cả";
            this.rdb_all.UseVisualStyleBackColor = true;
            this.rdb_all.CheckedChanged += new System.EventHandler(this.rdb_all_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Lọc theo trạng thái";
            // 
            // rdb_chuatt
            // 
            this.rdb_chuatt.AutoSize = true;
            this.rdb_chuatt.Location = new System.Drawing.Point(584, 11);
            this.rdb_chuatt.Name = "rdb_chuatt";
            this.rdb_chuatt.Size = new System.Drawing.Size(139, 24);
            this.rdb_chuatt.TabIndex = 8;
            this.rdb_chuatt.TabStop = true;
            this.rdb_chuatt.Text = "Chưa thanh toán";
            this.rdb_chuatt.UseVisualStyleBackColor = true;
            this.rdb_chuatt.CheckedChanged += new System.EventHandler(this.rdb_chuatt_CheckedChanged);
            // 
            // rdb_datt
            // 
            this.rdb_datt.AutoSize = true;
            this.rdb_datt.Location = new System.Drawing.Point(385, 11);
            this.rdb_datt.Name = "rdb_datt";
            this.rdb_datt.Size = new System.Drawing.Size(124, 24);
            this.rdb_datt.TabIndex = 7;
            this.rdb_datt.TabStop = true;
            this.rdb_datt.Text = "Đã thanh toán";
            this.rdb_datt.UseVisualStyleBackColor = true;
            this.rdb_datt.CheckedChanged += new System.EventHandler(this.rdb_datt_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tìm kiếm theo mã";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 27);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtg_hdct);
            this.groupBox2.Location = new System.Drawing.Point(9, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1476, 442);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Hóa Đơn";
            // 
            // dtg_hdct
            // 
            this.dtg_hdct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_hdct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_hdct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_hdct.Location = new System.Drawing.Point(3, 23);
            this.dtg_hdct.Name = "dtg_hdct";
            this.dtg_hdct.RowHeadersWidth = 51;
            this.dtg_hdct.RowTemplate.Height = 29;
            this.dtg_hdct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_hdct.Size = new System.Drawing.Size(1470, 416);
            this.dtg_hdct.TabIndex = 0;
            // 
            // Form_Hoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1523, 721);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form_Hoadon";
            this.Text = "Form_Hoadon";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_hd)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_hdct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_time;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtg_hd;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtg_hdct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_giamax;
        private System.Windows.Forms.TextBox tb_giamin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbb_manv;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_searchma;
        private System.Windows.Forms.RadioButton rdb_chuatt;
        private System.Windows.Forms.RadioButton rdb_datt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rdb_all;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_giamax2;
        private System.Windows.Forms.TextBox tb_giamin2;
        private System.Windows.Forms.RadioButton rdb_all1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rdb_chuatt1;
        private System.Windows.Forms.RadioButton rdb_datt1;
    }
}