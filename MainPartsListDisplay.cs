using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;


namespace TecanPartListManager
{
    public partial class MainPartsListDisplay : Form
    {

        int lastSelected = 0;
        Boolean EditEnabled = false;
        Boolean searchPreformed = true;
        Boolean instrumentChanged = false;
        Boolean categoryChanged = false;
        Boolean subCategoryChanged = false;
        PartsListDetailDisplay DetailsForm = null;
        SqlCeConnection TecanDatabase = null;

        public MainPartsListDisplay()
        {
            InitializeComponent();
        }

        public void partsListBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.partsListBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tecanPartsListDataSet);

        }

        public void MainPartsListDisplay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tecanPartsListDataSet.SalesType' table. You can move, or remove it, as needed.
            this.salesTypeTableAdapter.Fill(this.tecanPartsListDataSet.SalesType);
            // TODO: This line of code loads data into the 'tecanPartsListDataSet.DBMembership' table. You can move, or remove it, as needed.
            this.dBMembershipTableAdapter.Fill(this.tecanPartsListDataSet.DBMembership);
            // TODO: This line of code loads data into the 'tecanPartsListDataSet.SSPCategory' table. You can move, or remove it, as needed.
            this.partsListDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // TODO: This line of code loads data into the 'tecanPart   sListDataSet.SubCategory' table. You can move, or remove it, as needed.
            this.sSPCategoryTableAdapter.Fill(this.tecanPartsListDataSet.SSPCategory);
            this.subCategoryTableAdapter.Fill(this.tecanPartsListDataSet.SubCategory);
            // TODO: This line of code loads data into the 'tecanPartsListDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.tecanPartsListDataSet.Category);
            // TODO: This line of code loads data into the 'tecanPartsListDataSet.Instrument' table. You can move, or remove it, as needed.
            this.instrumentTableAdapter.Fill(this.tecanPartsListDataSet.Instrument);
            // TODO: This line of code loads data into the 'tecanPartsListDataSet.PartsList' table. You can move, or remove it, as needed.
            this.partsListTableAdapter.Fill(this.tecanPartsListDataSet.PartsList);

            if (partsListBindingSource.Count == 0)
            {
                String sourcePath = @"c:\TecanFiles";
                String sourcePartsFile = System.IO.Path.Combine(sourcePath, "TecanPartsList.sdf");
                if (File.Exists(sourcePartsFile))
                {
                    initalizePanel.Location = new Point(
                    this.ClientSize.Width / 2 - initalizePanel.Size.Width / 2,
                    this.ClientSize.Height / 2 - initalizePanel.Size.Height / 2);
                    initalizePanel.Anchor = AnchorStyles.None;
                    initalizePanel.Visible = true;
                }
                else
                {
                    if (MessageBox.Show("The Tecan Partlist Manager must be intilized!\r\n\r\nDo you want to load the database now?", "Initial Installation", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        this.Close();
                    }
                    else
                    {
                        // this.WindowState = FormWindowState.Minimized;
                        ImportAccessDatabaseForm ImportForm = new ImportAccessDatabaseForm();
                        ImportForm.SetForm1Instance(this);
                        ImportForm.Show();
                    }
                }
            }

            loadFilterComboBoxes();
            int newGridHeight;
            newGridHeight = Screen.PrimaryScreen.Bounds.Height - (this.menuStrip1.Height + this.partsListBindingNavigator.Height);
            this.partsListDataGridView.Height = newGridHeight - 60;
            this.partsListBindingSource.Position = lastSelected;
            this.partsListDataGridView.Enabled = false;
            multiplePartDataChangeToolStripMenuItem.Enabled = false;
            databaseToolsToolStripMenuItem.Enabled = false;
            publishDatabasesToolStripMenuItem.Enabled = false;
            EditLogonPanel.Location = new Point(
            this.ClientSize.Width / 2 - EditLogonPanel.Size.Width / 2,
            this.ClientSize.Height / 2 - EditLogonPanel.Size.Height / 2);
            EditLogonPanel.Anchor = AnchorStyles.None;
            EditLogonPanel.Visible = true;
            EditPasswordTextBox.Focus();
        }


        public void PartDetailReturn()
        {
            //            this.partsListTableAdapter.Fill(this.tecanPartsListDataSet.PartsList);
            SelectAllToolStripButton.Text = "Select All";
            searchPreformed = false;
            doSearch();

            int newGridHeight;
            newGridHeight = Screen.PrimaryScreen.Bounds.Height - (this.menuStrip1.Height + this.partsListBindingNavigator.Height);
            this.partsListDataGridView.Height = newGridHeight - 60;
            this.partsListBindingSource.Position = lastSelected;
            this.partsListDataGridView.FirstDisplayedScrollingRowIndex = lastSelected;
        }

        // After adding or deleting items in a Lookup table rebuild the list from the updated table
        // May not be necessary as lists may updtae automatically from binding sources
        public void associatedTableReturn(String currentTable)
        {
            switch (currentTable)
            {
                case "Instrument":
                    this.instrumentTableAdapter.Fill(this.tecanPartsListDataSet.Instrument);

                    // InstrumentListComboBox
                    InstrumentListComboBox.DataSource = this.InstrumentBindingSource;
                    InstrumentListComboBox.DisplayMember = "InstrumentName";
                    InstrumentListComboBox.ValueMember = "InstrumentID";

                    break;

                case "Category":
                    this.categoryTableAdapter.Fill(this.tecanPartsListDataSet.Category);

                    // CategoryListComboBox
                    CategoryListComboBox.DataSource = this.CategoryBindingSource;
                    CategoryListComboBox.DisplayMember = "CategoryName";
                    CategoryListComboBox.ValueMember = "CategoryID";

                    break;

                case "SubCategory":
                    this.subCategoryTableAdapter.Fill(this.tecanPartsListDataSet.SubCategory);

                    // SubCategoryListComboBox
                    SubCategoryListComboBox.DataSource = this.SubCategoryBindingSource;
                    SubCategoryListComboBox.DisplayMember = "SubCategoryName";
                    SubCategoryListComboBox.ValueMember = "SubCategoryID";

                    break;


                case "DBMembership":
                    this.dBMembershipTableAdapter.Fill(this.tecanPartsListDataSet.DBMembership);

                    // DBMembershipListComboBox
                    DBMembershipListComboBox.DataSource = this.dbMembershipBindingSource;
                    DBMembershipListComboBox.DisplayMember = "DBName";
                    DBMembershipListComboBox.ValueMember = "DBID";

                    break;

                case "SalesType":
                    this.salesTypeTableAdapter.Fill(this.tecanPartsListDataSet.SalesType);

                    // DBMembershipListComboBox
                    DBMembershipListComboBox.DataSource = this.SalesTypeBindingSource;
                    DBMembershipListComboBox.DisplayMember = "SalesTypeName";
                    DBMembershipListComboBox.ValueMember = "SalesTypeID";
                    break;

            }
            PartDetailReturn();
        }

        public void associationTableError(String currentTable, short selectedValue)
        {
            loadFilterComboBoxes();
            PartNumberSearchTextBox.Text = "";
            DescriptionSearchTextBox.Text = "";

            switch (currentTable)
            {
                case "Instrument":
                    InstrumentListComboBox.SelectedValue = selectedValue;
                    break;

                case "Category":
                    CategoryListComboBox.SelectedValue = selectedValue;
                    break;

                case "SubCategory":
                    SubCategoryListComboBox.SelectedValue = selectedValue;
                    break;

                //case "SSPCategory":
                //    SSPCategoryListComboBox.SelectedValue = selectedValue;
                //    break;

                case "DBMembership":
                    DBMembershipListComboBox.SelectedValue = selectedValue;
                    break;

                //case "SalesType":
                //    lookupTableID = "SalesType";
                //    break;

            }

            searchPreformed = false;
            doSearch();

        }

        // After the lookup table item has been selected
        // Change to the new value in all of the parts selected in the gridview
        public void multiPartChangeFormReturn(String currentTable, Int32 newValue)
        {
            String lookupTableID = "";

            switch (currentTable)
            {
                case "Instrument":
                    lookupTableID = "Instrument";
                    break;

                case "Category":
                    lookupTableID = "Category";
                    break;

                case "SubCategory":
                    lookupTableID = "SubCategory";
                    break;

                case "SSPCategory":
                    lookupTableID = "SSPCategory";
                    break;

                case "DBMembership":
                    lookupTableID = "DBMembership";
                    break;

                case "SalesType":
                    lookupTableID = "SalesType";
                    break;

            }

            SqlCeConnection TecanDatabase = null;

            TecanDatabase = new SqlCeConnection();
            String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanDatabase.Open();

            SqlCeCommand cmd = TecanDatabase.CreateCommand();

            // Get the number of rows selected
            Int32 selectedsRowCount = this.partsListDataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
            int partRowIndex = 0;
            String selectedSAPID;

            for (int s = 0; s < selectedsRowCount; s++)
            {
                // Get the SAPID for the current selected row
                partRowIndex = partsListDataGridView.SelectedRows[s].Index;
                DataGridViewRow srow = this.partsListDataGridView.Rows[partRowIndex];
                selectedSAPID = srow.Cells[0].Value.ToString();

                // Set the new lookup table value
                cmd.CommandText = "UPDATE PartsList SET " + lookupTableID + " = '" + newValue + "' WHERE SAPId = '" + selectedSAPID + "'";
                cmd.ExecuteNonQuery();

            }
            TecanDatabase.Close();
            PartDetailReturn();
        }

        // Initial Lookup Table lists, used for filtering displayed Parts
        // Lists are all loaded from lookup table items with all items
        // Look at updateCategoryComboBox() and updateSubCategoryComboBox() if only avaible items are required
        private void loadFilterComboBoxes()
        {

            // InstrumentListComboBox
            InstrumentListComboBox.DataSource = this.InstrumentBindingSource;
            InstrumentListComboBox.DisplayMember = "InstrumentName";
            InstrumentListComboBox.ValueMember = "InstrumentID";
            if (this.InstrumentBindingSource.Count > 0) InstrumentListComboBox.SelectedIndex = 0;

            // CategoryListComboBox
            CategoryListComboBox.DataSource = this.CategoryBindingSource;
            CategoryListComboBox.DisplayMember = "CategoryName";
            CategoryListComboBox.ValueMember = "CategoryID";
            if (this.CategoryBindingSource.Count > 0) CategoryListComboBox.SelectedIndex = 0;

            SubCategoryListComboBox.DataSource = this.SubCategoryBindingSource;
            SubCategoryListComboBox.DisplayMember = "SubCategoryName";
            SubCategoryListComboBox.ValueMember = "SubCategoryID";
            if (this.SubCategoryBindingSource.Count > 0) SubCategoryListComboBox.SelectedIndex = 0;

            DBMembershipListComboBox.DataSource = this.dbMembershipBindingSource;
            DBMembershipListComboBox.DisplayMember = "DBName";
            DBMembershipListComboBox.ValueMember = "DBID";
            if (this.dbMembershipBindingSource.Count > 0) DBMembershipListComboBox.SelectedIndex = 0;

            //// Sales Type
            SalesTypeComboBox.DataSource = this.SalesTypeBindingSource;
            SalesTypeComboBox.DisplayMember = "SalesTypeName";
            SalesTypeComboBox.ValueMember = "SalesTypeID";
            if (this.SalesTypeBindingSource.Count > 0) SalesTypeComboBox.SelectedIndex = 0;

        }

        // Called after doSearch() if Category or SubCategory has changed
        // Only include Instruments that are avaiable for selected Dataset
        //private void updateInstrumentComboBox()
        //{
        //    // Instruments
        //    categoryChanged = false;
        //    subCategoryChanged = false;
        //    String CurrentInstrumentSearchValue = InstrumentListComboBox.SelectedValue.ToString();
        //    short CategorySearchValue = (short)Convert.ToInt16(CategoryListComboBox.SelectedValue);
        //    short SubCategorySearchValue = (short)Convert.ToInt16(SubCategoryListComboBox.SelectedValue);

        //    if (CategorySearchValue != 0 || SubCategorySearchValue != 0)
        //    {
        //        // Set up new Available Category list
        //        ArrayList theAvailableInstruments = new ArrayList();
        //        theAvailableInstruments.Add(new LookupTableDefinitions.AvailableInstruments("Any", "0"));

        //        foreach (DataRow dr in this.tecanPartsListDataSet.Tables["Instrument"].Rows)
        //        {
        //            foreach (DataRow pr in this.tecanPartsListDataSet.Tables["PartsList"].Rows)
        //            {
        //                if (pr["Instrument"].ToString() == dr["InstrumentID"].ToString())
        //                {
        //                    theAvailableInstruments.Add(new LookupTableDefinitions.AvailableInstruments(dr["InstrumentName"].ToString(), dr["InstrumentID"].ToString()));
        //                    break;
        //                }
        //            }
        //        }
        //        // InstrumentListComboBox
        //        InstrumentListComboBox.DataSource = theAvailableInstruments;
        //        InstrumentListComboBox.DisplayMember = "Name";
        //        InstrumentListComboBox.ValueMember = "ID";
        //    }
        //    else
        //    {
        //        // InstrumentListComboBox
        //        InstrumentListComboBox.DataSource = this.InstrumentBindingSource;
        //        InstrumentListComboBox.DisplayMember = "InstrumentName";
        //        InstrumentListComboBox.ValueMember = "InstrumentID";
        //    }

        //    // Set the perviously selected item
        //    if (CurrentInstrumentSearchValue != "0")
        //    {
        //        searchPreformed = true;
        //        int currentItem = 0;

        //        try
        //        {
        //            foreach (LookupTableDefinitions.AvailableInstruments instruments in InstrumentListComboBox.Items)
        //            {
        //                if (instruments.ID == CurrentInstrumentSearchValue)
        //                {
        //                    InstrumentListComboBox.SelectedIndex = currentItem;
        //                }
        //                currentItem++;
        //            }
        //        }
        //        catch (Exception)
        //        { }

        //    }
        //}

        // Called after doSearch() if Instrument has changed
        // Only include Categories that are avaiable for selected Instrument
        private void updateCategoryComboBox()
        {
            // Categories
            String CurrentCategorySearchValue = CategoryListComboBox.SelectedValue.ToString();
            instrumentChanged = false;
            short InstrumentSearchValue = (short)Convert.ToInt16(InstrumentListComboBox.SelectedValue);
            short SubCategorySearchValue = (short)Convert.ToInt16(SubCategoryListComboBox.SelectedValue);

            if (InstrumentSearchValue != 0 || SubCategorySearchValue != 0)
            {
                // Set up new Available Category list
                ArrayList theAvailableCategories = new ArrayList();
                theAvailableCategories.Add(new LookupTableDefinitions.AvailableCategories("Any", "0"));

                foreach (DataRow dr in this.tecanPartsListDataSet.Tables["Category"].Rows)
                {
                    foreach (DataRow pr in this.tecanPartsListDataSet.Tables["PartsList"].Rows)
                    {
                        if (pr["Category"].ToString() == dr["CategoryID"].ToString())
                        {
                            theAvailableCategories.Add(new LookupTableDefinitions.AvailableCategories(dr["CategoryName"].ToString(), dr["CategoryID"].ToString()));
                            break;
                        }
                    }
                }
                // CategoryListComboBox
                CategoryListComboBox.DataSource = theAvailableCategories;
                CategoryListComboBox.DisplayMember = "Name";
                CategoryListComboBox.ValueMember = "ID";
            }
            else
            {
                // CategoryListComboBox
                CategoryListComboBox.DataSource = this.CategoryBindingSource;
                CategoryListComboBox.DisplayMember = "CategoryName";
                CategoryListComboBox.ValueMember = "CategoryID";
            }

            // Set the perviously selected item
            if (CurrentCategorySearchValue != "0")
            {
                searchPreformed = true;
                int currentItem = 0;

                try
                {
                    foreach (LookupTableDefinitions.AvailableCategories category in CategoryListComboBox.Items)
                    {
                        if (category.ID == CurrentCategorySearchValue)
                        {
                            CategoryListComboBox.SelectedIndex = currentItem;
                        }
                        currentItem++;
                    }
                }
                catch (Exception)
                { }
            }
        }

        // Called after doSearch() if Category has changed
        // Only include Sub-Categories that are avaiable for selected Category
        private void updateSubCategoryComboBox()
        {
            // SubCategories
            String CurrentSubCategorySearchValue = SubCategoryListComboBox.SelectedValue.ToString();
            categoryChanged = false;
            short InstrumentSearchValue = (short)Convert.ToInt16(InstrumentListComboBox.SelectedValue);
            short CategorySearchValue = (short)Convert.ToInt16(CategoryListComboBox.SelectedValue);

            if (InstrumentSearchValue != 0 || CategorySearchValue != 0)
            {
                // Set up new Available SubCategory list
                ArrayList theAvailableSubCategories = new ArrayList();
                theAvailableSubCategories.Add(new LookupTableDefinitions.AvailableSubCategories("Any", "0"));

                foreach (DataRow dr in this.tecanPartsListDataSet.Tables["SubCategory"].Rows)
                {
                    foreach (DataRow pr in this.tecanPartsListDataSet.Tables["PartsList"].Rows)
                    {
                        if (pr["SubCategory"].ToString() == dr["SubCategoryID"].ToString())
                        {
                            theAvailableSubCategories.Add(new LookupTableDefinitions.AvailableSubCategories(dr["SubCategoryName"].ToString(), dr["SubCategoryID"].ToString()));
                            break;
                        }
                    }
                }
                // SubCategoryListComboBox
                SubCategoryListComboBox.DataSource = theAvailableSubCategories;
                SubCategoryListComboBox.DisplayMember = "Name";
                SubCategoryListComboBox.ValueMember = "ID";
            }
            else
            {
                // SubCategoryListComboBox
                SubCategoryListComboBox.DataSource = this.SubCategoryBindingSource;
                SubCategoryListComboBox.DisplayMember = "SubCategoryName";
                SubCategoryListComboBox.ValueMember = "SubCategoryID";
            }

            // Set the perviously selected item
            if (CurrentSubCategorySearchValue != "0")
            {
                searchPreformed = true;
                int currentItem = 0;
                try
                {
                    foreach (LookupTableDefinitions.AvailableSubCategories category in SubCategoryListComboBox.Items)
                    {
                        if (category.ID == CurrentSubCategorySearchValue)
                        {
                            SubCategoryListComboBox.SelectedIndex = currentItem;
                        }
                        currentItem++;
                    }
                }
                catch (Exception)
                { }
            }
        }

        private void partsListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            lastSelected = this.partsListBindingSource.Position;
            System.Data.DataRowView SelectedRowView;
            TecanPartsListDataSet.PartsListRow SelectedRow;

            SelectedRowView = (System.Data.DataRowView)partsListBindingSource.Current;
            SelectedRow = (TecanPartsListDataSet.PartsListRow)SelectedRowView.Row;

            if (DetailsForm == null || DetailsForm.IsDisposed)
            {
                DetailsForm = new PartsListDetailDisplay();
            }
            try
            {
                DetailsForm.SetForm1Instance(this);
                DetailsForm.LoadParts(SelectedRow.SAPId);
                DetailsForm.TopMost = true;
                DetailsForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading Deatils Form " + ex.Message);
            }
        }

        private void associationTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableMaintnance tablesForm = new tableMaintnance();
            tablesForm.SetMainFormInstance(this);
            tablesForm.Show();
        }

        internal void UpdateParts()
        {
            this.partsListTableAdapter.GetData();
            this.partsListBindingSource.ResetBindings(true);
        }

        private void importAccessDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportAccessDatabaseForm ImportForm = new ImportAccessDatabaseForm();
            ImportForm.SetForm1Instance(this);
            ImportForm.Show();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            AddSAPIDForm sapidFrom = new AddSAPIDForm();
            sapidFrom.SetForm1Instance(this);
            sapidFrom.Show();
        }

        public void newSAPIDReturn(String sapID)
        {
            if (DetailsForm == null || DetailsForm.IsDisposed)
            {
                DetailsForm = new PartsListDetailDisplay();
            }
            // PartsListDetailDisplay DetailsForm = new PartsListDetailDisplay();
            try
            {
                DetailsForm.SetForm1Instance(this);
                DetailsForm.LoadParts(sapID);
                DetailsForm.TopMost = true;
                DetailsForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void quoteDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PublishDatabasesForm PublishForm = new PublishDatabasesForm();
            PublishForm.SetMainFormInstance(this);
            PublishForm.Show();
            PublishForm.startCopyProcess("Quote");
        }

        private void customerPartslistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PublishDatabasesForm PublishForm = new PublishDatabasesForm();
            PublishForm.SetMainFormInstance(this);
            PublishForm.Show();
            PublishForm.startCopyProcess("Customer");
        }
        private void bothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PublishDatabasesForm PublishForm = new PublishDatabasesForm();
            PublishForm.SetMainFormInstance(this);
            PublishForm.Show();
            PublishForm.startCopyProcess("Both");
        }

        private void PartNumberSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            searchPreformed = false;
            doSearch();
        }

        private void PartNumberClearButton_Click(object sender, EventArgs e)
        {
            PartNumberSearchTextBox.Text = "";
            searchPreformed = false;
            doSearch();
        }

        private void DescriptionSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            searchPreformed = false;
            doSearch();
        }

        private void DescriptionClearButton_Click(object sender, EventArgs e)
        {
            DescriptionSearchTextBox.Text = "";
            searchPreformed = false;
            doSearch();
        }


        private void doSearch()
        {
            if (!searchPreformed)
            {
                searchPreformed = true;
                String PartSearchValue;
                String DescriptionSearchValue;

                short InstrumentSearchValue = (short)Convert.ToInt16(InstrumentListComboBox.SelectedValue);
                short CategorySearchValue = (short)Convert.ToInt16(CategoryListComboBox.SelectedValue);
                short SubCategorySearchValue = (short)Convert.ToInt16(SubCategoryListComboBox.SelectedValue);
                short SalesTypeSearchValue = (short)Convert.ToInt16(SalesTypeComboBox.SelectedValue);
                byte DBMembershipSearchValue = (byte)Convert.ToInt16(DBMembershipListComboBox.SelectedValue);

                // Set Text Search values
                if (PartNumberSearchTextBox.Text != "")
                {
                    PartSearchValue = PartNumberSearchTextBox + "%";
                }
                else
                {
                    PartSearchValue = "%%";
                }

                if (DescriptionSearchTextBox.Text != "")
                {
                    DescriptionSearchValue = "%" + DescriptionSearchTextBox.Text + "%";
                }
                else
                {
                    DescriptionSearchValue = "%%";
                }

                // Test Filter Values values
                // No Filters Set
                if ((InstrumentSearchValue == 0) && (CategorySearchValue == 0) && (SubCategorySearchValue == 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKE(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue);
                }
                // Instrument Only
                else if ((InstrumentSearchValue != 0) && (CategorySearchValue == 0) && (SubCategorySearchValue == 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKEANDInstrument(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, InstrumentSearchValue);
                }
                // Category Only
                else if ((InstrumentSearchValue == 0) && (CategorySearchValue != 0) && (SubCategorySearchValue == 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKEANDCategory(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, CategorySearchValue);
                }
                // Sub Category Only
                else if ((InstrumentSearchValue == 0) && (CategorySearchValue == 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKEANDSubCategory(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, SubCategorySearchValue);
                }
                // DBMembership Only
                else if ((InstrumentSearchValue == 0) && (CategorySearchValue == 0) && (SubCategorySearchValue == 0) && (DBMembershipSearchValue != 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKEANDDBMembership(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, DBMembershipSearchValue);
                }
                // Sales Type Only
                else if ((InstrumentSearchValue == 0) && (CategorySearchValue == 0) && (SubCategorySearchValue == 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue != 0))
                {
                    partsListTableAdapter.FillByLIKEANDSalesType(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, SalesTypeSearchValue);
                }
                // Instrunment Combinations
                // Instrument AND Category
                else if ((InstrumentSearchValue != 0) && (CategorySearchValue != 0) && (SubCategorySearchValue == 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKEANDInstrumentANDCategory(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, InstrumentSearchValue, CategorySearchValue);
                }
                // Instrument AND SubCategory
                else if ((InstrumentSearchValue != 0) && (CategorySearchValue == 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKEANDInstrumentANDSubCategory(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, InstrumentSearchValue, SubCategorySearchValue);
                }
                // Instrument AND DBMembership
                else if ((InstrumentSearchValue != 0) && (CategorySearchValue == 0) && (SubCategorySearchValue == 0) && (DBMembershipSearchValue != 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKEANDInstrumentANDDBMembership(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, InstrumentSearchValue, DBMembershipSearchValue);
                }
                // Instrument AND SalesType
                else if ((InstrumentSearchValue != 0) && (CategorySearchValue == 0) && (SubCategorySearchValue == 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue != 0))
                {
                    partsListTableAdapter.FillByLIKEANDInstrumentANDSalesType(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, InstrumentSearchValue, SalesTypeSearchValue);
                }
                // Instrument AND Category AND Sub Category
                else if ((InstrumentSearchValue != 0) && (CategorySearchValue != 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKEANDInstrumentANDCategoryANDSubCategory(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, InstrumentSearchValue, CategorySearchValue, SubCategorySearchValue);
                }
                // Instrument AND Category AND DBMembership
                else if ((InstrumentSearchValue != 0) && (CategorySearchValue != 0) && (SubCategorySearchValue == 0) && (DBMembershipSearchValue != 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKEANDInstrumentANDCategoryANDDBMembership(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, InstrumentSearchValue, CategorySearchValue, DBMembershipSearchValue);
                }
                // Instrument AND Category AND SalesType
                else if ((InstrumentSearchValue != 0) && (CategorySearchValue != 0) && (SubCategorySearchValue == 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue != 0))
                {
                    partsListTableAdapter.FillByLIKEANDInstrumentANDCategoryANDSalesType(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, InstrumentSearchValue, CategorySearchValue, SalesTypeSearchValue);
                }
                // Instrument AND Category AND SubCategory AND DBMembership
                else if ((InstrumentSearchValue != 0) && (CategorySearchValue != 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue != 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKEANDInstrumentANDCategoryANDSubCategoryANDDBMembership(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, InstrumentSearchValue, CategorySearchValue, SubCategorySearchValue, DBMembershipSearchValue);
                }
                // Instrument AND Category AND SubCategory AND SalesType
                else if ((InstrumentSearchValue != 0) && (CategorySearchValue != 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue != 0))
                {
                    partsListTableAdapter.FillByLIKEANDInstrumentANDCategoryANDSubCategoryANDSalesType(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, InstrumentSearchValue, CategorySearchValue, SubCategorySearchValue, SalesTypeSearchValue);
                }
                // Instrument AND Category AND SubCategory AND DBMembership AND SalesType
                else if ((InstrumentSearchValue != 0) && (CategorySearchValue != 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue != 0) && (SalesTypeSearchValue != 0))
                {
                    partsListTableAdapter.FillByLIKEANDInstrumentANDCategoryANDSubCategoryANDDBMembershipANDSalesType(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, InstrumentSearchValue, CategorySearchValue, SubCategorySearchValue, DBMembershipSearchValue, SalesTypeSearchValue);
                }
                // Instrument AND SubCategory AND DBMembership
                else if ((InstrumentSearchValue != 0) && (CategorySearchValue == 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue != 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKEANDInstrumentANDSubCategoryANDDBMembership(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, InstrumentSearchValue, SubCategorySearchValue, DBMembershipSearchValue);
                }
                // Instrument AND SubCategory AND SalesType
                else if ((InstrumentSearchValue != 0) && (CategorySearchValue == 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue != 0))
                {
                    partsListTableAdapter.FillByLIKEANDInstrumentANDSubCategoryANDSalesType(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, InstrumentSearchValue, SubCategorySearchValue, SalesTypeSearchValue);
                }
                // Instrument AND SubCategory AND DBMembership AND SalesType
                else if ((InstrumentSearchValue != 0) && (CategorySearchValue == 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue != 0) && (SalesTypeSearchValue != 0))
                {
                    partsListTableAdapter.FillByLIKEANDInstrumentANDSubCategoryANDDBMembershipANDSalesType(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, InstrumentSearchValue, SubCategorySearchValue, DBMembershipSearchValue, SalesTypeSearchValue);
                }
                // Instrument AND DBMemebrship AND SalesType
                else if ((InstrumentSearchValue != 0) && (CategorySearchValue == 0) && (SubCategorySearchValue == 0) && (DBMembershipSearchValue != 0) && (SalesTypeSearchValue != 0))
                {
                    partsListTableAdapter.FillByLIKEANDInstrumentANDDBMembershipANDSalesType(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, InstrumentSearchValue, DBMembershipSearchValue, SalesTypeSearchValue);
                }
                // Category Combinations
                // Category AND SubCategory
                else if ((InstrumentSearchValue == 0) && (CategorySearchValue != 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKEANDCategoryANDSubCategory(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, CategorySearchValue, SubCategorySearchValue);
                }
                // Category AND DBMembership
                else if ((InstrumentSearchValue == 0) && (CategorySearchValue != 0) && (SubCategorySearchValue == 0) && (DBMembershipSearchValue != 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKEANDCategoryANDDBMembership(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, CategorySearchValue, DBMembershipSearchValue);
                }
                // Category AND Sales Type
                else if ((InstrumentSearchValue == 0) && (CategorySearchValue != 0) && (SubCategorySearchValue == 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue != 0))
                {
                    partsListTableAdapter.FillByLIKEANDCategoryANDSalesType(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, CategorySearchValue, SalesTypeSearchValue);
                }
                // Category AND SubCategory AND DBMembership
                else if ((InstrumentSearchValue == 0) && (CategorySearchValue != 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue != 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKEANDCategoryANDSubCategoryANDDBMembership(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, CategorySearchValue, SubCategorySearchValue, DBMembershipSearchValue);
                }
                // Category AND SubCategory AND Sales Type
                else if ((InstrumentSearchValue == 0) && (CategorySearchValue != 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue != 0))
                {
                    partsListTableAdapter.FillByLIKEANDCategoryANDSubCategoryANDSalesType(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, CategorySearchValue, SubCategorySearchValue, SalesTypeSearchValue);
                }
                // Category AND DBMembership AND Sales Type
                else if ((InstrumentSearchValue == 0) && (CategorySearchValue != 0) && (SubCategorySearchValue == 0) && (DBMembershipSearchValue != 0) && (SalesTypeSearchValue != 0))
                {
                    partsListTableAdapter.FillByLIKEANDCategoryANDDBMembershipANDSalesType(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, CategorySearchValue, DBMembershipSearchValue, SalesTypeSearchValue);
                }
                // Category AND SubCategory AND DBMembership AND Sales Type
                else if ((InstrumentSearchValue == 0) && (CategorySearchValue != 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue != 0) && (SalesTypeSearchValue != 0))
                {
                    partsListTableAdapter.FillByLIKEANDCategoryANDSubCategoryANDDBMembershipANDSalesType(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, CategorySearchValue, SubCategorySearchValue, DBMembershipSearchValue, SalesTypeSearchValue);
                }
                // SubCategory Combinations
                // SubCategory AND DBMembership
                else if ((InstrumentSearchValue == 0) && (CategorySearchValue == 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue != 0) && (SalesTypeSearchValue == 0))
                {
                    partsListTableAdapter.FillByLIKEANDSubCategoryANDDBMembership(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, SubCategorySearchValue, DBMembershipSearchValue);
                }
                // SubCategory AND Sales Type
                else if ((InstrumentSearchValue == 0) && (CategorySearchValue == 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue == 0) && (SalesTypeSearchValue != 0))
                {
                    partsListTableAdapter.FillByLIKEANDSubCategoryANDSalesType(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, SubCategorySearchValue, SalesTypeSearchValue);
                }
                // SubCategory AND DBMembership AND Sales Type
                else if ((InstrumentSearchValue == 0) && (CategorySearchValue == 0) && (SubCategorySearchValue != 0) && (DBMembershipSearchValue != 0) && (SalesTypeSearchValue != 0))
                {
                    partsListTableAdapter.FillByLIKEANDSubCategoryANDDBMembershipANDSalesType(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, SubCategorySearchValue, DBMembershipSearchValue, SalesTypeSearchValue);
                }
                // DBMembership Combinations
                // DBMembership AND Sales Type
                else if ((InstrumentSearchValue == 0) && (CategorySearchValue == 0) && (SubCategorySearchValue == 0) && (DBMembershipSearchValue != 0) && (SalesTypeSearchValue != 0))
                {
                    partsListTableAdapter.FillByLIKEANDDBMembershipANDSalesType(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue, DBMembershipSearchValue, SalesTypeSearchValue);
                }

                if (instrumentChanged)
                {
                    updateCategoryComboBox();
                    updateSubCategoryComboBox();
                }
                if (categoryChanged)
                {
                    // updateInstrumentComboBox();
                    updateSubCategoryComboBox();
                }
                //if (subCategoryChanged)
                //{
                //    updateInstrumentComboBox();
                //    updateCategoryComboBox();
                //}

            }
        }

        private void InstrumentListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryListComboBox.SelectedIndex != -1)
            {
                CategoryListComboBox.SelectedIndex = 0;
                SubCategoryListComboBox.SelectedIndex = 0;
                doSearch();
            }
        }

        private void CategoryListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SubCategoryListComboBox.SelectedIndex != 0 && SubCategoryListComboBox.SelectedIndex != -1) SubCategoryListComboBox.SelectedIndex = 0;
            doSearch();
        }

        private void SubCategoryListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            doSearch();
        }

        private void DBMembershipListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            doSearch();
        }

        private void SalesTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            doSearch();
        }

        private void InstrumentListComboBox_Click(object sender, EventArgs e)
        {
            searchPreformed = false;
            instrumentChanged = true;
        }

        private void CategoryListComboBox_Click(object sender, EventArgs e)
        {
            searchPreformed = false;
            categoryChanged = true;
        }

        private void SubCategoryListComboBox_Click(object sender, EventArgs e)
        {
            searchPreformed = false;
            subCategoryChanged = true;
        }

        private void DBMembershipListComboBox_Click(object sender, EventArgs e)
        {
            searchPreformed = false;
        }

        private void SalesTypeComboBox_Click(object sender, EventArgs e)
        {
            searchPreformed = false;
        }

        private void instrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiPartDataChangeForm ChangeForm = new MultiPartDataChangeForm();
            ChangeForm.SetFormInstance(this);
            ChangeForm.MultiPartDataChangeFormLoad("Instrument");
            ChangeForm.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiPartDataChangeForm ChangeForm = new MultiPartDataChangeForm();
            ChangeForm.SetFormInstance(this);
            ChangeForm.MultiPartDataChangeFormLoad("Category");
            ChangeForm.Show();
        }

        private void subCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiPartDataChangeForm ChangeForm = new MultiPartDataChangeForm();
            ChangeForm.SetFormInstance(this);
            ChangeForm.MultiPartDataChangeFormLoad("SubCategory");
            ChangeForm.Show();
        }

        private void sSPCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiPartDataChangeForm ChangeForm = new MultiPartDataChangeForm();
            ChangeForm.SetFormInstance(this);
            ChangeForm.MultiPartDataChangeFormLoad("SSPCategory");
            ChangeForm.Show();
        }

        private void databaseMembershipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiPartDataChangeForm ChangeForm = new MultiPartDataChangeForm();
            ChangeForm.SetFormInstance(this);
            ChangeForm.MultiPartDataChangeFormLoad("DBMembership");
            ChangeForm.Show();
        }

        private void salesTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiPartDataChangeForm ChangeForm = new MultiPartDataChangeForm();
            ChangeForm.SetFormInstance(this);
            ChangeForm.MultiPartDataChangeFormLoad("SalesType");
            ChangeForm.Show();
        }

        private void ClearFiltersButton_Click(object sender, EventArgs e)
        {
            loadFilterComboBoxes();
            searchPreformed = false;
            doSearch();
        }

        private void associationTablesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tableMaintnance tablesForm = new tableMaintnance();
            tablesForm.SetMainFormInstance(this);
            tablesForm.Show();
        }

        private void importAccessDatabaseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            ImportAccessDatabaseForm ImportForm = new ImportAccessDatabaseForm();
            ImportForm.SetForm1Instance(this);
            ImportForm.Show();
        }

        private void SelectAllToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectAllToolStripButton.Text == "Select All")
            {
                SelectAllToolStripButton.Text = "Clear Selection";
                partsListDataGridView.SelectAll();
            }
            else
            {
                SelectAllToolStripButton.Text = "Select All";
                partsListDataGridView.ClearSelection();
            }

        }

        // ZILR Price Changes
        private void zILR1400ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportExternalData ExternalDataForm = new ImportExternalData();
            ExternalDataForm.SetMainFormInstance(this);
            ExternalDataForm.LoadExternalData("ZILR Price");
            ExternalDataForm.Show();
        }

        // ZILR Discontinued Parts
        private void zILRDiscontinuedPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportExternalData ExternalDataForm = new ImportExternalData();
            ExternalDataForm.SetMainFormInstance(this);
            ExternalDataForm.LoadExternalData("ZILR Discontinued");
            ExternalDataForm.Show();
        }

        // Average Selling Price Report (ASP)
        private void zILR1401ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportExternalData ExternalDataForm = new ImportExternalData();
            ExternalDataForm.SetMainFormInstance(this);
            ExternalDataForm.LoadExternalData("ASP");
            ExternalDataForm.Show();
        }

        // Sales Text Report
        private void zILR1410ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportExternalData ExternalDataForm = new ImportExternalData();
            ExternalDataForm.SetMainFormInstance(this);
            ExternalDataForm.LoadExternalData("SalesText");
            ExternalDataForm.Show();
        }

        // MM60 Report
        private void mM60ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportExternalData ExternalDataForm = new ImportExternalData();
            ExternalDataForm.SetMainFormInstance(this);
            ExternalDataForm.LoadExternalData("MM60");
            ExternalDataForm.Show();
        }

        private void EnableEditOKButton_Click(object sender, EventArgs e)
        {
            if (EditPasswordTextBox.Text == "Rosebud")
            {
                EditEnabled = true;
                multiplePartDataChangeToolStripMenuItem.Enabled = true;
                databaseToolsToolStripMenuItem.Enabled = true;
                publishDatabasesToolStripMenuItem.Enabled = true;
            }
            else
            {
                EditEnabled = false;
                multiplePartDataChangeToolStripMenuItem.Enabled = false;
                databaseToolsToolStripMenuItem.Enabled = false;
                publishDatabasesToolStripMenuItem.Enabled = false;
            }
            EditLogonPanel.Visible = false;
            this.partsListDataGridView.Enabled = true;
        }

        private void NoEditButton_Click(object sender, EventArgs e)
        {
            EditLogonPanel.Visible = false;
            multiplePartDataChangeToolStripMenuItem.Enabled = false;
            databaseToolsToolStripMenuItem.Enabled = false;
            publishDatabasesToolStripMenuItem.Enabled = false;
            this.partsListDataGridView.Enabled = true;
        }

        private void editLogonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditLogonPanel.Visible = true;
        }

        public Boolean getEditStatus()
        {
            return EditEnabled;
        }

        private void applicationDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationDocsForm AppDocsForm = new ApplicationDocsForm();
            AppDocsForm.Show();
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sourcePath = @"c:\TecanFiles";
            String sourcePartsFile = System.IO.Path.Combine(sourcePath, "TecanPartsList.sdf");
            if (File.Exists(sourcePartsFile))
            {
                String sourceSuppFile = System.IO.Path.Combine(sourcePath, "TecanSuppDocs.sdf");
                String sourceAppDocFile = System.IO.Path.Combine(sourcePath, "TecanAppDocs.sdf");

                String targetPartsFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "TecanPartsList.sdf");
                String targetSuppFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "TecanSuppDocs.sdf");
                String targetAppDocFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "TecanAppDocs.sdf");

                System.IO.File.Copy(sourcePartsFile, targetPartsFile, true);
                System.IO.File.Copy(sourceSuppFile, targetSuppFile, true);
                System.IO.File.Copy(sourceAppDocFile, targetAppDocFile, true);
                MessageBox.Show("Backup Database Restored!");
            }
            else
            {
                MessageBox.Show("You do not currently have a Backup Database!");
                return;
            }
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sourcePartsFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "TecanPartsList.sdf");
            String sourceSuppFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "TecanSuppDocs.sdf");
            String sourceAppDocFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "TecanAppDocs.sdf");
            String targetPath = @"c:\TecanFiles";
            System.IO.Directory.CreateDirectory(targetPath);
            String targetPartsFile;
            String targetSuppFile;
            String targetAppDocFile;

            targetPartsFile = System.IO.Path.Combine(targetPath, "TecanPartsList.sdf");
            System.IO.File.Copy(sourcePartsFile, targetPartsFile, true);
            targetSuppFile = System.IO.Path.Combine(targetPath, "TecanSuppDocs.sdf");
            System.IO.File.Copy(sourceSuppFile, targetSuppFile, true);
            targetAppDocFile = System.IO.Path.Combine(targetPath, "TecanAppDocs.sdf");
            System.IO.File.Copy(sourceAppDocFile, targetAppDocFile, true);
            MessageBox.Show("Backup Database saved to " + targetPartsFile + "!");
        }

        private void restoreBackupButton_Click(object sender, EventArgs e)
        {
            initalizePanel.Visible = false;
            restoreToolStripMenuItem_Click(sender, e);
            MainPartsListDisplay_Load(sender, e);
        }

        private void getAccessButton_Click(object sender, EventArgs e)
        {
            initalizePanel.Visible = false;
            this.WindowState = FormWindowState.Minimized;
            ImportAccessDatabaseForm ImportForm = new ImportAccessDatabaseForm();
            ImportForm.SetForm1Instance(this);
            ImportForm.Show();
        }

        private void exitAppButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void findReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindReplacePanel.Location = new Point(
            this.ClientSize.Width / 2 - FindReplacePanel.Size.Width / 2,
            this.ClientSize.Height / 2 - FindReplacePanel.Size.Height / 2);
            FindReplacePanel.Anchor = AnchorStyles.None;
            FindReplacePanel.Height = 325;
            FindReplacePanel.Visible = true;
            SelectAllFindCheckBox.Checked = false;
            clearFindCheckListBox();
            FindTextBox.Focus();
        }

        private void clearFindCheckListBox()
        {
            for (int i = 0; i < FindCheckedListBox.Items.Count; i++)
            {
                FindCheckedListBox.SetItemChecked(i, false);
            }

        }

        private void SelectAllFindCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectAllFindCheckBox.Checked == true)
            {
                for (int i = 0; i < FindCheckedListBox.Items.Count; i++)
                {
                    FindCheckedListBox.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < FindCheckedListBox.Items.Count; i++)
                {
                    FindCheckedListBox.SetItemChecked(i, false);
                }
            }
        }

        private void CancelFindButton_Click(object sender, EventArgs e)
        {
            closeFindPanel();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {

            if (FindTextBox.Text == "")
            {
                MessageBox.Show("You must enter your text to find!", "Search Error!");
                return;
            }

            String FindWhat = "";
            Boolean AtLeastOne = false;

            openDB();
            SqlCeCommand cmd = TecanDatabase.CreateCommand();
            // SqlCeDataReader reader;

            FindWhat = "%" + FindTextBox.Text + "%";

            String commandString = "SELECT SAPId, SAPDescription, Description, DetailDescription, PLDescription, PLDetailDescription, Notes, NotesFromFile FROM PartsList WHERE";
            if (FindCheckedListBox.GetItemChecked(0))
            {
                commandString = commandString + " SAPDescription LIKE '" + FindWhat + "'";
                AtLeastOne = true;
            }
            if (FindCheckedListBox.GetItemChecked(1))
            {
                if(AtLeastOne)
                {
                    commandString = commandString + " OR Description LIKE '" + FindWhat + "'";
                }
                else
                {
                    commandString = commandString + " Description LIKE '" + FindWhat + "'";
                    AtLeastOne = true;
                }
            }
            if (FindCheckedListBox.GetItemChecked(2))
            {
                if (AtLeastOne)
                {
                    commandString = commandString + " OR DetailDescription LIKE '" + FindWhat + "'";
                }
                else
                {
                    commandString = commandString + " DetailDescription LIKE '" + FindWhat + "'";
                    AtLeastOne = true;
                }
            }
            if (FindCheckedListBox.GetItemChecked(3))
            {
                if (AtLeastOne)
                {
                    commandString = commandString + " OR PLDescription LIKE '" + FindWhat + "'";
                }
                else
                {
                    commandString = commandString + " PLDescription LIKE '" + FindWhat + "'";
                    AtLeastOne = true;
                }
            }
            if (FindCheckedListBox.GetItemChecked(4))
            {
                if (AtLeastOne)
                {
                    commandString = commandString + " OR PLDetailDescription LIKE '" + FindWhat + "'";
                }
                else
                {
                    commandString = commandString + " PLDetailDescription LIKE '" + FindWhat + "'";
                    AtLeastOne = true;
                }
            }
            if (FindCheckedListBox.GetItemChecked(5))
            {
                if (AtLeastOne)
                {
                    commandString = commandString + " OR Notes LIKE '" + FindWhat + "'";
                }
                else
                {
                    commandString = commandString + " Notes LIKE '" + FindWhat + "'";
                    AtLeastOne = true;
                }
            }
            if (FindCheckedListBox.GetItemChecked(6))
            {
                if (AtLeastOne)
                {
                    commandString = commandString + " OR NotesFromFile LIKE '" + FindWhat + "'";
                }
                else
                {
                    commandString = commandString + " NotesFromFile LIKE '" + FindWhat + "'";
                    AtLeastOne = true;
                }
            }

            if (!AtLeastOne)
            {
                MessageBox.Show("You must select at least one field to search!", "Search Error!");
                TecanDatabase.Close();
                return;
            }
            cmd.CommandText = commandString;
            // reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            RecordsFoundLabel.Text = "Found " + dt.Rows.Count + " Records.";
            RecordsFoundLabel.Visible = true;
            if(dt.Rows.Count > 0)
            {
                FindDataGridView.DataSource = dt;
                FindDataGridView.Columns[1].Width = 350;
                FindReplacePanel.Height = 575;
                FindDataGridView.Visible = true;
            }
            // reader.Dispose();
            

            // Find Only
            if (ReplaceTextBox.Text == "")
            {
                
            }
            // Find and Replace
            else
            {
                FindWhat = FindTextBox.Text;
                String ReplaceWith = ReplaceTextBox.Text;
                // String commandString = "SELECT SAPId, SAPDescription, Description, DetailDescription, PLDescription, PLDetailDescription, Notes, NotesFromFile FROM PartsList WHERE";

                RecordsFoundLabel.Text = "Found " + dt.Rows.Count + " Records. Replacing " + FindTextBox.Text + " with " + ReplaceTextBox.Text + ", exact matches only!";
                String OriginalSAPDescription = "";        // SAP Description Field
                String OriginalDescription = "";           // Description Field
                String OriginalDetailDescription = "";     // Detail Description Field
                String OriginalPLDescription = "";         // PL Description Field
                String OriginalPLDetailDescription = "";   // PL Detail Description Field (Tecan Only ?)
                String OriginalNotes = "";                 // Notes From File Field
                String OriginalComments = "";              // Notes Field

                String NewSAPDescription = "";
                String NewDescription = "";
                String NewDetailDescription = "";
                String NewPLDescription = "";
                String NewPLDetailDescription = "";
                String NewNotes = "";
                String NewComments = "";

                // cmd.CommandText = "UPDATE PartsList SET " + lookupTableID + " = '" + newValue + "' WHERE SAPId = '" + selectedSAPID + "'";

                String itemSAPID = "";
                DataGridViewRow srow = null;
                Int32 rowCount = FindDataGridView.Rows.Count;
                Int32 rowIndex;

                for (int s = 0; s < rowCount-1; s++)
                {
                    AtLeastOne = false;
                    commandString = "UPDATE PartsList SET";
                    rowIndex = FindDataGridView.Rows[s].Index;
                    srow = FindDataGridView.Rows[rowIndex];
                    FindDataGridView.Rows[s].Selected = true;
                    itemSAPID = srow.Cells[0].Value.ToString();

                    if (FindCheckedListBox.GetItemChecked(0))
                    {
                        OriginalSAPDescription = srow.Cells[1].Value.ToString();
                        NewSAPDescription = OriginalSAPDescription.Replace(FindWhat, ReplaceWith);
                        NewSAPDescription = NewSAPDescription.Replace("'","''");
                        commandString = commandString + " SAPDescription = '" + NewSAPDescription + "'";
                        AtLeastOne = true;
                    }
                    if (FindCheckedListBox.GetItemChecked(1))
                    {
                        OriginalDescription = srow.Cells[2].Value.ToString();
                        NewDescription = OriginalDescription.Replace(FindWhat, ReplaceWith);
                        NewDescription = NewDescription.Replace("'","''");
                        if (AtLeastOne)
                        {
                            commandString = commandString + ", Description = '" + NewDescription + "'";
                        }
                        else
                        {
                            commandString = commandString + " Description = '" + NewDescription + "'";
                            AtLeastOne = true;
                        }
                    }
                    if (FindCheckedListBox.GetItemChecked(2))
                    {
                        OriginalDetailDescription = srow.Cells[3].Value.ToString();
                        NewDetailDescription = OriginalDetailDescription.Replace(FindWhat, ReplaceWith);
                        NewDetailDescription = NewDetailDescription.Replace("'","''");
                        if (AtLeastOne)
                        {
                            commandString = commandString + ", DetailDescription = '" + NewDetailDescription + "'";
                        }
                        else
                        {
                            commandString = commandString + " DetailDescription = '" + NewDetailDescription + "'";
                            AtLeastOne = true;
                        }
                    }
                    if (FindCheckedListBox.GetItemChecked(3))
                    {
                        OriginalPLDescription = srow.Cells[4].Value.ToString();
                        NewPLDescription = OriginalPLDescription.Replace(FindWhat, ReplaceWith);
                        NewPLDescription = NewPLDescription.Replace("'","''");
                        if (AtLeastOne)
                        {
                            commandString = commandString + ", PLDescription = '" + NewPLDescription + "'";
                        }
                        else
                        {
                            commandString = commandString + " PLDescription = '" + NewPLDescription + "'";
                            AtLeastOne = true;
                        }
                    }
                    if (FindCheckedListBox.GetItemChecked(4))
                    {
                        OriginalPLDetailDescription = srow.Cells[5].Value.ToString();
                        NewPLDetailDescription = OriginalPLDetailDescription.Replace(FindWhat, ReplaceWith);
                        NewPLDetailDescription = NewPLDetailDescription.Replace("'","''");
                        if (AtLeastOne)
                        {
                            commandString = commandString + ", PLDetailDescription = '" + OriginalPLDetailDescription + "'";
                        }
                        else
                        {
                            commandString = commandString + " PLDetailDescription = '" + OriginalPLDetailDescription + "'";
                            AtLeastOne = true;
                        }
                    }
                    if (FindCheckedListBox.GetItemChecked(5))
                    {
                        OriginalNotes = srow.Cells[6].Value.ToString();
                        NewNotes = OriginalNotes.Replace(FindWhat, ReplaceWith);
                        NewNotes = NewNotes.Replace("'","''");
                        if (AtLeastOne)
                        {
                            commandString = commandString + ", Notes = '" + OriginalNotes + "'";
                        }
                        else
                        {
                            commandString = commandString + " Notes = '" + OriginalNotes + "'";
                            AtLeastOne = true;
                        }
                    }
                    if (FindCheckedListBox.GetItemChecked(6))
                    {
                        OriginalComments = srow.Cells[7].Value.ToString();
                        NewComments = OriginalComments.Replace(FindWhat, ReplaceWith);
                        NewComments = NewComments.Replace("'","''");
                        if (AtLeastOne)
                        {
                            commandString = commandString + ", NotesFromFile = '" + NewComments + "'";
                        }
                        else
                        {
                            commandString = commandString + " NotesFromFile = '" + NewComments + "'";
                            AtLeastOne = true;
                        }
                    }
                    commandString = commandString + " WHERE SAPId = '" + itemSAPID + "'";
                    cmd.CommandText = commandString;
                    cmd.ExecuteNonQuery();
                }
            }
            TecanDatabase.Close();
            PartDetailReturn();
        }

        private void openDB()
        {
            TecanDatabase = new SqlCeConnection();
            String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanDatabase.Open();
        }

        private void FindCancelButton_Click(object sender, EventArgs e)
        {
            closeFindPanel();
        }

        private void closeFindPanel()
        {
            RecordsFoundLabel.Text = "";
            RecordsFoundLabel.Visible = false;
            FindDataGridView.Visible = false;
            FindReplacePanel.Visible = false;
        }

        private void FindAgainButton_Click(object sender, EventArgs e)
        {
            RecordsFoundLabel.Text = "";
            RecordsFoundLabel.Visible = false;
            FindDataGridView.DataSource = null;
            FindReplacePanel.Height = 325;
            FindDataGridView.Visible = false;
        }

        private void FindDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = FindDataGridView.CurrentCell.RowIndex;
            // int columnindex = FindDataGridView.CurrentCell.ColumnIndex; 

            String mySAPID = FindDataGridView.Rows[rowindex].Cells[0].Value.ToString();

            if (DetailsForm == null || DetailsForm.IsDisposed)
            {
                DetailsForm = new PartsListDetailDisplay();
            }
            try
            {
                DetailsForm.SetForm1Instance(this);
                DetailsForm.LoadParts(mySAPID);
                DetailsForm.TopMost = true;
                DetailsForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading Deatils Form " + ex.Message);
            }

        }

    }
}
