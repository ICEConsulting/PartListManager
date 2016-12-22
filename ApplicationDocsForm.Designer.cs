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
            this.AppDocReplaceFileButton = new System.Windows.Forms.Button();
            this.ViewDocumentButton = new System.Windows.Forms.Button();
            this.AppDocCancelButton = new System.Windows.Forms.Button();
            this.AppDocDeleteButton = new System.Windows.Forms.Button();
            this.AppDocEditUpdateButton = new System.Windows.Forms.Button();
            this.AppDocAppCatTextBox = new System.Windows.Forms.TextBox();
            this.AppDocSmartStartTitleTextBox = new System.Windows.Forms.TextBox();
            this.AppDocDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.AppDocFilenameTextBox = new System.Windows.Forms.TextBox();
            this.AppDocIDTextBox = new System.Windows.Forms.TextBox();
            this.AppCatLabel = new System.Windows.Forms.Label();
            this.SmartStartLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AppDocEditPanelHeader = new System.Windows.Forms.Label();
            this.AddHeaderDocButton = new System.Windows.Forms.Button();
            this.AddBodyDocumentButton = new System.Windows.Forms.Button();
            this.AddFooterDocumentButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.AppDocEditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopDocumentsListView
            // 
            this.TopDocumentsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader7,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.TopDocumentsListView.FullRowSelect = true;
            this.TopDocumentsListView.HideSelection = false;
            this.TopDocumentsListView.Location = new System.Drawing.Point(72, 72);
            this.TopDocumentsListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TopDocumentsListView.MultiSelect = false;
            this.TopDocumentsListView.Name = "TopDocumentsListView";
            this.TopDocumentsListView.Size = new System.Drawing.Size(1056, 161);
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
            this.columnHeader1.Width = 240;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Document Description";
            this.columnHeader2.Width = 275;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Smart Start Title";
            this.columnHeader3.Width = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(302, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(598, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Document Header, Smart Start and Non-Smart Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(390, 331);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(424, 29);
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
            this.BodyDocumentsListView.Location = new System.Drawing.Point(72, 362);
            this.BodyDocumentsListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BodyDocumentsListView.MultiSelect = false;
            this.BodyDocumentsListView.Name = "BodyDocumentsListView";
            this.BodyDocumentsListView.Size = new System.Drawing.Size(1056, 657);
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
            this.columnHeader5.Width = 275;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Application Category";
            this.columnHeader6.Width = 110;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(428, 1136);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(348, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Terms and Conditions Footer";
            // 
            // FooterDocumentTextBox
            // 
            this.FooterDocumentTextBox.Location = new System.Drawing.Point(292, 1165);
            this.FooterDocumentTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FooterDocumentTextBox.Name = "FooterDocumentTextBox";
            this.FooterDocumentTextBox.Size = new System.Drawing.Size(613, 26);
            this.FooterDocumentTextBox.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importDocumentsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1200, 35);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // importDocumentsToolStripMenuItem
            // 
            this.importDocumentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.headerDocumentsToolStripMenuItem,
            this.bodyDocumentsToolStripMenuItem});
            this.importDocumentsToolStripMenuItem.Name = "importDocumentsToolStripMenuItem";
            this.importDocumentsToolStripMenuItem.Size = new System.Drawing.Size(175, 29);
            this.importDocumentsToolStripMenuItem.Text = "Import Documents";
            // 
            // headerDocumentsToolStripMenuItem
            // 
            this.headerDocumentsToolStripMenuItem.Name = "headerDocumentsToolStripMenuItem";
            this.headerDocumentsToolStripMenuItem.Size = new System.Drawing.Size(237, 30);
            this.headerDocumentsToolStripMenuItem.Text = "Header Documents";
            this.headerDocumentsToolStripMenuItem.Click += new System.EventHandler(this.headerDocumentsToolStripMenuItem_Click);
            // 
            // bodyDocumentsToolStripMenuItem
            // 
            this.bodyDocumentsToolStripMenuItem.Name = "bodyDocumentsToolStripMenuItem";
            this.bodyDocumentsToolStripMenuItem.Size = new System.Drawing.Size(237, 30);
            this.bodyDocumentsToolStripMenuItem.Text = "Body Documents";
            this.bodyDocumentsToolStripMenuItem.Click += new System.EventHandler(this.bodyDocumentsToolStripMenuItem_Click);
            // 
            // AppDocEditPanel
            // 
            this.AppDocEditPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppDocEditPanel.Controls.Add(this.AppDocReplaceFileButton);
            this.AppDocEditPanel.Controls.Add(this.ViewDocumentButton);
            this.AppDocEditPanel.Controls.Add(this.AppDocCancelButton);
            this.AppDocEditPanel.Controls.Add(this.AppDocDeleteButton);
            this.AppDocEditPanel.Controls.Add(this.AppDocEditUpdateButton);
            this.AppDocEditPanel.Controls.Add(this.AppDocAppCatTextBox);
            this.AppDocEditPanel.Controls.Add(this.AppDocSmartStartTitleTextBox);
            this.AppDocEditPanel.Controls.Add(this.AppDocDescriptionTextBox);
            this.AppDocEditPanel.Controls.Add(this.AppDocFilenameTextBox);
            this.AppDocEditPanel.Controls.Add(this.AppDocIDTextBox);
            this.AppDocEditPanel.Controls.Add(this.AppCatLabel);
            this.AppDocEditPanel.Controls.Add(this.SmartStartLabel);
            this.AppDocEditPanel.Controls.Add(this.label6);
            this.AppDocEditPanel.Controls.Add(this.label5);
            this.AppDocEditPanel.Controls.Add(this.label4);
            this.AppDocEditPanel.Controls.Add(this.AppDocEditPanelHeader);
            this.AppDocEditPanel.Location = new System.Drawing.Point(201, 306);
            this.AppDocEditPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AppDocEditPanel.Name = "AppDocEditPanel";
            this.AppDocEditPanel.Size = new System.Drawing.Size(797, 369);
            this.AppDocEditPanel.TabIndex = 7;
            this.AppDocEditPanel.Visible = false;
            // 
            // AppDocReplaceFileButton
            // 
            this.AppDocReplaceFileButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AppDocReplaceFileButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppDocReplaceFileButton.Location = new System.Drawing.Point(488, 288);
            this.AppDocReplaceFileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.ViewDocumentButton.Location = new System.Drawing.Point(356, 288);
            this.ViewDocumentButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.AppDocCancelButton.Location = new System.Drawing.Point(646, 288);
            this.AppDocCancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.AppDocDeleteButton.Location = new System.Drawing.Point(224, 288);
            this.AppDocDeleteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.AppDocEditUpdateButton.Location = new System.Drawing.Point(46, 288);
            this.AppDocEditUpdateButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AppDocEditUpdateButton.Name = "AppDocEditUpdateButton";
            this.AppDocEditUpdateButton.Size = new System.Drawing.Size(168, 34);
            this.AppDocEditUpdateButton.TabIndex = 11;
            this.AppDocEditUpdateButton.Text = "Save Changes";
            this.AppDocEditUpdateButton.UseVisualStyleBackColor = false;
            this.AppDocEditUpdateButton.Click += new System.EventHandler(this.AppDocEditUpdateButton_Click);
            // 
            // AppDocAppCatTextBox
            // 
            this.AppDocAppCatTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppDocAppCatTextBox.Location = new System.Drawing.Point(288, 190);
            this.AppDocAppCatTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AppDocAppCatTextBox.Name = "AppDocAppCatTextBox";
            this.AppDocAppCatTextBox.Size = new System.Drawing.Size(390, 30);
            this.AppDocAppCatTextBox.TabIndex = 10;
            // 
            // AppDocSmartStartTitleTextBox
            // 
            this.AppDocSmartStartTitleTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppDocSmartStartTitleTextBox.Location = new System.Drawing.Point(288, 190);
            this.AppDocSmartStartTitleTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AppDocSmartStartTitleTextBox.Name = "AppDocSmartStartTitleTextBox";
            this.AppDocSmartStartTitleTextBox.Size = new System.Drawing.Size(390, 30);
            this.AppDocSmartStartTitleTextBox.TabIndex = 9;
            // 
            // AppDocDescriptionTextBox
            // 
            this.AppDocDescriptionTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppDocDescriptionTextBox.Location = new System.Drawing.Point(288, 154);
            this.AppDocDescriptionTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AppDocDescriptionTextBox.Name = "AppDocDescriptionTextBox";
            this.AppDocDescriptionTextBox.Size = new System.Drawing.Size(390, 30);
            this.AppDocDescriptionTextBox.TabIndex = 8;
            // 
            // AppDocFilenameTextBox
            // 
            this.AppDocFilenameTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppDocFilenameTextBox.Location = new System.Drawing.Point(288, 118);
            this.AppDocFilenameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AppDocFilenameTextBox.Name = "AppDocFilenameTextBox";
            this.AppDocFilenameTextBox.Size = new System.Drawing.Size(390, 30);
            this.AppDocFilenameTextBox.TabIndex = 7;
            // 
            // AppDocIDTextBox
            // 
            this.AppDocIDTextBox.Enabled = false;
            this.AppDocIDTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppDocIDTextBox.Location = new System.Drawing.Point(288, 82);
            this.AppDocIDTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AppDocIDTextBox.Name = "AppDocIDTextBox";
            this.AppDocIDTextBox.Size = new System.Drawing.Size(390, 30);
            this.AppDocIDTextBox.TabIndex = 6;
            // 
            // AppCatLabel
            // 
            this.AppCatLabel.AutoSize = true;
            this.AppCatLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppCatLabel.Location = new System.Drawing.Point(74, 198);
            this.AppCatLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AppCatLabel.Name = "AppCatLabel";
            this.AppCatLabel.Size = new System.Drawing.Size(198, 23);
            this.AppCatLabel.TabIndex = 5;
            this.AppCatLabel.Text = "Application Category:";
            // 
            // SmartStartLabel
            // 
            this.SmartStartLabel.AutoSize = true;
            this.SmartStartLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmartStartLabel.Location = new System.Drawing.Point(111, 193);
            this.SmartStartLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SmartStartLabel.Name = "SmartStartLabel";
            this.SmartStartLabel.Size = new System.Drawing.Size(160, 23);
            this.SmartStartLabel.TabIndex = 4;
            this.SmartStartLabel.Text = "Smart Start Title:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(156, 157);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(174, 121);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Filename:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(195, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 23);
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
            this.AppDocEditPanelHeader.Size = new System.Drawing.Size(79, 27);
            this.AppDocEditPanelHeader.TabIndex = 0;
            this.AppDocEditPanelHeader.Text = "label4";
            // 
            // AddHeaderDocButton
            // 
            this.AddHeaderDocButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AddHeaderDocButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddHeaderDocButton.Location = new System.Drawing.Point(908, 33);
            this.AddHeaderDocButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddHeaderDocButton.Name = "AddHeaderDocButton";
            this.AddHeaderDocButton.Size = new System.Drawing.Size(123, 34);
            this.AddHeaderDocButton.TabIndex = 14;
            this.AddHeaderDocButton.Text = "Add";
            this.AddHeaderDocButton.UseVisualStyleBackColor = false;
            this.AddHeaderDocButton.Click += new System.EventHandler(this.AddHeaderDocButton_Click);
            // 
            // AddBodyDocumentButton
            // 
            this.AddBodyDocumentButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AddBodyDocumentButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBodyDocumentButton.Location = new System.Drawing.Point(908, 322);
            this.AddBodyDocumentButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddBodyDocumentButton.Name = "AddBodyDocumentButton";
            this.AddBodyDocumentButton.Size = new System.Drawing.Size(123, 34);
            this.AddBodyDocumentButton.TabIndex = 15;
            this.AddBodyDocumentButton.Text = "Add";
            this.AddBodyDocumentButton.UseVisualStyleBackColor = false;
            this.AddBodyDocumentButton.Click += new System.EventHandler(this.AddBodyDocumentButton_Click);
            // 
            // AddFooterDocumentButton
            // 
            this.AddFooterDocumentButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AddFooterDocumentButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFooterDocumentButton.Location = new System.Drawing.Point(784, 1127);
            this.AddFooterDocumentButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddFooterDocumentButton.Name = "AddFooterDocumentButton";
            this.AddFooterDocumentButton.Size = new System.Drawing.Size(123, 34);
            this.AddFooterDocumentButton.TabIndex = 16;
            this.AddFooterDocumentButton.Text = "Add";
            this.AddFooterDocumentButton.UseVisualStyleBackColor = false;
            this.AddFooterDocumentButton.Click += new System.EventHandler(this.AddFooterDocumentButton_Click);
            // 
            // ApplicationDocsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(1200, 1329);
            this.Controls.Add(this.AddFooterDocumentButton);
            this.Controls.Add(this.AppDocEditPanel);
            this.Controls.Add(this.AddBodyDocumentButton);
            this.Controls.Add(this.AddHeaderDocButton);
            this.Controls.Add(this.FooterDocumentTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BodyDocumentsListView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TopDocumentsListView);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ApplicationDocsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Document Configurations";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.AppDocEditPanel.ResumeLayout(false);
            this.AppDocEditPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView TopDocumentsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
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
        private System.Windows.Forms.TextBox AppDocAppCatTextBox;
        private System.Windows.Forms.TextBox AppDocSmartStartTitleTextBox;
        private System.Windows.Forms.TextBox AppDocDescriptionTextBox;
        private System.Windows.Forms.TextBox AppDocFilenameTextBox;
        private System.Windows.Forms.TextBox AppDocIDTextBox;
        private System.Windows.Forms.Label AppCatLabel;
        private System.Windows.Forms.Label SmartStartLabel;
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
    }
}