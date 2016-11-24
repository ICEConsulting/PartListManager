using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TecanPartListManager
{
    public partial class tableMaintenanceEdit : Form
    {
        tableMaintnance associationForm;
        MainPartsListDisplay mainForm;
        SqlCeConnection TecanDatabase = null;
        String currentTable;

        public void SetAssociationFormInstance(tableMaintnance inst)
        {
            associationForm = inst;
        }

        public void SetMainFormInstance(MainPartsListDisplay inst)
        {
            mainForm = inst;
        }

        public tableMaintenanceEdit()
        {
            InitializeComponent();
        }

        internal void LoadTableEdit(String Table, String Mode, String editItem = "")
        {
            currentTable = Table;
            if (Mode == "Add")
            {
                addItemPanel.Visible = true;
                addItemPanel.BringToFront();
                editDeletePanel.SendToBack();
                editDeletePanel.Visible = false;
            }
            else
            {
                addItemPanel.Visible = false;
                addItemPanel.SendToBack();
                editDeletePanel.Visible = true;
                editDeletePanel.BringToFront();
                currentItemTextBox.Text = editItem;
            }

        }

        private void tableMaintenanceEdit_Load(object sender, EventArgs e)
        {
            
        }

        private void openDB()
        {

            TecanDatabase = new SqlCeConnection();
            String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanDatabase.Open();

        }

        private void openSuppDB()
        {

            TecanDatabase = new SqlCeConnection();
            String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanSuppDocs.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanDatabase.Open();

        }


        private void addItemButton_Click(object sender, EventArgs e)
        {
            if (addItemTextBox.Text != "")
            {
                String newItem = addItemTextBox.Text;
                String indexFieldName = "";
                String itemFieldName = "";
                short rowCount = 0;
                switch (currentTable)
                {
                    case "Instrument":
                        indexFieldName = "InstrumentID";
                        itemFieldName = "InstrumentName";
                        break;
                        
                    case "Category":
                        indexFieldName = "CategoryID";
                        itemFieldName = "CategoryName";
                        break;
                        
                    case "SubCategory":
                        indexFieldName = "SubCategoryID";
                        itemFieldName = "SubCategoryName";
                        break;
                        
                    case "SSPCategory":
                        indexFieldName = "SSPCategoryId";
                        itemFieldName = "SSPCategoryName";
                        break;
                        
                    case "DBMembership":
                        indexFieldName = "DBID";
                        itemFieldName = "DBName";
                        break;
                        
                    case "SalesType":
                        indexFieldName = "SalesTypeID";
                        itemFieldName = "SalesTypeName";
                        break;

                    case "Compatibility":
                        indexFieldName = "CompatibilityID";
                        itemFieldName = "CompatibilityName";
                        break;
                        
                }
                rowCount = getRowCount(indexFieldName);

                openDB();
                SqlCeCommand cmd = TecanDatabase.CreateCommand();

                cmd.CommandText = "INSERT INTO " + currentTable + " (" + indexFieldName + "," +  itemFieldName + ") Values (" + rowCount + ", '" + newItem + "')";
                cmd.ExecuteNonQuery();
                TecanDatabase.Close();
                associationForm.returnFromEdit();
                this.Close();

            }
            else
            {
                MessageBox.Show("You cannot add a blank item");
            }
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            String renameCurrentItem = currentItemTextBox.Text;
            String renameNewItem = newItemTextBox.Text;
            String itemFieldName = "";
            switch (currentTable)
            {
                case "Instrument":
                    itemFieldName = "InstrumentName";
                    break;

                case "Category":
                    itemFieldName = "CategoryName";
                    break;

                case "SubCategory":
                    itemFieldName = "SubCategoryName";
                    break;

                case "SSPCategory":
                    itemFieldName = "SSPCategoryName";
                    break;

                case "DBMembership":
                    itemFieldName = "DBName";
                    break;

                case "SalesType":
                    itemFieldName = "SalesTypeName";
                    break;

                case "SuppumentalDocs":
                    itemFieldName = "FileName";
                    break;

                case "Compatibility":
                    itemFieldName = "CompatibilityName";
                    break;

            }

            if (currentTable != "SuppumentalDocs")
            {
                openDB();
            }
            else
            {
                openSuppDB();
            }
            SqlCeCommand cmd = TecanDatabase.CreateCommand();

            cmd.CommandText = "UPDATE " + currentTable + " SET " + itemFieldName + " = '" + renameNewItem  +  "' WHERE " + itemFieldName + " = '" + renameCurrentItem + "'";
            cmd.ExecuteNonQuery();
            TecanDatabase.Close();
            if (currentTable == "SuppumentalDocs")
            {
                openDB();
                SqlCeCommand cmd2 = TecanDatabase.CreateCommand();
                cmd2.CommandText = "UPDATE SuppumentalDocs SET " + itemFieldName + " = '" + renameNewItem + "' WHERE " + itemFieldName + " = '" + renameCurrentItem + "'";
                cmd2.ExecuteNonQuery();
                TecanDatabase.Close();

            }
            associationForm.returnFromEdit();
            this.Close();

        }

        private void deleteItemButton_Click(object sender, EventArgs e)
        {

            String deleteItem = currentItemTextBox.Text;
            String itemFieldName = "";
            String indexFieldName = "";
            switch (currentTable)
            {
                case "Instrument":
                    indexFieldName = "InstrumentID";
                    itemFieldName = "InstrumentName";
                    break;

                case "Category":
                    indexFieldName = "CategoryID";
                    itemFieldName = "CategoryName";
                    break;

                case "SubCategory":
                    indexFieldName = "SubCategoryID";
                    itemFieldName = "SubCategoryName";
                    break;

                case "SSPCategory":
                    indexFieldName = "SSPCategoryId";
                    itemFieldName = "SSPCategoryName";
                    break;

                case "DBMembership":
                    indexFieldName = "DBID";
                    itemFieldName = "DBName";
                    break;

                case "SalesType":
                    indexFieldName = "SalesTypeID";
                    itemFieldName = "SalesTypeName";
                    break;

                case "Compatibility":
                    indexFieldName = "CompatibilityID";
                    itemFieldName = "CompatibilityName";
                    break;
                        

            }

            if (currentTable != "SuppumentalDocs")
            {
                openDB();
            }
            else
            {
                openSuppDB();
            }
            SqlCeCommand cmd = TecanDatabase.CreateCommand();

            cmd.CommandText = "DELETE FROM " + currentTable + " WHERE " + itemFieldName + " = '" + deleteItem + "'";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                short indexID;
                String plIndexFieldName;
                if (indexFieldName == "DBID")
                {
                    plIndexFieldName = "DBMembership";
                }
                else
                {
                    plIndexFieldName = indexFieldName.Substring(0, indexFieldName.Length - 2);
                }
                cmd.CommandText = "SELECT " + indexFieldName + " FROM " + currentTable + " WHERE " + itemFieldName + " = '" + deleteItem + "'";
                indexID = (short)(Int32)cmd.ExecuteScalar();
                cmd.CommandText = "SELECT SAPId, Description FROM PartsList WHERE " + plIndexFieldName + " = '" + indexID + "'";
                //SqlCeDataReader reader = cmd.ExecuteReader();
                //int partCount = 0;
                //ExceptionPanel.Visible = true;
                //ExceptionLabel.Text = "The following parts are associated with the " + currentTable + " you are attempting to delete. Please changed these parts association.";
                //while (reader.Read())
                //{
                //    ExceptionListView.Items.Add(reader[0].ToString());
                //    ExceptionListView.Items[partCount].SubItems.Add(reader[1].ToString());
                //    partCount++;
                //}
                //reader.Dispose();
                MessageBox.Show("Unable to delete the selected " + currentTable + " because there are parts associated with " + deleteItem + "\n\nThe main partslist display will list the parts with this association!", "Deletion Error");
                associationForm.Close();
                this.Close();
                mainForm.associationTableError(currentTable, indexID);
            }
            TecanDatabase.Close();
            associationForm.returnFromEdit();
            this.Close();

        }

        private short getRowCount(string indexFieldName)
        {
            String newRowCount = "";
            int newRowCountNum = 0;
            openDB();
            SqlCeCommand cmd = TecanDatabase.CreateCommand();
            cmd.CommandText = "SELECT " + indexFieldName + " FROM " + currentTable + " ORDER BY " + indexFieldName;
            SqlCeDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // newRowCountNum = reader.GetInt16(0);
                newRowCount = reader[0].ToString();
            }
            TecanDatabase.Close();
            newRowCountNum = Convert.ToInt16(newRowCount);
            newRowCountNum++;
            return (short)newRowCountNum;

        }

        private void cancelAddButton_Click(object sender, EventArgs e)
        {
            associationForm.clearCurrentTable();
            this.Close();
        }

        private void cancelEditButton_Click(object sender, EventArgs e)
        {
            associationForm.clearCurrentTable();
            this.Close();
        }

    }
}
