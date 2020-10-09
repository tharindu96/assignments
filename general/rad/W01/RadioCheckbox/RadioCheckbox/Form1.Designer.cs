namespace RadioCheckbox
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAnimation = new System.Windows.Forms.CheckBox();
            this.chkRomance = new System.Windows.Forms.CheckBox();
            this.chkScienceFiction = new System.Windows.Forms.CheckBox();
            this.chkAction = new System.Windows.Forms.CheckBox();
            this.chkComedy = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoAnimation = new System.Windows.Forms.RadioButton();
            this.rdoRomance = new System.Windows.Forms.RadioButton();
            this.rdoScienceFiction = new System.Windows.Forms.RadioButton();
            this.rdoAction = new System.Windows.Forms.RadioButton();
            this.rdoComedy = new System.Windows.Forms.RadioButton();
            this.btnSelectedMovies = new System.Windows.Forms.Button();
            this.btnFav = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAnimation);
            this.groupBox1.Controls.Add(this.chkRomance);
            this.groupBox1.Controls.Add(this.chkScienceFiction);
            this.groupBox1.Controls.Add(this.chkAction);
            this.groupBox1.Controls.Add(this.chkComedy);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "What type of Movies do you like?";
            // 
            // chkAnimation
            // 
            this.chkAnimation.AutoSize = true;
            this.chkAnimation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAnimation.Location = new System.Drawing.Point(7, 114);
            this.chkAnimation.Name = "chkAnimation";
            this.chkAnimation.Size = new System.Drawing.Size(81, 17);
            this.chkAnimation.TabIndex = 4;
            this.chkAnimation.Text = "Animation";
            this.chkAnimation.UseVisualStyleBackColor = true;
            // 
            // chkRomance
            // 
            this.chkRomance.AutoSize = true;
            this.chkRomance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRomance.Location = new System.Drawing.Point(7, 91);
            this.chkRomance.Name = "chkRomance";
            this.chkRomance.Size = new System.Drawing.Size(79, 17);
            this.chkRomance.TabIndex = 3;
            this.chkRomance.Text = "Romance";
            this.chkRomance.UseVisualStyleBackColor = true;
            // 
            // chkScienceFiction
            // 
            this.chkScienceFiction.AutoSize = true;
            this.chkScienceFiction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkScienceFiction.Location = new System.Drawing.Point(7, 67);
            this.chkScienceFiction.Name = "chkScienceFiction";
            this.chkScienceFiction.Size = new System.Drawing.Size(114, 17);
            this.chkScienceFiction.TabIndex = 2;
            this.chkScienceFiction.Text = "Science Fiction";
            this.chkScienceFiction.UseVisualStyleBackColor = true;
            // 
            // chkAction
            // 
            this.chkAction.AutoSize = true;
            this.chkAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAction.Location = new System.Drawing.Point(7, 44);
            this.chkAction.Name = "chkAction";
            this.chkAction.Size = new System.Drawing.Size(62, 17);
            this.chkAction.TabIndex = 1;
            this.chkAction.Text = "Action";
            this.chkAction.UseVisualStyleBackColor = true;
            // 
            // chkComedy
            // 
            this.chkComedy.AutoSize = true;
            this.chkComedy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkComedy.Location = new System.Drawing.Point(7, 20);
            this.chkComedy.Name = "chkComedy";
            this.chkComedy.Size = new System.Drawing.Size(70, 17);
            this.chkComedy.TabIndex = 0;
            this.chkComedy.Text = "Comedy";
            this.chkComedy.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoAnimation);
            this.groupBox2.Controls.Add(this.rdoRomance);
            this.groupBox2.Controls.Add(this.rdoScienceFiction);
            this.groupBox2.Controls.Add(this.rdoAction);
            this.groupBox2.Controls.Add(this.rdoComedy);
            this.groupBox2.Location = new System.Drawing.Point(297, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 143);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "And you Favourite is?";
            // 
            // rdoAnimation
            // 
            this.rdoAnimation.AutoSize = true;
            this.rdoAnimation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAnimation.Location = new System.Drawing.Point(7, 114);
            this.rdoAnimation.Name = "rdoAnimation";
            this.rdoAnimation.Size = new System.Drawing.Size(80, 17);
            this.rdoAnimation.TabIndex = 4;
            this.rdoAnimation.TabStop = true;
            this.rdoAnimation.Text = "Animation";
            this.rdoAnimation.UseVisualStyleBackColor = true;
            // 
            // rdoRomance
            // 
            this.rdoRomance.AutoSize = true;
            this.rdoRomance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoRomance.Location = new System.Drawing.Point(7, 91);
            this.rdoRomance.Name = "rdoRomance";
            this.rdoRomance.Size = new System.Drawing.Size(78, 17);
            this.rdoRomance.TabIndex = 3;
            this.rdoRomance.TabStop = true;
            this.rdoRomance.Text = "Romance";
            this.rdoRomance.UseVisualStyleBackColor = true;
            // 
            // rdoScienceFiction
            // 
            this.rdoScienceFiction.AutoSize = true;
            this.rdoScienceFiction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoScienceFiction.Location = new System.Drawing.Point(7, 67);
            this.rdoScienceFiction.Name = "rdoScienceFiction";
            this.rdoScienceFiction.Size = new System.Drawing.Size(113, 17);
            this.rdoScienceFiction.TabIndex = 2;
            this.rdoScienceFiction.TabStop = true;
            this.rdoScienceFiction.Text = "Science Fiction";
            this.rdoScienceFiction.UseVisualStyleBackColor = true;
            // 
            // rdoAction
            // 
            this.rdoAction.AutoSize = true;
            this.rdoAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAction.Location = new System.Drawing.Point(7, 44);
            this.rdoAction.Name = "rdoAction";
            this.rdoAction.Size = new System.Drawing.Size(61, 17);
            this.rdoAction.TabIndex = 1;
            this.rdoAction.TabStop = true;
            this.rdoAction.Text = "Action";
            this.rdoAction.UseVisualStyleBackColor = true;
            // 
            // rdoComedy
            // 
            this.rdoComedy.AutoSize = true;
            this.rdoComedy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoComedy.Location = new System.Drawing.Point(7, 20);
            this.rdoComedy.Name = "rdoComedy";
            this.rdoComedy.Size = new System.Drawing.Size(69, 17);
            this.rdoComedy.TabIndex = 0;
            this.rdoComedy.TabStop = true;
            this.rdoComedy.Text = "Comedy";
            this.rdoComedy.UseVisualStyleBackColor = true;
            // 
            // btnSelectedMovies
            // 
            this.btnSelectedMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectedMovies.Location = new System.Drawing.Point(44, 162);
            this.btnSelectedMovies.Name = "btnSelectedMovies";
            this.btnSelectedMovies.Size = new System.Drawing.Size(191, 48);
            this.btnSelectedMovies.TabIndex = 2;
            this.btnSelectedMovies.Text = "Selected Movies";
            this.btnSelectedMovies.UseVisualStyleBackColor = true;
            this.btnSelectedMovies.Click += new System.EventHandler(this.btnSelectedMovies_Click);
            // 
            // btnFav
            // 
            this.btnFav.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFav.Location = new System.Drawing.Point(326, 162);
            this.btnFav.Name = "btnFav";
            this.btnFav.Size = new System.Drawing.Size(191, 48);
            this.btnFav.TabIndex = 3;
            this.btnFav.Text = "Favourite Movie";
            this.btnFav.UseVisualStyleBackColor = true;
            this.btnFav.Click += new System.EventHandler(this.btnFav_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 232);
            this.Controls.Add(this.btnFav);
            this.Controls.Add(this.btnSelectedMovies);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAnimation;
        private System.Windows.Forms.CheckBox chkRomance;
        private System.Windows.Forms.CheckBox chkScienceFiction;
        private System.Windows.Forms.CheckBox chkAction;
        private System.Windows.Forms.CheckBox chkComedy;
        private System.Windows.Forms.RadioButton rdoComedy;
        private System.Windows.Forms.RadioButton rdoAnimation;
        private System.Windows.Forms.RadioButton rdoRomance;
        private System.Windows.Forms.RadioButton rdoScienceFiction;
        private System.Windows.Forms.RadioButton rdoAction;
        private System.Windows.Forms.Button btnSelectedMovies;
        private System.Windows.Forms.Button btnFav;
    }
}

