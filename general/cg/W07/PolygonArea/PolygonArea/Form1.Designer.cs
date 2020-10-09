namespace ReflexVectors
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
            this.gbDoneDrawing = new System.Windows.Forms.GroupBox();
            this.btnDoneDrawing = new System.Windows.Forms.Button();
            this.gbCalculateArea = new System.Windows.Forms.GroupBox();
            this.btnCalculateArea = new System.Windows.Forms.Button();
            this.gbClear = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblArea = new System.Windows.Forms.Label();
            this.gbDoneDrawing.SuspendLayout();
            this.gbCalculateArea.SuspendLayout();
            this.gbClear.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Location = new System.Drawing.Point(12, 12);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(300, 300);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseUp);
            // 
            // gbDoneDrawing
            // 
            this.gbDoneDrawing.Controls.Add(this.btnDoneDrawing);
            this.gbDoneDrawing.Location = new System.Drawing.Point(318, 12);
            this.gbDoneDrawing.Name = "gbDoneDrawing";
            this.gbDoneDrawing.Size = new System.Drawing.Size(200, 55);
            this.gbDoneDrawing.TabIndex = 2;
            this.gbDoneDrawing.TabStop = false;
            this.gbDoneDrawing.Text = "Done Drawing";
            // 
            // btnDoneDrawing
            // 
            this.btnDoneDrawing.Location = new System.Drawing.Point(10, 19);
            this.btnDoneDrawing.Name = "btnDoneDrawing";
            this.btnDoneDrawing.Size = new System.Drawing.Size(177, 23);
            this.btnDoneDrawing.TabIndex = 1;
            this.btnDoneDrawing.Text = "Done";
            this.btnDoneDrawing.UseVisualStyleBackColor = true;
            this.btnDoneDrawing.Click += new System.EventHandler(this.btnSetVertexCount_Click);
            // 
            // gbCalculateArea
            // 
            this.gbCalculateArea.Controls.Add(this.lblArea);
            this.gbCalculateArea.Controls.Add(this.btnCalculateArea);
            this.gbCalculateArea.Enabled = false;
            this.gbCalculateArea.Location = new System.Drawing.Point(318, 73);
            this.gbCalculateArea.Name = "gbCalculateArea";
            this.gbCalculateArea.Size = new System.Drawing.Size(200, 88);
            this.gbCalculateArea.TabIndex = 4;
            this.gbCalculateArea.TabStop = false;
            this.gbCalculateArea.Text = "Calculate Area";
            // 
            // btnCalculateArea
            // 
            this.btnCalculateArea.Location = new System.Drawing.Point(10, 20);
            this.btnCalculateArea.Name = "btnCalculateArea";
            this.btnCalculateArea.Size = new System.Drawing.Size(177, 23);
            this.btnCalculateArea.TabIndex = 0;
            this.btnCalculateArea.Text = "Calculate Area";
            this.btnCalculateArea.UseVisualStyleBackColor = true;
            this.btnCalculateArea.Click += new System.EventHandler(this.btnCalculateArea_Click);
            // 
            // gbClear
            // 
            this.gbClear.Controls.Add(this.btnClear);
            this.gbClear.Location = new System.Drawing.Point(318, 167);
            this.gbClear.Name = "gbClear";
            this.gbClear.Size = new System.Drawing.Size(200, 62);
            this.gbClear.TabIndex = 5;
            this.gbClear.TabStop = false;
            this.gbClear.Text = "Clear";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(10, 20);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(177, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(88, 46);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(13, 13);
            this.lblArea.TabIndex = 1;
            this.lblArea.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 325);
            this.Controls.Add(this.gbClear);
            this.Controls.Add(this.gbCalculateArea);
            this.Controls.Add(this.gbDoneDrawing);
            this.Controls.Add(this.pnlMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbDoneDrawing.ResumeLayout(false);
            this.gbCalculateArea.ResumeLayout(false);
            this.gbCalculateArea.PerformLayout();
            this.gbClear.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox gbDoneDrawing;
        private System.Windows.Forms.Button btnDoneDrawing;
        private System.Windows.Forms.GroupBox gbCalculateArea;
        private System.Windows.Forms.GroupBox gbClear;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCalculateArea;
        private System.Windows.Forms.Label lblArea;
    }
}

