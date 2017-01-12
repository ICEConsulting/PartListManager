using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace TecanPartListManager
{
    // Imports reports from SAP or Excel or others and lists results
    public partial class ImportExternalData : Form
    {
        String whichReport;
        SqlCeConnection TecanMasterDatabase = null;
        SqlCeCommand cmdMaster;
        SqlCeDataReader reader;

        Int16 DBBothValue;
        Int16 DBC2Value;
        Int16 DBPLValue;
        
        Decimal CHFFactor = 0;
        Decimal EURFactor = 0;
        Boolean partFound;

        PartsListDetailDisplay DetailsForm = null;
        MainPartsListDisplay mainForm;

        public void SetMainFormInstance(MainPartsListDisplay inst)
        {
            mainForm = inst;
        }

        public ImportExternalData()
        {
            InitializeComponent();
        }

        public void LoadExternalData(String SAPReport)
        {
            whichReport = SAPReport;
        }

        // Populate table with excel data
        private void ImportExternalData_Shown(Object sender, EventArgs e)
        {
            
            if (whichReport == "MM60" && CHFFactor == 0)
            {
                CurrencyExchangePanel.Visible = true;
                return;
            }

            this.Text = "Loading Report ...";
            ReportStatusLabel.Text = "Loading Report ...";
            ReportStatusLabel.Update();

            DataSet ds = new DataSet();
            ds = ReadExcelFile();
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            switch (whichReport)
            {
                // ZILR Report - Discontinued Parts 
                case "ZILR Discontinued":
                    this.Text = "ZILR Report, Discontined Parts";

                    // Check for discontinued parts
                    ReportStatusLabel.Text = "Looking for Discontinued Parts";
                    ReportStatusLabel.Update();
                    setListColumnHeaders();
                    getDBMembership();
                    openMasterDB();
                    cmdMaster = TecanMasterDatabase.CreateCommand();

                    importExternalProgressBar.Value = 0;
                    importExternalProgressBar.Maximum = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        partFound = false;
                        DataRow drow = dt.Rows[i];
                        cmdMaster.CommandText = "SELECT SAPId FROM PartsList WHERE (SAPId = '" + drow["Material"].ToString() + "') AND (DBMembership = " + DBBothValue + " OR DBMembership = " + DBC2Value + " OR DBMembership = " + DBPLValue + ")";
                        reader = cmdMaster.ExecuteReader();
                        while (reader.Read())
                        {
                            partFound = true;
                        }
                        reader.Dispose();

                        if (partFound && drow["X-distr#chain status"].ToString() == "24")
                        {
                            ListViewItem lvi = new ListViewItem(drow["Material"].ToString());
                            lvi.SubItems.Add(drow["X-distr#chain status"].ToString());

                            // Add the list items to the ListView
                            ReportListView.Items.Add(lvi);
                        }
                        importExternalProgressBar.Value = importExternalProgressBar.Value + 1;
                    }
                    MessageBox.Show("# of discontinued parts = " + ReportListView.Items.Count.ToString());
                    break;

                // ZILR Report - ILP Price Changes 
                case "ZILR Price":
                    this.Text = "ZILR Report, ILP Price Changes";

                    // Check for price changes
                    // Open partslist database
                    ReportStatusLabel.Text = "Comparing Prices";
                    ReportStatusLabel.Update();
                    getDBMembership();
                    openMasterDB();
                    cmdMaster = TecanMasterDatabase.CreateCommand();

                    String StandarPrice = "";
                    String ILP = "";

                    setListColumnHeaders();
                    importExternalProgressBar.Value = 0;
                    importExternalProgressBar.Maximum = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        StandarPrice = "";
                        ILP = "";
                        partFound = false;

                        DataRow drow = dt.Rows[i];
                        cmdMaster.CommandText = "SELECT ILP, StandarPrice FROM PartsList WHERE (SAPId = '" + drow["Material"].ToString() + "') AND (DBMembership = " + DBBothValue + " OR DBMembership = " + DBC2Value + " OR DBMembership = " + DBPLValue + ")";
                        reader = cmdMaster.ExecuteReader();
                        while (reader.Read())
                        {
                            partFound = true;
                            ILP = reader[0].ToString();
                            StandarPrice = reader[1].ToString();
                        }
                        reader.Dispose();

                        if (partFound && (ILP != drow["Value of ZILP Condition"].ToString() || StandarPrice != drow["Sales Price to Customer"].ToString()))
                        {
                            ListViewItem lvi = new ListViewItem(drow["Material"].ToString());
                            lvi.SubItems.Add(ILP);
                            lvi.SubItems.Add(drow["Value of ZILP Condition"].ToString());
                            lvi.SubItems.Add(StandarPrice);
                            lvi.SubItems.Add(drow["Sales Price to Customer"].ToString());

                            // Add the list items to the ListView
                            ReportListView.Items.Add(lvi);
                        }
                        importExternalProgressBar.Value = importExternalProgressBar.Value + 1;
                    }
                    MessageBox.Show("# of price changes = " + ReportListView.Items.Count.ToString());
                    break;
                
                // ASP Report (Once Yearly) Average Selling Price Changes
                case "ASP":
                    this.Text = "ASP Report, Average Selling Price";
                    importExternalProgressBar.Value = 0;
                    importExternalProgressBar.Maximum = dt.Rows.Count;
                    ReportStatusLabel.Text = "Reading Excel File";

                    // Check for price changes
                    // Open partslist database
                    ReportStatusLabel.Text = "Comparing Prices";
                    ReportStatusLabel.Update();
                    getDBMembership();
                    openMasterDB();
                    cmdMaster = TecanMasterDatabase.CreateCommand();

                    String PartAverageSellingPrice = "";

                    setListColumnHeaders();
                    importExternalProgressBar.Value = 0;
                    importExternalProgressBar.Maximum = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PartAverageSellingPrice = "";
                        partFound = false;

                        DataRow drow = dt.Rows[i];
                        cmdMaster.CommandText = "SELECT ASP FROM PartsList WHERE (SAPId = '" + drow["Material"].ToString() + "') AND (DBMembership = " + DBBothValue + " OR DBMembership = " + DBC2Value + " OR DBMembership = " + DBPLValue + ")";
                        reader = cmdMaster.ExecuteReader();
                        while (reader.Read())
                        {
                            partFound = true;
                            PartAverageSellingPrice = reader[0].ToString();
                        }
                        reader.Dispose();

                        if (partFound && getDecimalValue(PartAverageSellingPrice) != getDecimalValue(drow["ASP"].ToString()))
                        {
                            ListViewItem lvi = new ListViewItem(drow["Material"].ToString());
                            lvi.SubItems.Add(PartAverageSellingPrice);
                            lvi.SubItems.Add(drow["ASP"].ToString());

                            // Add the list items to the ListView
                            ReportListView.Items.Add(lvi);
                        }
                        importExternalProgressBar.Value = importExternalProgressBar.Value + 1;
                    }
                    MessageBox.Show("# of price changes = " + ReportListView.Items.Count.ToString());
                    break;

                // Materials Report - Compare SAP Description to C2 Description
                case "SalesText":
                    this.Text = "Sales Text Report, SAP to C2 Descriptions";

                    importExternalProgressBar.Value = 0;
                    importExternalProgressBar.Maximum = dt.Rows.Count;
                    ReportStatusLabel.Text = "Reading Excel File";

                    // Check for price changes
                    // Open partslist database
                    ReportStatusLabel.Text = "Comparing Descriptions";
                    ReportStatusLabel.Update();
                    getDBMembership();
                    openMasterDB();
                    cmdMaster = TecanMasterDatabase.CreateCommand();

                    String Description = "";

                    setListColumnHeaders();
                    importExternalProgressBar.Value = 0;
                    importExternalProgressBar.Maximum = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Description = "";
                        partFound = false;

                        DataRow drow = dt.Rows[i];
                        cmdMaster.CommandText = "SELECT Description FROM PartsList WHERE (SAPId = '" + drow["Matnr"].ToString() + "') AND (DBMembership = " + DBBothValue + " OR DBMembership = " + DBC2Value + " OR DBMembership = " + DBPLValue + ")";
                        reader = cmdMaster.ExecuteReader();
                        while (reader.Read())
                        {
                            partFound = true;
                            Description = reader[0].ToString();
                        }
                        reader.Dispose();

                        if (partFound && Description != drow["Text"].ToString())
                        {
                            ListViewItem lvi = new ListViewItem(drow["Matnr"].ToString());
                            lvi.SubItems.Add(Description);
                            lvi.SubItems.Add(drow["Text"].ToString());

                            // Add the list items to the ListView
                            ReportListView.Items.Add(lvi);
                        }
                        importExternalProgressBar.Value = importExternalProgressBar.Value + 1;
                    }
                    MessageBox.Show("# of description differences = " + ReportListView.Items.Count.ToString());
                    break;

                // MM60 Report - Compare/Update Manufacturing Cost
                case "MM60":
                    this.Text = "MM60 Report, Update Manufacturing Cost";

                    importExternalProgressBar.Value = 0;
                    importExternalProgressBar.Maximum = dt.Rows.Count;

                    // Change all Currency to USD
                    Decimal CurrentValue = 0;
                    ReportStatusLabel.Text = "Changing all costs to USD";
                    ReportStatusLabel.Update();

                    importExternalProgressBar.Value = 0;
                    importExternalProgressBar.Maximum = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CurrentValue = 0;
                        DataRow drow = dt.Rows[i];

                        if (drow["Currency"].ToString() == "CHF")
                        {
                            CurrentValue = Convert.ToDecimal(drow["Price"].ToString());
                            CurrentValue = CurrentValue * CHFFactor;
                            drow["Price"] = CurrentValue;
                        }

                        if (drow["Currency"].ToString() == "EUR")
                        {
                            CurrentValue = Convert.ToDecimal(drow["Price"].ToString());
                            CurrentValue = CurrentValue * EURFactor;
                            drow["Price"] = CurrentValue;
                        }
                        importExternalProgressBar.Value = importExternalProgressBar.Value + 1;
                    }

                    // Check for cost changes
                    // Open partslist database
                    ReportStatusLabel.Text = "Comparing Manufacturing Costs";
                    ReportStatusLabel.Update();

                    getDBMembership();
                    openMasterDB();
                    cmdMaster = TecanMasterDatabase.CreateCommand();

                    String ManufacturingCost = "";

                    setListColumnHeaders();
                    importExternalProgressBar.Value = 0;
                    importExternalProgressBar.Maximum = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ManufacturingCost = "";
                        partFound = false;

                        DataRow drow = dt.Rows[i];
                        cmdMaster.CommandText = "SELECT ManufacturingCost FROM PartsList WHERE (SAPId = '" + drow["Material"].ToString() + "') AND (DBMembership = " + DBBothValue + " OR DBMembership = " + DBC2Value + " OR DBMembership = " + DBPLValue + ")";
                        reader = cmdMaster.ExecuteReader();
                        while (reader.Read())
                        {
                            partFound = true;
                            ManufacturingCost = reader[0].ToString();
                        }
                        reader.Dispose();

                        if (partFound && getDecimalValue(ManufacturingCost) != getDecimalValue(drow["Price"].ToString()))
                        {
                            ListViewItem lvi = new ListViewItem(drow["Material"].ToString());
                            lvi.SubItems.Add(ManufacturingCost);
                            lvi.SubItems.Add(drow["Price"].ToString());

                            // Add the list items to the ListView
                            ReportListView.Items.Add(lvi);
                        }
                        importExternalProgressBar.Value = importExternalProgressBar.Value + 1;
                    }
                    MessageBox.Show("# of cost changes = " + ReportListView.Items.Count.ToString());
                    break;

            }
            

        }

        private string getFilePath(String whichSAPReport)
        {
            String filePath;

            // Get Database Filename and Path
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Please select your latest " + whichSAPReport;
            openFileDialog1.InitialDirectory = "c:\\";
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

        private string GetConnectionString()
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            // XLSX - Excel 2007, 2010, 2012, 2013
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
            props["Extended Properties"] = "Excel 12.0 XML";
            props["Data Source"] = getFilePath(whichReport);;

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

        private DataSet ReadExcelFile()
        {
            DataSet ds = new DataSet();

            string connectionString = GetConnectionString();

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

        private void setListColumnHeaders()
        {
            System.Drawing.Rectangle workingRectangle;
            if (ReportListView.Columns.Count > 0)
            {
                ReportListView.Items.Clear();
                while(ReportListView.Columns.Count > 0)
                {
                    ReportListView.Columns.RemoveAt(0);
                }
            }

            switch (whichReport)
            {
                case "ZILR Discontinued":
                    this.Width = 325;
                    ReportListView.Width = 230;
                    importExternalProgressBar.Width = 230;
                    workingRectangle = Screen.PrimaryScreen.WorkingArea;
                    this.Left = (workingRectangle.Width / 2) - 165;
                    ReportListView.Columns.Add("SAP ID", 75, HorizontalAlignment.Left);
                    ReportListView.Columns.Add("ZILR X-distr.chain status", 150, HorizontalAlignment.Center);
                    break;

                case "ZILR Price":
                    this.Width = 750;
                    ReportListView.Width = 650;
                    importExternalProgressBar.Width = 650;
                    workingRectangle = Screen.PrimaryScreen.WorkingArea;
                    this.Left = (workingRectangle.Width / 2) - 375;
                    ReportListView.Columns.Add("SAP ID", 75, HorizontalAlignment.Left);
                    ReportListView.Columns.Add("Parts ILP", 100, HorizontalAlignment.Right);
                    ReportListView.Columns.Add("ZILR Value of ZILP Condition", 175, HorizontalAlignment.Right);
                    ReportListView.Columns.Add("Parts Standard Price", 125, HorizontalAlignment.Right);
                    ReportListView.Columns.Add("ZILR Sales Price to Customer", 175, HorizontalAlignment.Right);
                    break;

                case "ASP":
                    this.Width = 375;
                    ReportListView.Width = 280;
                    importExternalProgressBar.Width = 280;
                    workingRectangle = Screen.PrimaryScreen.WorkingArea;
                    this.Left = (workingRectangle.Width / 2) - 188;
                    ReportListView.Columns.Add("SAP ID", 75, HorizontalAlignment.Left);
                    ReportListView.Columns.Add("Parts ASP", 100, HorizontalAlignment.Right);
                    ReportListView.Columns.Add("ASP Report ASP", 100, HorizontalAlignment.Right);
                    break;

                case "SalesText":
                    this.Width = 1100;
                    ReportListView.Width = 1000;
                    importExternalProgressBar.Width = 1000;
                    workingRectangle = Screen.PrimaryScreen.WorkingArea;
                    this.Left = (workingRectangle.Width / 2) - 550;
                    ReportListView.Columns.Add("SAP ID", 75, HorizontalAlignment.Left);
                    ReportListView.Columns.Add("Parts Description", 450, HorizontalAlignment.Left);
                    ReportListView.Columns.Add("Sales Text Report Description", 450, HorizontalAlignment.Left);
                    break;

                case "MM60":
                    this.Width = 480;
                    ReportListView.Width = 380;
                    importExternalProgressBar.Width = 380;
                    workingRectangle = Screen.PrimaryScreen.WorkingArea;
                    this.Left = (workingRectangle.Width / 2) - 240;
                    ReportListView.Columns.Add("SAP ID", 75, HorizontalAlignment.Left);
                    ReportListView.Columns.Add("Parts Manufacturing Cost", 150, HorizontalAlignment.Right);
                    ReportListView.Columns.Add("MM60 Report Cost", 130, HorizontalAlignment.Right);
                    break;

            }

        }

        private void openMasterDB()
        {
            TecanMasterDatabase = new SqlCeConnection();
            if (mainForm.whichDb.Contains("TecanPartsList"))
            {
                TecanMasterDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            }
            else
            {
                TecanMasterDatabase.ConnectionString = "Data Source=|DataDirectory|\\TecanSmartStartPartsList.sdf;Max Database Size=4000;Max Buffer Size=1024;Persist Security Info=False";
            }
            TecanMasterDatabase.Open();
        }

        private void getDBMembership()
        {
            openMasterDB();
            cmdMaster = TecanMasterDatabase.CreateCommand();

            // Get DBMembership Values for records that need to be added to Quote Database
            cmdMaster.CommandText = "SELECT [DBID] FROM DBMembership WHERE [DBName] = 'Both'";
            DBBothValue = Convert.ToInt16(cmdMaster.ExecuteScalar());

            cmdMaster.CommandText = "SELECT [DBID] FROM DBMembership WHERE [DBName] = 'C2'";
            DBC2Value = Convert.ToInt16(cmdMaster.ExecuteScalar());

            cmdMaster.CommandText = "SELECT [DBID] FROM DBMembership WHERE [DBName] = 'PL'";
            DBPLValue = Convert.ToInt16(cmdMaster.ExecuteScalar());
            TecanMasterDatabase.Close();
        }

        private void ReportListView_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = ReportListView.Items[ReportListView.SelectedIndices[0]];
            
            if (DetailsForm == null || DetailsForm.IsDisposed)
            {
                DetailsForm = new PartsListDetailDisplay();
            }
            try
            {
                DetailsForm.LoadParts(selectedItem.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DetailsForm.SetForm1Instance(mainForm);
            DetailsForm.TopMost = true;
            DetailsForm.Show();
        }

        private decimal getDecimalValue(String value)
        {
            Decimal strValue = 0;
            strValue = decimal.Parse(value, NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
            strValue = Math.Round(strValue, 2, MidpointRounding.AwayFromZero);
            return strValue;
        }

        private void ExchangePanelOKButton_Click(object sender, EventArgs e)
        {
            CHFFactor = Convert.ToDecimal(CHFTextBox.Text);
            EURFactor = Convert.ToDecimal(EURTextBox.Text);
            CurrencyExchangePanel.Visible = false;
            ImportExternalData_Shown(sender, e);
        }

        private void ExchangePanelCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
