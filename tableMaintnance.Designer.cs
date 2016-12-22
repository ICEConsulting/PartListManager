namespace TecanPartListManager
{
    partial class tableMaintnance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tableMaintnance));
            this.tecanPartsListDataSet = new TecanPartListManager.TecanPartsListDataSet();
            this.instrumentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.instrumentTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.InstrumentTableAdapter();
            this.tableAdapterManager = new TecanPartListManager.TecanPartsListDataSetTableAdapters.TableAdapterManager();
            this.categoryTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.CategoryTableAdapter();
            this.dBMembershipTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.DBMembershipTableAdapter();
            this.partsListTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.PartsListTableAdapter();
            this.salesTypeTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.SalesTypeTableAdapter();
            this.sSPCategoryTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.SSPCategoryTableAdapter();
            this.subCategoryTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.SubCategoryTableAdapter();
            this.suppumentalDocsTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.SuppumentalDocsTableAdapter();
            this.instrumentListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.subCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subCategoryListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sSPCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sSPCategoryListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dBMembershipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBMembershipListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.salesTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salesTypeListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.suppumentalDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.suppumentalDocsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.partsListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.partsListListBox = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.allSuppDocsDataGridView = new System.Windows.Forms.DataGridView();
            this.DocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.addInstrumentButton = new System.Windows.Forms.Button();
            this.assoSuppDocButton = new System.Windows.Forms.Button();
            this.addCategoryButton = new System.Windows.Forms.Button();
            this.addSubCategoryButton = new System.Windows.Forms.Button();
            this.addSSPCategoryButton = new System.Windows.Forms.Button();
            this.addDBMembershipButton = new System.Windows.Forms.Button();
            this.addSalesTypeButton = new System.Windows.Forms.Button();
            this.addSuppDocButton = new System.Windows.Forms.Button();
            this.viewSuppDocButton = new System.Windows.Forms.Button();
            this.compatibilityListBox = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.addCompatibilityButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tecanPartsListDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSPCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBMembershipBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppumentalDocsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppumentalDocsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allSuppDocsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tecanPartsListDataSet
            // 
            this.tecanPartsListDataSet.DataSetName = "TecanPartsListDataSet";
            this.tecanPartsListDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CategoryTableAdapter = this.categoryTableAdapter;
            this.tableAdapterManager.DBMembershipTableAdapter = this.dBMembershipTableAdapter;
            this.tableAdapterManager.InstrumentTableAdapter = this.instrumentTableAdapter;
            this.tableAdapterManager.PartImagesTableAdapter = null;
            this.tableAdapterManager.PartsListTableAdapter = this.partsListTableAdapter;
            this.tableAdapterManager.RequiredPartsTableAdapter = null;
            this.tableAdapterManager.SalesTypeTableAdapter = this.salesTypeTableAdapter;
            this.tableAdapterManager.SSPCategoryTableAdapter = this.sSPCategoryTableAdapter;
            this.tableAdapterManager.SubCategoryTableAdapter = this.subCategoryTableAdapter;
            this.tableAdapterManager.SuppumentalDocsTableAdapter = this.suppumentalDocsTableAdapter;
            this.tableAdapterManager.UpdateOrder = TecanPartListManager.TecanPartsListDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // categoryTableAdapter
            // 
            this.categoryTableAdapter.ClearBeforeFill = true;
            // 
            // dBMembershipTableAdapter
            // 
            this.dBMembershipTableAdapter.ClearBeforeFill = true;
            // 
            // partsListTableAdapter
            // 
            this.partsListTableAdapter.ClearBeforeFill = true;
            // 
            // salesTypeTableAdapter
            // 
            this.salesTypeTableAdapter.ClearBeforeFill = true;
            // 
            // sSPCategoryTableAdapter
            // 
            this.sSPCategoryTableAdapter.ClearBeforeFill = true;
            // 
            // subCategoryTableAdapter
            // 
            this.subCategoryTableAdapter.ClearBeforeFill = true;
            // 
            // suppumentalDocsTableAdapter
            // 
            this.suppumentalDocsTableAdapter.ClearBeforeFill = true;
            // 
            // instrumentListBox
            // 
            this.instrumentListBox.DataSource = this.instrumentBindingSource;
            this.instrumentListBox.DisplayMember = "InstrumentName";
            this.instrumentListBox.FormattingEnabled = true;
            this.instrumentListBox.ItemHeight = 18;
            this.instrumentListBox.Location = new System.Drawing.Point(34, 46);
            this.instrumentListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.instrumentListBox.Name = "instrumentListBox";
            this.instrumentListBox.Size = new System.Drawing.Size(150, 292);
            this.instrumentListBox.TabIndex = 1;
            this.instrumentListBox.TabStop = false;
            this.instrumentListBox.ValueMember = "InstrumentID";
            this.instrumentListBox.DoubleClick += new System.EventHandler(this.instrumentListBox_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Instruments";
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataMember = "Category";
            this.categoryBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // categoryListBox
            // 
            this.categoryListBox.DataSource = this.categoryBindingSource;
            this.categoryListBox.DisplayMember = "CategoryName";
            this.categoryListBox.FormattingEnabled = true;
            this.categoryListBox.ItemHeight = 18;
            this.categoryListBox.Location = new System.Drawing.Point(230, 46);
            this.categoryListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.categoryListBox.Name = "categoryListBox";
            this.categoryListBox.Size = new System.Drawing.Size(186, 292);
            this.categoryListBox.TabIndex = 3;
            this.categoryListBox.TabStop = false;
            this.categoryListBox.ValueMember = "CategoryID";
            this.categoryListBox.DoubleClick += new System.EventHandler(this.categoryListBox_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(250, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Categories";
            // 
            // subCategoryBindingSource
            // 
            this.subCategoryBindingSource.DataMember = "SubCategory";
            this.subCategoryBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // subCategoryListBox
            // 
            this.subCategoryListBox.DataSource = this.subCategoryBindingSource;
            this.subCategoryListBox.DisplayMember = "SubCategoryName";
            this.subCategoryListBox.FormattingEnabled = true;
            this.subCategoryListBox.ItemHeight = 18;
            this.subCategoryListBox.Location = new System.Drawing.Point(464, 46);
            this.subCategoryListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.subCategoryListBox.Name = "subCategoryListBox";
            this.subCategoryListBox.Size = new System.Drawing.Size(193, 292);
            this.subCategoryListBox.TabIndex = 5;
            this.subCategoryListBox.TabStop = false;
            this.subCategoryListBox.ValueMember = "SubCategoryID";
            this.subCategoryListBox.DoubleClick += new System.EventHandler(this.subCategoryListBox_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(460, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sub-Categories";
            // 
            // sSPCategoryBindingSource
            // 
            this.sSPCategoryBindingSource.DataMember = "SSPCategory";
            this.sSPCategoryBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // sSPCategoryListBox
            // 
            this.sSPCategoryListBox.DataSource = this.sSPCategoryBindingSource;
            this.sSPCategoryListBox.DisplayMember = "SSPCategoryName";
            this.sSPCategoryListBox.FormattingEnabled = true;
            this.sSPCategoryListBox.ItemHeight = 18;
            this.sSPCategoryListBox.Location = new System.Drawing.Point(702, 46);
            this.sSPCategoryListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sSPCategoryListBox.Name = "sSPCategoryListBox";
            this.sSPCategoryListBox.Size = new System.Drawing.Size(198, 292);
            this.sSPCategoryListBox.TabIndex = 6;
            this.sSPCategoryListBox.TabStop = false;
            this.sSPCategoryListBox.ValueMember = "SSPCategoryId";
            this.sSPCategoryListBox.DoubleClick += new System.EventHandler(this.sSPCategoryListBox_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(699, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "SSP-Categories";
            // 
            // dBMembershipBindingSource
            // 
            this.dBMembershipBindingSource.DataMember = "DBMembership";
            this.dBMembershipBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // dBMembershipListBox
            // 
            this.dBMembershipListBox.DataSource = this.dBMembershipBindingSource;
            this.dBMembershipListBox.DisplayMember = "DBName";
            this.dBMembershipListBox.FormattingEnabled = true;
            this.dBMembershipListBox.ItemHeight = 18;
            this.dBMembershipListBox.Location = new System.Drawing.Point(952, 46);
            this.dBMembershipListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dBMembershipListBox.Name = "dBMembershipListBox";
            this.dBMembershipListBox.Size = new System.Drawing.Size(196, 112);
            this.dBMembershipListBox.TabIndex = 8;
            this.dBMembershipListBox.TabStop = false;
            this.dBMembershipListBox.ValueMember = "DBID";
            this.dBMembershipListBox.DoubleClick += new System.EventHandler(this.dBMembershipListBox_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(950, 13);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "DB Membership";
            // 
            // salesTypeBindingSource
            // 
            this.salesTypeBindingSource.DataMember = "SalesType";
            this.salesTypeBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // salesTypeListBox
            // 
            this.salesTypeListBox.DataSource = this.salesTypeBindingSource;
            this.salesTypeListBox.DisplayMember = "SalesTypeName";
            this.salesTypeListBox.FormattingEnabled = true;
            this.salesTypeListBox.ItemHeight = 18;
            this.salesTypeListBox.Location = new System.Drawing.Point(952, 244);
            this.salesTypeListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.salesTypeListBox.Name = "salesTypeListBox";
            this.salesTypeListBox.Size = new System.Drawing.Size(138, 94);
            this.salesTypeListBox.TabIndex = 10;
            this.salesTypeListBox.TabStop = false;
            this.salesTypeListBox.ValueMember = "SalesTypeID";
            this.salesTypeListBox.DoubleClick += new System.EventHandler(this.salesTypeListBox_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(950, 211);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "Sales Type";
            // 
            // suppumentalDocsBindingSource
            // 
            this.suppumentalDocsBindingSource.DataMember = "SuppumentalDocs";
            this.suppumentalDocsBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(231, 418);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(446, 29);
            this.label7.TabIndex = 13;
            this.label7.Text = "Associated Supplemental Documents";
            // 
            // suppumentalDocsDataGridView
            // 
            this.suppumentalDocsDataGridView.AutoGenerateColumns = false;
            this.suppumentalDocsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suppumentalDocsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.suppumentalDocsDataGridView.DataSource = this.suppumentalDocsBindingSource;
            this.suppumentalDocsDataGridView.Location = new System.Drawing.Point(34, 450);
            this.suppumentalDocsDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.suppumentalDocsDataGridView.MultiSelect = false;
            this.suppumentalDocsDataGridView.Name = "suppumentalDocsDataGridView";
            this.suppumentalDocsDataGridView.Size = new System.Drawing.Size(849, 370);
            this.suppumentalDocsDataGridView.TabIndex = 13;
            this.suppumentalDocsDataGridView.TabStop = false;
            this.suppumentalDocsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suppumentalDocsDataGridView_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SAPId";
            this.dataGridViewTextBoxColumn2.HeaderText = "SAPId";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FileName";
            this.dataGridViewTextBoxColumn3.HeaderText = "FileName";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 420;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(290, 866);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(348, 29);
            this.label8.TabIndex = 14;
            this.label8.Text = "All Supplemental Documents";
            // 
            // partsListBindingSource
            // 
            this.partsListBindingSource.DataMember = "PartsList";
            this.partsListBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // partsListListBox
            // 
            this.partsListListBox.DataSource = this.partsListBindingSource;
            this.partsListListBox.DisplayMember = "SAPId";
            this.partsListListBox.FormattingEnabled = true;
            this.partsListListBox.ItemHeight = 18;
            this.partsListListBox.Location = new System.Drawing.Point(950, 450);
            this.partsListListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.partsListListBox.Name = "partsListListBox";
            this.partsListListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.partsListListBox.Size = new System.Drawing.Size(196, 796);
            this.partsListListBox.TabIndex = 16;
            this.partsListListBox.TabStop = false;
            this.partsListListBox.ValueMember = "SAPId";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(951, 418);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(185, 29);
            this.label9.TabIndex = 17;
            this.label9.Text = "SAP ID / Part #";
            // 
            // allSuppDocsDataGridView
            // 
            this.allSuppDocsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allSuppDocsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocID,
            this.FileName});
            this.allSuppDocsDataGridView.Location = new System.Drawing.Point(34, 897);
            this.allSuppDocsDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.allSuppDocsDataGridView.Name = "allSuppDocsDataGridView";
            this.allSuppDocsDataGridView.Size = new System.Drawing.Size(849, 407);
            this.allSuppDocsDataGridView.TabIndex = 18;
            this.allSuppDocsDataGridView.TabStop = false;
            this.allSuppDocsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.allSuppDocsDataGridView_CellDoubleClick);
            // 
            // DocID
            // 
            this.DocID.HeaderText = "DocID";
            this.DocID.Name = "DocID";
            // 
            // FileName
            // 
            this.FileName.HeaderText = "Filename";
            this.FileName.Name = "FileName";
            this.FileName.Width = 420;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(1464, 46);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(372, 293);
            this.textBox1.TabIndex = 19;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1536, 13);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(221, 29);
            this.label10.TabIndex = 20;
            this.label10.Text = "Table Instructions";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1293, 418);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(438, 29);
            this.label11.TabIndex = 21;
            this.label11.Text = "Supplemental Document Instructions";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(1203, 461);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(633, 839);
            this.textBox2.TabIndex = 22;
            this.textBox2.TabStop = false;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // addInstrumentButton
            // 
            this.addInstrumentButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addInstrumentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addInstrumentButton.Location = new System.Drawing.Point(76, 347);
            this.addInstrumentButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addInstrumentButton.Name = "addInstrumentButton";
            this.addInstrumentButton.Size = new System.Drawing.Size(68, 36);
            this.addInstrumentButton.TabIndex = 23;
            this.addInstrumentButton.TabStop = false;
            this.addInstrumentButton.Text = "Add";
            this.addInstrumentButton.UseVisualStyleBackColor = false;
            this.addInstrumentButton.Click += new System.EventHandler(this.addInstrumentButton_Click);
            // 
            // assoSuppDocButton
            // 
            this.assoSuppDocButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.assoSuppDocButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assoSuppDocButton.Location = new System.Drawing.Point(974, 1258);
            this.assoSuppDocButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.assoSuppDocButton.Name = "assoSuppDocButton";
            this.assoSuppDocButton.Size = new System.Drawing.Size(150, 46);
            this.assoSuppDocButton.TabIndex = 30;
            this.assoSuppDocButton.TabStop = false;
            this.assoSuppDocButton.Text = "Associate";
            this.assoSuppDocButton.UseVisualStyleBackColor = false;
            this.assoSuppDocButton.Click += new System.EventHandler(this.assoSuppDocButton_Click);
            // 
            // addCategoryButton
            // 
            this.addCategoryButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addCategoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCategoryButton.Location = new System.Drawing.Point(290, 347);
            this.addCategoryButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addCategoryButton.Name = "addCategoryButton";
            this.addCategoryButton.Size = new System.Drawing.Size(68, 36);
            this.addCategoryButton.TabIndex = 31;
            this.addCategoryButton.TabStop = false;
            this.addCategoryButton.Text = "Add";
            this.addCategoryButton.UseVisualStyleBackColor = false;
            this.addCategoryButton.Click += new System.EventHandler(this.addCategoryButton_Click);
            // 
            // addSubCategoryButton
            // 
            this.addSubCategoryButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addSubCategoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSubCategoryButton.Location = new System.Drawing.Point(528, 347);
            this.addSubCategoryButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addSubCategoryButton.Name = "addSubCategoryButton";
            this.addSubCategoryButton.Size = new System.Drawing.Size(68, 36);
            this.addSubCategoryButton.TabIndex = 32;
            this.addSubCategoryButton.TabStop = false;
            this.addSubCategoryButton.Text = "Add";
            this.addSubCategoryButton.UseVisualStyleBackColor = false;
            this.addSubCategoryButton.Click += new System.EventHandler(this.addSubCategoryButton_Click);
            // 
            // addSSPCategoryButton
            // 
            this.addSSPCategoryButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addSSPCategoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSSPCategoryButton.Location = new System.Drawing.Point(768, 347);
            this.addSSPCategoryButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addSSPCategoryButton.Name = "addSSPCategoryButton";
            this.addSSPCategoryButton.Size = new System.Drawing.Size(68, 36);
            this.addSSPCategoryButton.TabIndex = 33;
            this.addSSPCategoryButton.TabStop = false;
            this.addSSPCategoryButton.Text = "Add";
            this.addSSPCategoryButton.UseVisualStyleBackColor = false;
            this.addSSPCategoryButton.Click += new System.EventHandler(this.addSSPCategoryButton_Click);
            // 
            // addDBMembershipButton
            // 
            this.addDBMembershipButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addDBMembershipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addDBMembershipButton.Location = new System.Drawing.Point(1018, 167);
            this.addDBMembershipButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addDBMembershipButton.Name = "addDBMembershipButton";
            this.addDBMembershipButton.Size = new System.Drawing.Size(68, 36);
            this.addDBMembershipButton.TabIndex = 34;
            this.addDBMembershipButton.TabStop = false;
            this.addDBMembershipButton.Text = "Add";
            this.addDBMembershipButton.UseVisualStyleBackColor = false;
            this.addDBMembershipButton.Click += new System.EventHandler(this.addDBMembershipButton_Click);
            // 
            // addSalesTypeButton
            // 
            this.addSalesTypeButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addSalesTypeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSalesTypeButton.Location = new System.Drawing.Point(988, 347);
            this.addSalesTypeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addSalesTypeButton.Name = "addSalesTypeButton";
            this.addSalesTypeButton.Size = new System.Drawing.Size(68, 36);
            this.addSalesTypeButton.TabIndex = 35;
            this.addSalesTypeButton.TabStop = false;
            this.addSalesTypeButton.Text = "Add";
            this.addSalesTypeButton.UseVisualStyleBackColor = false;
            this.addSalesTypeButton.Click += new System.EventHandler(this.addSalesTypeButton_Click);
            // 
            // addSuppDocButton
            // 
            this.addSuppDocButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addSuppDocButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSuppDocButton.Location = new System.Drawing.Point(652, 857);
            this.addSuppDocButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addSuppDocButton.Name = "addSuppDocButton";
            this.addSuppDocButton.Size = new System.Drawing.Size(68, 36);
            this.addSuppDocButton.TabIndex = 36;
            this.addSuppDocButton.TabStop = false;
            this.addSuppDocButton.Text = "Add";
            this.addSuppDocButton.UseVisualStyleBackColor = false;
            this.addSuppDocButton.Click += new System.EventHandler(this.addSuppDocButton_Click);
            // 
            // viewSuppDocButton
            // 
            this.viewSuppDocButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.viewSuppDocButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewSuppDocButton.Location = new System.Drawing.Point(729, 857);
            this.viewSuppDocButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.viewSuppDocButton.Name = "viewSuppDocButton";
            this.viewSuppDocButton.Size = new System.Drawing.Size(88, 36);
            this.viewSuppDocButton.TabIndex = 37;
            this.viewSuppDocButton.TabStop = false;
            this.viewSuppDocButton.Text = "View";
            this.viewSuppDocButton.UseVisualStyleBackColor = false;
            this.viewSuppDocButton.Click += new System.EventHandler(this.viewSuppDocButton_Click);
            // 
            // compatibilityListBox
            // 
            this.compatibilityListBox.FormattingEnabled = true;
            this.compatibilityListBox.ItemHeight = 18;
            this.compatibilityListBox.Location = new System.Drawing.Point(1203, 46);
            this.compatibilityListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.compatibilityListBox.Name = "compatibilityListBox";
            this.compatibilityListBox.Size = new System.Drawing.Size(236, 292);
            this.compatibilityListBox.TabIndex = 38;
            this.compatibilityListBox.TabStop = false;
            this.compatibilityListBox.DoubleClick += new System.EventHandler(this.compatibilityListBox_DoubleClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1197, 13);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(188, 29);
            this.label12.TabIndex = 39;
            this.label12.Text = "Compatibilities";
            // 
            // addCompatibilityButton
            // 
            this.addCompatibilityButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addCompatibilityButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCompatibilityButton.Location = new System.Drawing.Point(1288, 347);
            this.addCompatibilityButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addCompatibilityButton.Name = "addCompatibilityButton";
            this.addCompatibilityButton.Size = new System.Drawing.Size(68, 36);
            this.addCompatibilityButton.TabIndex = 40;
            this.addCompatibilityButton.TabStop = false;
            this.addCompatibilityButton.Text = "Add";
            this.addCompatibilityButton.UseVisualStyleBackColor = false;
            this.addCompatibilityButton.Click += new System.EventHandler(this.addCompatibilityButton_Click);
            // 
            // tableMaintnance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(1868, 1330);
            this.Controls.Add(this.addCompatibilityButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.compatibilityListBox);
            this.Controls.Add(this.viewSuppDocButton);
            this.Controls.Add(this.addSuppDocButton);
            this.Controls.Add(this.addSalesTypeButton);
            this.Controls.Add(this.addDBMembershipButton);
            this.Controls.Add(this.addSSPCategoryButton);
            this.Controls.Add(this.addSubCategoryButton);
            this.Controls.Add(this.addCategoryButton);
            this.Controls.Add(this.assoSuppDocButton);
            this.Controls.Add(this.addInstrumentButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.allSuppDocsDataGridView);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.partsListListBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.suppumentalDocsDataGridView);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.salesTypeListBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dBMembershipListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sSPCategoryListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.subCategoryListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.categoryListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.instrumentListBox);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "tableMaintnance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Association Tables";
            this.Load += new System.EventHandler(this.tableMaintnance_Load);
            this.Disposed += new System.EventHandler(this.tableMaintnance_Close);
            ((System.ComponentModel.ISupportInitialize)(this.tecanPartsListDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSPCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBMembershipBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppumentalDocsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppumentalDocsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allSuppDocsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TecanPartsListDataSet tecanPartsListDataSet;
        private System.Windows.Forms.BindingSource instrumentBindingSource;
        private TecanPartsListDataSetTableAdapters.InstrumentTableAdapter instrumentTableAdapter;
        private TecanPartsListDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ListBox instrumentListBox;
        private TecanPartsListDataSetTableAdapters.CategoryTableAdapter categoryTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private TecanPartsListDataSetTableAdapters.SubCategoryTableAdapter subCategoryTableAdapter;
        private System.Windows.Forms.ListBox categoryListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource subCategoryBindingSource;
        private System.Windows.Forms.ListBox subCategoryListBox;
        private System.Windows.Forms.Label label3;
        private TecanPartsListDataSetTableAdapters.SSPCategoryTableAdapter sSPCategoryTableAdapter;
        private System.Windows.Forms.BindingSource sSPCategoryBindingSource;
        private TecanPartsListDataSetTableAdapters.DBMembershipTableAdapter dBMembershipTableAdapter;
        private System.Windows.Forms.ListBox sSPCategoryListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource dBMembershipBindingSource;
        private TecanPartsListDataSetTableAdapters.SalesTypeTableAdapter salesTypeTableAdapter;
        private System.Windows.Forms.ListBox dBMembershipListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource salesTypeBindingSource;
        private TecanPartsListDataSetTableAdapters.SuppumentalDocsTableAdapter suppumentalDocsTableAdapter;
        private System.Windows.Forms.ListBox salesTypeListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource suppumentalDocsBindingSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView suppumentalDocsDataGridView;
        private System.Windows.Forms.Label label8;
        private TecanPartsListDataSetTableAdapters.PartsListTableAdapter partsListTableAdapter;
        private System.Windows.Forms.BindingSource partsListBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ListBox partsListListBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView allSuppDocsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button addInstrumentButton;
        private System.Windows.Forms.Button assoSuppDocButton;
        private System.Windows.Forms.Button addCategoryButton;
        private System.Windows.Forms.Button addSubCategoryButton;
        private System.Windows.Forms.Button addSSPCategoryButton;
        private System.Windows.Forms.Button addDBMembershipButton;
        private System.Windows.Forms.Button addSalesTypeButton;
        private System.Windows.Forms.Button addSuppDocButton;
        private System.Windows.Forms.Button viewSuppDocButton;
        private System.Windows.Forms.ListBox compatibilityListBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button addCompatibilityButton;
    }
}