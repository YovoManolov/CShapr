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

namespace Yovo_38_ex2
{
    public partial class Form1 : Form
    {
        ImageProcessor imageProcessor;
        public Form1()
        {
            InitializeComponent();
            imageProcessor = new ImageProcessor();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ApplyImage(bool setSize = false)
        {
            if (setSize)
                PB_Image.Size = new Size(imageProcessor.Width, imageProcessor.Height);
            PB_Image.Image = imageProcessor.Bitmap;
            
        }

        private void OnLoadImage(object sender, EventArgs e)
        {
            using (var fileDialg = new OpenFileDialog())
            {
                if (fileDialg.ShowDialog() == DialogResult.OK)
                {
                    imageProcessor.LoadImageData(fileDialg.FileName);
                    ApplyImage(true);
                }
            }
        }

        private void OnQuantizationProcess(object sender, EventArgs e)
        {
            imageProcessor.QuantizationProcess();
            ApplyImage();
        }

        private void OnPatterningProcess(object sender, EventArgs e)
        {
            imageProcessor.PatterningProcess();
            ApplyImage();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();

            }
            base.Dispose(disposing);
        }

        class ImageProcessor : IDisposable
        {
            private String fileName;
            public Bitmap Bitmap { get; private set; }
            public int Width
            {
                get
                {
                    Debug.Assert(this.Bitmap != null);
                    return this.Bitmap.Width;
                }
            }
            public int Height
            {
                get
                {
                    Debug.Assert(this.Bitmap != null);
                    return this.Bitmap.Height;
                }
            }

            private const int byteSize = 255;
            private const int matrixN = 2;
            private const double step = byteSize / 4.0;

            internal void LoadImageData(string fName)
            {
                try
                {
                    if (this.Bitmap != null) this.Bitmap.Dispose();
                    this.Bitmap = new Bitmap(this.fileName = fName);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }

            internal void PatterningProcess()
            {
                double sum;
                for (int i = 0; i < this.Width; i = i + matrixN)
                {
                    for (int j = 0; j < this.Height; j = j + matrixN)
                    {
                        sum = 0;
                        int pixelCount = 0;
                        for (int k = i; k < i + matrixN; k++)
                            for (int m = j; m < j + matrixN; m++)
                            {
                                if (k >= this.Width || m >= this.Height) continue;
                                sum += this.Bitmap.GetPixel(k, m).R;
                                pixelCount++;
                            }
                        if (pixelCount > 0)
                                    sum /= pixelCount;
                        var colorMatrix = sum == byteSize ?
                            new Color[,] { { Color.White, Color.White }, { Color.White, Color.White } } :
                                                sum >= 3 * step && sum < byteSize ?
                            new Color[,] { { Color.White, Color.Black }, { Color.White, Color.White } } :
                                                sum >= 2 * step && sum < 3 * step ?
                            new Color[,] { { Color.White, Color.Black }, { Color.Black, Color.White } } :
                                                sum >= step && sum < 2 * step ?
                            new Color[,] { { Color.White, Color.Black }, { Color.Black, Color.Black } } :
                                                sum >= 0.0 && sum < step ?
                            new Color[,] { { Color.Black, Color.Black }, { Color.Black, Color.Black } } :
                                                null;

                        Debug.Assert(colorMatrix != null);
                        FillMatrix(i, j, colorMatrix);
                    }
                }
            }

            private void FillMatrix(int wIndex, int hIndex, Color[,] colors)
            {
                this.Bitmap.SetPixel(wIndex, hIndex, colors[0, 0]);
                if (hIndex + 1 < this.Height)
                    this.Bitmap.SetPixel(wIndex, hIndex + 1, colors[0, 1]);
                if (wIndex + 1 < this.Width)
                    this.Bitmap.SetPixel(wIndex + 1, hIndex, colors[1, 0]);
                if (wIndex + 1 < this.Width && hIndex + 1 < this.Height)
                    this.Bitmap.SetPixel(wIndex +1, hIndex + 1, colors[1, 1]);
            }

            internal void QuantizationProcess()
            {
                for (int i = 0; i < this.Width; i++)
                {
                    for (int j = 0; j < this.Height; j++)
                    {
                        if (this.Bitmap.GetPixel(i, j).R < 127)
                        {
                            this.Bitmap.SetPixel(i, j, Color.Black);
                        }
                        else
                        {
                            this.Bitmap.SetPixel(i, j, Color.White);
                        }
                    }
                }
            }

            bool disposed;
            public void Dispose()
            {
                if (disposed) return;
                disposed = true;
                this.Bitmap?.Dispose();
                this.fileName = null;
            }
        }
    }
}
