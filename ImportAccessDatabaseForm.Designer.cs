namespace TecanPartListManager
{
    partial class ImportAccessDatabaseForm
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
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tecanPartsListDataSet = new TecanPartListManager.TecanPartsListDataSet();
            this.categoryTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.CategoryTableAdapter();
            this.categoryListBox = new System.Windows.Forms.ListBox();
            this.CatLabel = new System.Windows.Forms.Label();
            this.instrumentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.instrumentTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.InstrumentTableAdapter();
            this.instrumentListBox = new System.Windows.Forms.ListBox();
            this.instrumentLabel = new System.Windows.Forms.Label();
            this.subCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subCategoryTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.SubCategoryTableAdapter();
            this.subCategoryListBox = new System.Windows.Forms.ListBox();
            this.SubCategoryLabel = new System.Windows.Forms.Label();
            this.partsListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.partsListTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.PartsListTableAdapter();
            this.tableAdapterManager = new TecanPartListManager.TecanPartsListDataSetTableAdapters.TableAdapterManager();
            this.salesTypeTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.SalesTypeTableAdapter();
            this.sspCategoryTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.SSPCategoryTableAdapter();
            this.salesTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sspCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.statusPanelLabel = new System.Windows.Forms.Label();
            this.statusProgressBar = new System.Windows.Forms.ProgressBar();
            this.sspCategoryListBox = new System.Windows.Forms.ListBox();
            this.SSPCategoryLabel = new System.Windows.Forms.Label();
            this.dBMembershipbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBMembershipTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.DBMembershipTableAdapter();
            this.dBMembershipListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.salesTypeListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tecanPartsListDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sspCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBMembershipbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataMember = "Category";
            this.categoryBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // tecanPartsListDataSet
            // 
            this.tecanPartsListDataSet.DataSetName = "TecanPartsListDataSet";
            this.tecanPartsListDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoryTableAdapter
            // 
            this.categoryTableAdapter.ClearBeforeFill = true;
            // 
            // categoryListBox
            // 
            this.categoryListBox.DataSource = this.categoryBindingSource;
            this.categoryListBox.DisplayMember = "CategoryName";
            this.categoryListBox.FormattingEnabled = true;
            this.categoryListBox.ItemHeight = 20;
            this.categoryListBox.Location = new System.Drawing.Point(192, 68);
            this.categoryListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.categoryListBox.Name = "categoryListBox";
            this.categoryListBox.Size = new System.Drawing.Size(159, 144);
            this.categoryListBox.TabIndex = 0;
            // 
            // CatLabel
            // 
            this.CatLabel.AutoSize = true;
            this.CatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CatLabel.Location = new System.Drawing.Point(192, 38);
            this.CatLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CatLabel.Name = "CatLabel";
            this.CatLabel.Size = new System.Drawing.Size(106, 20);
            this.CatLabel.TabIndex = 1;
            this.CatLabel.Text = "Categories:";
            // 
            // instrumentBindingSource
            // 
            this.instrumentBindingSource.DataMember = "Instrument";
            this.instrumentBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // instrumentTableAdapter
            // 
            this.instrumentTableAdapter.ClearBeforeFill = true;
            // 
            // instrumentListBox
            // 
            this.instrumentListBox.DataSource = this.instrumentBindingSource;
            this.instrumentListBox.DisplayMember = "InstrumentName";
            this.instrumentListBox.FormattingEnabled = true;
            this.instrumentListBox.ItemHeight = 20;
            this.instrumentListBox.Location = new System.Drawing.Point(24, 68);
            this.instrumentListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.instrumentListBox.Name = "instrumentListBox";
            this.instrumentListBox.Size = new System.Drawing.Size(159, 144);
            this.instrumentListBox.TabIndex = 2;
            // 
            // instrumentLabel
            // 
            this.instrumentLabel.AutoSize = true;
            this.instrumentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instrumentLabel.Location = new System.Drawing.Point(24, 38);
            this.instrumentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.instrumentLabel.Name = "instrumentLabel";
            this.instrumentLabel.Size = new System.Drawing.Size(114, 20);
            this.instrumentLabel.TabIndex = 3;
            this.instrumentLabel.Text = "Instruments:";
            // 
            // subCategoryBindingSource
            // 
            this.subCategoryBindingSource.DataMember = "SubCategory";
            this.subCategoryBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // subCategoryTableAdapter
            // 
            this.subCategoryTableAdapter.ClearBeforeFill = true;
            // 
            // subCategoryListBox
            // 
            this.subCategoryListBox.DataSource = this.subCategoryBindingSource;
            this.subCategoryListBox.DisplayMember = "SubCategoryName";
            this.subCategoryListBox.FormattingEnabled = true;
            this.subCategoryListBox.ItemHeight = 20;
            this.subCategoryListBox.Location = new System.Drawing.Point(361, 68);
            this.subCategoryListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.subCategoryListBox.Name = "subCategoryListBox";
            this.subCategoryListBox.Size = new System.Drawing.Size(159, 144);
            this.subCategoryListBox.TabIndex = 4;
            // 
            // SubCategoryLabel
            // 
            this.SubCategoryLabel.AutoSize = true;
            this.SubCategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubCategoryLabel.Location = new System.Drawing.Point(361, 38);
            this.SubCategoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SubCategoryLabel.Name = "SubCategoryLabel";
            this.SubCategoryLabel.Size = new System.Drawing.Size(132, 20);
            this.SubCategoryLabel.TabIndex = 5;
            this.SubCategoryLabel.Text = "SubCategories";
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
            this.tableAdapterManager.CategoryTableAdapter = this.categoryTableAdapter;
            this.tableAdapterManager.DBMembershipTableAdapter = null;
            this.tableAdapterManager.InstrumentTableAdapter = this.instrumentTableAdapter;
            this.tableAdapterManager.PartImagesTableAdapter = null;
            this.tableAdapterManager.PartsListTableAdapter = this.partsListTableAdapter;
            this.tableAdapterManager.RequiredPartsTableAdapter = null;
            this.tableAdapterManager.SalesTypeTableAdapter = this.salesTypeTableAdapter;
            this.tableAdapterManager.SSPCategoryTableAdapter = this.sspCategoryTableAdapter;
            this.tableAdapterManager.SubCategoryTableAdapter = this.subCategoryTableAdapter;
            this.tableAdapterManager.SuppumentalDocsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TecanPartListManager.TecanPartsListDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // salesTypeTableAdapter
            // 
            this.salesTypeTableAdapter.ClearBeforeFill = true;
            // 
            // sspCategoryTableAdapter
            // 
            this.sspCategoryTableAdapter.ClearBeforeFill = true;
            // 
            // salesTypeBindingSource
            // 
            this.salesTypeBindingSource.DataMember = "SalesType";
            this.salesTypeBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // sspCategoryBindingSource
            // 
            this.sspCategoryBindingSource.DataMember = "SSPCategory";
            this.sspCategoryBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 289);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Importing ....";
            // 
            // statusPanelLabel
            // 
            this.statusPanelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusPanelLabel.Location = new System.Drawing.Point(397, 289);
            this.statusPanelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusPanelLabel.Name = "statusPanelLabel";
            this.statusPanelLabel.Size = new System.Drawing.Size(413, 25);
            this.statusPanelLabel.TabIndex = 1;
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Location = new System.Drawing.Point(290, 318);
            this.statusProgressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(414, 35);
            this.statusProgressBar.TabIndex = 2;
            // 
            // sspCategoryListBox
            // 
            this.sspCategoryListBox.DataSource = this.sspCategoryBindingSource;
            this.sspCategoryListBox.DisplayMember = "SSPCategoryName";
            this.sspCategoryListBox.FormattingEnabled = true;
            this.sspCategoryListBox.ItemHeight = 20;
            this.sspCategoryListBox.Location = new System.Drawing.Point(531, 68);
            this.sspCategoryListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sspCategoryListBox.Name = "sspCategoryListBox";
            this.sspCategoryListBox.Size = new System.Drawing.Size(159, 144);
            this.sspCategoryListBox.TabIndex = 7;
            // 
            // SSPCategoryLabel
            // 
            this.SSPCategoryLabel.AutoSize = true;
            this.SSPCategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSPCategoryLabel.Location = new System.Drawing.Point(531, 38);
            this.SSPCategoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SSPCategoryLabel.Name = "SSPCategoryLabel";
            this.SSPCategoryLabel.Size = new System.Drawing.Size(142, 20);
            this.SSPCategoryLabel.TabIndex = 8;
            this.SSPCategoryLabel.Text = "SSP Categories";
            // 
            // dBMembershipbindingSource
            // 
            this.dBMembershipbindingSource.DataMember = "DBMembership";
            this.dBMembershipbindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // dBMembershipTableAdapter
            // 
            this.dBMembershipTableAdapter.ClearBeforeFill = true;
            // 
            // dBMembershipListBox
            // 
            this.dBMembershipListBox.DataSource = this.dBMembershipbindingSource;
            this.dBMembershipListBox.DisplayMember = "DBName";
            this.dBMembershipListBox.FormattingEnabled = true;
            this.dBMembershipListBox.ItemHeight = 20;
            this.dBMembershipListBox.Location = new System.Drawing.Point(699, 68);
            this.dBMembershipListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dBMembershipListBox.Name = "dBMembershipListBox";
            this.dBMembershipListBox.Size = new System.Drawing.Size(159, 144);
            this.dBMembershipListBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(699, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "DB Membership";
            // 
            // salesTypeListBox
            // 
            this.salesTypeListBox.DataSource = this.salesTypeBindingSource;
            this.salesTypeListBox.DisplayMember = "SalesTypeName";
            this.salesTypeListBox.FormattingEnabled = true;
            this.salesTypeListBox.ItemHeight = 20;
            this.salesTypeListBox.Location = new System.Drawing.Point(867, 68);
            this.salesTypeListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.salesTypeListBox.Name = "salesTypeListBox";
            this.salesTypeListBox.Size = new System.Drawing.Size(159, 144);
            this.salesTypeListBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(862, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Sales Type";
            // 
            // ImportAccessDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(1051, 466);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.salesTypeListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dBMembershipListBox);
            this.Controls.Add(this.SSPCategoryLabel);
            this.Controls.Add(this.sspCategoryListBox);
            this.Controls.Add(this.statusProgressBar);
            this.Controls.Add(this.statusPanelLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SubCategoryLabel);
            this.Controls.Add(this.subCategoryListBox);
            this.Controls.Add(this.instrumentLabel);
            this.Controls.Add(this.instrumentListBox);
            this.Controls.Add(this.CatLabel);
            this.Controls.Add(this.categoryListBox);
            this.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ImportAccessDatabaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Access Database";
            this.Load += new System.EventHandler(this.ImportAccessDatabaseForm_Load);
            this.Shown += new System.EventHandler(this.ImportAccessDatabaseForm_Shown);
            this.Disposed += new System.EventHandler(this.ImportAccessDatabaseForm_Close);
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tecanPartsListDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sspCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBMembershipbindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource categoryBindingSource;
        private TecanPartsListDataSet tecanPartsListDataSet;
        private TecanPartsListDataSetTableAdapters.CategoryTableAdapter categoryTableAdapter;
        private System.Windows.Forms.ListBox categoryListBox;
        private System.Windows.Forms.Label CatLabel;
        private System.Windows.Forms.BindingSource instrumentBindingSource;
        private TecanPartsListDataSetTableAdapters.InstrumentTableAdapter instrumentTableAdapter;
        private System.Windows.Forms.ListBox instrumentListBox;
        private System.Windows.Forms.Label instrumentLabel;
        private System.Windows.Forms.BindingSource subCategoryBindingSource;
        private TecanPartsListDataSetTableAdapters.SubCategoryTableAdapter subCategoryTableAdapter;
        private System.Windows.Forms.ListBox subCategoryListBox;
        private System.Windows.Forms.Label SubCategoryLabel;
        private System.Windows.Forms.BindingSource partsListBindingSource;
        private TecanPartsListDataSetTableAdapters.PartsListTableAdapter partsListTableAdapter;
        private TecanPartsListDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.BindingSource salesTypeBindingSource;
        private TecanPartsListDataSetTableAdapters.SalesTypeTableAdapter salesTypeTableAdapter;
        private System.Windows.Forms.BindingSource sspCategoryBindingSource;
        private TecanPartsListDataSetTableAdapters.SSPCategoryTableAdapter sspCategoryTableAdapter;
        private System.Windows.Forms.ProgressBar statusProgressBar;
        private System.Windows.Forms.Label statusPanelLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox sspCategoryListBox;
        private System.Windows.Forms.Label SSPCategoryLabel;
        private System.Windows.Forms.BindingSource dBMembershipbindingSource;
        private TecanPartsListDataSetTableAdapters.DBMembershipTableAdapter dBMembershipTableAdapter;
        private System.Windows.Forms.ListBox dBMembershipListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox salesTypeListBox;
        private System.Windows.Forms.Label label3;
    }
}