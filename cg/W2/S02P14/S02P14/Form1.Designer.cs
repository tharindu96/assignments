namespace S02P14
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
            this.tbFirstNumber = new System.Windows.Forms.TextBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.tbSecondNumber = new System.Windows.Forms.TextBox();
            this.op1 = new System.Windows.Forms.ComboBox();
            this.op2 = new System.Windows.Forms.ComboBox();
            this.tbThirdNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbFirstNumber
            // 
            this.tbFirstNumber.Location = new System.Drawing.Point(12, 12);
            this.tbFirstNumber.Name = "tbFirstNumber";
            this.tbFirstNumber.Size = new System.Drawing.Size(50, 20);
            this.tbFirstNumber.TabIndex = 0;
            this.tbFirstNumber.Text = "10";
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(85, 138);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(75, 25);
            this.btnAnswer.TabIndex = 1;
            this.btnAnswer.Text = "Answer";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // tbSecondNumber
            // 
            this.tbSecondNumber.Location = new System.Drawing.Point(110, 12);
            this.tbSecondNumber.Name = "tbSecondNumber";
            this.tbSecondNumber.Size = new System.Drawing.Size(50, 20);
            this.tbSecondNumber.TabIndex = 2;
            this.tbSecondNumber.Text = "5";
            // 
            // op1
            // 
            this.op1.DisplayMember = "+";
            this.op1.FormattingEnabled = true;
            this.op1.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.op1.Location = new System.Drawing.Point(68, 11);
            this.op1.Name = "op1";
            this.op1.Size = new System.Drawing.Size(36, 21);
            this.op1.TabIndex = 3;
            this.op1.Text = "+";
            // 
            // op2
            // 
            this.op2.FormattingEnabled = true;
            this.op2.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.op2.Location = new System.Drawing.Point(166, 12);
            this.op2.Name = "op2";
            this.op2.Size = new System.Drawing.Size(36, 21);
            this.op2.TabIndex = 4;
            this.op2.Text = "+";
            // 
            // tbThirdNumber
            // 
            this.tbThirdNumber.Location = new System.Drawing.Point(208, 13);
            this.tbThirdNumber.Name = "tbThirdNumber";
            this.tbThirdNumber.Size = new System.Drawing.Size(50, 20);
            this.tbThirdNumber.TabIndex = 5;
            this.tbThirdNumber.Text = "5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tbThirdNumber);
            this.Controls.Add(this.op2);
            this.Controls.Add(this.op1);
            this.Controls.Add(this.tbSecondNumber);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.tbFirstNumber);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFirstNumber;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.TextBox tbSecondNumber;
        private System.Windows.Forms.ComboBox op1;
        private System.Windows.Forms.ComboBox op2;
        private System.Windows.Forms.TextBox tbThirdNumber;
    }
}

