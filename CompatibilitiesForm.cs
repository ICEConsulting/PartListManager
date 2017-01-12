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
    public partial class CompatibilitiesForm : Form
    {
        PartsListDetailDisplay detailForm;
        String SAPID;
        SqlCeConnection TecanDatabase = null;

        public void SetForm1Instance(PartsListDetailDisplay inst)
        {
            detailForm = inst;
        }

        public CompatibilitiesForm()
        {
            InitializeComponent();
        }

        public void Compatibilities_Load(String mySAPId)
        {
            SAPID = mySAPId;
            SAPIDLabel.Text = SAPID;
            loadCompatibilities();
        }

        public void loadCompatibilities()
        {
            // Add Compatibilities to List
            ArrayList theCompatibilities = new ArrayList();

            openDB();
            SqlCeCommand cmd = TecanDatabase.CreateCommand();
            cmd.CommandText = "SELECT CompatibilityName, CompatibilityID FROM Compatibility ORDER BY CompatibilityName";
            SqlCeDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                theCompatibilities.Add(new Compatibilities(reader[0].ToString(), reader[1].ToString()));
            }
            reader.Dispose();
            TecanDatabase.Close();

            compatibilitiesListBox.DataSource = theCompatibilities;
            compatibilitiesListBox.DisplayMember = "Name";
            compatibilitiesListBox.ValueMember = "ID";
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

        private void SetCompatibilitiesButton_Click(object sender, EventArgs e)
        {
            String selectedCompatibilities = "";

            foreach (Compatibilities compatibility in compatibilitiesListBox.SelectedItems)
            {
                if (selectedCompatibilities == "")
                {
                    selectedCompatibilities = compatibility.ID;
                }
                else
                {
                    selectedCompatibilities = selectedCompatibilities + "," + compatibility.ID;
                }
            }
            openDB();
            SqlCeCommand cmd = TecanDatabase.CreateCommand();
            cmd.CommandText = "UPDATE PartsList SET [Compatibility] = @selectedCompatibilities WHERE [SAPId] = '" + SAPID + "'";
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
            detailForm.CompatibilityReturn(SAPID);
            this.Close();
        }

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

    }
}
