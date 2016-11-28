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
            loadAppDocs();
        }

        private void loadAppDocs()
        {
            openAppDocDatabase();
            SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();


            // Load Top Documents into List
            TopDocumentsListView.Items.Clear(); 
            cmd.CommandText = "SELECT DocID, FileName, DocumentDescription, SmartStartTitle FROM Documents WHERE DocumentPosition = 'Header'";
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

            // Load Body Documents into List
            BodyDocumentsListView.Items.Clear();
            cmd.CommandText = "SELECT DocID, FileName, DocumentDescription, ApplicationCategory FROM Documents WHERE DocumentPosition = 'Body'";
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
            cmd.CommandText = "SELECT FileName FROM Documents WHERE DocumentPosition = 'Footer'";
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
                cmd.CommandText = "DELETE FROM Documents WHERE DocumentPosition = 'Header'";
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
                    cmd.Parameters.AddWithValue("@DocumentPosition", "Header");
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
                loadAppDocs();
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
                cmd.CommandText = "DELETE FROM Documents WHERE DocumentPosition = 'Body'";
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
                    cmd.CommandText = "INSERT INTO Documents (DocID, DocExtension, Document, FileName, DocumentDescription, DocumentPosition, ApplicationCategory)" +
                        " Values " +
                        "(@DocID, @DocExtension, @Document, @FileName, @DocumentDescription, @DocumentPosition, @ApplicationCategory)";

                    cmd.Parameters.AddWithValue("@DocId", docID);
                    cmd.Parameters.AddWithValue("@DocExtension", appDocExt);
                    cmd.Parameters.AddWithValue("@Document", appDocData);
                    cmd.Parameters.AddWithValue("@FileName", appDocFileName);
                    cmd.Parameters.AddWithValue("@DocumentDescription", appDocDescription);
                    cmd.Parameters.AddWithValue("@DocumentPosition", "Body");
                    cmd.Parameters.AddWithValue("@ApplicationCategory", "");
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
                foreach (string subDir in Directory.GetDirectories(appDocPath))
                {
                    appDocList = Directory.GetFiles(subDir);
                    appDocCategory = subDir.Substring(appDocPath.Length + 1, (subDir.Length - appDocPath.Length) - 1);
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
                        cmd.CommandText = "INSERT INTO Documents (DocID, DocExtension, Document, FileName, DocumentDescription, DocumentPosition, ApplicationCategory)" +
                            " Values " +
                            "(@DocID, @DocExtension, @Document, @FileName, @DocumentDescription, @DocumentPosition, @ApplicationCategory)";

                        cmd.Parameters.AddWithValue("@DocId", docID);
                        cmd.Parameters.AddWithValue("@DocExtension", appDocExt);
                        cmd.Parameters.AddWithValue("@Document", appDocData);
                        cmd.Parameters.AddWithValue("@FileName", appDocFileName);
                        cmd.Parameters.AddWithValue("@DocumentDescription", appDocDescription);
                        cmd.Parameters.AddWithValue("@DocumentPosition", "Body");
                        cmd.Parameters.AddWithValue("@ApplicationCategory", appDocCategory);
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
                loadAppDocs();
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
            AppDocEditPanelHeader.Text = "Edit Header Application Document";
            SmartStartLabel.Visible = true;
            AppDocSmartStartTitleTextBox.Visible = true;
            AppCatLabel.Visible = false;
            AppDocAppCatTextBox.Visible = false;
            AppDocEditPanel.Visible = true;
            Int32 EditDocID = Convert.ToInt32(TopDocumentsListView.SelectedItems[0].SubItems[1].Text);
            LoadAppDocEditPanel(EditDocID, "Header");
        }

        private void BodyDocumentsListView_Click(object sender, EventArgs e)
        {
            AppDocEditPanelHeader.Text = "Edit Body Application Document";
            SmartStartLabel.Visible = false;
            AppDocSmartStartTitleTextBox.Visible = false;
            AppCatLabel.Visible = true;
            AppDocAppCatTextBox.Visible = true;
            AppDocEditPanel.Visible = true;
            Int32 EditDocID = Convert.ToInt32(BodyDocumentsListView.SelectedItems[0].SubItems[1].Text);
            LoadAppDocEditPanel(EditDocID, "Body");
        }

        private void LoadAppDocEditPanel(int EditDocID, string DocPosition)
        {
            openAppDocDatabase();
            SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();

            if (DocPosition == "Header")
            {
                // Load Top Documents into Panel Textboxes
                cmd.CommandText = "SELECT DocID, FileName, DocumentDescription, SmartStartTitle FROM Documents WHERE DocID = '" + EditDocID + "'";
                try
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AppDocIDTextBox.Text = reader[0].ToString();
                        AppDocFilenameTextBox.Text = reader[1].ToString();
                        AppDocDescriptionTextBox.Text = reader[2].ToString();
                        AppDocSmartStartTitleTextBox.Text = reader[3].ToString();
                    }
                    reader.Dispose();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                // Load Body Documents into Panel Textboxes
                cmd.CommandText = "SELECT DocID, FileName, DocumentDescription, ApplicationCategory FROM Documents WHERE DocID = '" + EditDocID + "'";
                try
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AppDocIDTextBox.Text = reader[0].ToString();
                        AppDocFilenameTextBox.Text = reader[1].ToString();
                        AppDocDescriptionTextBox.Text = reader[2].ToString();
                        AppDocAppCatTextBox.Text = reader[3].ToString();
                    }
                    reader.Dispose();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
                AppDocEditPanel.Visible = false;
                loadAppDocs();
            }

        }

        private void AppDocEditUpdateButton_Click(object sender, EventArgs e)
        {
            openAppDocDatabase();
            SqlCeCommand cmd = TecanAppDocDatabase.CreateCommand();
            // Update current document... Save Changes Button

            if (AppDocEditPanelHeader.Text == "Edit Header Application Document")
            {
                cmd.CommandText = "UPDATE Documents SET [FileName] = @FileName, [DocumentDescription] = @Description, [SmartStartTitle] = @SmartStartTitle" +
                    " WHERE DocID = " + Convert.ToInt32(AppDocIDTextBox.Text);

                cmd.Parameters.AddWithValue("@FileName", AppDocFilenameTextBox.Text);
                cmd.Parameters.AddWithValue("@Description", AppDocDescriptionTextBox.Text);
                cmd.Parameters.AddWithValue("@SmartStartTitle", AppDocSmartStartTitleTextBox.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                cmd.CommandText = "UPDATE Documents SET [FileName] = @FileName, [DocumentDescription] = @Description, [ApplicationCategory] = @ApplicationCategory" +
                    " WHERE DocID = " + Convert.ToInt32(AppDocIDTextBox.Text);

                cmd.Parameters.AddWithValue("@FileName", AppDocFilenameTextBox.Text);
                cmd.Parameters.AddWithValue("@Description", AppDocDescriptionTextBox.Text);
                cmd.Parameters.AddWithValue("@ApplicationCategory", AppDocAppCatTextBox.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            cmd.Parameters.Clear();
            TecanAppDocDatabase.Close();
            AppDocEditPanel.Visible = false;
            loadAppDocs();
        }

        private void AddHeaderDocButton_Click(object sender, EventArgs e)
        {
            if(AppDocEditPanel.Visible == true) AppDocEditPanel.Visible = false;
            AddSingleDoc("Header");
        }

        private void AddBodyDocumentButton_Click(object sender, EventArgs e)
        {
            if (AppDocEditPanel.Visible == true) AppDocEditPanel.Visible = false;
            AddSingleDoc("Body");
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
                    cmd.CommandText = "DELETE FROM Documents WHERE DocumentPosition = 'Footer'";
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to Delete");
                    }
                    TecanAppDocDatabase.Close();
                    AddSingleDoc("Footer");
                }
            }
        }

        private void AppDocReplaceFileButton_Click(object sender, EventArgs e)
        {
            if (AppDocEditPanelHeader.Text == "Edit Header Application Document")
            {
                AddSingleDoc("Header");
            }
            else
            {
                AddSingleDoc("Body");
            }

        }

        private void AddSingleDoc(string DocumenrtPosition)
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
                        " [SmartStartTitle] = @SmartStartTitle WHERE DocID = " + docID;

                    cmd.Parameters.AddWithValue("@DocExtension", appDocExt);
                    cmd.Parameters.AddWithValue("@Document", appDocData);
                    cmd.Parameters.AddWithValue("@FileName", appDocFileName);
                    cmd.Parameters.AddWithValue("@DocumentDescription", AppDocDescriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("@DocumentPosition", DocumenrtPosition);
                    cmd.Parameters.AddWithValue("@ApplicationCategory", AppDocAppCatTextBox.Text);
                    cmd.Parameters.AddWithValue("@SmartStartTitle", AppDocSmartStartTitleTextBox.Text);
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
                loadAppDocs();

                if (DocumenrtPosition == "Header")
                {
                    AppDocEditPanelHeader.Text = "Edit Header Application Document";
                    SmartStartLabel.Visible = true;
                    AppDocSmartStartTitleTextBox.Visible = true;
                    AppCatLabel.Visible = false;
                    AppDocAppCatTextBox.Visible = false;
                    AppDocEditPanel.Visible = true;
                    LoadAppDocEditPanel(docID, "Header");
                }
                else
                {
                    AppDocEditPanelHeader.Text = "Edit Body Application Document";
                    SmartStartLabel.Visible = false;
                    AppDocSmartStartTitleTextBox.Visible = false;
                    AppCatLabel.Visible = true;
                    AppDocAppCatTextBox.Visible = true;
                    AppDocEditPanel.Visible = true;
                    LoadAppDocEditPanel(docID, "Body");
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

    }
}
