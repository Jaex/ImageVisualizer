using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageVisualizer
{
    public partial class ImageVisualizerForm : Form
    {
        public ImageVisualizerForm(Image img)
        {
            InitializeComponent();
            Text = string.Format("Image Visualizer - Width: {0}, Height: {1}, Type: {2}", img.Width, img.Height, img.GetType().Name);
            SetPreview(img);
        }

        private void SetPreview(Image img)
        {
            int lineWidth = 2;

            Bitmap bmpPreview = new Bitmap(img.Width + lineWidth * 2, img.Height + lineWidth * 2);

            using (Graphics g = Graphics.FromImage(bmpPreview))
            {
                g.Clear(Color.White);

                using (Image checkers = DrawCheckers(img.Width, img.Height))
                {
                    g.DrawImage(checkers, lineWidth, lineWidth, img.Width, img.Height);
                }

                g.DrawImage(img, lineWidth, lineWidth, img.Width, img.Height);

                using (Pen pen1 = new Pen(Color.Black, lineWidth))
                {
                    pen1.Alignment = PenAlignment.Inset;
                    g.DrawRectangle(pen1, 0, 0, img.Width + lineWidth * 2, img.Height + lineWidth * 2);
                }

                using (Pen pen2 = new Pen(Color.White, lineWidth))
                {
                    pen2.Alignment = PenAlignment.Inset;
                    pen2.DashPattern = new float[] { 3, 3 };
                    g.DrawRectangle(pen2, 0, 0, img.Width + lineWidth * 2, img.Height + lineWidth * 2);
                }
            }

            pbPreview.Image = bmpPreview;
        }

        private static Image DrawCheckers(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            using (Image checker = CreateCheckers(8, Color.LightGray, Color.White))
            using (Brush checkerBrush = new TextureBrush(checker, WrapMode.Tile))
            {
                g.FillRectangle(checkerBrush, new Rectangle(0, 0, bmp.Width, bmp.Height));
            }

            return bmp;
        }

        private static Image CreateCheckers(int size, Color color1, Color color2)
        {
            return CreateCheckers(size, size, color1, color2);
        }

        private static Image CreateCheckers(int width, int height, Color color1, Color color2)
        {
            Bitmap bmp = new Bitmap(width * 2, height * 2);

            using (Graphics g = Graphics.FromImage(bmp))
            using (Brush brush1 = new SolidBrush(color1))
            using (Brush brush2 = new SolidBrush(color2))
            {
                g.FillRectangle(brush1, 0, 0, width, height);
                g.FillRectangle(brush1, width, height, width, height);
                g.FillRectangle(brush2, width, 0, width, height);
                g.FillRectangle(brush2, 0, height, width, height);
            }

            return bmp;
        }
    }
}