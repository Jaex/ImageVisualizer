using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageVisualizer
{
    public partial class ImageVisualizerForm : Form
    {
        private int zoom;

        public int Zoom
        {
            get
            {
                return zoom;
            }
            private set
            {
                zoom = Between(value, 1, maxZoom);
            }
        }

        private Image image;
        private int maxZoom = 5;

        public ImageVisualizerForm(Image img)
        {
            InitializeComponent();
            Zoom = 1;
            image = img;
            SetPreview(image, Zoom);
        }

        private void SetPreview(Image img, int zoom = 1)
        {
            string title = string.Format("Image Visualizer - Width: {0}, Height: {1}, Type: {2}", img.Width, img.Height, img.GetType().Name);

            if (zoom > 1)
            {
                title += string.Format(", Zoom: {0}%", zoom * 100);
            }

            Text = title;

            int lineWidth = 2;
            int previewWidth = img.Width * zoom;
            int previewHeight = img.Height * zoom;

            Bitmap bmpPreview = new Bitmap(previewWidth + lineWidth * 2, previewHeight + lineWidth * 2, PixelFormat.Format24bppRgb);

            using (Graphics g = Graphics.FromImage(bmpPreview))
            {
                if (img.PixelFormat == PixelFormat.Format32bppArgb)
                {
                    using (Image checkers = DrawCheckers(previewWidth, previewHeight))
                    {
                        g.DrawImage(checkers, lineWidth, lineWidth, checkers.Width, checkers.Height);
                    }
                }

                g.DrawRectangle(Pens.White, 0, 0, bmpPreview.Width - 1, bmpPreview.Height - 1);
                g.DrawRectangle(Pens.Black, 1, 1, bmpPreview.Width - 3, bmpPreview.Height - 3);

                if (zoom > 1)
                {
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                }

                g.DrawImage(img, lineWidth, lineWidth, previewWidth, previewHeight);
            }

            if (pbPreview.Image != null)
            {
                pbPreview.Image.Dispose();
            }

            pbPreview.Image = bmpPreview;
        }

        private void pbPreview_MouseDown(object sender, MouseEventArgs e)
        {
            int previousZoom = Zoom;

            if (e.Button == MouseButtons.Left)
            {
                Zoom++;
            }
            else if (e.Button == MouseButtons.Right)
            {
                Zoom--;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                Zoom = 1;
            }

            if (Zoom != previousZoom)
            {
                SetPreview(image, Zoom);
            }
        }

        private static int Between(int num, int min, int max)
        {
            return Math.Max(min, Math.Min(max, num));
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