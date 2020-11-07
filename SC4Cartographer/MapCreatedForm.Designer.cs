namespace SC4CartographerUI
{
    partial class MapCreatedForm
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
            this.MapCreatedLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.PathLabel = new System.Windows.Forms.Label();
            this.OpenFolderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MapCreatedLabel
            // 
            this.MapCreatedLabel.AutoSize = true;
            this.MapCreatedLabel.Location = new System.Drawing.Point(64, 9);
            this.MapCreatedLabel.Name = "MapCreatedLabel";
            this.MapCreatedLabel.Size = new System.Drawing.Size(35, 13);
            this.MapCreatedLabel.TabIndex = 0;
            this.MapCreatedLabel.Text = "label1";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(381, 46);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(64, 22);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(35, 13);
            this.PathLabel.TabIndex = 3;
            this.PathLabel.Text = "label1";
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.Location = new System.Drawing.Point(243, 46);
            this.OpenFolderButton.Name = "OpenFolderButton";
            this.OpenFolderButton.Size = new System.Drawing.Size(132, 23);
            this.OpenFolderButton.TabIndex = 2;
            this.OpenFolderButton.Text = "Open folder in explorer";
            this.OpenFolderButton.UseVisualStyleBackColor = true;
            this.OpenFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // MapCreatedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 75);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.OpenFolderButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.MapCreatedLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MapCreatedForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Map Saved";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MapCreatedForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MapCreatedLabel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.Button OpenFolderButton;
    }
}