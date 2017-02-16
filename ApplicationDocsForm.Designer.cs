namespace TecanPartListManager
{
    partial class ApplicationDocsForm
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
            this.TopDocumentsListView = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BodyDocumentsListView = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.FooterDocumentTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.importDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headerDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bodyDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AppDocEditPanel = new System.Windows.Forms.Panel();
            this.IsSmartStartCheckBox = new System.Windows.Forms.CheckBox();
            this.AppDocCatComboBox = new System.Windows.Forms.ComboBox();
            this.AppDocReplaceFileButton = new System.Windows.Forms.Button();
            this.ViewDocumentButton = new System.Windows.Forms.Button();
            this.AppDocCancelButton = new System.Windows.Forms.Button();
            this.AppDocDeleteButton = new System.Windows.Forms.Button();
            this.AppDocEditUpdateButton = new System.Windows.Forms.Button();
            this.AppDocDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.AppDocFilenameTextBox = new System.Windows.Forms.TextBox();
            this.AppDocIDTextBox = new System.Windows.Forms.TextBox();
            this.AppCatLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AppDocEditPanelHeader = new System.Windows.Forms.Label();
            this.AddBodyDocumentButton = new System.Windows.Forms.Button();
            this.AddHeaderDocButton = new System.Windows.Forms.Button();
            this.AddFooterDocumentButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.AddCatButton = new System.Windows.Forms.Button();
            this.CatPanel = new System.Windows.Forms.Panel();
            this.CancelCatButton = new System.Windows.Forms.Button();
            this.DeleteCatButton = new System.Windows.Forms.Button();
            this.RenameCatButton = new System.Windows.Forms.Button();
            this.AddNewCatButton = new System.Windows.Forms.Button();
            this.AddEditCategoryTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CategoryListView = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CatID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CatName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CurrentCatID = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.AppDocEditPanel.SuspendLayout();
            this.CatPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopDocumentsListView
            // 
            this.TopDocumentsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader7,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader11,
            this.columnHeader3});
            this.TopDocumentsListView.FullRowSelect = true;
            this.TopDocumentsListView.HideSelection = false;
            this.TopDocumentsListView.Location = new System.Drawing.Point(49, 109);
            this.TopDocumentsListView.Margin = new System.Windows.Forms.Padding(4);
            this.TopDocumentsListView.MultiSelect = false;
            this.TopDocumentsListView.Name = "TopDocumentsListView";
            this.TopDocumentsListView.Size = new System.Drawing.Size(862, 161);
            this.TopDocumentsListView.TabIndex = 0;
            this.TopDocumentsListView.UseCompatibleStateImageBehavior = false;
            this.TopDocumentsListView.View = System.Windows.Forms.View.Details;
            this.TopDocumentsListView.DoubleClick += new System.EventHandler(this.TopDocumentsListView_Click);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = " ";
            this.columnHeader8.Width = 1;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Doc#";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 50;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Filename";
            this.columnHeader1.Width = 225;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Document Description";
            this.columnHeader2.Width = 350;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Category";
            this.columnHeader11.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Is SS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(279, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Document Header, Smart Start and Non-Smart Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 437);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Document Body, After Product Lists";
            // 
            // BodyDocumentsListView
            // 
            this.BodyDocumentsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.BodyDocumentsListView.FullRowSelect = true;
            this.BodyDocumentsListView.HideSelection = false;
            this.BodyDocumentsListView.Location = new System.Drawing.Point(49, 468);
            this.BodyDocumentsListView.Margin = new System.Windows.Forms.Padding(4);
            this.BodyDocumentsListView.MultiSelect = false;
            this.BodyDocumentsListView.Name = "BodyDocumentsListView";
            this.BodyDocumentsListView.Size = new System.Drawing.Size(862, 455);
            this.BodyDocumentsListView.TabIndex = 3;
            this.BodyDocumentsListView.UseCompatibleStateImageBehavior = false;
            this.BodyDocumentsListView.View = System.Windows.Forms.View.Details;
            this.BodyDocumentsListView.DoubleClick += new System.EventHandler(this.BodyDocumentsListView_Click);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = " ";
            this.columnHeader9.Width = 1;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Doc#";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Filename";
            this.columnHeader4.Width = 240;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Document Description";
            this.columnHeader5.Width = 400;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Category";
            this.columnHeader6.Width = 150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(309, 953);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Terms and Conditions Footer";
            // 
            // FooterDocumentTextBox
            // 
            this.FooterDocumentTextBox.Location = new System.Drawing.Point(173, 982);
            this.FooterDocumentTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.FooterDocumentTextBox.Name = "FooterDocumentTextBox";
            this.FooterDocumentTextBox.Size = new System.Drawing.Size(613, 20);
            this.FooterDocumentTextBox.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importDocumentsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(958, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // importDocumentsToolStripMenuItem
            // 
            this.importDocumentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.headerDocumentsToolStripMenuItem,
            this.bodyDocumentsToolStripMenuItem});
            this.importDocumentsToolStripMenuItem.Name = "importDocumentsToolStripMenuItem";
            this.importDocumentsToolStripMenuItem.Size = new System.Drawing.Size(119, 19);
            this.importDocumentsToolStripMenuItem.Text = "Import Documents";
            this.importDocumentsToolStripMenuItem.Visible = false;
            // 
            // headerDocumentsToolStripMenuItem
            // 
            this.headerDocumentsToolStripMenuItem.Name = "headerDocumentsToolStripMenuItem";
            this.headerDocumentsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.headerDocumentsToolStripMenuItem.Text = "Header Documents";
            this.headerDocumentsToolStripMenuItem.Click += new System.EventHandler(this.headerDocumentsToolStripMenuItem_Click);
            // 
            // bodyDocumentsToolStripMenuItem
            // 
            this.bodyDocumentsToolStripMenuItem.Name = "bodyDocumentsToolStripMenuItem";
            this.bodyDocumentsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.bodyDocumentsToolStripMenuItem.Text = "Body Documents";
            this.bodyDocumentsToolStripMenuItem.Click += new System.EventHandler(this.bodyDocumentsToolStripMenuItem_Click);
            // 
            // AppDocEditPanel
            // 
            this.AppDocEditPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppDocEditPanel.Controls.Add(this.IsSmartStartCheckBox);
            this.AppDocEditPanel.Controls.Add(this.AppDocCatComboBox);
            this.AppDocEditPanel.Controls.Add(this.AppDocReplaceFileButton);
            this.AppDocEditPanel.Controls.Add(this.ViewDocumentButton);
            this.AppDocEditPanel.Controls.Add(this.AppDocCancelButton);
            this.AppDocEditPanel.Controls.Add(this.AppDocDeleteButton);
            this.AppDocEditPanel.Controls.Add(this.AppDocEditUpdateButton);
            this.AppDocEditPanel.Controls.Add(this.AppDocDescriptionTextBox);
            this.AppDocEditPanel.Controls.Add(this.AppDocFilenameTextBox);
            this.AppDocEditPanel.Controls.Add(this.AppDocIDTextBox);
            this.AppDocEditPanel.Controls.Add(this.AppCatLabel);
            this.AppDocEditPanel.Controls.Add(this.label6);
            this.AppDocEditPanel.Controls.Add(this.label5);
            this.AppDocEditPanel.Controls.Add(this.label4);
            this.AppDocEditPanel.Controls.Add(this.AppDocEditPanelHeader);
            this.AppDocEditPanel.Location = new System.Drawing.Point(91, 548);
            this.AppDocEditPanel.Margin = new System.Windows.Forms.Padding(4);
            this.AppDocEditPanel.Name = "AppDocEditPanel";
            this.AppDocEditPanel.Size = new System.Drawing.Size(797, 324);
            this.AppDocEditPanel.TabIndex = 7;
            this.AppDocEditPanel.Visible = false;
            // 
            // IsSmartStartCheckBox
            // 
            this.IsSmartStartCheckBox.AutoSize = true;
            this.IsSmartStartCheckBox.Location = new System.Drawing.Point(239, 206);
            this.IsSmartStartCheckBox.Name = "IsSmartStartCheckBox";
            this.IsSmartStartCheckBox.Size = new System.Drawing.Size(118, 18);
            this.IsSmartStartCheckBox.TabIndex = 17;
            this.IsSmartStartCheckBox.Text = "Smart Start Header";
            this.IsSmartStartCheckBox.UseVisualStyleBackColor = true;
            this.IsSmartStartCheckBox.Visible = false;
            // 
            // AppDocCatComboBox
            // 
            this.AppDocCatComboBox.FormattingEnabled = true;
            this.AppDocCatComboBox.Location = new System.Drawing.Point(239, 177);
            this.AppDocCatComboBox.Name = "AppDocCatComboBox";
            this.AppDocCatComboBox.Size = new System.Drawing.Size(390, 22);
            this.AppDocCatComboBox.TabIndex = 16;
            // 
            // AppDocReplaceFileButton
            // 
            this.AppDocReplaceFileButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AppDocReplaceFileButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppDocReplaceFileButton.Location = new System.Drawing.Point(484, 252);
            this.AppDocReplaceFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.AppDocReplaceFileButton.Name = "AppDocReplaceFileButton";
            this.AppDocReplaceFileButton.Size = new System.Drawing.Size(150, 34);
            this.AppDocReplaceFileButton.TabIndex = 15;
            this.AppDocReplaceFileButton.Text = "Replace File";
            this.AppDocReplaceFileButton.UseVisualStyleBackColor = false;
            this.AppDocReplaceFileButton.Click += new System.EventHandler(this.AppDocReplaceFileButton_Click);
            // 
            // ViewDocumentButton
            // 
            this.ViewDocumentButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ViewDocumentButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewDocumentButton.Location = new System.Drawing.Point(352, 252);
            this.ViewDocumentButton.Margin = new System.Windows.Forms.Padding(4);
            this.ViewDocumentButton.Name = "ViewDocumentButton";
            this.ViewDocumentButton.Size = new System.Drawing.Size(123, 34);
            this.ViewDocumentButton.TabIndex = 14;
            this.ViewDocumentButton.Text = "View";
            this.ViewDocumentButton.UseVisualStyleBackColor = false;
            this.ViewDocumentButton.Click += new System.EventHandler(this.ViewDocumentButton_Click);
            // 
            // AppDocCancelButton
            // 
            this.AppDocCancelButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AppDocCancelButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppDocCancelButton.Location = new System.Drawing.Point(642, 252);
            this.AppDocCancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.AppDocCancelButton.Name = "AppDocCancelButton";
            this.AppDocCancelButton.Size = new System.Drawing.Size(123, 34);
            this.AppDocCancelButton.TabIndex = 13;
            this.AppDocCancelButton.Text = "Cancel";
            this.AppDocCancelButton.UseVisualStyleBackColor = false;
            this.AppDocCancelButton.Click += new System.EventHandler(this.AppDocCancelButton_Click);
            // 
            // AppDocDeleteButton
            // 
            this.AppDocDeleteButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AppDocDeleteButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppDocDeleteButton.Location = new System.Drawing.Point(220, 252);
            this.AppDocDeleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.AppDocDeleteButton.Name = "AppDocDeleteButton";
            this.AppDocDeleteButton.Size = new System.Drawing.Size(123, 34);
            this.AppDocDeleteButton.TabIndex = 12;
            this.AppDocDeleteButton.Text = "Delete";
            this.AppDocDeleteButton.UseVisualStyleBackColor = false;
            this.AppDocDeleteButton.Click += new System.EventHandler(this.AppDocDeleteButton_Click);
            // 
            // AppDocEditUpdateButton
            // 
            this.AppDocEditUpdateButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AppDocEditUpdateButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppDocEditUpdateButton.Location = new System.Drawing.Point(42, 252);
            this.AppDocEditUpdateButton.Margin = new System.Windows.Forms.Padding(4);
            this.AppDocEditUpdateButton.Name = "AppDocEditUpdateButton";
            this.AppDocEditUpdateButton.Size = new System.Drawing.Size(168, 34);
            this.AppDocEditUpdateButton.TabIndex = 11;
            this.AppDocEditUpdateButton.Text = "Save Changes";
            this.AppDocEditUpdateButton.UseVisualStyleBackColor = false;
            this.AppDocEditUpdateButton.Click += new System.EventHandler(this.AppDocEditUpdateButton_Click);
            // 
            // AppDocDescriptionTextBox
            // 
            this.AppDocDescriptionTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppDocDescriptionTextBox.Location = new System.Drawing.Point(239, 142);
            this.AppDocDescriptionTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AppDocDescriptionTextBox.Name = "AppDocDescriptionTextBox";
            this.AppDocDescriptionTextBox.Size = new System.Drawing.Size(390, 22);
            this.AppDocDescriptionTextBox.TabIndex = 8;
            // 
            // AppDocFilenameTextBox
            // 
            this.AppDocFilenameTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppDocFilenameTextBox.Location = new System.Drawing.Point(239, 103);
            this.AppDocFilenameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AppDocFilenameTextBox.Name = "AppDocFilenameTextBox";
            this.AppDocFilenameTextBox.Size = new System.Drawing.Size(390, 22);
            this.AppDocFilenameTextBox.TabIndex = 7;
            // 
            // AppDocIDTextBox
            // 
            this.AppDocIDTextBox.Enabled = false;
            this.AppDocIDTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppDocIDTextBox.Location = new System.Drawing.Point(239, 67);
            this.AppDocIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AppDocIDTextBox.Name = "AppDocIDTextBox";
            this.AppDocIDTextBox.Size = new System.Drawing.Size(390, 22);
            this.AppDocIDTextBox.TabIndex = 6;
            // 
            // AppCatLabel
            // 
            this.AppCatLabel.AutoSize = true;
            this.AppCatLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppCatLabel.Location = new System.Drawing.Point(99, 178);
            this.AppCatLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AppCatLabel.Name = "AppCatLabel";
            this.AppCatLabel.Size = new System.Drawing.Size(132, 16);
            this.AppCatLabel.TabIndex = 5;
            this.AppCatLabel.Text = "Application Category:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(154, 145);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(166, 106);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Filename:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(180, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Doc ID:";
            // 
            // AppDocEditPanelHeader
            // 
            this.AppDocEditPanelHeader.AutoSize = true;
            this.AppDocEditPanelHeader.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppDocEditPanelHeader.Location = new System.Drawing.Point(27, 18);
            this.AppDocEditPanelHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AppDocEditPanelHeader.Name = "AppDocEditPanelHeader";
            this.AppDocEditPanelHeader.Size = new System.Drawing.Size(50, 18);
            this.AppDocEditPanelHeader.TabIndex = 0;
            this.AppDocEditPanelHeader.Text = "label4";
            // 
            // AddBodyDocumentButton
            // 
            this.AddBodyDocumentButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AddBodyDocumentButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBodyDocumentButton.Location = new System.Drawing.Point(643, 430);
            this.AddBodyDocumentButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddBodyDocumentButton.Name = "AddBodyDocumentButton";
            this.AddBodyDocumentButton.Size = new System.Drawing.Size(123, 34);
            this.AddBodyDocumentButton.TabIndex = 15;
            this.AddBodyDocumentButton.Text = "Add";
            this.AddBodyDocumentButton.UseVisualStyleBackColor = false;
            this.AddBodyDocumentButton.Click += new System.EventHandler(this.AddBodyDocumentButton_Click);
            // 
            // AddHeaderDocButton
            // 
            this.AddHeaderDocButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AddHeaderDocButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddHeaderDocButton.Location = new System.Drawing.Point(685, 71);
            this.AddHeaderDocButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddHeaderDocButton.Name = "AddHeaderDocButton";
            this.AddHeaderDocButton.Size = new System.Drawing.Size(123, 34);
            this.AddHeaderDocButton.TabIndex = 14;
            this.AddHeaderDocButton.Text = "Add";
            this.AddHeaderDocButton.UseVisualStyleBackColor = false;
            this.AddHeaderDocButton.Click += new System.EventHandler(this.AddHeaderDocButton_Click);
            // 
            // AddFooterDocumentButton
            // 
            this.AddFooterDocumentButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AddFooterDocumentButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFooterDocumentButton.Location = new System.Drawing.Point(548, 940);
            this.AddFooterDocumentButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddFooterDocumentButton.Name = "AddFooterDocumentButton";
            this.AddFooterDocumentButton.Size = new System.Drawing.Size(123, 34);
            this.AddFooterDocumentButton.TabIndex = 16;
            this.AddFooterDocumentButton.Text = "Add";
            this.AddFooterDocumentButton.UseVisualStyleBackColor = false;
            this.AddFooterDocumentButton.Click += new System.EventHandler(this.AddFooterDocumentButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(48, 304);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 19);
            this.label7.TabIndex = 18;
            this.label7.Text = "Document Categories";
            // 
            // AddCatButton
            // 
            this.AddCatButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AddCatButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCatButton.Location = new System.Drawing.Point(385, 326);
            this.AddCatButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddCatButton.Name = "AddCatButton";
            this.AddCatButton.Size = new System.Drawing.Size(123, 34);
            this.AddCatButton.TabIndex = 19;
            this.AddCatButton.Text = "Add";
            this.AddCatButton.UseVisualStyleBackColor = false;
            this.AddCatButton.Click += new System.EventHandler(this.AddCatButton_Click);
            // 
            // CatPanel
            // 
            this.CatPanel.Controls.Add(this.CurrentCatID);
            this.CatPanel.Controls.Add(this.CancelCatButton);
            this.CatPanel.Controls.Add(this.DeleteCatButton);
            this.CatPanel.Controls.Add(this.RenameCatButton);
            this.CatPanel.Controls.Add(this.AddNewCatButton);
            this.CatPanel.Controls.Add(this.AddEditCategoryTextBox);
            this.CatPanel.Controls.Add(this.label8);
            this.CatPanel.Location = new System.Drawing.Point(261, 136);
            this.CatPanel.Name = "CatPanel";
            this.CatPanel.Size = new System.Drawing.Size(338, 160);
            this.CatPanel.TabIndex = 20;
            this.CatPanel.Visible = false;
            // 
            // CancelCatButton
            // 
            this.CancelCatButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CancelCatButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelCatButton.Location = new System.Drawing.Point(130, 114);
            this.CancelCatButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancelCatButton.Name = "CancelCatButton";
            this.CancelCatButton.Size = new System.Drawing.Size(73, 34);
            this.CancelCatButton.TabIndex = 23;
            this.CancelCatButton.Text = "Cancel";
            this.CancelCatButton.UseVisualStyleBackColor = false;
            this.CancelCatButton.Click += new System.EventHandler(this.CancelCatButton_Click);
            // 
            // DeleteCatButton
            // 
            this.DeleteCatButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DeleteCatButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteCatButton.Location = new System.Drawing.Point(174, 72);
            this.DeleteCatButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteCatButton.Name = "DeleteCatButton";
            this.DeleteCatButton.Size = new System.Drawing.Size(73, 34);
            this.DeleteCatButton.TabIndex = 22;
            this.DeleteCatButton.Text = "Delete";
            this.DeleteCatButton.UseVisualStyleBackColor = false;
            this.DeleteCatButton.Click += new System.EventHandler(this.DeleteCatButton_Click);
            // 
            // RenameCatButton
            // 
            this.RenameCatButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.RenameCatButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RenameCatButton.Location = new System.Drawing.Point(82, 72);
            this.RenameCatButton.Margin = new System.Windows.Forms.Padding(4);
            this.RenameCatButton.Name = "RenameCatButton";
            this.RenameCatButton.Size = new System.Drawing.Size(73, 34);
            this.RenameCatButton.TabIndex = 21;
            this.RenameCatButton.Text = "Rename";
            this.RenameCatButton.UseVisualStyleBackColor = false;
            this.RenameCatButton.Click += new System.EventHandler(this.RenameCatButton_Click);
            // 
            // AddNewCatButton
            // 
            this.AddNewCatButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AddNewCatButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewCatButton.Location = new System.Drawing.Point(144, 72);
            this.AddNewCatButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddNewCatButton.Name = "AddNewCatButton";
            this.AddNewCatButton.Size = new System.Drawing.Size(49, 34);
            this.AddNewCatButton.TabIndex = 20;
            this.AddNewCatButton.Text = "Add";
            this.AddNewCatButton.UseVisualStyleBackColor = false;
            this.AddNewCatButton.Click += new System.EventHandler(this.AddNewCatButton_Click);
            // 
            // AddEditCategoryTextBox
            // 
            this.AddEditCategoryTextBox.Location = new System.Drawing.Point(47, 35);
            this.AddEditCategoryTextBox.Name = "AddEditCategoryTextBox";
            this.AddEditCategoryTextBox.Size = new System.Drawing.Size(240, 20);
            this.AddEditCategoryTextBox.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(49, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Categories";
            // 
            // CategoryListView
            // 
            this.CategoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.CatID,
            this.CatName});
            this.CategoryListView.FullRowSelect = true;
            this.CategoryListView.Location = new System.Drawing.Point(52, 326);
            this.CategoryListView.MultiSelect = false;
            this.CategoryListView.Name = "CategoryListView";
            this.CategoryListView.Size = new System.Drawing.Size(326, 81);
            this.CategoryListView.TabIndex = 21;
            this.CategoryListView.UseCompatibleStateImageBehavior = false;
            this.CategoryListView.View = System.Windows.Forms.View.Details;
            this.CategoryListView.DoubleClick += new System.EventHandler(this.CategoryListView_DoubleClick);
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "";
            this.columnHeader12.Width = 1;
            // 
            // CatID
            // 
            this.CatID.Text = "CatID";
            this.CatID.Width = 50;
            // 
            // CatName
            // 
            this.CatName.Text = "Category Name";
            this.CatName.Width = 250;
            // 
            // CurrentCatID
            // 
            this.CurrentCatID.AutoSize = true;
            this.CurrentCatID.Location = new System.Drawing.Point(22, 125);
            this.CurrentCatID.Name = "CurrentCatID";
            this.CurrentCatID.Size = new System.Drawing.Size(35, 14);
            this.CurrentCatID.TabIndex = 24;
            this.CurrentCatID.Text = "label9";
            this.CurrentCatID.Visible = false;
            // 
            // ApplicationDocsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(958, 1044);
            this.Controls.Add(this.CategoryListView);
            this.Controls.Add(this.CatPanel);
            this.Controls.Add(this.AddCatButton);
            this.Controls.Add(this.AppDocEditPanel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AddBodyDocumentButton);
            this.Controls.Add(this.AddFooterDocumentButton);
            this.Controls.Add(this.AddHeaderDocButton);
            this.Controls.Add(this.FooterDocumentTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TopDocumentsListView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BodyDocumentsListView);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ApplicationDocsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Document Configurations";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.AppDocEditPanel.ResumeLayout(false);
            this.AppDocEditPanel.PerformLayout();
            this.CatPanel.ResumeLayout(false);
            this.CatPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView TopDocumentsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView BodyDocumentsListView;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FooterDocumentTextBox;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem importDocumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem headerDocumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bodyDocumentsToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Panel AppDocEditPanel;
        private System.Windows.Forms.TextBox AppDocDescriptionTextBox;
        private System.Windows.Forms.TextBox AppDocFilenameTextBox;
        private System.Windows.Forms.TextBox AppDocIDTextBox;
        private System.Windows.Forms.Label AppCatLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label AppDocEditPanelHeader;
        private System.Windows.Forms.Button AppDocCancelButton;
        private System.Windows.Forms.Button AppDocDeleteButton;
        private System.Windows.Forms.Button AppDocEditUpdateButton;
        private System.Windows.Forms.Button AddHeaderDocButton;
        private System.Windows.Forms.Button AddBodyDocumentButton;
        private System.Windows.Forms.Button AddFooterDocumentButton;
        private System.Windows.Forms.Button ViewDocumentButton;
        private System.Windows.Forms.Button AppDocReplaceFileButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button AddCatButton;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ComboBox AppDocCatComboBox;
        private System.Windows.Forms.CheckBox IsSmartStartCheckBox;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel CatPanel;
        private System.Windows.Forms.Button DeleteCatButton;
        private System.Windows.Forms.Button RenameCatButton;
        private System.Windows.Forms.Button AddNewCatButton;
        private System.Windows.Forms.TextBox AddEditCategoryTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button CancelCatButton;
        private System.Windows.Forms.ListView CategoryListView;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader CatID;
        private System.Windows.Forms.ColumnHeader CatName;
        private System.Windows.Forms.Label CurrentCatID;
    }
}