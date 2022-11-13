namespace _3.PresentationLayers.Views
{
    partial class Form_TacGia
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
            this.dtg_show = new System.Windows.Forms.DataGridView();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_show = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_ma = new System.Windows.Forms.TextBox();
            this.tbx_ten = new System.Windows.Forms.TextBox();
            this.cbx_trangthai = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_show)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg_show
            // 
            this.dtg_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_show.Location = new System.Drawing.Point(36, 12);
            this.dtg_show.Name = "dtg_show";
            this.dtg_show.RowHeadersWidth = 51;
            this.dtg_show.RowTemplate.Height = 29;
            this.dtg_show.Size = new System.Drawing.Size(519, 474);
            this.dtg_show.TabIndex = 0;
            this.dtg_show.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_show_CellClick);
            this.dtg_show.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_show_CellContentClick);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(963, 57);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(94, 29);
            this.btn_them.TabIndex = 1;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(963, 118);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(94, 29);
            this.btn_sua.TabIndex = 2;
            this.btn_sua.Text = "Sửa ";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(963, 182);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(94, 29);
            this.btn_xoa.TabIndex = 3;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_show
            // 
            this.btn_show.Location = new System.Drawing.Point(963, 253);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(94, 29);
            this.btn_show.TabIndex = 4;
            this.btn_show.Text = "Hiển thị";
            this.btn_show.UseVisualStyleBackColor = true;
            this.btn_show.Click += new System.EventHandler(this.btn_show_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(579, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(579, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(579, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Trạng thái";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbx_ma
            // 
            this.tbx_ma.Location = new System.Drawing.Point(702, 57);
            this.tbx_ma.Name = "tbx_ma";
            this.tbx_ma.Size = new System.Drawing.Size(181, 27);
            this.tbx_ma.TabIndex = 8;
            this.tbx_ma.TextChanged += new System.EventHandler(this.tbx_ma_TextChanged);
            // 
            // tbx_ten
            // 
            this.tbx_ten.Location = new System.Drawing.Point(702, 100);
            this.tbx_ten.Name = "tbx_ten";
            this.tbx_ten.Size = new System.Drawing.Size(181, 27);
            this.tbx_ten.TabIndex = 9;
            this.tbx_ten.TextChanged += new System.EventHandler(this.tbx_ten_TextChanged);
            // 
            // cbx_trangthai
            // 
            this.cbx_trangthai.FormattingEnabled = true;
            this.cbx_trangthai.Items.AddRange(new object[] {
            "Tồn tại",
            "Không tồn tại"});
            this.cbx_trangthai.Location = new System.Drawing.Point(702, 153);
            this.cbx_trangthai.Name = "cbx_trangthai";
            this.cbx_trangthai.Size = new System.Drawing.Size(151, 28);
            this.cbx_trangthai.TabIndex = 10;
            this.cbx_trangthai.SelectedIndexChanged += new System.EventHandler(this.cbx_trangthai_SelectedIndexChanged);
            // 
            // Form_TacGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 498);
            this.Controls.Add(this.cbx_trangthai);
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
            this.Name = "Form_TacGia";
            this.Text = "CrudTacGia";
            ((System.ComponentModel.ISupportInitialize)(this.dtg_show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtg_show;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_ma;
        private System.Windows.Forms.TextBox tbx_ten;
        private System.Windows.Forms.ComboBox cbx_trangthai;
    }
}