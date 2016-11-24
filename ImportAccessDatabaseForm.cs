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

        private void ImportAccessDatabaseForm_Shown(Object sender, EventArgs e)
        {
            if (MessageBox.Show("This will delete the current Parts List and Replace it with your selected Access Database.\r\n\r\nDo you want to proceed?", "Import Database", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.Close();
                mainForm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                SqlCeConnection TecanDatabase = null;
                try
                {
                    TecanDatabase = new SqlCeConnection();
//                    String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                    TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
                    TecanDatabase.Open();

                    SqlCeCommand cmd = TecanDatabase.CreateCommand();
                    cmd.CommandText = "DELETE FROM PartsList";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM Category";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM Compatibility";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM DBMembership";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM Instrument";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM PartImages";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM RequiredParts";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM OptionalParts";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM SalesType";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM SSPCategory";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM SubCategory";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM SuppumentalDocs";
                    cmd.ExecuteNonQuery();
                    TecanDatabase.Close();

                    TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanSuppDocs.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
                    TecanDatabase.Open();
                    cmd.CommandText = "DELETE FROM SuppumentalDocs";
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    TecanDatabase.Close();
                }
                loadDatabase();
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
            //             mainForm.MainPartsListDisplay_Load(sender, e);
        }

        private void ImportAccessDatabaseForm_Close(object sender, EventArgs e)
        {
            Validate();
            partsListBindingSource.EndEdit();
            tableAdapterManager.UpdateAll(this.tecanPartsListDataSet);
            mainForm.WindowState = FormWindowState.Maximized;
            mainForm.MainPartsListDisplay_Load(sender, e);
        }

        private void loadDatabase()
        {

            String myAccessDatabaseConnectionString;
            myAccessDatabaseConnectionString = getConnection();
            while (myAccessDatabaseConnectionString == "")
            {
                MessageBox.Show("All Data has already been Deleted!\r\n\r\nPlease select a Parts List File?", "Select an Import Database");
                {
                    myAccessDatabaseConnectionString = getConnection();
                }
            }

            SqlCeConnection TecanDatabase = null;

            using (OdbcConnection myConnection = new OdbcConnection(myAccessDatabaseConnectionString))
            {
                // Open Databases

                // New Tecan Database
                TecanDatabase = new SqlCeConnection();
                // String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
                TecanDatabase.Open();
                SqlCeCommand cmd = TecanDatabase.CreateCommand();

                // Access Database
                myConnection.Open();

                // Add DB Membership
                statusPanelLabel.Text = "Database Membership";
                statusProgressBar.Value = 0;
                statusProgressBar.Maximum = 500;

                // Put first entry into table for search purposes
                cmd.CommandText = "INSERT INTO DBMembership (DBID, DBName) Values (0, 'Any')";
                cmd.ExecuteNonQuery();

                string query = "SELECT DISTINCT [Database Membership] from Parts ORDER BY [Database Membership]";
                OdbcCommand command = new OdbcCommand(query, myConnection);
                String rowData;
                short rowCount;
                try
                {

                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        if(rowData.Length > 0) rowData = char.ToUpper(rowData[0]) + rowData.Substring(1);
                        if (rowData == "") rowData = "Removed";
                        cmd.CommandText = "INSERT INTO DBMembership (DBID, DBName) Values (" + rowCount + ", '" + rowData + "')";
                        cmd.ExecuteNonQuery();
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DBMembership " + ex.Message);
                }
                this.dBMembershipTableAdapter.Fill(this.tecanPartsListDataSet.DBMembership);
                
                // Add Instruments (Platform)
                statusPanelLabel.Text = "Instruments";
                statusProgressBar.Value = 0;

                // Put first entry into table for search purposes
                cmd.CommandText = "INSERT INTO Instrument (InstrumentID, InstrumentName) Values (0, 'Any')";
                cmd.ExecuteNonQuery();

                query = "SELECT DISTINCT Platform from Parts ORDER BY Platform";
                command = new OdbcCommand(query, myConnection);
                try
                {

                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        cmd.CommandText = "INSERT INTO Instrument (InstrumentID, InstrumentName) Values (" + rowCount + ", '" + rowData + "')";
                        cmd.ExecuteNonQuery();
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Instrument " + ex.Message);
                }
                this.instrumentTableAdapter.Fill(this.tecanPartsListDataSet.Instrument);

                // Add Categories
                statusPanelLabel.Text = "Categories";
                statusProgressBar.Value = 0;

                // Put first entry into table for search purposes
                cmd.CommandText = "INSERT INTO Category (CategoryID, CategoryName) Values (0, 'Any')";
                cmd.ExecuteNonQuery();

                query = "SELECT DISTINCT Category from Parts ORDER BY Category";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        cmd.CommandText = "INSERT INTO Category (CategoryID, CategoryName) Values (" + rowCount + ", '" + rowData + "')";
                        cmd.ExecuteNonQuery();
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Category " + ex.Message);
                }
                this.categoryTableAdapter.Fill(this.tecanPartsListDataSet.Category);


                // Add Sub Categories
                statusPanelLabel.Text = "Sub Categories";
                statusProgressBar.Value = 0;

                // Put first entry into table for search purposes
                cmd.CommandText = "INSERT INTO SubCategory (SubCategoryID, SubCategoryName) Values (0, 'Any')";
                cmd.ExecuteNonQuery();

                query = "SELECT DISTINCT Subcategory from Parts ORDER BY Subcategory";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        cmd.CommandText = "INSERT INTO SubCategory (SubCategoryID, SubCategoryName) Values (" + rowCount + ", '" + rowData + "')";
                        cmd.ExecuteNonQuery();
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SubCategory " + ex.Message);
                }
                this.subCategoryTableAdapter.Fill(this.tecanPartsListDataSet.SubCategory);

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
                        cmd.CommandText = "INSERT INTO Compatibility (CompatibilityID, CompatibilityName) Values (" + rowCount + ", '" + rowCompatibility + "')";
                        cmd.ExecuteNonQuery();
                        theCompatibilities.Add(new Compatibilites(rowCompatibility, rowCompatibilityAbbv, rowCount.ToString()));
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Compatibility " + ex.Message);
                }
                
                // Add Sales Types
                statusPanelLabel.Text = "Sales Types";
                statusProgressBar.Value = 0;

                // Put first entry into table for search purposes
                cmd.CommandText = "INSERT INTO SalesType (SalesTypeID, SalesTypeName) Values (0, 'Any')";
                cmd.ExecuteNonQuery();

                query = "SELECT DISTINCT [Sales Type] from Parts ORDER BY [Sales Type]";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        if (rowData.Length > 0) rowData = char.ToUpper(rowData[0]) + rowData.Substring(1);
                        cmd.CommandText = "INSERT INTO SalesType (SalesTypeID, SalesTypeName) Values (" + rowCount + ", '" + rowData + "')";
                        cmd.ExecuteNonQuery();
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SalesType " + ex.Message);
                }
                this.salesTypeTableAdapter.Fill(this.tecanPartsListDataSet.SalesType);


                // Add SSP Categories
                statusPanelLabel.Text = "SSP Categories";
                statusProgressBar.Value = 0;

                query = "SELECT DISTINCT [SSP_Category] from Parts ORDER BY [SSP_Category]";
                command = new OdbcCommand(query, myConnection);
                try
                {
                    OdbcDataReader reader = command.ExecuteReader();
                    rowCount = 1;
                    while (reader.Read())
                    {
                        rowData = reader[0].ToString();
                        if (rowData.Length > 0) rowData = char.ToUpper(rowData[0]) + rowData.Substring(1);
                        cmd.CommandText = "INSERT INTO SSPCategory (SSPCategoryId, SSPCategoryName) Values (" + rowCount + ", '" + rowData + "')";
                        cmd.ExecuteNonQuery();
                        rowCount++;
                        statusProgressBar.Value = rowCount;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("My SSP Categories " + ex.Message);
                }
                this.sspCategoryTableAdapter.Fill(this.tecanPartsListDataSet.SSPCategory);

                // Add Parts
                statusPanelLabel.Text = "Adding Parts";
                statusProgressBar.Value = 0;
                statusProgressBar.Maximum = 6000; // todo find better way to set progress bar max value associated with record count

                query = @"SELECT [Lab/Office], [SAP ID], [Old Part Number], [3rd Party Part Number], [Priority], [Platform], [Sales Type], [Category], [Subcategory], 
                                [Desc], [SAP Desc], [Detail Desc], [PL Desc], [PL Detail Desc], [PL Price], [grids], [Serial Ports], [USB Ports], [Standard Price], 
                                [ILP], [ASP], [Manuf Cost], [x_dimension], [y_dimension], [z_dimension], [createdate], [removaldate], [Database Membership], 
                                [Not in Master Price List], [3rd Party], [Notes], [SSP_Category], [System Compatibility] from Parts ORDER BY [SAP ID]";

                command = new OdbcCommand(query, myConnection);

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
                        Instrument = getInstrument(reader[5].ToString());
                        // Get Sales Type Lookup Value
                        if (reader[6].ToString() != "")
                        {
                            SalesType = getSalesType(char.ToUpper(reader[6].ToString()[0]) + reader[6].ToString().Substring(1));
                        }
                        else
                        {
                            SalesType = getSalesType(reader[6].ToString());
                        }
                        // Get Category Lookup Value
                        Category = getCategory(reader[7].ToString());
                        // Get SubCategory Lookup Value
                        SubCategory = getSubCategory(reader[8].ToString());
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
                            DBMembership = getDBMembership(char.ToUpper(reader[27].ToString()[0]) + reader[27].ToString().Substring(1));
                        }
                        else
                        {
                            DBMembership = getDBMembership(reader[27].ToString());
                        }
                        
                        NotMasterPriceList = Convert.ToBoolean(reader[28].ToString());
                        ThridParty = Convert.ToBoolean(reader[29].ToString());
                        Notes = reader[30].ToString();
                        // Get SSPCategory Lookup Value
                        SSPCategory = getSSPCategory(reader[31].ToString());
                        Compatibility = getCompatibility(reader[32].ToString());

                        cmd.CommandText = "INSERT INTO PartsList (Lab, SAPId, OldPartNum, ThridPartyPartNum, Priority, Instrument, SalesType, Category, SubCategory," +
                            " Description, SAPDescription, DetailDescription, PLDescription, PLDetailDescription, PlPrice, Grids, SerialPorts, USBPorts," +
                            " StandarPrice, ILP, ASP, ManufacturingCost, X_Dimension, Y_Dimension, Z_Dimension, Z_DimensionNote, CreateDate, RemoveDate, DBMembership," +
                            " NotMasterPriceList, ThridParty, Notes, SSPCategory, Compatibility)" +
                            " Values " +
                            "(@Lab, @SAPId, @OldPartNum, @ThridPartyPartNum, @Priority, @Instrument, @SalesType, @Category, @SubCategory, " +
                            "@Description, @SAPDescription, @DetailDescription, @PLDescription, @PLDetailDescription, @PlPrice, @Grids, @SerialPorts, @USBPorts, " +
                            "@StandarPrice, @ILP, @ASP, @ManufacturingCost, @X_Dimension, @Y_Dimension, @Z_Dimension, @Z_DimensionNote, @CreateDate, @RemoveDate, " +
                            "@DBMembership, @NotMasterPriceList, @ThridParty, @Notes, @SSPCategory, @Compatibility)";


                        cmd.Parameters.AddWithValue("@Lab", Lab);
                        cmd.Parameters.AddWithValue("@SAPId", SAPId);
                        cmd.Parameters.AddWithValue("@OldPartNum", OldPartNum);
                        cmd.Parameters.AddWithValue("@ThridPartyPartNum", ThridPartyPartNum);
                        cmd.Parameters.AddWithValue("@Priority", Priority);
                        cmd.Parameters.AddWithValue("@Instrument", Instrument);
                        cmd.Parameters.AddWithValue("@SalesType", SalesType);
                        cmd.Parameters.AddWithValue("@Category", Category);
                        cmd.Parameters.AddWithValue("@SubCategory", SubCategory);
                        cmd.Parameters.AddWithValue("@Description", Description);
                        cmd.Parameters.AddWithValue("@SAPDescription", SAPDescription);
                        cmd.Parameters.AddWithValue("@DetailDescription", DetailDescription);
                        cmd.Parameters.AddWithValue("@PLDescription", PLDescription); // This field is used for PL Additional Info
                        cmd.Parameters.AddWithValue("@PLDetailDescription", PLDetailDescription); // This field is being used as the Tecan Only Data Field
                        cmd.Parameters.AddWithValue("@PlPrice", PlPrice);
                        cmd.Parameters.AddWithValue("@Grids", Grids);
                        cmd.Parameters.AddWithValue("@SerialPorts", SerialPorts);
                        cmd.Parameters.AddWithValue("@USBPorts", USBPorts);
                        cmd.Parameters.AddWithValue("@StandarPrice", StandarPrice);
                        cmd.Parameters.AddWithValue("@ILP", ILP);
                        cmd.Parameters.AddWithValue("@ASP", ASP);
                        cmd.Parameters.AddWithValue("@ManufacturingCost", ManufacturingCost);
                        cmd.Parameters.AddWithValue("@X_Dimension", X_Dimension);
                        cmd.Parameters.AddWithValue("@Y_Dimension", Y_Dimension);
                        cmd.Parameters.AddWithValue("@Z_Dimension", Z_Dimension);
                        cmd.Parameters.AddWithValue("@Z_DimensionNote", Z_DimensionNote);
                        if (CreateDate != null)
                        {
                            cmd.Parameters.AddWithValue("@CreateDate", CreateDate);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@CreateDate", "01/01/01");
                        }
                        if (RemoveDate != null)
                        {
                            cmd.Parameters.AddWithValue("@RemoveDate", RemoveDate);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@RemoveDate", "01/01/01");
                        }
                        cmd.Parameters.AddWithValue("@DBMembership", DBMembership);
                        cmd.Parameters.AddWithValue("@NotMasterPriceList", NotMasterPriceList);
                        cmd.Parameters.AddWithValue("@ThridParty", ThridParty);
                        cmd.Parameters.AddWithValue("@Notes", Notes);
                        cmd.Parameters.AddWithValue("@SSPCategory", SSPCategory);
                        cmd.Parameters.AddWithValue("@Compatibility", Compatibility);
                        
                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();
                        statusProgressBar.Value = statusProgressBar.Value + 1;
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

                    cmd.CommandText = "UPDATE PartsList SET [NotesFromFile] = @fileData WHERE [SAPId] = '" + sapId + "'";
                    cmd.Parameters.AddWithValue("@fileData", fileData);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Notes " + ex.Message);
                    }
                                        
                    cmd.Parameters.Clear();
                    statusProgressBar.Value = statusProgressBar.Value + 1;
                }


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
                    
                    cmd.CommandText = "INSERT INTO PartImages (DocID, DocExtension, SAPId, Document, FileName)" +
                        " Values " +
                        "(@DocID, @DocExtension, @SAPId, @Document, @FileName)";

                    cmd.Parameters.AddWithValue("@DocId", docID);
                    cmd.Parameters.AddWithValue("@DocExtension", imageExt);
                    cmd.Parameters.AddWithValue("@SAPId", imageSapId);
                    cmd.Parameters.AddWithValue("@Document", imageData);
                    cmd.Parameters.AddWithValue("@FileName", imageFileName);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Images " + ex.Message);
                    }
                    
                    cmd.Parameters.Clear();
                    imageContents.Dispose();
                    br.Dispose();
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
                            cmd.CommandText = "INSERT INTO SuppumentalDocs (SAPId, FileName) Values (@SAPId, @FileName)";

                            cmd.Parameters.AddWithValue("@SAPId", suppSAPID);
                            cmd.Parameters.AddWithValue("@FileName", suppFilename);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Associate Supplement Docs 3 " + ex.Message);
                            }
                            cmd.Parameters.Clear();
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

                    cmd.CommandText = "UPDATE PartsList SET [CADInfo] = @CAD WHERE [SAPId] = '" + drow["Material"].ToString() + "'";
                    cmd.Parameters.AddWithValue("@CAD", CADInfo);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("CAD " + ex.Message);
                    }
                    statusProgressBar.Value = statusProgressBar.Value + 1;
                    cmd.Parameters.Clear();
                }
                TecanDatabase.Close();
                
                this.partsListTableAdapter.Fill(this.tecanPartsListDataSet.PartsList);
                this.Close();
            }
        }

        public class Compatibilites
        {
            private string CompatibilityID;
            private string CompatibilityAbbv;
            private string CompatibilityName;

            public Compatibilites(string strName, string strAbbv, string strID)
            {
                this.CompatibilityID = strID;
                this.CompatibilityAbbv = strAbbv;
                this.CompatibilityName = strName;
            }

            public string ID
            {
                get
                {
                    return CompatibilityID;
                }
            }

            public string Abbv
            {

                get
                {
                    return CompatibilityAbbv;
                }
            }

            public string Name
            {

                get
                {
                    return CompatibilityName;
                }
            }

        }

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
                br.Dispose();
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

        private short getInstrument(string p)
        {

            int dataIndex;
            dataIndex = 1;
            foreach (DataRowView s in instrumentListBox.Items)
            {
                string dataTest;
                dataTest = s.Row.ItemArray[1].ToString();
                if (dataTest == p)
                {
                    dataIndex = Convert.ToInt16(s.Row.ItemArray[0]);
                    break;
                }
            }

            return (short)dataIndex;
        }

        private short getCategory(string p)
        {

            int dataIndex;
            dataIndex = 1;
            foreach (DataRowView s in categoryListBox.Items)
            {
                string dataTest;
                dataTest = s.Row.ItemArray[1].ToString();
                if (dataTest == p)
                {
                    dataIndex = Convert.ToInt16(s.Row.ItemArray[0]);
                    break;
                }
            }

            return (short)dataIndex;
        }

        private short getSubCategory(string p)
        {
            int dataIndex;
            dataIndex = 1;
            foreach (DataRowView s in subCategoryListBox.Items)
            {
                string dataTest;
                dataTest = s.Row.ItemArray[1].ToString();
                if (dataTest == p)
                {
                    dataIndex = Convert.ToInt16(s.Row.ItemArray[0]);
                    break;
                }
            }

            return (short)dataIndex;
        }

        private short getSSPCategory(string p)
        {

            int dataIndex;
            dataIndex = 1;
            foreach (DataRowView s in sspCategoryListBox.Items)
            {
                string dataTest;
                dataTest = s.Row.ItemArray[1].ToString();
                if (dataTest == p)
                {
                    dataIndex = Convert.ToInt16(s.Row.ItemArray[0]);
                    break;
                }
            }

            return (short)dataIndex;
        }

        private String getCompatibility(string p)
        {
            String strCompatibility = "";
            foreach (Compatibilites s in theCompatibilities)
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
       
        private short getSalesType(string p)
        {

            int dataIndex;
            dataIndex = 1;
            foreach (DataRowView s in salesTypeListBox.Items)
            {
                string dataTest;
                dataTest = s.Row.ItemArray[1].ToString();
                if (dataTest == p)
                {
                    dataIndex = Convert.ToInt16(s.Row.ItemArray[0]);
                    break;
                }
            }

            return (short)dataIndex;
        }

        private short getDBMembership(string p)
        {

            int dataIndex;
            dataIndex = 1;
            foreach (DataRowView s in dBMembershipListBox.Items)
            {
                string dataTest;
                dataTest = s.Row.ItemArray[1].ToString();
                if (dataTest == p)
                {
                    dataIndex = Convert.ToInt16(s.Row.ItemArray[0]);
                    break;
                }
            }

            return (short)dataIndex;
        }


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
    }
}
