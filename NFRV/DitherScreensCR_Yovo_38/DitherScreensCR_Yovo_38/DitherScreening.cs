using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DitherScreensCR_Yovo_38
{
    public partial class DitherScreening : Form
    {
        ImageProcessor imageProcessor;
        public DitherScreening()
        {
            InitializeComponent();
            imageProcessor = new ImageProcessor();
        }

        private void ApplyImage(Bitmap image, bool setSize = false)
        {
            Debug.Assert(image != null);
            if (setSize)
            {
                PB_Image.Size = new Size(image.Width, image.Height);
                //this.PanelDisplay.Location = new Point(PB_Image.Top + image.Width, PB_Image.Top);
            }
            PB_Image.Image = image;
        }

        private void OnExit(object sender, EventArgs e) => this.Close();

        private void OnLoadImage(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    imageProcessor.LoadImage(fileDialog.FileName);
                    ApplyImage(this.imageProcessor.InMap, setSize: true);
                }
        }

        private void OnDitheringProcess(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                imageProcessor.LoadDitherMatrixImage(fileDialog.FileName);
            }
            imageProcessor.DitheringProcess();
            ApplyImage(imageProcessor.OutMap);
        }

        private void OnGrayScaleProcess(object sender, EventArgs e)
        {
            imageProcessor.GrayScaleProcess();
            ApplyImage(imageProcessor.OutMap);
        }
        
    }
}
