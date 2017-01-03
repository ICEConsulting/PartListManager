namespace TecanPartListManager
{
    partial class RemovePartCheckForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.RequiredDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.RequiredDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(661, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "The following parts have the part you are attempting to remove as a required part" +
    "!";
            // 
            // RequiredDataGridView
            // 
            this.RequiredDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RequiredDataGridView.Location = new System.Drawing.Point(53, 109);
            this.RequiredDataGridView.Name = "RequiredDataGridView";
            this.RequiredDataGridView.RowHeadersVisible = false;
            this.RequiredDataGridView.RowTemplate.Height = 28;
            this.RequiredDataGridView.Size = new System.Drawing.Size(860, 682);
            this.RequiredDataGridView.TabIndex = 1;
            this.RequiredDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RequiredDataGridView_CellContentClick);
            // 
            // RemovePartCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(966, 841);
            this.Controls.Add(this.RequiredDataGridView);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RemovePartCheckForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Removing Part Verification";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RemovePartCheckForm_Close);
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.RequiredDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView RequiredDataGridView;
    }
}