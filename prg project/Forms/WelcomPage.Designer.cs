namespace prg_project.Forms
{
    partial class WelcomPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomPage));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoginW = new System.Windows.Forms.Button();
            this.btnCreateW = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 54);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoginW
            // 
            this.btnLoginW.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLoginW.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLoginW.Location = new System.Drawing.Point(228, 314);
            this.btnLoginW.Name = "btnLoginW";
            this.btnLoginW.Size = new System.Drawing.Size(75, 23);
            this.btnLoginW.TabIndex = 2;
            this.btnLoginW.Text = "Login";
            this.btnLoginW.UseVisualStyleBackColor = false;
            this.btnLoginW.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCreateW
            // 
            this.btnCreateW.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCreateW.Location = new System.Drawing.Point(486, 314);
            this.btnCreateW.Name = "btnCreateW";
            this.btnCreateW.Size = new System.Drawing.Size(105, 23);
            this.btnCreateW.TabIndex = 3;
            this.btnCreateW.Text = "Create an Account";
            this.btnCreateW.UseVisualStyleBackColor = false;
            this.btnCreateW.Click += new System.EventHandler(this.btnCreateW_Click);
            // 
            // WelcomPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCreateW);
            this.Controls.Add(this.btnLoginW);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "WelcomPage";
            this.Text = "WelcomPage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLoginW;
        private System.Windows.Forms.Button btnCreateW;
    }
}