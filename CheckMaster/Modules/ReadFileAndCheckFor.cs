using CheckMaster.Restrictions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster.Modules
{
    [Serializable]
    class ReadFileAndCheckFor : MasterModule
    {
        private String FILE_PATH;

        private Status status;
        private List<string> errors;
        private List<ListBoxItem> rows;
        private bool runOnCheck;

        [NonSerialized]
        private ListBox RowsList;
        [NonSerialized]
        private ListBox RowItemsList;
        [NonSerialized]
        private TextBox AddRowTextBox;
        [NonSerialized]
        private TextBox AddRowItemTextBox;
        [NonSerialized]
        private CheckBox RowDisallowCheckBox;
        [NonSerialized]
        private Button RemoveRowButton;
        [NonSerialized]
        private Button RemoveRowItemButton;
        [NonSerialized]
        private Button AddRowItemButton;

        public ReadFileAndCheckFor()
        {
            this.FILE_PATH = "";
            this.status = Status.NOTRUN;
            this.errors = new List<string>();
            this.rows = new List<ListBoxItem>();
            this.runOnCheck = false;
        }

        public override void check()
        {
            if (runOnCheck)
            {
                this.checkFile();
            }
        }

        public override Control[] getEditControls()
        {
            List<Control> controls = new List<Control>();

            // FilePathLabel
            Label FilePathLabel = new Label();
            FilePathLabel.Location = new System.Drawing.Point(0, 0);
            FilePathLabel.Width = 75;
            FilePathLabel.Text = "Full Filepath:";
            controls.Add(FilePathLabel);

            // FilePath
            TextBox FilePathTextBox = new TextBox();
            FilePathTextBox.Location = new System.Drawing.Point(75, 0);
            FilePathTextBox.Width = 200;
            FilePathTextBox.Multiline = false;
            FilePathTextBox.TextChanged += new EventHandler(FilePathChanged);
            FilePathTextBox.Text = this.FILE_PATH;
            controls.Add(FilePathTextBox);

            // FilePathLabel
            Label FilePathExampleLabel = new Label();
            FilePathExampleLabel.Location = new System.Drawing.Point(0, 25);
            FilePathExampleLabel.Width = 300;
            FilePathExampleLabel.Text = "For example: C:/Config/INSTALLED_PACKAGES.txt";
            FilePathExampleLabel.ForeColor = System.Drawing.Color.Coral;
            controls.Add(FilePathExampleLabel);

            #region Rows
            // AddRowLabel
            Label AddRowLabel = new Label();
            AddRowLabel.Location = new System.Drawing.Point(0, 100);
            AddRowLabel.Width = 200;
            AddRowLabel.Text = "Add Row to check";
            controls.Add(AddRowLabel);

            // AddRowTextBox
            AddRowTextBox = new TextBox();
            AddRowTextBox.Location = new System.Drawing.Point(0, 130);
            AddRowTextBox.Width = 200;
            AddRowTextBox.Multiline = false;
            controls.Add(AddRowTextBox);

            // AddRowButton
            Button AddRowButton = new Button();
            AddRowButton.Location = new System.Drawing.Point(200, 130);
            AddRowButton.Width = 50;
            AddRowButton.Text = "Add Row";
            AddRowButton.Click += new EventHandler(AddRowButton_Clicked);
            controls.Add(AddRowButton);

            // ListBox
            RowsList = new ListBox();
            RowsList.Width = 200;
            RowsList.Height = 100;
            RowsList.Location = new System.Drawing.Point(0,160);
            RowsList.SelectedIndexChanged += new EventHandler(RowsList_SelectedIndexChanged);
            controls.Add(RowsList);

            // RemoveRowButton
            RemoveRowButton = new Button();
            RemoveRowButton.Width = 200;
            RemoveRowButton.Text = "Remove selected";
            RemoveRowButton.Location = new System.Drawing.Point(0,260);
            RemoveRowButton.Click += new EventHandler(RemoveRowButton_Click);
            RemoveRowButton.Enabled = false;
            controls.Add(RemoveRowButton);
            #endregion

            #region Row Actions
            // RowDisallowCheckBox
            RowDisallowCheckBox = new CheckBox();
            RowDisallowCheckBox.Width = 200;
            RowDisallowCheckBox.Location = new System.Drawing.Point(250, 75);
            RowDisallowCheckBox.Enabled = false;
            RowDisallowCheckBox.Text = "Items disallowed";
            RowDisallowCheckBox.CheckedChanged += new EventHandler(RowDisallow_Changed);
            controls.Add(RowDisallowCheckBox);

            // AddRowItemLabel
            Label AddRowItemLabel = new Label();
            AddRowItemLabel.Location = new System.Drawing.Point(250, 100);
            AddRowItemLabel.Width = 200;
            AddRowItemLabel.Text = "Add Item to check from Row";
            controls.Add(AddRowItemLabel);

            // AddRowItemTextBox
            AddRowItemTextBox = new TextBox();
            AddRowItemTextBox.Location = new System.Drawing.Point(250, 130);
            AddRowItemTextBox.Width = 200;
            AddRowItemTextBox.Multiline = false;
            AddRowItemTextBox.Enabled = false;
            controls.Add(AddRowItemTextBox);

            // AddRowItemButton
            AddRowItemButton = new Button();
            AddRowItemButton.Location = new System.Drawing.Point(450, 130);
            AddRowItemButton.Width = 50;
            AddRowItemButton.Text = "Add Item";
            AddRowItemButton.Enabled = false;
            AddRowItemButton.Click += new EventHandler(AddRowItemButton_Clicked);
            controls.Add(AddRowItemButton);
            
            // RowItemsList
            RowItemsList = new ListBox();
            RowItemsList.Width = 200;
            RowItemsList.Height = 100;
            RowItemsList.Location = new System.Drawing.Point(250, 160);
            RowItemsList.SelectedIndexChanged += new EventHandler(RowItemsList_SelectedIndexChanged);
            RowItemsList.Items.AddRange(this.rows.ToArray());
            controls.Add(RowItemsList);

            // RemoveRowItemButton
            RemoveRowItemButton = new Button();
            RemoveRowItemButton.Width = 200;
            RemoveRowItemButton.Text = "Remove selected";
            RemoveRowItemButton.Location = new System.Drawing.Point(250, 260);
            RemoveRowItemButton.Click += new EventHandler(RemoveRowItemButton_Click);
            RemoveRowItemButton.Enabled = false;
            controls.Add(RemoveRowItemButton);
            #endregion

            // Run on update
            CheckBox RunOnUpdate = new CheckBox();
            RunOnUpdate.Location = new System.Drawing.Point(0,300);
            RunOnUpdate.Text = "Run continuously";
            RunOnUpdate.CheckedChanged += new EventHandler(RunOnUpdate_CheckedChanged);
            RunOnUpdate.Width = 200;
            RunOnUpdate.Checked = false;
            controls.Add(RunOnUpdate);

            return controls.ToArray();
        }

        #region Events
        private void RunOnUpdate_CheckedChanged(object sender, EventArgs e)
        {
            this.runOnCheck = ((CheckBox)sender).Checked;
        }

        private void RowItemsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedIndex >= 0)
            {
                this.RemoveRowItemButton.Enabled = true;
            }
            else
            {
                this.RemoveRowItemButton.Enabled = false;
            }
        }

        private void RemoveRowItemButton_Click(object sender, EventArgs e)
        {
            if (this.RowItemsList.SelectedIndex >= 0)
            {
                ((ListBoxItem)this.RowsList.Items[this.RowsList.SelectedIndex]).items.RemoveAt(this.RowItemsList.SelectedIndex);
                this.RowItemsList.Items.RemoveAt(this.RowItemsList.SelectedIndex);

                // Serializable
                this.rows.RemoveAt(this.RowItemsList.SelectedIndex);
            }
        }

        private void RemoveRowButton_Click(object sender, EventArgs e)
        {
            if (this.RowsList.SelectedIndex >= 0)
            {
                this.RowsList.Items.RemoveAt(this.RowsList.SelectedIndex);
            }
        }

        private void RowsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedIndex >= 0)
            {
                RowItemsList.Items.Clear();
                RowDisallowCheckBox.Enabled = true;
                ListBox list = (ListBox)sender;
                ListBoxItem item = (ListBoxItem)list.Items[list.SelectedIndex];
                RowDisallowCheckBox.Checked = item.disallowed;
                RowItemsList.Enabled = true;
                AddRowItemButton.Enabled = true;
                AddRowItemTextBox.Enabled = true;
                RowItemsList.Items.AddRange(item.items.ToArray());
                RemoveRowButton.Enabled = true;
            }
            else
            {
                RowDisallowCheckBox.Enabled = false;
                RowDisallowCheckBox.Checked = false;
                RemoveRowButton.Enabled = false;
                RowItemsList.Enabled = false;
                AddRowItemButton.Enabled = false;
                AddRowItemTextBox.Enabled = false;
                RemoveRowItemButton.Enabled = false;
                RowItemsList.Items.Clear();
            }
        }

        private void RowDisallow_Changed(object sender, EventArgs e)
        {
            if(RowsList.SelectedIndex <= -1)
            {
                return;
            }

            ListBoxItem item = (ListBoxItem)RowsList.Items[RowsList.SelectedIndex];
            item.disallowed = ((CheckBox)sender).Checked;

            // Serializable
            item = this.rows[RowsList.SelectedIndex];
            item.disallowed = ((CheckBox)sender).Checked;
        }

        private void AddRowButton_Clicked(object sender, EventArgs e)
        {
            ListBoxItem listBoxItem = new ListBoxItem();
            listBoxItem.items = new List<string>();
            listBoxItem.disallowed = false;
            listBoxItem.row = AddRowTextBox.Text;
            this.RowsList.Items.Add(listBoxItem);

            // Serializable
            this.rows.Add(listBoxItem);

            AddRowTextBox.Text = "";
        }

        private void AddRowItemButton_Clicked(object sender, EventArgs e)
        {
            if (RowsList.SelectedIndex == -1)
            {
                return;
            }

            // Serializable
            this.rows[RowsList.SelectedIndex].items.Add(AddRowItemTextBox.Text);

            ((ListBoxItem)RowsList.Items[RowsList.SelectedIndex]).items.Add(AddRowItemTextBox.Text);
            RowItemsList.Items.Add(AddRowItemTextBox.Text);
            AddRowTextBox.Text = "";
        }

        private void FilePathChanged(object sender, EventArgs e)
        {
            this.FILE_PATH = ((TextBox)sender).Text;
        }
        #endregion

        public override string[] getErrors()
        {
            return this.errors.ToArray();
        }

        public override Status getStatus()
        {
            return this.status;
        }

        public override void init()
        {
            this.checkFile();
        }

        public void checkFile()
        {
            if (this.rows == null)
            {
                this.rows = new List<ListBoxItem>();
            }

            this.errors.Clear();
            this.status = Status.NOTRUN;

            if (File.Exists(this.FILE_PATH))
            {
                FileStream fs = File.OpenRead(this.FILE_PATH);
                Dictionary<ListBoxItem, bool> found = new Dictionary<ListBoxItem, bool>();

                using (StreamReader sr = new StreamReader(fs))
                {
                    while (sr.Peek() >= 0)
                    {
                        string line = sr.ReadLine();
                        found = new Dictionary<ListBoxItem, bool>();

                        foreach (ListBoxItem item in this.rows)
                        {
                            if (line.Contains(item.row))
                            {
                                bool founded = false;

                                foreach (string rowItem in item.items)
                                {
                                    if (line.Contains(rowItem))
                                    {
                                        founded = true;
                                    }
                                }

                                found.Add(item, founded);
                            }
                        }
                    }
                }

                foreach (ListBoxItem item in found.Keys)
                {
                    if (item.disallowed && found[item])
                    {
                        this.status = Status.FAIL;
                        this.errors.Add("Row (" + item.row + ") failed, items found");
                    }
                    if (item.disallowed == false && found[item] == false)
                    {
                        this.status = Status.FAIL;
                        this.errors.Add("Row (" + item.row + ") failed, items not found");
                    }
                }

                if (status == Status.NOTRUN)
                {
                    status = Status.OK;
                }
            }
            else
            {
                this.errors.Add("File (" + this.FILE_PATH + ") not found");
                this.status = Status.FAIL;
            }
        }

        public override string ToString()
        {
            return "Read file and check lines";
        }
    }
}
