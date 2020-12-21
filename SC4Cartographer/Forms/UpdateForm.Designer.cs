namespace SC4CartographerUI
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.DoNotShowAgainCheckbox = new System.Windows.Forms.CheckBox();
            this.YesButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.ChangelogTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UpdateLabel = new System.Windows.Forms.Label();
            this.UpdatePageLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // DoNotShowAgainCheckbox
            // 
            this.DoNotShowAgainCheckbox.AutoSize = true;
            this.DoNotShowAgainCheckbox.Checked = true;
            this.DoNotShowAgainCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DoNotShowAgainCheckbox.Location = new System.Drawing.Point(38, 176);
            this.DoNotShowAgainCheckbox.Name = "DoNotShowAgainCheckbox";
            this.DoNotShowAgainCheckbox.Size = new System.Drawing.Size(204, 17);
            this.DoNotShowAgainCheckbox.TabIndex = 0;
            this.DoNotShowAgainCheckbox.Text = "Don\'t automatically check for updates";
            this.DoNotShowAgainCheckbox.UseVisualStyleBackColor = true;
            this.DoNotShowAgainCheckbox.CheckedChanged += new System.EventHandler(this.DoNotShowAgainCheckbox_CheckedChanged);
            // 
            // YesButton
            // 
            this.YesButton.Location = new System.Drawing.Point(110, 199);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(75, 23);
            this.YesButton.TabIndex = 1;
            this.YesButton.Text = "Yes";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // NoButton
            // 
            this.NoButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.NoButton.Location = new System.Drawing.Point(191, 199);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(75, 23);
            this.NoButton.TabIndex = 2;
            this.NoButton.Text = "No";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // ChangelogTextBox
            // 
            this.ChangelogTextBox.Location = new System.Drawing.Point(38, 51);
            this.ChangelogTextBox.Multiline = true;
            this.ChangelogTextBox.Name = "ChangelogTextBox";
            this.ChangelogTextBox.ReadOnly = true;
            this.ChangelogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ChangelogTextBox.Size = new System.Drawing.Size(228, 97);
            this.ChangelogTextBox.TabIndex = 3;
            this.ChangelogTextBox.Text = "Changelog";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "A new version is available.";
            // 
            // UpdateLabel
            // 
            this.UpdateLabel.AutoSize = true;
            this.UpdateLabel.Location = new System.Drawing.Point(61, 23);
            this.UpdateLabel.Name = "UpdateLabel";
            this.UpdateLabel.Size = new System.Drawing.Size(158, 13);
            this.UpdateLabel.TabIndex = 5;
            this.UpdateLabel.Text = "Do you want to download v1.1?";
            // 
            // UpdatePageLinkLabel
            // 
            this.UpdatePageLinkLabel.AutoSize = true;
            this.UpdatePageLinkLabel.Location = new System.Drawing.Point(35, 155);
            this.UpdatePageLinkLabel.Name = "UpdatePageLinkLabel";
            this.UpdatePageLinkLabel.Size = new System.Drawing.Size(120, 13);
            this.UpdatePageLinkLabel.TabIndex = 6;
            this.UpdatePageLinkLabel.TabStop = true;
            this.UpdatePageLinkLabel.Text = "View release on github..";
            this.UpdatePageLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UpdatePageLinkLabel_LinkClicked);
            // 
            // UpdateForm
            // 
            this.AcceptButton = this.YesButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.NoButton;
            this.ClientSize = new System.Drawing.Size(278, 231);
            this.Controls.Add(this.UpdatePageLinkLabel);
            this.Controls.Add(this.UpdateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChangelogTextBox);
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.DoNotShowAgainCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SC4Cartographer Update Available";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateForm_OnClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateForm_OnPaint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox DoNotShowAgainCheckbox;
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Button NoButton;
        private System.Windows.Forms.TextBox ChangelogTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UpdateLabel;
        private System.Windows.Forms.LinkLabel UpdatePageLinkLabel;
    }
}