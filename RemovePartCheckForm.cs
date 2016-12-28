using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TecanPartListManager
{
    public partial class RemovePartCheckForm : Form
    {
        MainPartsListDisplay mainForm;
        PartsListDetailDisplay DetailsForm = null;

        public void SetForm1Instance(MainPartsListDisplay inst)
        {
            mainForm = inst;
        }

        public RemovePartCheckForm()
        {
            InitializeComponent();
        }

        internal void ShowRemoved(DataTable dt)
        {
            RequiredDataGridView.DataSource = dt;
            RequiredDataGridView.Columns[1].Width = 465;
            // RequiredDataGridView.Height = 575;
        }

        private void RequiredDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = RequiredDataGridView.CurrentCell.RowIndex;
            // int columnindex = FindDataGridView.CurrentCell.ColumnIndex; 

            String mySAPID = RequiredDataGridView.Rows[rowindex].Cells[0].Value.ToString();

            if (DetailsForm == null || DetailsForm.IsDisposed)
            {
                DetailsForm = new PartsListDetailDisplay();
            }
            try
            {
                DetailsForm.SetForm1Instance(mainForm);
                DetailsForm.LoadParts(mySAPID);
                DetailsForm.TopMost = true;
                DetailsForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading Deatils Form " + ex.Message);
            }
        }
    }
}
