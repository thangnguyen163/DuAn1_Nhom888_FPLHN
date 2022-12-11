namespace _3.PresentationLayers.Views
{
    partial class Form_GiaoCa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_GiaoCa));
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_ghichu = new System.Windows.Forms.TextBox();
            this.tb_phatsinhtienmat = new System.Windows.Forms.TextBox();
            this.btn_CapNhatTienPhatSinh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_xacnhan = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tb_email = new System.Windows.Forms.TextBox();
            this.tb_matkhau = new System.Windows.Forms.TextBox();
            this.lb_mavaten = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ck_confirm = new System.Windows.Forms.CheckBox();
            this.lb_tienmat = new System.Windows.Forms.TextBox();
            this.lb_tienkhac = new System.Windows.Forms.TextBox();
            this.lb_tongtien = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(463, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ghi chú : ";
            // 
            // tbx_ghichu
            // 
            this.tbx_ghichu.Location = new System.Drawing.Point(545, 296);
            this.tbx_ghichu.Multiline = true;
            this.tbx_ghichu.Name = "tbx_ghichu";
            this.tbx_ghichu.Size = new System.Drawing.Size(288, 87);
            this.tbx_ghichu.TabIndex = 3;
            // 
            // tb_phatsinhtienmat
            // 
            this.tb_phatsinhtienmat.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tb_phatsinhtienmat.Location = new System.Drawing.Point(545, 249);
            this.tb_phatsinhtienmat.Name = "tb_phatsinhtienmat";
            this.tb_phatsinhtienmat.Size = new System.Drawing.Size(172, 27);
            this.tb_phatsinhtienmat.TabIndex = 9;
            this.tb_phatsinhtienmat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_phatsinhtienmat.TextChanged += new System.EventHandler(this.tb_tienphatsinh_TextChanged);
            this.tb_phatsinhtienmat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_tienphatsinh_KeyPress);
            // 
            // btn_CapNhatTienPhatSinh
            // 
            this.btn_CapNhatTienPhatSinh.BackColor = System.Drawing.Color.Lime;
            this.btn_CapNhatTienPhatSinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_CapNhatTienPhatSinh.Location = new System.Drawing.Point(609, 407);
            this.btn_CapNhatTienPhatSinh.Name = "btn_CapNhatTienPhatSinh";
            this.btn_CapNhatTienPhatSinh.Size = new System.Drawing.Size(190, 52);
            this.btn_CapNhatTienPhatSinh.TabIndex = 15;
            this.btn_CapNhatTienPhatSinh.Text = "Cập nhật tiền phát sinh";
            this.btn_CapNhatTienPhatSinh.UseVisualStyleBackColor = false;
            this.btn_CapNhatTienPhatSinh.Click += new System.EventHandler(this.btn_tienphatsinh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(444, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng tiền : ";
            // 
            // btn_xacnhan
            // 
            this.btn_xacnhan.BackColor = System.Drawing.Color.Lime;
            this.btn_xacnhan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_xacnhan.Location = new System.Drawing.Point(140, 424);
            this.btn_xacnhan.Name = "btn_xacnhan";
            this.btn_xacnhan.Size = new System.Drawing.Size(128, 52);
            this.btn_xacnhan.TabIndex = 4;
            this.btn_xacnhan.Text = "Xác nhận";
            this.btn_xacnhan.UseVisualStyleBackColor = false;
            this.btn_xacnhan.Click += new System.EventHandler(this.btn_xacnhan_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(140, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 38);
            this.label4.TabIndex = 16;
            this.label4.Text = "Giao Ca";
            // 
            // tb_email
            // 
            this.tb_email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.tb_email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_email.Location = new System.Drawing.Point(95, 286);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(215, 20);
            this.tb_email.TabIndex = 10;
            this.tb_email.TextChanged += new System.EventHandler(this.tb_email_TextChanged);
            // 
            // tb_matkhau
            // 
            this.tb_matkhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.tb_matkhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_matkhau.Location = new System.Drawing.Point(96, 353);
            this.tb_matkhau.Name = "tb_matkhau";
            this.tb_matkhau.PasswordChar = '*';
            this.tb_matkhau.Size = new System.Drawing.Size(215, 20);
            this.tb_matkhau.TabIndex = 13;
            // 
            // lb_mavaten
            // 
            this.lb_mavaten.AutoSize = true;
            this.lb_mavaten.Location = new System.Drawing.Point(310, 456);
            this.lb_mavaten.Name = "lb_mavaten";
            this.lb_mavaten.Size = new System.Drawing.Size(0, 20);
            this.lb_mavaten.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(387, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Tiền mặt phát sinh :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(418, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Tổng tiền mặt :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(412, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Tổng tiền khác :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.tb_email);
            this.panel1.Controls.Add(this.btn_xacnhan);
            this.panel1.Controls.Add(this.tb_matkhau);
            this.panel1.Controls.Add(this.lb_mavaten);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 500);
            this.panel1.TabIndex = 23;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(96, 380);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 2);
            this.panel2.TabIndex = 124;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Black;
            this.panel13.Controls.Add(this.panel3);
            this.panel13.Location = new System.Drawing.Point(96, 310);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(215, 2);
            this.panel13.TabIndex = 124;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(215, 2);
            this.panel3.TabIndex = 125;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(29, 334);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 48);
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(29, 275);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 48);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(115, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 167);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(723, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "VND";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(723, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "VND";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(723, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "VND";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(723, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "VND";
            // 
            // ck_confirm
            // 
            this.ck_confirm.AutoSize = true;
            this.ck_confirm.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.ck_confirm.ForeColor = System.Drawing.Color.Blue;
            this.ck_confirm.Location = new System.Drawing.Point(387, 407);
            this.ck_confirm.Name = "ck_confirm";
            this.ck_confirm.Size = new System.Drawing.Size(200, 24);
            this.ck_confirm.TabIndex = 25;
            this.ck_confirm.Text = "Xác nhận tiền phát sinh";
            this.ck_confirm.UseVisualStyleBackColor = true;
            this.ck_confirm.CheckedChanged += new System.EventHandler(this.ck_confirm_CheckedChanged);
            // 
            // lb_tienmat
            // 
            this.lb_tienmat.BackColor = System.Drawing.SystemColors.Control;
            this.lb_tienmat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_tienmat.Location = new System.Drawing.Point(545, 117);
            this.lb_tienmat.Name = "lb_tienmat";
            this.lb_tienmat.ReadOnly = true;
            this.lb_tienmat.Size = new System.Drawing.Size(172, 20);
            this.lb_tienmat.TabIndex = 26;
            this.lb_tienmat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_tienkhac
            // 
            this.lb_tienkhac.BackColor = System.Drawing.SystemColors.Control;
            this.lb_tienkhac.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_tienkhac.Location = new System.Drawing.Point(545, 157);
            this.lb_tienkhac.Name = "lb_tienkhac";
            this.lb_tienkhac.ReadOnly = true;
            this.lb_tienkhac.Size = new System.Drawing.Size(172, 20);
            this.lb_tienkhac.TabIndex = 26;
            this.lb_tienkhac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_tongtien
            // 
            this.lb_tongtien.BackColor = System.Drawing.SystemColors.Control;
            this.lb_tongtien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_tongtien.Location = new System.Drawing.Point(545, 206);
            this.lb_tongtien.Name = "lb_tongtien";
            this.lb_tongtien.ReadOnly = true;
            this.lb_tongtien.Size = new System.Drawing.Size(172, 20);
            this.lb_tongtien.TabIndex = 26;
            this.lb_tongtien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form_GiaoCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 496);
            this.Controls.Add(this.lb_tongtien);
            this.Controls.Add(this.lb_tienkhac);
            this.Controls.Add(this.lb_tienmat);
            this.Controls.Add(this.ck_confirm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_CapNhatTienPhatSinh);
            this.Controls.Add(this.tb_phatsinhtienmat);
            this.Controls.Add(this.tbx_ghichu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_GiaoCa";
            this.Text = "KetCa";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_TongTienCaTruoc;
        private System.Windows.Forms.TextBox tbx_ghichu;
        private System.Windows.Forms.TextBox tb_phatsinhtienmat;
        private System.Windows.Forms.Button btn_CapNhatTienPhatSinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_xacnhan;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox tb_email;
        private System.Windows.Forms.TextBox tb_matkhau;
        private System.Windows.Forms.Label lb_mavaten;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ck_confirm;
        private System.Windows.Forms.TextBox lb_tienmat;
        private System.Windows.Forms.TextBox lb_tienkhac;
        private System.Windows.Forms.TextBox lb_tongtien;
    }
}