namespace CheckMaster
{
    partial class ComputerInfoForm
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
            this.ComputerInfoList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkToCreator = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // ComputerInfoList
            // 
            this.ComputerInfoList.BackColor = System.Drawing.SystemColors.Control;
            this.ComputerInfoList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ComputerInfoList.FormattingEnabled = true;
            this.ComputerInfoList.Location = new System.Drawing.Point(13, 35);
            this.ComputerInfoList.Name = "ComputerInfoList";
            this.ComputerInfoList.Size = new System.Drawing.Size(387, 208);
            this.ComputerInfoList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Computer Info";
            // 
            // linkToCreator
            // 
            this.linkToCreator.ActiveLinkColor = System.Drawing.Color.Red;
            this.linkToCreator.AutoSize = true;
            this.linkToCreator.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkToCreator.Location = new System.Drawing.Point(15, 250);
            this.linkToCreator.Name = "linkToCreator";
            this.linkToCreator.Size = new System.Drawing.Size(380, 13);
            this.linkToCreator.TabIndex = 2;
            this.linkToCreator.TabStop = true;
            this.linkToCreator.Text = "Ohjelman on suunnitellut, ohjelmoinut ja optimoinut: Kristian Lauttamus 9.2.2017";
            this.linkToCreator.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkToCreator_LinkClicked);
            // 
            // ComputerInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 269);
            this.Controls.Add(this.linkToCreator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComputerInfoList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComputerInfoForm";
            this.Text = "ComputerInfoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ComputerInfoList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkToCreator;
    }
}