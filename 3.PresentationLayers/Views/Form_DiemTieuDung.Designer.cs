namespace _3.PresentationLayers.Views
{
    partial class Form_DiemTieuDung
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_ma = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_sodiem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_timkiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtg_show = new System.Windows.Forms.DataGridView();
            this.rd_hoatdong = new System.Windows.Forms.RadioButton();
            this.rd_khonghoatdong = new System.Windows.Forms.RadioButton();
            this.bt_them = new System.Windows.Forms.Button();
            this.bt_sua = new System.Windows.Forms.Button();
            this.bt_xoa = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_show)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd_khonghoatdong);
            this.groupBox1.Controls.Add(this.rd_hoatdong);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_sodiem);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_ma);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(22, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 271);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin ";
            // 
            // tb_ma
            // 
            this.tb_ma.Location = new System.Drawing.Point(134, 39);
            this.tb_ma.Name = "tb_ma";
            this.tb_ma.Size = new System.Drawing.Size(342, 27);
            this.tb_ma.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Trạng thái";
            // 
            // tb_sodiem
            // 
            this.tb_sodiem.Location = new System.Drawing.Point(134, 99);
            this.tb_sodiem.Name = "tb_sodiem";
            this.tb_sodiem.Size = new System.Drawing.Size(342, 27);
            this.tb_sodiem.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Số điểm";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_xoa);
            this.groupBox2.Controls.Add(this.bt_sua);
            this.groupBox2.Controls.Add(this.bt_them);
            this.groupBox2.Location = new System.Drawing.Point(746, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 271);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtg_show);
            this.groupBox3.Controls.Add(this.tb_timkiem);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(35, 320);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(997, 312);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dữ liệu ";
            // 
            // tb_timkiem
            // 
            this.tb_timkiem.Location = new System.Drawing.Point(105, 26);
            this.tb_timkiem.Name = "tb_timkiem";
            this.tb_timkiem.Size = new System.Drawing.Size(342, 27);
            this.tb_timkiem.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tìm kiếm";
            // 
            // dtg_show
            // 
            this.dtg_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_show.Location = new System.Drawing.Point(17, 73);
            this.dtg_show.Name = "dtg_show";
            this.dtg_show.RowHeadersWidth = 51;
            this.dtg_show.RowTemplate.Height = 29;
            this.dtg_show.Size = new System.Drawing.Size(899, 216);
            this.dtg_show.TabIndex = 10;
            // 
            // rd_hoatdong
            // 
            this.rd_hoatdong.AutoSize = true;
            this.rd_hoatdong.Location = new System.Drawing.Point(157, 169);
            this.rd_hoatdong.Name = "rd_hoatdong";
            this.rd_hoatdong.Size = new System.Drawing.Size(102, 24);
            this.rd_hoatdong.TabIndex = 7;
            this.rd_hoatdong.TabStop = true;
            this.rd_hoatdong.Text = "Hoạt động";
            this.rd_hoatdong.UseVisualStyleBackColor = true;
            // 
            // rd_khonghoatdong
            // 
            this.rd_khonghoatdong.AutoSize = true;
            this.rd_khonghoatdong.Location = new System.Drawing.Point(330, 169);
            this.rd_khonghoatdong.Name = "rd_khonghoatdong";
            this.rd_khonghoatdong.Size = new System.Drawing.Size(146, 24);
            this.rd_khonghoatdong.TabIndex = 8;
            this.rd_khonghoatdong.TabStop = true;
            this.rd_khonghoatdong.Text = "Không hoạt động";
            this.rd_khonghoatdong.UseVisualStyleBackColor = true;
            // 
            // bt_them
            // 
            this.bt_them.Location = new System.Drawing.Point(26, 30);
            this.bt_them.Name = "bt_them";
            this.bt_them.Size = new System.Drawing.Size(241, 48);
            this.bt_them.TabIndex = 0;
            this.bt_them.Text = "Thêm ";
            this.bt_them.UseVisualStyleBackColor = true;
            // 
            // bt_sua
            // 
            this.bt_sua.Location = new System.Drawing.Point(26, 106);
            this.bt_sua.Name = "bt_sua";
            this.bt_sua.Size = new System.Drawing.Size(241, 48);
            this.bt_sua.TabIndex = 1;
            this.bt_sua.Text = "Sửa";
            this.bt_sua.UseVisualStyleBackColor = true;
            // 
            // bt_xoa
            // 
            this.bt_xoa.Location = new System.Drawing.Point(26, 184);
            this.bt_xoa.Name = "bt_xoa";
            this.bt_xoa.Size = new System.Drawing.Size(241, 48);
            this.bt_xoa.TabIndex = 2;
            this.bt_xoa.Text = "Chuyển trạng thái";
            this.bt_xoa.UseVisualStyleBackColor = true;
            // 
            // Form_DiemTieuDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 636);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_DiemTieuDung";
            this.Text = "Form_DiemTieuDung";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_show)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rd_khonghoatdong;
        private System.Windows.Forms.RadioButton rd_hoatdong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_sodiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_ma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_xoa;
        private System.Windows.Forms.Button bt_sua;
        private System.Windows.Forms.Button bt_them;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtg_show;
        private System.Windows.Forms.TextBox tb_timkiem;
        private System.Windows.Forms.Label label5;
    }
}