using System;
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
    public partial class RequirePartForm : Form
    {
        PartsListDetailDisplay detailForm;
        String SAPID;

        SqlCeConnection TecanDatabase = null;

        public void SetForm1Instance(PartsListDetailDisplay inst)
        {
            detailForm = inst;
        }

        public RequirePartForm()
        {
            InitializeComponent();
        }

        private void partsListBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.partsListBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tecanPartsListDataSet);
        }

        private void RequirePartForm_Load(object sender, EventArgs e)
        {
            partsListTableAdapter.Connection.ConnectionString = detailForm.whichDb;
            this.partsListTableAdapter.Fill(this.tecanPartsListDataSet.PartsList);
        }

        private void RequirePartForm_Close(object sender, EventArgs e)
        {
            detailForm.RequiredPartsReturn(SAPID);       
        }

        public void RequirePart_Load(String mySAPId)
        {

            SAPID = mySAPId;
            SAPIDLabel.Text = SAPID;
            // SAPIDLabel2.Text = SAPID;
            LoadRequiredPartListView();
            // LoadOptionalPartListView();

            //openDB();
            //SqlCeCommand cmd = TecanDatabase.CreateCommand();
            
            //cmd.CommandText = "SELECT R.RequiredSAPId, P.Description FROM RequiredParts R" +
            //" INNER JOIN PartsList P " +
            //" ON R.RequiredSAPId = P.SAPId" +
            //" WHERE R.SAPId = '" + SAPID + "'" +
            //" ORDER BY RequiredSAPId";
            //try
            //{
            //    SqlCeDataReader reader = cmd.ExecuteReader();

            //    int partCount = 0;
            //    while (reader.Read())
            //    {
            //        RequiredListView.Items.Add(reader[0].ToString());
            //        RequiredListView.Items[partCount].SubItems.Add(reader[1].ToString());
            //        partCount++;
            //    }
            //    reader.Dispose();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //TecanDatabase.Close();

            partsListDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            partsListDataGridView.Columns["DescriptiondataGridViewTextBoxColumn"].SortMode = DataGridViewColumnSortMode.Automatic;
            RequiredListView.AllowDrop = true;
            // OptionalListView.AllowDrop = true;
        }

        private void LoadRequiredPartListView()
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

        //private void LoadOptionalPartListView()
        //{
        //    OptionalListView.Items.Clear();

        //    openDB();
        //    SqlCeCommand cmd = TecanDatabase.CreateCommand();

        //    cmd.CommandText = "SELECT O.OptionalSAPId, P.Description FROM OptionalParts O" +
        //    " INNER JOIN PartsList P " +
        //    " ON O.OptionalSAPId = P.SAPId" +
        //    " WHERE O.SAPId = '" + SAPID + "'" +
        //    " ORDER BY OptionalSAPId";
        //    try
        //    {
        //        SqlCeDataReader reader = cmd.ExecuteReader();

        //        int partCount = 0;
        //        while (reader.Read())
        //        {
        //            OptionalListView.Items.Add(reader[0].ToString());
        //            OptionalListView.Items[partCount].SubItems.Add(reader[1].ToString());
        //            partCount++;
        //        }
        //        reader.Dispose();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    TecanDatabase.Close();

        //}

        private void openDB()
        {
            TecanDatabase = new SqlCeConnection();
            String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (detailForm.whichDb.Contains("TecanPartsList"))
            {
                TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            }
            else
            {
                TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanSmartStartPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            }
            TecanDatabase.Open();
        }

        // Event Trigers Drag Drop (originator)
        private void partsListDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            partsListDataGridView.DoDragDrop(partsListDataGridView.SelectedRows, DragDropEffects.Move);
        }

        private void partsListDataGridView_HeaderDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("here");
        }
         
        // Object that a drag into is desired
        private void RequiredListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataGridViewSelectedRowCollection)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        // The drop into the desired object
        private void RequiredListView_DragDrop(object sender, DragEventArgs e)
        {
            int partCount;
            partCount = RequiredListView.Items.Count;
            String requiredSAPID;
            String requiredDescription;
            
            DataGridViewSelectedRowCollection rows = (DataGridViewSelectedRowCollection)e.Data.GetData(typeof(DataGridViewSelectedRowCollection));

            openDB();
            SqlCeCommand cmd = TecanDatabase.CreateCommand();

            foreach (DataGridViewRow row in rows)
            {
                requiredSAPID = row.Cells[0].Value.ToString();
                requiredDescription = row.Cells[1].Value.ToString();

                RequiredListView.Items.Add(requiredSAPID);
                RequiredListView.Items[partCount].SubItems.Add(requiredDescription);
                partCount++;

                cmd.CommandText = "INSERT INTO RequiredParts (SAPId, RequiredSAPId)" +
                    " Values " +
                    "(@SAPId, @RequiredSAPId)";

                cmd.Parameters.AddWithValue("@SAPId", SAPID);
                cmd.Parameters.AddWithValue("@RequiredSAPId", requiredSAPID);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cmd.Parameters.Clear();
            }
            PartNumberSearchTextBox.Focus();
        }

        // Clear Grid Selection
        private void RequiredListView_MouseLeave(object sender, EventArgs e)
        {
            partsListDataGridView.ClearSelection();
            partsListDataGridView.Focus();
        }
        
        // Object that a drag into is desired
        //private void OptionalListView_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(typeof(DataGridViewSelectedRowCollection)))
        //    {
        //        e.Effect = DragDropEffects.Move;
        //    }
        //}

        // The drop into the desired object
        //private void OptionalListView_DragDrop(object sender, DragEventArgs e)
        //{
        //    int partCount;
        //    partCount = OptionalListView.Items.Count;
        //    String OptionalSAPID;
        //    String OptionalDescription;
            
        //    DataGridViewSelectedRowCollection rows = (DataGridViewSelectedRowCollection)e.Data.GetData(typeof(DataGridViewSelectedRowCollection));

        //    openDB();
        //    SqlCeCommand cmd = TecanDatabase.CreateCommand();

        //    foreach (DataGridViewRow row in rows)
        //    {

        //        OptionalSAPID = row.Cells[0].Value.ToString();
        //        OptionalDescription = row.Cells[1].Value.ToString();

        //        OptionalListView.Items.Add(OptionalSAPID);
        //        OptionalListView.Items[partCount].SubItems.Add(OptionalDescription);
        //        partCount++;

        //        cmd.CommandText = "INSERT INTO OptionalParts (SAPId, OptionalSAPId)" +
        //            " Values " +
        //            "(@SAPId, @OptionalSAPId)";

        //        cmd.Parameters.AddWithValue("@SAPId", SAPID);
        //        cmd.Parameters.AddWithValue("@OptionalSAPId", OptionalSAPID);
        //        try
        //        {
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //        cmd.Parameters.Clear();

        //    }
            //int partCount;
            //partCount = OptionalListView.Items.Count;
            //String alternateSAPID;
            //String alternateDescription;
            //int a  = RequiredListView.SelectedItems.Count;
            //String selectedRequiredPart = SAPIDLabel2.Text;
            //String AlternateSAPIdString = "";

            //DataGridViewSelectedRowCollection rows = (DataGridViewSelectedRowCollection)e.Data.GetData(typeof(DataGridViewSelectedRowCollection));

            //openDB();
            //SqlCeDataReader reader;
            //SqlCeCommand cmd = TecanDatabase.CreateCommand();

            //// Read from Required Parts table to see if there are already alternate parts for this required part
            //cmd.CommandText = "SELECT Alternatives FROM RequiredParts WHERE SAPId = '" + SAPID + "' AND RequiredSAPId = '" + selectedRequiredPart + "'";
            //reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    AlternateSAPIdString = reader[0].ToString();
            //}
            //reader.Dispose();

            //foreach (DataGridViewRow row in rows)
            //{

            //    alternateSAPID = row.Cells[0].Value.ToString();
            //    alternateDescription = row.Cells[1].Value.ToString();

            //    OptionalListView.Items.Add(alternateSAPID);
            //    OptionalListView.Items[partCount].SubItems.Add(alternateDescription);
            //    partCount++;

            //    if (AlternateSAPIdString != "")
            //    {
            //        AlternateSAPIdString = AlternateSAPIdString + "," + alternateSAPID;
            //    }
            //    else
            //    {
            //        AlternateSAPIdString = alternateSAPID;
            //    }
            //}      
            //cmd.CommandText = "UPDATE RequiredParts SET [Alternatives] = @AlternateSAPId" +
            //    " WHERE [SAPId] = '" + SAPID + "' AND [RequiredSAPId] = '" + selectedRequiredPart + "'";

            //cmd.Parameters.AddWithValue("@AlternateSAPId", AlternateSAPIdString);
            //try
            //{
            //    cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //cmd.Parameters.Clear();
            //TecanDatabase.Close();
        //}

        //private void RequiredListView_Click(object sender, EventArgs e)
        //{
        //    SAPIDLabel2.Text = RequiredListView.SelectedItems[0].Text;
        //    OptionalListView.Items.Clear();
            
        //    String[] AlternateSAP = new String[10];
        //    String[] AlternateDescription = new String[10];

        //    openDB();
        //    SqlCeCommand cmd = TecanDatabase.CreateCommand();

        //    cmd.CommandText = "SELECT Alternatives FROM RequiredParts WHERE SAPId = '" + SAPID + "' AND RequiredSAPId = '" + SAPIDLabel2.Text + "'";
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
        //        OptionalListView.Items.Add(AlternateSAP[i]);
        //        OptionalListView.Items[i].SubItems.Add(AlternateDescription[i]);
        //    }
        //    OptionalListView.AllowDrop = true;

        //}

        private void RequiredListView_DoubleClick(object sender, EventArgs e)
        {
            String RequiredSAPID = RequiredListView.SelectedItems[0].Text;
            if (MessageBox.Show("Do you want to remove the required part " + RequiredSAPID + " for part " + SAPID + "?", "Remove Required Part", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                openDB();
                SqlCeCommand cmd = TecanDatabase.CreateCommand();

                cmd.CommandText = "DELETE FROM RequiredParts WHERE SAPId = '" + SAPID + "' AND RequiredSAPId = '" + RequiredSAPID + "'";
                cmd.ExecuteNonQuery();
                TecanDatabase.Close();
                LoadRequiredPartListView();
            }
        }

        //private void OptionalListView_DoubleClick(object sender, EventArgs e)
        //{
        //    String OptionalSAPID = OptionalListView.SelectedItems[0].Text;
        //    if (MessageBox.Show("Do you want to remove the optional part " + OptionalSAPID + " for part " + SAPID + "?", "Remove Optional Part", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    {
        //        openDB();
        //        SqlCeCommand cmd = TecanDatabase.CreateCommand();

        //        cmd.CommandText = "DELETE FROM OptionalParts WHERE SAPId = '" + SAPID + "' AND OptionalSAPId = '" + OptionalSAPID + "'";
        //        cmd.ExecuteNonQuery();
        //        TecanDatabase.Close();
        //        LoadOptionalPartListView();
        //    }
        //}

        //private void AlternateListView_DoubleClick(object sender, EventArgs e)
        //{
            
        //    String AlternatePartToRemove = OptionalListView.SelectedItems[0].Text;
        //    if (MessageBox.Show("Do you want to remove the alternate part " + AlternatePartToRemove + " from the required part " + SAPIDLabel2.Text + " for part " + SAPID + "?", "Remove Required Part", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    {
            
        //        String[] AlternateSAP = new String[10];
        //        String AlternateSAPIdString = "";
        //        int removeIndex = 0;
        //        openDB();
        //        SqlCeCommand cmd = TecanDatabase.CreateCommand();

        //        cmd.CommandText = "SELECT Alternatives FROM RequiredParts WHERE SAPId = '" + SAPID + "' AND RequiredSAPId = '" + SAPIDLabel2.Text + "'";
        //        try
        //        {
        //            SqlCeDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                AlternateSAP = reader[0].ToString().Split(',');
        //            }
        //            reader.Dispose();

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }

        //        for (int i = 0; i < AlternateSAP.Length; i++)
        //        {
        //            if (AlternateSAP[i] == AlternatePartToRemove)
        //            {
        //                removeIndex = i;
        //                break;
        //            }
        //        }
        //        AlternateSAP = AlternateSAP.Where((source, index) => index != removeIndex).ToArray();

        //        for (int i = 0; i < AlternateSAP.Length; i++)
        //        {
        //            if (AlternateSAPIdString != "")
        //            {
        //                AlternateSAPIdString = AlternateSAPIdString + "," + AlternateSAP[i];
        //            }
        //            else
        //            {
        //                AlternateSAPIdString = AlternateSAP[i];
        //            }
        //        }

        //        cmd.CommandText = "UPDATE RequiredParts SET [Alternatives] = @AlternateSAPId" +
        //            " WHERE [SAPId] = '" + SAPID + "' AND [RequiredSAPId] = '" + SAPIDLabel2.Text + "'";

        //        cmd.Parameters.AddWithValue("@AlternateSAPId", AlternateSAPIdString);
        //        try
        //        {
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //        cmd.Parameters.Clear();
        //        // RequiredListView_Click(sender, e);
        //    }
            
        //}

        private void PartNumberSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            doSearch();
        }

        private void DescriptionSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            doSearch();
        }

        private void doSearch()
        {
            this.partsListTableAdapter.Fill(this.tecanPartsListDataSet.PartsList);
            String PartSearchValue;
            String DescriptionSearchValue;

            // Set Text Search values
            if (PartNumberSearchTextBox.Text != "")
            {
                PartSearchValue = PartNumberSearchTextBox.Text + "%";
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

            partsListTableAdapter.FillByLIKE(this.tecanPartsListDataSet.PartsList, PartSearchValue, DescriptionSearchValue);
            
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            detailForm.RequiredPartsReturn(SAPID);
            this.Close();
        }

    }
}
