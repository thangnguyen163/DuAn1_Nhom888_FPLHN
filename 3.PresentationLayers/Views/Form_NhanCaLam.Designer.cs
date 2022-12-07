namespace _3.PresentationLayers.Views
{
    partial class Form_NhanCaLam
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
            this.tbx_tienbandau = new System.Windows.Forms.TextBox();
            this.btn_NhanCa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_manv = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mời nhập số tiền ban đầu";
            // 
            // tbx_tienbandau
            // 
            this.tbx_tienbandau.Location = new System.Drawing.Point(61, 128);
            this.tbx_tienbandau.Name = "tbx_tienbandau";
            this.tbx_tienbandau.Size = new System.Drawing.Size(308, 27);
            this.tbx_tienbandau.TabIndex = 2;
            this.tbx_tienbandau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_tienbandau_KeyPress);
            // 
            // btn_NhanCa
            // 
            this.btn_NhanCa.Location = new System.Drawing.Point(504, 111);
            this.btn_NhanCa.Name = "btn_NhanCa";
            this.btn_NhanCa.Size = new System.Drawing.Size(147, 44);
            this.btn_NhanCa.TabIndex = 3;
            this.btn_NhanCa.Text = "Nhận ca làm";
            this.btn_NhanCa.UseVisualStyleBackColor = true;
            this.btn_NhanCa.Click += new System.EventHandler(this.btn_TiepNhan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã nhân viên: ";
            // 
            // lb_manv
            // 
            this.lb_manv.AutoSize = true;
            this.lb_manv.Location = new System.Drawing.Point(171, 26);
            this.lb_manv.Name = "lb_manv";
            this.lb_manv.Size = new System.Drawing.Size(0, 20);
            this.lb_manv.TabIndex = 5;
            // 
            // Form_NhanCaLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb_manv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_tienbandau);
            this.Controls.Add(this.btn_NhanCa);
            this.Controls.Add(this.label2);
            this.Name = "Form_NhanCaLam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_NhanCaLam";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_tienbandau;
        private System.Windows.Forms.Button btn_NhanCa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_manv;
    }
}