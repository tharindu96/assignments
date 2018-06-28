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
            this.panel = new System.Windows.Forms.Panel();
            this.gpCP = new System.Windows.Forms.GroupBox();
            this.gbLS = new System.Windows.Forms.GroupBox();
            this.gbAlgo = new System.Windows.Forms.GroupBox();
            this.lbAlgo = new System.Windows.Forms.ListBox();
            this.gbTime = new System.Windows.Forms.GroupBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDraw = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLineSegments = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVertices = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.gpCP.SuspendLayout();
            this.gbLS.SuspendLayout();
            this.gbAlgo.SuspendLayout();
            this.gbTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Black;
            this.panel.Location = new System.Drawing.Point(13, 13);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(500, 500);
            this.panel.TabIndex = 0;
            // 
            // gpCP
            // 
            this.gpCP.Controls.Add(this.btnInsert);
            this.gpCP.Controls.Add(this.txtY);
            this.gpCP.Controls.Add(this.txtX);
            this.gpCP.Controls.Add(this.label6);
            this.gpCP.Controls.Add(this.label5);
            this.gpCP.Controls.Add(this.txtV);
            this.gpCP.Controls.Add(this.label4);
            this.gpCP.Controls.Add(this.btnOK);
            this.gpCP.Controls.Add(this.txtVertices);
            this.gpCP.Controls.Add(this.label3);
            this.gpCP.Location = new System.Drawing.Point(519, 13);
            this.gpCP.Name = "gpCP";
            this.gpCP.Size = new System.Drawing.Size(250, 148);
            this.gpCP.TabIndex = 1;
            this.gpCP.TabStop = false;
            this.gpCP.Text = "Convex Polygon";
            // 
            // gbLS
            // 
            this.gbLS.Controls.Add(this.txtLineSegments);
            this.gbLS.Controls.Add(this.label2);
            this.gbLS.Enabled = false;
            this.gbLS.Location = new System.Drawing.Point(519, 167);
            this.gbLS.Name = "gbLS";
            this.gbLS.Size = new System.Drawing.Size(250, 52);
            this.gbLS.TabIndex = 2;
            this.gbLS.TabStop = false;
            this.gbLS.Text = "Line Segments";
            // 
            // gbAlgo
            // 
            this.gbAlgo.Controls.Add(this.lbAlgo);
            this.gbAlgo.Enabled = false;
            this.gbAlgo.Location = new System.Drawing.Point(520, 225);
            this.gbAlgo.Name = "gbAlgo";
            this.gbAlgo.Size = new System.Drawing.Size(250, 152);
            this.gbAlgo.TabIndex = 3;
            this.gbAlgo.TabStop = false;
            this.gbAlgo.Text = "Algorithms";
            // 
            // lbAlgo
            // 
            this.lbAlgo.FormattingEnabled = true;
            this.lbAlgo.Items.AddRange(new object[] {
            "Cyrus Beck",
            "Skala",
            "Proposed"});
            this.lbAlgo.Location = new System.Drawing.Point(8, 19);
            this.lbAlgo.Name = "lbAlgo";
            this.lbAlgo.Size = new System.Drawing.Size(234, 121);
            this.lbAlgo.TabIndex = 0;
            // 
            // gbTime
            // 
            this.gbTime.Controls.Add(this.txtTime);
            this.gbTime.Controls.Add(this.label1);
            this.gbTime.Controls.Add(this.btnRun);
            this.gbTime.Enabled = false;
            this.gbTime.Location = new System.Drawing.Point(519, 390);
            this.gbTime.Name = "gbTime";
            this.gbTime.Size = new System.Drawing.Size(250, 93);
            this.gbTime.TabIndex = 4;
            this.gbTime.TabStop = false;
            this.gbTime.Text = "Time";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(6, 66);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(237, 20);
            this.txtTime.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Execution Time";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(6, 19);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(237, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(520, 489);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDraw
            // 
            this.btnDraw.Enabled = false;
            this.btnDraw.Location = new System.Drawing.Point(646, 489);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(120, 23);
            this.btnDraw.TabIndex = 6;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Number";
            // 
            // txtLineSegments
            // 
            this.txtLineSegments.Location = new System.Drawing.Point(56, 17);
            this.txtLineSegments.Name = "txtLineSegments";
            this.txtLineSegments.Size = new System.Drawing.Size(186, 20);
            this.txtLineSegments.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Vertices";
            // 
            // txtVertices
            // 
            this.txtVertices.Location = new System.Drawing.Point(102, 17);
            this.txtVertices.Name = "txtVertices";
            this.txtVertices.Size = new System.Drawing.Size(54, 20);
            this.txtVertices.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(167, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "V";
            // 
            // txtV
            // 
            this.txtV.Location = new System.Drawing.Point(29, 77);
            this.txtV.Name = "txtV";
            this.txtV.ReadOnly = true;
            this.txtV.Size = new System.Drawing.Size(25, 20);
            this.txtV.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "y";
            // 
            // txtX
            // 
            this.txtX.Enabled = false;
            this.txtX.Location = new System.Drawing.Point(100, 77);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(45, 20);
            this.txtX.TabIndex = 7;
            // 
            // txtY
            // 
            this.txtY.Enabled = false;
            this.txtY.Location = new System.Drawing.Point(100, 106);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(45, 20);
            this.txtY.TabIndex = 8;
            // 
            // btnInsert
            // 
            this.btnInsert.Enabled = false;
            this.btnInsert.Location = new System.Drawing.Point(167, 104);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 9;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 529);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.gbTime);
            this.Controls.Add(this.gbAlgo);
            this.Controls.Add(this.gbLS);
            this.Controls.Add(this.gpCP);
            this.Controls.Add(this.panel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gpCP.ResumeLayout(false);
            this.gpCP.PerformLayout();
            this.gbLS.ResumeLayout(false);
            this.gbLS.PerformLayout();
            this.gbAlgo.ResumeLayout(false);
            this.gbTime.ResumeLayout(false);
            this.gbTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.GroupBox gpCP;
        private System.Windows.Forms.GroupBox gbLS;
        private System.Windows.Forms.GroupBox gbAlgo;
        private System.Windows.Forms.GroupBox gbTime;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.ListBox lbAlgo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLineSegments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtVertices;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtV;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInsert;
    }
}

