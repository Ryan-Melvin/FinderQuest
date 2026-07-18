namespace FinderQuest
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStripGame = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelGame = new System.Windows.Forms.Panel();
            this.labelPlayer = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelArea = new System.Windows.Forms.Label();
            this.panelTalkArea = new System.Windows.Forms.Panel();
            this.labelSkip = new System.Windows.Forms.Label();
            this.labelCutscene = new System.Windows.Forms.Label();
            this.labelTimerTalk = new System.Windows.Forms.Label();
            this.labelAreaTalk = new System.Windows.Forms.Label();
            this.panelCredits = new System.Windows.Forms.Panel();
            this.buttonExitCredit = new System.Windows.Forms.Button();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.timerGame = new System.Windows.Forms.Timer(this.components);
            this.panelPaused = new System.Windows.Forms.Panel();
            this.labelPaused = new System.Windows.Forms.Label();
            this.panelHelp = new System.Windows.Forms.Panel();
            this.buttonCloseHelp = new System.Windows.Forms.Button();
            this.panelHelpBack = new System.Windows.Forms.Panel();
            this.panelHelpNext = new System.Windows.Forms.Panel();
            this.skinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripGame.SuspendLayout();
            this.panelGame.SuspendLayout();
            this.panelTalkArea.SuspendLayout();
            this.panelCredits.SuspendLayout();
            this.panelPaused.SuspendLayout();
            this.panelHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripGame
            // 
            this.menuStripGame.BackColor = System.Drawing.SystemColors.Control;
            this.menuStripGame.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripGame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.accountToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.creditsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStripGame.Location = new System.Drawing.Point(0, 0);
            this.menuStripGame.Name = "menuStripGame";
            this.menuStripGame.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStripGame.Size = new System.Drawing.Size(533, 24);
            this.menuStripGame.TabIndex = 0;
            this.menuStripGame.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.pauseToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 22);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.startToolStripMenuItem.Text = "Start New Game";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.pauseToolStripMenuItem.Text = "Pause/Play";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileInfoToolStripMenuItem,
            this.skinsToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 22);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // profileInfoToolStripMenuItem
            // 
            this.profileInfoToolStripMenuItem.Name = "profileInfoToolStripMenuItem";
            this.profileInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.profileInfoToolStripMenuItem.Text = "View Profile";
            this.profileInfoToolStripMenuItem.Click += new System.EventHandler(this.profileInfoToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panelGame
            // 
            this.panelGame.BackColor = System.Drawing.Color.Transparent;
            this.panelGame.Controls.Add(this.labelPlayer);
            this.panelGame.Controls.Add(this.labelTimer);
            this.panelGame.Controls.Add(this.labelArea);
            this.panelGame.Location = new System.Drawing.Point(0, 23);
            this.panelGame.Margin = new System.Windows.Forms.Padding(2);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(533, 70);
            this.panelGame.TabIndex = 1;
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer.ForeColor = System.Drawing.Color.White;
            this.labelPlayer.Location = new System.Drawing.Point(380, 16);
            this.labelPlayer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(87, 16);
            this.labelPlayer.TabIndex = 2;
            this.labelPlayer.Text = "labelPlayer";
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimer.ForeColor = System.Drawing.Color.Red;
            this.labelTimer.Location = new System.Drawing.Point(225, 14);
            this.labelTimer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(98, 25);
            this.labelTimer.TabIndex = 1;
            this.labelTimer.Text = "00:00:00";
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.BackColor = System.Drawing.Color.Black;
            this.labelArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArea.ForeColor = System.Drawing.Color.White;
            this.labelArea.Location = new System.Drawing.Point(21, 16);
            this.labelArea.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(77, 17);
            this.labelArea.TabIndex = 0;
            this.labelArea.Text = "labelArea";
            // 
            // panelTalkArea
            // 
            this.panelTalkArea.BackColor = System.Drawing.Color.Transparent;
            this.panelTalkArea.Controls.Add(this.labelSkip);
            this.panelTalkArea.Controls.Add(this.labelCutscene);
            this.panelTalkArea.Controls.Add(this.labelTimerTalk);
            this.panelTalkArea.Controls.Add(this.labelAreaTalk);
            this.panelTalkArea.Location = new System.Drawing.Point(0, 23);
            this.panelTalkArea.Margin = new System.Windows.Forms.Padding(2);
            this.panelTalkArea.Name = "panelTalkArea";
            this.panelTalkArea.Size = new System.Drawing.Size(533, 269);
            this.panelTalkArea.TabIndex = 2;
            this.panelTalkArea.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTalkArea_Paint);
            // 
            // labelSkip
            // 
            this.labelSkip.AutoSize = true;
            this.labelSkip.Location = new System.Drawing.Point(245, 216);
            this.labelSkip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSkip.Name = "labelSkip";
            this.labelSkip.Size = new System.Drawing.Size(28, 13);
            this.labelSkip.TabIndex = 5;
            this.labelSkip.Text = "Skip";
            // 
            // labelCutscene
            // 
            this.labelCutscene.AutoSize = true;
            this.labelCutscene.Location = new System.Drawing.Point(187, 113);
            this.labelCutscene.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCutscene.Name = "labelCutscene";
            this.labelCutscene.Size = new System.Drawing.Size(74, 13);
            this.labelCutscene.TabIndex = 4;
            this.labelCutscene.Text = "labelCutscene";
            // 
            // labelTimerTalk
            // 
            this.labelTimerTalk.AutoSize = true;
            this.labelTimerTalk.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimerTalk.ForeColor = System.Drawing.Color.Red;
            this.labelTimerTalk.Location = new System.Drawing.Point(425, 228);
            this.labelTimerTalk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTimerTalk.Name = "labelTimerTalk";
            this.labelTimerTalk.Size = new System.Drawing.Size(98, 25);
            this.labelTimerTalk.TabIndex = 3;
            this.labelTimerTalk.Text = "00:00:00";
            // 
            // labelAreaTalk
            // 
            this.labelAreaTalk.AutoSize = true;
            this.labelAreaTalk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAreaTalk.ForeColor = System.Drawing.Color.White;
            this.labelAreaTalk.Location = new System.Drawing.Point(21, 232);
            this.labelAreaTalk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAreaTalk.Name = "labelAreaTalk";
            this.labelAreaTalk.Size = new System.Drawing.Size(52, 17);
            this.labelAreaTalk.TabIndex = 3;
            this.labelAreaTalk.Text = "label1";
            // 
            // panelCredits
            // 
            this.panelCredits.BackgroundImage = global::FinderQuest.Properties.Resources.Credits;
            this.panelCredits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelCredits.Controls.Add(this.buttonExitCredit);
            this.panelCredits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelCredits.Location = new System.Drawing.Point(2, 21);
            this.panelCredits.Margin = new System.Windows.Forms.Padding(2);
            this.panelCredits.Name = "panelCredits";
            this.panelCredits.Size = new System.Drawing.Size(533, 269);
            this.panelCredits.TabIndex = 6;
            // 
            // buttonExitCredit
            // 
            this.buttonExitCredit.BackColor = System.Drawing.Color.Maroon;
            this.buttonExitCredit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonExitCredit.FlatAppearance.BorderSize = 2;
            this.buttonExitCredit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExitCredit.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExitCredit.ForeColor = System.Drawing.Color.PeachPuff;
            this.buttonExitCredit.Location = new System.Drawing.Point(240, 176);
            this.buttonExitCredit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExitCredit.Name = "buttonExitCredit";
            this.buttonExitCredit.Size = new System.Drawing.Size(44, 25);
            this.buttonExitCredit.TabIndex = 0;
            this.buttonExitCredit.Text = "Close";
            this.buttonExitCredit.UseVisualStyleBackColor = false;
            this.buttonExitCredit.Click += new System.EventHandler(this.buttonExitCredit_Click);
            // 
            // timerTime
            // 
            this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
            // 
            // timerGame
            // 
            this.timerGame.Interval = 20;
            this.timerGame.Tick += new System.EventHandler(this.timerGame_Tick);
            // 
            // panelPaused
            // 
            this.panelPaused.Controls.Add(this.labelPaused);
            this.panelPaused.Location = new System.Drawing.Point(0, 23);
            this.panelPaused.Margin = new System.Windows.Forms.Padding(2);
            this.panelPaused.Name = "panelPaused";
            this.panelPaused.Size = new System.Drawing.Size(533, 269);
            this.panelPaused.TabIndex = 5;
            this.panelPaused.Visible = false;
            // 
            // labelPaused
            // 
            this.labelPaused.AutoSize = true;
            this.labelPaused.Location = new System.Drawing.Point(210, 129);
            this.labelPaused.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPaused.Name = "labelPaused";
            this.labelPaused.Size = new System.Drawing.Size(43, 13);
            this.labelPaused.TabIndex = 0;
            this.labelPaused.Text = "Paused";
            // 
            // panelHelp
            // 
            this.panelHelp.BackgroundImage = global::FinderQuest.Properties.Resources.help1;
            this.panelHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHelp.Controls.Add(this.buttonCloseHelp);
            this.panelHelp.Controls.Add(this.panelHelpBack);
            this.panelHelp.Controls.Add(this.panelHelpNext);
            this.panelHelp.Location = new System.Drawing.Point(0, 21);
            this.panelHelp.Margin = new System.Windows.Forms.Padding(2);
            this.panelHelp.Name = "panelHelp";
            this.panelHelp.Size = new System.Drawing.Size(533, 270);
            this.panelHelp.TabIndex = 6;
            // 
            // buttonCloseHelp
            // 
            this.buttonCloseHelp.BackColor = System.Drawing.Color.Maroon;
            this.buttonCloseHelp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonCloseHelp.FlatAppearance.BorderSize = 2;
            this.buttonCloseHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseHelp.ForeColor = System.Drawing.Color.PeachPuff;
            this.buttonCloseHelp.Location = new System.Drawing.Point(237, 229);
            this.buttonCloseHelp.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCloseHelp.Name = "buttonCloseHelp";
            this.buttonCloseHelp.Size = new System.Drawing.Size(53, 26);
            this.buttonCloseHelp.TabIndex = 2;
            this.buttonCloseHelp.Text = "Close";
            this.buttonCloseHelp.UseVisualStyleBackColor = false;
            this.buttonCloseHelp.Click += new System.EventHandler(this.buttonCloseHelp_Click);
            // 
            // panelHelpBack
            // 
            this.panelHelpBack.BackColor = System.Drawing.Color.Transparent;
            this.panelHelpBack.Location = new System.Drawing.Point(70, 123);
            this.panelHelpBack.Margin = new System.Windows.Forms.Padding(2);
            this.panelHelpBack.Name = "panelHelpBack";
            this.panelHelpBack.Size = new System.Drawing.Size(73, 39);
            this.panelHelpBack.TabIndex = 1;
            this.panelHelpBack.Click += new System.EventHandler(this.panelHelpBack_Click);
            // 
            // panelHelpNext
            // 
            this.panelHelpNext.BackColor = System.Drawing.Color.Transparent;
            this.panelHelpNext.Location = new System.Drawing.Point(389, 123);
            this.panelHelpNext.Margin = new System.Windows.Forms.Padding(2);
            this.panelHelpNext.Name = "panelHelpNext";
            this.panelHelpNext.Size = new System.Drawing.Size(73, 39);
            this.panelHelpNext.TabIndex = 0;
            this.panelHelpNext.Click += new System.EventHandler(this.panelHelpNext_Click);
            // 
            // skinsToolStripMenuItem
            // 
            this.skinsToolStripMenuItem.Name = "skinsToolStripMenuItem";
            this.skinsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.skinsToolStripMenuItem.Text = "Skins";
            this.skinsToolStripMenuItem.Click += new System.EventHandler(this.skinsToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FinderQuest.Properties.Resources.Finder_Quest;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.panelHelp);
            this.Controls.Add(this.panelTalkArea);
            this.Controls.Add(this.panelCredits);
            this.Controls.Add(this.panelPaused);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.menuStripGame);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripGame;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finder Quest Game";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
            this.menuStripGame.ResumeLayout(false);
            this.menuStripGame.PerformLayout();
            this.panelGame.ResumeLayout(false);
            this.panelGame.PerformLayout();
            this.panelTalkArea.ResumeLayout(false);
            this.panelTalkArea.PerformLayout();
            this.panelCredits.ResumeLayout(false);
            this.panelPaused.ResumeLayout(false);
            this.panelPaused.PerformLayout();
            this.panelHelp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripGame;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelArea;
        private System.Windows.Forms.Panel panelTalkArea;
        private System.Windows.Forms.Timer timerTime;
        public System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.Timer timerGame;
        private System.Windows.Forms.Label labelTimerTalk;
        private System.Windows.Forms.Label labelAreaTalk;
        private System.Windows.Forms.Label labelCutscene;
        private System.Windows.Forms.Panel panelPaused;
        private System.Windows.Forms.Label labelPaused;
        private System.Windows.Forms.Label labelSkip;
        private System.Windows.Forms.Panel panelCredits;
        private System.Windows.Forms.Button buttonExitCredit;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.Panel panelHelp;
        private System.Windows.Forms.Button buttonCloseHelp;
        private System.Windows.Forms.Panel panelHelpBack;
        private System.Windows.Forms.Panel panelHelpNext;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skinsToolStripMenuItem;
    }
}

