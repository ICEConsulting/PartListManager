using System.Windows.Forms;
using System;

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
            this.backupRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publishDatabasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quoteDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerPartslistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findReplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.initalizePanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.exitAppButton = new System.Windows.Forms.Button();
            this.getAccessButton = new System.Windows.Forms.Button();
            this.restoreBackupButton = new System.Windows.Forms.Button();
            this.FindReplacePanel = new System.Windows.Forms.Panel();
            this.DeleteFindCheckBox = new System.Windows.Forms.CheckBox();
            this.RecordsFoundLabel = new System.Windows.Forms.Label();
            this.FindCancelButton = new System.Windows.Forms.Button();
            this.FindAgainButton = new System.Windows.Forms.Button();
            this.FindDataGridView = new System.Windows.Forms.DataGridView();
            this.SelectAllFindCheckBox = new System.Windows.Forms.CheckBox();
            this.CancelFindButton = new System.Windows.Forms.Button();
            this.FindButton = new System.Windows.Forms.Button();
            this.FindCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ReplaceTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.FindTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
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
            this.initalizePanel.SuspendLayout();
            this.FindReplacePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FindDataGridView)).BeginInit();
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
            this.partsListBindingNavigator.Size = new System.Drawing.Size(1927, 25);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.partsListDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.partsListDataGridView.EnableHeadersVisualStyles = false;
            this.partsListDataGridView.GridColor = System.Drawing.Color.White;
            this.partsListDataGridView.Location = new System.Drawing.Point(0, 48);
            this.partsListDataGridView.Name = "partsListDataGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.partsListDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.partsListDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.partsListDataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            this.partsListDataGridView.Size = new System.Drawing.Size(1919, 587);
            this.partsListDataGridView.TabIndex = 1;
            this.partsListDataGridView.TabStop = false;
            this.partsListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.partsListDataGridView_CellDoubleClick);
            this.partsListDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.partsListDataGridView_CellValueChanged);
            this.partsListDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.partsListDataGridView_CurrentCellDirtyStateChanged);
            // 
            // sAPIdDataGridViewTextBoxColumn
            // 
            this.sAPIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sAPIdDataGridViewTextBoxColumn.DataPropertyName = "SAPId";
            this.sAPIdDataGridViewTextBoxColumn.HeaderText = "SAPId";
            this.sAPIdDataGridViewTextBoxColumn.Name = "sAPIdDataGridViewTextBoxColumn";
            this.sAPIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.sAPIdDataGridViewTextBoxColumn.Width = 61;
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
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "DetailDescription";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descriptionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Detail Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 1200;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PowderBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.multiplePartDataChangeToolStripMenuItem,
            this.databaseToolsToolStripMenuItem,
            this.publishDatabasesToolStripMenuItem,
            this.findReplaceToolStripMenuItem,
            this.editLogonToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1927, 24);
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
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
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
            // findReplaceToolStripMenuItem
            // 
            this.findReplaceToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findReplaceToolStripMenuItem.Name = "findReplaceToolStripMenuItem";
            this.findReplaceToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.findReplaceToolStripMenuItem.Text = "Find / Replace";
            this.findReplaceToolStripMenuItem.Click += new System.EventHandler(this.findReplaceToolStripMenuItem_Click);
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
            this.CategoryListComboBox.Location = new System.Drawing.Point(881, 1);
            this.CategoryListComboBox.Name = "CategoryListComboBox";
            this.CategoryListComboBox.Size = new System.Drawing.Size(155, 22);
            this.CategoryListComboBox.TabIndex = 3;
            this.CategoryListComboBox.TabStop = false;
            this.CategoryListComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryListComboBox_SelectedIndexChanged);
            this.CategoryListComboBox.Click += new System.EventHandler(this.CategoryListComboBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(615, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Instrument";
            // 
            // InstrumentListComboBox
            // 
            this.InstrumentListComboBox.FormattingEnabled = true;
            this.InstrumentListComboBox.Location = new System.Drawing.Point(682, 1);
            this.InstrumentListComboBox.Name = "InstrumentListComboBox";
            this.InstrumentListComboBox.Size = new System.Drawing.Size(132, 22);
            this.InstrumentListComboBox.TabIndex = 5;
            this.InstrumentListComboBox.TabStop = false;
            this.InstrumentListComboBox.SelectedIndexChanged += new System.EventHandler(this.InstrumentListComboBox_SelectedIndexChanged);
            this.InstrumentListComboBox.Click += new System.EventHandler(this.InstrumentListComboBox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PowderBlue;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(820, 3);
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
            this.label3.Location = new System.Drawing.Point(1043, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sub-Category";
            // 
            // SubCategoryListComboBox
            // 
            this.SubCategoryListComboBox.FormattingEnabled = true;
            this.SubCategoryListComboBox.Location = new System.Drawing.Point(1129, 1);
            this.SubCategoryListComboBox.Name = "SubCategoryListComboBox";
            this.SubCategoryListComboBox.Size = new System.Drawing.Size(173, 22);
            this.SubCategoryListComboBox.TabIndex = 8;
            this.SubCategoryListComboBox.TabStop = false;
            this.SubCategoryListComboBox.SelectedIndexChanged += new System.EventHandler(this.SubCategoryListComboBox_SelectedIndexChanged);
            this.SubCategoryListComboBox.Click += new System.EventHandler(this.SubCategoryListComboBox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.PowderBlue;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1313, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "DB Membership";
            // 
            // DBMembershipListComboBox
            // 
            this.DBMembershipListComboBox.FormattingEnabled = true;
            this.DBMembershipListComboBox.Location = new System.Drawing.Point(1410, 1);
            this.DBMembershipListComboBox.Name = "DBMembershipListComboBox";
            this.DBMembershipListComboBox.Size = new System.Drawing.Size(70, 22);
            this.DBMembershipListComboBox.TabIndex = 10;
            this.DBMembershipListComboBox.TabStop = false;
            this.DBMembershipListComboBox.SelectedIndexChanged += new System.EventHandler(this.DBMembershipListComboBox_SelectedIndexChanged);
            this.DBMembershipListComboBox.Click += new System.EventHandler(this.DBMembershipListComboBox_Click);
            // 
            // ClearFiltersButton
            // 
            this.ClearFiltersButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClearFiltersButton.Location = new System.Drawing.Point(1628, -1);
            this.ClearFiltersButton.Name = "ClearFiltersButton";
            this.ClearFiltersButton.Size = new System.Drawing.Size(97, 22);
            this.ClearFiltersButton.TabIndex = 11;
            this.ClearFiltersButton.TabStop = false;
            this.ClearFiltersButton.Text = "Clear Filters";
            this.ClearFiltersButton.UseVisualStyleBackColor = false;
            this.ClearFiltersButton.Click += new System.EventHandler(this.ClearFiltersButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.PowderBlue;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1488, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sales Type";
            // 
            // SalesTypeComboBox
            // 
            this.SalesTypeComboBox.FormattingEnabled = true;
            this.SalesTypeComboBox.Location = new System.Drawing.Point(1560, 0);
            this.SalesTypeComboBox.Name = "SalesTypeComboBox";
            this.SalesTypeComboBox.Size = new System.Drawing.Size(64, 22);
            this.SalesTypeComboBox.TabIndex = 13;
            this.SalesTypeComboBox.TabStop = false;
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
            this.EditLogonPanel.Location = new System.Drawing.Point(819, 135);
            this.EditLogonPanel.Name = "EditLogonPanel";
            this.EditLogonPanel.Size = new System.Drawing.Size(260, 137);
            this.EditLogonPanel.TabIndex = 14;
            this.EditLogonPanel.Visible = false;
            // 
            // NoEditButton
            // 
            this.NoEditButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.NoEditButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoEditButton.Location = new System.Drawing.Point(104, 91);
            this.NoEditButton.Name = "NoEditButton";
            this.NoEditButton.Size = new System.Drawing.Size(135, 33);
            this.NoEditButton.TabIndex = 4;
            this.NoEditButton.Text = "Continue, No Edit";
            this.NoEditButton.UseVisualStyleBackColor = false;
            this.NoEditButton.Click += new System.EventHandler(this.NoEditButton_Click);
            // 
            // EnableEditOKButton
            // 
            this.EnableEditOKButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.EnableEditOKButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnableEditOKButton.Location = new System.Drawing.Point(38, 91);
            this.EnableEditOKButton.Name = "EnableEditOKButton";
            this.EnableEditOKButton.Size = new System.Drawing.Size(51, 33);
            this.EnableEditOKButton.TabIndex = 3;
            this.EnableEditOKButton.Text = "OK";
            this.EnableEditOKButton.UseVisualStyleBackColor = false;
            this.EnableEditOKButton.Click += new System.EventHandler(this.EnableEditOKButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Enter Password:";
            // 
            // EditPasswordTextBox
            // 
            this.EditPasswordTextBox.Location = new System.Drawing.Point(27, 53);
            this.EditPasswordTextBox.Name = "EditPasswordTextBox";
            this.EditPasswordTextBox.Size = new System.Drawing.Size(212, 20);
            this.EditPasswordTextBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(55, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Enable Editing Logon";
            // 
            // initalizePanel
            // 
            this.initalizePanel.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.initalizePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.initalizePanel.Controls.Add(this.label11);
            this.initalizePanel.Controls.Add(this.label10);
            this.initalizePanel.Controls.Add(this.label9);
            this.initalizePanel.Controls.Add(this.label8);
            this.initalizePanel.Controls.Add(this.exitAppButton);
            this.initalizePanel.Controls.Add(this.getAccessButton);
            this.initalizePanel.Controls.Add(this.restoreBackupButton);
            this.initalizePanel.Location = new System.Drawing.Point(801, 287);
            this.initalizePanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.initalizePanel.Name = "initalizePanel";
            this.initalizePanel.Size = new System.Drawing.Size(297, 161);
            this.initalizePanel.TabIndex = 15;
            this.initalizePanel.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(47, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Exit Program";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(47, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 30);
            this.label10.TabIndex = 9;
            this.label10.Text = "Load Access Database \r\nand associated files";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(47, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Load Backup Databases";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(105, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Initialize Program";
            // 
            // exitAppButton
            // 
            this.exitAppButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.exitAppButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitAppButton.Location = new System.Drawing.Point(199, 112);
            this.exitAppButton.Name = "exitAppButton";
            this.exitAppButton.Size = new System.Drawing.Size(51, 24);
            this.exitAppButton.TabIndex = 6;
            this.exitAppButton.Text = "Exit";
            this.exitAppButton.UseVisualStyleBackColor = false;
            this.exitAppButton.Click += new System.EventHandler(this.exitAppButton_Click);
            // 
            // getAccessButton
            // 
            this.getAccessButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.getAccessButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getAccessButton.Location = new System.Drawing.Point(199, 76);
            this.getAccessButton.Name = "getAccessButton";
            this.getAccessButton.Size = new System.Drawing.Size(51, 24);
            this.getAccessButton.TabIndex = 5;
            this.getAccessButton.Text = "Go";
            this.getAccessButton.UseVisualStyleBackColor = false;
            this.getAccessButton.Click += new System.EventHandler(this.getAccessButton_Click);
            // 
            // restoreBackupButton
            // 
            this.restoreBackupButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.restoreBackupButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restoreBackupButton.Location = new System.Drawing.Point(199, 39);
            this.restoreBackupButton.Name = "restoreBackupButton";
            this.restoreBackupButton.Size = new System.Drawing.Size(51, 24);
            this.restoreBackupButton.TabIndex = 4;
            this.restoreBackupButton.Text = "Go";
            this.restoreBackupButton.UseVisualStyleBackColor = false;
            this.restoreBackupButton.Click += new System.EventHandler(this.restoreBackupButton_Click);
            // 
            // FindReplacePanel
            // 
            this.FindReplacePanel.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.FindReplacePanel.Controls.Add(this.DeleteFindCheckBox);
            this.FindReplacePanel.Controls.Add(this.RecordsFoundLabel);
            this.FindReplacePanel.Controls.Add(this.FindCancelButton);
            this.FindReplacePanel.Controls.Add(this.FindAgainButton);
            this.FindReplacePanel.Controls.Add(this.FindDataGridView);
            this.FindReplacePanel.Controls.Add(this.SelectAllFindCheckBox);
            this.FindReplacePanel.Controls.Add(this.CancelFindButton);
            this.FindReplacePanel.Controls.Add(this.FindButton);
            this.FindReplacePanel.Controls.Add(this.FindCheckedListBox);
            this.FindReplacePanel.Controls.Add(this.label15);
            this.FindReplacePanel.Controls.Add(this.label14);
            this.FindReplacePanel.Controls.Add(this.ReplaceTextBox);
            this.FindReplacePanel.Controls.Add(this.label13);
            this.FindReplacePanel.Controls.Add(this.FindTextBox);
            this.FindReplacePanel.Controls.Add(this.label12);
            this.FindReplacePanel.Location = new System.Drawing.Point(500, 102);
            this.FindReplacePanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FindReplacePanel.Name = "FindReplacePanel";
            this.FindReplacePanel.Size = new System.Drawing.Size(486, 528);
            this.FindReplacePanel.TabIndex = 16;
            this.FindReplacePanel.Visible = false;
            // 
            // DeleteFindCheckBox
            // 
            this.DeleteFindCheckBox.AutoSize = true;
            this.DeleteFindCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteFindCheckBox.Location = new System.Drawing.Point(305, 71);
            this.DeleteFindCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeleteFindCheckBox.Name = "DeleteFindCheckBox";
            this.DeleteFindCheckBox.Size = new System.Drawing.Size(97, 19);
            this.DeleteFindCheckBox.TabIndex = 14;
            this.DeleteFindCheckBox.Text = "Delete Above";
            this.DeleteFindCheckBox.UseVisualStyleBackColor = true;
            // 
            // RecordsFoundLabel
            // 
            this.RecordsFoundLabel.AutoSize = true;
            this.RecordsFoundLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordsFoundLabel.Location = new System.Drawing.Point(16, 248);
            this.RecordsFoundLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RecordsFoundLabel.Name = "RecordsFoundLabel";
            this.RecordsFoundLabel.Size = new System.Drawing.Size(0, 15);
            this.RecordsFoundLabel.TabIndex = 13;
            this.RecordsFoundLabel.Visible = false;
            // 
            // FindCancelButton
            // 
            this.FindCancelButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.FindCancelButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindCancelButton.Location = new System.Drawing.Point(262, 488);
            this.FindCancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FindCancelButton.Name = "FindCancelButton";
            this.FindCancelButton.Size = new System.Drawing.Size(98, 25);
            this.FindCancelButton.TabIndex = 12;
            this.FindCancelButton.Text = "Cancel";
            this.FindCancelButton.UseVisualStyleBackColor = false;
            this.FindCancelButton.Click += new System.EventHandler(this.FindCancelButton_Click);
            // 
            // FindAgainButton
            // 
            this.FindAgainButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.FindAgainButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindAgainButton.Location = new System.Drawing.Point(134, 488);
            this.FindAgainButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FindAgainButton.Name = "FindAgainButton";
            this.FindAgainButton.Size = new System.Drawing.Size(98, 25);
            this.FindAgainButton.TabIndex = 11;
            this.FindAgainButton.Text = "Find Again";
            this.FindAgainButton.UseVisualStyleBackColor = false;
            this.FindAgainButton.Click += new System.EventHandler(this.FindAgainButton_Click);
            // 
            // FindDataGridView
            // 
            this.FindDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FindDataGridView.Location = new System.Drawing.Point(13, 266);
            this.FindDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FindDataGridView.Name = "FindDataGridView";
            this.FindDataGridView.RowTemplate.Height = 28;
            this.FindDataGridView.Size = new System.Drawing.Size(460, 207);
            this.FindDataGridView.TabIndex = 10;
            this.FindDataGridView.Visible = false;
            this.FindDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FindDataGridView_CellDoubleClick);
            // 
            // SelectAllFindCheckBox
            // 
            this.SelectAllFindCheckBox.AutoSize = true;
            this.SelectAllFindCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectAllFindCheckBox.Location = new System.Drawing.Point(245, 114);
            this.SelectAllFindCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SelectAllFindCheckBox.Name = "SelectAllFindCheckBox";
            this.SelectAllFindCheckBox.Size = new System.Drawing.Size(75, 19);
            this.SelectAllFindCheckBox.TabIndex = 9;
            this.SelectAllFindCheckBox.Text = "Select All";
            this.SelectAllFindCheckBox.UseVisualStyleBackColor = true;
            this.SelectAllFindCheckBox.CheckedChanged += new System.EventHandler(this.SelectAllFindCheckBox_CheckedChanged);
            // 
            // CancelFindButton
            // 
            this.CancelFindButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CancelFindButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelFindButton.Location = new System.Drawing.Point(255, 265);
            this.CancelFindButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CancelFindButton.Name = "CancelFindButton";
            this.CancelFindButton.Size = new System.Drawing.Size(81, 25);
            this.CancelFindButton.TabIndex = 8;
            this.CancelFindButton.Text = "Cancel";
            this.CancelFindButton.UseVisualStyleBackColor = false;
            this.CancelFindButton.Click += new System.EventHandler(this.CancelFindButton_Click);
            // 
            // FindButton
            // 
            this.FindButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.FindButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindButton.Location = new System.Drawing.Point(149, 265);
            this.FindButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(59, 25);
            this.FindButton.TabIndex = 7;
            this.FindButton.Text = "Find";
            this.FindButton.UseVisualStyleBackColor = false;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // FindCheckedListBox
            // 
            this.FindCheckedListBox.FormattingEnabled = true;
            this.FindCheckedListBox.Items.AddRange(new object[] {
            "SAP Description",
            "Description",
            "Detail Description",
            "PL Description",
            "PL Detail Description",
            "Notes",
            "Comments"});
            this.FindCheckedListBox.Location = new System.Drawing.Point(165, 141);
            this.FindCheckedListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FindCheckedListBox.Name = "FindCheckedListBox";
            this.FindCheckedListBox.Size = new System.Drawing.Size(151, 94);
            this.FindCheckedListBox.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(166, 113);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 16);
            this.label15.TabIndex = 5;
            this.label15.Text = "Look In:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(97, 71);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(207, 15);
            this.label14.TabIndex = 4;
            this.label14.Text = "Replace (leave blank for simple find)";
            // 
            // ReplaceTextBox
            // 
            this.ReplaceTextBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReplaceTextBox.Location = new System.Drawing.Point(99, 89);
            this.ReplaceTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReplaceTextBox.Name = "ReplaceTextBox";
            this.ReplaceTextBox.Size = new System.Drawing.Size(299, 21);
            this.ReplaceTextBox.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(97, 34);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 15);
            this.label13.TabIndex = 2;
            this.label13.Text = "Find";
            // 
            // FindTextBox
            // 
            this.FindTextBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindTextBox.Location = new System.Drawing.Point(99, 49);
            this.FindTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FindTextBox.Name = "FindTextBox";
            this.FindTextBox.Size = new System.Drawing.Size(299, 21);
            this.FindTextBox.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(191, 15);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Find / Replace";
            // 
            // MainPartsListDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(1927, 851);
            this.Controls.Add(this.FindReplacePanel);
            this.Controls.Add(this.initalizePanel);
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
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainPartsListDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Entry";
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
            this.initalizePanel.ResumeLayout(false);
            this.initalizePanel.PerformLayout();
            this.FindReplacePanel.ResumeLayout(false);
            this.FindReplacePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FindDataGridView)).EndInit();
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
        private Panel initalizePanel;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Button exitAppButton;
        private Button getAccessButton;
        private Button restoreBackupButton;
        private ToolStripMenuItem findReplaceToolStripMenuItem;
        private Panel FindReplacePanel;
        private CheckBox SelectAllFindCheckBox;
        private Button CancelFindButton;
        private Button FindButton;
        private CheckedListBox FindCheckedListBox;
        private Label label15;
        private Label label14;
        private TextBox ReplaceTextBox;
        private Label label13;
        private TextBox FindTextBox;
        private Label label12;
        private DataGridView FindDataGridView;
        private Label RecordsFoundLabel;
        private Button FindCancelButton;
        private Button FindAgainButton;
        private CheckBox DeleteFindCheckBox;
        private DataGridViewTextBoxColumn sAPIdDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn instrumentDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn categoryDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn subCategoryDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn DBMembership;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;

    }
}

