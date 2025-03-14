namespace MultApps.Windows
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMultapps = new System.Windows.Forms.Label();
            this.pgbLoad = new System.Windows.Forms.ProgressBar();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = global::MultApps.Windows.Properties.Resources.da390a7d06548be59c0f863117c9b93e;
            this.pictureBox1.Location = new System.Drawing.Point(280, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblMultapps
            // 
            this.lblMultapps.AutoSize = true;
            this.lblMultapps.Font = new System.Drawing.Font("Microsoft Sans Serif", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMultapps.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMultapps.Location = new System.Drawing.Point(229, 221);
            this.lblMultapps.Name = "lblMultapps";
            this.lblMultapps.Size = new System.Drawing.Size(303, 76);
            this.lblMultapps.TabIndex = 1;
            this.lblMultapps.Text = "Multapps";
            // 
            // pgbLoad
            // 
            this.pgbLoad.Location = new System.Drawing.Point(223, 338);
            this.pgbLoad.Name = "pgbLoad";
            this.pgbLoad.Size = new System.Drawing.Size(295, 23);
            this.pgbLoad.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbLoad.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(36, 418);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(258, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.pgbLoad);
            this.Controls.Add(this.lblMultapps);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.Shown += new System.EventHandler(this.SplashScreen_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMultapps;
        private System.Windows.Forms.ProgressBar pgbLoad;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}