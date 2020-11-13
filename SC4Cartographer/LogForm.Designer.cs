namespace SC4CartographerUI
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.LogOutputTextbox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CopyToClipboardButton = new System.Windows.Forms.Button();
            this.OpenLogDirectoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogOutputTextbox
            // 
            this.LogOutputTextbox.Location = new System.Drawing.Point(12, 12);
            this.LogOutputTextbox.Multiline = true;
            this.LogOutputTextbox.Name = "LogOutputTextbox";
            this.LogOutputTextbox.ReadOnly = true;
            this.LogOutputTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogOutputTextbox.Size = new System.Drawing.Size(776, 407);
            this.LogOutputTextbox.TabIndex = 0;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(713, 425);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CopyToClipboardButton
            // 
            this.CopyToClipboardButton.Location = new System.Drawing.Point(600, 425);
            this.CopyToClipboardButton.Name = "CopyToClipboardButton";
            this.CopyToClipboardButton.Size = new System.Drawing.Size(107, 23);
            this.CopyToClipboardButton.TabIndex = 2;
            this.CopyToClipboardButton.Text = "Copy to Clipboard";
            this.CopyToClipboardButton.UseVisualStyleBackColor = true;
            this.CopyToClipboardButton.Click += new System.EventHandler(this.CopyToClipboardButton_Click);
            // 
            // OpenLogDirectoryButton
            // 
            this.OpenLogDirectoryButton.Location = new System.Drawing.Point(480, 425);
            this.OpenLogDirectoryButton.Name = "OpenLogDirectoryButton";
            this.OpenLogDirectoryButton.Size = new System.Drawing.Size(114, 23);
            this.OpenLogDirectoryButton.TabIndex = 3;
            this.OpenLogDirectoryButton.Text = "Open Log Directory";
            this.OpenLogDirectoryButton.UseVisualStyleBackColor = true;
            this.OpenLogDirectoryButton.Click += new System.EventHandler(this.OpenLogDirectoryButton_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 454);
            this.Controls.Add(this.OpenLogDirectoryButton);
            this.Controls.Add(this.CopyToClipboardButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.LogOutputTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogForm";
            this.Text = "Log Output";
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LogOutputTextbox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CopyToClipboardButton;
        private System.Windows.Forms.Button OpenLogDirectoryButton;
    }
}