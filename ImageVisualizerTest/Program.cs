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

using ImageVisualizerTest.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageVisualizerTest
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Image testImage = GetImageFromResource();

            if (testImage != null)
            {
                Console.WriteLine("Width: {0}, Height: {1}, Type: {2}", testImage.Width, testImage.Height, testImage.GetType().Name);

                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
            }
        }

        private static Image GetImageFromResource()
        {
            return Resources.Test;
        }

        private static Image GetImageFromFile()
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