namespace _3.PresentationLayers.Views
{
    partial class Form_Dasboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Dasboard));
            this.PanelTitel = new System.Windows.Forms.Panel();
            this.labelTite = new System.Windows.Forms.Label();
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.PanelDesktopPanel = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.logout = new System.Windows.Forms.Button();
            this.btn_sanpham = new System.Windows.Forms.Button();
            this.btn_ThongKe = new System.Windows.Forms.Button();
            this.btn_shopping = new System.Windows.Forms.Button();
            this.PanelTitel.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTitel
            // 
            this.PanelTitel.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.PanelTitel.Controls.Add(this.labelTite);
            this.PanelTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitel.Location = new System.Drawing.Point(228, 0);
            this.PanelTitel.Name = "PanelTitel";
            this.PanelTitel.Size = new System.Drawing.Size(1158, 100);
            this.PanelTitel.TabIndex = 1;
            // 
            // labelTite
            // 
            this.labelTite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTite.AutoSize = true;
            this.labelTite.Font = new System.Drawing.Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTite.ForeColor = System.Drawing.Color.White;
            this.labelTite.Location = new System.Drawing.Point(549, 44);
            this.labelTite.Name = "labelTite";
            this.labelTite.Size = new System.Drawing.Size(65, 25);
            this.labelTite.TabIndex = 0;
            this.labelTite.Text = "HOME";
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandTimeout = 30;
            this.sqlCommand1.Connection = null;
            this.sqlCommand1.Notification = null;
            this.sqlCommand1.Transaction = null;
            // 
            // PanelDesktopPanel
            // 
            this.PanelDesktopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelDesktopPanel.Location = new System.Drawing.Point(228, 100);
            this.PanelDesktopPanel.Name = "PanelDesktopPanel";
            this.PanelDesktopPanel.Size = new System.Drawing.Size(1158, 498);
            this.PanelDesktopPanel.TabIndex = 2;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(228, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.logout);
            this.panelMenu.Controls.Add(this.btn_sanpham);
            this.panelMenu.Controls.Add(this.btn_ThongKe);
            this.panelMenu.Controls.Add(this.btn_shopping);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(228, 598);
            this.panelMenu.TabIndex = 0;
            // 
            // logout
            // 
            this.logout.Dock = System.Windows.Forms.DockStyle.Top;
            this.logout.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.logout.FlatAppearance.BorderSize = 0;
            this.logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logout.ForeColor = System.Drawing.Color.White;
            this.logout.Image = ((System.Drawing.Image)(resources.GetObject("logout.Image")));
            this.logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout.Location = new System.Drawing.Point(0, 250);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(228, 60);
            this.logout.TabIndex = 4;
            this.logout.Text = "Thoát";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // btn_sanpham
            // 
            this.btn_sanpham.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_sanpham.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_sanpham.FlatAppearance.BorderSize = 0;
            this.btn_sanpham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sanpham.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_sanpham.ForeColor = System.Drawing.Color.White;
            this.btn_sanpham.Image = ((System.Drawing.Image)(resources.GetObject("btn_sanpham.Image")));
            this.btn_sanpham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sanpham.Location = new System.Drawing.Point(0, 200);
            this.btn_sanpham.Name = "btn_sanpham";
            this.btn_sanpham.Size = new System.Drawing.Size(228, 50);
            this.btn_sanpham.TabIndex = 3;
            this.btn_sanpham.Text = "Sản Phẩm";
            this.btn_sanpham.UseVisualStyleBackColor = true;
            this.btn_sanpham.Click += new System.EventHandler(this.btn_sanpham_Click);
            // 
            // btn_ThongKe
            // 
            this.btn_ThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_ThongKe.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_ThongKe.FlatAppearance.BorderSize = 0;
            this.btn_ThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ThongKe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_ThongKe.ForeColor = System.Drawing.Color.White;
            this.btn_ThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btn_ThongKe.Image")));
            this.btn_ThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ThongKe.Location = new System.Drawing.Point(0, 150);
            this.btn_ThongKe.Name = "btn_ThongKe";
            this.btn_ThongKe.Size = new System.Drawing.Size(228, 50);
            this.btn_ThongKe.TabIndex = 2;
            this.btn_ThongKe.Text = "Thống Kê";
            this.btn_ThongKe.UseVisualStyleBackColor = true;
            this.btn_ThongKe.Click += new System.EventHandler(this.btn_ThongKe_Click);
            // 
            // btn_shopping
            // 
            this.btn_shopping.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_shopping.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_shopping.FlatAppearance.BorderSize = 0;
            this.btn_shopping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_shopping.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_shopping.ForeColor = System.Drawing.Color.White;
            this.btn_shopping.Image = ((System.Drawing.Image)(resources.GetObject("btn_shopping.Image")));
            this.btn_shopping.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_shopping.Location = new System.Drawing.Point(0, 100);
            this.btn_shopping.Name = "btn_shopping";
            this.btn_shopping.Size = new System.Drawing.Size(228, 50);
            this.btn_shopping.TabIndex = 1;
            this.btn_shopping.Text = "Bán Hàng";
            this.btn_shopping.UseVisualStyleBackColor = true;
            this.btn_shopping.Click += new System.EventHandler(this.btn_shopping_Click);
            // 
            // Form_Dasboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1386, 598);
            this.Controls.Add(this.PanelDesktopPanel);
            this.Controls.Add(this.PanelTitel);
            this.Controls.Add(this.panelMenu);
            this.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.Name = "Form_Dasboard";
            this.Text = "Form_Dasboard";
            this.PanelTitel.ResumeLayout(false);
            this.PanelTitel.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelTitel;
        private System.Windows.Forms.Label labelTite;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.Panel PanelDesktopPanel;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button btn_sanpham;
        private System.Windows.Forms.Button btn_ThongKe;
        private System.Windows.Forms.Button btn_shopping;
    }
}