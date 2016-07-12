namespace Sdl.EditorOperations.Sample
{
    partial class MyEditorViewPartControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DocumentsList = new System.Windows.Forms.ListView();
            this.DocumentNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SegmentsCountColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SourceLanguageColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TargetLanguageColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OpenUsingStudioActionButton = new System.Windows.Forms.Button();
            this.SaveAllButton = new System.Windows.Forms.Button();
            this.ReplaceAllButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ReplaceText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FindText = new System.Windows.Forms.TextBox();
            this.FindReplaceActiveButton = new System.Windows.Forms.RadioButton();
            this.FindReplaceAllButton = new System.Windows.Forms.RadioButton();
            this.CloseAllDocumentsButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.EventsListView = new System.Windows.Forms.ListView();
            this.EventIndexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EventName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EventMetadataColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ReplaceSelectionButton = new System.Windows.Forms.Button();
            this.ReplaceSelectionTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CurrentSelectionTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(920, 200);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DocumentsList);
            this.tabPage1.Controls.Add(this.OpenUsingStudioActionButton);
            this.tabPage1.Controls.Add(this.SaveAllButton);
            this.tabPage1.Controls.Add(this.ReplaceAllButton);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.ReplaceText);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.FindText);
            this.tabPage1.Controls.Add(this.FindReplaceActiveButton);
            this.tabPage1.Controls.Add(this.FindReplaceAllButton);
            this.tabPage1.Controls.Add(this.CloseAllDocumentsButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(912, 174);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DocumentsList
            // 
            this.DocumentsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DocumentNameColumn,
            this.SegmentsCountColumn,
            this.SourceLanguageColumn,
            this.TargetLanguageColumn});
            this.DocumentsList.Dock = System.Windows.Forms.DockStyle.Left;
            this.DocumentsList.FullRowSelect = true;
            this.DocumentsList.GridLines = true;
            this.DocumentsList.HideSelection = false;
            this.DocumentsList.Location = new System.Drawing.Point(3, 3);
            this.DocumentsList.MultiSelect = false;
            this.DocumentsList.Name = "DocumentsList";
            this.DocumentsList.Size = new System.Drawing.Size(528, 168);
            this.DocumentsList.TabIndex = 18;
            this.DocumentsList.UseCompatibleStateImageBehavior = false;
            this.DocumentsList.View = System.Windows.Forms.View.Details;
            this.DocumentsList.ItemActivate += new System.EventHandler(this.DocumentsList_ItemActivate);
            // 
            // DocumentNameColumn
            // 
            this.DocumentNameColumn.Text = "Name";
            this.DocumentNameColumn.Width = 200;
            // 
            // SegmentsCountColumn
            // 
            this.SegmentsCountColumn.Text = "Seg. Count";
            this.SegmentsCountColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SegmentsCountColumn.Width = 80;
            // 
            // SourceLanguageColumn
            // 
            this.SourceLanguageColumn.Text = "Source Language";
            this.SourceLanguageColumn.Width = 120;
            // 
            // TargetLanguageColumn
            // 
            this.TargetLanguageColumn.Text = "Target Language";
            this.TargetLanguageColumn.Width = 120;
            // 
            // OpenUsingStudioActionButton
            // 
            this.OpenUsingStudioActionButton.Location = new System.Drawing.Point(537, 6);
            this.OpenUsingStudioActionButton.Name = "OpenUsingStudioActionButton";
            this.OpenUsingStudioActionButton.Size = new System.Drawing.Size(98, 23);
            this.OpenUsingStudioActionButton.TabIndex = 17;
            this.OpenUsingStudioActionButton.Text = "Open document";
            this.OpenUsingStudioActionButton.UseVisualStyleBackColor = true;
            this.OpenUsingStudioActionButton.Click += new System.EventHandler(this.OpenUsingStudioActionButton_Click);
            // 
            // SaveAllButton
            // 
            this.SaveAllButton.Location = new System.Drawing.Point(537, 35);
            this.SaveAllButton.Name = "SaveAllButton";
            this.SaveAllButton.Size = new System.Drawing.Size(98, 23);
            this.SaveAllButton.TabIndex = 27;
            this.SaveAllButton.Text = "Save all";
            this.SaveAllButton.UseVisualStyleBackColor = true;
            this.SaveAllButton.Click += new System.EventHandler(this.SaveAllButton_Click);
            // 
            // ReplaceAllButton
            // 
            this.ReplaceAllButton.Location = new System.Drawing.Point(831, 119);
            this.ReplaceAllButton.Name = "ReplaceAllButton";
            this.ReplaceAllButton.Size = new System.Drawing.Size(75, 23);
            this.ReplaceAllButton.TabIndex = 26;
            this.ReplaceAllButton.Text = "Replace all";
            this.ReplaceAllButton.UseVisualStyleBackColor = true;
            this.ReplaceAllButton.Click += new System.EventHandler(this.ReplaceAllButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(688, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Replace:";
            // 
            // ReplaceText
            // 
            this.ReplaceText.Location = new System.Drawing.Point(746, 80);
            this.ReplaceText.Name = "ReplaceText";
            this.ReplaceText.Size = new System.Drawing.Size(160, 20);
            this.ReplaceText.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(688, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Find:";
            // 
            // FindText
            // 
            this.FindText.Location = new System.Drawing.Point(746, 54);
            this.FindText.Name = "FindText";
            this.FindText.Size = new System.Drawing.Size(160, 20);
            this.FindText.TabIndex = 22;
            // 
            // FindReplaceActiveButton
            // 
            this.FindReplaceActiveButton.AutoSize = true;
            this.FindReplaceActiveButton.Location = new System.Drawing.Point(691, 30);
            this.FindReplaceActiveButton.Name = "FindReplaceActiveButton";
            this.FindReplaceActiveButton.Size = new System.Drawing.Size(190, 17);
            this.FindReplaceActiveButton.TabIndex = 21;
            this.FindReplaceActiveButton.Text = "Find && Replace in active document";
            this.FindReplaceActiveButton.UseVisualStyleBackColor = true;
            // 
            // FindReplaceAllButton
            // 
            this.FindReplaceAllButton.AutoSize = true;
            this.FindReplaceAllButton.Checked = true;
            this.FindReplaceAllButton.Location = new System.Drawing.Point(691, 7);
            this.FindReplaceAllButton.Name = "FindReplaceAllButton";
            this.FindReplaceAllButton.Size = new System.Drawing.Size(215, 17);
            this.FindReplaceAllButton.TabIndex = 20;
            this.FindReplaceAllButton.TabStop = true;
            this.FindReplaceAllButton.Text = "Find && Replace in all opened documents";
            this.FindReplaceAllButton.UseVisualStyleBackColor = true;
            // 
            // CloseAllDocumentsButton
            // 
            this.CloseAllDocumentsButton.Location = new System.Drawing.Point(537, 64);
            this.CloseAllDocumentsButton.Name = "CloseAllDocumentsButton";
            this.CloseAllDocumentsButton.Size = new System.Drawing.Size(98, 23);
            this.CloseAllDocumentsButton.TabIndex = 19;
            this.CloseAllDocumentsButton.Text = "Close all";
            this.CloseAllDocumentsButton.UseVisualStyleBackColor = true;
            this.CloseAllDocumentsButton.Click += new System.EventHandler(this.CloseAllDocumentsButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.EventsListView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(912, 174);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tracking Events";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // EventsListView
            // 
            this.EventsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EventIndexColumn,
            this.EventName,
            this.EventMetadataColumn});
            this.EventsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventsListView.FullRowSelect = true;
            this.EventsListView.GridLines = true;
            this.EventsListView.Location = new System.Drawing.Point(3, 3);
            this.EventsListView.MultiSelect = false;
            this.EventsListView.Name = "EventsListView";
            this.EventsListView.Size = new System.Drawing.Size(906, 168);
            this.EventsListView.TabIndex = 0;
            this.EventsListView.UseCompatibleStateImageBehavior = false;
            this.EventsListView.View = System.Windows.Forms.View.Details;
            // 
            // EventIndexColumn
            // 
            this.EventIndexColumn.Text = "Crt.";
            this.EventIndexColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // EventName
            // 
            this.EventName.Text = "EventName";
            this.EventName.Width = 200;
            // 
            // EventMetadataColumn
            // 
            this.EventMetadataColumn.Text = "Meta";
            this.EventMetadataColumn.Width = 300;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ReplaceSelectionButton);
            this.tabPage3.Controls.Add(this.ReplaceSelectionTextBox);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.CurrentSelectionTextBox);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(912, 174);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Selections";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ReplaceSelectionButton
            // 
            this.ReplaceSelectionButton.Location = new System.Drawing.Point(434, 90);
            this.ReplaceSelectionButton.Name = "ReplaceSelectionButton";
            this.ReplaceSelectionButton.Size = new System.Drawing.Size(99, 23);
            this.ReplaceSelectionButton.TabIndex = 4;
            this.ReplaceSelectionButton.Text = "Replace";
            this.ReplaceSelectionButton.UseVisualStyleBackColor = true;
            this.ReplaceSelectionButton.Click += new System.EventHandler(this.ReplaceSelectionButton_Click);
            // 
            // ReplaceSelectionTextBox
            // 
            this.ReplaceSelectionTextBox.Location = new System.Drawing.Point(434, 16);
            this.ReplaceSelectionTextBox.Multiline = true;
            this.ReplaceSelectionTextBox.Name = "ReplaceSelectionTextBox";
            this.ReplaceSelectionTextBox.Size = new System.Drawing.Size(374, 67);
            this.ReplaceSelectionTextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(431, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Replace selection with:";
            // 
            // CurrentSelectionTextBox
            // 
            this.CurrentSelectionTextBox.Location = new System.Drawing.Point(6, 16);
            this.CurrentSelectionTextBox.Name = "CurrentSelectionTextBox";
            this.CurrentSelectionTextBox.ReadOnly = true;
            this.CurrentSelectionTextBox.Size = new System.Drawing.Size(419, 96);
            this.CurrentSelectionTextBox.TabIndex = 1;
            this.CurrentSelectionTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Current selection text";
            // 
            // MyEditorViewPartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "MyEditorViewPartControl";
            this.Size = new System.Drawing.Size(920, 200);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView DocumentsList;
        private System.Windows.Forms.ColumnHeader DocumentNameColumn;
        private System.Windows.Forms.ColumnHeader SegmentsCountColumn;
        private System.Windows.Forms.ColumnHeader SourceLanguageColumn;
        private System.Windows.Forms.ColumnHeader TargetLanguageColumn;
        private System.Windows.Forms.Button OpenUsingStudioActionButton;
        private System.Windows.Forms.Button SaveAllButton;
        private System.Windows.Forms.Button ReplaceAllButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ReplaceText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FindText;
        private System.Windows.Forms.RadioButton FindReplaceActiveButton;
        private System.Windows.Forms.RadioButton FindReplaceAllButton;
        private System.Windows.Forms.Button CloseAllDocumentsButton;
        private System.Windows.Forms.ListView EventsListView;
        private System.Windows.Forms.ColumnHeader EventName;
        private System.Windows.Forms.ColumnHeader EventIndexColumn;
        private System.Windows.Forms.ColumnHeader EventMetadataColumn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox CurrentSelectionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ReplaceSelectionTextBox;
        private System.Windows.Forms.Button ReplaceSelectionButton;

    }
}
