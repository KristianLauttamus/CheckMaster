namespace CheckMaster
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.howManyRanLabel = new System.Windows.Forms.Label();
            this.statusList = new System.Windows.Forms.ListBox();
            this.computerInfo = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(62, 257);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Load Settings";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // howManyRanLabel
            // 
            this.howManyRanLabel.AutoSize = true;
            this.howManyRanLabel.Location = new System.Drawing.Point(13, 13);
            this.howManyRanLabel.Name = "howManyRanLabel";
            this.howManyRanLabel.Size = new System.Drawing.Size(78, 13);
            this.howManyRanLabel.TabIndex = 2;
            this.howManyRanLabel.Text = "Ran 0 modules";
            // 
            // statusList
            // 
            this.statusList.BackColor = System.Drawing.SystemColors.Control;
            this.statusList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.statusList.FormattingEnabled = true;
            this.statusList.Location = new System.Drawing.Point(13, 56);
            this.statusList.Name = "statusList";
            this.statusList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.statusList.Size = new System.Drawing.Size(166, 195);
            this.statusList.TabIndex = 3;
            this.statusList.TabStop = false;
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
            // CheckMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 292);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.computerInfo);
            this.Controls.Add(this.statusList);
            this.Controls.Add(this.howManyRanLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckMasterForm";
            this.Text = "CheckMaster";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckMasterForm_FormClosing);
            this.Load += new System.EventHandler(this.CheckMasterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label howManyRanLabel;
        private System.Windows.Forms.ListBox statusList;
        private System.Windows.Forms.Button computerInfo;
        private System.Windows.Forms.Button okButton;
    }
}

