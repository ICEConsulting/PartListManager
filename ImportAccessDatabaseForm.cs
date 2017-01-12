using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.IO;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Data.OleDb;

namespace TecanPartListManager
{
    public partial class ImportAccessDatabaseForm : Form
    {

        MainPartsListDisplay mainForm;
        // Set up new Compatibilities list used in loadDatabases - Compatibility
        ArrayList theCompatibilities = new ArrayList();
        // DataTable CADTable;
        String LastFilePath;
        SqlCeConnection TecanPartsDatabase = new SqlCeConnection();
        SqlCeConnection TecanSmartStartDatabase = new SqlCeConnection();
        SqlCeConnection TecanSuppDocsDatabase = new SqlCeConnection();

        DataTable InstrumentDataTable = new DataTable();
        DataTable CategoryDataTable = new DataTable();
        DataTable SubCategoryDataTable = new DataTable();
        DataTable SSPCategoryDataTable = new DataTable();
        DataTable dBMembershipDataTable = new DataTable();
        DataTable SalesTypeDataTable = new DataTable();

        DataTable InstrumentSSDataTable = new DataTable();
        DataTable CategorySSDataTable = new DataTable();
        DataTable SubCategorySSDataTable = new DataTable();
        DataTable SSPCategorySSDataTable = new DataTable();
        DataTable dBMembershipSSDataTable = new DataTable();
        DataTable SalesTypeSSDataTable = new DataTable();

        private void createDataTableSchemas(DataTable currentTable, ListBox currentListbox)
        {
            // Declare DataColumn and DataRow variables.
            DataColumn column;

            // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ID";
            currentTable.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            currentTable.Columns.Add(column);

            currentListbox.DataSource = currentTable;
            currentListbox.DisplayMember = "Name";
            currentListbox.ValueMember = "ID";
        }

        private void ImportAccessDatabaseForm_Shown(Object sender, EventArgs e)
        {

            TecanPartsDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanPartsDatabase.Open();

            SqlCeCommand pcmd = TecanPartsDatabase.CreateCommand();
            pcmd.CommandText = "DELETE FROM PartsList";
            pcmd.ExecuteNonQuery();
            pcmd.CommandText = "DELETE FROM Category";
            pcmd.ExecuteNonQuery();
            pcmd.CommandText = "DELETE FROM Compatibility";
            pcmd.ExecuteNonQuery();
            pcmd.CommandText = "DELETE FROM DBMembership";
            pcmd.ExecuteNonQuery();
            pcmd.CommandText = "DELETE FROM Instrument";
            pcmd.ExecuteNonQuery();
            pcmd.CommandText = "DELETE FROM PartImages";
            pcmd.ExecuteNonQuery();
            pcmd.CommandText = "DELETE FROM RequiredParts";
            pcmd.ExecuteNonQuery();
            //cmd.CommandText = "DELETE FROM OptionalParts";
            //cmd.ExecuteNonQuery();
            pcmd.CommandText = "DELETE FROM SalesType";
            pcmd.ExecuteNonQuery();
            pcmd.CommandText = "DELETE FROM SSPCategory";
            pcmd.ExecuteNonQuery();
            pcmd.CommandText = "DELETE FROM SubCategory";
            pcmd.ExecuteNonQuery();
            pcmd.CommandText = "DELETE FROM SuppumentalDocs";
            pcmd.ExecuteNonQuery();
            TecanPartsDatabase.Close();

            TecanSmartStartDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanSmartStartPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanSmartStartDatabase.Open();

            SqlCeCommand sscmd = TecanSmartStartDatabase.CreateCommand();
            sscmd.CommandText = "DELETE FROM PartsList";
            sscmd.ExecuteNonQuery();
            sscmd.CommandText = "DELETE FROM Category";
            sscmd.ExecuteNonQuery();
            sscmd.CommandText = "DELETE FROM Compatibility";
            sscmd.ExecuteNonQuery();
            sscmd.CommandText = "DELETE FROM DBMembership";
            sscmd.ExecuteNonQuery();
            sscmd.CommandText = "DELETE FROM Instrument";
            sscmd.ExecuteNonQuery();
            sscmd.CommandText = "DELETE FROM PartImages";
            sscmd.ExecuteNonQuery();
            sscmd.CommandText = "DELETE FROM RequiredParts";
            sscmd.ExecuteNonQuery();
            //cmd.CommandText = "DELETE FROM OptionalParts";
            //cmd.ExecuteNonQuery();
            sscmd.CommandText = "DELETE FROM SalesType";
            sscmd.ExecuteNonQuery();
            sscmd.CommandText = "DELETE FROM SSPCategory";
            sscmd.ExecuteNonQuery();
            sscmd.CommandText = "DELETE FROM SubCategory";
            sscmd.ExecuteNonQuery();
            sscmd.CommandText = "DELETE FROM SuppumentalDocs";
            sscmd.ExecuteNonQuery();
            TecanSmartStartDatabase.Close();


            TecanSuppDocsDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanSuppDocs.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanSuppDocsDatabase.Open();

            SqlCeCommand scmd = TecanSuppDocsDatabase.CreateCommand();
            scmd.CommandText = "DELETE FROM SuppumentalDocs";
            scmd.ExecuteNonQuery();
            TecanSuppDocsDatabase.Close();

            //TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanAppDocs.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            //TecanDatabase.Open();
            //cmd.CommandText = "DELETE FROM ApplicationCategories";
            //cmd.ExecuteNonQuery();
            //cmd.CommandText = "DELETE FROM Documents";
            //cmd.ExecuteNonQuery();


            String myAccessDatabaseConnectionString;
            myAccessDatabaseConnectionString = getConnection();
            if (myAccessDatabaseConnectionString == "")
            {
                if (MessageBox.Show("All Data has already been Deleted!\r\n\r\nPlease select a Parts List File?", "Select an Import Database", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    myAccessDatabaseConnectionString = getConnection();
                }
            }
            if (myAccessDatabaseConnectionString != "")
            {
                loadDatabase(myAccessDatabaseConnectionString);
            }
            else
            {
                this.Close();
            }
        }

        public void SetForm1Instance(MainPartsListDisplay inst)
        {
            mainForm = inst;
        }

        public ImportAccessDatabaseForm()
        {
            InitializeComponent();
        }

        private void ImportAccessDatabaseForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tecanPartsListDataSet.DBMembership' table. You can move, or remove it, as needed.
            // this.dBMembershipTableAdapter.Fill(this.tecanPartsListDataSet.DBMembership);
            // mainForm.MainPartsListDisplay_Load(sender, e);
        }

        private void ImportAccessDatabaseForm_Close(object sender, EventArgs e)
        {
            Validate();
            //partsListBindingSource.EndEdit();
            //tableAdapterManager.UpdateAll(this.tecanPartsListDataSet);
            mainForm.WindowState = FormWindowState.Maximized;
            mainForm.MainPartsListDisplay_Load(sender, e);
        }

