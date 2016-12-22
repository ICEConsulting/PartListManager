namespace TecanPartListManager
{
    partial class tableMaintenanceEdit
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
            this.addItemTextBox = new System.Windows.Forms.TextBox();
            this.addItemlabel = new System.Windows.Forms.Label();
            this.addItemButton = new System.Windows.Forms.Button();
            this.cancelAddButton = new System.Windows.Forms.Button();
            this.addItemPanel = new System.Windows.Forms.Panel();
            this.editDeletePanel = new System.Windows.Forms.Panel();
            this.cancelEditButton = new System.Windows.Forms.Button();
            this.deleteItemButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.newItemTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currentItemTextBox = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.addItemPanel.SuspendLayout();
            this.editDeletePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addItemTextBox
            // 
            this.addItemTextBox.Location = new System.Drawing.Point(192, 36);
            this.addItemTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addItemTextBox.Name = "addItemTextBox";
            this.addItemTextBox.Size = new System.Drawing.Size(540, 26);
            this.addItemTextBox.TabIndex = 0;
            // 
            // addItemlabel
            // 
            this.addItemlabel.AutoSize = true;
            this.addItemlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItemlabel.Location = new System.Drawing.Point(33, 38);
            this.addItemlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.addItemlabel.Name = "addItemlabel";
            this.addItemlabel.Size = new System.Drawing.Size(150, 25);
            this.addItemlabel.TabIndex = 1;
            this.addItemlabel.Text = "Enter New Item:";
            // 
            // addItemButton
            // 
            this.addItemButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addItemButton.Location = new System.Drawing.Point(336, 95);
            this.addItemButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(106, 46);
            this.addItemButton.TabIndex = 2;
            this.addItemButton.Text = "Add";
            this.addItemButton.UseVisualStyleBackColor = false;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // cancelAddButton
            // 
            this.cancelAddButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cancelAddButton.Location = new System.Drawing.Point(306, 167);
            this.cancelAddButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelAddButton.Name = "cancelAddButton";
            this.cancelAddButton.Size = new System.Drawing.Size(162, 41);
            this.cancelAddButton.TabIndex = 3;
            this.cancelAddButton.Text = "Cancel";
            this.cancelAddButton.UseVisualStyleBackColor = false;
            this.cancelAddButton.Click += new System.EventHandler(this.cancelAddButton_Click);
            // 
            // addItemPanel
            // 
            this.addItemPanel.Controls.Add(this.cancelAddButton);
            this.addItemPanel.Controls.Add(this.addItemTextBox);
            this.addItemPanel.Controls.Add(this.addItemButton);
            this.addItemPanel.Controls.Add(this.addItemlabel);
            this.addItemPanel.Location = new System.Drawing.Point(18, 16);
            this.addItemPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addItemPanel.Name = "addItemPanel";
            this.addItemPanel.Size = new System.Drawing.Size(776, 244);
            this.addItemPanel.TabIndex = 4;
            this.addItemPanel.Visible = false;
            // 
            // editDeletePanel
            // 
            this.editDeletePanel.Controls.Add(this.cancelEditButton);
            this.editDeletePanel.Controls.Add(this.deleteItemButton);
            this.editDeletePanel.Controls.Add(this.renameButton);
            this.editDeletePanel.Controls.Add(this.newItemTextBox);
            this.editDeletePanel.Controls.Add(this.label1);
            this.editDeletePanel.Controls.Add(this.currentItemTextBox);
            this.editDeletePanel.Controls.Add(this.label);
            this.editDeletePanel.Location = new System.Drawing.Point(16, 16);
            this.editDeletePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.editDeletePanel.Name = "editDeletePanel";
            this.editDeletePanel.Size = new System.Drawing.Size(776, 280);
            this.editDeletePanel.TabIndex = 5;
            this.editDeletePanel.Visible = false;
            // 
            // cancelEditButton
            // 
            this.cancelEditButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cancelEditButton.Location = new System.Drawing.Point(459, 190);
            this.cancelEditButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelEditButton.Name = "cancelEditButton";
            this.cancelEditButton.Size = new System.Drawing.Size(105, 40);
            this.cancelEditButton.TabIndex = 6;
            this.cancelEditButton.Text = "Cancel";
            this.cancelEditButton.UseVisualStyleBackColor = false;
            this.cancelEditButton.Click += new System.EventHandler(this.cancelEditButton_Click);
            // 
            // deleteItemButton
            // 
            this.deleteItemButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.deleteItemButton.Location = new System.Drawing.Point(344, 190);
            this.deleteItemButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteItemButton.Name = "deleteItemButton";
            this.deleteItemButton.Size = new System.Drawing.Size(105, 40);
            this.deleteItemButton.TabIndex = 5;
            this.deleteItemButton.Text = "Delete";
            this.deleteItemButton.UseVisualStyleBackColor = false;
            this.deleteItemButton.Click += new System.EventHandler(this.deleteItemButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.renameButton.Location = new System.Drawing.Point(212, 190);
            this.renameButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(105, 40);
            this.renameButton.TabIndex = 4;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = false;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // newItemTextBox
            // 
            this.newItemTextBox.Location = new System.Drawing.Point(224, 97);
            this.newItemTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.newItemTextBox.Name = "newItemTextBox";
            this.newItemTextBox.Size = new System.Drawing.Size(508, 26);
            this.newItemTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "New Item Name:";
            // 
            // currentItemTextBox
            // 
            this.currentItemTextBox.Location = new System.Drawing.Point(224, 41);
            this.currentItemTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.currentItemTextBox.Name = "currentItemTextBox";
            this.currentItemTextBox.ReadOnly = true;
            this.currentItemTextBox.Size = new System.Drawing.Size(508, 26);
            this.currentItemTextBox.TabIndex = 1;
            this.currentItemTextBox.TabStop = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(33, 43);
            this.label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(182, 25);
            this.label.TabIndex = 0;
            this.label.Text = "Current Item Name:";
            // 
            // tableMaintenanceEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(812, 327);
            this.Controls.Add(this.editDeletePanel);
            this.Controls.Add(this.addItemPanel);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "tableMaintenanceEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tableMaintenanceEdit";
            this.Load += new System.EventHandler(this.tableMaintenanceEdit_Load);
            this.addItemPanel.ResumeLayout(false);
            this.addItemPanel.PerformLayout();
            this.editDeletePanel.ResumeLayout(false);
            this.editDeletePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox addItemTextBox;
        private System.Windows.Forms.Label addItemlabel;
        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.Button cancelAddButton;
        private System.Windows.Forms.Panel addItemPanel;
        private System.Windows.Forms.Panel editDeletePanel;
        private System.Windows.Forms.Button cancelEditButton;
        private System.Windows.Forms.Button deleteItemButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.TextBox newItemTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currentItemTextBox;
        private System.Windows.Forms.Label label;
    }
}