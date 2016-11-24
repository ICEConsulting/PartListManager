namespace TecanPartListManager
{
    partial class RequirePartForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequirePartForm));
            this.tecanPartsListDataSet = new TecanPartListManager.TecanPartsListDataSet();
            this.partsListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.partsListTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.PartsListTableAdapter();
            this.tableAdapterManager = new TecanPartListManager.TecanPartsListDataSetTableAdapters.TableAdapterManager();
            this.partsListDataGridView = new System.Windows.Forms.DataGridView();
            this.SAPIdataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptiondataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.RequiredListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OptionalListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.SAPIDLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SAPIDLabel2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PartNumberSearchTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionSearchTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tecanPartsListDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tecanPartsListDataSet
            // 
            this.tecanPartsListDataSet.DataSetName = "TecanPartsListDataSet";
            this.tecanPartsListDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // partsListBindingSource
            // 
            this.partsListBindingSource.DataMember = "PartsList";
            this.partsListBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // partsListTableAdapter
            // 
            this.partsListTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CategoryTableAdapter = null;
            this.tableAdapterManager.DBMembershipTableAdapter = null;
            this.tableAdapterManager.InstrumentTableAdapter = null;
            this.tableAdapterManager.PartImagesTableAdapter = null;
            this.tableAdapterManager.PartsListTableAdapter = this.partsListTableAdapter;
            this.tableAdapterManager.RequiredPartsTableAdapter = null;
            this.tableAdapterManager.SalesTypeTableAdapter = null;
            this.tableAdapterManager.SSPCategoryTableAdapter = null;
            this.tableAdapterManager.SubCategoryTableAdapter = null;
            this.tableAdapterManager.SuppumentalDocsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TecanPartListManager.TecanPartsListDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // partsListDataGridView
            // 
            this.partsListDataGridView.AutoGenerateColumns = false;
            this.partsListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SAPIdataGridViewTextBoxColumn,
            this.DescriptiondataGridViewTextBoxColumn});
            this.partsListDataGridView.DataSource = this.partsListBindingSource;
            this.partsListDataGridView.Location = new System.Drawing.Point(12, 61);
            this.partsListDataGridView.Name = "partsListDataGridView";
            this.partsListDataGridView.Size = new System.Drawing.Size(648, 337);
            this.partsListDataGridView.TabIndex = 1;
            this.partsListDataGridView.TabStop = false;
            this.partsListDataGridView.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.partsListDataGridView_HeaderDoubleClick);
            this.partsListDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.partsListDataGridView_MouseDown);
            // 
            // SAPIdataGridViewTextBoxColumn
            // 
            this.SAPIdataGridViewTextBoxColumn.DataPropertyName = "SAPId";
            this.SAPIdataGridViewTextBoxColumn.HeaderText = "SAPId";
            this.SAPIdataGridViewTextBoxColumn.Name = "SAPIdataGridViewTextBoxColumn";
            // 
            // DescriptiondataGridViewTextBoxColumn
            // 
            this.DescriptiondataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.DescriptiondataGridViewTextBoxColumn.HeaderText = "Description";
            this.DescriptiondataGridViewTextBoxColumn.Name = "DescriptiondataGridViewTextBoxColumn";
            this.DescriptiondataGridViewTextBoxColumn.ReadOnly = true;
            this.DescriptiondataGridViewTextBoxColumn.Width = 488;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "All Parts";
            // 
            // RequiredListView
            // 
            this.RequiredListView.AllowDrop = true;
            this.RequiredListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.RequiredListView.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequiredListView.FullRowSelect = true;
            this.RequiredListView.Location = new System.Drawing.Point(12, 584);
            this.RequiredListView.MultiSelect = false;
            this.RequiredListView.Name = "RequiredListView";
            this.RequiredListView.Size = new System.Drawing.Size(310, 182);
            this.RequiredListView.TabIndex = 3;
            this.RequiredListView.TabStop = false;
            this.RequiredListView.UseCompatibleStateImageBehavior = false;
            this.RequiredListView.View = System.Windows.Forms.View.Details;
            this.RequiredListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.RequiredListView_DragDrop);
            this.RequiredListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.RequiredListView_DragEnter);
            this.RequiredListView.DoubleClick += new System.EventHandler(this.RequiredListView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "SAPID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 300;
            // 
            // OptionalListView
            // 
            this.OptionalListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.OptionalListView.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionalListView.FullRowSelect = true;
            this.OptionalListView.Location = new System.Drawing.Point(350, 584);
            this.OptionalListView.MultiSelect = false;
            this.OptionalListView.Name = "OptionalListView";
            this.OptionalListView.Size = new System.Drawing.Size(310, 182);
            this.OptionalListView.TabIndex = 4;
            this.OptionalListView.TabStop = false;
            this.OptionalListView.UseCompatibleStateImageBehavior = false;
            this.OptionalListView.View = System.Windows.Forms.View.Details;
            this.OptionalListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.OptionalListView_DragDrop);
            this.OptionalListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.OptionalListView_DragEnter);
            this.OptionalListView.DoubleClick += new System.EventHandler(this.OptionalListView_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "SAPID";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            this.columnHeader4.Width = 300;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 565);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Required Parts for Part# ";
            // 
            // SAPIDLabel
            // 
            this.SAPIDLabel.AutoSize = true;
            this.SAPIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAPIDLabel.Location = new System.Drawing.Point(205, 565);
            this.SAPIDLabel.Name = "SAPIDLabel";
            this.SAPIDLabel.Size = new System.Drawing.Size(82, 16);
            this.SAPIDLabel.TabIndex = 6;
            this.SAPIDLabel.Text = "SAPIDLabel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(353, 565);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Optional Parts to Part# ";
            // 
            // SAPIDLabel2
            // 
            this.SAPIDLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAPIDLabel2.Location = new System.Drawing.Point(526, 565);
            this.SAPIDLabel2.Name = "SAPIDLabel2";
            this.SAPIDLabel2.Size = new System.Drawing.Size(90, 16);
            this.SAPIDLabel2.TabIndex = 8;
            this.SAPIDLabel2.Text = "SAPIDLabel2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Part#:";
            // 
            // PartNumberSearchTextBox
            // 
            this.PartNumberSearchTextBox.Location = new System.Drawing.Point(56, 39);
            this.PartNumberSearchTextBox.Name = "PartNumberSearchTextBox";
            this.PartNumberSearchTextBox.Size = new System.Drawing.Size(120, 20);
            this.PartNumberSearchTextBox.TabIndex = 10;
            this.PartNumberSearchTextBox.TabStop = false;
            this.PartNumberSearchTextBox.TextChanged += new System.EventHandler(this.PartNumberSearchTextBox_TextChanged);
            // 
            // DescriptionSearchTextBox
            // 
            this.DescriptionSearchTextBox.Location = new System.Drawing.Point(277, 40);
            this.DescriptionSearchTextBox.Name = "DescriptionSearchTextBox";
            this.DescriptionSearchTextBox.Size = new System.Drawing.Size(247, 20);
            this.DescriptionSearchTextBox.TabIndex = 11;
            this.DescriptionSearchTextBox.TabStop = false;
            this.DescriptionSearchTextBox.TextChanged += new System.EventHandler(this.DescriptionSearchTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Description:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(196, 415);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 131);
            this.textBox1.TabIndex = 13;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // RequirePartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(684, 794);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DescriptionSearchTextBox);
            this.Controls.Add(this.PartNumberSearchTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SAPIDLabel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SAPIDLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OptionalListView);
            this.Controls.Add(this.RequiredListView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.partsListDataGridView);
            this.Name = "RequirePartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Edit Require Parts";
            this.Load += new System.EventHandler(this.RequirePartForm_Load);
            this.Disposed += new System.EventHandler(this.RequirePartForm_Close);
            ((System.ComponentModel.ISupportInitialize)(this.tecanPartsListDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TecanPartsListDataSet tecanPartsListDataSet;
        private System.Windows.Forms.BindingSource partsListBindingSource;
        private TecanPartsListDataSetTableAdapters.PartsListTableAdapter partsListTableAdapter;
        private TecanPartsListDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView partsListDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView RequiredListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView OptionalListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SAPIDLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SAPIDLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAPIdataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptiondataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PartNumberSearchTextBox;
        private System.Windows.Forms.TextBox DescriptionSearchTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
    }
}