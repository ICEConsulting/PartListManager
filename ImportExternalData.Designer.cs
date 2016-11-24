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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CHFTextBox = new System.Windows.Forms.TextBox();
            this.EURTextBox = new System.Windows.Forms.TextBox();
            this.ExchangePanelOKButton = new System.Windows.Forms.Button();
            this.ExchangePanelCancelButton = new System.Windows.Forms.Button();
            this.CurrencyExchangePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReportListView
            // 
            this.ReportListView.AllowColumnReorder = true;
            this.ReportListView.FullRowSelect = true;
            this.ReportListView.GridLines = true;
            this.ReportListView.LabelEdit = true;
            this.ReportListView.Location = new System.Drawing.Point(42, 27);
            this.ReportListView.Name = "ReportListView";
            this.ReportListView.Size = new System.Drawing.Size(489, 479);
            this.ReportListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ReportListView.TabIndex = 0;
            this.ReportListView.UseCompatibleStateImageBehavior = false;
            this.ReportListView.View = System.Windows.Forms.View.Details;
            this.ReportListView.DoubleClick += new System.EventHandler(this.ReportListView_DoubleClick);
            // 
            // importExternalProgressBar
            // 
            this.importExternalProgressBar.Location = new System.Drawing.Point(43, 540);
            this.importExternalProgressBar.Name = "importExternalProgressBar";
            this.importExternalProgressBar.Size = new System.Drawing.Size(488, 21);
            this.importExternalProgressBar.TabIndex = 1;
            // 
            // ReportStatusLabel
            // 
            this.ReportStatusLabel.AutoSize = true;
            this.ReportStatusLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportStatusLabel.Location = new System.Drawing.Point(46, 517);
            this.ReportStatusLabel.Name = "ReportStatusLabel";
            this.ReportStatusLabel.Size = new System.Drawing.Size(41, 15);
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
            this.CurrencyExchangePanel.Location = new System.Drawing.Point(113, 149);
            this.CurrencyExchangePanel.Name = "CurrencyExchangePanel";
            this.CurrencyExchangePanel.Size = new System.Drawing.Size(343, 146);
            this.CurrencyExchangePanel.TabIndex = 3;
            this.CurrencyExchangePanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter exchange rates.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "EUR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(110, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "CHF";
            // 
            // CHFTextBox
            // 
            this.CHFTextBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHFTextBox.Location = new System.Drawing.Point(159, 42);
            this.CHFTextBox.Name = "CHFTextBox";
            this.CHFTextBox.Size = new System.Drawing.Size(70, 20);
            this.CHFTextBox.TabIndex = 3;
            // 
            // EURTextBox
            // 
            this.EURTextBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EURTextBox.Location = new System.Drawing.Point(159, 69);
            this.EURTextBox.Name = "EURTextBox";
            this.EURTextBox.Size = new System.Drawing.Size(70, 20);
            this.EURTextBox.TabIndex = 4;
            // 
            // ExchangePanelOKButton
            // 
            this.ExchangePanelOKButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExchangePanelOKButton.Location = new System.Drawing.Point(75, 106);
            this.ExchangePanelOKButton.Name = "ExchangePanelOKButton";
            this.ExchangePanelOKButton.Size = new System.Drawing.Size(75, 24);
            this.ExchangePanelOKButton.TabIndex = 5;
            this.ExchangePanelOKButton.Text = "OK";
            this.ExchangePanelOKButton.UseVisualStyleBackColor = true;
            this.ExchangePanelOKButton.Click += new System.EventHandler(this.ExchangePanelOKButton_Click);
            // 
            // ExchangePanelCancelButton
            // 
            this.ExchangePanelCancelButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExchangePanelCancelButton.Location = new System.Drawing.Point(191, 106);
            this.ExchangePanelCancelButton.Name = "ExchangePanelCancelButton";
            this.ExchangePanelCancelButton.Size = new System.Drawing.Size(75, 24);
            this.ExchangePanelCancelButton.TabIndex = 6;
            this.ExchangePanelCancelButton.Text = "Cancel";
            this.ExchangePanelCancelButton.UseVisualStyleBackColor = true;
            this.ExchangePanelCancelButton.Click += new System.EventHandler(this.ExchangePanelCancelButton_Click);
            // 
            // ImportExternalData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 585);
            this.Controls.Add(this.CurrencyExchangePanel);
            this.Controls.Add(this.ReportStatusLabel);
            this.Controls.Add(this.importExternalProgressBar);
            this.Controls.Add(this.ReportListView);
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