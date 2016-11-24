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
    public partial class AddSAPIDForm : Form
    {

        MainPartsListDisplay mainForm;

        public void SetForm1Instance(MainPartsListDisplay inst)
        {
            mainForm = inst;
        }

        public AddSAPIDForm()
        {
            InitializeComponent();
        }

        private void AddSAPIDButton_Click(object sender, EventArgs e)
        {
            if (NewSAPIDTextBox.Text != "")
            {
                String SAPId = NewSAPIDTextBox.Text;
                short Instrument = 0;
                short SalesType = 1;
                short Category = 0;
                short SubCategory = 0;
                short SSPCategory = 1;
                byte DBMembership = 0;

                System.Data.DataRowView SelectedRowView;
                TecanPartsListDataSet.PartsListRow SelectedRow;

                SelectedRowView = (System.Data.DataRowView)mainForm.partsListBindingSource.Current;
                SelectedRow = (TecanPartsListDataSet.PartsListRow)SelectedRowView.Row;
                SelectedRow.SAPId = SAPId;
                SelectedRow.Instrument = Instrument;
                SelectedRow.SalesType = SalesType;
                SelectedRow.Category = Category;
                SelectedRow.SubCategory = SubCategory;
                SelectedRow.SSPCategory = SSPCategory;
                SelectedRow.DBMembership = DBMembership;
                mainForm.partsListBindingNavigatorSaveItem_Click(sender, e);
                mainForm.newSAPIDReturn(SAPId);
                this.Close();
            }
        }

    }
}
