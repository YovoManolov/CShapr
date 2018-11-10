namespace Yovo_38_ex2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

       
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PB_Image = new System.Windows.Forms.PictureBox();
            this.loadImageId = new System.Windows.Forms.Button();
            this.patterningId = new System.Windows.Forms.Button();
            this.Quantization = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Image
            // 
            this.PB_Image.Location = new System.Drawing.Point(12, 3);
            this.PB_Image.Name = "PB_Image";
            this.PB_Image.Size = new System.Drawing.Size(783, 375);
            this.PB_Image.TabIndex = 0;
            this.PB_Image.TabStop = false;
            // 
            // loadImageId
            // 
            this.loadImageId.Location = new System.Drawing.Point(42, 396);
            this.loadImageId.Name = "loadImageId";
            this.loadImageId.Size = new System.Drawing.Size(140, 42);
            this.loadImageId.TabIndex = 1;
            this.loadImageId.Text = "Load Image";
            this.loadImageId.UseVisualStyleBackColor = true;
            this.loadImageId.Click += new System.EventHandler(this.OnLoadImage);
            // 
            // patterningId
            // 
            this.patterningId.Location = new System.Drawing.Point(272, 396);
            this.patterningId.Name = "patterningId";
            this.patterningId.Size = new System.Drawing.Size(140, 42);
            this.patterningId.TabIndex = 2;
            this.patterningId.Text = "Patterning";
            this.patterningId.UseVisualStyleBackColor = true;
            this.patterningId.Click += new System.EventHandler(this.OnPatterningProcess);
            // 
            // Quantization
            // 
            this.Quantization.Location = new System.Drawing.Point(507, 396);
            this.Quantization.Name = "Quantization";
            this.Quantization.Size = new System.Drawing.Size(140, 42);
            this.Quantization.TabIndex = 3;
            this.Quantization.Text = "Quantization";
            this.Quantization.UseVisualStyleBackColor = true;
            this.Quantization.Click += new System.EventHandler(this.OnQuantizationProcess);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Quantization);
            this.Controls.Add(this.patterningId);
            this.Controls.Add(this.loadImageId);
            this.Controls.Add(this.PB_Image);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Image;
        private System.Windows.Forms.Button loadImageId;
        private System.Windows.Forms.Button patterningId;
        private System.Windows.Forms.Button Quantization;
    }
}

