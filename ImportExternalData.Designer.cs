namespace TecanPartListManager
{
    partial class ImportExternalData
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
            this.ReportListView = new System.Windows.Forms.ListView();
            this.importExternalProgressBar = new System.Windows.Forms.ProgressBar();
            this.ReportStatusLabel = new System.Windows.Forms.Label();
            this.CurrencyExchangePanel = new System.Windows.Forms.Panel();
            this.ExchangePanelCancelButton = new System.Windows.Forms.Button();
            this.ExchangePanelOKButton = new System.Windows.Forms.Button();
            this.EURTextBox = new System.Windows.Forms.TextBox();
            this.CHFTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrencyExchangePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReportListView
            // 
            this.ReportListView.AllowColumnReorder = true;
            this.ReportListView.FullRowSelect = true;
            this.ReportListView.GridLines = true;
            this.ReportListView.LabelEdit = true;
            this.ReportListView.Location = new System.Drawing.Point(63, 38);
            this.ReportListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReportListView.Name = "ReportListView";
            this.ReportListView.Size = new System.Drawing.Size(732, 662);
            this.ReportListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ReportListView.TabIndex = 0;
            this.ReportListView.UseCompatibleStateImageBehavior = false;
            this.ReportListView.View = System.Windows.Forms.View.Details;
            this.ReportListView.DoubleClick += new System.EventHandler(this.ReportListView_DoubleClick);
            // 
            // importExternalProgressBar
            // 
            this.importExternalProgressBar.Location = new System.Drawing.Point(64, 748);
            this.importExternalProgressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.importExternalProgressBar.Name = "importExternalProgressBar";
            this.importExternalProgressBar.Size = new System.Drawing.Size(732, 29);
            this.importExternalProgressBar.TabIndex = 1;
            // 
            // ReportStatusLabel
            // 
            this.ReportStatusLabel.AutoSize = true;
            this.ReportStatusLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportStatusLabel.Location = new System.Drawing.Point(69, 715);
            this.ReportStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ReportStatusLabel.Name = "ReportStatusLabel";
            this.ReportStatusLabel.Size = new System.Drawing.Size(62, 21);
            this.ReportStatusLabel.TabIndex = 2;
            this.ReportStatusLabel.Text = "label1";
            // 
            // CurrencyExchangePanel
            // 
            this.CurrencyExchangePanel.Controls.Add(this.ExchangePanelCancelButton);
            this.CurrencyExchangePanel.Controls.Add(this.ExchangePanelOKButton);
            this.CurrencyExchangePanel.Controls.Add(this.EURTextBox);
            this.CurrencyExchangePanel.Controls.Add(this.CHFTextBox);
            this.CurrencyExchangePanel.Controls.Add(this.label3);
            this.CurrencyExchangePanel.Controls.Add(this.label2);
            this.CurrencyExchangePanel.Controls.Add(this.label1);
            this.CurrencyExchangePanel.Location = new System.Drawing.Point(170, 206);
            this.CurrencyExchangePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CurrencyExchangePanel.Name = "CurrencyExchangePanel";
            this.CurrencyExchangePanel.Size = new System.Drawing.Size(514, 202);
            this.CurrencyExchangePanel.TabIndex = 3;
            this.CurrencyExchangePanel.Visible = false;
            // 
            // ExchangePanelCancelButton
            // 
            this.ExchangePanelCancelButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExchangePanelCancelButton.Location = new System.Drawing.Point(286, 147);
            this.ExchangePanelCancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExchangePanelCancelButton.Name = "ExchangePanelCancelButton";
            this.ExchangePanelCancelButton.Size = new System.Drawing.Size(112, 33);
            this.ExchangePanelCancelButton.TabIndex = 6;
            this.ExchangePanelCancelButton.Text = "Cancel";
            this.ExchangePanelCancelButton.UseVisualStyleBackColor = true;
            this.ExchangePanelCancelButton.Click += new System.EventHandler(this.ExchangePanelCancelButton_Click);
            // 
            // ExchangePanelOKButton
            // 
            this.ExchangePanelOKButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExchangePanelOKButton.Location = new System.Drawing.Point(112, 147);
            this.ExchangePanelOKButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExchangePanelOKButton.Name = "ExchangePanelOKButton";
            this.ExchangePanelOKButton.Size = new System.Drawing.Size(112, 33);
            this.ExchangePanelOKButton.TabIndex = 5;
            this.ExchangePanelOKButton.Text = "OK";
            this.ExchangePanelOKButton.UseVisualStyleBackColor = true;
            this.ExchangePanelOKButton.Click += new System.EventHandler(this.ExchangePanelOKButton_Click);
            // 
            // EURTextBox
            // 
            this.EURTextBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EURTextBox.Location = new System.Drawing.Point(238, 95);
            this.EURTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EURTextBox.Name = "EURTextBox";
            this.EURTextBox.Size = new System.Drawing.Size(103, 26);
            this.EURTextBox.TabIndex = 4;
            // 
            // CHFTextBox
            // 
            this.CHFTextBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHFTextBox.Location = new System.Drawing.Point(238, 58);
            this.CHFTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CHFTextBox.Name = "CHFTextBox";
            this.CHFTextBox.Size = new System.Drawing.Size(103, 26);
            this.CHFTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(165, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "CHF";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(165, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "EUR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter exchange rates.";
            // 
            // ImportExternalData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(861, 810);
            this.Controls.Add(this.CurrencyExchangePanel);
            this.Controls.Add(this.ReportStatusLabel);
            this.Controls.Add(this.importExternalProgressBar);
            this.Controls.Add(this.ReportListView);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ImportExternalData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportExternalData";
            this.Shown += new System.EventHandler(this.ImportExternalData_Shown);
            this.CurrencyExchangePanel.ResumeLayout(false);
            this.CurrencyExchangePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ReportListView;
        private System.Windows.Forms.ProgressBar importExternalProgressBar;
        private System.Windows.Forms.Label ReportStatusLabel;
        private System.Windows.Forms.Panel CurrencyExchangePanel;
        private System.Windows.Forms.Button ExchangePanelCancelButton;
        private System.Windows.Forms.Button ExchangePanelOKButton;
        private System.Windows.Forms.TextBox EURTextBox;
        private System.Windows.Forms.TextBox CHFTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}