namespace RandomSimplePolygon
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
            this.gbGenerate = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtVertexCount = new System.Windows.Forms.TextBox();
            this.lblVertexCount = new System.Windows.Forms.Label();
            this.gbClear = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.gbGenerate.SuspendLayout();
            this.gbClear.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Location = new System.Drawing.Point(12, 12);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(300, 300);
            this.pnlMain.TabIndex = 0;
            // 
            // gbGenerate
            // 
            this.gbGenerate.Controls.Add(this.btnGenerate);
            this.gbGenerate.Controls.Add(this.txtVertexCount);
            this.gbGenerate.Controls.Add(this.lblVertexCount);
            this.gbGenerate.Location = new System.Drawing.Point(318, 12);
            this.gbGenerate.Name = "gbGenerate";
            this.gbGenerate.Size = new System.Drawing.Size(200, 80);
            this.gbGenerate.TabIndex = 1;
            this.gbGenerate.TabStop = false;
            this.gbGenerate.Text = "Generate";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(6, 46);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(188, 23);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtVertexCount
            // 
            this.txtVertexCount.Location = new System.Drawing.Point(81, 20);
            this.txtVertexCount.Name = "txtVertexCount";
            this.txtVertexCount.Size = new System.Drawing.Size(113, 20);
            this.txtVertexCount.TabIndex = 1;
            // 
            // lblVertexCount
            // 
            this.lblVertexCount.AutoSize = true;
            this.lblVertexCount.Location = new System.Drawing.Point(7, 20);
            this.lblVertexCount.Name = "lblVertexCount";
            this.lblVertexCount.Size = new System.Drawing.Size(67, 13);
            this.lblVertexCount.TabIndex = 0;
            this.lblVertexCount.Text = "# of Vertices";
            // 
            // gbClear
            // 
            this.gbClear.Controls.Add(this.btnClear);
            this.gbClear.Location = new System.Drawing.Point(318, 98);
            this.gbClear.Name = "gbClear";
            this.gbClear.Size = new System.Drawing.Size(200, 55);
            this.gbClear.TabIndex = 2;
            this.gbClear.TabStop = false;
            this.gbClear.Text = "Clear";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(6, 19);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(188, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 324);
            this.Controls.Add(this.gbClear);
            this.Controls.Add(this.gbGenerate);
            this.Controls.Add(this.pnlMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbGenerate.ResumeLayout(false);
            this.gbGenerate.PerformLayout();
            this.gbClear.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox gbGenerate;
        private System.Windows.Forms.GroupBox gbClear;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblVertexCount;
        private System.Windows.Forms.TextBox txtVertexCount;
        private System.Windows.Forms.Button btnGenerate;
    }
}

