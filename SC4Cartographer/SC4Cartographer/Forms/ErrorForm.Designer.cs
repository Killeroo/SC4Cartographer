namespace SC4CartographerUI
{
    partial class ErrorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
            this.OKButton = new System.Windows.Forms.Button();
            this.CopyErrorButton = new System.Windows.Forms.Button();
            this.Line3Label = new System.Windows.Forms.Label();
            this.ErrorMessageTextbox = new System.Windows.Forms.TextBox();
            this.MainErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OKButton.Location = new System.Drawing.Point(653, 89);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CopyErrorButton
            // 
            this.CopyErrorButton.Location = new System.Drawing.Point(510, 89);
            this.CopyErrorButton.Name = "CopyErrorButton";
            this.CopyErrorButton.Size = new System.Drawing.Size(137, 23);
            this.CopyErrorButton.TabIndex = 6;
            this.CopyErrorButton.Text = "Copy Details to Clipboard";
            this.CopyErrorButton.UseVisualStyleBackColor = true;
            this.CopyErrorButton.Click += new System.EventHandler(this.CopyErrorButton_Click);
            // 
            // Line3Label
            // 
            this.Line3Label.AutoSize = true;
            this.Line3Label.Location = new System.Drawing.Point(64, 35);
            this.Line3Label.Name = "Line3Label";
            this.Line3Label.Size = new System.Drawing.Size(0, 13);
            this.Line3Label.TabIndex = 7;
            // 
            // ErrorMessageTextbox
            // 
            this.ErrorMessageTextbox.Location = new System.Drawing.Point(67, 23);
            this.ErrorMessageTextbox.Multiline = true;
            this.ErrorMessageTextbox.Name = "ErrorMessageTextbox";
            this.ErrorMessageTextbox.ReadOnly = true;
            this.ErrorMessageTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ErrorMessageTextbox.Size = new System.Drawing.Size(661, 60);
            this.ErrorMessageTextbox.TabIndex = 8;
            // 
            // MainErrorLabel
            // 
            this.MainErrorLabel.AutoSize = true;
            this.MainErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainErrorLabel.Location = new System.Drawing.Point(64, 7);
            this.MainErrorLabel.Name = "MainErrorLabel";
            this.MainErrorLabel.Size = new System.Drawing.Size(29, 13);
            this.MainErrorLabel.TabIndex = 9;
            this.MainErrorLabel.Text = "Error";
            // 
            // ErrorForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.OKButton;
            this.ClientSize = new System.Drawing.Size(740, 121);
            this.Controls.Add(this.MainErrorLabel);
            this.Controls.Add(this.ErrorMessageTextbox);
            this.Controls.Add(this.Line3Label);
            this.Controls.Add(this.CopyErrorButton);
            this.Controls.Add(this.OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ErrorForm";
            this.Text = "Error";
            this.Load += new System.EventHandler(this.ErrorForm_OnLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ErrorForm_OnPaint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CopyErrorButton;
        private System.Windows.Forms.Label Line3Label;
        private System.Windows.Forms.TextBox ErrorMessageTextbox;
        private System.Windows.Forms.Label MainErrorLabel;
    }
}