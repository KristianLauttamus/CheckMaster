using CheckMaster.Restrictions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster.Modules
{
    [Serializable]
    class ReadFileAndCheckFor : Module
    {
        public String FILE_PATH;

        private ListBox RowsList;
        private ListBox RowItemsList;
        private TextBox AddRowTextBox;
        private TextBox AddRowItemTextBox;
        private CheckBox RowDisallowCheckBox;

        public ReadFileAndCheckFor()
        {
            this.FILE_PATH = "";
        }

        public void check()
        {
            throw new NotImplementedException();
        }

        public Control[] getEditControls()
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
            AddRowLabel.Location = new System.Drawing.Point(0, 75);
            AddRowLabel.Width = 200;
            AddRowLabel.Text = "Add Row to check";
            controls.Add(AddRowLabel);

            // AddRowTextBox
            AddRowTextBox = new TextBox();
            AddRowTextBox.Location = new System.Drawing.Point(0, 100);
            AddRowTextBox.Width = 200;
            AddRowTextBox.Multiline = false;
            controls.Add(AddRowTextBox);

            // AddRowButton
            Button AddRowButton = new Button();
            AddRowButton.Location = new System.Drawing.Point(200, 100);
            AddRowButton.Width = 50;
            AddRowButton.Text = "Add Row";
            AddRowButton.Click += new EventHandler(AddRowButton_Clicked);
            controls.Add(AddRowButton);

            // ListBox
            RowsList = new ListBox();
            RowsList.Width = 200;
            RowsList.Location = new System.Drawing.Point(0,125);
            RowsList.MeasureItem += new MeasureItemEventHandler(RowsList_MeasureItem);
            RowsList.DrawItem += new DrawItemEventHandler(RowsList_DrawItem);
            controls.Add(RowsList);
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
            controls.Add(AddRowItemTextBox);

            // AddRowItemButton
            Button AddRowItemButton = new Button();
            AddRowItemButton.Location = new System.Drawing.Point(450, 130);
            AddRowItemButton.Width = 50;
            AddRowItemButton.Text = "Add Item";
            AddRowItemButton.Click += new EventHandler(AddRowItemButton_Clicked);
            controls.Add(AddRowItemButton);
            
            // RowItemsList
            RowItemsList = new ListBox();
            RowItemsList.Width = 200;
            RowItemsList.Location = new System.Drawing.Point(250, 160);
            controls.Add(RowItemsList);
            #endregion

            return controls.ToArray();
        }

        #region Events
        private void RowDisallow_Changed(object sender, EventArgs e)
        {
            if(RowsList.SelectedIndex == -1)
            {
                return;
            }

            ((ListBoxItem)RowsList.Items[RowsList.SelectedIndex]).setDisallowed(((CheckBox)sender).Checked);
        }

        private void AddRowButton_Clicked(object sender, EventArgs e)
        {
            ListBoxItem listBoxItem = new ListBoxItem();
            listBoxItem.items = new List<string>();
            listBoxItem.disallowed = false;
            listBoxItem.row = AddRowTextBox.Text;
            this.RowsList.Items.Add(listBoxItem);

            AddRowTextBox.Text = "";
        }

        private void AddRowItemButton_Clicked(object sender, EventArgs e)
        {
            if (RowsList.SelectedIndex == -1)
            {
                return;
            }

            ((ListBoxItem)RowsList.Items[RowsList.SelectedIndex]).items.Add(AddRowTextBox.Text);
            AddRowTextBox.Text = "";
        }

        private void RowsList_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }

            e.ItemHeight = 20;

            foreach(string item in ((ListBoxItem)RowsList.Items[e.Index]).items)
            {
                e.ItemHeight += 25;
            }
        }

        private void RowsList_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

        private void FilePathChanged(object sender, EventArgs e)
        {
            this.FILE_PATH = ((TextBox)sender).Text;
        }
        #endregion

        public string[] getErrors()
        {
            throw new NotImplementedException();
        }

        public string getName()
        {
            return "";
        }

        public Status getStatus()
        {
            throw new NotImplementedException();
        }

        public void init()
        {
            throw new NotImplementedException();
        }

        #region Restrictions
        private List<Restriction> restrictions = new List<Restriction>();

        public void addRestriction(Restriction restriction)
        {
            this.restrictions.Add(restriction);
        }

        public void removeRestriction(int index)
        {
            this.restrictions.RemoveAt(index);
        }

        public void initRestrictions()
        {
            foreach (Restriction restriction in this.restrictions)
            {
                restriction.init();
            }
        }

        public bool isRestricted()
        {
            foreach (Restriction restriction in this.restrictions)
            {
                if (restriction.approved() == false)
                    return true;
            }

            return false;
        }

        public List<Restriction> getRestrictions()
        {
            return this.restrictions;
        }
        #endregion

        public override string ToString()
        {
            return "Read file and check lines";
        }

        [Serializable]
        public struct ListBoxItem
        {
            public string row;
            public bool disallowed;
            public List<string> items;

            public override string ToString()
            {
                String toString = row + "\n";

                foreach(string item in items)
                {
                    toString += " - " + item + "\n";
                }

                return toString;
            }

            internal void setDisallowed(bool disallowed)
            {
                this.disallowed = disallowed;
            }
        }
    }
}
