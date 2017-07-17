using System;
using System.Collections;
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
    public partial class tableMaintnance : Form
    {

        MainPartsListDisplay mainForm;
        String currentTable = "";

        public void SetMainFormInstance(MainPartsListDisplay inst)
        {
            mainForm = inst;
        }

        public tableMaintnance()
        {
            InitializeComponent();
        }

        private void instrumentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.instrumentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tecanPartsListDataSet);
        }

        private void tableMaintnance_Load(object sender, EventArgs e)
        {

            partsListTableAdapter.Connection.ConnectionString = mainForm.whichDb;
            salesTypeTableAdapter.Connection.ConnectionString = mainForm.whichDb;
            dBMembershipTableAdapter.Connection.ConnectionString = mainForm.whichDb;
            sSPCategoryTableAdapter.Connection.ConnectionString = mainForm.whichDb;
            subCategoryTableAdapter.Connection.ConnectionString = mainForm.whichDb;
            categoryTableAdapter.Connection.ConnectionString = mainForm.whichDb;
            instrumentTableAdapter.Connection.ConnectionString = mainForm.whichDb;

            //String str1 = salesTypeTableAdapter.Connection.ConnectionString.ToString();
            //String str2 = dBMembershipTableAdapter.Connection.ConnectionString.ToString();
            //String str3 = sSPCategoryTableAdapter.Connection.ConnectionString.ToString();
            //String str4 = subCategoryTableAdapter.Connection.ConnectionString.ToString();
            //String str5 = categoryTableAdapter.Connection.ConnectionString.ToString();
            //String str6 = instrumentTableAdapter.Connection.ConnectionString.ToString();
            //String str7 = partsListTableAdapter.Connection.ConnectionString.ToString();
            //MessageBox.Show(str1 + "\n" + str2 + "\n" + str3 + "\n" + str4 + "\n" + str5 + "\n" + str6 + "\n" + str7);

            this.partsListTableAdapter.Fill(this.tecanPartsListDataSet.PartsList);
            this.suppumentalDocsTableAdapter.Fill(this.tecanPartsListDataSet.SuppumentalDocs);
            this.salesTypeTableAdapter.Fill(this.tecanPartsListDataSet.SalesType);
            this.dBMembershipTableAdapter.Fill(this.tecanPartsListDataSet.DBMembership);
            this.sSPCategoryTableAdapter.Fill(this.tecanPartsListDataSet.SSPCategory);
            this.subCategoryTableAdapter.Fill(this.tecanPartsListDataSet.SubCategory);
            this.categoryTableAdapter.Fill(this.tecanPartsListDataSet.Category);
            this.instrumentTableAdapter.Fill(this.tecanPartsListDataSet.Instrument);


            // Add All Supplemental Documents to List 
            SqlCeConnection TecanSuppDocsDatabase = null;

            TecanSuppDocsDatabase = new SqlCeConnection();
            // String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
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
            suppumentalDocsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Add Compatibilities to List
            ArrayList theCompatibilities = new ArrayList();

            SqlCeConnection TecanDatabase = null;

            TecanDatabase = new SqlCeConnection();
            // String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanDatabase.Open();
            cmd = TecanDatabase.CreateCommand();
            cmd.CommandText = "SELECT CompatibilityName, CompatibilityID FROM Compatibility ORDER BY CompatibilityName";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                theCompatibilities.Add(new Compatibilities(reader[0].ToString(), reader[1].ToString()));
            }
            reader.Dispose();
            TecanDatabase.Close();

            compatibilityListBox.DataSource = theCompatibilities;
            compatibilityListBox.DisplayMember = "Name";
            compatibilityListBox.ValueMember = "ID";

        }

        //public class Compatibilities
        //{
        //    private String CompatibilityID;
        //    private String CompatibilityName;

        //    public Compatibilities(string strName, string strID)
        //    {
        //        this.CompatibilityID = strID;
        //        this.CompatibilityName = strName;
        //    }

        //    public string ID
        //    {
        //        get
        //        {
        //            return CompatibilityID;
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

        public void clearCurrentTable()
        {
            currentTable = "";
        }

        private void tableMaintnance_Close(object sender, EventArgs e)
        {
            if (currentTable != "")
            {
                mainForm.associatedTableReturn(currentTable);
            }
        }

        private void addInstrumentButton_Click(object sender, EventArgs e)
        {
            currentTable = "Instrument";
            tableMaintenanceEdit EditTableForm = new tableMaintenanceEdit();
            EditTableForm.SetAssociationFormInstance(this);
            EditTableForm.SetMainFormInstance(mainForm);
            EditTableForm.Text = "Add Instrument Item";
            EditTableForm.LoadTableEdit("Instrument", "Add");
            EditTableForm.TopMost = true;
            EditTableForm.Show();
        }

        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            currentTable = "Category";
            tableMaintenanceEdit EditTableForm = new tableMaintenanceEdit();
            EditTableForm.SetAssociationFormInstance(this);
            EditTableForm.SetMainFormInstance(mainForm);
            EditTableForm.Text = "Add Category Item";
            EditTableForm.LoadTableEdit("Category", "Add");
            EditTableForm.TopMost = true;
            EditTableForm.Show();
        }

        private void addSubCategoryButton_Click(object sender, EventArgs e)
        {
            currentTable = "SubCategory";
            tableMaintenanceEdit EditTableForm = new tableMaintenanceEdit();
            EditTableForm.SetAssociationFormInstance(this);
            EditTableForm.SetMainFormInstance(mainForm);
            EditTableForm.Text = "Add Sub-Category Item";
            EditTableForm.LoadTableEdit("SubCategory", "Add");
            EditTableForm.TopMost = true;
            EditTableForm.Show();
        }

        private void addSSPCategoryButton_Click(object sender, EventArgs e)
        {
            currentTable = "SSPCategory";
            tableMaintenanceEdit EditTableForm = new tableMaintenanceEdit();
            EditTableForm.SetAssociationFormInstance(this);
            EditTableForm.SetMainFormInstance(mainForm);
            EditTableForm.Text = "Add SSP-Category Item";
            EditTableForm.LoadTableEdit("SSPCategory", "Add");
            EditTableForm.TopMost = true;
            EditTableForm.Show();
        }

        private void addDBMembershipButton_Click(object sender, EventArgs e)
        {
            currentTable = "DBMembership";
            tableMaintenanceEdit EditTableForm = new tableMaintenanceEdit();
            EditTableForm.SetAssociationFormInstance(this);
            EditTableForm.SetMainFormInstance(mainForm);
            EditTableForm.Text = "Add Database Membership Item";
            EditTableForm.LoadTableEdit("DBMembership", "Add");
            EditTableForm.TopMost = true;
            EditTableForm.Show();
        }

        private void addSalesTypeButton_Click(object sender, EventArgs e)
        {
            currentTable = "SalesType";
            tableMaintenanceEdit EditTableForm = new tableMaintenanceEdit();
            EditTableForm.SetAssociationFormInstance(this);
            EditTableForm.SetMainFormInstance(mainForm);
            EditTableForm.Text = "Add Sales Type Item";
            EditTableForm.LoadTableEdit("SalesType", "Add");
            EditTableForm.TopMost = true;
            EditTableForm.Show();
        }

        private void addCompatibilityButton_Click(object sender, EventArgs e)
        {
            currentTable = "Compatibility";
            tableMaintenanceEdit EditTableForm = new tableMaintenanceEdit();
            EditTableForm.SetAssociationFormInstance(this);
            EditTableForm.SetMainFormInstance(mainForm);
            EditTableForm.Text = "Add Compatibility Item";
            EditTableForm.LoadTableEdit("Compatibility", "Add");
            EditTableForm.TopMost = true;
            EditTableForm.Show();
        }

        private void instrumentListBox_DoubleClick(object sender, EventArgs e)
        {
            currentTable = "Instrument";
            tableMaintenanceEdit EditTableForm = new tableMaintenanceEdit();
            EditTableForm.SetAssociationFormInstance(this);
            EditTableForm.SetMainFormInstance(mainForm);
            EditTableForm.Text = "Edit or Delete Instrument Item";
            EditTableForm.LoadTableEdit("Instrument", "Edit", instrumentListBox.GetItemText(instrumentListBox.SelectedItem));
            EditTableForm.TopMost = true;
            EditTableForm.Show();
        }

        private void categoryListBox_DoubleClick(object sender, EventArgs e)
        {
            currentTable = "Category";
            tableMaintenanceEdit EditTableForm = new tableMaintenanceEdit();
            EditTableForm.SetAssociationFormInstance(this);
            EditTableForm.SetMainFormInstance(mainForm);
            EditTableForm.Text = "Edit or Delete Category Item";
            EditTableForm.LoadTableEdit("Category", "Edit", categoryListBox.GetItemText(categoryListBox.SelectedItem));
            EditTableForm.TopMost = true;
            EditTableForm.Show();
        }

        private void subCategoryListBox_DoubleClick(object sender, EventArgs e)
        {
            currentTable = "SubCategory";
            tableMaintenanceEdit EditTableForm = new tableMaintenanceEdit();
            EditTableForm.SetAssociationFormInstance(this);
            EditTableForm.SetMainFormInstance(mainForm);
            EditTableForm.Text = "Edit or Delete Sub-Category Item";
            EditTableForm.LoadTableEdit("SubCategory", "Edit", subCategoryListBox.GetItemText(subCategoryListBox.SelectedItem));
            EditTableForm.TopMost = true;
            EditTableForm.Show();
        }

        private void sSPCategoryListBox_DoubleClick(object sender, EventArgs e)
        {
            currentTable = "SSPCategory";
            tableMaintenanceEdit EditTableForm = new tableMaintenanceEdit();
            EditTableForm.SetAssociationFormInstance(this);
            EditTableForm.SetMainFormInstance(mainForm);
            EditTableForm.Text = "Edit or Delete SSP Category Item";
            EditTableForm.LoadTableEdit("SSPCategory", "Edit", sSPCategoryListBox.GetItemText(sSPCategoryListBox.SelectedItem));
            EditTableForm.TopMost = true;
            EditTableForm.Show();
        }

        private void dBMembershipListBox_DoubleClick(object sender, EventArgs e)
        {
            currentTable = "DBMembership";
            tableMaintenanceEdit EditTableForm = new tableMaintenanceEdit();
            EditTableForm.SetAssociationFormInstance(this);
            EditTableForm.SetMainFormInstance(mainForm);
            EditTableForm.Text = "Edit or Delete Database Membership Item";
            EditTableForm.LoadTableEdit("DBMembership", "Edit", dBMembershipListBox.GetItemText(dBMembershipListBox.SelectedItem));
            EditTableForm.TopMost = true;
            EditTableForm.Show();
        }

        private void salesTypeListBox_DoubleClick(object sender, EventArgs e)
        {
            currentTable = "SalesType";
            tableMaintenanceEdit EditTableForm = new tableMaintenanceEdit();
            EditTableForm.SetAssociationFormInstance(this);
            EditTableForm.SetMainFormInstance(mainForm);
            EditTableForm.Text = "Edit or Delete Sales Type Item";
            EditTableForm.LoadTableEdit("SalesType", "Edit", salesTypeListBox.GetItemText(salesTypeListBox.SelectedItem));
            EditTableForm.TopMost = true;
            EditTableForm.Show();
        }

        private void compatibilityListBox_DoubleClick(object sender, EventArgs e)
        {
            currentTable = "Compatibility";
            tableMaintenanceEdit EditTableForm = new tableMaintenanceEdit();
            EditTableForm.SetAssociationFormInstance(this);
            EditTableForm.SetMainFormInstance(mainForm);
            EditTableForm.Text = "Edit or Delete Compatibility Item";
            EditTableForm.LoadTableEdit("Compatibility", "Edit", compatibilityListBox.GetItemText(compatibilityListBox.SelectedItem));
            EditTableForm.TopMost = true;
            EditTableForm.Show();
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

        // Rename or Delete supp doc
        private void allSuppDocsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String selectedDocID;
            String selectedDocName;

            DataGridViewRow row = this.allSuppDocsDataGridView.Rows[e.RowIndex];
            selectedDocID = row.Cells[0].Value.ToString();
            selectedDocName = row.Cells[1].Value.ToString();
            currentTable = "SuppumentalDocs";
            tableMaintenanceEdit EditTableForm = new tableMaintenanceEdit();
            EditTableForm.SetAssociationFormInstance(this);
            EditTableForm.SetMainFormInstance(mainForm);
            EditTableForm.Text = "Edit or Delete Supplemental Document";
            EditTableForm.LoadTableEdit("SuppumentalDocs", "Edit", selectedDocName);
            EditTableForm.TopMost = true;
            EditTableForm.Show();

        }

        // redisplay the affected listbox, grid after edit    
        public void returnFromEdit()
        {

            switch (currentTable)
            {
                case "Instrument":
                    this.instrumentTableAdapter.Fill(this.tecanPartsListDataSet.Instrument);
                    break;

                case "Category":
                    this.categoryTableAdapter.Fill(this.tecanPartsListDataSet.Category);
                    break;

                case "SubCategory":
                    this.subCategoryTableAdapter.Fill(this.tecanPartsListDataSet.SubCategory);
                    break;

                case "SSPCategory":
                    this.sSPCategoryTableAdapter.Fill(this.tecanPartsListDataSet.SSPCategory);
                    break;

                case "DBMembership":
                    this.dBMembershipTableAdapter.Fill(this.tecanPartsListDataSet.DBMembership);
                    break;

                case "SalesType":
                    this.salesTypeTableAdapter.Fill(this.tecanPartsListDataSet.SalesType);
                    break;

                case "Compatibility":
                    // Add Compatibilities to List
                    ArrayList theCompatibilities = new ArrayList();

                    SqlCeConnection TecanDatabase = null;

                    TecanDatabase = new SqlCeConnection();
                    // String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                    TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
                    TecanDatabase.Open();
                    SqlCeCommand cmd = TecanDatabase.CreateCommand();
                    cmd.CommandText = "SELECT CompatibilityName, CompatibilityID FROM Compatibility ORDER BY CompatibilityName";
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        theCompatibilities.Add(new Compatibilities(reader[0].ToString(), reader[1].ToString()));
                    }
                    reader.Dispose();
                    TecanDatabase.Close();

                    compatibilityListBox.DataSource = theCompatibilities;
                    compatibilityListBox.DisplayMember = "Name";
                    compatibilityListBox.ValueMember = "ID";
                    break;

                case "SuppumentalDocs":
                    // Clear and rebuild the Supp Filelist Display
                    allSuppDocsDataGridView.Rows.Clear();
                    SqlCeConnection TecanSuppDocsDatabase = null;

                    TecanSuppDocsDatabase = new SqlCeConnection();
                    String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                    TecanSuppDocsDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanSuppDocs.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
                    TecanSuppDocsDatabase.Open();
                    SqlCeCommand cmd2 = TecanSuppDocsDatabase.CreateCommand();

                    cmd2.CommandText = "SELECT DocID, FileName FROM SuppumentalDocs ORDER BY FileName";
                    SqlCeDataReader reader2 = cmd2.ExecuteReader();
                    reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        allSuppDocsDataGridView.Rows.Add(reader2[0].ToString(), reader2[1].ToString());
                    }
                    reader2.Dispose();
                    TecanSuppDocsDatabase.Close();

                    this.suppumentalDocsTableAdapter.Fill(this.tecanPartsListDataSet.SuppumentalDocs);
                    break;

            }

        }

        // get supp doc from DB and save to temp folder then display.
        private void viewSuppDocButton_Click(object sender, EventArgs e)
        {
            // String selectedDocID;
            String selectedDocName;
            int rowIndex = 0;

            // Get the filename and docID
            Int32 selectedRowCount = this.allSuppDocsDataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    rowIndex = allSuppDocsDataGridView.SelectedRows[i].Index;
                }
            }

            DataGridViewRow row = this.allSuppDocsDataGridView.Rows[rowIndex];
            // selectedDocID = row.Cells[0].Value.ToString();
            selectedDocName = row.Cells[1].Value.ToString();

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
                try
                {
                    file.Delete();
                }
                catch { }
            }

            String fullFilePathName = @tempFilePath + "\\" + selectedDocName;
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void assoSuppDocButton_Click(object sender, EventArgs e)
        {
            // String selectedDocID;
            String selectedDocName;
            int suppRowIndex = 0;
            String partNum;

            // Get the filename and docID
            Int32 selectedsRowCount = this.allSuppDocsDataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
            Int32 selectedpItemCount = partsListListBox.SelectedItems.Count;
            if (selectedsRowCount > 0 && selectedpItemCount > 0)
            {
                SqlCeConnection TecanDatabase = null;

                TecanDatabase = new SqlCeConnection();
                String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
                TecanDatabase.Open();

                SqlCeCommand cmd = TecanDatabase.CreateCommand();

                for (int s = 0; s < selectedsRowCount; s++)
                {
                    suppRowIndex = allSuppDocsDataGridView.SelectedRows[s].Index;
                    DataGridViewRow srow = this.allSuppDocsDataGridView.Rows[suppRowIndex];
                    // selectedDocID = srow.Cells[0].Value.ToString();
                    selectedDocName = srow.Cells[1].Value.ToString();

                   

                    foreach(DataRowView selectedpitem in partsListListBox.SelectedItems)
                    {
                        partNum = selectedpitem["SAPId"].ToString();

                        cmd.CommandText = "INSERT INTO SuppumentalDocs (SAPId, FileName) Values (@SAPId, @FileName)";

                        cmd.Parameters.AddWithValue("@SAPId", partNum);
                        cmd.Parameters.AddWithValue("@FileName", selectedDocName);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                    }
                }
                TecanDatabase.Close();
                this.suppumentalDocsTableAdapter.Fill(this.tecanPartsListDataSet.SuppumentalDocs);
            }

        }

        private void suppumentalDocsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String selectedSAPID;
            String selectedDocName;

            DataGridViewRow row = this.suppumentalDocsDataGridView.Rows[e.RowIndex];
            selectedSAPID = row.Cells[0].Value.ToString();
            selectedDocName = row.Cells[1].Value.ToString();

            String msgString = "Are you certain you want to remove the SAPID - Supplemental Document association referenced below?\r\n\r\n" + selectedSAPID + " - " + selectedDocName;
            if (MessageBox.Show(msgString, "Remove Assosciation",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlCeConnection TecanDatabase = null;
                try
                {
                    TecanDatabase = new SqlCeConnection();
                    TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
                    TecanDatabase.Open();

                    SqlCeCommand cmd = TecanDatabase.CreateCommand();
                    cmd.CommandText = "DELETE FROM SuppumentalDocs WHERE SAPId = '" + selectedSAPID + "' AND FileName = '" + selectedDocName + "'";
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    TecanDatabase.Close();
                }
            }

        }

    }
}
