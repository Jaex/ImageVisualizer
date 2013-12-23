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
        private Image previewImage, backgroundImage;
        private int offset = 1;

        public ImageVisualizerForm(Image img)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            Text = string.Format("Image Visualizer - Width: {0}, Height: {1}, Type: {2}", img.Width, img.Height, img.GetType().Name);
            previewImage = img;
            backgroundImage = DrawCheckers(previewImage.Width, previewImage.Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.DrawRectangle(Pens.Black, offset, offset, previewImage.Width + 1, previewImage.Height + 1);
            g.DrawImage(backgroundImage, offset + 1, offset + 1, previewImage.Width, previewImage.Height);
            g.DrawImage(previewImage, offset + 1, offset + 1, previewImage.Width, previewImage.Height);
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