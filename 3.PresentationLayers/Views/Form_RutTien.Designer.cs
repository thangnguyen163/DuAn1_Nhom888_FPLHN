namespace _3.PresentationLayers.Views
{
    partial class Form_RutTien
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
            this.tbx_user = new System.Windows.Forms.TextBox();
            this.tbx_pass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_TienRut = new System.Windows.Forms.TextBox();
            this.btn_ruttien = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbx_user
            // 
            this.tbx_user.Location = new System.Drawing.Point(126, 59);
            this.tbx_user.Name = "tbx_user";
            this.tbx_user.Size = new System.Drawing.Size(217, 27);
            this.tbx_user.TabIndex = 0;
            // 
            // tbx_pass
            // 
            this.tbx_pass.Location = new System.Drawing.Point(126, 131);
            this.tbx_pass.Name = "tbx_pass";
            this.tbx_pass.Size = new System.Drawing.Size(217, 27);
            this.tbx_pass.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mời nhập số tiền muốn rút";
            // 
            // tbx_TienRut
            // 
            this.tbx_TienRut.Location = new System.Drawing.Point(126, 211);
            this.tbx_TienRut.Name = "tbx_TienRut";
            this.tbx_TienRut.Size = new System.Drawing.Size(217, 27);
            this.tbx_TienRut.TabIndex = 5;
            this.tbx_TienRut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_TienRut_KeyPress);
            // 
            // btn_ruttien
            // 
            this.btn_ruttien.Location = new System.Drawing.Point(148, 266);
            this.btn_ruttien.Name = "btn_ruttien";
            this.btn_ruttien.Size = new System.Drawing.Size(162, 53);
            this.btn_ruttien.TabIndex = 7;
            this.btn_ruttien.Text = "Rút tiền";
            this.btn_ruttien.UseVisualStyleBackColor = true;
            this.btn_ruttien.Click += new System.EventHandler(this.btn_ruttien_Click);
            // 
            // Form_RutTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 392);
            this.Controls.Add(this.btn_ruttien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbx_TienRut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_pass);
            this.Controls.Add(this.tbx_user);
            this.Name = "Form_RutTien";
            this.Text = "RutTien";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_user;
        private System.Windows.Forms.TextBox tbx_pass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_TienRut;
        private System.Windows.Forms.Button btn_ruttien;
    }
}