#region License Information (GPL v3)

/*
    Copyright (c) Jaex

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageVisualizer
{
    public partial class ImageVisualizerForm : Form
    {
        private const int MaxZoom = 10;

        private int zoom = 1;

        public int Zoom
        {
            get
            {
                return zoom;
            }
            private set
            {
                int tempZoom = value.Between(1, MaxZoom);

                if (tempZoom != zoom)
                {
                    zoom = tempZoom;

                    UpdatePreview();
                }
            }
        }

        private Image image;

        public ImageVisualizerForm(Image img)
        {
            InitializeComponent();
            image = img;
            UpdateControls();
        }

        private void UpdateControls()
        {
            tsddbZoom.HideImageMargin();

            for (int i = 0; i < MaxZoom; i++)
            {
                int currentZoom = i + 1;
                ToolStripMenuItem tsmi = new ToolStripMenuItem(currentZoom * 100 + "%");
                tsmi.Click += (sender, e) => Zoom = currentZoom;
                tsddbZoom.DropDownItems.Add(tsmi);
            }

            UpdatePreview();
        }

        private void UpdatePreview()
        {
            UpdatePreview(image);
        }

        private void UpdatePreview(Image img)
        {
            tsddbZoom.Text = $"Zoom: {Zoom * 100}%";

            if (img == null)
            {
                return;
            }

            tsslStatusWidth.Text = $"Width: {img.Width}px";
            tsslStatusHeight.Text = $"Height: {img.Height}px";
            tsslStatusPixelFormat.Text = $"Pixel format: {img.PixelFormat}";
            tsslStatusType.Text = $"Type: {img.GetType().Name}";

            int lineSize = 2;
            int previewWidth = img.Width * Zoom;
            int previewHeight = img.Height * Zoom;

            Bitmap bmpPreview = new Bitmap(previewWidth + lineSize * 2, previewHeight + lineSize * 2, PixelFormat.Format24bppRgb);

            using (Graphics g = Graphics.FromImage(bmpPreview))
            {
                if (img.PixelFormat == PixelFormat.Format32bppArgb)
                {
                    using (Image checkers = DrawCheckers(previewWidth, previewHeight))
                    {
                        g.DrawImage(checkers, lineSize, lineSize, checkers.Width, checkers.Height);
                    }
                }

                g.DrawRectangle(Pens.White, 0, 0, bmpPreview.Width - 1, bmpPreview.Height - 1);
                g.DrawRectangle(Pens.Black, 1, 1, bmpPreview.Width - 3, bmpPreview.Height - 3);

                if (Zoom > 1)
                {
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                }

                g.DrawImage(img, lineSize, lineSize, previewWidth, previewHeight);
            }

            if (pbPreview.Image != null)
            {
                pbPreview.Image.Dispose();
            }

            pbPreview.Image = bmpPreview;
        }

        private void tsbCopyImage_Click(object sender, EventArgs e)
        {
            Helpers.CopyImage(image);
        }

        private void tsbSaveImage_Click(object sender, EventArgs e)
        {
            Helpers.SaveImageAsFile(image);
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