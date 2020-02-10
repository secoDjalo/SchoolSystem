namespace SchoolSystem
{
    partial class Grades
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grades));
            this.buttonBackToMain = new System.Windows.Forms.Button();
            this.labeInformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBackToMain
            // 
            this.buttonBackToMain.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackToMain.Location = new System.Drawing.Point(347, 477);
            this.buttonBackToMain.Name = "buttonBackToMain";
            this.buttonBackToMain.Size = new System.Drawing.Size(339, 67);
            this.buttonBackToMain.TabIndex = 0;
            this.buttonBackToMain.Text = "Back to main Window";
            this.buttonBackToMain.UseVisualStyleBackColor = true;
            this.buttonBackToMain.Click += new System.EventHandler(this.buttonBackToMain_Click);
            // 
            // labeInformation
            // 
            this.labeInformation.AutoSize = true;
            this.labeInformation.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeInformation.Location = new System.Drawing.Point(350, 365);
            this.labeInformation.Name = "labeInformation";
            this.labeInformation.Size = new System.Drawing.Size(336, 33);
            this.labeInformation.TabIndex = 1;
            this.labeInformation.Text = "To be developed further";
            // 
            // Grades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1034, 662);
            this.ControlBox = false;
            this.Controls.Add(this.labeInformation);
            this.Controls.Add(this.buttonBackToMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Grades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grades";
            this.Load += new System.EventHandler(this.Grades_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBackToMain;
        private System.Windows.Forms.Label labeInformation;
    }
}