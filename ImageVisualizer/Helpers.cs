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

using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageVisualizer
{
    public static class Helpers
    {
        public static void CopyImage(Image img)
        {
            if (img != null)
            {
                Clipboard.SetImage(img);
            }
        }

        public static string SaveImageAsFile(Image img)
        {
            if (img != null)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.DefaultExt = "png";
                    sfd.Filter = "PNG (*.png)|*.png|JPEG (*.jpg, *.jpeg, *.jpe, *.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|GIF (*.gif)|*.gif|BMP (*.bmp)|*.bmp|TIFF (*.tif, *.tiff)|*.tif;*.tiff";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = sfd.FileName;

                        if (!string.IsNullOrEmpty(filePath))
                        {
                            ImageFormat imageFormat = GetImageFormat(filePath);
                            img.Save(filePath, imageFormat);
                            return filePath;
                        }
                    }
                }
            }

            return null;
        }

        private static ImageFormat GetImageFormat(string filePath)
        {
            ImageFormat imageFormat = ImageFormat.Png;

            string ext = GetFilenameExtension(filePath);

            if (!string.IsNullOrEmpty(ext))
            {
                switch (ext)
                {
                    default:
                    case "png":
                        imageFormat = ImageFormat.Png;
                        break;
                    case "jpg":
                    case "jpeg":
                    case "jpe":
                    case "jfif":
                        imageFormat = ImageFormat.Jpeg;
                        break;
                    case "gif":
                        imageFormat = ImageFormat.Gif;
                        break;
                    case "bmp":
                        imageFormat = ImageFormat.Bmp;
                        break;
                    case "tif":
                    case "tiff":
                        imageFormat = ImageFormat.Tiff;
                        break;
                }
            }

            return imageFormat;
        }

        // Extension without dot
        private static string GetFilenameExtension(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                int pos = filePath.LastIndexOf('.');

                if (pos >= 0)
                {
                    return filePath.Substring(pos + 1).ToLowerInvariant();
                }
            }

            return null;
        }
    }
}