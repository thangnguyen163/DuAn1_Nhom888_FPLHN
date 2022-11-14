namespace _3.PresentationLayers.Views
{
    partial class FrmChiTietTheLoai
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.gB_tt = new System.Windows.Forms.GroupBox();
            this.cbb_trangthai = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ten = new System.Windows.Forms.TextBox();
            this.tb_ma = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_Timkiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtg_Show = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbb_theloai = new System.Windows.Forms.ComboBox();
            this.cbb_tensach = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.gB_tt.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Show)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_Reset);
            this.groupBox3.Controls.Add(this.btn_Xoa);
            this.groupBox3.Controls.Add(this.btn_Sua);
            this.groupBox3.Controls.Add(this.btn_Them);
            this.groupBox3.Location = new System.Drawing.Point(740, 288);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(349, 282);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(6, 234);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(337, 29);
            this.btn_Reset.TabIndex = 3;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(3, 172);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(337, 29);
            this.btn_Xoa.TabIndex = 2;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Location = new System.Drawing.Point(6, 106);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(337, 29);
            this.btn_Sua.TabIndex = 1;
            this.btn_Sua.Text = "Sửa ";
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(6, 44);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(337, 29);
            this.btn_Them.TabIndex = 0;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // gB_tt
            // 
            this.gB_tt.Controls.Add(this.cbb_tensach);
            this.gB_tt.Controls.Add(this.cbb_theloai);
            this.gB_tt.Controls.Add(this.label6);
            this.gB_tt.Controls.Add(this.label5);
            this.gB_tt.Controls.Add(this.cbb_trangthai);
            this.gB_tt.Controls.Add(this.label4);
            this.gB_tt.Controls.Add(this.label3);
            this.gB_tt.Controls.Add(this.label2);
            this.gB_tt.Controls.Add(this.tb_ten);
            this.gB_tt.Controls.Add(this.tb_ma);
            this.gB_tt.Location = new System.Drawing.Point(12, 288);
            this.gB_tt.Name = "gB_tt";
            this.gB_tt.Size = new System.Drawing.Size(692, 282);
            this.gB_tt.TabIndex = 7;
            this.gB_tt.TabStop = false;
            this.gB_tt.Text = "Thông Tin Nhà Xuất Bản";
            // 
            // cbb_trangthai
            // 
            this.cbb_trangthai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_trangthai.FormattingEnabled = true;
            this.cbb_trangthai.Location = new System.Drawing.Point(206, 225);
            this.cbb_trangthai.Name = "cbb_trangthai";
            this.cbb_trangthai.Size = new System.Drawing.Size(219, 28);
            this.cbb_trangthai.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Thể loại chi tiết";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Trạng Thái :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã chi tiết:";
            // 
            // tb_ten
            // 
            this.tb_ten.Location = new System.Drawing.Point(206, 174);
            this.tb_ten.Name = "tb_ten";
            this.tb_ten.Size = new System.Drawing.Size(352, 27);
            this.tb_ten.TabIndex = 3;
            // 
            // tb_ma
            // 
            this.tb_ma.Location = new System.Drawing.Point(206, 121);
            this.tb_ma.Name = "tb_ma";
            this.tb_ma.Size = new System.Drawing.Size(352, 27);
            this.tb_ma.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_Timkiem);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtg_Show);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1077, 259);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Nhà Xuất Bản";
            // 
            // tb_Timkiem
            // 
            this.tb_Timkiem.Location = new System.Drawing.Point(808, 32);
            this.tb_Timkiem.Name = "tb_Timkiem";
            this.tb_Timkiem.Size = new System.Drawing.Size(252, 27);
            this.tb_Timkiem.TabIndex = 2;
            this.tb_Timkiem.TextChanged += new System.EventHandler(this.tb_Timkiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(723, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm Kiếm: ";
            // 
            // dtg_Show
            // 
            this.dtg_Show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_Show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_Show.Location = new System.Drawing.Point(20, 65);
            this.dtg_Show.Name = "dtg_Show";
            this.dtg_Show.RowHeadersWidth = 51;
            this.dtg_Show.RowTemplate.Height = 29;
            this.dtg_Show.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_Show.Size = new System.Drawing.Size(1040, 176);
            this.dtg_Show.TabIndex = 0;
            this.dtg_Show.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_Show_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Thể loại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tên sách:";
            // 
            // cbb_theloai
            // 
            this.cbb_theloai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_theloai.FormattingEnabled = true;
            this.cbb_theloai.Location = new System.Drawing.Point(206, 26);
            this.cbb_theloai.Name = "cbb_theloai";
            this.cbb_theloai.Size = new System.Drawing.Size(219, 28);
            this.cbb_theloai.TabIndex = 12;
            // 
            // cbb_tensach
            // 
            this.cbb_tensach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_tensach.FormattingEnabled = true;
            this.cbb_tensach.Location = new System.Drawing.Point(206, 72);
            this.cbb_tensach.Name = "cbb_tensach";
            this.cbb_tensach.Size = new System.Drawing.Size(219, 28);
            this.cbb_tensach.TabIndex = 13;
            // 
            // FrmChiTietTheLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 577);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gB_tt);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmChiTietTheLoai";
            this.Text = "FrmChiTietTheLoai";
            this.groupBox3.ResumeLayout(false);
            this.gB_tt.ResumeLayout(false);
            this.gB_tt.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Show)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.GroupBox gB_tt;
        private System.Windows.Forms.ComboBox cbb_trangthai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_ten;
        private System.Windows.Forms.TextBox tb_ma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_Timkiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtg_Show;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbb_tensach;
        private System.Windows.Forms.ComboBox cbb_theloai;
    }
}