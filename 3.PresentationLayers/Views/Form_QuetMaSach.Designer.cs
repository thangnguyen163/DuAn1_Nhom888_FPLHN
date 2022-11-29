namespace _3.PresentationLayers.Views
{
    partial class Form_QuetMaSach
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
            this.cbb_tenmay = new System.Windows.Forms.ComboBox();
            this.tb_mavach = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ptb_barcode = new System.Windows.Forms.PictureBox();
            this.tb_tensach = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_barcode)).BeginInit();
            this.SuspendLayout();
            // 
            // cbb_tenmay
            // 
            this.cbb_tenmay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_tenmay.FormattingEnabled = true;
            this.cbb_tenmay.Location = new System.Drawing.Point(99, 30);
            this.cbb_tenmay.Name = "cbb_tenmay";
            this.cbb_tenmay.Size = new System.Drawing.Size(268, 28);
            this.cbb_tenmay.TabIndex = 17;
            // 
            // tb_mavach
            // 
            this.tb_mavach.Location = new System.Drawing.Point(99, 394);
            this.tb_mavach.Name = "tb_mavach";
            this.tb_mavach.Size = new System.Drawing.Size(689, 27);
            this.tb_mavach.TabIndex = 15;
            this.tb_mavach.TextChanged += new System.EventHandler(this.tb_mavach_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mã vạch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Camera";
            // 
            // ptb_barcode
            // 
            this.ptb_barcode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptb_barcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptb_barcode.Location = new System.Drawing.Point(12, 64);
            this.ptb_barcode.Name = "ptb_barcode";
            this.ptb_barcode.Size = new System.Drawing.Size(776, 309);
            this.ptb_barcode.TabIndex = 12;
            this.ptb_barcode.TabStop = false;
            // 
            // tb_tensach
            // 
            this.tb_tensach.Location = new System.Drawing.Point(99, 442);
            this.tb_tensach.Name = "tb_tensach";
            this.tb_tensach.ReadOnly = true;
            this.tb_tensach.Size = new System.Drawing.Size(689, 27);
            this.tb_tensach.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 445);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Tên sách";
            // 
            // Form_QuetMaSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.tb_tensach);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbb_tenmay);
            this.Controls.Add(this.tb_mavach);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ptb_barcode);
            this.Name = "Form_QuetMaSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_QuetMaSach";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_QuetMaSach_FormClosing);
            this.Load += new System.EventHandler(this.Form_QuetMaSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_barcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_tenmay;
        private System.Windows.Forms.TextBox tb_mavach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ptb_barcode;
        private System.Windows.Forms.TextBox tb_tensach;
        private System.Windows.Forms.Label label3;
    }
}