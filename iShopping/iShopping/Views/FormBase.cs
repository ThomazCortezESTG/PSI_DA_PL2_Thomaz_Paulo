using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace iShopping.Views
{
    public class FormBase : Form
    {
        private bool dragging = false;
        private Point dragStart;

        private readonly Color transparentKey = Color.FromArgb(1, 1, 1);
        private readonly int radius = 20;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000; // CS_DROPSHADOW
                return cp;
            }
        }

        public FormBase()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = transparentKey;
            this.TransparencyKey = transparentKey;
            this.DoubleBuffered = true;

            this.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left)
                {
                    dragging = true;
                    dragStart = e.Location;
                }
            };
            this.MouseMove += (s, e) => {
                if (dragging)
                    this.Location = new Point(
                        this.Left + e.X - dragStart.X,
                        this.Top + e.Y - dragStart.Y
                    );
            };
            this.MouseUp += (s, e) => dragging = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(4, 4, this.Width - 9, this.Height - 9);

            // Fundo do form
            using (GraphicsPath path = GetRoundedPath(rect, radius))
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                g.FillPath(brush, path);
            }

            // Outline subtil para se destacar
            using (GraphicsPath path = GetRoundedPath(rect, radius))
            using (Pen pen = new Pen(Color.FromArgb(180, 200, 200, 200), 1.5f))
            {
                g.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int r)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseAllFigures();
            return path;
        }
    }
}