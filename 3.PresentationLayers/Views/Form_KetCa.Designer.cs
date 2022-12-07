namespace _3.PresentationLayers.Views
{
    partial class Form_KetCa
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
            this.label2 = new System.Windows.Forms.Label();
            this.lb_tongtien = new System.Windows.Forms.Label();
            this.tbx_ghichu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_tienphatsinh = new System.Windows.Forms.TextBox();
            this.btn_CapNhatTienPhatSinh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_xacnhan = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tb_email = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_matkhau = new System.Windows.Forms.TextBox();
            this.lb_mavaten = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ghi chú";
            // 
            // lb_tongtien
            // 
            this.lb_tongtien.AutoSize = true;
            this.lb_tongtien.Location = new System.Drawing.Point(271, 52);
            this.lb_tongtien.Name = "lb_tongtien";
            this.lb_tongtien.Size = new System.Drawing.Size(0, 20);
            this.lb_tongtien.TabIndex = 2;
            // 
            // tbx_ghichu
            // 
            this.tbx_ghichu.Location = new System.Drawing.Point(209, 123);
            this.tbx_ghichu.Multiline = true;
            this.tbx_ghichu.Name = "tbx_ghichu";
            this.tbx_ghichu.Size = new System.Drawing.Size(277, 63);
            this.tbx_ghichu.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tiền phát sinh:";
            // 
            // tb_tienphatsinh
            // 
            this.tb_tienphatsinh.Location = new System.Drawing.Point(271, 84);
            this.tb_tienphatsinh.Name = "tb_tienphatsinh";
            this.tb_tienphatsinh.Size = new System.Drawing.Size(215, 27);
            this.tb_tienphatsinh.TabIndex = 9;
            this.tb_tienphatsinh.TextChanged += new System.EventHandler(this.tb_tienphatsinh_TextChanged);
            this.tb_tienphatsinh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_tienphatsinh_KeyPress);
            // 
            // btn_CapNhatTienPhatSinh
            // 
            this.btn_CapNhatTienPhatSinh.Location = new System.Drawing.Point(545, 52);
            this.btn_CapNhatTienPhatSinh.Name = "btn_CapNhatTienPhatSinh";
            this.btn_CapNhatTienPhatSinh.Size = new System.Drawing.Size(186, 59);
            this.btn_CapNhatTienPhatSinh.TabIndex = 15;
            this.btn_CapNhatTienPhatSinh.Text = "Cập nhật tiền phát sinh";
            this.btn_CapNhatTienPhatSinh.UseVisualStyleBackColor = true;
            this.btn_CapNhatTienPhatSinh.Click += new System.EventHandler(this.btn_tienphatsinh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng tiền";
            // 
            // btn_xacnhan
            // 
            this.btn_xacnhan.Location = new System.Drawing.Point(271, 460);
            this.btn_xacnhan.Name = "btn_xacnhan";
            this.btn_xacnhan.Size = new System.Drawing.Size(203, 63);
            this.btn_xacnhan.TabIndex = 4;
            this.btn_xacnhan.Text = "Xác nhận";
            this.btn_xacnhan.UseVisualStyleBackColor = true;
            this.btn_xacnhan.Click += new System.EventHandler(this.btn_xacnhan_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(385, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 38);
            this.label4.TabIndex = 16;
            this.label4.Text = "Kết Ca";
            // 
            // tb_email
            // 
            this.tb_email.Location = new System.Drawing.Point(273, 342);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(215, 27);
            this.tb_email.TabIndex = 10;
            this.tb_email.TextChanged += new System.EventHandler(this.tb_email_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(132, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Email nhận ca";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 412);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Mật khẩu";
            // 
            // tb_matkhau
            // 
            this.tb_matkhau.Location = new System.Drawing.Point(273, 409);
            this.tb_matkhau.Name = "tb_matkhau";
            this.tb_matkhau.Size = new System.Drawing.Size(215, 27);
            this.tb_matkhau.TabIndex = 13;
            // 
            // lb_mavaten
            // 
            this.lb_mavaten.AutoSize = true;
            this.lb_mavaten.Location = new System.Drawing.Point(494, 345);
            this.lb_mavaten.Name = "lb_mavaten";
            this.lb_mavaten.Size = new System.Drawing.Size(0, 20);
            this.lb_mavaten.TabIndex = 14;
            // 
            // Form_KetCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 524);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_CapNhatTienPhatSinh);
            this.Controls.Add(this.lb_mavaten);
            this.Controls.Add(this.tb_matkhau);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_email);
            this.Controls.Add(this.tb_tienphatsinh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_xacnhan);
            this.Controls.Add(this.tbx_ghichu);
            this.Controls.Add(this.lb_tongtien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_KetCa";
            this.Text = "KetCa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_TongTienCaTruoc;
        private System.Windows.Forms.TextBox tbx_ghichu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_tienphatsinh;
        private System.Windows.Forms.Button btn_CapNhatTienPhatSinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_xacnhan;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lb_tongtien;
        private System.Windows.Forms.TextBox tb_email;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_matkhau;
        private System.Windows.Forms.Label lb_mavaten;
    }
}