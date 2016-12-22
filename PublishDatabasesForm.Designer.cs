namespace TecanPartListManager
{
    partial class PublishDatabasesForm
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
            this.publishProgressBar = new System.Windows.Forms.ProgressBar();
            this.publishLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // publishProgressBar
            // 
            this.publishProgressBar.Location = new System.Drawing.Point(124, 115);
            this.publishProgressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.publishProgressBar.Name = "publishProgressBar";
            this.publishProgressBar.Size = new System.Drawing.Size(444, 33);
            this.publishProgressBar.TabIndex = 0;
            // 
            // publishLabel
            // 
            this.publishLabel.AutoSize = true;
            this.publishLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.publishLabel.Location = new System.Drawing.Point(119, 76);
            this.publishLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.publishLabel.Name = "publishLabel";
            this.publishLabel.Size = new System.Drawing.Size(85, 29);
            this.publishLabel.TabIndex = 1;
            this.publishLabel.Text = "label1";
            this.publishLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PublishDatabasesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(694, 224);
            this.Controls.Add(this.publishLabel);
            this.Controls.Add(this.publishProgressBar);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PublishDatabasesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publish Databases";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar publishProgressBar;
        private System.Windows.Forms.Label publishLabel;
    }
}