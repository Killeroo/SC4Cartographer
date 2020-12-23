namespace SC4CartographerUI
{
    partial class SuccessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuccessForm));
            this.MainTextLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.ExtraTextLabel = new System.Windows.Forms.Label();
            this.OpenFolderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MapCreatedLabel
            // 
            this.MainTextLabel.AutoSize = true;
            this.MainTextLabel.Location = new System.Drawing.Point(64, 9);
            this.MainTextLabel.Name = "MapCreatedLabel";
            this.MainTextLabel.Size = new System.Drawing.Size(35, 13);
            this.MainTextLabel.TabIndex = 0;
            this.MainTextLabel.Text = "label1";
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this.ExtraTextLabel.AutoSize = true;
            this.ExtraTextLabel.Location = new System.Drawing.Point(64, 22);
            this.ExtraTextLabel.Name = "PathLabel";
            this.ExtraTextLabel.Size = new System.Drawing.Size(35, 13);
            this.ExtraTextLabel.TabIndex = 3;
            this.ExtraTextLabel.Text = "label1";
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
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.OKButton;
            this.ClientSize = new System.Drawing.Size(462, 75);
            this.Controls.Add(this.ExtraTextLabel);
            this.Controls.Add(this.OpenFolderButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.MainTextLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MapCreatedForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Map Saved";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SuccessForm_OnPaint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainTextLabel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label ExtraTextLabel;
        private System.Windows.Forms.Button OpenFolderButton;
    }
}