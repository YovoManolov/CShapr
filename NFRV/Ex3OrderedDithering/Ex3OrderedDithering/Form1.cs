using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex3OrderedDithering
{
    public partial class Form1 : Form
    {
        ImageProcessor imageProcessor;
        public Form1()
        {
            InitializeComponent();
            //imageProcessor = new ImageProcessor(this.PanelDisplay);
            imageProcessor = new ImageProcessor();
            this.textBox1.LostFocus += (s, e) => this.imageProcessor.SetText(this.textBox1.Text);
        }

        //private void OnLoadImage(object sender, EventArgs e)
        //{
        //    using (var fileDialog = new OpenFileDialog())
        //    {
        //        if (fileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            imageProcessor.LoadImage(fileDialog.FileName);
        //            //ApplyImage(this.imageProcessor.Bitmap, setSize: true);
        //            ApplyImage(this.imageProcessor.InMap, setSize: true);
        //        }
        //    }
        //}

        private void OnLoadImage(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    imageProcessor.LoadImage(fileDialog.FileName);
                    ApplyImage(this.imageProcessor.InMap, setSize: true);
                }
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

        private void OnDitheringProcess(object sender, EventArgs e)
        {
            imageProcessor.DitheringProcess();
            ApplyImage(imageProcessor.OutMap);
        }

        private void OnGrayScaleProcess(object sender, EventArgs e)
        {
            imageProcessor.GrayScaleProcess();
            ApplyImage(imageProcessor.Bitmap);
        }

        private void OnQuantizationProcess(object sender, EventArgs e)
        {
            imageProcessor.QuantizationProcess();
            ApplyImage(imageProcessor.OutMap);
        }

        private void OnFloydSteinbergProcess(object sender, EventArgs e)
        {
            imageProcessor.FloydSteinbergProcess();
            ApplyImage(imageProcessor.OutMap);
        }

        private void OnOriginalReturn(object sender, EventArgs e) 
                            => ApplyImage(imageProcessor.InMap);

        private void OnDiagramProcess(object sender, EventArgs e) 
                         => this.imageProcessor.DiagramProcess();

        private void OnEqualizationProcess(object sender, EventArgs e)
        {
            imageProcessor.EqualizationProcess();
            ApplyImage(imageProcessor.Bitmap);
        }

        private void OnEqualizationDiagramProcess(object sender, EventArgs e) 
            => this.imageProcessor.EqualizationDiagramProcess();

        private void OnTextScreeningProcess(object sender, EventArgs e)
        {
            if (imageProcessor.TextScreeningProcess()) ApplyImage(imageProcessor.OutMap);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                imageProcessor.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
        
        class ImageProcessor : IDisposable
        {
            public Bitmap Bitmap { get; private set; }
            internal Bitmap InMap { get; private set; }
            internal Bitmap OutMap { get; private set; }

            private readonly int[,] ditherMatrix;
            private const int colorLimit = 255;
            private const int byteSize = 256;
            private int[] histogram;
            private double[] eqHistogram;

            private const int matrix = 5;
            private Graphics graphics;
            private string text;
            internal void SetText(string text) => this.text = text;
         

            private readonly int containerHeight;
            

            public ImageProcessor()
            {
                ditherMatrix = new int[,] { { 0, 1 }, { 3, 2 } };
            }

            public ImageProcessor(Panel container)
            {
                this.graphics = container.CreateGraphics();
                this.containerHeight = container.Height;
            }
            private int Approximate(int intesity) => intesity > 0 && intesity < 63 ? 0 :
                                                  intesity >= 63 && intesity < 127 ? 63 :
                                                  intesity >= 127 && intesity < 191 ? 127 :
                                                  intesity >= 191 && intesity< 255 ? 191 : 0;

            private static int getCount(char[] symbols, int c) => c < symbols.Length - 1 ? c + 1 : 0;

            private static int GetFontSize(int intensity) => intensity >= 0 && intensity < 63  ? 14 :
                                                                intensity >= 63 && intensity < 127 ? 12 :
                                                                intensity >= 127 && intensity < 190 ? 10 :
                                                                intensity >= 190? 8 : -1;



            internal void LoadImage(string fileName)
            {
                try
                {
                    if (this.InMap != null) this.InMap.Dispose();
                    this.InMap = new Bitmap(Image.FromFile(fileName));
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }

            //internal void LoadImage(string fileName)
            //{
            //    try
            //    {
            //        if (this.Bitmap != null) this.Bitmap.Dispose();
            //        this.Bitmap = new Bitmap(Image.FromFile(fileName));
            //    }
            //    catch (Exception error)
            //    {
            //        MessageBox.Show(error.Message);
            //    }
            //}
            internal void DitheringProcess()
            {
                int k, m;
                Debug.Assert(this.InMap != null);
                if (this.OutMap != null) this.OutMap.Dispose();
                this.OutMap = new Bitmap(this.InMap);
                for (int i = 0; i < this.InMap.Width; i++)
                    for (int j = 0; j < this.InMap.Height; j++)
                    {
                        k = i % 2;
                        m = j % 2;
                        var color = Approximate(this.OutMap.GetPixel(i, j).R)
                               < this.ditherMatrix[k, m] ? Color.White : Color.Black;
                        this.OutMap.SetPixel(i, j, color);
                    }

            }

            internal bool TextScreeningProcess()
            {
                Debug.Assert(this.InMap != null);
                if (string.IsNullOrEmpty(this.text))
                {
                    MessageBox.Show("Please, enter text for screening!");
                    return false;
                }

                var symbols = text.ToUpper().Replace(" ", string.Empty).ToCharArray();
                this.OutMap = new Bitmap(this.InMap.Width, this.InMap.Height);
                this.graphics = Graphics.FromImage(this.OutMap);
                this.graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
                for(int j = 0; j< this.InMap.Height; j+= matrix)
                {
                    var charCount = 0;
                    for (int i = 0; i < this.InMap.Width; i+= matrix)
                        {
                            var pixelIntensity= this.InMap.GetPixel(i,j).R;
                            var fontSize = GetFontSize(pixelIntensity);
                            Debug.Assert(fontSize != -1);

                        using (var font = new Font("Arial", fontSize, FontStyle.Regular,GraphicsUnit.Pixel))
                        this.graphics.DrawString(symbols[charCount].ToString(), font, Brushes.Black, i, j);

                        charCount = getCount(symbols, charCount);
                    }
                }

                return true;
            }

            //internal void GrayScaleProcess()
            //{
            //    Debug.Assert(this.InMap != null);
            //    for (int i = 0; i < this.InMap.Width; i++)
            //        for (int j = 0; j < this.InMap.Height; j++)
            //        {
            //            int r = this.InMap.GetPixel(i, j).R;
            //            var color = Color.FromArgb(r, r, r);
            //            this.InMap.SetPixel(i, j, color);
            //        }
            //}

            internal void GrayScaleProcess()
            {
                Debug.Assert(this.Bitmap != null);
                for (int i = 0; i < this.Bitmap.Width; i++)
                    for (int j = 0; j < this.Bitmap.Height; j++)
                    {
                        var color = this.Bitmap.GetPixel(i, j).R;
                        this.Bitmap.SetPixel(i, j, Color.FromArgb(color,color,color));
                    }
            }

            internal void QuantizationProcess()
            {
                Debug.Assert(this.InMap != null);
                if (this.OutMap != null) this.OutMap.Dispose();
                this.OutMap = new Bitmap(this.InMap.Width,this.InMap.Height);
                for (int i = 0; i < this.InMap.Width; i++)
                    for (int j = 0; j < this.InMap.Height; j++)
                    {
                        int r = this.InMap.GetPixel(i, j).R;
                        int appr = this.Approximate(r);
                        this.OutMap.SetPixel(i, j, Color.FromArgb(appr, appr, appr));
                    }
            }

            internal void FloydSteinbergProcess()
            {
                Debug.Assert(this.InMap != null);
                int r, r1,r2, r3, r4,error,
                    size = this.InMap.Width > this.InMap.Height?
                            this.InMap.Height : this.InMap.Width;

                if (this.OutMap != null) this.OutMap.Dispose();
                this.OutMap = new Bitmap(size,size);

                for (int i = size-2; i  > 0; i--)
                    for (int j = 1; j < size - 1; j++)
                    {
                        int c = this.InMap.GetPixel(i, j).R;
                        r = Approximate(c);
                        this.OutMap.SetPixel(i, j, Color.FromArgb(r, r, r));
                        error = c - r;

                        r1 = this.InMap.GetPixel(i, j + 1).R + 7 * error / 16;
                        r2 = this.InMap.GetPixel(i + 1, j - 1).R + 3 * error / 16;
                        r3 = this.InMap.GetPixel(i + 1, j ).R + 5 * error / 16;
                        r4 = this.InMap.GetPixel(i + 1, j + 1).R + 3 * error / 16;

                        if (r1 >= colorLimit) r1 = colorLimit;
                        if (r2 >= colorLimit) r2 = colorLimit;
                        if (r3 >= colorLimit) r3 = colorLimit;
                        if (r4 >= colorLimit) r4 = colorLimit;

                        this.OutMap.SetPixel(i, j, Color.FromArgb(r1, r1, r1));
                        this.OutMap.SetPixel(i, j, Color.FromArgb(r2, r2, r2));
                        this.OutMap.SetPixel(i, j, Color.FromArgb(r3, r3, r3));
                        this.OutMap.SetPixel(i, j, Color.FromArgb(r4, r4, r4));
                    }
            }

            internal void CreateHistogram()
            {
                Debug.Assert(this.Bitmap != null);
                    this.histogram = new int[byteSize];
                    for(int i= 0; i < byteSize; i++)
                        this.histogram[i] = 0;

                    for (int i = 0; i < this.Bitmap.Width; i++)
                        for (int j = 0; j < this.Bitmap.Height; j++)
                                this.histogram[this.Bitmap.GetPixel(i,j).R] += 1;
            }

            internal void DiagramProcess()
            {
                Debug.Assert(this.Bitmap != null);
                this.CreateHistogram();
                this.graphics.Clear(Color.White);
                var max = this.histogram[0];
                for (int i = 0; i < colorLimit; i++)
                    if (this.histogram[i] > max)
                        max = this.histogram[i];

                for(int i = 0; i < byteSize; i++)
                {
                    double fact = this.containerHeight * this.histogram[i] * 1.0 / max;
                    var r2 = Convert.ToInt32(fact);
                    this.graphics.DrawLine(Pens.Blue, new Point(i, 0), new Point(i, r2));
                }
            }

            internal void EqualizationProcess()
            {
                Debug.Assert(this.Bitmap != null);
                //this.CreateHistogram();
                int p = this.Bitmap.Width * this.Bitmap.Height;
                this.eqHistogram = new double[byteSize];
                this.eqHistogram[0] = this.histogram[0];

                for (int i = 1; i < byteSize; i++)
                    this.eqHistogram[i] = this.eqHistogram[i - 1] + this.histogram[i];

                for (int i = 0; i < byteSize; i++)
                    this.eqHistogram[i] = this.eqHistogram[i] * 1.0 / p;


                for (int i = 0; i < this.Bitmap.Width; i++)
                    for (int j = 0; j < this.Bitmap.Height; j++)
                    {
                        var color = this.Bitmap.GetPixel(i, j).R;
                        var outColor = Convert.ToInt32(this.eqHistogram[color] * 255);
                        this.Bitmap.SetPixel(i, j, Color.FromArgb(outColor, outColor, outColor));
                    
                    }
            }

            internal void EqualizationDiagramProcess()
            {
                
                this.graphics.Clear(Color.White);
                var max = this.eqHistogram[0];

                for (int i = 1; i < colorLimit; i++)
                    if (this.eqHistogram[i] > max)
                        max = this.eqHistogram[i];

                for (int i = 0; i < byteSize; i++)
                {
                    double fact = this.containerHeight * this.eqHistogram[i] * 1.0 / max;
                    long r2 = Convert.ToInt64(fact);
                    this.graphics.DrawLine(Pens.Blue, new Point(i, 0), new Point(i, Convert.ToInt32(r2)));
                }
                    
               
            }

            bool disposed;

            public void Dispose()
            {
                if (disposed) return;
                disposed = true;
                this.Bitmap.Dispose();
                this.InMap?.Dispose();
                this.OutMap?.Dispose();
            }
        }
        
    }
}
