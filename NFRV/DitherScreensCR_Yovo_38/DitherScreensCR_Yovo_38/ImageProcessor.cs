using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DitherScreensCR_Yovo_38
{
    class ImageProcessor : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        internal Bitmap InMap { get; private set; }
        internal Bitmap DritherMatrixInMap { get; private set; }
        internal Bitmap OutMap { get; private set; }

        private readonly int[,] ditherMatrix;
        //private Graphics graphics;
        private const int colorLimit = 255;
        private const int byteSize = 256;
        private int[] histogram;

        private string text;
        internal void SetText(string text) => this.text = text;


        private readonly int containerHeight;

        public ImageProcessor()
        {
            ditherMatrix = new int[,] { { 0, 1 }, { 3, 2 } };
        }

        public ImageProcessor(Panel container)
        {
            //this.graphics = container.CreateGraphics();
            this.containerHeight = container.Height;
        }

        private int Approximate(int intesity) => intesity > 0 && intesity < 63 ? 0 :
                                              intesity >= 63 && intesity < 127 ? 63 :
                                              intesity >= 127 && intesity < 191 ? 127 :
                                              intesity >= 191 && intesity < 255 ? 191 : 0;
        
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


        internal void LoadDitherMatrixImage(string fileName)
        {
            try
            {
                if (this.DritherMatrixInMap != null) this.DritherMatrixInMap.Dispose();
                this.DritherMatrixInMap = new Bitmap(Image.FromFile(fileName));
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        internal void DitheringProcess()
        {
            int k, m;
            Debug.Assert(this.InMap != null);
            if (this.OutMap != null) this.OutMap.Dispose();
            this.OutMap = new Bitmap(this.InMap);
            for (int w = 0; w < this.InMap.Width; w++)
                for (int h = 0; h < this.InMap.Height; h++)
                {
                    k = w % 2;
                    m = h % 2;
                    Color color ;
                    //if (Approximate(InMap.GetPixel(w, h).R) < this.ditherMatrix[k, m] )
                    if (Approximate(InMap.GetPixel(w, h).R) < Approximate(DritherMatrixInMap.GetPixel(w, h).R))
                    {
                        color = Color.White;
                    }
                    else
                    {
                        color = Color.Black;
                    }
                    
                    this.OutMap.SetPixel(w, h, color);
                }
        }

        internal void GrayScaleProcess()
        {
            Debug.Assert(this.InMap != null);
            if (this.OutMap != null) this.OutMap.Dispose();
            this.OutMap = new Bitmap(this.InMap);
            for (int i = 0; i < this.InMap.Width; i++)
                for (int j = 0; j < this.InMap.Height; j++)
                {
                    var color = this.InMap.GetPixel(i, j).R;
                    this.OutMap.SetPixel(i, j, Color.FromArgb(color, color, color));
                }
        }

        //internal void DiagramProcess()
        //{
        //    Debug.Assert(this.Bitmap != null);
        //    this.CreateHistogram();
        //    this.graphics.Clear(Color.White);
        //    var max = this.histogram[0];
        //    for (int i = 0; i < colorLimit; i++)
        //        if (this.histogram[i] > max)
        //            max = this.histogram[i];

        //    for (int i = 0; i < byteSize; i++)
        //    {
        //        double fact = this.containerHeight * this.histogram[i] * 1.0 / max;
        //        var r2 = Convert.ToInt32(fact);
        //        this.graphics.DrawLine(Pens.Blue, new Point(i, 0), new Point(i, r2));
        //    }
        //}

        //internal void CreateHistogram()
        //{
        //    Debug.Assert(this.Bitmap != null);
        //    this.histogram = new int[byteSize];
        //    for (int i = 0; i < byteSize; i++)
        //        this.histogram[i] = 0;

        //    for (int i = 0; i < this.Bitmap.Width; i++)
        //        for (int j = 0; j < this.Bitmap.Height; j++)
        //            this.histogram[this.Bitmap.GetPixel(i, j).R] += 1;
        //}

        bool disposed;

        public void Dispose()
        {
            if (disposed) return;
            disposed = true;
            //this.Bitmap.Dispose();
            this.InMap?.Dispose();
            this.OutMap?.Dispose();
        }
    }
}
