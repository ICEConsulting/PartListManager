namespace TecanPartListManager
{
    partial class CompatibilitiesForm
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
            this.compatibilitiesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SAPIDLabel = new System.Windows.Forms.Label();
            this.SetCompatibilitiesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // compatibilitiesListBox
            // 
            this.compatibilitiesListBox.FormattingEnabled = true;
            this.compatibilitiesListBox.ItemHeight = 20;
            this.compatibilitiesListBox.Location = new System.Drawing.Point(80, 109);
            this.compatibilitiesListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.compatibilitiesListBox.Name = "compatibilitiesListBox";
            this.compatibilitiesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.compatibilitiesListBox.Size = new System.Drawing.Size(311, 404);
            this.compatibilitiesListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select All Compatibilities for";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Part# ";
            // 
            // SAPIDLabel
            // 
            this.SAPIDLabel.AutoSize = true;
            this.SAPIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAPIDLabel.Location = new System.Drawing.Point(160, 75);
            this.SAPIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SAPIDLabel.Name = "SAPIDLabel";
            this.SAPIDLabel.Size = new System.Drawing.Size(70, 25);
            this.SAPIDLabel.TabIndex = 3;
            this.SAPIDLabel.Text = "label3";
            // 
            // SetCompatibilitiesButton
            // 
            this.SetCompatibilitiesButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SetCompatibilitiesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetCompatibilitiesButton.Location = new System.Drawing.Point(123, 532);
            this.SetCompatibilitiesButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SetCompatibilitiesButton.Name = "SetCompatibilitiesButton";
            this.SetCompatibilitiesButton.Size = new System.Drawing.Size(228, 57);
            this.SetCompatibilitiesButton.TabIndex = 4;
            this.SetCompatibilitiesButton.Text = "Set Compatibilities";
            this.SetCompatibilitiesButton.UseVisualStyleBackColor = false;
            this.SetCompatibilitiesButton.Click += new System.EventHandler(this.SetCompatibilitiesButton_Click);
            // 
            // CompatibilitiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(472, 608);
            this.Controls.Add(this.SetCompatibilitiesButton);
            this.Controls.Add(this.SAPIDLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.compatibilitiesListBox);
            this.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CompatibilitiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Compatibilities";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox compatibilitiesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SAPIDLabel;
        private System.Windows.Forms.Button SetCompatibilitiesButton;
    }
}