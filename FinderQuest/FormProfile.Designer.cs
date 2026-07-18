namespace FinderQuest
{
    partial class FormProfile
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
            this.panelProfileSkin = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonNewSave = new System.Windows.Forms.Button();
            this.buttonSaveProgress = new System.Windows.Forms.Button();
            this.buttonLoadProgress = new System.Windows.Forms.Button();
            this.buttonViewHistory = new System.Windows.Forms.Button();
            this.labelGamesCompleted = new System.Windows.Forms.Label();
            this.labelSkinsCollected = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelGoldBalance = new System.Windows.Forms.Label();
            this.labelHighScore = new System.Windows.Forms.Label();
            this.labelTotalGold = new System.Windows.Forms.Label();
            this.pictureBoxGold = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGold)).BeginInit();
            this.SuspendLayout();
            // 
            // panelProfileSkin
            // 
            this.panelProfileSkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(149)))), ((int)(((byte)(138)))));
            this.panelProfileSkin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProfileSkin.Location = new System.Drawing.Point(57, 31);
            this.panelProfileSkin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelProfileSkin.Name = "panelProfileSkin";
            this.panelProfileSkin.Size = new System.Drawing.Size(246, 311);
            this.panelProfileSkin.TabIndex = 0;
            this.panelProfileSkin.Paint += new System.Windows.Forms.PaintEventHandler(this.panelProfileSkin_Paint);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Plus Jakarta Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(194)))), ((int)(((byte)(161)))));
            this.labelName.Location = new System.Drawing.Point(327, 9);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(175, 79);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Guest";
            // 
            // buttonNewSave
            // 
            this.buttonNewSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(102)))), ((int)(((byte)(65)))));
            this.buttonNewSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.buttonNewSave.FlatAppearance.BorderSize = 2;
            this.buttonNewSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonNewSave.Location = new System.Drawing.Point(57, 369);
            this.buttonNewSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonNewSave.Name = "buttonNewSave";
            this.buttonNewSave.Size = new System.Drawing.Size(88, 62);
            this.buttonNewSave.TabIndex = 3;
            this.buttonNewSave.Text = "New Save";
            this.buttonNewSave.UseVisualStyleBackColor = false;
            this.buttonNewSave.Click += new System.EventHandler(this.buttonNewSave_Click);
            // 
            // buttonSaveProgress
            // 
            this.buttonSaveProgress.BackColor = System.Drawing.Color.Maroon;
            this.buttonSaveProgress.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonSaveProgress.FlatAppearance.BorderSize = 2;
            this.buttonSaveProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveProgress.ForeColor = System.Drawing.Color.PeachPuff;
            this.buttonSaveProgress.Location = new System.Drawing.Point(150, 369);
            this.buttonSaveProgress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSaveProgress.Name = "buttonSaveProgress";
            this.buttonSaveProgress.Size = new System.Drawing.Size(154, 62);
            this.buttonSaveProgress.TabIndex = 4;
            this.buttonSaveProgress.Text = "Save Progress";
            this.buttonSaveProgress.UseVisualStyleBackColor = false;
            this.buttonSaveProgress.Click += new System.EventHandler(this.buttonSaveProgress_Click);
            // 
            // buttonLoadProgress
            // 
            this.buttonLoadProgress.BackColor = System.Drawing.Color.Maroon;
            this.buttonLoadProgress.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonLoadProgress.FlatAppearance.BorderSize = 2;
            this.buttonLoadProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadProgress.ForeColor = System.Drawing.Color.PeachPuff;
            this.buttonLoadProgress.Location = new System.Drawing.Point(308, 369);
            this.buttonLoadProgress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLoadProgress.Name = "buttonLoadProgress";
            this.buttonLoadProgress.Size = new System.Drawing.Size(150, 62);
            this.buttonLoadProgress.TabIndex = 1;
            this.buttonLoadProgress.Text = "Load Progress";
            this.buttonLoadProgress.UseVisualStyleBackColor = false;
            this.buttonLoadProgress.Click += new System.EventHandler(this.buttonLoadProgress_Click);
            // 
            // buttonViewHistory
            // 
            this.buttonViewHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(82)))), ((int)(((byte)(45)))));
            this.buttonViewHistory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(133)))), ((int)(((byte)(70)))));
            this.buttonViewHistory.FlatAppearance.BorderSize = 3;
            this.buttonViewHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonViewHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(212)))));
            this.buttonViewHistory.Location = new System.Drawing.Point(489, 369);
            this.buttonViewHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonViewHistory.Name = "buttonViewHistory";
            this.buttonViewHistory.Size = new System.Drawing.Size(255, 62);
            this.buttonViewHistory.TabIndex = 6;
            this.buttonViewHistory.Text = "View Game History";
            this.buttonViewHistory.UseVisualStyleBackColor = false;
            this.buttonViewHistory.Click += new System.EventHandler(this.buttonViewHistory_Click);
            // 
            // labelGamesCompleted
            // 
            this.labelGamesCompleted.AutoSize = true;
            this.labelGamesCompleted.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGamesCompleted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(194)))), ((int)(((byte)(161)))));
            this.labelGamesCompleted.Location = new System.Drawing.Point(336, 100);
            this.labelGamesCompleted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGamesCompleted.Name = "labelGamesCompleted";
            this.labelGamesCompleted.Size = new System.Drawing.Size(253, 29);
            this.labelGamesCompleted.TabIndex = 7;
            this.labelGamesCompleted.Text = "Games Completed:";
            // 
            // labelSkinsCollected
            // 
            this.labelSkinsCollected.AutoSize = true;
            this.labelSkinsCollected.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSkinsCollected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(194)))), ((int)(((byte)(161)))));
            this.labelSkinsCollected.Location = new System.Drawing.Point(336, 149);
            this.labelSkinsCollected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSkinsCollected.Name = "labelSkinsCollected";
            this.labelSkinsCollected.Size = new System.Drawing.Size(268, 29);
            this.labelSkinsCollected.TabIndex = 8;
            this.labelSkinsCollected.Text = "Skins Collected: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Unispace", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MediumPurple;
            this.label5.Location = new System.Drawing.Point(336, 197);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 35);
            this.label5.TabIndex = 9;
            this.label5.Text = "High Score:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Unispace", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gold;
            this.label6.Location = new System.Drawing.Point(336, 263);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 35);
            this.label6.TabIndex = 10;
            this.label6.Text = "Balance:";
            // 
            // labelGoldBalance
            // 
            this.labelGoldBalance.AutoSize = true;
            this.labelGoldBalance.BackColor = System.Drawing.Color.Transparent;
            this.labelGoldBalance.Font = new System.Drawing.Font("Unispace", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGoldBalance.ForeColor = System.Drawing.Color.Gold;
            this.labelGoldBalance.Location = new System.Drawing.Point(547, 258);
            this.labelGoldBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGoldBalance.Name = "labelGoldBalance";
            this.labelGoldBalance.Size = new System.Drawing.Size(129, 43);
            this.labelGoldBalance.TabIndex = 13;
            this.labelGoldBalance.Text = "1000G";
            // 
            // labelHighScore
            // 
            this.labelHighScore.AutoSize = true;
            this.labelHighScore.BackColor = System.Drawing.Color.Transparent;
            this.labelHighScore.Font = new System.Drawing.Font("Unispace", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHighScore.ForeColor = System.Drawing.Color.MediumPurple;
            this.labelHighScore.Location = new System.Drawing.Point(536, 192);
            this.labelHighScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHighScore.Name = "labelHighScore";
            this.labelHighScore.Size = new System.Drawing.Size(173, 43);
            this.labelHighScore.TabIndex = 14;
            this.labelHighScore.Text = "4000pts";
            // 
            // labelTotalGold
            // 
            this.labelTotalGold.AutoSize = true;
            this.labelTotalGold.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalGold.Font = new System.Drawing.Font("Unispace", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalGold.ForeColor = System.Drawing.Color.Gold;
            this.labelTotalGold.Location = new System.Drawing.Point(339, 320);
            this.labelTotalGold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotalGold.Name = "labelTotalGold";
            this.labelTotalGold.Size = new System.Drawing.Size(238, 24);
            this.labelTotalGold.TabIndex = 15;
            this.labelTotalGold.Text = "Total Gold Earned: ";
            // 
            // pictureBoxGold
            // 
            this.pictureBoxGold.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxGold.Image = global::FinderQuest.Properties.Resources.Coin;
            this.pictureBoxGold.Location = new System.Drawing.Point(492, 254);
            this.pictureBoxGold.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxGold.Name = "pictureBoxGold";
            this.pictureBoxGold.Size = new System.Drawing.Size(50, 49);
            this.pictureBoxGold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGold.TabIndex = 12;
            this.pictureBoxGold.TabStop = false;
            this.pictureBoxGold.UseWaitCursor = true;
            // 
            // FormProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.labelTotalGold);
            this.Controls.Add(this.labelHighScore);
            this.Controls.Add(this.labelGoldBalance);
            this.Controls.Add(this.pictureBoxGold);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelSkinsCollected);
            this.Controls.Add(this.labelGamesCompleted);
            this.Controls.Add(this.buttonViewHistory);
            this.Controls.Add(this.buttonSaveProgress);
            this.Controls.Add(this.buttonNewSave);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonLoadProgress);
            this.Controls.Add(this.panelProfileSkin);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profile Information";
            this.Load += new System.EventHandler(this.FormProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelProfileSkin;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonNewSave;
        private System.Windows.Forms.Button buttonSaveProgress;
        private System.Windows.Forms.Button buttonLoadProgress;
        private System.Windows.Forms.Button buttonViewHistory;
        private System.Windows.Forms.Label labelGamesCompleted;
        private System.Windows.Forms.Label labelSkinsCollected;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelGoldBalance;
        private System.Windows.Forms.PictureBox pictureBoxGold;
        private System.Windows.Forms.Label labelHighScore;
        private System.Windows.Forms.Label labelTotalGold;
    }
}