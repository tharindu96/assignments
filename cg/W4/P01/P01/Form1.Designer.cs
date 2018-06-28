namespace P01
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtXs = new System.Windows.Forms.TextBox();
            this.lblXs = new System.Windows.Forms.Label();
            this.lblYs = new System.Windows.Forms.Label();
            this.txtYs = new System.Windows.Forms.TextBox();
            this.lblXe = new System.Windows.Forms.Label();
            this.txtXe = new System.Windows.Forms.TextBox();
            this.lblYe = new System.Windows.Forms.Label();
            this.txtYe = new System.Windows.Forms.TextBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Location = new System.Drawing.Point(12, 12);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(500, 500);
            this.pnlMain.TabIndex = 0;
            // 
            // txtXs
            // 
            this.txtXs.Location = new System.Drawing.Point(547, 12);
            this.txtXs.Name = "txtXs";
            this.txtXs.Size = new System.Drawing.Size(100, 20);
            this.txtXs.TabIndex = 1;
            // 
            // lblXs
            // 
            this.lblXs.AutoSize = true;
            this.lblXs.Location = new System.Drawing.Point(524, 15);
            this.lblXs.Name = "lblXs";
            this.lblXs.Size = new System.Drawing.Size(17, 13);
            this.lblXs.TabIndex = 2;
            this.lblXs.Text = "xs";
            // 
            // lblYs
            // 
            this.lblYs.AutoSize = true;
            this.lblYs.Location = new System.Drawing.Point(524, 41);
            this.lblYs.Name = "lblYs";
            this.lblYs.Size = new System.Drawing.Size(17, 13);
            this.lblYs.TabIndex = 4;
            this.lblYs.Text = "ys";
            // 
            // txtYs
            // 
            this.txtYs.Location = new System.Drawing.Point(547, 38);
            this.txtYs.Name = "txtYs";
            this.txtYs.Size = new System.Drawing.Size(100, 20);
            this.txtYs.TabIndex = 3;
            // 
            // lblXe
            // 
            this.lblXe.AutoSize = true;
            this.lblXe.Location = new System.Drawing.Point(524, 67);
            this.lblXe.Name = "lblXe";
            this.lblXe.Size = new System.Drawing.Size(18, 13);
            this.lblXe.TabIndex = 6;
            this.lblXe.Text = "xe";
            // 
            // txtXe
            // 
            this.txtXe.Location = new System.Drawing.Point(547, 64);
            this.txtXe.Name = "txtXe";
            this.txtXe.Size = new System.Drawing.Size(100, 20);
            this.txtXe.TabIndex = 5;
            // 
            // lblYe
            // 
            this.lblYe.AutoSize = true;
            this.lblYe.Location = new System.Drawing.Point(524, 93);
            this.lblYe.Name = "lblYe";
            this.lblYe.Size = new System.Drawing.Size(18, 13);
            this.lblYe.TabIndex = 8;
            this.lblYe.Text = "ye";
            // 
            // txtYe
            // 
            this.txtYe.Location = new System.Drawing.Point(547, 90);
            this.txtYe.Name = "txtYe";
            this.txtYe.Size = new System.Drawing.Size(100, 20);
            this.txtYe.TabIndex = 7;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(547, 116);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(100, 23);
            this.btnDraw.TabIndex = 9;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(547, 145);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 526);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.lblYe);
            this.Controls.Add(this.txtYe);
            this.Controls.Add(this.lblXe);
            this.Controls.Add(this.txtXe);
            this.Controls.Add(this.lblYs);
            this.Controls.Add(this.txtYs);
            this.Controls.Add(this.lblXs);
            this.Controls.Add(this.txtXs);
            this.Controls.Add(this.pnlMain);
            this.Name = "Form1";
            this.Text = "Drawing Line Segments";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TextBox txtXs;
        private System.Windows.Forms.Label lblXs;
        private System.Windows.Forms.Label lblYs;
        private System.Windows.Forms.TextBox txtYs;
        private System.Windows.Forms.Label lblXe;
        private System.Windows.Forms.TextBox txtXe;
        private System.Windows.Forms.Label lblYe;
        private System.Windows.Forms.TextBox txtYe;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnClear;
    }
}

