namespace CheckMaster
{
    partial class EditModulesForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.modulesSelection = new System.Windows.Forms.ComboBox();
            this.addedModulesList = new System.Windows.Forms.ListBox();
            this.moduleLabel = new System.Windows.Forms.Label();
            this.removeModuleButton = new System.Windows.Forms.Button();
            this.editPanel = new System.Windows.Forms.Panel();
            this.addedSuccessModulesList = new System.Windows.Forms.ListBox();
            this.removeSuccessModuleButton = new System.Windows.Forms.Button();
            this.successModulesSelection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editSuccessModuleRestrictions = new System.Windows.Forms.Button();
            this.editModuleRestrictions = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(692, 402);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(99, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // modulesSelection
            // 
            this.modulesSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modulesSelection.FormattingEnabled = true;
            this.modulesSelection.Location = new System.Drawing.Point(12, 29);
            this.modulesSelection.Name = "modulesSelection";
            this.modulesSelection.Size = new System.Drawing.Size(171, 21);
            this.modulesSelection.TabIndex = 1;
            this.modulesSelection.TabStop = false;
            this.modulesSelection.SelectedIndexChanged += new System.EventHandler(this.modulesSelection_SelectedIndexChanged);
            // 
            // addedModulesList
            // 
            this.addedModulesList.FormattingEnabled = true;
            this.addedModulesList.Location = new System.Drawing.Point(13, 54);
            this.addedModulesList.Name = "addedModulesList";
            this.addedModulesList.Size = new System.Drawing.Size(171, 316);
            this.addedModulesList.TabIndex = 2;
            this.addedModulesList.SelectedIndexChanged += new System.EventHandler(this.addedModulesList_SelectedIndexChanged);
            // 
            // moduleLabel
            // 
            this.moduleLabel.AutoSize = true;
            this.moduleLabel.Location = new System.Drawing.Point(12, 13);
            this.moduleLabel.Name = "moduleLabel";
            this.moduleLabel.Size = new System.Drawing.Size(47, 13);
            this.moduleLabel.TabIndex = 3;
            this.moduleLabel.Text = "Modules";
            // 
            // removeModuleButton
            // 
            this.removeModuleButton.Enabled = false;
            this.removeModuleButton.Location = new System.Drawing.Point(12, 376);
            this.removeModuleButton.Name = "removeModuleButton";
            this.removeModuleButton.Size = new System.Drawing.Size(172, 23);
            this.removeModuleButton.TabIndex = 4;
            this.removeModuleButton.Text = "Remove";
            this.removeModuleButton.UseVisualStyleBackColor = true;
            this.removeModuleButton.Click += new System.EventHandler(this.removeModuleButton_Click);
            // 
            // editPanel
            // 
            this.editPanel.Location = new System.Drawing.Point(368, 29);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(504, 367);
            this.editPanel.TabIndex = 5;
            // 
            // addedSuccessModulesList
            // 
            this.addedSuccessModulesList.FormattingEnabled = true;
            this.addedSuccessModulesList.Location = new System.Drawing.Point(190, 54);
            this.addedSuccessModulesList.Name = "addedSuccessModulesList";
            this.addedSuccessModulesList.Size = new System.Drawing.Size(171, 316);
            this.addedSuccessModulesList.TabIndex = 6;
            this.addedSuccessModulesList.SelectedIndexChanged += new System.EventHandler(this.addedSuccessModulesList_SelectedIndexChanged);
            // 
            // removeSuccessModuleButton
            // 
            this.removeSuccessModuleButton.Enabled = false;
            this.removeSuccessModuleButton.Location = new System.Drawing.Point(190, 376);
            this.removeSuccessModuleButton.Name = "removeSuccessModuleButton";
            this.removeSuccessModuleButton.Size = new System.Drawing.Size(172, 23);
            this.removeSuccessModuleButton.TabIndex = 7;
            this.removeSuccessModuleButton.Text = "Remove";
            this.removeSuccessModuleButton.UseVisualStyleBackColor = true;
            this.removeSuccessModuleButton.Click += new System.EventHandler(this.removeSuccessModuleButton_Click);
            // 
            // successModulesSelection
            // 
            this.successModulesSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.successModulesSelection.FormattingEnabled = true;
            this.successModulesSelection.Location = new System.Drawing.Point(189, 27);
            this.successModulesSelection.Name = "successModulesSelection";
            this.successModulesSelection.Size = new System.Drawing.Size(171, 21);
            this.successModulesSelection.TabIndex = 8;
            this.successModulesSelection.TabStop = false;
            this.successModulesSelection.SelectedIndexChanged += new System.EventHandler(this.successModulesSelection_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "SuccessModules";
            // 
            // editSuccessModuleRestrictions
            // 
            this.editSuccessModuleRestrictions.Enabled = false;
            this.editSuccessModuleRestrictions.Location = new System.Drawing.Point(190, 405);
            this.editSuccessModuleRestrictions.Name = "editSuccessModuleRestrictions";
            this.editSuccessModuleRestrictions.Size = new System.Drawing.Size(172, 23);
            this.editSuccessModuleRestrictions.TabIndex = 10;
            this.editSuccessModuleRestrictions.Text = "Edit Restrictions...";
            this.editSuccessModuleRestrictions.UseVisualStyleBackColor = true;
            this.editSuccessModuleRestrictions.Click += new System.EventHandler(this.editSuccessModuleRestrictions_Click);
            // 
            // editModuleRestrictions
            // 
            this.editModuleRestrictions.Enabled = false;
            this.editModuleRestrictions.Location = new System.Drawing.Point(12, 405);
            this.editModuleRestrictions.Name = "editModuleRestrictions";
            this.editModuleRestrictions.Size = new System.Drawing.Size(172, 23);
            this.editModuleRestrictions.TabIndex = 11;
            this.editModuleRestrictions.Text = "Edit Restrictions...";
            this.editModuleRestrictions.UseVisualStyleBackColor = true;
            this.editModuleRestrictions.Click += new System.EventHandler(this.editModuleRestrictions_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(797, 402);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(75, 23);
            this.saveAsButton.TabIndex = 12;
            this.saveAsButton.Text = "Save As...";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // EditModulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 432);
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.editModuleRestrictions);
            this.Controls.Add(this.editSuccessModuleRestrictions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.successModulesSelection);
            this.Controls.Add(this.removeSuccessModuleButton);
            this.Controls.Add(this.addedSuccessModulesList);
            this.Controls.Add(this.editPanel);
            this.Controls.Add(this.removeModuleButton);
            this.Controls.Add(this.moduleLabel);
            this.Controls.Add(this.addedModulesList);
            this.Controls.Add(this.modulesSelection);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditModulesForm";
            this.Text = "EditModules";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditModulesForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox modulesSelection;
        private System.Windows.Forms.ListBox addedModulesList;
        private System.Windows.Forms.Label moduleLabel;
        private System.Windows.Forms.Button removeModuleButton;
        private System.Windows.Forms.Panel editPanel;
        private System.Windows.Forms.ListBox addedSuccessModulesList;
        private System.Windows.Forms.Button removeSuccessModuleButton;
        private System.Windows.Forms.ComboBox successModulesSelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editSuccessModuleRestrictions;
        private System.Windows.Forms.Button editModuleRestrictions;
        private System.Windows.Forms.Button saveAsButton;
    }
}