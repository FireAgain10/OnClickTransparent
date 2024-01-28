using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnClickTransparent
{
    public partial class Form1 : Form
    {
        private TransparentPanel panel;
        private bool isDragging = false;
        private Point offset;

        public Form1()
        {
            this.TopLevel = true;
            this.TopMost = true;
           // this.FormBorderStyle = FormBorderStyle.None;
            
            var screen = Screen.PrimaryScreen;


            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Width = ((int)(screen.Bounds.Width * 0.1));
            this.Height = ((int)(screen.Bounds.Height * 0.9));
            this.Location = new Point((int)(screen.Bounds.Width * 0.65), (int)(screen.Bounds.Height * 0.05));

            panel = new TransparentPanel();
            panel.Dock = DockStyle.Fill;
            this.Controls.Add(panel);

            panel.MouseDown += Form1_MouseDown;
            panel.MouseMove += Form1_MouseMove;
            panel.MouseUp += Form1_MouseUp;
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                offset = new Point(e.X, e.Y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newLocation = this.PointToScreen(new Point(e.X, e.Y));
                newLocation.Offset(-offset.X, -offset.Y);
                this.Location = newLocation;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }


        //protected override void OnGotFocus(EventArgs e)
        //{
        //    base.OnGotFocus(e);
        //}

        //protected override void OnLostFocus(EventArgs e)
        //{
        //    base.OnLostFocus(e);
        //}

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            //panel.BackColor = Color.Transparent;

        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            //panel.BackColor = Color.DeepSkyBlue;

        }
    }
}
