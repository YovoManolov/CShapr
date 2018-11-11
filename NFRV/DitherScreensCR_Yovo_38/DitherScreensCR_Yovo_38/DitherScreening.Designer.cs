namespace DitherScreensCR_Yovo_38
{
    partial class DitherScreening
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
            this.PB_Image = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ditherScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ditherScreenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screeningWitTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Image)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PB_Image
            // 
            this.PB_Image.Location = new System.Drawing.Point(120, 27);
            this.PB_Image.Name = "PB_Image";
            this.PB_Image.Size = new System.Drawing.Size(410, 332);
            this.PB_Image.TabIndex = 0;
            this.PB_Image.TabStop = false;
            this.PB_Image.Click += new System.EventHandler(this.PB_Image_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ditherScreenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(914, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ditherScreenToolStripMenuItem
            // 
            this.ditherScreenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.grayScaleToolStripMenuItem,
            this.ditherScreenToolStripMenuItem1,
            this.screeningWitTextToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.ditherScreenToolStripMenuItem.Name = "ditherScreenToolStripMenuItem";
            this.ditherScreenToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ditherScreenToolStripMenuItem.Text = "Menu";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.loadImageToolStripMenuItem.Text = "Load image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.OnLoadImage);
            // 
            // grayScaleToolStripMenuItem
            // 
            this.grayScaleToolStripMenuItem.Name = "grayScaleToolStripMenuItem";
            this.grayScaleToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.grayScaleToolStripMenuItem.Text = "Gray scale";
            this.grayScaleToolStripMenuItem.Click += new System.EventHandler(this.OnGrayScaleProcess);
            // 
            // ditherScreenToolStripMenuItem1
            // 
            this.ditherScreenToolStripMenuItem1.Name = "ditherScreenToolStripMenuItem1";
            this.ditherScreenToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.ditherScreenToolStripMenuItem1.Text = "Dither screen";
            this.ditherScreenToolStripMenuItem1.Click += new System.EventHandler(this.OnDitheringProcess);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExit);
            // 
            // screeningWitTextToolStripMenuItem
            // 
            this.screeningWitTextToolStripMenuItem.Name = "screeningWitTextToolStripMenuItem";
            this.screeningWitTextToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.screeningWitTextToolStripMenuItem.Text = "Screening wit text";
            // 
            // DitherScreening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 437);
            this.Controls.Add(this.PB_Image);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DitherScreening";
            this.Text = "Dither screening";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Image)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Image;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ditherScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ditherScreenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screeningWitTextToolStripMenuItem;
    }
}

