namespace FinderQuest
{
    partial class FormPlayReport
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.labelFeedback = new System.Windows.Forms.Label();
            this.labelStars = new System.Windows.Forms.Label();
            this.labelStats = new System.Windows.Forms.Label();
            this.panelBack = new System.Windows.Forms.Panel();
            this.pictureBoxGold = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelGold = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGold)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(296, 27);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(149, 29);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = "Play Report";
            // 
            // buttonReturn
            // 
            this.buttonReturn.AutoSize = true;
            this.buttonReturn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonReturn.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonReturn.FlatAppearance.BorderSize = 0;
            this.buttonReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonReturn.ForeColor = System.Drawing.Color.White;
            this.buttonReturn.Location = new System.Drawing.Point(301, 412);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(135, 42);
            this.buttonReturn.TabIndex = 10;
            this.buttonReturn.Text = "Return";
            this.buttonReturn.UseVisualStyleBackColor = false;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // labelFeedback
            // 
            this.labelFeedback.BackColor = System.Drawing.Color.Transparent;
            this.labelFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFeedback.ForeColor = System.Drawing.Color.Black;
            this.labelFeedback.Location = new System.Drawing.Point(26, 76);
            this.labelFeedback.Name = "labelFeedback";
            this.labelFeedback.Size = new System.Drawing.Size(486, 38);
            this.labelFeedback.TabIndex = 8;
            this.labelFeedback.Text = "labelFeedback";
            this.labelFeedback.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStars
            // 
            this.labelStars.BackColor = System.Drawing.Color.Transparent;
            this.labelStars.Cursor = System.Windows.Forms.Cursors.No;
            this.labelStars.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelStars.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStars.Location = new System.Drawing.Point(21, 0);
            this.labelStars.Name = "labelStars";
            this.labelStars.Size = new System.Drawing.Size(491, 64);
            this.labelStars.TabIndex = 7;
            this.labelStars.Text = "labelStars";
            this.labelStars.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStats
            // 
            this.labelStats.BackColor = System.Drawing.Color.Transparent;
            this.labelStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStats.ForeColor = System.Drawing.Color.White;
            this.labelStats.Location = new System.Drawing.Point(94, 114);
            this.labelStats.Name = "labelStats";
            this.labelStats.Size = new System.Drawing.Size(335, 57);
            this.labelStats.TabIndex = 6;
            this.labelStats.Text = "labelStats";
            this.labelStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBack
            // 
            this.panelBack.BackColor = System.Drawing.Color.Gray;
            this.panelBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBack.Controls.Add(this.label3);
            this.panelBack.Controls.Add(this.labelScore);
            this.panelBack.Controls.Add(this.labelGold);
            this.panelBack.Controls.Add(this.label1);
            this.panelBack.Controls.Add(this.pictureBoxGold);
            this.panelBack.Controls.Add(this.labelFeedback);
            this.panelBack.Controls.Add(this.labelStars);
            this.panelBack.Controls.Add(this.labelStats);
            this.panelBack.Location = new System.Drawing.Point(109, 76);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(532, 321);
            this.panelBack.TabIndex = 12;
            this.panelBack.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBack_Paint);
            // 
            // pictureBoxGold
            // 
            this.pictureBoxGold.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxGold.Image = global::FinderQuest.Properties.Resources.Coin;
            this.pictureBoxGold.Location = new System.Drawing.Point(262, 233);
            this.pictureBoxGold.Name = "pictureBoxGold";
            this.pictureBoxGold.Size = new System.Drawing.Size(63, 59);
            this.pictureBoxGold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGold.TabIndex = 9;
            this.pictureBoxGold.TabStop = false;
            this.pictureBoxGold.UseWaitCursor = true;
            this.pictureBoxGold.Click += new System.EventHandler(this.pictureBoxGold_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightCyan;
            this.label1.Location = new System.Drawing.Point(136, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Final Score:";
            // 
            // labelGold
            // 
            this.labelGold.AutoSize = true;
            this.labelGold.BackColor = System.Drawing.Color.Transparent;
            this.labelGold.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGold.ForeColor = System.Drawing.Color.Gold;
            this.labelGold.Location = new System.Drawing.Point(325, 244);
            this.labelGold.Name = "labelGold";
            this.labelGold.Size = new System.Drawing.Size(117, 37);
            this.labelGold.TabIndex = 11;
            this.labelGold.Text = "1000G";
            this.labelGold.Click += new System.EventHandler(this.labelGold_Click);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.Transparent;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.ForeColor = System.Drawing.Color.LightCyan;
            this.labelScore.Location = new System.Drawing.Point(287, 188);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(104, 29);
            this.labelScore.TabIndex = 12;
            this.labelScore.Text = "4000pts";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(83, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 29);
            this.label3.TabIndex = 13;
            this.label3.Text = "Gold Earned:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // FormPlayReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FinderQuest.Properties.Resources.Mountain;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(760, 478);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.panelBack);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Name = "FormPlayReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Play Report";
            this.Load += new System.EventHandler(this.FormPlayReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPlayReport_KeyDown);
            this.panelBack.ResumeLayout(false);
            this.panelBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Label labelFeedback;
        private System.Windows.Forms.Label labelStars;
        private System.Windows.Forms.Label labelStats;
        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.PictureBox pictureBoxGold;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelGold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}