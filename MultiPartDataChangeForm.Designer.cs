namespace TecanPartListManager
{
    partial class MultiPartDataChangeForm
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
            this.currentTableLabel = new System.Windows.Forms.Label();
            this.currentTableListBox = new System.Windows.Forms.ListBox();
            this.SetPartsButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // currentTableLabel
            // 
            this.currentTableLabel.AutoSize = true;
            this.currentTableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTableLabel.Location = new System.Drawing.Point(169, 23);
            this.currentTableLabel.Name = "currentTableLabel";
            this.currentTableLabel.Size = new System.Drawing.Size(57, 20);
            this.currentTableLabel.TabIndex = 0;
            this.currentTableLabel.Text = "label1";
            this.currentTableLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // currentTableListBox
            // 
            this.currentTableListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.currentTableListBox.FormattingEnabled = true;
            this.currentTableListBox.Location = new System.Drawing.Point(32, 61);
            this.currentTableListBox.Name = "currentTableListBox";
            this.currentTableListBox.Size = new System.Drawing.Size(330, 277);
            this.currentTableListBox.TabIndex = 1;
            // 
            // SetPartsButton
            // 
            this.SetPartsButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SetPartsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetPartsButton.Location = new System.Drawing.Point(103, 357);
            this.SetPartsButton.Name = "SetPartsButton";
            this.SetPartsButton.Size = new System.Drawing.Size(91, 32);
            this.SetPartsButton.TabIndex = 2;
            this.SetPartsButton.Text = "SET";
            this.SetPartsButton.UseVisualStyleBackColor = false;
            this.SetPartsButton.Click += new System.EventHandler(this.SetPartsButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(200, 357);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(91, 32);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // MultiPartDataChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(394, 401);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SetPartsButton);
            this.Controls.Add(this.currentTableListBox);
            this.Controls.Add(this.currentTableLabel);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MultiPartDataChangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Multiple Parts Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentTableLabel;
        private System.Windows.Forms.ListBox currentTableListBox;
        private System.Windows.Forms.Button SetPartsButton;
        private System.Windows.Forms.Button CancelButton;
    }
}