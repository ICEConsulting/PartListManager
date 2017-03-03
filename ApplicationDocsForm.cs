using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;
using System.Diagnostics;

namespace TecanPartListManager
{
    public partial class ApplicationDocsForm : Form
    {

        SqlCeConnection TecanAppDocDatabase = null;

        public ApplicationDocsForm()
        {
            InitializeComponent();
        }

        private void loadAppDocs(object sender, EventArgs e)
        {
            openAppDocDatabase();
            SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();
            
            // Load Top Documents into List
            cmd.CommandText = "SELECT D.DocID, D.FileName, D.DocumentDescription, C.AppCategoryName FROM Documents D" +
            " INNER JOIN ApplicationCategories C" +
            " ON D.ApplicationCategory = C.AppCategoryID" +
            " WHERE DocumentPosition = 1";

            try
            {
                SqlCeDataReader reader = cmd.ExecuteReader();

                int docCount = 0;
                while (reader.Read())
                {
                    TopDocumentsListView.Items.Add("");
                    TopDocumentsListView.Items[docCount].SubItems.Add(reader[0].ToString());
                    TopDocumentsListView.Items[docCount].SubItems.Add(reader[1].ToString());
                    TopDocumentsListView.Items[docCount].SubItems.Add(reader[2].ToString());
                    TopDocumentsListView.Items[docCount].SubItems.Add(reader[3].ToString());
                    docCount++;
                }
                reader.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading Header List: " + ex.Message);
            }

            // Load Categories List
            LoadCatList();

            // Load Body Documents into List
            cmd.CommandText = "SELECT D.DocID, D.FileName, D.DocumentDescription, C.AppCategoryName FROM Documents D" +
            " INNER JOIN ApplicationCategories C" +
            " ON D.ApplicationCategory = C.AppCategoryID" +
            " WHERE DocumentPosition = 2";

            try
            {
                SqlCeDataReader reader = cmd.ExecuteReader();

                int docCount = 0;
                while (reader.Read())
                {
                    BodyDocumentsListView.Items.Add("");
                    BodyDocumentsListView.Items[docCount].SubItems.Add(reader[0].ToString());
                    BodyDocumentsListView.Items[docCount].SubItems.Add(reader[1].ToString());
                    BodyDocumentsListView.Items[docCount].SubItems.Add(reader[2].ToString());
                    BodyDocumentsListView.Items[docCount].SubItems.Add(reader[3].ToString());
                    docCount++;
                }
                reader.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading Body List: " + ex.Message);
            }

            // Load Footer Document textbox
            cmd.CommandText = "SELECT FileName FROM Documents WHERE DocumentPosition = 3";
            try
            {
                SqlCeDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FooterDocumentTextBox.Text = reader[0].ToString();
                }
                reader.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            TecanAppDocDatabase.Close();
        }

        private void LoadCatList()
        {
            openAppDocDatabase();
            SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();

            cmd.CommandText = "SELECT AppCategoryID, AppCategoryName FROM ApplicationCategories";
            try
            {
                SqlCeDataReader reader = cmd.ExecuteReader();
                int catCount = 0;
                while (reader.Read())
                {
                    CategoryListView.Items.Add("");
                    CategoryListView.Items[catCount].SubItems.Add(reader[0].ToString());
                    CategoryListView.Items[catCount].SubItems.Add(reader[1].ToString());
                    catCount++;
                }
                reader.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading Categories List: " + ex.Message);
            }
            TecanAppDocDatabase.Close();
        }

        private void openAppDocDatabase()
        {
            TecanAppDocDatabase = new SqlCeConnection();
            String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            TecanAppDocDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanAppDocs.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanAppDocDatabase.Open();
        }

        private void headerDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will delete the all Header Application Documents and replace them.\r\n\r\nDo you want to proceed?", "Import Header Application Documents", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            else
            {

                openAppDocDatabase();
                SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();

                // Delete current header documents
                cmd.CommandText = "DELETE FROM Documents WHERE DocumentPosition = 1";
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to Delete " + ex.Message);
                }

                int docID = getLastDocId();
                
                String appDocPath, appDocFileName, appDocExt, appDocDescription;
                Byte[] appDocData;
                long appDocNumBytes;
                String[] appDocList;

