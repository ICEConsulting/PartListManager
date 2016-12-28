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

namespace TecanPartListManager
{
    public partial class MultiLookupDataChangeForm : Form
    {

        MainPartsListDisplay mainForm;
        String currentTable = "";

        SqlCeConnection TecanDatabase = null;

        public void SetFormInstance(MainPartsListDisplay inst)
        {
            mainForm = inst;
        }

        public MultiLookupDataChangeForm()
        {
            InitializeComponent();
        }

        internal void MultiPartDataChangeFormLoad(String Table)
        {

            currentTable = Table;
            currentTableLabel.Text = currentTable;
            currentTableLabel.Left = (this.ClientSize.Width - currentTableLabel.Width) / 2;

            openBD();
            SqlCeCommand cmd = TecanDatabase.CreateCommand();
            SqlCeDataReader reader;

            String lookupID = "";
            String lookupName = "";

            switch (currentTable)
            {
                case "Instrument":
                    lookupID = "InstrumentID";
                    lookupName = "InstrumentName";
                    break;

                case "Category":
                    lookupID = "CategoryID";
                    lookupName = "CategoryName";
                    break;

                case "SubCategory":
                    lookupID = "SubCategoryID";
                    lookupName = "SubCategoryName";
                    break;

                case "SSPCategory":
                    lookupID = "SSPCategoryId";
                    lookupName = "SSPCategoryName";
                    break;

                case "DBMembership":
                    lookupID = "DBID";
                    lookupName = "DBName";
                    break;

                case "SalesType":
                    lookupID = "SalesTypeID";
                    lookupName = "SalesTypeName";
                    break;
            }
            // Add Lookup Items to List
            ArrayList theLookupTableValues = new ArrayList();
            cmd.CommandText = "SELECT " + lookupID + ", " + lookupName + " FROM " + currentTable + " ORDER BY " + lookupName;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                theLookupTableValues.Add(new theLookupTableValues(reader[1].ToString(), reader[0].ToString()));
            }
            reader.Dispose();
            TecanDatabase.Close();

            currentTableListBox.DataSource = theLookupTableValues;
            currentTableListBox.DisplayMember = "Name";
            currentTableListBox.ValueMember = "ID";

            reader.Dispose();
            TecanDatabase.Close();
            SetListBoxSize();
        }

        private void openBD()
        {
            TecanDatabase = new SqlCeConnection();
            String dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            TecanDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            TecanDatabase.Open();
        }

        private void SetListBoxSize()
        {

            int width = 0;
            Graphics g = currentTableListBox.CreateGraphics();
            Font font = currentTableListBox.Font;

            int newWidth = 0;
            foreach (theLookupTableValues s in currentTableListBox.Items)
            {
                newWidth = (int)g.MeasureString(s.Name, font).Width;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            currentTableListBox.Width = width;
            currentTableListBox.Left = (this.ClientSize.Width - currentTableListBox.Width) / 2;

        }

        public class theLookupTableValues
        {
            private String LookupID;
            private String LookupName;

            public theLookupTableValues(string strName, string strID)
            {
                this.LookupID = strID;
                this.LookupName = strName;
            }

            public string ID
            {
                get
                {
                    return LookupID;
                }
            }

            public string Name
            {
                get
                {
                    return LookupName;
                }
            }
        }

        private void SetPartsButton_Click(object sender, EventArgs e)
        {
            Int32 selectedValue = 0;
            selectedValue = Convert.ToInt32(currentTableListBox.SelectedValue);
            mainForm.multiPartChangeFormReturn(currentTable, (int)selectedValue);
            this.Close();

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
