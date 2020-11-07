namespace SC4CartographerUI
{
    partial class MapErrorForm
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
            this.OKButton = new System.Windows.Forms.Button();
            this.CopyErrorButton = new System.Windows.Forms.Button();
            this.Line3Label = new System.Windows.Forms.Label();
            this.ErrorMessageTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OKButton
            // 
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
            this.CopyErrorButton.Location = new System.Drawing.Point(515, 89);
            this.CopyErrorButton.Name = "CopyErrorButton";
            this.CopyErrorButton.Size = new System.Drawing.Size(132, 23);
            this.CopyErrorButton.TabIndex = 6;
            this.CopyErrorButton.Text = "Copy details to clipboard";
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
            this.ErrorMessageTextbox.Location = new System.Drawing.Point(67, 9);
            this.ErrorMessageTextbox.Multiline = true;
            this.ErrorMessageTextbox.Name = "ErrorMessageTextbox";
            this.ErrorMessageTextbox.ReadOnly = true;
            this.ErrorMessageTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ErrorMessageTextbox.Size = new System.Drawing.Size(661, 74);
            this.ErrorMessageTextbox.TabIndex = 8;
            // 
            // MapErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 121);
            this.Controls.Add(this.ErrorMessageTextbox);
            this.Controls.Add(this.Line3Label);
            this.Controls.Add(this.CopyErrorButton);
            this.Controls.Add(this.OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MapErrorForm";
            this.Text = "Error";
            this.Load += new System.EventHandler(this.MapErrorForm_OnLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MapErrorForm_OnPaint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CopyErrorButton;
        private System.Windows.Forms.Label Line3Label;
        private System.Windows.Forms.TextBox ErrorMessageTextbox;
    }
}