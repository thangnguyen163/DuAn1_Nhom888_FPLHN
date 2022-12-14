namespace _3.PresentationLayers.Views
{
    partial class Form_DoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DoiMatKhau));
            this.btn_dmk = new System.Windows.Forms.Button();
            this.tb_nhaplai = new System.Windows.Forms.TextBox();
            this.tb_mkm = new System.Windows.Forms.TextBox();
            this.tb_mkc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.show = new System.Windows.Forms.PictureBox();
            this.hide = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.show)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hide)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_dmk
            // 
            this.btn_dmk.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_dmk.Location = new System.Drawing.Point(126, 372);
            this.btn_dmk.Name = "btn_dmk";
            this.btn_dmk.Size = new System.Drawing.Size(137, 33);
            this.btn_dmk.TabIndex = 9;
            this.btn_dmk.Text = "Đổi Mật Khẩu";
            this.btn_dmk.UseVisualStyleBackColor = true;
            this.btn_dmk.Click += new System.EventHandler(this.btn_dmk_Click);
            // 
            // tb_nhaplai
            // 
            this.tb_nhaplai.Location = new System.Drawing.Point(180, 300);
            this.tb_nhaplai.Name = "tb_nhaplai";
            this.tb_nhaplai.Size = new System.Drawing.Size(149, 27);
            this.tb_nhaplai.TabIndex = 15;
            this.tb_nhaplai.TextChanged += new System.EventHandler(this.tb_nhaplai_TextChanged);
            // 
            // tb_mkm
            // 
            this.tb_mkm.Location = new System.Drawing.Point(180, 199);
            this.tb_mkm.Name = "tb_mkm";
            this.tb_mkm.Size = new System.Drawing.Size(149, 27);
            this.tb_mkm.TabIndex = 14;
            this.tb_mkm.TextChanged += new System.EventHandler(this.tb_mkm_TextChanged);
            // 
            // tb_mkc
            // 
            this.tb_mkc.Location = new System.Drawing.Point(180, 107);
            this.tb_mkc.Name = "tb_mkc";
            this.tb_mkc.Size = new System.Drawing.Size(149, 27);
            this.tb_mkc.TabIndex = 10;
            this.tb_mkc.TextChanged += new System.EventHandler(this.tb_mkc_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nhập lại mật khẩu : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Mật khẩu mới : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mật khẩu cũ : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(107, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 26);
            this.label1.TabIndex = 19;
            this.label1.Text = "ĐỔI MẬT KHẨU";
            // 
            // show
            // 
            this.show.Image = ((System.Drawing.Image)(resources.GetObject("show.Image")));
            this.show.Location = new System.Drawing.Point(297, 333);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(32, 21);
            this.show.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.show.TabIndex = 20;
            this.show.TabStop = false;
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // hide
            // 
            this.hide.Image = ((System.Drawing.Image)(resources.GetObject("hide.Image")));
            this.hide.Location = new System.Drawing.Point(297, 333);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(32, 21);
            this.hide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hide.TabIndex = 21;
            this.hide.TabStop = false;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // Form_DoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(393, 450);
            this.Controls.Add(this.show);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_dmk);
            this.Controls.Add(this.tb_nhaplai);
            this.Controls.Add(this.tb_mkm);
            this.Controls.Add(this.tb_mkc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hide);
            this.Name = "Form_DoiMatKhau";
            this.Text = "Form_DoiMatKhau";
            ((System.ComponentModel.ISupportInitialize)(this.show)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_dmk;
        private System.Windows.Forms.TextBox tb_nhaplai;
        private System.Windows.Forms.TextBox tb_mkm;
        private System.Windows.Forms.TextBox tb_mkc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox show;
        private System.Windows.Forms.PictureBox hide;
    }
}