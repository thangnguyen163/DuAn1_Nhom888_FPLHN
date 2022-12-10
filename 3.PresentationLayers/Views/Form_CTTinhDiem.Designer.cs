namespace _3.PresentationLayers.Views
{
    partial class Form_CTTinhDiem
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
            this.dtg_Show = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_tongtien = new System.Windows.Forms.TextBox();
            this.cbb_trangthai = new System.Windows.Forms.ComboBox();
            this.tb_heso = new System.Windows.Forms.TextBox();
            this.tb_giamgia = new System.Windows.Forms.TextBox();
            this.tb_ma = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.tb_tongdiem = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Show)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtg_Show);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1088, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách tích điểm ";
            // 
            // dtg_Show
            // 
            this.dtg_Show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_Show.Location = new System.Drawing.Point(22, 32);
            this.dtg_Show.Name = "dtg_Show";
            this.dtg_Show.RowHeadersWidth = 51;
            this.dtg_Show.RowTemplate.Height = 29;
            this.dtg_Show.Size = new System.Drawing.Size(1049, 255);
            this.dtg_Show.TabIndex = 0;
            this.dtg_Show.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_Show_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_tongdiem);
            this.groupBox2.Controls.Add(this.tb_tongtien);
            this.groupBox2.Controls.Add(this.cbb_trangthai);
            this.groupBox2.Controls.Add(this.tb_heso);
            this.groupBox2.Controls.Add(this.tb_giamgia);
            this.groupBox2.Controls.Add(this.tb_ma);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 329);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(749, 290);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin ";
            // 
            // tb_tongtien
            // 
            this.tb_tongtien.Location = new System.Drawing.Point(485, 41);
            this.tb_tongtien.Name = "tb_tongtien";
            this.tb_tongtien.Size = new System.Drawing.Size(216, 27);
            this.tb_tongtien.TabIndex = 11;
            // 
            // cbb_trangthai
            // 
            this.cbb_trangthai.FormattingEnabled = true;
            this.cbb_trangthai.Location = new System.Drawing.Point(485, 205);
            this.cbb_trangthai.Name = "cbb_trangthai";
            this.cbb_trangthai.Size = new System.Drawing.Size(216, 28);
            this.cbb_trangthai.TabIndex = 9;
            // 
            // tb_heso
            // 
            this.tb_heso.Location = new System.Drawing.Point(130, 118);
            this.tb_heso.Name = "tb_heso";
            this.tb_heso.Size = new System.Drawing.Size(210, 27);
            this.tb_heso.TabIndex = 8;
            // 
            // tb_giamgia
            // 
            this.tb_giamgia.Location = new System.Drawing.Point(130, 206);
            this.tb_giamgia.Name = "tb_giamgia";
            this.tb_giamgia.Size = new System.Drawing.Size(210, 27);
            this.tb_giamgia.TabIndex = 7;
            // 
            // tb_ma
            // 
            this.tb_ma.Location = new System.Drawing.Point(130, 41);
            this.tb_ma.Name = "tb_ma";
            this.tb_ma.Size = new System.Drawing.Size(210, 27);
            this.tb_ma.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(377, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tổng tiền :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Trạng thái";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tổng điểm :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hệ số :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Giảm giá : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_reset);
            this.groupBox3.Controls.Add(this.btn_xoa);
            this.groupBox3.Controls.Add(this.btn_sua);
            this.groupBox3.Controls.Add(this.btn_them);
            this.groupBox3.Location = new System.Drawing.Point(781, 329);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(319, 290);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng ";
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(13, 223);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(300, 45);
            this.btn_reset.TabIndex = 3;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(13, 161);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(300, 43);
            this.btn_xoa.TabIndex = 2;
            this.btn_xoa.Text = "Xóa ";
            this.btn_xoa.UseVisualStyleBackColor = true;
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(13, 102);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(300, 41);
            this.btn_sua.TabIndex = 1;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(13, 41);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(300, 41);
            this.btn_them.TabIndex = 0;
            this.btn_them.Text = "Thêm ";
            this.btn_them.UseVisualStyleBackColor = true;
            // 
            // tb_tongdiem
            // 
            this.tb_tongdiem.Location = new System.Drawing.Point(485, 116);
            this.tb_tongdiem.Name = "tb_tongdiem";
            this.tb_tongdiem.Size = new System.Drawing.Size(216, 27);
            this.tb_tongdiem.TabIndex = 12;
            // 
            // Form_CTTinhDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 639);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_CTTinhDiem";
            this.Text = "Form_CTTinhDiem";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Show)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtg_Show;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_tongtien;
        private System.Windows.Forms.ComboBox cbb_trangthai;
        private System.Windows.Forms.TextBox tb_heso;
        private System.Windows.Forms.TextBox tb_giamgia;
        private System.Windows.Forms.TextBox tb_ma;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox tb_tongdiem;
    }
}