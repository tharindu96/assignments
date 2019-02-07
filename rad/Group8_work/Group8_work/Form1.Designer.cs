namespace Group8_work
{
    partial class Form1
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
            this.pb01 = new System.Windows.Forms.PictureBox();
            this.pb02 = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.ofd_image = new System.Windows.Forms.OpenFileDialog();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.sfd_image = new System.Windows.Forms.SaveFileDialog();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pb01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb02)).BeginInit();
            this.SuspendLayout();
            // 
            // pb01
            // 
            this.pb01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb01.Location = new System.Drawing.Point(15, 15);
            this.pb01.Margin = new System.Windows.Forms.Padding(6);
            this.pb01.Name = "pb01";
            this.pb01.Size = new System.Drawing.Size(572, 622);
            this.pb01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb01.TabIndex = 0;
            this.pb01.TabStop = false;
            // 
            // pb02
            // 
            this.pb02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb02.Location = new System.Drawing.Point(599, 15);
            this.pb02.Margin = new System.Windows.Forms.Padding(6);
            this.pb02.Name = "pb02";
            this.pb02.Size = new System.Drawing.Size(597, 622);
            this.pb02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb02.TabIndex = 1;
            this.pb02.TabStop = false;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(24, 649);
            this.btnLoadImage.Margin = new System.Windows.Forms.Padding(6);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(150, 44);
            this.btnLoadImage.TabIndex = 2;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(186, 649);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(6);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(150, 44);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(1046, 649);
            this.btnClear.Margin = new System.Windows.Forms.Padding(6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 44);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ofd_image
            // 
            this.ofd_image.FileName = "image";
            this.ofd_image.Filter = "\"Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG\"";
            this.ofd_image.Title = "Open Image";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Enabled = false;
            this.btnSaveImage.Location = new System.Drawing.Point(345, 649);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(163, 44);
            this.btnSaveImage.TabIndex = 5;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(514, 649);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(523, 44);
            this.pbProgress.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 708);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.pb02);
            this.Controls.Add(this.pb01);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pb01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb02)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb01;
        private System.Windows.Forms.PictureBox pb02;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.OpenFileDialog ofd_image;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.SaveFileDialog sfd_image;
        private System.Windows.Forms.ProgressBar pbProgress;
    }
}