        private void loadDatabase(String myAccessDatabaseConnectionString)
        {
            createDataTableSchemas(InstrumentDataTable, instrumentListBox);
            createDataTableSchemas(CategoryDataTable, categoryListBox);
            createDataTableSchemas(SubCategoryDataTable, subCategoryListBox);
            createDataTableSchemas(SSPCategoryDataTable, sspCategoryListBox);
            createDataTableSchemas(dBMembershipDataTable, dBMembershipListBox);
            createDataTableSchemas(SalesTypeDataTable, salesTypeListBox);

            createDataTableSchemas(InstrumentSSDataTable, instrumentSSListBox);
            createDataTableSchemas(CategorySSDataTable, categorySSListBox);
            createDataTableSchemas(SubCategorySSDataTable, subCategorySSListBox);
            createDataTableSchemas(SSPCategorySSDataTable, sspCategorySSListBox);
            createDataTableSchemas(dBMembershipSSDataTable, dBMembershipSSListBox);
            createDataTableSchemas(SalesTypeSSDataTable, salesTypeSSListBox);

            //String myAccessDatabaseConnectionString;
            //myAccessDatabaseConnectionString = getConnection();
            //if (myAccessDatabaseConnectionString == "")
            //{
            //    if (MessageBox.Show("All Data has already been Deleted!\r\n\r\nPlease select a Parts List File?", "Select an Import Database", MessageBoxButtons.YesNo) == DialogResult.No)
            //    {
            //        this.Close();
            //    }
            //    else
            //    {
            //        myAccessDatabaseConnectionString = getConnection();
            //    }
            //}

            // SqlCeConnection TecanDatabase = null;

            using (OdbcConnection myConnection = new OdbcConnection(myAccessDatabaseConnectionString))
            {
                // Open Databases
                // New Tecan Database
                TecanPartsDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
                TecanPartsDatabase.Open();
                SqlCeCommand pcmd = TecanPartsDatabase.CreateCommand();

                TecanSmartStartDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanSmartStartPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
                TecanSmartStartDatabase.Open();
                SqlCeCommand scmd = TecanSmartStartDatabase.CreateCommand();

                // Access Database
                myConnection.Open();

                Boolean EmptyLookupField = false;

                // Add DB Membership
                statusPanelLabel.Text = "Database Membership";
                statusProgressBar.Visible = true;

                statusProgressBar.Value = 0;
                statusProgressBar.Maximum = 500;

                // Put first entry into table for search purposes
                pcmd.CommandText = "INSERT INTO DBMembership (DBID, DBName) Values (0, 'Any')";
                pcmd.ExecuteNonQuery();

                scmd.CommandText = "INSERT INTO DBMembership (DBID, DBName) Values (0, 'Any')";
                scmd.ExecuteNonQuery();

                string query = "SELECT DISTINCT [Database Membership] from Parts WHERE SSP_Category IS NULL ORDER BY [Database Membership]";
                OdbcCommand command = new OdbcCommand(query, myConnection);
                String rowData;
                short rowCount;
                try
                {
                    DataRow row;
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        if(rowData.Length > 0) rowData = char.ToUpper(rowData[0]) + rowData.Substring(1);
                        if (rowData == "") EmptyLookupField = true;
                        // Add row to PartsList Db (non-ss)
                        pcmd.CommandText = "INSERT INTO DBMembership (DBID, DBName) Values (" + rowCount + ", '" + rowData + "')";
                        pcmd.ExecuteNonQuery();
                        // Add row to DataTable and ultimately to ListBox
                        row = dBMembershipDataTable.NewRow();
                        row["ID"] = rowCount;
                        row["Name"] = rowData;
                        dBMembershipDataTable.Rows.Add(row);
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DBMembership " + ex.Message);
                }
                
                query = "SELECT DISTINCT [Database Membership] from Parts WHERE SSP_Category IS NOT NULL ORDER BY [Database Membership]";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    DataRow row;
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        if (rowData.Length > 0) rowData = char.ToUpper(rowData[0]) + rowData.Substring(1);
                        if (rowData == "") EmptyLookupField = true;
                        scmd.CommandText = "INSERT INTO DBMembership (DBID, DBName) Values (" + rowCount + ", '" + rowData + "')";
                        scmd.ExecuteNonQuery();
                        // Add row to DataTable and ultimately to ListBox
                        row = dBMembershipSSDataTable.NewRow();
                        row["ID"] = rowCount;
                        row["Name"] = rowData;
                        dBMembershipSSDataTable.Rows.Add(row);
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DBMembership " + ex.Message);
                }

                //
                // Add Instruments (Platform)
                statusPanelLabel.Text = "Instruments";
                statusProgressBar.Value = 0;

                // Put first entry into table for search purposes
                pcmd.CommandText = "INSERT INTO Instrument (InstrumentID, InstrumentName) Values (0, 'Any')";
                pcmd.ExecuteNonQuery();

                scmd.CommandText = "INSERT INTO Instrument (InstrumentID, InstrumentName) Values (0, 'Any')";
                scmd.ExecuteNonQuery();

                query = "SELECT DISTINCT Platform from Parts WHERE SSP_Category IS NULL ORDER BY Platform";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    DataRow row;
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        if (rowData == "") EmptyLookupField = true;
                        pcmd.CommandText = "INSERT INTO Instrument (InstrumentID, InstrumentName) Values (" + rowCount + ", '" + rowData + "')";
                        pcmd.ExecuteNonQuery();
                        // Add row to DataTable and ultimately to ListBox
                        row = InstrumentDataTable.NewRow();
                        row["ID"] = rowCount;
                        row["Name"] = rowData;
                        InstrumentDataTable.Rows.Add(row);
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Instrument " + ex.Message);
                }

                query = "SELECT DISTINCT Platform from Parts WHERE SSP_Category IS NOT NULL ORDER BY Platform";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    DataRow row;
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        if (rowData == "") EmptyLookupField = true;
                        scmd.CommandText = "INSERT INTO Instrument (InstrumentID, InstrumentName) Values (" + rowCount + ", '" + rowData + "')";
                        scmd.ExecuteNonQuery();
                        // Add row to DataTable and ultimately to ListBox
                        row = InstrumentSSDataTable.NewRow();
                        row["ID"] = rowCount;
                        row["Name"] = rowData;
                        InstrumentSSDataTable.Rows.Add(row);
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Instrument " + ex.Message);
                }

                //
                // Add Categories
                statusPanelLabel.Text = "Categories";
                statusProgressBar.Value = 0;

                // Put first entry into table for search purposes
                pcmd.CommandText = "INSERT INTO Category (CategoryID, CategoryName) Values (0, 'Any')";
                pcmd.ExecuteNonQuery();

                scmd.CommandText = "INSERT INTO Category (CategoryID, CategoryName) Values (0, 'Any')";
                scmd.ExecuteNonQuery();

