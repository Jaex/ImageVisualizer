namespace ImageVisualizer
{
    partial class ImageVisualizerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageVisualizerForm));
            this.tscMain = new System.Windows.Forms.ToolStripContainer();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsddbZoom = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiZoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiZoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiZoom300 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiZoom400 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiZoom500 = new System.Windows.Forms.ToolStripMenuItem();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.tsbCopyImage = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveImage = new System.Windows.Forms.ToolStripButton();
            this.tscMain.ContentPanel.SuspendLayout();
            this.tscMain.TopToolStripPanel.SuspendLayout();
            this.tscMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // tscMain
            // 
            // 
            // tscMain.ContentPanel
            // 
            this.tscMain.ContentPanel.Controls.Add(this.pbPreview);
            this.tscMain.ContentPanel.Size = new System.Drawing.Size(584, 436);
            this.tscMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscMain.Location = new System.Drawing.Point(0, 0);
            this.tscMain.Name = "tscMain";
            this.tscMain.Size = new System.Drawing.Size(584, 461);
            this.tscMain.TabIndex = 1;
            this.tscMain.Text = "toolStripContainer1";
            // 
            // tscMain.TopToolStripPanel
            // 
            this.tscMain.TopToolStripPanel.Controls.Add(this.tsMain);
            // 
            // tsMain
            // 
            this.tsMain.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbZoom,
            this.tsbCopyImage,
            this.tsbSaveImage});
            this.tsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsMain.Location = new System.Drawing.Point(3, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(398, 25);
            this.tsMain.TabIndex = 0;
            // 
            // tsddbZoom
            // 
            this.tsddbZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiZoom100,
            this.tsmiZoom200,
            this.tsmiZoom300,
            this.tsmiZoom400,
            this.tsmiZoom500});
            this.tsddbZoom.Image = global::ImageVisualizer.Properties.Resources.magnifier;
            this.tsddbZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbZoom.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tsddbZoom.Name = "tsddbZoom";
            this.tsddbZoom.Size = new System.Drawing.Size(102, 22);
            this.tsddbZoom.Text = "Zoom: 100%";
            // 
            // tsmiZoom100
            // 
            this.tsmiZoom100.Name = "tsmiZoom100";
            this.tsmiZoom100.Size = new System.Drawing.Size(152, 22);
            this.tsmiZoom100.Text = "100%";
            this.tsmiZoom100.Click += new System.EventHandler(this.tsmiZoom100_Click);
            // 
            // tsmiZoom200
            // 
            this.tsmiZoom200.Name = "tsmiZoom200";
            this.tsmiZoom200.Size = new System.Drawing.Size(152, 22);
            this.tsmiZoom200.Text = "200%";
            this.tsmiZoom200.Click += new System.EventHandler(this.tsmiZoom200_Click);
            // 
            // tsmiZoom300
            // 
            this.tsmiZoom300.Name = "tsmiZoom300";
            this.tsmiZoom300.Size = new System.Drawing.Size(152, 22);
            this.tsmiZoom300.Text = "300%";
            this.tsmiZoom300.Click += new System.EventHandler(this.tsmiZoom300_Click);
            // 
            // tsmiZoom400
            // 
            this.tsmiZoom400.Name = "tsmiZoom400";
            this.tsmiZoom400.Size = new System.Drawing.Size(152, 22);
            this.tsmiZoom400.Text = "400%";
            this.tsmiZoom400.Click += new System.EventHandler(this.tsmiZoom400_Click);
            // 
            // tsmiZoom500
            // 
            this.tsmiZoom500.Name = "tsmiZoom500";
            this.tsmiZoom500.Size = new System.Drawing.Size(152, 22);
            this.tsmiZoom500.Text = "500%";
            this.tsmiZoom500.Click += new System.EventHandler(this.tsmiZoom500_Click);
            // 
            // pbPreview
            // 
            this.pbPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPreview.Location = new System.Drawing.Point(0, 0);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(400, 300);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            // 
            // tsbCopyImage
            // 
            this.tsbCopyImage.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopyImage.Image")));
            this.tsbCopyImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopyImage.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tsbCopyImage.Name = "tsbCopyImage";
            this.tsbCopyImage.Size = new System.Drawing.Size(158, 22);
            this.tsbCopyImage.Text = "Copy image to clipboard";
            this.tsbCopyImage.Click += new System.EventHandler(this.tsbCopyImage_Click);
            // 
            // tsbSaveImage
            // 
            this.tsbSaveImage.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveImage.Image")));
            this.tsbSaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveImage.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tsbSaveImage.Name = "tsbSaveImage";
            this.tsbSaveImage.Size = new System.Drawing.Size(129, 22);
            this.tsbSaveImage.Text = "Save image as file...";
            this.tsbSaveImage.Click += new System.EventHandler(this.tsbSaveImage_Click);
            // 
            // ImageVisualizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.tscMain);
            this.MinimizeBox = false;
            this.Name = "ImageVisualizerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Visualizer";
            this.TopMost = true;
            this.tscMain.ContentPanel.ResumeLayout(false);
            this.tscMain.ContentPanel.PerformLayout();
            this.tscMain.TopToolStripPanel.ResumeLayout(false);
            this.tscMain.TopToolStripPanel.PerformLayout();
            this.tscMain.ResumeLayout(false);
            this.tscMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.ToolStripContainer tscMain;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbCopyImage;
        private System.Windows.Forms.ToolStripButton tsbSaveImage;
        private System.Windows.Forms.ToolStripDropDownButton tsddbZoom;
        private System.Windows.Forms.ToolStripMenuItem tsmiZoom100;
        private System.Windows.Forms.ToolStripMenuItem tsmiZoom200;
        private System.Windows.Forms.ToolStripMenuItem tsmiZoom300;
        private System.Windows.Forms.ToolStripMenuItem tsmiZoom400;
        private System.Windows.Forms.ToolStripMenuItem tsmiZoom500;
    }
}