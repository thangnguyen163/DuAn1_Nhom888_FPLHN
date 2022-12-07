namespace _3.PresentationLayers.Views
{
    partial class Form_QuenMatKhau
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
            this.tb_ten = new System.Windows.Forms.TextBox();
            this.tb_sdt = new System.Windows.Forms.TextBox();
            this.tb_matkhau = new System.Windows.Forms.TextBox();
            this.tb_nhaplaimatkhau = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_pass1 = new System.Windows.Forms.CheckBox();
            this.cb_pass2 = new System.Windows.Forms.CheckBox();
            this.btn_xacnhan = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_ten
            // 
            this.tb_ten.Location = new System.Drawing.Point(224, 25);
            this.tb_ten.Name = "tb_ten";
            this.tb_ten.Size = new System.Drawing.Size(322, 27);
            this.tb_ten.TabIndex = 0;
            // 
            // tb_sdt
            // 
            this.tb_sdt.Location = new System.Drawing.Point(224, 79);
            this.tb_sdt.Name = "tb_sdt";
            this.tb_sdt.Size = new System.Drawing.Size(322, 27);
            this.tb_sdt.TabIndex = 1;
            // 
            // tb_matkhau
            // 
            this.tb_matkhau.Location = new System.Drawing.Point(212, 217);
            this.tb_matkhau.Name = "tb_matkhau";
            this.tb_matkhau.PasswordChar = '*';
            this.tb_matkhau.Size = new System.Drawing.Size(322, 27);
            this.tb_matkhau.TabIndex = 2;
            // 
            // tb_nhaplaimatkhau
            // 
            this.tb_nhaplaimatkhau.Location = new System.Drawing.Point(212, 276);
            this.tb_nhaplaimatkhau.Name = "tb_nhaplaimatkhau";
            this.tb_nhaplaimatkhau.PasswordChar = '*';
            this.tb_nhaplaimatkhau.Size = new System.Drawing.Size(322, 27);
            this.tb_nhaplaimatkhau.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Số điện thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật khẩu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nhập lại mật khẩu";
            // 
            // cb_pass1
            // 
            this.cb_pass1.AutoSize = true;
            this.cb_pass1.Location = new System.Drawing.Point(540, 220);
            this.cb_pass1.Name = "cb_pass1";
            this.cb_pass1.Size = new System.Drawing.Size(83, 24);
            this.cb_pass1.TabIndex = 8;
            this.cb_pass1.Text = "Hiển thị";
            this.cb_pass1.UseVisualStyleBackColor = true;
            this.cb_pass1.CheckedChanged += new System.EventHandler(this.cb_pass1_CheckedChanged);
            // 
            // cb_pass2
            // 
            this.cb_pass2.AutoSize = true;
            this.cb_pass2.Location = new System.Drawing.Point(540, 279);
            this.cb_pass2.Name = "cb_pass2";
            this.cb_pass2.Size = new System.Drawing.Size(83, 24);
            this.cb_pass2.TabIndex = 9;
            this.cb_pass2.Text = "Hiển thị";
            this.cb_pass2.UseVisualStyleBackColor = true;
            this.cb_pass2.CheckedChanged += new System.EventHandler(this.cb_pass2_CheckedChanged);
            // 
            // btn_xacnhan
            // 
            this.btn_xacnhan.Location = new System.Drawing.Point(676, 233);
            this.btn_xacnhan.Name = "btn_xacnhan";
            this.btn_xacnhan.Size = new System.Drawing.Size(194, 50);
            this.btn_xacnhan.TabIndex = 10;
            this.btn_xacnhan.Text = "Xác nhận";
            this.btn_xacnhan.UseVisualStyleBackColor = true;
            this.btn_xacnhan.Click += new System.EventHandler(this.btn_xacnhan_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(224, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 47);
            this.button1.TabIndex = 11;
            this.button1.Text = "Gửi mail";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_QuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 212);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_xacnhan);
            this.Controls.Add(this.cb_pass2);
            this.Controls.Add(this.cb_pass1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_nhaplaimatkhau);
            this.Controls.Add(this.tb_matkhau);
            this.Controls.Add(this.tb_sdt);
            this.Controls.Add(this.tb_ten);
            this.Name = "Form_QuenMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_QuenMatKhau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_ten;
        private System.Windows.Forms.TextBox tb_sdt;
        private System.Windows.Forms.TextBox tb_matkhau;
        private System.Windows.Forms.TextBox tb_nhaplaimatkhau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_pass1;
        private System.Windows.Forms.CheckBox cb_pass2;
        private System.Windows.Forms.Button btn_xacnhan;
        private System.Windows.Forms.Button button1;
    }
}