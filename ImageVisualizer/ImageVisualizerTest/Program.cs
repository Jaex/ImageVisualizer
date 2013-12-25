using ImageVisualizerTest.Properties;
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
            Image imageTest = ImageFromResource();

            if (imageTest != null)
            {
                Console.WriteLine("Width: {0}, Height: {1}, Type: {2}", imageTest.Width, imageTest.Height, imageTest.GetType().Name);

                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
            }
        }

        private static Image ImageFromResource()
        {
            return Resources.Test;
        }

        private static Image ImageFromFile()
        {
            string filePath = OpenImageFileDialog();

            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                return Image.FromFile(filePath);
            }

            return null;
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