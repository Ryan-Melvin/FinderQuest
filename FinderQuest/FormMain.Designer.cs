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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelGame = new System.Windows.Forms.Panel();
            this.labelPlayer = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelArea = new System.Windows.Forms.Label();
            this.panelTalkArea = new System.Windows.Forms.Panel();
            this.labelCutscene = new System.Windows.Forms.Label();
            this.labelTimerTalk = new System.Windows.Forms.Label();
            this.labelAreaTalk = new System.Windows.Forms.Label();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.timerGame = new System.Windows.Forms.Timer(this.components);
            this.labelSkip = new System.Windows.Forms.Label();
            this.menuStripGame.SuspendLayout();
            this.panelGame.SuspendLayout();
            this.panelTalkArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripGame
            // 
            this.menuStripGame.BackColor = System.Drawing.SystemColors.Control;
            this.menuStripGame.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripGame.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripGame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripGame.Location = new System.Drawing.Point(0, 0);
            this.menuStripGame.Name = "menuStripGame";
            this.menuStripGame.Size = new System.Drawing.Size(800, 33);
            this.menuStripGame.TabIndex = 0;
            this.menuStripGame.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.pauseToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.startToolStripMenuItem.Text = "Start new Game";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.pauseToolStripMenuItem.Text = "Pause/Play";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(55, 29);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // panelGame
            // 
            this.panelGame.BackColor = System.Drawing.Color.Transparent;
            this.panelGame.Controls.Add(this.labelPlayer);
            this.panelGame.Controls.Add(this.labelTimer);
            this.panelGame.Controls.Add(this.labelArea);
            this.panelGame.Location = new System.Drawing.Point(0, 35);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(800, 108);
            this.panelGame.TabIndex = 1;
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.labelPlayer.ForeColor = System.Drawing.Color.White;
            this.labelPlayer.Location = new System.Drawing.Point(620, 22);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(96, 20);
            this.labelPlayer.TabIndex = 2;
            this.labelPlayer.Text = "labelPlayer";
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimer.ForeColor = System.Drawing.Color.Red;
            this.labelTimer.Location = new System.Drawing.Point(338, 22);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(141, 36);
            this.labelTimer.TabIndex = 1;
            this.labelTimer.Text = "00:00:00";
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.BackColor = System.Drawing.Color.Black;
            this.labelArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArea.ForeColor = System.Drawing.Color.White;
            this.labelArea.Location = new System.Drawing.Point(32, 25);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(104, 25);
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
            this.panelTalkArea.Location = new System.Drawing.Point(0, 35);
            this.panelTalkArea.Name = "panelTalkArea";
            this.panelTalkArea.Size = new System.Drawing.Size(800, 414);
            this.panelTalkArea.TabIndex = 2;
            this.panelTalkArea.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTalkArea_Paint);
            // 
            // labelCutscene
            // 
            this.labelCutscene.AutoSize = true;
            this.labelCutscene.Location = new System.Drawing.Point(280, 174);
            this.labelCutscene.Name = "labelCutscene";
            this.labelCutscene.Size = new System.Drawing.Size(110, 20);
            this.labelCutscene.TabIndex = 4;
            this.labelCutscene.Text = "labelCutscene";
            // 
            // labelTimerTalk
            // 
            this.labelTimerTalk.AutoSize = true;
            this.labelTimerTalk.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimerTalk.ForeColor = System.Drawing.Color.Red;
            this.labelTimerTalk.Location = new System.Drawing.Point(638, 351);
            this.labelTimerTalk.Name = "labelTimerTalk";
            this.labelTimerTalk.Size = new System.Drawing.Size(141, 36);
            this.labelTimerTalk.TabIndex = 3;
            this.labelTimerTalk.Text = "00:00:00";
            // 
            // labelAreaTalk
            // 
            this.labelAreaTalk.AutoSize = true;
            this.labelAreaTalk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAreaTalk.ForeColor = System.Drawing.Color.White;
            this.labelAreaTalk.Location = new System.Drawing.Point(32, 357);
            this.labelAreaTalk.Name = "labelAreaTalk";
            this.labelAreaTalk.Size = new System.Drawing.Size(70, 25);
            this.labelAreaTalk.TabIndex = 3;
            this.labelAreaTalk.Text = "label1";
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
            // labelSkip
            // 
            this.labelSkip.AutoSize = true;
            this.labelSkip.Location = new System.Drawing.Point(354, 364);
            this.labelSkip.Name = "labelSkip";
            this.labelSkip.Size = new System.Drawing.Size(51, 20);
            this.labelSkip.TabIndex = 5;
            this.labelSkip.Text = "label1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FinderQuest.Properties.Resources.Finder_Quest;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.panelTalkArea);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.menuStripGame);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripGame;
            this.Name = "FormMain";
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
        private System.Windows.Forms.Label labelSkip;
    }
}

