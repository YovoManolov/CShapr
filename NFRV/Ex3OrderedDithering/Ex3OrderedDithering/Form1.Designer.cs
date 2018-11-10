namespace Ex3OrderedDithering
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ditheringProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.originalReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScaleProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quantizationProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floydSteinbergProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagramProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizationProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizationDiagramProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PB_Image = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textScreeningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.ditheringProcessToolStripMenuItem,
            this.originalReturnToolStripMenuItem,
            this.grayScaleProcessToolStripMenuItem,
            this.quantizationProcessToolStripMenuItem,
            this.floydSteinbergProcessToolStripMenuItem,
            this.diagramProcessToolStripMenuItem,
            this.equalizationProcessToolStripMenuItem,
            this.equalizationDiagramProcessToolStripMenuItem,
            this.textScreeningToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.loadImageToolStripMenuItem.Text = "Load Image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.OnLoadImage);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExit);
            // 
            // ditheringProcessToolStripMenuItem
            // 
            this.ditheringProcessToolStripMenuItem.Name = "ditheringProcessToolStripMenuItem";
            this.ditheringProcessToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.ditheringProcessToolStripMenuItem.Text = "Dithering Process";
            this.ditheringProcessToolStripMenuItem.Click += new System.EventHandler(this.OnDitheringProcess);
            // 
            // originalReturnToolStripMenuItem
            // 
            this.originalReturnToolStripMenuItem.Name = "originalReturnToolStripMenuItem";
            this.originalReturnToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.originalReturnToolStripMenuItem.Text = "Original return";
            this.originalReturnToolStripMenuItem.Click += new System.EventHandler(this.OnOriginalReturn);
            // 
            // grayScaleProcessToolStripMenuItem
            // 
            this.grayScaleProcessToolStripMenuItem.Name = "grayScaleProcessToolStripMenuItem";
            this.grayScaleProcessToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.grayScaleProcessToolStripMenuItem.Text = "Gray Scale Process";
            this.grayScaleProcessToolStripMenuItem.Click += new System.EventHandler(this.OnGrayScaleProcess);
            // 
            // quantizationProcessToolStripMenuItem
            // 
            this.quantizationProcessToolStripMenuItem.Name = "quantizationProcessToolStripMenuItem";
            this.quantizationProcessToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.quantizationProcessToolStripMenuItem.Text = "Quantization Process";
            this.quantizationProcessToolStripMenuItem.Click += new System.EventHandler(this.OnQuantizationProcess);
            // 
            // floydSteinbergProcessToolStripMenuItem
            // 
            this.floydSteinbergProcessToolStripMenuItem.Name = "floydSteinbergProcessToolStripMenuItem";
            this.floydSteinbergProcessToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.floydSteinbergProcessToolStripMenuItem.Text = "Floyd Steinberg Process";
            this.floydSteinbergProcessToolStripMenuItem.Click += new System.EventHandler(this.OnFloydSteinbergProcess);
            // 
            // diagramProcessToolStripMenuItem
            // 
            this.diagramProcessToolStripMenuItem.Name = "diagramProcessToolStripMenuItem";
            this.diagramProcessToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.diagramProcessToolStripMenuItem.Text = "Diagram Process";
            this.diagramProcessToolStripMenuItem.Click += new System.EventHandler(this.OnDiagramProcess);
            // 
            // equalizationProcessToolStripMenuItem
            // 
            this.equalizationProcessToolStripMenuItem.Name = "equalizationProcessToolStripMenuItem";
            this.equalizationProcessToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.equalizationProcessToolStripMenuItem.Text = "Equalization Process";
            this.equalizationProcessToolStripMenuItem.Click += new System.EventHandler(this.OnEqualizationProcess);
            // 
            // equalizationDiagramProcessToolStripMenuItem
            // 
            this.equalizationDiagramProcessToolStripMenuItem.Name = "equalizationDiagramProcessToolStripMenuItem";
            this.equalizationDiagramProcessToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.equalizationDiagramProcessToolStripMenuItem.Text = "Equalization  Diagram Process";
            this.equalizationDiagramProcessToolStripMenuItem.Click += new System.EventHandler(this.OnEqualizationDiagramProcess);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // PB_Image
            // 
            this.PB_Image.Location = new System.Drawing.Point(13, 46);
            this.PB_Image.Name = "PB_Image";
            this.PB_Image.Size = new System.Drawing.Size(464, 325);
            this.PB_Image.TabIndex = 1;
            this.PB_Image.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(494, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textScreeningToolStripMenuItem
            // 
            this.textScreeningToolStripMenuItem.Name = "textScreeningToolStripMenuItem";
            this.textScreeningToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.textScreeningToolStripMenuItem.Text = "Text Screening";
            this.textScreeningToolStripMenuItem.Click += new System.EventHandler(this.OnTextScreeningProcess);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.PB_Image);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ditheringProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem originalReturnToolStripMenuItem;
        private System.Windows.Forms.PictureBox PB_Image;
        private System.Windows.Forms.ToolStripMenuItem grayScaleProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quantizationProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floydSteinbergProcessToolStripMenuItem;
        //private System.Windows.Forms.Panel PanelDisplay;
        private System.Windows.Forms.ToolStripMenuItem diagramProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalizationProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalizationDiagramProcessToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem textScreeningToolStripMenuItem;
    }
}

