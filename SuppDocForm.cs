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
    public partial class SuppDocForm : Form
    {

        PartsListDetailDisplay detailForm;
        String SAPID;

        public void SetForm1Instance(PartsListDetailDisplay inst)
        {
            detailForm = inst;
        }

        public SuppDocForm()
        {
            InitializeComponent();
        }

        private void SuppDocForm_Load(object sender, EventArgs e)
        {
            SqlCeConnection TecanSuppDocsDatabase = null;

            TecanSuppDocsDatabase = new SqlCeConnection();
            String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            TecanSuppDocsDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanSuppDocs.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanSuppDocsDatabase.Open();
            SqlCeCommand cmd = TecanSuppDocsDatabase.CreateCommand();
            cmd.CommandText = "SELECT DocID, FileName FROM SuppumentalDocs ORDER BY FileName";
            SqlCeDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                allSuppDocsDataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString());
            }
            reader.Dispose();
            TecanSuppDocsDatabase.Close();
            allSuppDocsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void suppForm_Load(String SAPId)
        {
            SAPID = SAPId;
        }

        private void addSuppDocButton_Click(object sender, EventArgs e)
        {

            String newRowCount = "";
            int newRowCountNum = 0;
            String suppumentalPath, suppumentalFileName, suppumentalExt;
            Byte[] suppumentalData;
            long suppumentalNumBytes;

            // Get Suppumental Filename and Path
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            //  openFileDialog1.Filter = "mdb files (*.mdb)|*.mdb|accdb files (*.accdb)|*.accdb";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SqlCeConnection TecanSuppDocsDatabase = null;

                TecanSuppDocsDatabase = new SqlCeConnection();
                String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                TecanSuppDocsDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanSuppDocs.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
                TecanSuppDocsDatabase.Open();
                SqlCeCommand cmd = TecanSuppDocsDatabase.CreateCommand();

                // Get the last DocID and add 1
                cmd.CommandText = "SELECT DocID FROM SuppumentalDocs";
                SqlCeDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    newRowCount = reader[0].ToString();
                }
                reader.Dispose();
                newRowCountNum = Convert.ToInt16(newRowCount);
                newRowCountNum++;

                // OPen File and get all fields required to add to Supp DB
                suppumentalPath = openFileDialog1.FileName;
                FileInfo suppumentalFileInfo = new FileInfo(suppumentalPath);
                suppumentalNumBytes = suppumentalFileInfo.Length;
                FileStream suppumentalContents = new FileStream(suppumentalPath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(suppumentalContents);
                suppumentalData = br.ReadBytes((int)suppumentalNumBytes);
                suppumentalContents.Close();

                suppumentalFileName = suppumentalFileInfo.Name.ToLower();
                suppumentalExt = suppumentalFileInfo.Extension.Replace(".", "").ToLower();

                cmd.CommandText = "INSERT INTO SuppumentalDocs (DocID, DocExtension, Document, FileName)" +
                    " Values " +
                    "(@DocID, @DocExtension, @Document, @FileName)";

                cmd.Parameters.AddWithValue("@DocId", newRowCountNum);
                cmd.Parameters.AddWithValue("@DocExtension", suppumentalExt);
                cmd.Parameters.AddWithValue("@Document", suppumentalData);
                cmd.Parameters.AddWithValue("@FileName", suppumentalFileName);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please correct the Supplemental Filename \n\n " + suppumentalFileName + "\n\n" + ex.Message + "\n\n" + ex.TargetSite);
                }
                cmd.Parameters.Clear();
                suppumentalContents.Dispose();
                // br.Dispose();

                // Clear and rebuild the Supp Filelist Display
                allSuppDocsDataGridView.Rows.Clear();
                cmd.CommandText = "SELECT DocID, FileName FROM SuppumentalDocs ORDER BY FileName";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    allSuppDocsDataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString());
                }
                reader.Dispose();
                TecanSuppDocsDatabase.Close();
            }

        }

        // get supp doc from DB and save to temp folder then display.
        private void viewSuppDocButton_Click(object sender, EventArgs e)
        {
            String selectedDocName;
            int rowIndex = 0;

            // Get the filename
            Int32 selectedRowCount = this.allSuppDocsDataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    rowIndex = allSuppDocsDataGridView.SelectedRows[i].Index;
                }
            }

            DataGridViewRow row = this.allSuppDocsDataGridView.Rows[rowIndex];
            selectedDocName = row.Cells[1].Value.ToString();

            // Get the file contects from the database
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

        private void associateDocButton_Click(object sender, EventArgs e)
        {
            String selectedDocName;
            int suppRowIndex = 0;
            String partNum;

            // Get the filename
            Int32 selectedRowCount = this.allSuppDocsDataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                SqlCeConnection TecanDatabase = null;

                TecanDatabase = new SqlCeConnection();
                String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
                TecanDatabase.Open();

                SqlCeCommand cmd = TecanDatabase.CreateCommand();

                for (int s = 0; s < selectedRowCount; s++)
                {
                    suppRowIndex = allSuppDocsDataGridView.SelectedRows[s].Index;
                    DataGridViewRow srow = this.allSuppDocsDataGridView.Rows[suppRowIndex];
                    selectedDocName = srow.Cells[1].Value.ToString();
                    partNum = SAPID;

                    cmd.CommandText = "INSERT INTO SuppumentalDocs (SAPId, FileName)" +
                        " Values " +
                        "(@SAPId, @FileName)";

                    cmd.Parameters.AddWithValue("@SAPId", partNum);
                    cmd.Parameters.AddWithValue("@FileName", selectedDocName);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                }
                TecanDatabase.Close();
                detailForm.SuppDocReturn(SAPID);
                this.Close();
            }

        }

    }
}
