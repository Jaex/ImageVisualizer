using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImageVisualizerTest
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            string filePath = OpenImageFileDialog();

            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                Image img = Image.FromFile(filePath);
                Console.WriteLine("Image width: {0}, height: {1}", img.Width, img.Height);
                if (Debugger.IsAttached) Debugger.Break();
            }
        }

        private static string OpenImageFileDialog()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image files (*.png, *.jpg, *.jpeg, *.jpe, *.jfif, *.gif, *.bmp, *.tif, *.tiff)|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.bmp;*.tif;*.tiff|" +
                    "PNG (*.png)|*.png|JPEG (*.jpg, *.jpeg, *.jpe, *.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|GIF (*.gif)|*.gif|BMP (*.bmp)|*.bmp|TIFF (*.tif, *.tiff)|*.tif;*.tiff|" +
                    "All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }
            }

            return null;
        }
    }
}