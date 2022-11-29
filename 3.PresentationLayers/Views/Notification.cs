﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PresentationLayers.Views
{
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();            
        }
        public enum enmAction
        {
            wait,
            start,
            close
        }
        private Notification.enmAction action;
        private int x, y;
        private void button1_Click(object sender, EventArgs e)
        {
            timer_close.Interval = 1;
            action = enmAction.close;
        }
        private void timer_close_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer_close.Interval = 5000;
                    action = enmAction.close;
                    break;
                case enmAction.start:
                    timer_close.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer_close.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }
        public void showAlert(string msg,Color color)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;
            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Notification frmAlert = (Notification)Application.OpenForms[fname];
                if (frmAlert == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;//hiển thị
            this.lb_message.Text = msg; // text
            this.BackColor = color;//màu           
            this.Show(); // hiển thị
            this.action = enmAction.start;
            this.timer_close.Interval = 1;
            timer_close.Start();
        }
    }
}