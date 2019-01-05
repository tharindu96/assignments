namespace MatrixChain
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
            this.txtNum11 = new System.Windows.Forms.TextBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNum12 = new System.Windows.Forms.TextBox();
            this.txtNum13 = new System.Windows.Forms.TextBox();
            this.txtNum23 = new System.Windows.Forms.TextBox();
            this.txtNum22 = new System.Windows.Forms.TextBox();
            this.txtNum21 = new System.Windows.Forms.TextBox();
            this.txtNum33 = new System.Windows.Forms.TextBox();
            this.txtNum32 = new System.Windows.Forms.TextBox();
            this.txtNum31 = new System.Windows.Forms.TextBox();
            this.btnNewMatrix = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.txtAns11 = new System.Windows.Forms.TextBox();
            this.txtAns12 = new System.Windows.Forms.TextBox();
            this.txtAns13 = new System.Windows.Forms.TextBox();
            this.txtAns23 = new System.Windows.Forms.TextBox();
            this.txtAns22 = new System.Windows.Forms.TextBox();
            this.txtAns21 = new System.Windows.Forms.TextBox();
            this.txtAns33 = new System.Windows.Forms.TextBox();
            this.txtAns32 = new System.Windows.Forms.TextBox();
            this.txtAns31 = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDeleteMatrix = new System.Windows.Forms.Button();
            this.lblMatrix = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNum11
            // 
            this.txtNum11.Enabled = false;
            this.txtNum11.Location = new System.Drawing.Point(12, 33);
            this.txtNum11.Name = "txtNum11";
            this.txtNum11.Size = new System.Drawing.Size(37, 20);
            this.txtNum11.TabIndex = 0;
            this.txtNum11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNum11.TextChanged += new System.EventHandler(this.btnMatrix_TextChange);
            this.txtNum11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnMatrix_KeyPress);
            // 
            // btnPrev
            // 
            this.btnPrev.Enabled = false;
            this.btnPrev.Location = new System.Drawing.Point(12, 111);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(37, 23);
            this.btnPrev.TabIndex = 9;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(98, 111);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(37, 23);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Location = new System.Drawing.Point(-132, -167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Matrix: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNum12
            // 
            this.txtNum12.Enabled = false;
            this.txtNum12.Location = new System.Drawing.Point(55, 33);
            this.txtNum12.Name = "txtNum12";
            this.txtNum12.Size = new System.Drawing.Size(37, 20);
            this.txtNum12.TabIndex = 12;
            this.txtNum12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNum12.TextChanged += new System.EventHandler(this.btnMatrix_TextChange);
            this.txtNum12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnMatrix_KeyPress);
            // 
            // txtNum13
            // 
            this.txtNum13.Enabled = false;
            this.txtNum13.Location = new System.Drawing.Point(98, 33);
            this.txtNum13.Name = "txtNum13";
            this.txtNum13.Size = new System.Drawing.Size(37, 20);
            this.txtNum13.TabIndex = 13;
            this.txtNum13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNum13.TextChanged += new System.EventHandler(this.btnMatrix_TextChange);
            this.txtNum13.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnMatrix_KeyPress);
            // 
            // txtNum23
            // 
            this.txtNum23.Enabled = false;
            this.txtNum23.Location = new System.Drawing.Point(98, 59);
            this.txtNum23.Name = "txtNum23";
            this.txtNum23.Size = new System.Drawing.Size(37, 20);
            this.txtNum23.TabIndex = 16;
            this.txtNum23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNum23.TextChanged += new System.EventHandler(this.btnMatrix_TextChange);
            this.txtNum23.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnMatrix_KeyPress);
            // 
            // txtNum22
            // 
            this.txtNum22.Enabled = false;
            this.txtNum22.Location = new System.Drawing.Point(55, 59);
            this.txtNum22.Name = "txtNum22";
            this.txtNum22.Size = new System.Drawing.Size(37, 20);
            this.txtNum22.TabIndex = 15;
            this.txtNum22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNum22.TextChanged += new System.EventHandler(this.btnMatrix_TextChange);
            this.txtNum22.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnMatrix_KeyPress);
            // 
            // txtNum21
            // 
            this.txtNum21.Enabled = false;
            this.txtNum21.Location = new System.Drawing.Point(12, 59);
            this.txtNum21.Name = "txtNum21";
            this.txtNum21.Size = new System.Drawing.Size(37, 20);
            this.txtNum21.TabIndex = 14;
            this.txtNum21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNum21.TextChanged += new System.EventHandler(this.btnMatrix_TextChange);
            this.txtNum21.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnMatrix_KeyPress);
            // 
            // txtNum33
            // 
            this.txtNum33.Enabled = false;
            this.txtNum33.Location = new System.Drawing.Point(98, 85);
            this.txtNum33.Name = "txtNum33";
            this.txtNum33.Size = new System.Drawing.Size(37, 20);
            this.txtNum33.TabIndex = 19;
            this.txtNum33.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNum33.TextChanged += new System.EventHandler(this.btnMatrix_TextChange);
            this.txtNum33.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnMatrix_KeyPress);
            // 
            // txtNum32
            // 
            this.txtNum32.Enabled = false;
            this.txtNum32.Location = new System.Drawing.Point(55, 85);
            this.txtNum32.Name = "txtNum32";
            this.txtNum32.Size = new System.Drawing.Size(37, 20);
            this.txtNum32.TabIndex = 18;
            this.txtNum32.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNum32.TextChanged += new System.EventHandler(this.btnMatrix_TextChange);
            this.txtNum32.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnMatrix_KeyPress);
            // 
            // txtNum31
            // 
            this.txtNum31.Enabled = false;
            this.txtNum31.Location = new System.Drawing.Point(12, 85);
            this.txtNum31.Name = "txtNum31";
            this.txtNum31.Size = new System.Drawing.Size(37, 20);
            this.txtNum31.TabIndex = 17;
            this.txtNum31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNum31.TextChanged += new System.EventHandler(this.btnMatrix_TextChange);
            this.txtNum31.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnMatrix_KeyPress);
            // 
            // btnNewMatrix
            // 
            this.btnNewMatrix.Location = new System.Drawing.Point(12, 140);
            this.btnNewMatrix.Name = "btnNewMatrix";
            this.btnNewMatrix.Size = new System.Drawing.Size(123, 23);
            this.btnNewMatrix.TabIndex = 20;
            this.btnNewMatrix.Text = "New Matrix";
            this.btnNewMatrix.UseVisualStyleBackColor = true;
            this.btnNewMatrix.Click += new System.EventHandler(this.btnNewMatrix_Click);
            // 
            // btnMultiply
            // 
            this.btnMultiply.Enabled = false;
            this.btnMultiply.Location = new System.Drawing.Point(185, 111);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(123, 23);
            this.btnMultiply.TabIndex = 21;
            this.btnMultiply.Text = "Multiply";
            this.btnMultiply.UseVisualStyleBackColor = true;
            this.btnMultiply.Click += new System.EventHandler(this.btnMultiply_Click);
            // 
            // txtAns11
            // 
            this.txtAns11.Location = new System.Drawing.Point(185, 33);
            this.txtAns11.Name = "txtAns11";
            this.txtAns11.ReadOnly = true;
            this.txtAns11.Size = new System.Drawing.Size(37, 20);
            this.txtAns11.TabIndex = 22;
            this.txtAns11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAns12
            // 
            this.txtAns12.Location = new System.Drawing.Point(228, 33);
            this.txtAns12.Name = "txtAns12";
            this.txtAns12.ReadOnly = true;
            this.txtAns12.Size = new System.Drawing.Size(37, 20);
            this.txtAns12.TabIndex = 23;
            this.txtAns12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAns13
            // 
            this.txtAns13.Location = new System.Drawing.Point(271, 33);
            this.txtAns13.Name = "txtAns13";
            this.txtAns13.ReadOnly = true;
            this.txtAns13.Size = new System.Drawing.Size(37, 20);
            this.txtAns13.TabIndex = 24;
            this.txtAns13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAns23
            // 
            this.txtAns23.Location = new System.Drawing.Point(271, 59);
            this.txtAns23.Name = "txtAns23";
            this.txtAns23.ReadOnly = true;
            this.txtAns23.Size = new System.Drawing.Size(37, 20);
            this.txtAns23.TabIndex = 27;
            this.txtAns23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAns22
            // 
            this.txtAns22.Location = new System.Drawing.Point(228, 59);
            this.txtAns22.Name = "txtAns22";
            this.txtAns22.ReadOnly = true;
            this.txtAns22.Size = new System.Drawing.Size(37, 20);
            this.txtAns22.TabIndex = 26;
            this.txtAns22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAns21
            // 
            this.txtAns21.Location = new System.Drawing.Point(185, 59);
            this.txtAns21.Name = "txtAns21";
            this.txtAns21.ReadOnly = true;
            this.txtAns21.Size = new System.Drawing.Size(37, 20);
            this.txtAns21.TabIndex = 25;
            this.txtAns21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAns33
            // 
            this.txtAns33.Location = new System.Drawing.Point(271, 85);
            this.txtAns33.Name = "txtAns33";
            this.txtAns33.ReadOnly = true;
            this.txtAns33.Size = new System.Drawing.Size(37, 20);
            this.txtAns33.TabIndex = 30;
            this.txtAns33.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAns32
            // 
            this.txtAns32.Location = new System.Drawing.Point(228, 85);
            this.txtAns32.Name = "txtAns32";
            this.txtAns32.ReadOnly = true;
            this.txtAns32.Size = new System.Drawing.Size(37, 20);
            this.txtAns32.TabIndex = 29;
            this.txtAns32.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAns31
            // 
            this.txtAns31.Location = new System.Drawing.Point(185, 85);
            this.txtAns31.Name = "txtAns31";
            this.txtAns31.ReadOnly = true;
            this.txtAns31.Size = new System.Drawing.Size(37, 20);
            this.txtAns31.TabIndex = 28;
            this.txtAns31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(185, 140);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(123, 23);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDeleteMatrix
            // 
            this.btnDeleteMatrix.Enabled = false;
            this.btnDeleteMatrix.Location = new System.Drawing.Point(12, 169);
            this.btnDeleteMatrix.Name = "btnDeleteMatrix";
            this.btnDeleteMatrix.Size = new System.Drawing.Size(123, 23);
            this.btnDeleteMatrix.TabIndex = 32;
            this.btnDeleteMatrix.Text = "Delete Matrix";
            this.btnDeleteMatrix.UseVisualStyleBackColor = true;
            this.btnDeleteMatrix.Click += new System.EventHandler(this.btnDeleteMatrix_Click);
            // 
            // lblMatrix
            // 
            this.lblMatrix.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMatrix.Location = new System.Drawing.Point(55, 111);
            this.lblMatrix.Name = "lblMatrix";
            this.lblMatrix.Size = new System.Drawing.Size(37, 23);
            this.lblMatrix.TabIndex = 33;
            this.lblMatrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 210);
            this.Controls.Add(this.lblMatrix);
            this.Controls.Add(this.btnDeleteMatrix);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtAns33);
            this.Controls.Add(this.txtAns32);
            this.Controls.Add(this.txtAns31);
            this.Controls.Add(this.txtAns23);
            this.Controls.Add(this.txtAns22);
            this.Controls.Add(this.txtAns21);
            this.Controls.Add(this.txtAns13);
            this.Controls.Add(this.txtAns12);
            this.Controls.Add(this.txtAns11);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnNewMatrix);
            this.Controls.Add(this.txtNum33);
            this.Controls.Add(this.txtNum32);
            this.Controls.Add(this.txtNum31);
            this.Controls.Add(this.txtNum23);
            this.Controls.Add(this.txtNum22);
            this.Controls.Add(this.txtNum21);
            this.Controls.Add(this.txtNum13);
            this.Controls.Add(this.txtNum12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.txtNum11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNum11;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNum12;
        private System.Windows.Forms.TextBox txtNum13;
        private System.Windows.Forms.TextBox txtNum23;
        private System.Windows.Forms.TextBox txtNum22;
        private System.Windows.Forms.TextBox txtNum21;
        private System.Windows.Forms.TextBox txtNum33;
        private System.Windows.Forms.TextBox txtNum32;
        private System.Windows.Forms.TextBox txtNum31;
        private System.Windows.Forms.Button btnNewMatrix;
        private System.Windows.Forms.Button btnMultiply;
        private System.Windows.Forms.TextBox txtAns11;
        private System.Windows.Forms.TextBox txtAns12;
        private System.Windows.Forms.TextBox txtAns13;
        private System.Windows.Forms.TextBox txtAns23;
        private System.Windows.Forms.TextBox txtAns22;
        private System.Windows.Forms.TextBox txtAns21;
        private System.Windows.Forms.TextBox txtAns33;
        private System.Windows.Forms.TextBox txtAns32;
        private System.Windows.Forms.TextBox txtAns31;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDeleteMatrix;
        private System.Windows.Forms.Label lblMatrix;
    }
}

