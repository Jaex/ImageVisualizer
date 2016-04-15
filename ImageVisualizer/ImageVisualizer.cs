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

using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

[assembly: DebuggerVisualizer(typeof(ImageVisualizer.ImageVisualizer), typeof(VisualizerObjectSource), Target = typeof(Image), Description = "Image Visualizer")]

namespace ImageVisualizer
{
    public class ImageVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService service, IVisualizerObjectProvider provider)
        {
            Image img = provider.GetObject() as Image;

            if (img != null)
            {
                try
                {
                    using (ImageVisualizerForm form = new ImageVisualizerForm(img))
                    {
                        form.ShowDialog();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Image Visualizer error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}