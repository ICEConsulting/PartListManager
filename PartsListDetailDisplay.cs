using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlServerCe;
using System.Diagnostics;

namespace TecanPartListManager
{
    public partial class PartsListDetailDisplay : Form
    {

        MainPartsListDisplay mainForm;
        Boolean hasSAPID;
        
        SqlCeConnection TecanDatabase = null;

        public void SetForm1Instance(MainPartsListDisplay inst)
        {
            mainForm = inst;
        }

        public PartsListDetailDisplay()
        {
            InitializeComponent();
        }

        private void partsListBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (hasSAPID)
            {
                if (CADDescription.Text != "" || CADFiles.Text != "") saveCADInfo();
                this.Validate();
                this.partsListBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.tecanPartsListDataSet);
            }
            else
            {
                saveNewRecord();
            }
            mainForm.PartDetailReturn();
            this.Close();
        }

        internal void LoadParts(String SAPID)
        {
            if (SAPID != "" && SAPID != null)
            {
                hasSAPID = true;
            }
            // ice todo May need to add required parts fill to this
            this.partsListTableAdapter.FillBySAPID(this.tecanPartsListDataSet.PartsList, SAPID);
            this.suppumentalDocsTableAdapter.FillBySAPID(this.tecanPartsListDataSet.SuppumentalDocs, SAPID);
//            this.requiredPartsTableAdapter.FillBySAPID(this.tecanPartsListDataSet.RequiredParts, SAPID);
            this.dBMembershipTableAdapter.Fill(this.tecanPartsListDataSet.DBMembership);
            this.sSPCategoryTableAdapter.Fill(this.tecanPartsListDataSet.SSPCategory);
            this.salesTypeTableAdapter.Fill(this.tecanPartsListDataSet.SalesType);
            this.subCategoryTableAdapter.Fill(this.tecanPartsListDataSet.SubCategory);
            this.categoryTableAdapter.Fill(this.tecanPartsListDataSet.Category);
            this.instrumentTableAdapter.Fill(this.tecanPartsListDataSet.Instrument);

            loadImage(SAPID);
            loadRequiredParts(SAPID);
            loadOptionalParts(SAPID);
            loadCompatibility(SAPID);
            // loadCAD(SAPID);
            if (mainForm.getEditStatus() != true)
            {
                partsListBindingNavigatorSaveItem.Enabled = false;
                DuplicatePartToolStripLabel.Enabled = false;
                addSuppDocButton.Enabled = false;
                addRequiredPartButton.Enabled = false;
                addRequiredPartButton2.Enabled = false;
                AddCompatibilityButton.Enabled = false;
                addImageButton.Enabled = false;
                this.ControlBox = true;
            }
        }

        private void loadImage(string SAPID)
        {
                // SqlCeConnection TecanDatabase = null;
                Byte[] imageData;
                try
                {
                    //TecanDatabase = new SqlCeConnection();
                    //String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                    //TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
                    //TecanDatabase.Open();
                    openDB();
                    SqlCeCommand cmd = TecanDatabase.CreateCommand();
                    cmd.CommandText = "SELECT Document FROM PartImages WHERE SAPId = '" + SAPID + "'";
                    imageData = (byte[])cmd.ExecuteScalar();
                    if (imageData != null)
                    {
                        Image newImage = byteArrayToImage(imageData);
                        newImage = ResizeImage(newImage, new Size(396, 224));
                        partImagePictureBox.Image = newImage;
                    }
                    
                }
                finally
                {
                    TecanDatabase.Close();
                }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        //public static Image resizeImage(Image imgToResize, Size size)
        //{
        //   return (Image)(new Bitmap(imgToResize, size));
        //}


        public static Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        
        private void PartsListDetailDisplay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tecanPartsListDataSet.RequiredParts' table. You can move, or remove it, as needed.
            // this.requiredPartsTableAdapter.Fill(this.tecanPartsListDataSet.RequiredParts);
            // TODO: This line of code loads data into the 'tecanPartsListDataSet.SuppumentalDocs' table. You can move, or remove it, as needed.
            if (!hasSAPID)
            {
                this.dBMembershipTableAdapter.Fill(this.tecanPartsListDataSet.DBMembership);
                this.sSPCategoryTableAdapter.Fill(this.tecanPartsListDataSet.SSPCategory);
                this.salesTypeTableAdapter.Fill(this.tecanPartsListDataSet.SalesType);
                this.subCategoryTableAdapter.Fill(this.tecanPartsListDataSet.SubCategory);
                this.categoryTableAdapter.Fill(this.tecanPartsListDataSet.Category);
                this.instrumentTableAdapter.Fill(this.tecanPartsListDataSet.Instrument);
            }
            else
            {
                // ice todo If there is a part displayed, may need to fill suppumental docs and required parts????
                DBMembershipComboBox.SelectedIndex = Convert.ToInt32(dBMembershipTextBox.Text);
                SSPCategoryComboBox.SelectedIndex = Convert.ToInt32(SSPCategoryTextBox.Text) - 1;
                salesTypeComboBox.SelectedIndex = Convert.ToInt32(salesTypeTextBox.Text);
                subCategoryComboBox.SelectedIndex = Convert.ToInt32(subCategoryTextBox.Text);
                categoryComboBox.SelectedIndex = Convert.ToInt32(categoryTextBox.Text);
                instrumentComboBox.SelectedIndex = Convert.ToInt32(instrumentTextBox.Text);
                loadCAD(sAPIdTextBox.Text);
            }

        }

        private void PartsListDetailDisplay_Close(object sender, EventArgs e)
        {
            //Validate();
            //partsListBindingSource.EndEdit();
            //tableAdapterManager.UpdateAll(this.tecanPartsListDataSet);
            //mainForm.PartDetailReturn();
        }

        private void saveNewRecord()
        {
            // SqlCeConnection TecanDatabase = null;

            openDB();
            //TecanDatabase = new SqlCeConnection();
            //String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            //TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            //TecanDatabase.Open();
            SqlCeCommand cmd = TecanDatabase.CreateCommand();

            // Used to remove string value from decimal number bfore conversion
            String tempString = "";
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
            Byte DBMembership;
            Boolean NotMasterPriceList;
            Boolean ThridParty;
            String Notes;
            short SSPCategory;
            String CAD;

 
            if (labTextBox.Text != "")
            {
                try
                {
                    Lab = Convert.ToInt16(labTextBox.Text);
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

            SAPId = sAPIdTextBox.Text;
            OldPartNum = oldPartNumTextBox.Text;
            ThridPartyPartNum = thirdPartyPartNumTextBox.Text;

            if (priorityTextBox.Text != "")
            {
                try
                {
                    Priority = Convert.ToByte(priorityTextBox.Text);
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
            Instrument = (short)Convert.ToInt16(instrumentComboBox.SelectedIndex);
            // Get Sales Type Lookup Value 
            SalesType = (short)Convert.ToInt16(salesTypeComboBox.SelectedIndex);
            // Get Category Lookup Value
            Category = (short)Convert.ToInt16(categoryComboBox.SelectedIndex);
            // Get SubCategory Lookup Value
            SubCategory = (short)Convert.ToInt16(subCategoryComboBox.SelectedIndex);

            Description = descriptionTextBox.Text;
            SAPDescription = sAPDescriptionTextBox.Text;
            DetailDescription = detailDescriptionTextBox.Text;
            PLDescription = pLDescriptionTextBox.Text; // This field is used for PL Additional Info
            PLDetailDescription = pLDetailDescriptionTextBox.Text; // This field is used for Tecan Only Data

            if (plPriceTextBox.Text != "")
            {
                if (plPriceTextBox.Text.IndexOf('$') != -1)
                    tempString = plPriceTextBox.Text.Replace("$", "");
                
                try
                {
                    PlPrice = Convert.ToDecimal(tempString);
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

            if (gridsTextBox.Text != "")
            {
                try
                {
                    Grids = (short)Convert.ToInt16(gridsTextBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Convert Grids " + ex.Message);
                }
            }
            else
            {
                Grids = 0;
            }

            if (serialPortsTextBox.Text != "")
            {
                try
                {
                    SerialPorts = Convert.ToByte(serialPortsTextBox.Text);
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

            if (uSBPortsTextBox.Text != "")
            {
                try
                {
                    USBPorts = Convert.ToByte(uSBPortsTextBox.Text);
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

            if (standarPriceTextBox.Text != "")
            {
                if (standarPriceTextBox.Text.IndexOf('$') != -1)
                    tempString = standarPriceTextBox.Text.Replace("$", "");
                try
                {
                    StandarPrice = Convert.ToDecimal(tempString);
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

            if (iLPTextBox.Text != "")
            {
                if (iLPTextBox.Text.IndexOf('$') != -1)
                    tempString = iLPTextBox.Text.Replace("$", "");
                try
                {
                    ILP = Convert.ToDecimal(tempString);
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

            if (aSPTextBox.Text != "")
            {
                if (aSPTextBox.Text.IndexOf('$') != -1)
                    tempString = aSPTextBox.Text.Replace("$", "");
                try
                {
                    ASP = Convert.ToDecimal(tempString);
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

            if (manufacturingCostTextBox.Text != "")
            {
                if (manufacturingCostTextBox.Text.IndexOf('$') != -1)
                    tempString = manufacturingCostTextBox.Text.Replace("$", "");
                try
                {
                    ManufacturingCost = Convert.ToDecimal(tempString);
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

            X_Dimension = x_DimensionTextBox.Text;
            Y_Dimension = y_DimensionTextBox.Text;
            Z_Dimension = z_DimensionTextBox.Text;
            Z_DimensionNote = z_DimensionNoteTextBox.Text; 
            CreateDate = Convert.ToDateTime(CreateDateDateTimePicker.Text);
            RemoveDate = Convert.ToDateTime(removeDateDateTimePicker.Text);

            // Set DB Membership
            DBMembership = (byte)Convert.ToInt16(DBMembershipComboBox.SelectedIndex);
            NotMasterPriceList = Convert.ToBoolean(notMasterPriceListCheckBox.Checked);
            ThridParty = Convert.ToBoolean(thridPartyCheckBox.Checked);
            Notes = notesTextBox.Text;
            // Get SSPCategory Lookup Value
            SSPCategory = (short)(Convert.ToInt16(SSPCategoryComboBox.SelectedIndex) + 1);
            CAD = CADDescription.Text + "^" + CADFiles.Text;

            cmd.CommandText = "INSERT INTO PartsList (Lab, SAPId, OldPartNum, ThridPartyPartNum, Priority, Instrument, SalesType, Category, SubCategory," +
                " Description, SAPDescription, DetailDescription, PLDescription, PLDetailDescription, PlPrice, Grids, SerialPorts, USBPorts," +
                " StandarPrice, ILP, ASP, ManufacturingCost, X_Dimension, Y_Dimension, Z_Dimension, Z_DimensionNote, CreateDate, RemoveDate, DBMembership," +
                " NotMasterPriceList, ThridParty, Notes, SSPCategory, CADInfo)" +
                " Values " +
                "(@Lab, @SAPId, @OldPartNum, @ThridPartyPartNum, @Priority, @Instrument, @SalesType, @Category, @SubCategory, " +
                "@Description, @SAPDescription, @DetailDescription, @PLDescription, @PLDetailDescription, @PlPrice, @Grids, @SerialPorts, @USBPorts, " +
                "@StandarPrice, @ILP, @ASP, @ManufacturingCost, @X_Dimension, @Y_Dimension, @Z_Dimension, @Z_DimensionNote, @CreateDate, @RemoveDate, " +
                "@DBMembership, @NotMasterPriceList, @ThridParty, @Notes, @SSPCategory, @CAD)";


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
            cmd.Parameters.AddWithValue("@PLDetailDescription", PLDetailDescription); // This field is used for Tecan Only Data
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
            cmd.Parameters.AddWithValue("@CreateDate", CreateDate);
            cmd.Parameters.AddWithValue("@RemoveDate", RemoveDate);
            cmd.Parameters.AddWithValue("@DBMembership", DBMembership);
            cmd.Parameters.AddWithValue("@NotMasterPriceList", NotMasterPriceList);
            cmd.Parameters.AddWithValue("@ThridParty", ThridParty);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@SSPCategory", SSPCategory);
            cmd.Parameters.AddWithValue("@CAD", CAD);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            TecanDatabase.Close();
        }

        private void addSuppDocButton_Click(object sender, EventArgs e)
        {
            SuppDocForm SuppForm = new SuppDocForm();
            SuppForm.SetForm1Instance(this);
            SuppForm.suppForm_Load(sAPIdTextBox.Text);
            SuppForm.Show();
        }

        public void SuppDocReturn(String SAPID)
        {
            this.suppumentalDocsTableAdapter.FillBySAPID(this.tecanPartsListDataSet.SuppumentalDocs, SAPID);
        }

        private void suppumentalDocsListBox_Click(object sender, EventArgs e)
        {
            String selectedDoc = suppumentalDocsListBox.GetItemText(suppumentalDocsListBox.SelectedItem);
            if (selectedDoc != "")
            {
                viewSuppDocButton.Visible = true;
            }
        }

        private void viewSuppDocButton_Click(object sender, EventArgs e)
        {
            String selectedDocName = suppumentalDocsListBox.GetItemText(suppumentalDocsListBox.SelectedItem);

            // Get the file contents from the database
            SqlCeConnection TecanSuppDocsDatabase = null;

            TecanSuppDocsDatabase = new SqlCeConnection();
            String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            TecanSuppDocsDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanSuppDocs.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanSuppDocsDatabase.Open();
            SqlCeCommand cmd = TecanSuppDocsDatabase.CreateCommand();

            cmd.CommandText = "SELECT Document FROM SuppumentalDocs WHERE FileName = '" + selectedDocName + "'";
            SqlCeDataReader reader = cmd.ExecuteReader();
            reader = cmd.ExecuteReader();
            Byte[] documentData = new Byte[0];
            while (reader.Read())
            {
                documentData = (byte[])reader[0];
            }
            reader.Dispose();
            TecanSuppDocsDatabase.Close();

            // Create the new file in temp directory
            String tempFilePath = @AppDomain.CurrentDomain.BaseDirectory.ToString() + "temp";
            System.IO.Directory.CreateDirectory(tempFilePath);

            // If temp directory current contains any files, delete them
            System.IO.DirectoryInfo tempFiles = new DirectoryInfo(tempFilePath);

            foreach (FileInfo file in tempFiles.GetFiles())
            {
                file.Delete();
            }

            String fullFilePathName = @tempFilePath + "\\" + selectedDocName;
            System.IO.FileStream fs = System.IO.File.Create(fullFilePathName);
            fs.Close();

            // Write file contents into file
            BinaryWriter Writer = null;

            try
            {
                // Create a new stream to write to the file
                Writer = new BinaryWriter(File.OpenWrite(fullFilePathName));

                // Writer raw data                
                Writer.Write(documentData);
                Writer.Flush();
                Writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Process.Start(fullFilePathName);

        }

        private void addImageButton_Click(object sender, EventArgs e)
        {
            // Remove Image?
            if (partImagePictureBox.Image != null)
            {
                // Image exists
                if (MessageBox.Show("Do you want to remove the from this part?", "Remove Image", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    openDB();
                    SqlCeCommand cmd = TecanDatabase.CreateCommand();

                    cmd.CommandText = "DELETE FROM PartImages WHERE SAPId = '" + sAPIdTextBox.Text + "'";
                    cmd.ExecuteNonQuery();
                    TecanDatabase.Close();
                    partImagePictureBox.Image = null;
                }
            }

            // Select and Add image to part
            if (partImagePictureBox.Image == null)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Title = "Please Select an image for part number " + sAPIdTextBox.Text;
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "jpg files (*.jpg, *.JPG)|*.jpg;*.JPG";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    String newRowCount = "";
                    int newRowCountNum = 0;
                    String filePath, imageFileName, imageExt;
                    Byte[] imageData;
                    long imageNumBytes;

                    // Get the last DocID and add 1
                    openDB();
                    SqlCeCommand cmd = TecanDatabase.CreateCommand();

                    cmd.CommandText = "SELECT DocID FROM PartImages";
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        newRowCount = reader[0].ToString();
                    }
                    reader.Dispose();
                    newRowCountNum = Convert.ToInt16(newRowCount);
                    newRowCountNum++;

                    filePath = openFileDialog1.FileName;

                    FileInfo imageFileInfo = new FileInfo(filePath);
                    imageNumBytes = imageFileInfo.Length;
                    FileStream imageContents = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(imageContents);
                    imageData = br.ReadBytes((int)imageNumBytes);
                    imageContents.Close();

                    imageFileName = imageFileInfo.Name.ToLower();
                    imageExt = imageFileInfo.Extension.Replace(".", "").ToLower();

                    cmd.CommandText = "INSERT INTO PartImages (DocID, DocExtension, SAPId, Document, FileName)" +
                        " Values " +
                        "(@DocID, @DocExtension, @SAPId, @Document, @FileName)";

                    cmd.Parameters.AddWithValue("@DocId", newRowCountNum);
                    cmd.Parameters.AddWithValue("@DocExtension", imageExt);
                    cmd.Parameters.AddWithValue("@SAPId", sAPIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@Document", imageData);
                    cmd.Parameters.AddWithValue("@FileName", imageFileName);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    imageContents.Dispose();
                    br.Dispose();
                    TecanDatabase.Close();

                    loadImage(sAPIdTextBox.Text);
                }
            }
        }

        //DELETE FROM SuppumentalDocs Listbox
        private void suppumentalDocsListBox_DoubleClick(object sender, EventArgs e)
        {
            if (mainForm.getEditStatus() != true) return;
            String selectedDoc = suppumentalDocsListBox.GetItemText(suppumentalDocsListBox.SelectedItem);
            if (selectedDoc != "")
            {
                if (MessageBox.Show("Do you want to remove the association of " + selectedDoc + " to this part?", "Remove Document Association", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // SqlCeConnection TecanDatabase = null;

                    //TecanDatabase = new SqlCeConnection();
                    //String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                    //TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
                    //TecanDatabase.Open();
                    openDB();
                    SqlCeCommand cmd = TecanDatabase.CreateCommand();

                    cmd.CommandText = "DELETE FROM SuppumentalDocs WHERE FileName = '" + selectedDoc + "'";
                    cmd.ExecuteNonQuery();
                    TecanDatabase.Close();
                    this.suppumentalDocsTableAdapter.FillBySAPID(this.tecanPartsListDataSet.SuppumentalDocs, sAPIdTextBox.Text);
                }
            }
        }

        private void addRequiredPartButton_Click(object sender, EventArgs e)
        {
            RequirePartForm RequiredForm = new RequirePartForm();
            RequiredForm.SetForm1Instance(this);
            RequiredForm.RequirePart_Load(sAPIdTextBox.Text);
            RequiredForm.TopMost = true;
            RequiredForm.Show();
        }

        private void addRequiredPartButton2_Click(object sender, EventArgs e)
        {
            RequirePartForm RequiredForm = new RequirePartForm();
            RequiredForm.SetForm1Instance(this);
            RequiredForm.RequirePart_Load(sAPIdTextBox.Text);
            RequiredForm.TopMost = true;
            RequiredForm.Show();
        }

        private void RequiredListView_DoubleClick(object sender, EventArgs e)
        {
            if (mainForm.getEditStatus() != true) return;
            String RequiredSAPID = RequiredListView.SelectedItems[0].Text;
            if (MessageBox.Show("Do you want to remove the required part " + RequiredSAPID + " for part " + sAPIdTextBox.Text + "?", "Remove Required Part", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                openDB();
                SqlCeCommand cmd = TecanDatabase.CreateCommand();

                cmd.CommandText = "DELETE FROM RequiredParts WHERE SAPId = '" + sAPIdTextBox.Text + "' AND RequiredSAPId = '" + RequiredSAPID + "'";
                cmd.ExecuteNonQuery();
                TecanDatabase.Close();
                loadRequiredParts(sAPIdTextBox.Text);
            }
        }

        private void OptionalListView_DoubleClick(object sender, EventArgs e)
        {
            if (mainForm.getEditStatus() != true) return;
            String OptionalSAPID = OptionalListView.SelectedItems[0].Text;
            if (MessageBox.Show("Do you want to remove the optional part " + OptionalSAPID + " for part " + sAPIdTextBox.Text + "?", "Remove Optional Part", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                openDB();
                SqlCeCommand cmd = TecanDatabase.CreateCommand();

                cmd.CommandText = "DELETE FROM OptionalParts WHERE SAPId = '" + sAPIdTextBox.Text + "' AND OptionalSAPId = '" + OptionalSAPID + "'";
                cmd.ExecuteNonQuery();
                TecanDatabase.Close();
                loadOptionalParts(sAPIdTextBox.Text);
            }
        }

        public void RequiredPartsReturn(String SAPID)
        {
            loadRequiredParts(SAPID);
            loadOptionalParts(SAPID);
        }

        private void loadRequiredParts(String SAPID)
        {
            RequiredListView.Items.Clear();
            
            openDB();
            SqlCeCommand cmd = TecanDatabase.CreateCommand();

            cmd.CommandText = "SELECT R.RequiredSAPId, P.Description FROM RequiredParts R" +
            " INNER JOIN PartsList P " +
            " ON R.RequiredSAPId = P.SAPId" +
            " WHERE R.SAPId = '" + SAPID + "'" +
            " ORDER BY RequiredSAPId";
            try
            {
                SqlCeDataReader reader = cmd.ExecuteReader();

                int partCount = 0;
                while (reader.Read())
                {
                    RequiredListView.Items.Add(reader[0].ToString());
                    RequiredListView.Items[partCount].SubItems.Add(reader[1].ToString());
                    partCount++;
                }
                reader.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            TecanDatabase.Close();

        }

        private void loadOptionalParts(String SAPID)
        {
            OptionalListView.Items.Clear();

            openDB();
            SqlCeCommand cmd = TecanDatabase.CreateCommand();

            cmd.CommandText = "SELECT O.OptionalSAPId, P.Description FROM OptionalParts O" +
            " INNER JOIN PartsList P " +
            " ON O.OptionalSAPId = P.SAPId" +
            " WHERE O.SAPId = '" + SAPID + "'" +
            " ORDER BY OptionalSAPId";
            try
            {
                SqlCeDataReader reader = cmd.ExecuteReader();

                int partCount = 0;
                while (reader.Read())
                {
                    OptionalListView.Items.Add(reader[0].ToString());
                    OptionalListView.Items[partCount].SubItems.Add(reader[1].ToString());
                    partCount++;
                }
                reader.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            TecanDatabase.Close();
        }

        private void AddCompatibilityButton_Click(object sender, EventArgs e)
        {
            CompatibilitiesForm CompatibilityForm = new CompatibilitiesForm();
            CompatibilityForm.SetForm1Instance(this);
            CompatibilityForm.Compatibilities_Load(sAPIdTextBox.Text);
            CompatibilityForm.Show();
        }

        public void CompatibilityReturn(String SAPID)
        {
            loadCompatibility(SAPID);
        }

        private void loadCompatibility(String SAPID)
        {
            compatibilityListBox.Items.Clear();
            String[] compatibilities = new String[20];

            openDB();
            SqlCeCommand cmd = TecanDatabase.CreateCommand();
            SqlCeDataReader reader;
            cmd.CommandText = "SELECT Compatibility FROM PartsList WHERE SAPId = '" + SAPID + "'";
            try
            {
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    compatibilities = reader[0].ToString().Split(',');
                }
                reader.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            for (int i = 0; i < compatibilities.Length; i++)
            {
                cmd.CommandText = "SELECT CompatibilityName FROM Compatibility WHERE CompatibilityID = '" + compatibilities[i] + "'";
                try
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        compatibilityListBox.Items.Add(reader[0]);
                    }
                    reader.Dispose();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            TecanDatabase.Close();
            
        }

        private void loadCAD(String SAPID)
        {

            openDB();
            SqlCeCommand cmd = TecanDatabase.CreateCommand();
            SqlCeDataReader reader;
            cmd.CommandText = "SELECT CADInfo FROM PartsList WHERE SAPId = '" + SAPID + "'";
            String[] CADInfo = new String[2];
            try
            {
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[0].ToString().IndexOf('^') != -1)
                    {
                        CADInfo = reader[0].ToString().Split('^');
                    }
                    else
                    {
                        CADInfo[0] = reader[0].ToString();
                        CADInfo[1] = "";
                    }
                }
                reader.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            TecanDatabase.Close();
            CADDescription.Text = CADInfo[0];
            CADFiles.Text = CADInfo[1];

        }
       
        private void compatibilityListBox_DoubleClick(object sender, EventArgs e)
        {
            if (mainForm.getEditStatus() != true) return;
            String selectedCompatibility = compatibilityListBox.SelectedItem.ToString();
            if (MessageBox.Show("Do you want to remove the selected compatibility " + selectedCompatibility + " from part " + sAPIdTextBox.Text + "?", "Remove Compatibility", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                openDB();
                SqlCeCommand cmd = TecanDatabase.CreateCommand();
                SqlCeDataReader reader;
                compatibilityListBox.Items.Remove(compatibilityListBox.SelectedItem);
                String selectedCompatibilities = "";

                foreach (object compatibility in compatibilityListBox.Items)
                {
                    cmd.CommandText = "SELECT [CompatibilityID] FROM Compatibility WHERE [CompatibilityName] = '" + compatibility.ToString() + "'";
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (selectedCompatibilities == "")
                        {
                            selectedCompatibilities = reader[0].ToString();
                        }
                        else
                        {
                            selectedCompatibilities = selectedCompatibilities + "," + reader[0].ToString();
                        }

                    }
                    reader.Dispose();
                }
                cmd.CommandText = "UPDATE PartsList SET [Compatibility] = @selectedCompatibilities WHERE [SAPId] = '" + sAPIdTextBox.Text + "'";
                cmd.Parameters.AddWithValue("@selectedCompatibilities", selectedCompatibilities);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cmd.Parameters.Clear();
                TecanDatabase.Close();
                loadCompatibility(sAPIdTextBox.Text);
            }
        }

        private void saveCADInfo()
        {
            openDB();
            SqlCeCommand cmd = TecanDatabase.CreateCommand();
            cmd.CommandText = "UPDATE PartsList SET [CADInfo] = @CAD WHERE [SAPId] = '" + sAPIdTextBox.Text + "'";
            cmd.Parameters.AddWithValue("@CAD", CADDescription.Text);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void RequiredListView_Click(object sender, EventArgs e)
        //{
        //    String RequiredSAPID = RequiredListView.SelectedItems[0].Text;
        //    AlternativesListView.Items.Clear();
            
        //    String[] AlternateSAP = new String[10];
        //    String[] AlternateDescription = new String[10];

        //    openDB();
        //    SqlCeCommand cmd = TecanDatabase.CreateCommand();

        //    cmd.CommandText = "SELECT Alternatives FROM RequiredParts WHERE SAPId = '" + sAPIdTextBox.Text + "' AND RequiredSAPId = '" + RequiredSAPID + "'";
        //    try
        //    {
        //        SqlCeDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            AlternateSAP = reader[0].ToString().Split(',');
        //        }
        //        reader.Dispose();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //    for (int i = 0; i < AlternateSAP.Length; i++)
        //    {
        //        cmd.CommandText = "SELECT Description FROM PartsList WHERE SAPId = '" + AlternateSAP[i] + "'";
        //        try
        //        {
        //            SqlCeDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                AlternateDescription[i] = reader[0].ToString();
        //            }
        //            reader.Dispose();

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    TecanDatabase.Close();
        //    for (int i = 0; i < AlternateSAP.Length; i++)
        //    {
        //        AlternativesListView.Items.Add(AlternateSAP[i]);
        //        AlternativesListView.Items[i].SubItems.Add(AlternateDescription[i]);

        //    }

        //}


        //private void requiredPartComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    String RequiredSAPID = this.requiredPartComboBox.GetItemText(requiredPartComboBox.SelectedItem);
        //    requiredPartAlternativesListBox.Items.Clear();

        //    SqlCeConnection TecanDatabase = null;

        //    TecanDatabase = new SqlCeConnection();
        //    String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        //    TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
        //    TecanDatabase.Open();
        //    SqlCeCommand cmd = TecanDatabase.CreateCommand();

        //    cmd.CommandText = "SELECT Alternatives FROM RequiredParts WHERE SAPId = '" + sAPIdTextBox.Text + "' AND RequiredSAPId = '" + RequiredSAPID + "'";
        //    try
        //    {
        //        SqlCeDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            requiredPartAlternativesListBox.Items.Add(reader[0].ToString());
        //        }
        //        reader.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    TecanDatabase.Close();
        //}

        //private void partsListBindingNavigator_RefreshItems(object sender, EventArgs e)
        //{

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}

        //private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        //{

        //}
        private void openDB()
        {
            TecanDatabase = new SqlCeConnection();
            String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanDatabase.Open();
        }

        private void detailDescriptionLabel_Click(object sender, EventArgs e)
        {

        }

        private void detailDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void standarPriceTextBox_GotFocus(object sender, EventArgs e)
        {
            standarPriceTextBox.SelectionStart = standarPriceTextBox.Text.Length;
        }

        private void standarPriceTextBox_LostFocus(object sender, EventArgs e)
        {
            if (standarPriceTextBox.Text.IndexOf("$") == -1)
            {
                standarPriceTextBox.Text = getFormatedDollarValue(standarPriceTextBox.Text);
            }
        }

        private void standarPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (standarPriceTextBox.Focused != true)
            {
                if (standarPriceTextBox.Text.IndexOf("$") == -1)
                {
                    standarPriceTextBox.Text = getFormatedDollarValue(standarPriceTextBox.Text);
                }
            }
        }

        private void iLPTextBox_GotFocus(object sender, EventArgs e)
        {
            iLPTextBox.SelectionStart = iLPTextBox.Text.Length;
        }

        private void iLPTextBox_LostFocus(object sender, EventArgs e)
        {
            if (iLPTextBox.Text.IndexOf("$") == -1)
            {
                iLPTextBox.Text = getFormatedDollarValue(iLPTextBox.Text);
            }
        }

        private void iLPTextBox_TextChanged(object sender, EventArgs e)
        {
            if (iLPTextBox.Focused != true)
            {
                if (iLPTextBox.Text.IndexOf("$") == -1)
                {
                    iLPTextBox.Text = getFormatedDollarValue(iLPTextBox.Text);
                }
            }
        }

        private void manufacturingCostTextBox_GotFocus(object sender, EventArgs e)
        {
            manufacturingCostTextBox.SelectionStart = manufacturingCostTextBox.Text.Length;
        }

        private void manufacturingCostTextBox_LostFocus(object sender, EventArgs e)
        {
            if (manufacturingCostTextBox.Text.IndexOf("$") == -1)
            {
                manufacturingCostTextBox.Text = getFormatedDollarValue(manufacturingCostTextBox.Text);
            }
        }

        private void manufacturingCostTextBox_TextChanged(object sender, EventArgs e)
        {
            if (manufacturingCostTextBox.Focused != true)
            {
                if (manufacturingCostTextBox.Text.IndexOf("$") == -1)
                {
                    manufacturingCostTextBox.Text = getFormatedDollarValue(manufacturingCostTextBox.Text);
                }
            }            
        }

        private void aSPTextBox_GotFocus(object sender, EventArgs e)
        {
            aSPTextBox.SelectionStart = aSPTextBox.Text.Length;
        }

        private void aSPTextBox_LostFocus(object sender, EventArgs e)
        {
            if (aSPTextBox.Text.IndexOf("$") == -1)
            {
                aSPTextBox.Text = getFormatedDollarValue(aSPTextBox.Text);
            }
        }

        private void aSPTextBox_TextChanged(object sender, EventArgs e)
        {
            if (aSPTextBox.Focused != true)
            {
                if (aSPTextBox.Text.IndexOf("$") == -1)
                {
                    aSPTextBox.Text = getFormatedDollarValue(aSPTextBox.Text);
                }
            }
        }
        
        private void plPriceTextBox_GotFocus(object sender, EventArgs e)
        {
            plPriceTextBox.SelectionStart = plPriceTextBox.Text.Length;
        }

        private void plPriceTextBox_LostFocus(object sender, EventArgs e)
        {
            if (plPriceTextBox.Text.IndexOf("$") == -1)
            {
                plPriceTextBox.Text = getFormatedDollarValue(plPriceTextBox.Text);
            }
        }

        private void plPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (plPriceTextBox.Focused != true)
            {
                if (plPriceTextBox.Text.IndexOf("$") == -1)
                {
                    plPriceTextBox.Text = getFormatedDollarValue(plPriceTextBox.Text);
                }
            }
        }
        
        private String getFormatedDollarValue(String dollarString)
        {
            String dollardValue = dollarString;
            Decimal d = Decimal.Parse(dollardValue, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-US"));
            dollardValue = String.Format("{0:C2}", d);
            return dollardValue;
        }

        private int GetDecimals(decimal d, int i = 0)
        {
            decimal multiplied = (decimal)((double)d * Math.Pow(10, i));
            if (Math.Round(multiplied) == multiplied)
                return i;
            return GetDecimals(d, i + 1);
        }

        private void PLAddedInfoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PLAddedInfoCheckBox.CheckState == CheckState.Checked)
            {
                pLDescriptionTextBox.Text = "Please contact Tecan for additional information and pricing.";
            }
            else
            {
                pLDescriptionTextBox.Text = "";
            }
        }

        // Duplicate Part Menu Item
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if(hasSAPID) 
                NewSAPIDPanel.Visible = true;
        }

        private void AddNewSAPIDButton_Click(object sender, EventArgs e)
        {
            if (NewSAPIDTextBox.Text != "")
            {
                hasSAPID = false;
                sAPIdTextBox.Text = NewSAPIDTextBox.Text;
            }
            NewSAPIDPanel.Visible = false;
        }

        private void CancelAddNewSAPIDButton_Click(object sender, EventArgs e)
        {
            NewSAPIDPanel.Visible = false;
        }


    }
}
