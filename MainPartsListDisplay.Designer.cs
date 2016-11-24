using System.Windows.Forms;

namespace TecanPartListManager
{
    partial class MainPartsListDisplay
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
                try
                {
                    this.partsListDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                }
                catch { }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPartsListDisplay));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tecanPartsListDataSet = new TecanPartListManager.TecanPartsListDataSet();
            this.partsListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.partsListTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.PartsListTableAdapter();
            this.tableAdapterManager = new TecanPartListManager.TecanPartsListDataSetTableAdapters.TableAdapterManager();
            this.categoryTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.CategoryTableAdapter();
            this.instrumentTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.InstrumentTableAdapter();
            this.subCategoryTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.SubCategoryTableAdapter();
            this.partsListBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.partsListBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.PartNumberSearchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.PartNumberClearButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.DescriptionSearchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.DescriptionClearButton = new System.Windows.Forms.ToolStripButton();
            this.SelectAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.partsListDataGridView = new System.Windows.Forms.DataGridView();
            this.sAPIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instrumentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.InstrumentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SubCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DBMembership = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dbMembershipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.multiplePartDataChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseMembershipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSPCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.associationTablesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSAPDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zILRDiscontinuedPartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zILR1400ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zILR1401ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zILR1410ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mM60ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importAccessDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publishDatabasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quoteDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerPartslistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editLogonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SSPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sSPCategoryTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.SSPCategoryTableAdapter();
            this.dBMembershipTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.DBMembershipTableAdapter();
            this.CategoryListComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InstrumentListComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SubCategoryListComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DBMembershipListComboBox = new System.Windows.Forms.ComboBox();
            this.ClearFiltersButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SalesTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SalesTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salesTypeTableAdapter = new TecanPartListManager.TecanPartsListDataSetTableAdapters.SalesTypeTableAdapter();
            this.EditLogonPanel = new System.Windows.Forms.Panel();
            this.NoEditButton = new System.Windows.Forms.Button();
            this.EnableEditOKButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.EditPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.backupRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tecanPartsListDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsListBindingNavigator)).BeginInit();
            this.partsListBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstrumentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMembershipBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesTypeBindingSource)).BeginInit();
            this.EditLogonPanel.SuspendLayout();
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
            this.tableAdapterManager.CategoryTableAdapter = this.categoryTableAdapter;
            this.tableAdapterManager.DBMembershipTableAdapter = null;
            this.tableAdapterManager.InstrumentTableAdapter = this.instrumentTableAdapter;
            this.tableAdapterManager.PartImagesTableAdapter = null;
            this.tableAdapterManager.PartsListTableAdapter = this.partsListTableAdapter;
            this.tableAdapterManager.RequiredPartsTableAdapter = null;
            this.tableAdapterManager.SalesTypeTableAdapter = null;
            this.tableAdapterManager.SSPCategoryTableAdapter = null;
            this.tableAdapterManager.SubCategoryTableAdapter = this.subCategoryTableAdapter;
            this.tableAdapterManager.SuppumentalDocsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TecanPartListManager.TecanPartsListDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // categoryTableAdapter
            // 
            this.categoryTableAdapter.ClearBeforeFill = true;
            // 
            // instrumentTableAdapter
            // 
            this.instrumentTableAdapter.ClearBeforeFill = true;
            // 
            // subCategoryTableAdapter
            // 
            this.subCategoryTableAdapter.ClearBeforeFill = true;
            // 
            // partsListBindingNavigator
            // 
            this.partsListBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.partsListBindingNavigator.BackColor = System.Drawing.Color.Beige;
            this.partsListBindingNavigator.BindingSource = this.partsListBindingSource;
            this.partsListBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.partsListBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.partsListBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.partsListBindingNavigatorSaveItem,
            this.toolStripSeparator,
            this.toolStripLabel1,
            this.PartNumberSearchTextBox,
            this.PartNumberClearButton,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.DescriptionSearchTextBox,
            this.DescriptionClearButton,
            this.SelectAllToolStripButton,
            this.helpToolStripButton});
            this.partsListBindingNavigator.Location = new System.Drawing.Point(0, 24);
            this.partsListBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.partsListBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.partsListBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.partsListBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.partsListBindingNavigator.Name = "partsListBindingNavigator";
            this.partsListBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.partsListBindingNavigator.Size = new System.Drawing.Size(1898, 25);
            this.partsListBindingNavigator.TabIndex = 0;
            this.partsListBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.AutoSize = false;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // partsListBindingNavigatorSaveItem
            // 
            this.partsListBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.partsListBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("partsListBindingNavigatorSaveItem.Image")));
            this.partsListBindingNavigatorSaveItem.Name = "partsListBindingNavigatorSaveItem";
            this.partsListBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.partsListBindingNavigatorSaveItem.Text = "Save Data";
            this.partsListBindingNavigatorSaveItem.Click += new System.EventHandler(this.partsListBindingNavigatorSaveItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(38, 20);
            this.toolStripLabel1.Text = "Part #";
            // 
            // PartNumberSearchTextBox
            // 
            this.PartNumberSearchTextBox.Name = "PartNumberSearchTextBox";
            this.PartNumberSearchTextBox.Size = new System.Drawing.Size(80, 25);
            this.PartNumberSearchTextBox.TextChanged += new System.EventHandler(this.PartNumberSearchTextBox_TextChanged);
            // 
            // PartNumberClearButton
            // 
            this.PartNumberClearButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.PartNumberClearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PartNumberClearButton.Image = ((System.Drawing.Image)(resources.GetObject("PartNumberClearButton.Image")));
            this.PartNumberClearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PartNumberClearButton.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.PartNumberClearButton.Name = "PartNumberClearButton";
            this.PartNumberClearButton.Size = new System.Drawing.Size(38, 20);
            this.PartNumberClearButton.Text = "Clear";
            this.PartNumberClearButton.Click += new System.EventHandler(this.PartNumberClearButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(67, 20);
            this.toolStripLabel2.Text = "Description";
            // 
            // DescriptionSearchTextBox
            // 
            this.DescriptionSearchTextBox.Name = "DescriptionSearchTextBox";
            this.DescriptionSearchTextBox.Size = new System.Drawing.Size(250, 25);
            this.DescriptionSearchTextBox.TextChanged += new System.EventHandler(this.DescriptionSearchTextBox_TextChanged);
            // 
            // DescriptionClearButton
            // 
            this.DescriptionClearButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DescriptionClearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DescriptionClearButton.Image = ((System.Drawing.Image)(resources.GetObject("DescriptionClearButton.Image")));
            this.DescriptionClearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DescriptionClearButton.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.DescriptionClearButton.Name = "DescriptionClearButton";
            this.DescriptionClearButton.Size = new System.Drawing.Size(38, 20);
            this.DescriptionClearButton.Text = "Clear";
            this.DescriptionClearButton.Click += new System.EventHandler(this.DescriptionClearButton_Click);
            // 
            // SelectAllToolStripButton
            // 
            this.SelectAllToolStripButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SelectAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SelectAllToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SelectAllToolStripButton.Image")));
            this.SelectAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectAllToolStripButton.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.SelectAllToolStripButton.Name = "SelectAllToolStripButton";
            this.SelectAllToolStripButton.Size = new System.Drawing.Size(59, 20);
            this.SelectAllToolStripButton.Text = "Select All";
            this.SelectAllToolStripButton.Click += new System.EventHandler(this.SelectAllToolStripButton_Click);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // partsListDataGridView
            // 
            this.partsListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.partsListDataGridView.AutoGenerateColumns = false;
            this.partsListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.partsListDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.partsListDataGridView.BackgroundColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.partsListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.partsListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sAPIdDataGridViewTextBoxColumn,
            this.instrumentDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn,
            this.subCategoryDataGridViewTextBoxColumn,
            this.DBMembership,
            this.descriptionDataGridViewTextBoxColumn});
            this.partsListDataGridView.DataSource = this.partsListBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.partsListDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.partsListDataGridView.EnableHeadersVisualStyles = false;
            this.partsListDataGridView.GridColor = System.Drawing.Color.White;
            this.partsListDataGridView.Location = new System.Drawing.Point(0, 52);
            this.partsListDataGridView.Name = "partsListDataGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.partsListDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.partsListDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.partsListDataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            this.partsListDataGridView.Size = new System.Drawing.Size(1898, 228);
            this.partsListDataGridView.TabIndex = 1;
            this.partsListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.partsListDataGridView_CellDoubleClick);
            // 
            // sAPIdDataGridViewTextBoxColumn
            // 
            this.sAPIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sAPIdDataGridViewTextBoxColumn.DataPropertyName = "SAPId";
            this.sAPIdDataGridViewTextBoxColumn.HeaderText = "SAPId";
            this.sAPIdDataGridViewTextBoxColumn.Name = "sAPIdDataGridViewTextBoxColumn";
            this.sAPIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.sAPIdDataGridViewTextBoxColumn.Width = 62;
            // 
            // instrumentDataGridViewTextBoxColumn
            // 
            this.instrumentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.instrumentDataGridViewTextBoxColumn.DataPropertyName = "Instrument";
            this.instrumentDataGridViewTextBoxColumn.DataSource = this.InstrumentBindingSource;
            this.instrumentDataGridViewTextBoxColumn.DisplayMember = "InstrumentName";
            this.instrumentDataGridViewTextBoxColumn.HeaderText = "Instrument";
            this.instrumentDataGridViewTextBoxColumn.Name = "instrumentDataGridViewTextBoxColumn";
            this.instrumentDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.instrumentDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.instrumentDataGridViewTextBoxColumn.ValueMember = "InstrumentID";
            this.instrumentDataGridViewTextBoxColumn.Width = 175;
            // 
            // InstrumentBindingSource
            // 
            this.InstrumentBindingSource.DataMember = "Instrument";
            this.InstrumentBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.DataSource = this.CategoryBindingSource;
            this.categoryDataGridViewTextBoxColumn.DisplayMember = "CategoryName";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.categoryDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.categoryDataGridViewTextBoxColumn.ValueMember = "CategoryID";
            this.categoryDataGridViewTextBoxColumn.Width = 175;
            // 
            // CategoryBindingSource
            // 
            this.CategoryBindingSource.DataMember = "Category";
            this.CategoryBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // subCategoryDataGridViewTextBoxColumn
            // 
            this.subCategoryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.subCategoryDataGridViewTextBoxColumn.DataPropertyName = "SubCategory";
            this.subCategoryDataGridViewTextBoxColumn.DataSource = this.SubCategoryBindingSource;
            this.subCategoryDataGridViewTextBoxColumn.DisplayMember = "SubCategoryName";
            this.subCategoryDataGridViewTextBoxColumn.HeaderText = "SubCategory";
            this.subCategoryDataGridViewTextBoxColumn.Name = "subCategoryDataGridViewTextBoxColumn";
            this.subCategoryDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.subCategoryDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.subCategoryDataGridViewTextBoxColumn.ValueMember = "SubCategoryID";
            this.subCategoryDataGridViewTextBoxColumn.Width = 175;
            // 
            // SubCategoryBindingSource
            // 
            this.SubCategoryBindingSource.DataMember = "SubCategory";
            this.SubCategoryBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // DBMembership
            // 
            this.DBMembership.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DBMembership.DataPropertyName = "DBMembership";
            this.DBMembership.DataSource = this.dbMembershipBindingSource;
            this.DBMembership.DisplayMember = "DBName";
            this.DBMembership.HeaderText = "DB Membership";
            this.DBMembership.Name = "DBMembership";
            this.DBMembership.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DBMembership.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DBMembership.ValueMember = "DBID";
            this.DBMembership.Width = 75;
            // 
            // dbMembershipBindingSource
            // 
            this.dbMembershipBindingSource.DataMember = "DBMembership";
            this.dbMembershipBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "DetailDescription";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descriptionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PowderBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.multiplePartDataChangeToolStripMenuItem,
            this.databaseToolsToolStripMenuItem,
            this.publishDatabasesToolStripMenuItem,
            this.editLogonToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1898, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // multiplePartDataChangeToolStripMenuItem
            // 
            this.multiplePartDataChangeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instrumentToolStripMenuItem,
            this.categoryToolStripMenuItem,
            this.subCategoryToolStripMenuItem,
            this.databaseMembershipToolStripMenuItem,
            this.sSPCategoryToolStripMenuItem,
            this.salesTypeToolStripMenuItem});
            this.multiplePartDataChangeToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiplePartDataChangeToolStripMenuItem.Name = "multiplePartDataChangeToolStripMenuItem";
            this.multiplePartDataChangeToolStripMenuItem.Size = new System.Drawing.Size(162, 20);
            this.multiplePartDataChangeToolStripMenuItem.Text = "Multiple Part Data Change";
            // 
            // instrumentToolStripMenuItem
            // 
            this.instrumentToolStripMenuItem.Name = "instrumentToolStripMenuItem";
            this.instrumentToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.instrumentToolStripMenuItem.Text = "Instrument";
            this.instrumentToolStripMenuItem.Click += new System.EventHandler(this.instrumentToolStripMenuItem_Click);
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.categoryToolStripMenuItem.Text = "Category";
            this.categoryToolStripMenuItem.Click += new System.EventHandler(this.categoryToolStripMenuItem_Click);
            // 
            // subCategoryToolStripMenuItem
            // 
            this.subCategoryToolStripMenuItem.Name = "subCategoryToolStripMenuItem";
            this.subCategoryToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.subCategoryToolStripMenuItem.Text = "Sub Category";
            this.subCategoryToolStripMenuItem.Click += new System.EventHandler(this.subCategoryToolStripMenuItem_Click);
            // 
            // databaseMembershipToolStripMenuItem
            // 
            this.databaseMembershipToolStripMenuItem.Name = "databaseMembershipToolStripMenuItem";
            this.databaseMembershipToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.databaseMembershipToolStripMenuItem.Text = "Database Membership";
            this.databaseMembershipToolStripMenuItem.Click += new System.EventHandler(this.databaseMembershipToolStripMenuItem_Click);
            // 
            // sSPCategoryToolStripMenuItem
            // 
            this.sSPCategoryToolStripMenuItem.Name = "sSPCategoryToolStripMenuItem";
            this.sSPCategoryToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.sSPCategoryToolStripMenuItem.Text = "SSP Category";
            this.sSPCategoryToolStripMenuItem.Click += new System.EventHandler(this.sSPCategoryToolStripMenuItem_Click);
            // 
            // salesTypeToolStripMenuItem
            // 
            this.salesTypeToolStripMenuItem.Name = "salesTypeToolStripMenuItem";
            this.salesTypeToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.salesTypeToolStripMenuItem.Text = "Sales Type";
            this.salesTypeToolStripMenuItem.Click += new System.EventHandler(this.salesTypeToolStripMenuItem_Click);
            // 
            // databaseToolsToolStripMenuItem
            // 
            this.databaseToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.associationTablesToolStripMenuItem1,
            this.applicationDocumentsToolStripMenuItem,
            this.importSAPDataToolStripMenuItem1,
            this.importAccessDatabaseToolStripMenuItem,
            this.backupRestoreToolStripMenuItem});
            this.databaseToolsToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseToolsToolStripMenuItem.Name = "databaseToolsToolStripMenuItem";
            this.databaseToolsToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.databaseToolsToolStripMenuItem.Text = "Database Tools";
            // 
            // associationTablesToolStripMenuItem1
            // 
            this.associationTablesToolStripMenuItem1.Name = "associationTablesToolStripMenuItem1";
            this.associationTablesToolStripMenuItem1.Size = new System.Drawing.Size(208, 22);
            this.associationTablesToolStripMenuItem1.Text = "Association Tables";
            this.associationTablesToolStripMenuItem1.Click += new System.EventHandler(this.associationTablesToolStripMenuItem1_Click);
            // 
            // applicationDocumentsToolStripMenuItem
            // 
            this.applicationDocumentsToolStripMenuItem.Name = "applicationDocumentsToolStripMenuItem";
            this.applicationDocumentsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.applicationDocumentsToolStripMenuItem.Text = "Application Documents";
            this.applicationDocumentsToolStripMenuItem.Click += new System.EventHandler(this.applicationDocumentsToolStripMenuItem_Click);
            // 
            // importSAPDataToolStripMenuItem1
            // 
            this.importSAPDataToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zILRDiscontinuedPartsToolStripMenuItem,
            this.zILR1400ToolStripMenuItem,
            this.zILR1401ToolStripMenuItem,
            this.zILR1410ToolStripMenuItem,
            this.mM60ToolStripMenuItem});
            this.importSAPDataToolStripMenuItem1.Name = "importSAPDataToolStripMenuItem1";
            this.importSAPDataToolStripMenuItem1.Size = new System.Drawing.Size(208, 22);
            this.importSAPDataToolStripMenuItem1.Text = "Import SAP Data";
            // 
            // zILRDiscontinuedPartsToolStripMenuItem
            // 
            this.zILRDiscontinuedPartsToolStripMenuItem.Name = "zILRDiscontinuedPartsToolStripMenuItem";
            this.zILRDiscontinuedPartsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.zILRDiscontinuedPartsToolStripMenuItem.Text = "ZILR Discontinued Parts";
            this.zILRDiscontinuedPartsToolStripMenuItem.Click += new System.EventHandler(this.zILRDiscontinuedPartsToolStripMenuItem_Click);
            // 
            // zILR1400ToolStripMenuItem
            // 
            this.zILR1400ToolStripMenuItem.Name = "zILR1400ToolStripMenuItem";
            this.zILR1400ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.zILR1400ToolStripMenuItem.Text = "ZILR Price Changes";
            this.zILR1400ToolStripMenuItem.Click += new System.EventHandler(this.zILR1400ToolStripMenuItem_Click);
            // 
            // zILR1401ToolStripMenuItem
            // 
            this.zILR1401ToolStripMenuItem.Name = "zILR1401ToolStripMenuItem";
            this.zILR1401ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.zILR1401ToolStripMenuItem.Text = "ASP";
            this.zILR1401ToolStripMenuItem.Click += new System.EventHandler(this.zILR1401ToolStripMenuItem_Click);
            // 
            // zILR1410ToolStripMenuItem
            // 
            this.zILR1410ToolStripMenuItem.Name = "zILR1410ToolStripMenuItem";
            this.zILR1410ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.zILR1410ToolStripMenuItem.Text = "Sales Text";
            this.zILR1410ToolStripMenuItem.Click += new System.EventHandler(this.zILR1410ToolStripMenuItem_Click);
            // 
            // mM60ToolStripMenuItem
            // 
            this.mM60ToolStripMenuItem.Name = "mM60ToolStripMenuItem";
            this.mM60ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.mM60ToolStripMenuItem.Text = "MM60";
            this.mM60ToolStripMenuItem.Click += new System.EventHandler(this.mM60ToolStripMenuItem_Click);
            // 
            // importAccessDatabaseToolStripMenuItem
            // 
            this.importAccessDatabaseToolStripMenuItem.Name = "importAccessDatabaseToolStripMenuItem";
            this.importAccessDatabaseToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.importAccessDatabaseToolStripMenuItem.Text = "Import Access Database";
            this.importAccessDatabaseToolStripMenuItem.Click += new System.EventHandler(this.importAccessDatabaseToolStripMenuItem_Click_1);
            // 
            // publishDatabasesToolStripMenuItem
            // 
            this.publishDatabasesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quoteDatabaseToolStripMenuItem,
            this.customerPartslistToolStripMenuItem,
            this.bothToolStripMenuItem});
            this.publishDatabasesToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.publishDatabasesToolStripMenuItem.Name = "publishDatabasesToolStripMenuItem";
            this.publishDatabasesToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.publishDatabasesToolStripMenuItem.Text = "Publish Databases";
            // 
            // quoteDatabaseToolStripMenuItem
            // 
            this.quoteDatabaseToolStripMenuItem.Name = "quoteDatabaseToolStripMenuItem";
            this.quoteDatabaseToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.quoteDatabaseToolStripMenuItem.Text = "Quote Database";
            this.quoteDatabaseToolStripMenuItem.Click += new System.EventHandler(this.quoteDatabaseToolStripMenuItem_Click);
            // 
            // customerPartslistToolStripMenuItem
            // 
            this.customerPartslistToolStripMenuItem.Name = "customerPartslistToolStripMenuItem";
            this.customerPartslistToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.customerPartslistToolStripMenuItem.Text = "Customer Partslist";
            this.customerPartslistToolStripMenuItem.Click += new System.EventHandler(this.customerPartslistToolStripMenuItem_Click);
            // 
            // bothToolStripMenuItem
            // 
            this.bothToolStripMenuItem.Name = "bothToolStripMenuItem";
            this.bothToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.bothToolStripMenuItem.Text = "Both";
            this.bothToolStripMenuItem.Click += new System.EventHandler(this.bothToolStripMenuItem_Click);
            // 
            // editLogonToolStripMenuItem
            // 
            this.editLogonToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editLogonToolStripMenuItem.Name = "editLogonToolStripMenuItem";
            this.editLogonToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.editLogonToolStripMenuItem.Text = "Edit Logon";
            this.editLogonToolStripMenuItem.Click += new System.EventHandler(this.editLogonToolStripMenuItem_Click);
            // 
            // SSPBindingSource
            // 
            this.SSPBindingSource.DataMember = "SSPCategory";
            this.SSPBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // sSPCategoryTableAdapter
            // 
            this.sSPCategoryTableAdapter.ClearBeforeFill = true;
            // 
            // dBMembershipTableAdapter
            // 
            this.dBMembershipTableAdapter.ClearBeforeFill = true;
            // 
            // CategoryListComboBox
            // 
            this.CategoryListComboBox.FormattingEnabled = true;
            this.CategoryListComboBox.Location = new System.Drawing.Point(993, 2);
            this.CategoryListComboBox.Name = "CategoryListComboBox";
            this.CategoryListComboBox.Size = new System.Drawing.Size(155, 21);
            this.CategoryListComboBox.TabIndex = 3;
            this.CategoryListComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryListComboBox_SelectedIndexChanged);
            this.CategoryListComboBox.Click += new System.EventHandler(this.CategoryListComboBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(723, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Instrument";
            // 
            // InstrumentListComboBox
            // 
            this.InstrumentListComboBox.FormattingEnabled = true;
            this.InstrumentListComboBox.Location = new System.Drawing.Point(795, 2);
            this.InstrumentListComboBox.Name = "InstrumentListComboBox";
            this.InstrumentListComboBox.Size = new System.Drawing.Size(130, 21);
            this.InstrumentListComboBox.TabIndex = 5;
            this.InstrumentListComboBox.SelectedIndexChanged += new System.EventHandler(this.InstrumentListComboBox_SelectedIndexChanged);
            this.InstrumentListComboBox.Click += new System.EventHandler(this.InstrumentListComboBox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PowderBlue;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(931, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.PowderBlue;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1154, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sub-Category";
            // 
            // SubCategoryListComboBox
            // 
            this.SubCategoryListComboBox.FormattingEnabled = true;
            this.SubCategoryListComboBox.Location = new System.Drawing.Point(1242, 2);
            this.SubCategoryListComboBox.Name = "SubCategoryListComboBox";
            this.SubCategoryListComboBox.Size = new System.Drawing.Size(173, 21);
            this.SubCategoryListComboBox.TabIndex = 8;
            this.SubCategoryListComboBox.SelectedIndexChanged += new System.EventHandler(this.SubCategoryListComboBox_SelectedIndexChanged);
            this.SubCategoryListComboBox.Click += new System.EventHandler(this.SubCategoryListComboBox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.PowderBlue;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1421, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "DB Membership";
            // 
            // DBMembershipListComboBox
            // 
            this.DBMembershipListComboBox.FormattingEnabled = true;
            this.DBMembershipListComboBox.Location = new System.Drawing.Point(1523, 2);
            this.DBMembershipListComboBox.Name = "DBMembershipListComboBox";
            this.DBMembershipListComboBox.Size = new System.Drawing.Size(64, 21);
            this.DBMembershipListComboBox.TabIndex = 10;
            this.DBMembershipListComboBox.SelectedIndexChanged += new System.EventHandler(this.DBMembershipListComboBox_SelectedIndexChanged);
            this.DBMembershipListComboBox.Click += new System.EventHandler(this.DBMembershipListComboBox_Click);
            // 
            // ClearFiltersButton
            // 
            this.ClearFiltersButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClearFiltersButton.Location = new System.Drawing.Point(1789, 0);
            this.ClearFiltersButton.Name = "ClearFiltersButton";
            this.ClearFiltersButton.Size = new System.Drawing.Size(97, 24);
            this.ClearFiltersButton.TabIndex = 11;
            this.ClearFiltersButton.Text = "Clear Filters";
            this.ClearFiltersButton.UseVisualStyleBackColor = false;
            this.ClearFiltersButton.Click += new System.EventHandler(this.ClearFiltersButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.PowderBlue;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1593, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sales Type";
            // 
            // SalesTypeComboBox
            // 
            this.SalesTypeComboBox.FormattingEnabled = true;
            this.SalesTypeComboBox.Location = new System.Drawing.Point(1666, 2);
            this.SalesTypeComboBox.Name = "SalesTypeComboBox";
            this.SalesTypeComboBox.Size = new System.Drawing.Size(64, 21);
            this.SalesTypeComboBox.TabIndex = 13;
            this.SalesTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.SalesTypeComboBox_SelectedIndexChanged);
            this.SalesTypeComboBox.Click += new System.EventHandler(this.SalesTypeComboBox_Click);
            // 
            // SalesTypeBindingSource
            // 
            this.SalesTypeBindingSource.DataMember = "SalesType";
            this.SalesTypeBindingSource.DataSource = this.tecanPartsListDataSet;
            // 
            // salesTypeTableAdapter
            // 
            this.salesTypeTableAdapter.ClearBeforeFill = true;
            // 
            // EditLogonPanel
            // 
            this.EditLogonPanel.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.EditLogonPanel.Controls.Add(this.NoEditButton);
            this.EditLogonPanel.Controls.Add(this.EnableEditOKButton);
            this.EditLogonPanel.Controls.Add(this.label7);
            this.EditLogonPanel.Controls.Add(this.EditPasswordTextBox);
            this.EditLogonPanel.Controls.Add(this.label6);
            this.EditLogonPanel.Location = new System.Drawing.Point(819, 147);
            this.EditLogonPanel.Name = "EditLogonPanel";
            this.EditLogonPanel.Size = new System.Drawing.Size(260, 148);
            this.EditLogonPanel.TabIndex = 14;
            this.EditLogonPanel.Visible = false;
            // 
            // NoEditButton
            // 
            this.NoEditButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.NoEditButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoEditButton.Location = new System.Drawing.Point(104, 98);
            this.NoEditButton.Name = "NoEditButton";
            this.NoEditButton.Size = new System.Drawing.Size(135, 35);
            this.NoEditButton.TabIndex = 4;
            this.NoEditButton.Text = "Continue, No Edit";
            this.NoEditButton.UseVisualStyleBackColor = false;
            this.NoEditButton.Click += new System.EventHandler(this.NoEditButton_Click);
            // 
            // EnableEditOKButton
            // 
            this.EnableEditOKButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.EnableEditOKButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnableEditOKButton.Location = new System.Drawing.Point(38, 98);
            this.EnableEditOKButton.Name = "EnableEditOKButton";
            this.EnableEditOKButton.Size = new System.Drawing.Size(51, 35);
            this.EnableEditOKButton.TabIndex = 3;
            this.EnableEditOKButton.Text = "OK";
            this.EnableEditOKButton.UseVisualStyleBackColor = false;
            this.EnableEditOKButton.Click += new System.EventHandler(this.EnableEditOKButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Enter Password:";
            // 
            // EditPasswordTextBox
            // 
            this.EditPasswordTextBox.Location = new System.Drawing.Point(27, 58);
            this.EditPasswordTextBox.Name = "EditPasswordTextBox";
            this.EditPasswordTextBox.Size = new System.Drawing.Size(212, 20);
            this.EditPasswordTextBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(55, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Enable Editing Logon";
            // 
            // backupRestoreToolStripMenuItem
            // 
            this.backupRestoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem,
            this.restoreToolStripMenuItem});
            this.backupRestoreToolStripMenuItem.Name = "backupRestoreToolStripMenuItem";
            this.backupRestoreToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.backupRestoreToolStripMenuItem.Text = "Backup / Restore";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            // 
            // MainPartsListDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 514);
            this.Controls.Add(this.EditLogonPanel);
            this.Controls.Add(this.SalesTypeComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ClearFiltersButton);
            this.Controls.Add(this.DBMembershipListComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SubCategoryListComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InstrumentListComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CategoryListComboBox);
            this.Controls.Add(this.partsListDataGridView);
            this.Controls.Add(this.partsListBindingNavigator);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainPartsListDisplay";
            this.Text = "Tecan Parts List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainPartsListDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tecanPartsListDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsListBindingNavigator)).EndInit();
            this.partsListBindingNavigator.ResumeLayout(false);
            this.partsListBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstrumentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbMembershipBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesTypeBindingSource)).EndInit();
            this.EditLogonPanel.ResumeLayout(false);
            this.EditLogonPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TecanPartsListDataSet tecanPartsListDataSet;
        public System.Windows.Forms.BindingSource partsListBindingSource;
        private TecanPartsListDataSetTableAdapters.PartsListTableAdapter partsListTableAdapter;
        private TecanPartsListDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator partsListBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton partsListBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView partsListDataGridView;
        private System.Windows.Forms.BindingSource InstrumentBindingSource;
        private TecanPartsListDataSetTableAdapters.InstrumentTableAdapter instrumentTableAdapter;
        private TecanPartsListDataSetTableAdapters.CategoryTableAdapter categoryTableAdapter;
        private System.Windows.Forms.BindingSource CategoryBindingSource;
        private TecanPartsListDataSetTableAdapters.SubCategoryTableAdapter subCategoryTableAdapter;
        private System.Windows.Forms.BindingSource SubCategoryBindingSource;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox PartNumberSearchTextBox;
        private ToolStripButton PartNumberClearButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox DescriptionSearchTextBox;
        private ToolStripButton DescriptionClearButton;
        private BindingSource SSPBindingSource;
        private TecanPartsListDataSetTableAdapters.SSPCategoryTableAdapter sSPCategoryTableAdapter;
        private ToolStripMenuItem multiplePartDataChangeToolStripMenuItem;
        private ToolStripMenuItem instrumentToolStripMenuItem;
        private ToolStripMenuItem categoryToolStripMenuItem;
        private ToolStripMenuItem subCategoryToolStripMenuItem;
        private ToolStripMenuItem sSPCategoryToolStripMenuItem;
        private ToolStripMenuItem databaseMembershipToolStripMenuItem;
        private ToolStripMenuItem salesTypeToolStripMenuItem;
        private BindingSource dbMembershipBindingSource;
        private TecanPartsListDataSetTableAdapters.DBMembershipTableAdapter dBMembershipTableAdapter;
        private ToolStripMenuItem publishDatabasesToolStripMenuItem;
        private ComboBox CategoryListComboBox;
        private Label label1;
        private ComboBox InstrumentListComboBox;
        private Label label2;
        private Label label3;
        private ComboBox SubCategoryListComboBox;
        private Label label4;
        private ComboBox DBMembershipListComboBox;
        private Button ClearFiltersButton;
        private DataGridViewTextBoxColumn sAPIdDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn instrumentDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn categoryDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn subCategoryDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn DBMembership;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private ToolStripMenuItem quoteDatabaseToolStripMenuItem;
        private ToolStripMenuItem customerPartslistToolStripMenuItem;
        private ToolStripMenuItem bothToolStripMenuItem;
        private ToolStripMenuItem databaseToolsToolStripMenuItem;
        private ToolStripMenuItem importSAPDataToolStripMenuItem1;
        private ToolStripMenuItem zILR1400ToolStripMenuItem;
        private ToolStripMenuItem zILR1401ToolStripMenuItem;
        private ToolStripMenuItem zILR1410ToolStripMenuItem;
        private ToolStripMenuItem associationTablesToolStripMenuItem1;
        private ToolStripMenuItem importAccessDatabaseToolStripMenuItem;
        private ToolStripButton SelectAllToolStripButton;
        private Label label5;
        private ComboBox SalesTypeComboBox;
        private BindingSource SalesTypeBindingSource;
        private TecanPartsListDataSetTableAdapters.SalesTypeTableAdapter salesTypeTableAdapter;
        private ToolStripMenuItem mM60ToolStripMenuItem;
        private ToolStripMenuItem zILRDiscontinuedPartsToolStripMenuItem;
        private Panel EditLogonPanel;
        private Button NoEditButton;
        private Button EnableEditOKButton;
        private Label label7;
        private TextBox EditPasswordTextBox;
        private Label label6;
        private ToolStripMenuItem editLogonToolStripMenuItem;
        private ToolStripMenuItem applicationDocumentsToolStripMenuItem;
        private ToolStripMenuItem backupRestoreToolStripMenuItem;
        private ToolStripMenuItem backupToolStripMenuItem;
        private ToolStripMenuItem restoreToolStripMenuItem;

    }
}

