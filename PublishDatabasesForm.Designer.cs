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
            this.publishProgressBar.Location = new System.Drawing.Point(83, 83);
            this.publishProgressBar.Name = "publishProgressBar";
            this.publishProgressBar.Size = new System.Drawing.Size(296, 24);
            this.publishProgressBar.TabIndex = 0;
            // 
            // publishLabel
            // 
            this.publishLabel.AutoSize = true;
            this.publishLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.publishLabel.Location = new System.Drawing.Point(214, 56);
            this.publishLabel.Name = "publishLabel";
            this.publishLabel.Size = new System.Drawing.Size(57, 20);
            this.publishLabel.TabIndex = 1;
            this.publishLabel.Text = "label1";
            this.publishLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PublishDatabasesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 162);
            this.Controls.Add(this.publishLabel);
            this.Controls.Add(this.publishProgressBar);
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