                query = "SELECT DISTINCT Category from Parts WHERE SSP_Category IS NULL ORDER BY Category";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    DataRow row;
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        if (rowData == "") EmptyLookupField = true;
                        pcmd.CommandText = "INSERT INTO Category (CategoryID, CategoryName) Values (" + rowCount + ", '" + rowData + "')";
                        pcmd.ExecuteNonQuery();
                        // Add row to DataTable and ultimately to ListBox
                        row = CategoryDataTable.NewRow();
                        row["ID"] = rowCount;
                        row["Name"] = rowData;
                        CategoryDataTable.Rows.Add(row);
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Category " + ex.Message);
                }

                query = "SELECT DISTINCT Category from Parts WHERE SSP_Category IS NOT NULL ORDER BY Category";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    DataRow row;
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        if (rowData == "") EmptyLookupField = true;
                        scmd.CommandText = "INSERT INTO Category (CategoryID, CategoryName) Values (" + rowCount + ", '" + rowData + "')";
                        scmd.ExecuteNonQuery();
                        // Add row to DataTable and ultimately to ListBox
                        row = CategorySSDataTable.NewRow();
                        row["ID"] = rowCount;
                        row["Name"] = rowData;
                        CategorySSDataTable.Rows.Add(row);
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Category " + ex.Message);
                }

                //
                // Add Sub Categories
                statusPanelLabel.Text = "Sub Categories";
                statusProgressBar.Value = 0;

                // Put first entry into table for search purposes
                pcmd.CommandText = "INSERT INTO SubCategory (SubCategoryID, SubCategoryName) Values (0, 'Any')";
                pcmd.ExecuteNonQuery();

                scmd.CommandText = "INSERT INTO SubCategory (SubCategoryID, SubCategoryName) Values (0, 'Any')";
                scmd.ExecuteNonQuery();

                query = "SELECT DISTINCT Subcategory from Parts WHERE SSP_Category IS NULL ORDER BY Subcategory";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    DataRow row;
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        if (rowData == "") EmptyLookupField = true;
                        pcmd.CommandText = "INSERT INTO SubCategory (SubCategoryID, SubCategoryName) Values (" + rowCount + ", '" + rowData + "')";
                        pcmd.ExecuteNonQuery();
                        // Add row to DataTable and ultimately to ListBox
                        row = SubCategoryDataTable.NewRow();
                        row["ID"] = rowCount;
                        row["Name"] = rowData;
                        SubCategoryDataTable.Rows.Add(row);
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SubCategory 1" + ex.Message);
                }

                query = "SELECT DISTINCT Subcategory from Parts WHERE SSP_Category IS NOT NULL ORDER BY Subcategory";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    DataRow row;
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        if (rowData == "") EmptyLookupField = true;
                        scmd.CommandText = "INSERT INTO SubCategory (SubCategoryID, SubCategoryName) Values (" + rowCount + ", '" + rowData + "')";
                        scmd.ExecuteNonQuery();
                        // Add row to DataTable and ultimately to ListBox
                        row = SubCategorySSDataTable.NewRow();
                        row["ID"] = rowCount;
                        row["Name"] = rowData;
                        SubCategorySSDataTable.Rows.Add(row);
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SubCategory 2" + ex.Message);
                }

                //
                // Add Compatibilities
                statusPanelLabel.Text = "Compatibilities";
                statusProgressBar.Value = 0;
               
                String rowCompatibilityAbbv;
                String rowCompatibility;
                query = "SELECT [Compat ID], [Compatibility] from Compatibility ORDER BY [Compat ID]";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowCompatibilityAbbv = reader[0].ToString();
                        rowCompatibility = reader[1].ToString();
                        pcmd.CommandText = "INSERT INTO Compatibility (CompatibilityID, CompatibilityName) Values (" + rowCount + ", '" + rowCompatibility + "')";
                        pcmd.ExecuteNonQuery();
                        scmd.CommandText = "INSERT INTO Compatibility (CompatibilityID, CompatibilityName) Values (" + rowCount + ", '" + rowCompatibility + "')";
                        scmd.ExecuteNonQuery();
                        theCompatibilities.Add(new Compatibilities(rowCompatibility, rowCount.ToString(), rowCompatibilityAbbv));
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Compatibility " + ex.Message);
                }

                //
                // Add Sales Types
                statusPanelLabel.Text = "Sales Types";
                statusProgressBar.Value = 0;

                // Put first entry into table for search purposes
                pcmd.CommandText = "INSERT INTO SalesType (SalesTypeID, SalesTypeName) Values (0, 'Any')";
                pcmd.ExecuteNonQuery();

                scmd.CommandText = "INSERT INTO SalesType (SalesTypeID, SalesTypeName) Values (0, 'Any')";
                scmd.ExecuteNonQuery();

                query = "SELECT DISTINCT [Sales Type] from Parts WHERE SSP_Category IS NULL ORDER BY [Sales Type]";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    DataRow row;
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        if (rowData.Length > 0) rowData = char.ToUpper(rowData[0]) + rowData.Substring(1);
                        if (rowData == "") EmptyLookupField = true;
                        pcmd.CommandText = "INSERT INTO SalesType (SalesTypeID, SalesTypeName) Values (" + rowCount + ", '" + rowData + "')";
                        pcmd.ExecuteNonQuery();
                        // Add row to DataTable and ultimately to ListBox
                        row = SalesTypeDataTable.NewRow();
                        row["ID"] = rowCount;
                        row["Name"] = rowData;
                        SalesTypeDataTable.Rows.Add(row);
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SalesType " + ex.Message);
                }

                query = "SELECT DISTINCT [Sales Type] from Parts WHERE SSP_Category IS NOT NULL ORDER BY [Sales Type]";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    DataRow row;
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        if (rowData.Length > 0) rowData = char.ToUpper(rowData[0]) + rowData.Substring(1);
                        if (rowData == "") EmptyLookupField = true;
                        scmd.CommandText = "INSERT INTO SalesType (SalesTypeID, SalesTypeName) Values (" + rowCount + ", '" + rowData + "')";
                        scmd.ExecuteNonQuery();
                        // Add row to DataTable and ultimately to ListBox
                        row = SalesTypeSSDataTable.NewRow();
                        row["ID"] = rowCount;
                        row["Name"] = rowData;
                        SalesTypeSSDataTable.Rows.Add(row);
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SalesType " + ex.Message);
                }

                // Add SSP Categories
                statusPanelLabel.Text = "SSP Categories";
                statusProgressBar.Value = 0;

                query = "SELECT DISTINCT [SSP_Category] from Parts WHERE SSP_Category IS NULL ORDER BY [SSP_Category]";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    DataRow row;
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        if (rowData.Length > 0) rowData = char.ToUpper(rowData[0]) + rowData.Substring(1);
                        pcmd.CommandText = "INSERT INTO SSPCategory (SSPCategoryId, SSPCategoryName) Values (" + rowCount + ", '" + rowData + "')";
                        pcmd.ExecuteNonQuery();
                        // Add row to DataTable and ultimately to ListBox
                        row = SSPCategoryDataTable.NewRow();
                        row["ID"] = rowCount;
                        row["Name"] = rowData;
                        SSPCategoryDataTable.Rows.Add(row);
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("My SSP Categories " + ex.Message);
                }

                query = "SELECT DISTINCT [SSP_Category] from Parts WHERE SSP_Category IS NOT NULL ORDER BY [SSP_Category]";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    DataRow row;
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        if (rowData.Length > 0) rowData = char.ToUpper(rowData[0]) + rowData.Substring(1);
                        if (rowData == "") EmptyLookupField = true;
                        scmd.CommandText = "INSERT INTO SSPCategory (SSPCategoryId, SSPCategoryName) Values (" + rowCount + ", '" + rowData + "')";
                        scmd.ExecuteNonQuery();
                        // Add row to DataTable and ultimately to ListBox
                        row = SSPCategorySSDataTable.NewRow();
                        row["ID"] = rowCount;
                        row["Name"] = rowData;
                        SSPCategorySSDataTable.Rows.Add(row);
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("My SSP Categories " + ex.Message);
                }

                // Add Parts
                statusPanelLabel.Text = "Adding Parts";
                statusProgressBar.Value = 0;
                statusProgressBar.Maximum = 6000; // todo find better way to set progress bar max value associated with record count

//                query = @"SELECT [Lab/Office], [SAP ID], [Old Part Number], [3rd Party Part Number], [Priority], [Platform], [Sales Type], [Category], [Subcategory], 
//                                [Desc], [SAP Desc], [Detail Desc], [PL Desc], [PL Detail Desc], [PL Price], [grids], [Serial Ports], [USB Ports], [Standard Price], 
//                                [ILP], [ASP], [Manuf Cost], [x_dimension], [y_dimension], [z_dimension], [createdate], [removaldate], [Database Membership], 
//                                [Not in Master Price List], [3rd Party], [Notes], [SSP_Category], [System Compatibility] from Parts ORDER BY [SAP ID]";

