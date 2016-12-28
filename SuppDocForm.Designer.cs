namespace TecanPartListManager
{
    partial class SuppDocForm
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
            this.viewSuppDocButton = new System.Windows.Forms.Button();
            this.addSuppDocButton = new System.Windows.Forms.Button();
            this.allSuppDocsDataGridView = new System.Windows.Forms.DataGridView();
            this.DocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.associateDocButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.allSuppDocsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // viewSuppDocButton
            // 
            this.viewSuppDocButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.viewSuppDocButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewSuppDocButton.Location = new System.Drawing.Point(710, 40);
            this.viewSuppDocButton.Margin = new System.Windows.Forms.Padding(4);
            this.viewSuppDocButton.Name = "viewSuppDocButton";
            this.viewSuppDocButton.Size = new System.Drawing.Size(88, 36);
            this.viewSuppDocButton.TabIndex = 41;
            this.viewSuppDocButton.TabStop = false;
            this.viewSuppDocButton.Text = "View";
            this.viewSuppDocButton.UseVisualStyleBackColor = false;
            this.viewSuppDocButton.Click += new System.EventHandler(this.viewSuppDocButton_Click);
            // 
            // addSuppDocButton
            // 
            this.addSuppDocButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addSuppDocButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSuppDocButton.Location = new System.Drawing.Point(633, 40);
            this.addSuppDocButton.Margin = new System.Windows.Forms.Padding(4);
            this.addSuppDocButton.Name = "addSuppDocButton";
            this.addSuppDocButton.Size = new System.Drawing.Size(68, 36);
            this.addSuppDocButton.TabIndex = 40;
            this.addSuppDocButton.TabStop = false;
            this.addSuppDocButton.Text = "Add";
            this.addSuppDocButton.UseVisualStyleBackColor = false;
            this.addSuppDocButton.Click += new System.EventHandler(this.addSuppDocButton_Click);
            // 
            // allSuppDocsDataGridView
            // 
            this.allSuppDocsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allSuppDocsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocID,
            this.FileName});
            this.allSuppDocsDataGridView.Location = new System.Drawing.Point(56, 80);
            this.allSuppDocsDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.allSuppDocsDataGridView.Name = "allSuppDocsDataGridView";
            this.allSuppDocsDataGridView.Size = new System.Drawing.Size(968, 882);
            this.allSuppDocsDataGridView.TabIndex = 39;
            this.allSuppDocsDataGridView.TabStop = false;
            // 
            // DocID
            // 
            this.DocID.HeaderText = "DocID";
            this.DocID.Name = "DocID";
            // 
            // FileName
            // 
            this.FileName.HeaderText = "Filename";
            this.FileName.Name = "FileName";
            this.FileName.Width = 500;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(270, 49);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(311, 29);
            this.label8.TabIndex = 38;
            this.label8.Text = "Supplemental Documents";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 990);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 29);
            this.label1.TabIndex = 42;
            this.label1.Text = "Add:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(234, 1039);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 29);
            this.label2.TabIndex = 43;
            this.label2.Text = "View:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(172, 1093);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 29);
            this.label3.TabIndex = 44;
            this.label3.Text = "Associate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(321, 994);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(461, 25);
            this.label4.TabIndex = 45;
            this.label4.Text = "Add a new supplemental document to the database.";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(321, 1042);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(615, 56);
            this.label5.TabIndex = 46;
            this.label5.Text = "View the selected document. Only one document may be selected.";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(321, 1096);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(702, 103);
            this.label6.TabIndex = 47;
            this.label6.Text = "Associate the selected document(s).\r\nNote: To delete a supplemental document,  pl" +
    "ease use the Assocation Table menu item on the main parts list display page.";
            // 
            // associateDocButton
            // 
            this.associateDocButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.associateDocButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.associateDocButton.Location = new System.Drawing.Point(807, 40);
            this.associateDocButton.Margin = new System.Windows.Forms.Padding(4);
            this.associateDocButton.Name = "associateDocButton";
            this.associateDocButton.Size = new System.Drawing.Size(146, 36);
            this.associateDocButton.TabIndex = 48;
            this.associateDocButton.TabStop = false;
            this.associateDocButton.Text = "Associate";
            this.associateDocButton.UseVisualStyleBackColor = false;
            this.associateDocButton.Click += new System.EventHandler(this.associateDocButton_Click);
            // 
            // SuppDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(1077, 1195);
            this.Controls.Add(this.associateDocButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewSuppDocButton);
            this.Controls.Add(this.addSuppDocButton);
            this.Controls.Add(this.allSuppDocsDataGridView);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SuppDocForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Associate Supplemental Document";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SuppDocForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.allSuppDocsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button viewSuppDocButton;
        private System.Windows.Forms.Button addSuppDocButton;
        private System.Windows.Forms.DataGridView allSuppDocsDataGridView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button associateDocButton;
    }
}