using System;
using System.IO;
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
    public partial class PublishDatabasesForm : Form
    {
        MainPartsListDisplay mainForm;
        Boolean errorFoundDoExit = false;

        SqlCeConnection TecanMasterDatabase = null;
        SqlCeCommand cmdMaster;

        SqlCeConnection TecanQuoteDatabase = null;
        SqlCeCommand cmdQuote;

        SqlCeConnection TecanCustomerDatabase = null;
        SqlCeCommand cmdCustomer;

        int DBBothValue;
        int DBC2Value;
        int DBPLValue;

        public PublishDatabasesForm()
        {
            InitializeComponent();
        }

        public void SetMainFormInstance(MainPartsListDisplay inst)
        {
            mainForm = inst;
        }

        public void startCopyProcess(String WhichDatabase)
        {
            publishProgressBar.Maximum = 5000;
            if (WhichDatabase == "Quote" || WhichDatabase == "Both")
            {
                publishProgressBar.Value = 0;
                publishLabel.Text = "Creating Quote Generator Database";
                CleanExistingQuoteDatabase();
                getDBMembership();
                CreateQuoteLookupTables();
                if (errorFoundDoExit) return;
                CopyMasterDatabaseToQuoteDatabase();
                SaveNewQuoteDatabaseToFolder();
            }

            if (WhichDatabase == "Customer" || WhichDatabase == "Both")
            {
                publishProgressBar.Value = 0;
                publishLabel.Text = "Creating Customer Database";
                CleanExistingCustomerDatabase();
                getDBMembership();
                CreateCustomerLookupTables();
                if (errorFoundDoExit) return;
                CopyMasterDatabaseToCustomerDatabase();
                SaveNewCustomerDatabaseToFolder();
            }

            // Add all of above for PL
            this.Close();

        }

        // Delete any data that may be in Quote Database
        private void CleanExistingQuoteDatabase()
        {
            if(TecanQuoteDatabase == null) openQuoteDB();

            cmdQuote = TecanQuoteDatabase.CreateCommand();
            cmdQuote.CommandText = "DELETE FROM PartsList";
            cmdQuote.ExecuteNonQuery();
            cmdQuote.CommandText = "DELETE FROM Category";
            cmdQuote.ExecuteNonQuery();
            cmdQuote.CommandText = "DELETE FROM Compatibility";
            cmdQuote.ExecuteNonQuery();
            cmdQuote.CommandText = "DELETE FROM Instrument";
            cmdQuote.ExecuteNonQuery();
            cmdQuote.CommandText = "DELETE FROM PartImages";
            cmdQuote.ExecuteNonQuery();
            cmdQuote.CommandText = "DELETE FROM RequiredParts";
            cmdQuote.ExecuteNonQuery();
            cmdQuote.CommandText = "DELETE FROM SalesType";
            cmdQuote.ExecuteNonQuery();
            cmdQuote.CommandText = "DELETE FROM SSPCategory";
            cmdQuote.ExecuteNonQuery();
            cmdQuote.CommandText = "DELETE FROM SubCategory";
            cmdQuote.ExecuteNonQuery();
            cmdQuote.CommandText = "DELETE FROM SuppumentalDocs";
            cmdQuote.ExecuteNonQuery();
            TecanQuoteDatabase.Close();
        }

        private void CleanExistingCustomerDatabase()
        {
            if (TecanCustomerDatabase == null) openCustomerDB();

            cmdCustomer = TecanCustomerDatabase.CreateCommand();
            cmdCustomer.CommandText = "DELETE FROM PartsList";
            cmdCustomer.ExecuteNonQuery();
            cmdCustomer.CommandText = "DELETE FROM Category";
            cmdCustomer.ExecuteNonQuery();
            cmdCustomer.CommandText = "DELETE FROM Compatibility";
            cmdCustomer.ExecuteNonQuery();
            cmdCustomer.CommandText = "DELETE FROM Instrument";
            cmdCustomer.ExecuteNonQuery();
            cmdCustomer.CommandText = "DELETE FROM PartImages";
            cmdCustomer.ExecuteNonQuery();
            cmdCustomer.CommandText = "DELETE FROM RequiredParts";
            cmdCustomer.ExecuteNonQuery();
            cmdCustomer.CommandText = "DELETE FROM SubCategory";
            cmdCustomer.ExecuteNonQuery();
            cmdCustomer.CommandText = "DELETE FROM SuppumentalDocs";
            cmdCustomer.ExecuteNonQuery();

            TecanCustomerDatabase.Close();
        }

        private void getDBMembership()
        {
            openMasterDB();
            cmdMaster = TecanMasterDatabase.CreateCommand();

            // Get DBMembership Values for records that need to be added to Quote Database
            cmdMaster.CommandText = "SELECT [DBID] FROM DBMembership WHERE [DBName] = 'Both'";
            DBBothValue = (int)cmdMaster.ExecuteScalar();

            cmdMaster.CommandText = "SELECT [DBID] FROM DBMembership WHERE [DBName] = 'C2'";
            DBC2Value = (int)cmdMaster.ExecuteScalar();

            cmdMaster.CommandText = "SELECT [DBID] FROM DBMembership WHERE [DBName] = 'PL'";
            DBPLValue = (int)cmdMaster.ExecuteScalar();
            TecanMasterDatabase.Close();
        }

        private void CreateQuoteLookupTables()
        {

            openMasterDB();
            cmdMaster = TecanMasterDatabase.CreateCommand();

            openQuoteDB();
            cmdQuote = TecanQuoteDatabase.CreateCommand();

            // Category Table
            cmdQuote.CommandText = "INSERT INTO Category (CategoryID, CategoryName) Values (0, 'Any')"; // Used only for filter default selection
            cmdQuote.ExecuteNonQuery();

            cmdMaster.CommandText = "SELECT DISTINCT P.Category, C.CategoryName FROM PartsList P" +
            " INNER JOIN Category C" +
            " ON P.Category = C.CategoryID" +
            " WHERE P.DBMembership = " + DBBothValue + " OR P.DBMembership = " + DBC2Value +
            " ORDER BY CategoryName";

            SqlCeDataReader  reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                if (reader[1].ToString() == "")
                {
                    if (MessageBox.Show("There are parts that have no Category assigned!\r\n\r\nDo you want to continue to Publish this database?\r\n\r\nSelect No, the main partslist display will list the parts with this association!", "Invalid Category", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        errorFoundDoExit = true; 
                        break;
                    }
                }
                cmdQuote.CommandText = "INSERT INTO Category (CategoryID, CategoryName)" +
                    " Values (@CategoryID, @CategoryName)";

                cmdQuote.Parameters.AddWithValue("@CategoryID", Convert.ToInt16(reader[0].ToString()));
                cmdQuote.Parameters.AddWithValue("@CategoryName", reader[1].ToString());
                cmdQuote.ExecuteNonQuery();
                cmdQuote.Parameters.Clear();
            }
            if (errorFoundDoExit)
            {
                mainForm.associationTableError("Category", Convert.ToInt16(reader[0].ToString()));
                reader.Dispose();
                cleanupAndExit();
                return;
            }
            
            // Compatibility Table
            cmdMaster.CommandText = "SELECT CompatibilityID, CompatibilityName FROM Compatibility";

            reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                cmdQuote.CommandText = "INSERT INTO Compatibility (CompatibilityID, CompatibilityName)" +
                    " Values (@CompatibilityID, @CompatibilityName)";

                cmdQuote.Parameters.AddWithValue("@CompatibilityID", Convert.ToInt16(reader[0].ToString()));
                cmdQuote.Parameters.AddWithValue("@CompatibilityName", reader[1].ToString());
                cmdQuote.ExecuteNonQuery();
                cmdQuote.Parameters.Clear();
            }

            // Instrument Table
            cmdQuote.CommandText = "INSERT INTO Instrument (InstrumentID, InstrumentName) Values (0, 'Any')"; // Used only for filter default selection
            cmdQuote.ExecuteNonQuery();

            cmdMaster.CommandText = "SELECT DISTINCT P.Instrument, I.InstrumentName FROM PartsList P" +
            " INNER JOIN Instrument I" +
            " ON P.Instrument = I.InstrumentID" +
            " WHERE P.DBMembership = " + DBBothValue + " OR P.DBMembership = " + DBC2Value +
            " ORDER BY InstrumentName";

            reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                if (reader[1].ToString() == "")
                {
                    if (MessageBox.Show("There are parts that have no Instrument assigned!\r\n\r\nDo you want to continue to Publish this database?\r\n\r\nSelect No, the main partslist display will list the parts with this association!", "Invalid Instrument", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        errorFoundDoExit = true;
                        break;
                    }
                }
                cmdQuote.CommandText = "INSERT INTO Instrument (InstrumentID, InstrumentName)" +
                    " Values (@InstrumentID, @InstrumentName)";

                cmdQuote.Parameters.AddWithValue("@InstrumentID", Convert.ToInt16(reader[0].ToString()));
                cmdQuote.Parameters.AddWithValue("@InstrumentName", reader[1].ToString());
                cmdQuote.ExecuteNonQuery();
                cmdQuote.Parameters.Clear();
            }
            if (errorFoundDoExit)
            {
                mainForm.associationTableError("Instrument", Convert.ToInt16(reader[0].ToString()));
                reader.Dispose();
                cleanupAndExit();
                return;
            }

            // PartImages Table
            Byte[] imageData;
            cmdMaster.CommandText = "SELECT DocID, DocExtension, SAPId, Document, FileName FROM PartImages";

            reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                cmdQuote.CommandText = "INSERT INTO PartImages (DocID, DocExtension, SAPId, Document, FileName)" +
                    " Values (@DocID, @DocExtension, @SAPId, @Document, @FileName)";

                cmdQuote.Parameters.AddWithValue("@DocID", Convert.ToInt16(reader[0].ToString()));
                cmdQuote.Parameters.AddWithValue("@DocExtension", reader[1].ToString());
                cmdQuote.Parameters.AddWithValue("@SAPId", reader[2].ToString());
                imageData = (byte[])reader[3];
                cmdQuote.Parameters.AddWithValue("@Document", imageData);
                cmdQuote.Parameters.AddWithValue("@FileName", reader[4].ToString());
                cmdQuote.ExecuteNonQuery();
                cmdQuote.Parameters.Clear();
            }

            // RequiredParts Table
            cmdMaster.CommandText = "SELECT SAPId, RequiredSAPId, Alternatives FROM RequiredParts";

            reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                cmdQuote.CommandText = "INSERT INTO RequiredParts (SAPId, RequiredSAPId, Alternatives)" +
                    " Values (@SAPId, @RequiredSAPId, @Alternatives)";

                cmdQuote.Parameters.AddWithValue("@SAPId", reader[0].ToString());
                cmdQuote.Parameters.AddWithValue("@RequiredSAPId", reader[1].ToString());
                cmdQuote.Parameters.AddWithValue("@Alternatives", reader[2].ToString());
                cmdQuote.ExecuteNonQuery();
                cmdQuote.Parameters.Clear();
            }

            // SalesType Table
            cmdQuote.CommandText = "INSERT INTO SalesType (SalesTypeID, SalesTypeName) Values (0, 'Any')"; // Used only for filter default selection
            cmdQuote.ExecuteNonQuery();

            cmdMaster.CommandText = "SELECT DISTINCT P.SalesType, C.SalesTypeName FROM PartsList P" +
            " INNER JOIN SalesType C" +
            " ON P.SalesType = C.SalesTypeID" +
            " WHERE P.DBMembership = " + DBBothValue + " OR P.DBMembership = " + DBC2Value +
            " ORDER BY SalesTypeName";

            reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                if (reader[1].ToString() == "")
                {
                    if (MessageBox.Show("There are parts that have no Sales Type assigned!\r\n\r\nDo you want to continue to Publish this database?\r\n\r\nSelect No, the main partslist display will list the parts with this association!", "Invalid Sales Type", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        errorFoundDoExit = true;
                        break;
                    }
                }
                cmdQuote.CommandText = "INSERT INTO SalesType (SalesTypeID, SalesTypeName)" +
                    " Values (@SalesTypeID, @SalesTypeName)";

                cmdQuote.Parameters.AddWithValue("@SalesTypeID", Convert.ToInt16(reader[0].ToString()));
                cmdQuote.Parameters.AddWithValue("@SalesTypeName", reader[1].ToString());
                cmdQuote.ExecuteNonQuery();
                cmdQuote.Parameters.Clear();
            }
            if (errorFoundDoExit)
            {
                mainForm.associationTableError("SalesType", Convert.ToInt16(reader[0].ToString()));
                reader.Dispose();
                cleanupAndExit();
                return;
            }

            // SSPCategory Table
            cmdMaster.CommandText = "SELECT DISTINCT P.SSPCategory, C.SSPCategoryName FROM PartsList P" +
            " INNER JOIN SSPCategory C" +
            " ON P.SSPCategory = C.SSPCategoryID" +
            " WHERE P.DBMembership = " + DBBothValue + " OR P.DBMembership = " + DBC2Value +
            " ORDER BY SSPCategoryName";

            reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                cmdQuote.CommandText = "INSERT INTO SSPCategory (SSPCategoryID, SSPCategoryName)" +
                    " Values (@SSPCategoryID, @SSPCategoryName)";

                cmdQuote.Parameters.AddWithValue("@SSPCategoryID", Convert.ToInt16(reader[0].ToString()));
                cmdQuote.Parameters.AddWithValue("@SSPCategoryName", reader[1].ToString());
                cmdQuote.ExecuteNonQuery();
                cmdQuote.Parameters.Clear();
            }

            // SubCategory Table
            cmdQuote.CommandText = "INSERT INTO SubCategory (SubCategoryID, SubCategoryName) Values (0, 'Any')"; // Used only for filter default selection
            cmdQuote.ExecuteNonQuery();

            cmdMaster.CommandText = "SELECT DISTINCT P.SubCategory, C.SubCategoryName FROM PartsList P" +
            " INNER JOIN SubCategory C" +
            " ON P.SubCategory = C.SubCategoryID" +
            " WHERE P.DBMembership = " + DBBothValue + " OR P.DBMembership = " + DBC2Value +
            " ORDER BY SubCategoryName";

            reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                if (reader[1].ToString() == "")
                {
                    if (MessageBox.Show("There are parts that have no SubCategory assigned!\r\n\r\nDo you want to continue to Publish this database?\r\n\r\nSelect No, the main partslist display will list the parts with this association!", "Invalid SubCategory", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        errorFoundDoExit = true;
                        break;
                    }
                }
                cmdQuote.CommandText = "INSERT INTO SubCategory (SubCategoryID, SubCategoryName)" +
                    " Values (@SubCategoryID, @SubCategoryName)";

                cmdQuote.Parameters.AddWithValue("@SubCategoryID", Convert.ToInt16(reader[0].ToString()));
                cmdQuote.Parameters.AddWithValue("@SubCategoryName", reader[1].ToString());
                cmdQuote.ExecuteNonQuery();
                cmdQuote.Parameters.Clear();
            }
            if (errorFoundDoExit)
            {
                mainForm.associationTableError("SubCategory", Convert.ToInt16(reader[0].ToString()));
                reader.Dispose();
                cleanupAndExit();
                return;
            }

            // Supplemental Document Reference Table (This table does not contain the documents themselves)
            cmdMaster.CommandText = "SELECT SAPId, FileName FROM SuppumentalDocs";

            reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                cmdQuote.CommandText = "INSERT INTO SuppumentalDocs (SAPId, FileName)" +
                    " Values (@SAPId, @FileName)";

                cmdQuote.Parameters.AddWithValue("@SAPId", reader[0].ToString());
                cmdQuote.Parameters.AddWithValue("@FileName", reader[1].ToString());
                cmdQuote.ExecuteNonQuery();
                cmdQuote.Parameters.Clear();
            }

            TecanMasterDatabase.Close();
            TecanQuoteDatabase.Close();
            reader.Dispose();
        }

        private void CopyMasterDatabaseToQuoteDatabase()
        {

            Int16 Lab;
            String SAPId;
            String OldPartNum;
            String ThridPartyPartNum;
            Byte Priority;
            short Instrument;
            short SalesType;
            short Category;
            short SubCategory;
            String Description;
            String SAPDescription;
            String DetailDescription;
            // String PLDescription; // This field is used for PL Additional Info
            // String PLDetailDescription; // This field is used for Tecan Only Data
            Decimal PlPrice;
            Int16 Grids;
            Byte SerialPorts;
            Byte USBPorts;
            Decimal StandarPrice;
            Decimal ILP;
            Decimal ASP;
            Decimal ManufacturingCost;
            String X_Dimension;
            String Y_Dimension;
            String Z_Dimension;
            String Z_DimensionNote;
            // DateTime? CreateDate = null;
            // DateTime? RemoveDate = null;
            // Byte DBMembership;
            Boolean NotMasterPriceList;
            Boolean ThridParty;
            String NotesFromFile = "";
            short SSPCategory;
            String Compatibility;
           
            openMasterDB();
            cmdMaster = TecanMasterDatabase.CreateCommand();

            cmdMaster.CommandText = "SELECT [Lab], [SAPId], [OldPartNum], [Priority], [Instrument], [Category], [SubCategory], [SSPCategory]," +
                " [Description], [SAPDescription], [DetailDescription], [PLDetailDescription], [Grids], [SerialPorts], [USBPorts], [PlPrice]," +
                " [StandarPrice], [ILP], [ASP], [ManufacturingCost], [SalesType], [X_Dimension], [Y_Dimension], [Z_Dimension], [Z_DimensionNote]," +
                " [NotMasterPriceList], [ThridParty], [ThridPartyPartNum], [NotesFromFile], [Compatibility]" +
                " FROM [PartsList] WHERE [DBMembership] = " + DBBothValue + " OR [DBMembership] = " + DBC2Value + " ORDER BY [SAPId]";

            SqlCeDataReader reader = cmdMaster.ExecuteReader();

            openQuoteDB();
            cmdQuote = TecanQuoteDatabase.CreateCommand();

            while (reader.Read())
            {
                // Read the Master Parts List Record
                Lab = Convert.ToInt16(reader[0].ToString());
                SAPId = reader.GetString(1);
                OldPartNum = reader.GetString(2);
                Priority = (byte)Convert.ToInt16(reader[3].ToString());
                Instrument = Convert.ToInt16(reader[4].ToString());
                Category = Convert.ToInt16(reader[5].ToString());
                SubCategory = Convert.ToInt16(reader[6].ToString());
                SSPCategory = Convert.ToInt16(reader[7].ToString());
                Description = reader.GetString(8);
                SAPDescription = reader.GetString(9);
                DetailDescription = reader.GetString(10) + "\n" + reader.GetString(11);
                // String PLDescription; // This field is used for PL Additional Info
                // PLDetailDescription; // This field is used for Tecan Only Data and has been added to the Quote Database Detail Description
                Grids = Convert.ToInt16(reader[12].ToString());
                SerialPorts = (byte)Convert.ToInt16(reader[13].ToString());
                USBPorts = (byte)Convert.ToInt16(reader[14].ToString());
                PlPrice = Convert.ToDecimal(reader[15].ToString());
                StandarPrice = Convert.ToDecimal(reader[16].ToString());
                ILP = Convert.ToDecimal(reader[17].ToString());
                ASP = Convert.ToDecimal(reader[18].ToString());
                ManufacturingCost = Convert.ToDecimal(reader[19].ToString());
                SalesType = Convert.ToInt16(reader[20].ToString());
                X_Dimension = reader.GetString(21);
                Y_Dimension = reader.GetString(22);
                Z_Dimension = reader.GetString(23);
                Z_DimensionNote = reader.GetString(24);
                // DateTime? CreateDate = null;
                // DateTime? RemoveDate = null;
                // Byte DBMembership;
                NotMasterPriceList = Convert.ToBoolean(reader[25].ToString());
                ThridParty = Convert.ToBoolean(reader[26].ToString());
                ThridPartyPartNum = reader.GetString(27);
                NotesFromFile = reader[28].ToString();
//                NotesFromFile = reader.GetString(28);
                Compatibility = reader.GetString(29);

                // Insert New Record into Quote Database
                cmdQuote.CommandText = "INSERT INTO PartsList (Lab, SAPId, OldPartNum, Priority, Instrument, Category, SubCategory, SSPCategory," +
                " Description, SAPDescription, DetailDescription, Grids, SerialPorts, USBPorts, PlPrice, StandarPrice, ILP, ASP, ManufacturingCost," +
                " SalesType, X_Dimension, Y_Dimension, Z_Dimension, Z_DimensionNote, NotMasterPriceList, ThridParty, ThridPartyPartNum," +
                " NotesFromFile, Compatibility)" +
                " Values " +
                " (@Lab, @SAPId, @OldPartNum, @Priority, @Instrument, @Category, @SubCategory, @SSPCategory, @Description, @SAPDescription," +
                " @DetailDescription, @Grids, @SerialPorts, @USBPorts, @PlPrice, @StandarPrice, @ILP, @ASP, @ManufacturingCost, @SalesType," +
                " @X_Dimension, @Y_Dimension, @Z_Dimension, @Z_DimensionNote, @NotMasterPriceList, @ThridParty, @ThridPartyPartNum," +
                " @NotesFromFile, @Compatibility)";

                cmdQuote.Parameters.AddWithValue("@Lab", Lab);
                cmdQuote.Parameters.AddWithValue("@SAPId", SAPId);
                cmdQuote.Parameters.AddWithValue("@OldPartNum", OldPartNum);
                cmdQuote.Parameters.AddWithValue("@Priority", Priority);
                cmdQuote.Parameters.AddWithValue("@Instrument", Instrument);
                cmdQuote.Parameters.AddWithValue("@Category", Category);
                cmdQuote.Parameters.AddWithValue("@SubCategory", SubCategory);
                cmdQuote.Parameters.AddWithValue("@SSPCategory", SSPCategory);
                cmdQuote.Parameters.AddWithValue("@Description", Description);
                cmdQuote.Parameters.AddWithValue("@SAPDescription", SAPDescription);
                cmdQuote.Parameters.AddWithValue("@DetailDescription", DetailDescription);
                cmdQuote.Parameters.AddWithValue("@Grids", Grids);
                cmdQuote.Parameters.AddWithValue("@SerialPorts", SerialPorts);
                cmdQuote.Parameters.AddWithValue("@USBPorts", USBPorts);
                cmdQuote.Parameters.AddWithValue("@PlPrice", PlPrice);
                cmdQuote.Parameters.AddWithValue("@StandarPrice", StandarPrice);
                cmdQuote.Parameters.AddWithValue("@ILP", ILP);
                cmdQuote.Parameters.AddWithValue("@ASP", ASP);
                cmdQuote.Parameters.AddWithValue("@ManufacturingCost", ManufacturingCost);
                cmdQuote.Parameters.AddWithValue("@SalesType", SalesType);
                cmdQuote.Parameters.AddWithValue("@X_Dimension", X_Dimension);
                cmdQuote.Parameters.AddWithValue("@Y_Dimension", Y_Dimension);
                cmdQuote.Parameters.AddWithValue("@Z_Dimension", Z_Dimension);
                cmdQuote.Parameters.AddWithValue("@Z_DimensionNote", Z_DimensionNote);
                cmdQuote.Parameters.AddWithValue("@NotMasterPriceList", NotMasterPriceList);
                cmdQuote.Parameters.AddWithValue("@ThridParty", ThridParty);
                cmdQuote.Parameters.AddWithValue("@ThridPartyPartNum", ThridPartyPartNum);
                cmdQuote.Parameters.AddWithValue("@NotesFromFile", NotesFromFile);
                cmdQuote.Parameters.AddWithValue("@Compatibility", Compatibility);

                cmdQuote.ExecuteNonQuery();

                cmdQuote.Parameters.Clear();
                publishProgressBar.Value = publishProgressBar.Value + 1;
            }
            TecanMasterDatabase.Close();
            TecanQuoteDatabase.Close();
            reader.Dispose();

        }

        private void SaveNewQuoteDatabaseToFolder()
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Please select your Quote Database Distribution Folder";
            folderBrowserDialog1.ShowNewFolderButton = false;

            String sourceQuoteFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "TecanQuoteGeneratorPartsList.sdf");
            String sourceSuppFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "TecanSuppDocs.sdf");
            String sourceAppDocFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "TecanAppDocs.sdf");
            String targetPath = "";
            String targetQuoteFile;
            String targetSuppFile;
            String targetAppDocFile;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                targetPath = folderBrowserDialog1.SelectedPath;
            }
            targetQuoteFile = System.IO.Path.Combine(targetPath, "TecanQuoteGeneratorPartsList.sdf");
            System.IO.File.Copy(sourceQuoteFile, targetQuoteFile, true);
            targetSuppFile = System.IO.Path.Combine(targetPath, "TecanSuppDocs.sdf");
            System.IO.File.Copy(sourceSuppFile, targetSuppFile, true);
            targetAppDocFile = System.IO.Path.Combine(targetPath, "TecanAppDocs.sdf");
            System.IO.File.Copy(sourceAppDocFile, targetAppDocFile, true);
        }

        private void CreateCustomerLookupTables()
        {

            openMasterDB();
            cmdMaster = TecanMasterDatabase.CreateCommand();

            openCustomerDB();
            cmdCustomer = TecanCustomerDatabase.CreateCommand();

            // Category Table
            cmdCustomer.CommandText = "INSERT INTO Category (CategoryID, CategoryName) Values (0, 'Any')"; // Used only for filter default selection
            cmdCustomer.ExecuteNonQuery();

            cmdMaster.CommandText = "SELECT DISTINCT P.Category, C.CategoryName FROM PartsList P" +
            " INNER JOIN Category C" +
            " ON P.Category = C.CategoryID" +
            " WHERE P.DBMembership = " + DBBothValue + " OR P.DBMembership = " + DBPLValue +
            " ORDER BY CategoryName";

            SqlCeDataReader reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                if (reader[1].ToString() == "")
                {
                    if (MessageBox.Show("There are parts that have no Category assigned!\r\n\r\nDo you want to continue to Publish this database?\r\n\r\nSelect No, the main partslist display will list the parts with this association!", "Invalid Category", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        errorFoundDoExit = true;
                        break;
                    }
                }
                cmdCustomer.CommandText = "INSERT INTO Category (CategoryID, CategoryName)" +
                    " Values (@CategoryID, @CategoryName)";

                cmdCustomer.Parameters.AddWithValue("@CategoryID", Convert.ToInt16(reader[0].ToString()));
                cmdCustomer.Parameters.AddWithValue("@CategoryName", reader[1].ToString());
                cmdCustomer.ExecuteNonQuery();
                cmdCustomer.Parameters.Clear();
            }
            if (errorFoundDoExit)
            {
                mainForm.associationTableError("Category", Convert.ToInt16(reader[0].ToString()));
                reader.Dispose();
                cleanupAndExit();
                return;
            }

            // Compatibility Table
            cmdMaster.CommandText = "SELECT CompatibilityID, CompatibilityName FROM Compatibility";

            reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                cmdCustomer.CommandText = "INSERT INTO Compatibility (CompatibilityID, CompatibilityName)" +
                    " Values (@CompatibilityID, @CompatibilityName)";

                cmdCustomer.Parameters.AddWithValue("@CompatibilityID", Convert.ToInt16(reader[0].ToString()));
                cmdCustomer.Parameters.AddWithValue("@CompatibilityName", reader[1].ToString());
                cmdCustomer.ExecuteNonQuery();
                cmdCustomer.Parameters.Clear();
            }

            // Instrument Table
            cmdCustomer.CommandText = "INSERT INTO Instrument (InstrumentID, InstrumentName) Values (0, 'Any')"; // Used only for filter default selection
            cmdCustomer.ExecuteNonQuery();

            cmdMaster.CommandText = "SELECT DISTINCT P.Instrument, I.InstrumentName FROM PartsList P" +
            " INNER JOIN Instrument I" +
            " ON P.Instrument = I.InstrumentID" +
            " WHERE P.DBMembership = " + DBBothValue + " OR P.DBMembership = " + DBPLValue +
            " ORDER BY InstrumentName";

            reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                if (reader[1].ToString() == "")
                {
                    if (MessageBox.Show("There are parts that have no Instrument assigned!\r\n\r\nDo you want to continue to Publish this database?\r\n\r\nSelect No, the main partslist display will list the parts with this association!", "Invalid Instrument", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        errorFoundDoExit = true;
                        break;
                    }
                }
                cmdCustomer.CommandText = "INSERT INTO Instrument (InstrumentID, InstrumentName)" +
                    " Values (@InstrumentID, @InstrumentName)";

                cmdCustomer.Parameters.AddWithValue("@InstrumentID", Convert.ToInt16(reader[0].ToString()));
                cmdCustomer.Parameters.AddWithValue("@InstrumentName", reader[1].ToString());
                cmdCustomer.ExecuteNonQuery();
                cmdCustomer.Parameters.Clear();
            }
            if (errorFoundDoExit)
            {
                mainForm.associationTableError("Instrument", Convert.ToInt16(reader[0].ToString()));
                reader.Dispose();
                cleanupAndExit();
                return;
            }

            // PartImages Table
            Byte[] imageData;
            cmdMaster.CommandText = "SELECT DocID, DocExtension, SAPId, Document, FileName FROM PartImages";

            reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                cmdCustomer.CommandText = "INSERT INTO PartImages (DocID, DocExtension, SAPId, Document, FileName)" +
                    " Values (@DocID, @DocExtension, @SAPId, @Document, @FileName)";

                cmdCustomer.Parameters.AddWithValue("@DocID", Convert.ToInt16(reader[0].ToString()));
                cmdCustomer.Parameters.AddWithValue("@DocExtension", reader[1].ToString());
                cmdCustomer.Parameters.AddWithValue("@SAPId", reader[2].ToString());
                imageData = (byte[])reader[3];
                cmdCustomer.Parameters.AddWithValue("@Document", imageData);
                cmdCustomer.Parameters.AddWithValue("@FileName", reader[4].ToString());
                cmdCustomer.ExecuteNonQuery();
                cmdCustomer.Parameters.Clear();
            }

            // RequiredParts Table
            cmdMaster.CommandText = "SELECT SAPId, RequiredSAPId, Alternatives FROM RequiredParts";

            reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                cmdCustomer.CommandText = "INSERT INTO RequiredParts (SAPId, RequiredSAPId, Alternatives)" +
                    " Values (@SAPId, @RequiredSAPId, @Alternatives)";

                cmdCustomer.Parameters.AddWithValue("@SAPId", reader[0].ToString());
                cmdCustomer.Parameters.AddWithValue("@RequiredSAPId", reader[1].ToString());
                cmdCustomer.Parameters.AddWithValue("@Alternatives", reader[2].ToString());
                cmdCustomer.ExecuteNonQuery();
                cmdCustomer.Parameters.Clear();
            }

            // SubCategory Table
            cmdCustomer.CommandText = "INSERT INTO SubCategory (SubCategoryID, SubCategoryName) Values (0, 'Any')"; // Used only for filter default selection
            cmdCustomer.ExecuteNonQuery();

            cmdMaster.CommandText = "SELECT DISTINCT P.SubCategory, C.SubCategoryName FROM PartsList P" +
            " INNER JOIN SubCategory C" +
            " ON P.SubCategory = C.SubCategoryID" +
            " WHERE P.DBMembership = " + DBBothValue + " OR P.DBMembership = " + DBPLValue +
            " ORDER BY SubCategoryName";

            reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                if (reader[1].ToString() == "")
                {
                    if (MessageBox.Show("There are parts that have no SubCategory assigned!\r\n\r\nDo you want to continue to Publish this database?\r\n\r\nSelect No, the main partslist display will list the parts with this association!", "Invalid SubCategory", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        errorFoundDoExit = true;
                        break;
                    }
                }
                cmdCustomer.CommandText = "INSERT INTO SubCategory (SubCategoryID, SubCategoryName)" +
                    " Values (@SubCategoryID, @SubCategoryName)";

                cmdCustomer.Parameters.AddWithValue("@SubCategoryID", Convert.ToInt16(reader[0].ToString()));
                cmdCustomer.Parameters.AddWithValue("@SubCategoryName", reader[1].ToString());
                cmdCustomer.ExecuteNonQuery();
                cmdCustomer.Parameters.Clear();
            }
            if (errorFoundDoExit)
            {
                mainForm.associationTableError("SubCategory", Convert.ToInt16(reader[0].ToString()));
                reader.Dispose();
                cleanupAndExit();
                return;
            }

            // Supplemental Document Reference Table (This table does not contain the documents themselves)
            cmdMaster.CommandText = "SELECT SAPId, FileName FROM SuppumentalDocs";

            reader = cmdMaster.ExecuteReader();
            while (reader.Read())
            {
                cmdCustomer.CommandText = "INSERT INTO SuppumentalDocs (SAPId, FileName)" +
                    " Values (@SAPId, @FileName)";

                cmdCustomer.Parameters.AddWithValue("@SAPId", reader[0].ToString());
                cmdCustomer.Parameters.AddWithValue("@FileName", reader[1].ToString());
                cmdCustomer.ExecuteNonQuery();
                cmdCustomer.Parameters.Clear();
            }

            TecanMasterDatabase.Close();
            TecanCustomerDatabase.Close();
            reader.Dispose();
        }

        private void CopyMasterDatabaseToCustomerDatabase()
        {

            String SAPId;
            String OldPartNum;
            Byte Priority;
            short Instrument;
            short Category;
            short SubCategory;
            String Description;
            String SAPDescription;
            String DetailDescription;
            // String PLDescription; // This field is used for PL Additional Info
            // String PLDetailDescription; // This field is used for Tecan Only Data
            Int16 Grids;
            Byte SerialPorts;
            Byte USBPorts;
            Decimal ILP;
            String X_Dimension;
            String Y_Dimension;
            String Z_Dimension;
            String Z_DimensionNote;
            String NotesFromFile = "";
            String Compatibility;

            openMasterDB();
            cmdMaster = TecanMasterDatabase.CreateCommand();

            cmdMaster.CommandText = "SELECT [SAPId], [OldPartNum], [Priority], [Instrument], [Category], [SubCategory]," +
                " [Description], [SAPDescription], [DetailDescription], [PLDescription], [Grids], [SerialPorts], [USBPorts], [ILP]," +
                " [X_Dimension], [Y_Dimension], [Z_Dimension], [Z_DimensionNote], [NotesFromFile], [Compatibility]" +
                " FROM [PartsList] WHERE [DBMembership] = " + DBBothValue + " OR [DBMembership] = " + DBPLValue + " ORDER BY [SAPId]";

            SqlCeDataReader reader = cmdMaster.ExecuteReader();

            openCustomerDB();
            cmdCustomer = TecanCustomerDatabase.CreateCommand();

            while (reader.Read())
            {
                // Read the Master Parts List Record
                SAPId = reader.GetString(0);
                OldPartNum = reader.GetString(1);
                Priority = (byte)Convert.ToInt16(reader[2].ToString());
                Instrument = Convert.ToInt16(reader[3].ToString());
                Category = Convert.ToInt16(reader[4].ToString());
                SubCategory = Convert.ToInt16(reader[5].ToString());
                Description = reader.GetString(6);
                SAPDescription = reader.GetString(7);
                DetailDescription = reader.GetString(8) + "\n" + reader.GetString(9);
                // String PLDescription; // This field is used for PL Additional Info
                // PLDetailDescription; // This field is used for Tecan Only Data and has been added to the Quote Database Detail Description
                Grids = Convert.ToInt16(reader[10].ToString());
                SerialPorts = (byte)Convert.ToInt16(reader[11].ToString());
                USBPorts = (byte)Convert.ToInt16(reader[12].ToString());
                ILP = Convert.ToDecimal(reader[13].ToString());
                X_Dimension = reader.GetString(14);
                Y_Dimension = reader.GetString(15);
                Z_Dimension = reader.GetString(16);
                Z_DimensionNote = reader.GetString(17);
                NotesFromFile = reader[18].ToString();
                Compatibility = reader.GetString(19);

                // Insert New Record into Quote Database
                cmdCustomer.CommandText = "INSERT INTO PartsList (SAPId, OldPartNum, Priority, Instrument, Category, SubCategory," +
                " Description, SAPDescription, DetailDescription, Grids, SerialPorts, USBPorts, ILP, X_Dimension, Y_Dimension, Z_Dimension, Z_DimensionNote," +
                " NotesFromFile, Compatibility)" +
                " Values " +
                " (@SAPId, @OldPartNum, @Priority, @Instrument, @Category, @SubCategory, @Description, @SAPDescription, @DetailDescription, @Grids," +
                " @SerialPorts, @USBPorts, @ILP, @X_Dimension, @Y_Dimension, @Z_Dimension, @Z_DimensionNote, @NotesFromFile, @Compatibility)";

                cmdCustomer.Parameters.AddWithValue("@SAPId", SAPId);
                cmdCustomer.Parameters.AddWithValue("@OldPartNum", OldPartNum);
                cmdCustomer.Parameters.AddWithValue("@Priority", Priority);
                cmdCustomer.Parameters.AddWithValue("@Instrument", Instrument);
                cmdCustomer.Parameters.AddWithValue("@Category", Category);
                cmdCustomer.Parameters.AddWithValue("@SubCategory", SubCategory);
                cmdCustomer.Parameters.AddWithValue("@Description", Description);
                cmdCustomer.Parameters.AddWithValue("@SAPDescription", SAPDescription);
                cmdCustomer.Parameters.AddWithValue("@DetailDescription", DetailDescription);
                cmdCustomer.Parameters.AddWithValue("@Grids", Grids);
                cmdCustomer.Parameters.AddWithValue("@SerialPorts", SerialPorts);
                cmdCustomer.Parameters.AddWithValue("@USBPorts", USBPorts);
                cmdCustomer.Parameters.AddWithValue("@ILP", ILP);
                cmdCustomer.Parameters.AddWithValue("@X_Dimension", X_Dimension);
                cmdCustomer.Parameters.AddWithValue("@Y_Dimension", Y_Dimension);
                cmdCustomer.Parameters.AddWithValue("@Z_Dimension", Z_Dimension);
                cmdCustomer.Parameters.AddWithValue("@Z_DimensionNote", Z_DimensionNote);
                cmdCustomer.Parameters.AddWithValue("@NotesFromFile", NotesFromFile);
                cmdCustomer.Parameters.AddWithValue("@Compatibility", Compatibility);

                cmdCustomer.ExecuteNonQuery();

                cmdCustomer.Parameters.Clear();
                publishProgressBar.Value = publishProgressBar.Value + 1;
            }
            TecanMasterDatabase.Close();
            TecanCustomerDatabase.Close();
            reader.Dispose();

        }

        private void SaveNewCustomerDatabaseToFolder()
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Please select your Customer Database Distribution Folder";
            folderBrowserDialog1.ShowNewFolderButton = false;

            String sourceCustomerFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "TecanCustomerPartsList.sdf");
            String sourceSuppFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "TecanSuppDocs.sdf");
            String targetPath = "";
            String targetCustomerFile;
            String targetSuppFile;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                targetPath = folderBrowserDialog1.SelectedPath;
            }
            targetCustomerFile = System.IO.Path.Combine(targetPath, "TecanCustomerPartsList.sdf");
            System.IO.File.Copy(sourceCustomerFile, targetCustomerFile, true);
            targetSuppFile = System.IO.Path.Combine(targetPath, "TecanSuppDocs.sdf");
            System.IO.File.Copy(sourceSuppFile, targetSuppFile, true);
        }

        private void openMasterDB()
        {
            TecanMasterDatabase = new SqlCeConnection();
            TecanMasterDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanMasterDatabase.Open();
        }

        private void openQuoteDB()
        {
            TecanQuoteDatabase = new SqlCeConnection();
            TecanQuoteDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanQuoteGeneratorPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanQuoteDatabase.Open();
        }

        private void openCustomerDB()
        {
            TecanCustomerDatabase = new SqlCeConnection();
            TecanCustomerDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanCustomerPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanCustomerDatabase.Open();
        }

        private void cleanupAndExit()
        {
            if (TecanQuoteDatabase != null) CleanExistingQuoteDatabase();
            if (TecanCustomerDatabase != null) CleanExistingCustomerDatabase();
            TecanMasterDatabase.Close();
            this.Dispose();
            this.Close();
        }

    }
}