//                command = new OdbcCommand(query, myConnection);

                Int16 Lab = 0;
                String SAPId;
                String OldPartNum;
                String ThridPartyPartNum;
                Byte Priority = 0;
                short Instrument;
                short SalesType;
                short Category;
                short SubCategory;
                String Description;
                String SAPDescription;
                String DetailDescription;
                String PLDescription; // This field is used for PL Additional Info
                String PLDetailDescription; // This field is used for Tecan Only Data
                Decimal PlPrice = 0;
                Int16 Grids = 0;
                Byte SerialPorts = 0;
                Byte USBPorts = 0;
                Decimal StandarPrice = 0;
                Decimal ILP = 0;
                Decimal ASP = 0;
                Decimal ManufacturingCost = 0;
                String X_Dimension;
                String Y_Dimension;
                String Z_Dimension;
                String Z_DimensionNote;
                DateTime? CreateDate = null;
                DateTime? RemoveDate = null;
                short DBMembership;
                Boolean NotMasterPriceList;
                Boolean ThridParty;
                String Notes;
                short SSPCategory;
                String Compatibility;

                query = @"SELECT [Lab/Office], [SAP ID], [Old Part Number], [3rd Party Part Number], [Priority], [Platform], [Sales Type], [Category], [Subcategory], 
                                [Desc], [SAP Desc], [Detail Desc], [PL Desc], [PL Detail Desc], [PL Price], [grids], [Serial Ports], [USB Ports], [Standard Price], 
                                [ILP], [ASP], [Manuf Cost], [x_dimension], [y_dimension], [z_dimension], [createdate], [removaldate], [Database Membership], 
                                [Not in Master Price List], [3rd Party], [Notes], [SSP_Category], [System Compatibility] from Parts WHERE SSP_Category IS NULL ORDER BY [SAP ID]";

                command = new OdbcCommand(query, myConnection);

                try
                {

                    OdbcDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        if (reader[0].ToString() != "")
                        {
                            try
                            {
                                Lab = Convert.ToInt16(reader[0].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert Lab " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            Lab = 0;
                        }

                        SAPId = reader[1].ToString();
                        OldPartNum = reader[2].ToString();
                        ThridPartyPartNum = reader[3].ToString();

                        if (reader[4].ToString() != "")
                        {
                            try
                            {
                                Priority = Convert.ToByte(reader[4].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert Priority " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            Priority = 0;
                        }

                        // Get Instrument Lookup Value
                        Instrument = getLookupTableValue(reader[5].ToString(), InstrumentDataTable); //getInstrument(reader[5].ToString());
                        // Get Sales Type Lookup Value
                        if (reader[6].ToString() != "")
                        {
                            SalesType = getLookupTableValue(char.ToUpper(reader[6].ToString()[0]) + reader[6].ToString().Substring(1), SalesTypeDataTable); // getSalesType(char.ToUpper(reader[6].ToString()[0]) + reader[6].ToString().Substring(1));
                        }
                        else
                        {
                            SalesType = getLookupTableValue(reader[6].ToString(), SalesTypeDataTable); //getSalesType(reader[6].ToString());
                        }
                        // Get Category Lookup Value
                        Category = getLookupTableValue(reader[7].ToString(), CategoryDataTable); // getCategory(reader[7].ToString());
                        // Get SubCategory Lookup Value
                        SubCategory = getLookupTableValue(reader[8].ToString(), SubCategoryDataTable);  //getSubCategory(reader[8].ToString());
                        Description = reader[9].ToString();
                        SAPDescription = reader[10].ToString();
                        DetailDescription = reader[11].ToString();
                        // The PL Description Field is being used as a PL Additional Info field in the new database
                        // Do not add the PL Description data from the Access Database
                        // PLDescription = reader[12].ToString();
                        PLDescription = ""; // This field is used for PL Additional Info
                        // The PL Detail Description Field is being used as a Tecan Only field in the new database
                        // Do not add the PL Detail Description data from the Access Database
                        // PLDetailDescription = reader[13].ToString();
                        PLDetailDescription = ""; // This field is used for Tecan Only Data

                        if (reader[14].ToString() != "")
                        {
                            try
                            {
                                PlPrice = Convert.ToDecimal(reader[14].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert PlPrice " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            PlPrice = 0;
                        }

                        if (reader[15].ToString() != "")
                        {
                            try
                            {
                                Grids = (short)Convert.ToInt16(reader[15].ToString());
                            }
                            catch (Exception ex)
                            {
                               // MessageBox.Show("Convert Grids " + ex.Message + " " + reader[15].ToString());
                            }
                        }
                        else
                        {
                            Grids = 0;
                        }

                        if (reader[16].ToString() != "")
                        {
                            try
                            {
                                SerialPorts = Convert.ToByte(reader[16].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert SerialPorts " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            SerialPorts = 0;
                        }

                        if (reader[17].ToString() != "")
                        {
                            try
                            {
                                USBPorts = Convert.ToByte(reader[17].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert USBPorts " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            USBPorts = 0;
                        }
                        
                        // Standard price and ILP are reversed in the original Access database
                        // Swap reader[18] standard price for reader[19] ilp
                        if (reader[19].ToString() != "")
                        {
                            try
                            {
                                StandarPrice = Convert.ToDecimal(reader[19].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert StandarPrice " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            StandarPrice = 0;
                        }

                        if (reader[18].ToString() != "")
                        {
                            try
                            {
                                ILP = Convert.ToDecimal(reader[18].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert ILP " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            ILP = 0;
                        }

                        if (reader[20].ToString() != "")
                        {
                            try
                            {
                                ASP = Convert.ToDecimal(reader[20].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert ASP " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            ASP = 0;
                        }

                        if (reader[21].ToString() != "")
                        {
                            try
                            {
                                ManufacturingCost = Convert.ToDecimal(reader[21].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert ManufacturingCost " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            ManufacturingCost = 0;
                        }

                        X_Dimension = reader[22].ToString();
                        Y_Dimension = reader[23].ToString();
                        Z_Dimension = reader[24].ToString();
                        Z_DimensionNote = ""; // Todo Find location for Dimension Notes 

                        if (reader[25].ToString() != "")
                        {
                            try
                            {
                                CreateDate = Convert.ToDateTime(reader[25].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert CreateDate " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            CreateDate = null;
                        }

                        if (reader[26].ToString() != "")
                        {
                            try
                            {
                                RemoveDate = Convert.ToDateTime(reader[26].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert RemoveDate " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            RemoveDate = null;
                        }

                        // Set DB Membership
                        if (reader[27].ToString() != "")
                        {
                            DBMembership = getLookupTableValue(char.ToUpper(reader[27].ToString()[0]) + reader[27].ToString().Substring(1), dBMembershipDataTable); // getDBMembership(char.ToUpper(reader[27].ToString()[0]) + reader[27].ToString().Substring(1));
                        }
                        else
                        {
                            DBMembership = getLookupTableValue(reader[27].ToString(), dBMembershipDataTable); // getDBMembership(reader[27].ToString());
                        }
                        
                        NotMasterPriceList = Convert.ToBoolean(reader[28].ToString());
                        ThridParty = Convert.ToBoolean(reader[29].ToString());
                        Notes = reader[30].ToString();
                        // Get SSPCategory Lookup Value
                        SSPCategory = getLookupTableValue(reader[31].ToString(), SSPCategoryDataTable);  // getSSPCategory(reader[31].ToString());
                        Compatibility = getCompatibility(reader[32].ToString());

                        pcmd.CommandText = "INSERT INTO PartsList (Lab, SAPId, OldPartNum, ThridPartyPartNum, Priority, Instrument, SalesType, Category, SubCategory," +
                            " Description, SAPDescription, DetailDescription, PLDescription, PLDetailDescription, PlPrice, Grids, SerialPorts, USBPorts," +
                            " StandarPrice, ILP, ASP, ManufacturingCost, X_Dimension, Y_Dimension, Z_Dimension, Z_DimensionNote, CreateDate, RemoveDate, DBMembership," +
                            " NotMasterPriceList, ThridParty, Notes, SSPCategory, Compatibility)" +
                            " Values " +
                            "(@Lab, @SAPId, @OldPartNum, @ThridPartyPartNum, @Priority, @Instrument, @SalesType, @Category, @SubCategory, " +
                            "@Description, @SAPDescription, @DetailDescription, @PLDescription, @PLDetailDescription, @PlPrice, @Grids, @SerialPorts, @USBPorts, " +
                            "@StandarPrice, @ILP, @ASP, @ManufacturingCost, @X_Dimension, @Y_Dimension, @Z_Dimension, @Z_DimensionNote, @CreateDate, @RemoveDate, " +
                            "@DBMembership, @NotMasterPriceList, @ThridParty, @Notes, @SSPCategory, @Compatibility)";


                        pcmd.Parameters.AddWithValue("@Lab", Lab);
                        pcmd.Parameters.AddWithValue("@SAPId", SAPId);
                        pcmd.Parameters.AddWithValue("@OldPartNum", OldPartNum);
                        pcmd.Parameters.AddWithValue("@ThridPartyPartNum", ThridPartyPartNum);
                        pcmd.Parameters.AddWithValue("@Priority", Priority);
                        pcmd.Parameters.AddWithValue("@Instrument", Instrument);
                        pcmd.Parameters.AddWithValue("@SalesType", SalesType);
                        pcmd.Parameters.AddWithValue("@Category", Category);
                        pcmd.Parameters.AddWithValue("@SubCategory", SubCategory);
                        pcmd.Parameters.AddWithValue("@Description", Description);
                        pcmd.Parameters.AddWithValue("@SAPDescription", SAPDescription);
                        pcmd.Parameters.AddWithValue("@DetailDescription", DetailDescription);
                        pcmd.Parameters.AddWithValue("@PLDescription", PLDescription); // This field is used for PL Additional Info
                        pcmd.Parameters.AddWithValue("@PLDetailDescription", PLDetailDescription); // This field is being used as the Tecan Only Data Field
                        pcmd.Parameters.AddWithValue("@PlPrice", PlPrice);
                        pcmd.Parameters.AddWithValue("@Grids", Grids);
                        pcmd.Parameters.AddWithValue("@SerialPorts", SerialPorts);
                        pcmd.Parameters.AddWithValue("@USBPorts", USBPorts);
                        pcmd.Parameters.AddWithValue("@StandarPrice", StandarPrice);
                        pcmd.Parameters.AddWithValue("@ILP", ILP);
                        pcmd.Parameters.AddWithValue("@ASP", ASP);
                        pcmd.Parameters.AddWithValue("@ManufacturingCost", ManufacturingCost);
                        pcmd.Parameters.AddWithValue("@X_Dimension", X_Dimension);
                        pcmd.Parameters.AddWithValue("@Y_Dimension", Y_Dimension);
                        pcmd.Parameters.AddWithValue("@Z_Dimension", Z_Dimension);
                        pcmd.Parameters.AddWithValue("@Z_DimensionNote", Z_DimensionNote);
                        if (CreateDate != null)
                        {
                            pcmd.Parameters.AddWithValue("@CreateDate", CreateDate);
                        }
                        else
                        {
                            pcmd.Parameters.AddWithValue("@CreateDate", "01/01/01");
                        }
                        if (RemoveDate != null)
                        {
                            pcmd.Parameters.AddWithValue("@RemoveDate", RemoveDate);
                        }
                        else
                        {
                            pcmd.Parameters.AddWithValue("@RemoveDate", "01/01/01");
                        }
                        pcmd.Parameters.AddWithValue("@DBMembership", DBMembership);
                        pcmd.Parameters.AddWithValue("@NotMasterPriceList", NotMasterPriceList);
                        pcmd.Parameters.AddWithValue("@ThridParty", ThridParty);
                        pcmd.Parameters.AddWithValue("@Notes", Notes);
                        pcmd.Parameters.AddWithValue("@SSPCategory", SSPCategory);
                        pcmd.Parameters.AddWithValue("@Compatibility", Compatibility);
                        
                        pcmd.ExecuteNonQuery();
                        pcmd.Parameters.Clear();
                        statusProgressBar.Value = statusProgressBar.Value + 1;
                        partsListBox.Items.Add(SAPId + " - ' " + Description);
                    }
                    reader.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Parts " + ex.Message);
                }
                finally
                {
//                    TecanDatabase.Close();
                }

                // Parts to SSP items
                query = @"SELECT [Lab/Office], [SAP ID], [Old Part Number], [3rd Party Part Number], [Priority], [Platform], [Sales Type], [Category], [Subcategory], 
                                [Desc], [SAP Desc], [Detail Desc], [PL Desc], [PL Detail Desc], [PL Price], [grids], [Serial Ports], [USB Ports], [Standard Price], 
                                [ILP], [ASP], [Manuf Cost], [x_dimension], [y_dimension], [z_dimension], [createdate], [removaldate], [Database Membership], 
                                [Not in Master Price List], [3rd Party], [Notes], [SSP_Category], [System Compatibility] from Parts WHERE SSP_Category IS NOT NULL ORDER BY [SAP ID]";

                command = new OdbcCommand(query, myConnection);

                try
                {

                    OdbcDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        if (reader[0].ToString() != "")
                        {
                            try
                            {
                                Lab = Convert.ToInt16(reader[0].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert Lab " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            Lab = 0;
                        }

                        SAPId = reader[1].ToString();
                        OldPartNum = reader[2].ToString();
                        ThridPartyPartNum = reader[3].ToString();

                        if (reader[4].ToString() != "")
                        {
                            try
                            {
                                Priority = Convert.ToByte(reader[4].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert Priority " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            Priority = 0;
                        }

                        // Get Instrument Lookup Value
                        Instrument = getLookupTableValue(reader[5].ToString(), InstrumentSSDataTable);  // getInstrument(reader[5].ToString());
                        // Get Sales Type Lookup Value
                        if (reader[6].ToString() != "")
                        {
                            SalesType = getLookupTableValue(char.ToUpper(reader[6].ToString()[0]) + reader[6].ToString().Substring(1), SalesTypeSSDataTable); // getSalesType(char.ToUpper(reader[6].ToString()[0]) + reader[6].ToString().Substring(1));
                        }
                        else
                        {
                            SalesType = getLookupTableValue(reader[6].ToString(), SalesTypeSSDataTable); // getSalesType(reader[6].ToString());
                        }
                        // Get Category Lookup Value
                        Category = getLookupTableValue(reader[7].ToString(), CategorySSDataTable); // getCategory(reader[7].ToString());
                        // Get SubCategory Lookup Value
                        SubCategory = getLookupTableValue(reader[8].ToString(), SubCategorySSDataTable); // getSubCategory(reader[8].ToString());
                        Description = reader[9].ToString();
                        SAPDescription = reader[10].ToString();
                        DetailDescription = reader[11].ToString();
                        // The PL Description Field is being used as a PL Additional Info field in the new database
                        // Do not add the PL Description data from the Access Database
                        // PLDescription = reader[12].ToString();
                        PLDescription = ""; // This field is used for PL Additional Info
                        // The PL Detail Description Field is being used as a Tecan Only field in the new database
                        // Do not add the PL Detail Description data from the Access Database
                        // PLDetailDescription = reader[13].ToString();
                        PLDetailDescription = ""; // This field is used for Tecan Only Data

                        if (reader[14].ToString() != "")
                        {
                            try
                            {
                                PlPrice = Convert.ToDecimal(reader[14].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert PlPrice " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            PlPrice = 0;
                        }

                        if (reader[15].ToString() != "")
                        {
                            try
                            {
                                Grids = (short)Convert.ToInt16(reader[15].ToString());
                            }
                            catch (Exception ex)
                            {
                                // MessageBox.Show("Convert Grids " + ex.Message + " " + reader[15].ToString());
                            }
                        }
                        else
                        {
                            Grids = 0;
                        }

                        if (reader[16].ToString() != "")
                        {
                            try
                            {
                                SerialPorts = Convert.ToByte(reader[16].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert SerialPorts " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            SerialPorts = 0;
                        }

                        if (reader[17].ToString() != "")
                        {
                            try
                            {
                                USBPorts = Convert.ToByte(reader[17].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert USBPorts " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            USBPorts = 0;
                        }

                        // Standard price and ILP are reversed in the original Access database
                        // Swap reader[18] standard price for reader[19] ilp
                        if (reader[19].ToString() != "")
                        {
                            try
                            {
                                StandarPrice = Convert.ToDecimal(reader[19].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert StandarPrice " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            StandarPrice = 0;
                        }

                        if (reader[18].ToString() != "")
                        {
                            try
                            {
                                ILP = Convert.ToDecimal(reader[18].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert ILP " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            ILP = 0;
                        }

                        if (reader[20].ToString() != "")
                        {
                            try
                            {
                                ASP = Convert.ToDecimal(reader[20].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert ASP " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            ASP = 0;
                        }

                        if (reader[21].ToString() != "")
                        {
                            try
                            {
                                ManufacturingCost = Convert.ToDecimal(reader[21].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert ManufacturingCost " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            ManufacturingCost = 0;
                        }

                        X_Dimension = reader[22].ToString();
                        Y_Dimension = reader[23].ToString();
                        Z_Dimension = reader[24].ToString();
                        Z_DimensionNote = ""; // Todo Find location for Dimension Notes 

                        if (reader[25].ToString() != "")
                        {
                            try
                            {
                                CreateDate = Convert.ToDateTime(reader[25].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert CreateDate " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            CreateDate = null;
                        }

                        if (reader[26].ToString() != "")
                        {
                            try
                            {
                                RemoveDate = Convert.ToDateTime(reader[26].ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Convert RemoveDate " + ex.Message + ex.Source);
                            }
                        }
                        else
                        {
                            RemoveDate = null;
                        }

                        // Set DB Membership
                        if (reader[27].ToString() != "")
                        {
                            DBMembership = getLookupTableValue(char.ToUpper(reader[27].ToString()[0]) + reader[27].ToString().Substring(1), dBMembershipSSDataTable); // getDBMembership(char.ToUpper(reader[27].ToString()[0]) + reader[27].ToString().Substring(1));
                        }
                        else
                        {
                            DBMembership = getLookupTableValue(reader[27].ToString(), dBMembershipSSDataTable);  //getDBMembership(reader[27].ToString());
                        }

                        NotMasterPriceList = Convert.ToBoolean(reader[28].ToString());
                        ThridParty = Convert.ToBoolean(reader[29].ToString());
                        Notes = reader[30].ToString();
                        // Get SSPCategory Lookup Value
                        SSPCategory = getLookupTableValue(reader[31].ToString(), SSPCategorySSDataTable); // getSSPCategory(reader[31].ToString());
                        Compatibility = getCompatibility(reader[32].ToString());

                        scmd.CommandText = "INSERT INTO PartsList (Lab, SAPId, OldPartNum, ThridPartyPartNum, Priority, Instrument, SalesType, Category, SubCategory," +
                            " Description, SAPDescription, DetailDescription, PLDescription, PLDetailDescription, PlPrice, Grids, SerialPorts, USBPorts," +
                            " StandarPrice, ILP, ASP, ManufacturingCost, X_Dimension, Y_Dimension, Z_Dimension, Z_DimensionNote, CreateDate, RemoveDate, DBMembership," +
                            " NotMasterPriceList, ThridParty, Notes, SSPCategory, Compatibility)" +
                            " Values " +
                            "(@Lab, @SAPId, @OldPartNum, @ThridPartyPartNum, @Priority, @Instrument, @SalesType, @Category, @SubCategory, " +
                            "@Description, @SAPDescription, @DetailDescription, @PLDescription, @PLDetailDescription, @PlPrice, @Grids, @SerialPorts, @USBPorts, " +
                            "@StandarPrice, @ILP, @ASP, @ManufacturingCost, @X_Dimension, @Y_Dimension, @Z_Dimension, @Z_DimensionNote, @CreateDate, @RemoveDate, " +
                            "@DBMembership, @NotMasterPriceList, @ThridParty, @Notes, @SSPCategory, @Compatibility)";


                        scmd.Parameters.AddWithValue("@Lab", Lab);
                        scmd.Parameters.AddWithValue("@SAPId", SAPId);
                        scmd.Parameters.AddWithValue("@OldPartNum", OldPartNum);
                        scmd.Parameters.AddWithValue("@ThridPartyPartNum", ThridPartyPartNum);
                        scmd.Parameters.AddWithValue("@Priority", Priority);
                        scmd.Parameters.AddWithValue("@Instrument", Instrument);
                        scmd.Parameters.AddWithValue("@SalesType", SalesType);
                        scmd.Parameters.AddWithValue("@Category", Category);
                        scmd.Parameters.AddWithValue("@SubCategory", SubCategory);
                        scmd.Parameters.AddWithValue("@Description", Description);
                        scmd.Parameters.AddWithValue("@SAPDescription", SAPDescription);
                        scmd.Parameters.AddWithValue("@DetailDescription", DetailDescription);
                        scmd.Parameters.AddWithValue("@PLDescription", PLDescription); // This field is used for PL Additional Info
                        scmd.Parameters.AddWithValue("@PLDetailDescription", PLDetailDescription); // This field is being used as the Tecan Only Data Field
                        scmd.Parameters.AddWithValue("@PlPrice", PlPrice);
                        scmd.Parameters.AddWithValue("@Grids", Grids);
                        scmd.Parameters.AddWithValue("@SerialPorts", SerialPorts);
                        scmd.Parameters.AddWithValue("@USBPorts", USBPorts);
                        scmd.Parameters.AddWithValue("@StandarPrice", StandarPrice);
                        scmd.Parameters.AddWithValue("@ILP", ILP);
                        scmd.Parameters.AddWithValue("@ASP", ASP);
                        scmd.Parameters.AddWithValue("@ManufacturingCost", ManufacturingCost);
                        scmd.Parameters.AddWithValue("@X_Dimension", X_Dimension);
                        scmd.Parameters.AddWithValue("@Y_Dimension", Y_Dimension);
                        scmd.Parameters.AddWithValue("@Z_Dimension", Z_Dimension);
                        scmd.Parameters.AddWithValue("@Z_DimensionNote", Z_DimensionNote);
                        if (CreateDate != null)
                        {
                            scmd.Parameters.AddWithValue("@CreateDate", CreateDate);
                        }
                        else
                        {
                            scmd.Parameters.AddWithValue("@CreateDate", "01/01/01");
                        }
                        if (RemoveDate != null)
                        {
                            scmd.Parameters.AddWithValue("@RemoveDate", RemoveDate);
                        }
                        else
                        {
                            scmd.Parameters.AddWithValue("@RemoveDate", "01/01/01");
                        }
                        scmd.Parameters.AddWithValue("@DBMembership", DBMembership);
                        scmd.Parameters.AddWithValue("@NotMasterPriceList", NotMasterPriceList);
                        scmd.Parameters.AddWithValue("@ThridParty", ThridParty);
                        scmd.Parameters.AddWithValue("@Notes", Notes);
                        scmd.Parameters.AddWithValue("@SSPCategory", SSPCategory);
                        scmd.Parameters.AddWithValue("@Compatibility", Compatibility);

                        scmd.ExecuteNonQuery();
                        scmd.Parameters.Clear();
                        statusProgressBar.Value = statusProgressBar.Value + 1;
                        SSpartsListBox.Items.Add(SAPId + " - ' " + Description);
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Parts " + ex.Message);
                }
                finally
                {
                    //                    TecanDatabase.Close();
                }

                //
                // Add Notes from files to database
                statusPanelLabel.Text = "Adding Notes";
                statusProgressBar.Value = 0;

                String filePath, fileData;
                String[] fileList;

                filePath = getNotesFilePath();

                fileList = Directory.GetFiles(filePath);

                int ExtPosition, NamePosition;
                String sapId;
                foreach (string fileName in fileList)
                {
                    StreamReader fileContents = new StreamReader(fileName);
                    fileData = fileContents.ReadToEnd();
                    fileContents.Close();

                    NamePosition = filePath.Length + 1;
                    ExtPosition = fileName.IndexOf(".");
                    sapId = fileName.Substring(NamePosition, (ExtPosition - NamePosition));

                    pcmd.CommandText = "UPDATE PartsList SET [NotesFromFile] = @fileData WHERE [SAPId] = '" + sapId + "'";
                    pcmd.Parameters.AddWithValue("@fileData", fileData);

                    scmd.CommandText = "UPDATE PartsList SET [NotesFromFile] = @fileData WHERE [SAPId] = '" + sapId + "'";
                    scmd.Parameters.AddWithValue("@fileData", fileData);

                    try
                    {
                        pcmd.ExecuteNonQuery();
                        scmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Notes " + ex.Message);
                    }
                                        
                    pcmd.Parameters.Clear();
                    scmd.Parameters.Clear();
                    statusProgressBar.Value = statusProgressBar.Value + 1;
                }

                //
                // Add Images to database
                statusPanelLabel.Text = "Adding Images";
                statusProgressBar.Value = 0;
                String imagePath, imageFileName, imageExt;
                Byte[] imageData;
                long imageNumBytes;
                String[] imageList;

                imagePath = getImagePath();

                imageList = Directory.GetFiles(imagePath);

                int docID;
                docID = 1;
                String imageSapId;
                foreach (string imagePathandName in imageList)
                {
                    FileInfo imageFileInfo = new FileInfo(imagePathandName);
                    imageNumBytes = imageFileInfo.Length;
                    FileStream imageContents = new FileStream(imagePathandName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(imageContents);
                    imageData = br.ReadBytes((int)imageNumBytes); 
                    imageContents.Close();

                    imageFileName = imageFileInfo.Name.ToLower();
                    imageExt = imageFileInfo.Extension.Replace(".", "").ToLower();
                    imageSapId = imageFileName.Replace("." + imageExt, "");
                    
                    pcmd.CommandText = "INSERT INTO PartImages (DocID, DocExtension, SAPId, Document, FileName)" +
                        " Values " +
                        "(@DocID, @DocExtension, @SAPId, @Document, @FileName)";

                    pcmd.Parameters.AddWithValue("@DocId", docID);
                    pcmd.Parameters.AddWithValue("@DocExtension", imageExt);
                    pcmd.Parameters.AddWithValue("@SAPId", imageSapId);
                    pcmd.Parameters.AddWithValue("@Document", imageData);
                    pcmd.Parameters.AddWithValue("@FileName", imageFileName);

                    scmd.CommandText = "INSERT INTO PartImages (DocID, DocExtension, SAPId, Document, FileName)" +
                       " Values " +
                       "(@DocID, @DocExtension, @SAPId, @Document, @FileName)";

                    scmd.Parameters.AddWithValue("@DocId", docID);
                    scmd.Parameters.AddWithValue("@DocExtension", imageExt);
                    scmd.Parameters.AddWithValue("@SAPId", imageSapId);
                    scmd.Parameters.AddWithValue("@Document", imageData);
                    scmd.Parameters.AddWithValue("@FileName", imageFileName);
                    
                    try
                    {
                        pcmd.ExecuteNonQuery();
                        scmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Images " + ex.Message);
                    }
                    
                    pcmd.Parameters.Clear();
                    scmd.Parameters.Clear();
                    imageContents.Dispose();
                    // br.Dispose();
                    docID++;
                    statusProgressBar.Value = statusProgressBar.Value + 1;
                }

                loadSuppumentalDocs();

                // Associate Supplement Docs
                statusPanelLabel.Text = "Associating Supplemental Documents";
                // statusProgressBar.Value = 0;

                String suppSAPID;
                String suppFilename;
                String suppFileNameVerification;

                // Open Supplement Documents Database
                SqlCeConnection TecanSuppDatabase = null;
                TecanSuppDatabase = new SqlCeConnection();
                // String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                TecanSuppDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanSuppDocs.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
                TecanSuppDatabase.Open();
                SqlCeCommand suppCmd = TecanSuppDatabase.CreateCommand();

                query = "SELECT [SAP ID], [File] FROM [Supplemental File List] ORDER BY [SAP ID]";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    OdbcDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        suppSAPID = reader[0].ToString();
                        suppFilename = reader[1].ToString();
                        suppFileNameVerification = "";
                        suppCmd.CommandText = "SELECT [FileName] FROM SuppumentalDocs WHERE [FileName] = '" + suppFilename + "'";
                        try
                        {
                            suppFileNameVerification = (String)suppCmd.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Associate Supplement Docs 2 " + ex.Message);
                        }
                        if(suppFileNameVerification != "")
                        {
                            pcmd.CommandText = "INSERT INTO SuppumentalDocs (SAPId, FileName) Values (@SAPId, @FileName)";

                            pcmd.Parameters.AddWithValue("@SAPId", suppSAPID);
                            pcmd.Parameters.AddWithValue("@FileName", suppFilename);

                            try
                            {
                                pcmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Associate Supplement Docs 3 " + ex.Message);
                            }


                            scmd.CommandText = "INSERT INTO SuppumentalDocs (SAPId, FileName) Values (@SAPId, @FileName)";

                            scmd.Parameters.AddWithValue("@SAPId", suppSAPID);
                            scmd.Parameters.AddWithValue("@FileName", suppFilename);

                            try
                            {
                                scmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Associate Supplement Docs 3 " + ex.Message);
                            }
                            scmd.Parameters.Clear();
                            pcmd.Parameters.Clear();
                            supplementalDocsListBox.Items.Add(suppSAPID + " - ' " + suppFilename);
                        }
                    }
                    reader.Close();
                    reader.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Associate Supplement Docs 1 " + ex.Message);
                }
                TecanSuppDatabase.Close();

                //
                // Add CAD info to parts
                statusPanelLabel.Text = "Adding CAD Information";
                statusProgressBar.Value = 0;

                DataSet ds = new DataSet();
                ds = ReadCADFile();
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                String CADInfo;
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow drow = dt.Rows[i];
                    CADInfo = drow["Description"].ToString() + "^" + drow["CAD"].ToString();

                    pcmd.CommandText = "UPDATE PartsList SET [CADInfo] = @CAD WHERE [SAPId] = '" + drow["Material"].ToString() + "'";
                    pcmd.Parameters.AddWithValue("@CAD", CADInfo);

                    scmd.CommandText = "UPDATE PartsList SET [CADInfo] = @CAD WHERE [SAPId] = '" + drow["Material"].ToString() + "'";
                    scmd.Parameters.AddWithValue("@CAD", CADInfo);

                    try
                    {
                        pcmd.ExecuteNonQuery();
                        scmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("CAD " + ex.Message);
                    }
                    statusProgressBar.Value = statusProgressBar.Value + 1;
                    pcmd.Parameters.Clear();
                    scmd.Parameters.Clear();
                }
                TecanPartsDatabase.Close();
                TecanSmartStartDatabase.Close();

                statusProgressBar.Visible = false;
                ImportStatusLabel.Text = "Import Complete!";
                if (EmptyLookupField)
                {
                    MessageBox.Show("Note items that have blank values.\nThese items can be filtered from the Main Part List screen!");
                }

                // this.partsListTableAdapter.Fill(this.tecanPartsListDataSet.PartsList);
                // this.Close();
            }
        }

        //public class Compatibilites
        //{
        //    private string CompatibilityID;
        //    private string CompatibilityAbbv;
        //    private string CompatibilityName;

        //    public Compatibilites(string strName, string strAbbv, string strID)
        //    {
        //        this.CompatibilityID = strID;
        //        this.CompatibilityAbbv = strAbbv;
        //        this.CompatibilityName = strName;
        //    }

        //    public string ID
        //    {
        //        get
        //        {
        //            return CompatibilityID;
        //        }
        //    }

        //    public string Abbv
        //    {

        //        get
        //        {
        //            return CompatibilityAbbv;
        //        }
        //    }

        //    public string Name
        //    {

        //        get
        //        {
        //            return CompatibilityName;
        //        }
        //    }

        //}

        // Add Supplemental Documents to database
        private void loadSuppumentalDocs()
        {
            statusPanelLabel.Text = "Adding Supplemental Documents";
            statusProgressBar.Value = 0;
            SqlCeConnection TecanSuppDatabase = null;
            TecanSuppDatabase = new SqlCeConnection();
            // String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            TecanSuppDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanSuppDocs.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanSuppDatabase.Open();
            SqlCeCommand cmd = TecanSuppDatabase.CreateCommand();

            int docID;
            docID = 1;
            String suppumentalPath, suppumentalFileName, suppumentalExt;
            Byte[] suppumentalData;
            long suppumentalNumBytes;
            String[] suppumentalList;

            suppumentalPath = getSuppumentalPath();
            suppumentalList = Directory.GetFiles(suppumentalPath);

            foreach (string suppumentalPathandName in suppumentalList)
            {
                FileInfo suppumentalFileInfo = new FileInfo(suppumentalPathandName);
                suppumentalNumBytes = suppumentalFileInfo.Length;
                FileStream suppumentalContents = new FileStream(suppumentalPathandName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(suppumentalContents);
                suppumentalData = br.ReadBytes((int)suppumentalNumBytes);
                suppumentalContents.Close();

                suppumentalFileName = suppumentalFileInfo.Name.ToLower();
                suppumentalExt = suppumentalFileInfo.Extension.Replace(".", "").ToLower();
                cmd.CommandText = "INSERT INTO SuppumentalDocs (DocID, DocExtension, Document, FileName)" +
                    " Values " +
                    "(@DocID, @DocExtension, @Document, @FileName)";

                cmd.Parameters.AddWithValue("@DocId", docID);
                cmd.Parameters.AddWithValue("@DocExtension", suppumentalExt);
                cmd.Parameters.AddWithValue("@Document", suppumentalData);
                cmd.Parameters.AddWithValue("@FileName", suppumentalFileName);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please correct the Supplemental Filename and add to database manually \n\n " + suppumentalFileName + "\n\n" + ex.Message + "\n\n" + ex.TargetSite);
                }
                cmd.Parameters.Clear();
                suppumentalContents.Dispose();
                // br.Dispose();
                docID++;
                statusProgressBar.Value = statusProgressBar.Value + 1;
            }
            TecanSuppDatabase.Close();
        }

        // Read Excel File for CAD Information
        private DataSet ReadCADFile()
        {
            DataSet ds = new DataSet();

            string connectionString = GetExcelConnection();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;

                // Get all Sheets in Excel File
                DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                // Loop through all Sheets to get data
                foreach (DataRow dr in dtSheet.Rows)
                {
                    string sheetName = dr["TABLE_NAME"].ToString();

                    if (!sheetName.EndsWith("$"))
                        continue;

                    // Get all rows from the Sheet
                    cmd.CommandText = "SELECT * FROM [" + sheetName + "]";

                    DataTable dt = new DataTable();
                    dt.TableName = sheetName;

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    ds.Tables.Add(dt);
                }

                cmd = null;
                conn.Close();
            }
            return ds;
        }

        // Add Template Documents to database
        // todo
        private void loadTemplateDocs()
        {
            statusPanelLabel.Text = "Adding Quote Templates";
            statusProgressBar.Value = 0;
            SqlCeConnection TecanAppDocsDatabase = null;
            TecanAppDocsDatabase = new SqlCeConnection();
            // String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            TecanAppDocsDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanAppDocs.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanAppDocsDatabase.Open();
            SqlCeCommand cmd = TecanAppDocsDatabase.CreateCommand();

            int docID;
            docID = 1;
            String suppumentalPath, suppumentalFileName, suppumentalExt;
            Byte[] suppumentalData;
            long suppumentalNumBytes;
            String[] suppumentalList;

            suppumentalPath = getSuppumentalPath();
            suppumentalList = Directory.GetFiles(suppumentalPath);

            foreach (string suppumentalPathandName in suppumentalList)
            {
                FileInfo suppumentalFileInfo = new FileInfo(suppumentalPathandName);
                suppumentalNumBytes = suppumentalFileInfo.Length;
                FileStream suppumentalContents = new FileStream(suppumentalPathandName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(suppumentalContents);
                suppumentalData = br.ReadBytes((int)suppumentalNumBytes);
                suppumentalContents.Close();

                suppumentalFileName = suppumentalFileInfo.Name.ToLower();
                suppumentalExt = suppumentalFileInfo.Extension.Replace(".", "").ToLower();
                cmd.CommandText = "INSERT INTO SuppumentalDocs (DocID, DocExtension, Document, FileName)" +
                    " Values " +
                    "(@DocID, @DocExtension, @Document, @FileName)";

                cmd.Parameters.AddWithValue("@DocId", docID);
                cmd.Parameters.AddWithValue("@DocExtension", suppumentalExt);
                cmd.Parameters.AddWithValue("@Document", suppumentalData);
                cmd.Parameters.AddWithValue("@FileName", suppumentalFileName);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please correct the Supplemental Filename and add to database manually \n\n " + suppumentalFileName + "\n\n" + ex.Message + "\n\n" + ex.TargetSite);
                }
                cmd.Parameters.Clear();
                suppumentalContents.Dispose();
                // br.Dispose();
                docID++;
                statusProgressBar.Value = statusProgressBar.Value + 1;
            }
            TecanAppDocsDatabase.Close();
        }

        private string GetExcelConnection()
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            // XLSX - Excel 2007, 2010, 2012, 2013
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
            props["Extended Properties"] = "Excel 12.0 XML";
            props["Data Source"] = getCADFilePath(); ;

            // XLS - Excel 2003 and Older
            //props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            //props["Extended Properties"] = "Excel 8.0";
            //props["Data Source"] = "C:\\MyExcel.xls";

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }
            return sb.ToString();

        }

        private string getCADFilePath()
        {
            String filePath;

            // Get Database Filename and Path
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Please select your latest CAD Excel File";
            openFileDialog1.InitialDirectory = LastFilePath;
            openFileDialog1.Filter = "xls files (*.xls)|*.xls|xlsx files (*.xlsx)|*.xlsx";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                return filePath;
            }
            else
            {
                return "";
            }
        }

        private string getConnection()
        {
            String myConnection;
            String filePath;

            // Get Database Filename and Path
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Please select your latest Access Database used to Add and Edit Parts";
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "mdb files (*.mdb)|*.mdb|accdb files (*.accdb)|*.accdb";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                //if(Path.GetExtension(openFileDialog1.FileName) == "mdb")
                //{
                //    // mdb file
                //    myConnection = @"Driver={Microsoft Access Driver (*.mdb)};" + "Dbq=" + filePath;
                //} else {
                //    // accdb file
                    myConnection = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};" + "Dbq=" + filePath;
//                }
                LastFilePath = Path.GetDirectoryName(filePath);
                return myConnection;
            }
            else
            {
                return "";
            }
        }

        private short getLookupTableValue(string LookupString, DataTable whichTable)
        {
            int dataIndex;
            dataIndex = 1;
            foreach (DataRow tableRow in whichTable.Rows)
            {
                if (LookupString == tableRow["Name"].ToString())
                {
                    dataIndex = Convert.ToInt16(tableRow["ID"]);
                    break;
                }
            }
            return (short)dataIndex;
        }

        



        //private short getInstrument(string p)
        //{

        //    int dataIndex;
        //    dataIndex = 1;
        //    foreach (DataRowView s in instrumentListBox.Items)
        //    {
        //        string dataTest;
        //        dataTest = s.Row.ItemArray[1].ToString();
        //        if (dataTest == p)
        //        {
        //            dataIndex = Convert.ToInt16(s.Row.ItemArray[0]);
        //            break;
        //        }
        //    }

        //    return (short)dataIndex;
        //}

        //private short getCategory(string p)
        //{

        //    int dataIndex;
        //    dataIndex = 1;
        //    foreach (DataRowView s in categoryListBox.Items)
        //    {
        //        string dataTest;
        //        dataTest = s.Row.ItemArray[1].ToString();
        //        if (dataTest == p)
        //        {
        //            dataIndex = Convert.ToInt16(s.Row.ItemArray[0]);
        //            break;
        //        }
        //    }

        //    return (short)dataIndex;
        //}

        //private short getSubCategory(string p)
        //{
        //    int dataIndex;
        //    dataIndex = 1;
        //    foreach (DataRowView s in subCategoryListBox.Items)
        //    {
        //        string dataTest;
        //        dataTest = s.Row.ItemArray[1].ToString();
        //        if (dataTest == p)
        //        {
        //            dataIndex = Convert.ToInt16(s.Row.ItemArray[0]);
        //            break;
        //        }
        //    }

        //    return (short)dataIndex;
        //}

        //private short getSSPCategory(string p)
        //{

        //    int dataIndex;
        //    dataIndex = 1;
        //    foreach (DataRowView s in sspCategoryListBox.Items)
        //    {
        //        string dataTest;
        //        dataTest = s.Row.ItemArray[1].ToString();
        //        if (dataTest == p)
        //        {
        //            dataIndex = Convert.ToInt16(s.Row.ItemArray[0]);
        //            break;
        //        }
        //    }

        //    return (short)dataIndex;
        //}

        private String getCompatibility(string p)
        {
            String strCompatibility = "";
            foreach (Compatibilities s in theCompatibilities)
            {
                String dataTest;
                dataTest = s.Abbv;
                if (p.IndexOf(dataTest) != -1)
                {
                    if (strCompatibility == "")
                    {
                        strCompatibility = s.ID;
                    }
                    else
                    {
                        strCompatibility = strCompatibility + "," + s.ID;
                    }
                }
            }
            return strCompatibility;
        }
       
        //private short getSalesType(string p)
        //{

        //    int dataIndex;
        //    dataIndex = 1;
        //    foreach (DataRowView s in salesTypeListBox.Items)
        //    {
        //        string dataTest;
        //        dataTest = s.Row.ItemArray[1].ToString();
        //        if (dataTest == p)
        //        {
        //            dataIndex = Convert.ToInt16(s.Row.ItemArray[0]);
        //            break;
        //        }
        //    }

        //    return (short)dataIndex;
        //}

        //private short getDBMembership(string p)
        //{

        //    int dataIndex;
        //    dataIndex = 1;
        //    foreach (DataRowView s in dBMembershipListBox.Items)
        //    {
        //        string dataTest;
        //        dataTest = s.Row.ItemArray[1].ToString();
        //        if (dataTest == p)
        //        {
        //            dataIndex = Convert.ToInt16(s.Row.ItemArray[0]);
        //            break;
        //        }
        //    }

        //    return (short)dataIndex;
        //}


        private String getNotesFilePath()
        {

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Please select your Partslist Notes folder";
            folderBrowserDialog1.SelectedPath = LastFilePath;
            folderBrowserDialog1.ShowNewFolderButton = false;

            String myPath = "";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                myPath = folderBrowserDialog1.SelectedPath;
            }
            
            return myPath;

        }

        private String getImagePath()
        {

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Please select your Partslist Image folder";
            folderBrowserDialog1.SelectedPath = LastFilePath;
            folderBrowserDialog1.ShowNewFolderButton = false;

            String myPath = "";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                myPath = folderBrowserDialog1.SelectedPath;
            }

            return myPath;

        }

        private String getSuppumentalPath()
        {

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Please select your Partslist Supplemental Files folder";
            folderBrowserDialog1.SelectedPath = LastFilePath;
            folderBrowserDialog1.ShowNewFolderButton = false;

            String myPath = "";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                myPath = folderBrowserDialog1.SelectedPath;
            }

            return myPath;

        }

        private void importAccessDatabaseCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
