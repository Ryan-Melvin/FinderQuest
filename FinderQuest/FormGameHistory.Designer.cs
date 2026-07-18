namespace FinderQuest
{
    partial class FormGameHistory
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
            this.labelSkinsCollected = new System.Windows.Forms.Label();
            this.labelGamesCompleted = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.listBoxDisplay = new System.Windows.Forms.ListBox();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.radioButtonAscending = new System.Windows.Forms.RadioButton();
            this.radioButtonDescending = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // labelSkinsCollected
            // 
            this.labelSkinsCollected.AutoSize = true;
            this.labelSkinsCollected.Font = new System.Drawing.Font("Unispace", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSkinsCollected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(194)))), ((int)(((byte)(161)))));
            this.labelSkinsCollected.Location = new System.Drawing.Point(494, 126);
            this.labelSkinsCollected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSkinsCollected.Name = "labelSkinsCollected";
            this.labelSkinsCollected.Size = new System.Drawing.Size(177, 38);
            this.labelSkinsCollected.TabIndex = 23;
            this.labelSkinsCollected.Text = "Sort By:";
            // 
            // labelGamesCompleted
            // 
            this.labelGamesCompleted.AutoSize = true;
            this.labelGamesCompleted.Font = new System.Drawing.Font("Unispace", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGamesCompleted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(194)))), ((int)(((byte)(161)))));
            this.labelGamesCompleted.Location = new System.Drawing.Point(508, 262);
            this.labelGamesCompleted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGamesCompleted.Name = "labelGamesCompleted";
            this.labelGamesCompleted.Size = new System.Drawing.Size(137, 38);
            this.labelGamesCompleted.TabIndex = 22;
            this.labelGamesCompleted.Text = "Order:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(194)))), ((int)(((byte)(161)))));
            this.labelName.Location = new System.Drawing.Point(394, 42);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(329, 55);
            this.labelName.TabIndex = 18;
            this.labelName.Text = "Game History";
            // 
            // listBoxDisplay
            // 
            this.listBoxDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(149)))), ((int)(((byte)(138)))));
            this.listBoxDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxDisplay.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.listBoxDisplay.FormattingEnabled = true;
            this.listBoxDisplay.ItemHeight = 28;
            this.listBoxDisplay.Location = new System.Drawing.Point(28, 42);
            this.listBoxDisplay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxDisplay.Name = "listBoxDisplay";
            this.listBoxDisplay.Size = new System.Drawing.Size(332, 366);
            this.listBoxDisplay.TabIndex = 24;
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(149)))), ((int)(((byte)(138)))));
            this.comboBoxSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSort.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Location = new System.Drawing.Point(432, 178);
            this.comboBoxSort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(274, 40);
            this.comboBoxSort.TabIndex = 25;
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSort_SelectedIndexChanged);
            // 
            // radioButtonAscending
            // 
            this.radioButtonAscending.AutoSize = true;
            this.radioButtonAscending.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAscending.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(194)))), ((int)(((byte)(161)))));
            this.radioButtonAscending.Location = new System.Drawing.Point(478, 312);
            this.radioButtonAscending.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonAscending.Name = "radioButtonAscending";
            this.radioButtonAscending.Size = new System.Drawing.Size(175, 44);
            this.radioButtonAscending.TabIndex = 26;
            this.radioButtonAscending.TabStop = true;
            this.radioButtonAscending.Text = "Ascending";
            this.radioButtonAscending.UseVisualStyleBackColor = true;
            this.radioButtonAscending.CheckedChanged += new System.EventHandler(this.radioButtonAscending_CheckedChanged);
            // 
            // radioButtonDescending
            // 
            this.radioButtonDescending.AutoSize = true;
            this.radioButtonDescending.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDescending.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(194)))), ((int)(((byte)(161)))));
            this.radioButtonDescending.Location = new System.Drawing.Point(478, 366);
            this.radioButtonDescending.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonDescending.Name = "radioButtonDescending";
            this.radioButtonDescending.Size = new System.Drawing.Size(192, 44);
            this.radioButtonDescending.TabIndex = 27;
            this.radioButtonDescending.TabStop = true;
            this.radioButtonDescending.Text = "Descending";
            this.radioButtonDescending.UseVisualStyleBackColor = true;
            // 
            // FormGameHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.radioButtonDescending);
            this.Controls.Add(this.radioButtonAscending);
            this.Controls.Add(this.comboBoxSort);
            this.Controls.Add(this.listBoxDisplay);
            this.Controls.Add(this.labelSkinsCollected);
            this.Controls.Add(this.labelGamesCompleted);
            this.Controls.Add(this.labelName);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormGameHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game History";
            this.Load += new System.EventHandler(this.FormGameHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelSkinsCollected;
        private System.Windows.Forms.Label labelGamesCompleted;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ListBox listBoxDisplay;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.RadioButton radioButtonAscending;
        private System.Windows.Forms.RadioButton radioButtonDescending;
    }
}