﻿namespace CheckMaster
{
    partial class CheckMasterForm
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
            this.editButton = new System.Windows.Forms.Button();
            this.loadSettingsButton = new System.Windows.Forms.Button();
            this.howManyRanLabel = new System.Windows.Forms.Label();
            this.computerInfo = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.currentFileLabel = new System.Windows.Forms.Label();
            this.modulesLabelPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(5, 262);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(43, 23);
            this.editButton.TabIndex = 0;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // loadSettingsButton
            // 
            this.loadSettingsButton.Location = new System.Drawing.Point(54, 262);
            this.loadSettingsButton.Name = "loadSettingsButton";
            this.loadSettingsButton.Size = new System.Drawing.Size(92, 23);
            this.loadSettingsButton.TabIndex = 1;
            this.loadSettingsButton.Text = "Load Settings";
            this.loadSettingsButton.UseVisualStyleBackColor = true;
            this.loadSettingsButton.Click += new System.EventHandler(this.loadSettingsButton_Click);
            // 
            // howManyRanLabel
            // 
            this.howManyRanLabel.AutoSize = true;
            this.howManyRanLabel.Location = new System.Drawing.Point(2, 9);
            this.howManyRanLabel.Name = "howManyRanLabel";
            this.howManyRanLabel.Size = new System.Drawing.Size(78, 13);
            this.howManyRanLabel.TabIndex = 2;
            this.howManyRanLabel.Text = "Ran 0 modules";
            // 
            // computerInfo
            // 
            this.computerInfo.Location = new System.Drawing.Point(367, 3);
            this.computerInfo.Name = "computerInfo";
            this.computerInfo.Size = new System.Drawing.Size(90, 23);
            this.computerInfo.TabIndex = 4;
            this.computerInfo.Text = "Computer info";
            this.computerInfo.UseVisualStyleBackColor = true;
            this.computerInfo.Click += new System.EventHandler(this.computerInfo_Click);
            // 
            // okButton
            // 
            this.okButton.Enabled = false;
            this.okButton.Location = new System.Drawing.Point(367, 257);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(89, 32);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // currentFileLabel
            // 
            this.currentFileLabel.AutoSize = true;
            this.currentFileLabel.Location = new System.Drawing.Point(152, 267);
            this.currentFileLabel.Name = "currentFileLabel";
            this.currentFileLabel.Size = new System.Drawing.Size(60, 13);
            this.currentFileLabel.TabIndex = 6;
            this.currentFileLabel.Text = "Current File";
            // 
            // modulesLabelPanel
            // 
            this.modulesLabelPanel.AutoScroll = true;
            this.modulesLabelPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.modulesLabelPanel.Location = new System.Drawing.Point(13, 32);
            this.modulesLabelPanel.Name = "modulesLabelPanel";
            this.modulesLabelPanel.Size = new System.Drawing.Size(435, 219);
            this.modulesLabelPanel.TabIndex = 7;
            // 
            // CheckMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 292);
            this.Controls.Add(this.modulesLabelPanel);
            this.Controls.Add(this.currentFileLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.computerInfo);
            this.Controls.Add(this.howManyRanLabel);
            this.Controls.Add(this.loadSettingsButton);
            this.Controls.Add(this.editButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckMasterForm";
            this.Text = "CheckMaster";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckMasterForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button loadSettingsButton;
        private System.Windows.Forms.Label howManyRanLabel;
        private System.Windows.Forms.Button computerInfo;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label currentFileLabel;
        private System.Windows.Forms.Panel modulesLabelPanel;
    }
}

