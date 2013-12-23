using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

[assembly: DebuggerVisualizer(typeof(ImageVisualizer.ImageVisualizer), typeof(VisualizerObjectSource), Target = typeof(Image), Description = "Image Visualizer")]

namespace ImageVisualizer
{
    public class ImageVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            Image img = objectProvider.GetObject() as Image;

            if (img != null)
            {
                ImageVisualizerForm form = new ImageVisualizerForm(img);
                form.ShowDialog();
            }
        }
    }
}