                appDocPath = getHeaderAppDocPath();
                if (appDocPath == "")
                {
                    TecanAppDocDatabase.Close();
                    return;
                }

                appDocList = Directory.GetFiles(appDocPath);

                foreach (string appDocPathandName in appDocList)
                {
                    FileInfo appDocFileInfo = new FileInfo(appDocPathandName);
                    appDocNumBytes = appDocFileInfo.Length;
                    FileStream appDocContents = new FileStream(appDocPathandName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(appDocContents);
                    appDocData = br.ReadBytes((int)appDocNumBytes);
                    appDocContents.Close();

                    appDocFileName = appDocFileInfo.Name.ToLower();
                    appDocExt = appDocFileInfo.Extension.Replace(".", "").ToLower();
                    appDocDescription = appDocFileInfo.Name.Substring(0, (appDocFileInfo.Name.Length - appDocExt.Length) - 1);
                    cmd.CommandText = "INSERT INTO Documents (DocID, DocExtension, Document, FileName, DocumentDescription, DocumentPosition)" +
                        " Values " +
                        "(@DocID, @DocExtension, @Document, @FileName, @DocumentDescription, @DocumentPosition)";

                    cmd.Parameters.AddWithValue("@DocId", docID);
                    cmd.Parameters.AddWithValue("@DocExtension", appDocExt);
                    cmd.Parameters.AddWithValue("@Document", appDocData);
                    cmd.Parameters.AddWithValue("@FileName", appDocFileName);
                    cmd.Parameters.AddWithValue("@DocumentDescription", appDocDescription);
                    cmd.Parameters.AddWithValue("@DocumentPosition", 1);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Please correct the Application Document Filename and add to database manually \n\n " + appDocFileName + "\n\n" + ex.Message + "\n\n" + ex.TargetSite);
                    }
                    cmd.Parameters.Clear();
                    appDocContents.Dispose();
                    // br.Dispose();
                    docID++;
                }
                TecanAppDocDatabase.Close();
                loadAppDocs(sender, e);
            }
        }

        private string getHeaderAppDocPath()
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Please select your HEADER Application Documents Files folder";
            folderBrowserDialog1.ShowNewFolderButton = false;

            String myPath = "";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                myPath = folderBrowserDialog1.SelectedPath;
            }

            return myPath;

        }

        // Add Body Application Documents to database
        private void bodyDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will delete the all Body Application Documents and replace them.\r\n\r\nDo you want to proceed?", "Import Header Application Documents", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            else
            {

                openAppDocDatabase();
                SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();

                // Delete current body documents
                cmd.CommandText = "DELETE FROM Documents WHERE DocumentPosition = 2";
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to Delete");
                }

                int docID = getLastDocId();

                String appDocPath, appDocFileName, appDocExt, appDocDescription;
                Byte[] appDocData;
                long appDocNumBytes;
                String[] appDocList;
                String[] AppDocsFolders;

                appDocPath = getAppDocPath();
                if (appDocPath == "")
                {
                    TecanAppDocDatabase.Close();
                    return;
                }

                appDocList = Directory.GetFiles(appDocPath);

                foreach (string appDocPathandName in appDocList)
                {
                    FileInfo appDocFileInfo = new FileInfo(appDocPathandName);
                    appDocNumBytes = appDocFileInfo.Length;
                    FileStream appDocContents = new FileStream(appDocPathandName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(appDocContents);
                    appDocData = br.ReadBytes((int)appDocNumBytes);
                    appDocContents.Close();

                    appDocFileName = appDocFileInfo.Name.ToLower();
                    appDocExt = appDocFileInfo.Extension.Replace(".", "").ToLower();
                    appDocDescription = appDocFileInfo.Name.Substring(0, (appDocFileInfo.Name.Length - appDocExt.Length) - 1);
                    cmd.CommandText = "INSERT INTO Documents (DocID, DocumentName, DocExtension, FileName, Document, DocumentDescription, DocumentPosition, ApplicationCategory, IsSmartStart)" +
                        " Values " +
                        "(@DocID, @DocumentName, @DocExtension, @FileName, @Document, @DocumentDescription, @DocumentPosition, @ApplicationCategory, @IsSmartStart)";

                    cmd.Parameters.AddWithValue("@DocId", docID);
                    cmd.Parameters.AddWithValue("@DocumentName", appDocFileName);
                    cmd.Parameters.AddWithValue("@DocExtension", appDocExt);
                    cmd.Parameters.AddWithValue("@FileName", appDocFileName);
                    cmd.Parameters.AddWithValue("@Document", appDocData);
                    cmd.Parameters.AddWithValue("@DocumentDescription", appDocDescription);
                    cmd.Parameters.AddWithValue("@DocumentPosition", 2);
                    cmd.Parameters.AddWithValue("@ApplicationCategory", 1);
                    cmd.Parameters.AddWithValue("@IsSmartStart", 0);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Please correct the Application Document Filename and add to database manually \n\n " + appDocFileName + "\n\n" + ex.Message + "\n\n" + ex.TargetSite);
                    }
                    cmd.Parameters.Clear();
                    appDocContents.Dispose();
                    // br.Dispose();
                    docID++;
                }

                String appDocCategory = "";
                AppDocsFolders = Directory.GetDirectories(appDocPath);
                foreach (string subDir in AppDocsFolders)
                {
                    appDocCategory = subDir.Substring(subDir.LastIndexOf('\\') + 1);
                    appDocList = Directory.GetFiles(subDir, "*.pdf");
                    foreach (string appDocPathandName in appDocList)
                    {
                        FileInfo appDocFileInfo = new FileInfo(appDocPathandName);
                        appDocNumBytes = appDocFileInfo.Length;
                        FileStream appDocContents = new FileStream(appDocPathandName, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(appDocContents);
                        appDocData = br.ReadBytes((int)appDocNumBytes);
                        appDocContents.Close();

                        appDocFileName = appDocFileInfo.Name.ToLower();
                        appDocExt = appDocFileInfo.Extension.Replace(".", "").ToLower();
                        appDocDescription = appDocFileInfo.Name.Substring(0, appDocFileInfo.Name.Length - appDocExt.Length - 1);
                        cmd.CommandText = "INSERT INTO Documents (DocID, DocumentName, DocExtension, FileName, Document, DocumentDescription, DocumentPosition, ApplicationCategory, IsSmartStart)" +
                            " Values " +
                            "(@DocID, @DocumentName, @DocExtension, @FileName, @Document, @DocumentDescription, @DocumentPosition, @ApplicationCategory, @IsSmartStart)";

                        cmd.Parameters.AddWithValue("@DocId", docID);
                        cmd.Parameters.AddWithValue("@DocumentName", appDocFileName);
                        cmd.Parameters.AddWithValue("@DocExtension", appDocExt);
                        cmd.Parameters.AddWithValue("@FileName", appDocFileName);
                        cmd.Parameters.AddWithValue("@Document", appDocData);
                        cmd.Parameters.AddWithValue("@DocumentDescription", appDocDescription);
                        cmd.Parameters.AddWithValue("@DocumentPosition", 2);
                        cmd.Parameters.AddWithValue("@ApplicationCategory", 1);
                        if (appDocCategory == "Smart Start")
                        {
                            cmd.Parameters.AddWithValue("@IsSmartStart", 1);
                            cmd.Parameters.AddWithValue("@DocumentPosition", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@IsSmartStart", 0);
                            cmd.Parameters.AddWithValue("@DocumentPosition", 2);
                        }
                        cmd.Parameters.AddWithValue("@IsSmartStart", 0);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Sub-Directories, Please correct the Application Document Filename and add to database manually \n\n " + appDocFileName + "\n\n" + ex.Message + "\n\n" + ex.TargetSite);
                        }
                        cmd.Parameters.Clear();
                        appDocContents.Dispose();
                        // br.Dispose();
                        docID++;
                    }
                }

                TecanAppDocDatabase.Close();
                loadAppDocs(sender, e);
            }
        }

        private int getLastDocId()
        {
            int docCount = 0;

            openAppDocDatabase();
            SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();

            cmd.CommandText = "SELECT DocID FROM Documents ORDER BY DocID";
            try
            {
                SqlCeDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    docCount = Convert.ToInt32(reader[0].ToString());
                }
                reader.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get Last Doc ID: " + ex.Message);
            }
            docCount++;
            return docCount;
        }

        private String getAppDocPath()
        {

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Please select your BODY Application Documents Files folder";
            folderBrowserDialog1.ShowNewFolderButton = false;

            String myPath = "";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                myPath = folderBrowserDialog1.SelectedPath;
            }

            return myPath;

        }

        private void TopDocumentsListView_Click(object sender, EventArgs e)
        {
            BodyDocumentsListView.SelectedIndices.Clear();
            AppDocEditPanelHeader.Text = "Edit Header Application Document";
            IsSmartStartCheckBox.Visible = true;
            AppDocEditPanel.Visible = true;
            Int32 EditDocID = Convert.ToInt32(TopDocumentsListView.SelectedItems[0].SubItems[1].Text);
            LoadAppDocEditPanel(EditDocID);
        }

        private void BodyDocumentsListView_Click(object sender, EventArgs e)
        {
            TopDocumentsListView.SelectedIndices.Clear();
            AppDocEditPanelHeader.Text = "Edit Body Application Document";
            IsSmartStartCheckBox.Visible = false;
            AppDocEditPanel.Visible = true;
            Int32 EditDocID = Convert.ToInt32(BodyDocumentsListView.SelectedItems[0].SubItems[1].Text);
            LoadAppDocEditPanel(EditDocID);
        }

        private void LoadAppDocEditPanel(int EditDocID)
        {
            openAppDocDatabase();
            SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();
            SqlCeDataReader reader;

            // Load Load AppCat combobox
            cmd.CommandText = "SELECT AppCategoryID, AppCategoryName FROM ApplicationCategories";
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("AppCategoryID");
            dt.Columns.Add("AppCategoryName");
            dt.Load(reader);
            AppDocCatComboBox.ValueMember = "AppCategoryID";
            AppDocCatComboBox.DisplayMember = "AppCategoryName";
            AppDocCatComboBox.DataSource = dt;
            String SSTest;

            // Load Document details into Edit Panel
            cmd.CommandText = "SELECT DocID, FileName, DocumentDescription, ApplicationCategory, IsSmartStart FROM Documents WHERE DocID = '" + EditDocID + "'";
            try
            {
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AppDocIDTextBox.Text = reader[0].ToString();
                    AppDocFilenameTextBox.Text = reader[1].ToString();
                    AppDocDescriptionTextBox.Text = reader[2].ToString();
                    AppDocCatComboBox.SelectedValue = reader[3];
                    SSTest = reader[4].ToString();
                    if (SSTest != "")
                    {
                        if (IsSmartStartCheckBox.Visible == true)
                        {
                            if (Convert.ToInt16(reader[4]) == 1)
                            {
                                IsSmartStartCheckBox.Checked = true;
                            }
                            else
                            {
                                IsSmartStartCheckBox.Checked = false;
                            }
                        }
                    }
                }
                reader.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            TecanAppDocDatabase.Close();
        }

        private void AppDocCancelButton_Click(object sender, EventArgs e)
        {
            AppDocEditPanel.Visible = false;
        }

        private void AppDocDeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you certain you want to delete " + AppDocDescriptionTextBox.Text + " .\r\n\r\nDo you want to proceed?", "Delete Application Document", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            else
            {

                openAppDocDatabase();
                SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();

                // Delete current document
                cmd.CommandText = "DELETE FROM Documents WHERE DocID = " + Convert.ToInt32(AppDocIDTextBox.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to Delete");
                }
                TecanAppDocDatabase.Close();
                // update listviews contents
                int whichSelected;
                if (TopDocumentsListView.SelectedIndices.Count > 0)
                {
                    whichSelected = TopDocumentsListView.SelectedIndices[0];
                    TopDocumentsListView.Items.RemoveAt(whichSelected);
                }
                if (BodyDocumentsListView.SelectedIndices.Count > 0)
                {
                    whichSelected = BodyDocumentsListView.SelectedIndices[0];
                    BodyDocumentsListView.Items.RemoveAt(whichSelected);
                }
                AppDocEditPanel.Visible = false;
            }

        }

        private void AppDocEditUpdateButton_Click(object sender, EventArgs e)
        {
            openAppDocDatabase();
            SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();
            // Update current document... Save Changes Button

            cmd.CommandText = "UPDATE Documents SET [FileName] = @FileName, [DocumentDescription] = @Description, [ApplicationCategory] = @ApplicationCategory, [IsSmartStart] = @IsSmartStart" +
                " WHERE DocID = " + Convert.ToInt32(AppDocIDTextBox.Text);

            cmd.Parameters.AddWithValue("@FileName", AppDocFilenameTextBox.Text);
            cmd.Parameters.AddWithValue("@Description", AppDocDescriptionTextBox.Text);
            cmd.Parameters.AddWithValue("@ApplicationCategory", AppDocCatComboBox.SelectedValue);
            if (IsSmartStartCheckBox.Visible == true)
            {
                if (IsSmartStartCheckBox.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@IsSmartStart", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsSmartStart", 0);
                }
            }
            else
            {
                cmd.Parameters.AddWithValue("@IsSmartStart", 0);
            }

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            cmd.Parameters.Clear();
            TecanAppDocDatabase.Close();
            // update listviews contents
            int whichSelected;
            if (TopDocumentsListView.SelectedIndices.Count > 0)
            {
                whichSelected = TopDocumentsListView.SelectedIndices[0];
                TopDocumentsListView.Items[whichSelected].SubItems[2].Text = AppDocFilenameTextBox.Text;
                TopDocumentsListView.Items[whichSelected].SubItems[3].Text = AppDocDescriptionTextBox.Text;
                TopDocumentsListView.Items[whichSelected].SubItems[4].Text = AppDocCatComboBox.Text;
            }
            if (BodyDocumentsListView.SelectedIndices.Count > 0)
            {
                whichSelected = BodyDocumentsListView.SelectedIndices[0];
                BodyDocumentsListView.Items[whichSelected].SubItems[2].Text = AppDocFilenameTextBox.Text;
                BodyDocumentsListView.Items[whichSelected].SubItems[3].Text = AppDocDescriptionTextBox.Text;
                BodyDocumentsListView.Items[whichSelected].SubItems[4].Text = AppDocCatComboBox.Text;
            }
            AppDocEditPanel.Visible = false;
        }

        private void AddHeaderDocButton_Click(object sender, EventArgs e)
        {
            if(AppDocEditPanel.Visible == true) AppDocEditPanel.Visible = false;
            AddSingleDoc(1);
        }

        private void AddBodyDocumentButton_Click(object sender, EventArgs e)
        {
            if (AppDocEditPanel.Visible == true) AppDocEditPanel.Visible = false;
            AddSingleDoc(2);
        }

        private void AddFooterDocumentButton_Click(object sender, EventArgs e)
        {
            if (AppDocEditPanel.Visible == true) AppDocEditPanel.Visible = false;
            if (FooterDocumentTextBox.Text != "")
            {
                if (MessageBox.Show("Are you certain you want to replace " + FooterDocumentTextBox.Text + " .\r\n\r\nDo you want to proceed?", "Replace Footer Document", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    openAppDocDatabase();
                    SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();

                    // Delete current document
                    cmd.CommandText = "DELETE FROM Documents WHERE DocumentPosition = 3";
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to Delete");
                    }
                    TecanAppDocDatabase.Close();
                    AddSingleDoc(3);
                }
            }
        }

        private void AppDocReplaceFileButton_Click(object sender, EventArgs e)
        {
            if (AppDocEditPanelHeader.Text == "Edit Header Application Document")
            {
                AddSingleDoc(1);
            }
            else
            {
                AddSingleDoc(2);
            }
            loadAppDocs(sender, e);
        }

        private void AddSingleDoc(int DocumenrtPosition)
        {
            int docID;
            if (AppDocEditPanel.Visible == true)
            {
                docID = Convert.ToInt32(AppDocIDTextBox.Text);
            }
            else
            {
                docID = getLastDocId();
            }

            String appDocPath, appDocFileName, appDocExt, appDocDescription;
            Byte[] appDocData;
            long appDocNumBytes;

            // Get Filename and Path
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.Filter = "pdf files (*.pdf)|*.pdf";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                appDocPath = openFileDialog1.FileName;
                FileInfo appDocFileInfo = new FileInfo(appDocPath);
                appDocNumBytes = appDocFileInfo.Length;
                FileStream appDocContents = new FileStream(appDocPath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(appDocContents);
                appDocData = br.ReadBytes((int)appDocNumBytes);
                appDocContents.Close();

                appDocFileName = appDocFileInfo.Name.ToLower();
                appDocExt = appDocFileInfo.Extension.Replace(".", "").ToLower();
                appDocDescription = appDocFileInfo.Name.Substring(0, (appDocFileInfo.Name.Length - appDocExt.Length) - 1);

                openAppDocDatabase();
                SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();

                if (AppDocEditPanel.Visible == false)
                {
                    cmd.CommandText = "INSERT INTO Documents (DocID, DocExtension, Document, FileName, DocumentDescription, DocumentPosition)" +
                        " Values " +
                        "(@DocID, @DocExtension, @Document, @FileName, @DocumentDescription, @DocumentPosition)";

                    cmd.Parameters.AddWithValue("@DocId", docID);
                    cmd.Parameters.AddWithValue("@DocExtension", appDocExt);
                    cmd.Parameters.AddWithValue("@Document", appDocData);
                    cmd.Parameters.AddWithValue("@FileName", appDocFileName);
                    cmd.Parameters.AddWithValue("@DocumentDescription", appDocDescription);
                    cmd.Parameters.AddWithValue("@DocumentPosition", DocumenrtPosition);
                }
                else
                {
                    cmd.CommandText = "UPDATE Documents SET [DocExtension] = @DocExtension, [Document] = @Document, [FileName] = @FileName," +
                        " [DocumentDescription] = @DocumentDescription, [DocumentPosition] = @DocumentPosition, [ApplicationCategory] = @ApplicationCategory," + 
                        " [IsSmartStart] = @IsSmartStart WHERE DocID = " + docID;

                    cmd.Parameters.AddWithValue("@DocExtension", appDocExt);
                    cmd.Parameters.AddWithValue("@Document", appDocData);
                    cmd.Parameters.AddWithValue("@FileName", appDocFileName);
                    cmd.Parameters.AddWithValue("@DocumentDescription", appDocDescription);
                    cmd.Parameters.AddWithValue("@DocumentPosition", DocumenrtPosition);
                    cmd.Parameters.AddWithValue("@ApplicationCategory", AppDocCatComboBox.SelectedValue);
                    if (IsSmartStartCheckBox.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@IsSmartStart", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@IsSmartStart", 0);
                    }
                    AppDocEditPanel.Visible = false;
                }
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please correct the Application Document Filename and add to database manually \n\n " + appDocFileName + "\n\n" + ex.Message + "\n\n" + ex.TargetSite);
                }
                cmd.Parameters.Clear();
                TecanAppDocDatabase.Close();
                appDocContents.Dispose();
                // br.Dispose();

                switch (DocumenrtPosition)
                {
                    case 1:
                        AppDocEditPanelHeader.Text = "Edit Header Application Document";
                        IsSmartStartCheckBox.Visible = true;
                        AppDocEditPanel.Visible = true;
                        LoadAppDocEditPanel(docID);
                        break;

                    case 2:                    
                        AppDocEditPanelHeader.Text = "Edit Body Application Document";
                        IsSmartStartCheckBox.Visible = false;
                        AppDocEditPanel.Visible = true;
                        LoadAppDocEditPanel(docID);
                        break;
                }
            }

        }

        private void ViewDocumentButton_Click(object sender, EventArgs e)
        {
            Int32 EditDocID = Convert.ToInt32(AppDocIDTextBox.Text);
            String Filename = AppDocFilenameTextBox.Text;
            openAppDocDatabase();
            SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();
            cmd.CommandText = "SELECT Document FROM Documents WHERE DocID = '" + EditDocID + "'";
            SqlCeDataReader reader = cmd.ExecuteReader();
            reader = cmd.ExecuteReader();
            Byte[] documentData = new Byte[0];
            while (reader.Read())
            {
                documentData = (byte[])reader[0];
            }
            reader.Dispose();
            TecanAppDocDatabase.Close();

            // Create the new file in temp directory
            String tempFilePath = @AppDomain.CurrentDomain.BaseDirectory.ToString() + "temp";
            System.IO.Directory.CreateDirectory(tempFilePath);

            // If temp directory current contains any files, delete them
            System.IO.DirectoryInfo tempFiles = new DirectoryInfo(tempFilePath);

            foreach (FileInfo file in tempFiles.GetFiles())
            {
                file.Delete();
            }

            String fullFilePathName = @tempFilePath + "\\" + Filename;
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

        private void AddCatButton_Click(object sender, EventArgs e)
        {
            RenameCatButton.Visible = false;
            DeleteCatButton.Visible = false;
            AddNewCatButton.Visible = true;
            CatPanel.Visible = true;
            AddEditCategoryTextBox.Focus();
        }

        private void AddNewCatButton_Click(object sender, EventArgs e)
        {
            if (AddEditCategoryTextBox.Text != "")
            {
                int NewCatID = getlastCatID();

                openAppDocDatabase();
                SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();

                cmd.CommandText = "INSERT INTO ApplicationCategories (AppCategoryID, AppCategoryName) Values (@AppCategoryID, @AppCategoryName)";

                cmd.Parameters.AddWithValue("@AppCategoryID", NewCatID);
                cmd.Parameters.AddWithValue("@AppCategoryName", AddEditCategoryTextBox.Text);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                TecanAppDocDatabase.Close();
                CatPanel.Visible = false;
                CategoryListView.Items.Add("");
                CategoryListView.Items[CategoryListView.Items.Count-1].SubItems.Add(NewCatID.ToString());
                CategoryListView.Items[CategoryListView.Items.Count-1].SubItems.Add(AddEditCategoryTextBox.Text);
            }

        }

        private int getlastCatID()
        {
            Int16 NewCatID = 0;
            openAppDocDatabase();
            SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();
            cmd.CommandText = "SELECT AppCategoryID FROM ApplicationCategories ORDER BY AppCategoryID";

            SqlCeDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                NewCatID = Convert.ToInt16(reader[0]);
            }
            reader.Dispose();
            TecanAppDocDatabase.Close();
            return NewCatID++;
        }

        private void CategoryListView_DoubleClick(object sender, EventArgs e)
        {
            RenameCatButton.Visible = true;
            DeleteCatButton.Visible = true;
            AddNewCatButton.Visible = false;
            CatPanel.Visible = true;
            CurrentCatID.Text = CategoryListView.SelectedItems[0].SubItems[1].Text;
            AddEditCategoryTextBox.Text = CategoryListView.SelectedItems[0].SubItems[2].Text;
            AddEditCategoryTextBox.Focus();
        }

        private void CancelCatButton_Click(object sender, EventArgs e)
        {
            CatPanel.Visible = false;
        }

        private void RenameCatButton_Click(object sender, EventArgs e)
        {
            openAppDocDatabase();
            SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();

            cmd.CommandText = "UPDATE ApplicationCategories SET [AppCategoryName] = @NewCatName WHERE AppCategoryID = " + Convert.ToInt32(CurrentCatID.Text);
            cmd.Parameters.AddWithValue("@NewCatName", AddEditCategoryTextBox.Text);            
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            TecanAppDocDatabase.Close();
            int whichSelected;
            if (CategoryListView.SelectedIndices.Count > 0)
            {
                whichSelected = CategoryListView.SelectedIndices[0];
                CategoryListView.Items[whichSelected].SubItems[2].Text = AddEditCategoryTextBox.Text;
            }
            CatPanel.Visible = false;
        }

        private void DeleteCatButton_Click(object sender, EventArgs e)
        {
            int docCount = 0;
            openAppDocDatabase();
            SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();

            cmd.CommandText = "SELECT DocID FROM Documents WHERE ApplicationCategory = " + Convert.ToInt32(CurrentCatID.Text);
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                docCount++;
            }
            reader.Dispose();
            if (docCount > 0)
            {
                MessageBox.Show("There are documents in application category " + AddEditCategoryTextBox.Text +
                    ".\n\nPlease change the document categories before deleting this category.");
            }
            else
            {
                cmd.CommandText = "DELETE FROM ApplicationCategories WHERE AppCategoryID = " + Convert.ToInt32(CurrentCatID.Text);
                cmd.ExecuteNonQuery();
                int whichSelected;
                if (CategoryListView.SelectedIndices.Count > 0)
                {
                    whichSelected = CategoryListView.SelectedIndices[0];
                    CategoryListView.Items.RemoveAt(whichSelected);
                }

            }
            TecanAppDocDatabase.Close();
            CatPanel.Visible = false;
        }

    }
}
