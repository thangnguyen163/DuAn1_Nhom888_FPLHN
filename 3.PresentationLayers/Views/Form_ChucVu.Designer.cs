namespace _3.PresentationLayers.Views
{
    partial class Form_ChucVu
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ten = new System.Windows.Forms.TextBox();
            this.tb_ma = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_Timkiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtg_Show = new System.Windows.Forms.DataGridView();
            this.rB_hd = new System.Windows.Forms.RadioButton();
            this.rB_khd = new System.Windows.Forms.RadioButton();
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
            this.groupBox3.Location = new System.Drawing.Point(740, 277);
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
            this.gB_tt.Controls.Add(this.rB_khd);
            this.gB_tt.Controls.Add(this.rB_hd);
            this.gB_tt.Controls.Add(this.label4);
            this.gB_tt.Controls.Add(this.label3);
            this.gB_tt.Controls.Add(this.label2);
            this.gB_tt.Controls.Add(this.tb_ten);
            this.gB_tt.Controls.Add(this.tb_ma);
            this.gB_tt.Location = new System.Drawing.Point(12, 277);
            this.gB_tt.Name = "gB_tt";
            this.gB_tt.Size = new System.Drawing.Size(692, 282);
            this.gB_tt.TabIndex = 7;
            this.gB_tt.TabStop = false;
            this.gB_tt.Text = "Thông Tin Chức Vụ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tên :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Trạng Thái :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã :";
            // 
            // tb_ten
            // 
            this.tb_ten.Location = new System.Drawing.Point(453, 35);
            this.tb_ten.Name = "tb_ten";
            this.tb_ten.Size = new System.Drawing.Size(125, 27);
            this.tb_ten.TabIndex = 3;
            // 
            // tb_ma
            // 
            this.tb_ma.Location = new System.Drawing.Point(156, 35);
            this.tb_ma.Name = "tb_ma";
            this.tb_ma.Size = new System.Drawing.Size(125, 27);
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
            this.groupBox1.Text = "Danh Sách Chức Vụ";
            // 
            // tb_Timkiem
            // 
            this.tb_Timkiem.Location = new System.Drawing.Point(808, 32);
            this.tb_Timkiem.Name = "tb_Timkiem";
            this.tb_Timkiem.Size = new System.Drawing.Size(252, 27);
            this.tb_Timkiem.TabIndex = 2;
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
            this.dtg_Show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_Show.Location = new System.Drawing.Point(20, 65);
            this.dtg_Show.Name = "dtg_Show";
            this.dtg_Show.RowHeadersWidth = 51;
            this.dtg_Show.RowTemplate.Height = 29;
            this.dtg_Show.Size = new System.Drawing.Size(1040, 176);
            this.dtg_Show.TabIndex = 0;
            this.dtg_Show.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_Show_CellClick);
            // 
            // rB_hd
            // 
            this.rB_hd.AutoSize = true;
            this.rB_hd.Location = new System.Drawing.Point(220, 158);
            this.rB_hd.Name = "rB_hd";
            this.rB_hd.Size = new System.Drawing.Size(102, 24);
            this.rB_hd.TabIndex = 11;
            this.rB_hd.TabStop = true;
            this.rB_hd.Text = "Hoạt động";
            this.rB_hd.UseVisualStyleBackColor = true;
            this.rB_hd.Click += new System.EventHandler(this.rB_hd_Click);
            // 
            // rB_khd
            // 
            this.rB_khd.AutoSize = true;
            this.rB_khd.Location = new System.Drawing.Point(436, 156);
            this.rB_khd.Name = "rB_khd";
            this.rB_khd.Size = new System.Drawing.Size(146, 24);
            this.rB_khd.TabIndex = 12;
            this.rB_khd.TabStop = true;
            this.rB_khd.Text = "Không hoạt động";
            this.rB_khd.UseVisualStyleBackColor = true;
            this.rB_khd.Click += new System.EventHandler(this.rB_khd_Click);
            // 
            // Form_ChucVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 572);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gB_tt);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_ChucVu";
            this.Text = "Form_ChucVu";
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_ten;
        private System.Windows.Forms.TextBox tb_ma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_Timkiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtg_Show;
        private System.Windows.Forms.RadioButton rB_khd;
        private System.Windows.Forms.RadioButton rB_hd;
    }
}