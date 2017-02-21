namespace CheckMaster
{
    partial class RestrictionEditingForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.moduleLabel = new System.Windows.Forms.Label();
            this.editPanel = new System.Windows.Forms.Panel();
            this.removeButton = new System.Windows.Forms.Button();
            this.restrictionsListBox = new System.Windows.Forms.ListBox();
            this.restrictionsComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(13, 282);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(443, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Module:";
            // 
            // moduleLabel
            // 
            this.moduleLabel.AutoSize = true;
            this.moduleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moduleLabel.Location = new System.Drawing.Point(57, 12);
            this.moduleLabel.Name = "moduleLabel";
            this.moduleLabel.Size = new System.Drawing.Size(106, 15);
            this.moduleLabel.TabIndex = 2;
            this.moduleLabel.Text = "Module\'s name";
            // 
            // editPanel
            // 
            this.editPanel.Location = new System.Drawing.Point(211, 29);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(245, 247);
            this.editPanel.TabIndex = 3;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(12, 253);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(193, 23);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "Remove Selected";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // restrictionsListBox
            // 
            this.restrictionsListBox.FormattingEnabled = true;
            this.restrictionsListBox.Location = new System.Drawing.Point(12, 60);
            this.restrictionsListBox.Name = "restrictionsListBox";
            this.restrictionsListBox.Size = new System.Drawing.Size(193, 186);
            this.restrictionsListBox.TabIndex = 5;
            this.restrictionsListBox.SelectedIndexChanged += new System.EventHandler(this.restrictionsListBox_SelectedIndexChanged);
            // 
            // restrictionsComboBox
            // 
            this.restrictionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.restrictionsComboBox.FormattingEnabled = true;
            this.restrictionsComboBox.Location = new System.Drawing.Point(12, 33);
            this.restrictionsComboBox.Name = "restrictionsComboBox";
            this.restrictionsComboBox.Size = new System.Drawing.Size(193, 21);
            this.restrictionsComboBox.TabIndex = 0;
            this.restrictionsComboBox.SelectedIndexChanged += new System.EventHandler(this.restrictionsComboBox_SelectedIndexChanged);
            // 
            // RestrictionEditingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 317);
            this.Controls.Add(this.restrictionsComboBox);
            this.Controls.Add(this.restrictionsListBox);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.editPanel);
            this.Controls.Add(this.moduleLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeButton);
            this.Name = "RestrictionEditingForm";
            this.Text = "RestrictionEditingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RestrictionEditingForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label moduleLabel;
        private System.Windows.Forms.Panel editPanel;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ListBox restrictionsListBox;
        private System.Windows.Forms.ComboBox restrictionsComboBox;
    }
}