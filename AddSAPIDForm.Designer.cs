namespace TecanPartListManager
{
    partial class AddSAPIDForm
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
            this.NewSAPIDTextBox = new System.Windows.Forms.TextBox();
            this.AddSAPIDButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter SAPID:";
            // 
            // NewSAPIDTextBox
            // 
            this.NewSAPIDTextBox.Location = new System.Drawing.Point(249, 65);
            this.NewSAPIDTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewSAPIDTextBox.Name = "NewSAPIDTextBox";
            this.NewSAPIDTextBox.Size = new System.Drawing.Size(218, 26);
            this.NewSAPIDTextBox.TabIndex = 1;
            // 
            // AddSAPIDButton
            // 
            this.AddSAPIDButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AddSAPIDButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSAPIDButton.Location = new System.Drawing.Point(156, 136);
            this.AddSAPIDButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddSAPIDButton.Name = "AddSAPIDButton";
            this.AddSAPIDButton.Size = new System.Drawing.Size(194, 36);
            this.AddSAPIDButton.TabIndex = 2;
            this.AddSAPIDButton.Text = "Add";
            this.AddSAPIDButton.UseVisualStyleBackColor = false;
            this.AddSAPIDButton.Click += new System.EventHandler(this.AddSAPIDButton_Click);
            // 
            // AddSAPIDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(506, 223);
            this.Controls.Add(this.AddSAPIDButton);
            this.Controls.Add(this.NewSAPIDTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddSAPIDForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter New SAPID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NewSAPIDTextBox;
        private System.Windows.Forms.Button AddSAPIDButton;
    }
}