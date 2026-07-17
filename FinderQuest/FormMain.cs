using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeApplication;

namespace FinderQuest
{
    public partial class FormMain : Form
    {
        #region fields
        public GameManager game = new GameManager(); // Centralized game manager that handles logic
        public SoundManager sound = new SoundManager(); //Centralized sound manager that handles music and SFX
        public CutsceneManager cutscene = new CutsceneManager(); //Centralized cutscene manager that hanldles all cutscenes
        public WalkAreaManager walkArea = new WalkAreaManager(); //Centralized walk area manager that handles all walk area logic
        public TalkAreaManager talkArea = new TalkAreaManager(); //Centralized talk area manager that handles all talk area logic

        private FormQuestion form;
        public Time time;
        public Time timePlayed;
        private bool paused;
        private int numOfWalkArea = 8; // 8 walk areas

        public Player player;
        private bool enterTalkArea = false;
        private bool gameStarted = false;

        private int savePersonX;
        private int savePersonY;
        private Size savePersonSize;

        private int smallNPC = 110;
        private int mediumNPC = 120;
        private int bigNPC = 150;
        private int bossSize = 220;

        private bool allowReturnMainMenu = false;
        private bool inCutscene = false;
        private bool allowSkipCutscene = false;
        private bool blockEnterToStart = false;
        public CancellationTokenSource skip; //for signaling to the cutscene method to skip the cutscene

        private int helpPage = 1;
        #endregion

        #region constructor
        public FormMain()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            typeof(Panel).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, panelTalkArea, new object[] { true });
        }
        #endregion

        #region helper methods
        public void SetAllowSkipCutscene(bool value)
        {
            this.allowSkipCutscene = value;
        }

        public void SetGameStarted(bool value)
        {
            this.gameStarted = value;
        }

        public void SetAllowReturnMainMenu(bool value)
        {
            this.allowReturnMainMenu = value;
        }

        public void SetInCutscene(bool value)
        {
            this.inCutscene = value;
        }

        public Panel GetGamePanel()
        {
            return this.panelGame;
        }

        public Panel GetTalkAreaPanel()
        {
            return this.panelTalkArea;
        }
        public int GetSize(string type)
        {
            if(type == "small")
            {
                return this.smallNPC;
            } 
            else if(type == "medium")
            {
                return this.mediumNPC;
            }
            else if(type == "big")
            {
                return this.bigNPC;
            }
            else
            {
                return this.bossSize;
            }
        }

        public Size GetPlayerSize()
        {
            return player.Size;
        }

        public void SavePeronX(int x)
        {
            this.savePersonX = x;
        }

        public int GetPersonX()
        {
            return this.savePersonX;   
        }

        public void SavePersonY(int y)
        {
            this.savePersonY = y;
        }

        public int GetPersonY()
        {
            return this.savePersonY;
        }

        public void SavePersonSize(Size size)
        {
            this.savePersonSize = size;
        }

        public Size GetPersonSize()
        {
            return this.savePersonSize;
        }

        public void SetEnterTalkArea(bool value)
        {
            this.enterTalkArea = value;
        }
        #endregion

        #region form lifecycle events
        // Change to async function (pull trivia items immediately at Form Load)
        private async void FormMain_Load(object sender, EventArgs e)
        {
            #region styling
            labelArea.Parent = panelGame;
            labelPlayer.Parent = panelGame;
            labelArea.BackColor = Color.FromArgb(120, 0, 0, 0);
            labelArea.ForeColor = Color.White;
            labelPlayer.BackColor = Color.FromArgb(120, 0, 0, 0);
            labelTimer.BackColor = Color.FromArgb(120, 0, 0, 0);
            labelTimerTalk.BackColor = Color.FromArgb(120, 0, 0, 0);
            labelPlayer.ForeColor = Color.White;
            labelAreaTalk.BackColor = Color.FromArgb(120, 0, 0, 0);
            labelAreaTalk.ForeColor = Color.White;
            labelTimer.Parent = panelGame;
            panelGame.Visible = false;
            panelTalkArea.Visible = false;
            labelSkip.Visible = false;

            panelPaused.Visible = false;
            panelPaused.BackColor = Color.FromArgb(180, 0, 0, 0);
            labelPaused.ForeColor = Color.White;
            labelPaused.BackColor = Color.FromArgb(120, 0, 0, 0);
            labelPaused.Font = new Font("Garamond", 20, FontStyle.Bold);
            labelPaused.Location = new Point(this.ClientSize.Width / 2 - (labelPaused.Size.Width / 2), this.ClientSize.Height / 2 - (labelPaused.Size.Height));

            panelCredits.Visible = false;
            panelHelp.Visible = false;
            #endregion

            // Lock the startup button 
            startToolStripMenuItem.Text = "Connecting to Trivia Servers...";
            startToolStripMenuItem.Enabled = false;
            pauseToolStripMenuItem.Enabled = false;
            timerTime.Interval = 1000;

            this.KeyPreview = true;
            this.DoubleBuffered = true;
            this.BackgroundImage = Properties.Resources.Finder_Quest;

            time = new Time(0, 0, 0);
            timePlayed = new Time(0, 0, 0); // timer to keep tracked of playtime
            player = new Player(new Size(110, 110), timePlayed, 10, this.ClientSize.Height / 2, "DarkLord");
            player.IsVisible = false;

            sound.PlaySound("main-menu");

            // Wait until all 7 calls finish downloading
            await game.InitializeAllQuestionsAsync();

            // Unlock start menu
            startToolStripMenuItem.Text = "Start Game";
            startToolStripMenuItem.Enabled = true;

            timerGame.Start();
            AnimateMainMenu();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void skinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSkins form = new FormSkins();
            form.Owner = this;
            form.ShowDialog();

            //
            sound.PlaySound("main-menu");
        }
        #endregion

        #region gameplay loop controllers
        private async void timerTime_Tick(object sender, EventArgs e)
        {
            if(time.Second >= 1)
            {
                time.AddWithSecond(-1);
                timePlayed.AddWithSecond(1); //updates playtime every second
            } 
            else if(time.Minute != 0 && time.Hour == 0)
            {
                time.AddWithSecond(-1);
                timePlayed.AddWithSecond(1);
            }

            labelTimer.Text = time.DisplayData();
            labelPlayer.Text = player.DisplayData(); //updates player label every second

            if (enterTalkArea)
            {
                labelTimerTalk.Text = time.DisplayData();
            }

            if (time.Hour == 0 && time.Minute == 0 && time.Second == 0 && gameStarted)
            {
                if(this.form != null)
                {
                    this.form.Close();
                    talkArea.ExitTalkArea(this);
                }
                if(game.CurrTalkArea != null)
                {
                    talkArea.ExitTalkArea(this);
                }
                timerTime.Stop();
                sound.PlaySound("lose");
                sound.PlaySFX("LoseTaunt");
                skip = new CancellationTokenSource();
                await cutscene.PlayBadEnding(this, pauseToolStripMenuItem, startToolStripMenuItem, labelCutscene, labelSkip, skip.Token);
            }
        }

        // game over & start game
        private void GameOver()
        {
            timerTime.Stop();
            panelGame.Visible = false;
            startToolStripMenuItem.Enabled = true;
            creditsToolStripMenuItem.Enabled = true;
            skinsToolStripMenuItem.Enabled = true;
            helpToolStripMenuItem.Enabled = true;
            gameStarted = false;
            enterTalkArea = false;
            inCutscene = false;
            startToolStripMenuItem.Text = "Start new game";
            this.BackgroundImage = Properties.Resources.Finder_Quest;

            if (game.CurrWalkArea != null)
            {
                game.CurrWalkArea.RemovePeople();
            }

            game.CurrWalkArea = null;
            game.CurrTalkArea = null;
            this.BackgroundImage = Properties.Resources.Finder_Quest;
            AnimateMainMenu();

            game.BossQuestionNum = 0;
            player.IsVisible = true;
            labelPaused.Visible = false;
            panelPaused.Visible = false;

            paused = true;
            pauseToolStripMenuItem.PerformClick();
            paused = false;

            time.ResetTimer();
        }

        private void StartGame()
        {
            panelGame.Visible = true;
            paused = false;
            player.IsVisible = true;

            pauseToolStripMenuItem.Enabled = true;
            creditsToolStripMenuItem.Enabled = false;
            helpToolStripMenuItem.Enabled = false;
            skinsToolStripMenuItem .Enabled = false;
            startToolStripMenuItem.Text = "Stop Game";
            gameStarted = true;
            pauseToolStripMenuItem.Text = "Pause Game";

            time.AddWithSecond(10);
            labelTimer.Text = time.DisplayData();
            timerTime.Start();

            AnimatePlayer();
            labelPlayer.Text = player.DisplayData();

            if (game.CurrWalkArea != null)
            {
                game.CurrWalkArea.RemovePeople();
            }
            game.CurrWalkArea = null;
            walkArea.GenerateWalkArea(this,labelArea);

            this.Invalidate();
        }

        //start & pause
        private async void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                timerGame.Start();
                skip = new CancellationTokenSource();
                creditsToolStripMenuItem.Enabled = false;
                helpToolStripMenuItem.Enabled = false;
                skinsToolStripMenuItem.Enabled = false;
                await cutscene.PlayOpeningCutscene(this, startToolStripMenuItem, pauseToolStripMenuItem, labelCutscene, labelSkip, skip.Token);
                StartGame();
            }
            else
            {
                GameOver();
                sound.PlaySound("main-menu");
            }
        }
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (paused) //continue game
            {
                pauseToolStripMenuItem.Text = "Pause";
                paused = false;
                timerTime.Start();
                timerGame.Start();
                sound.ResumeMusic();
                panelPaused.Visible = false;
                panelPaused.SendToBack();
            }
            else //pause game
            {
                pauseToolStripMenuItem.Text = "Continue";
                paused = true;
                timerTime.Stop();
                timerGame.Stop();
                sound.PauseMusic();
                panelPaused.Visible = true;
                panelPaused.BringToFront();
                labelPaused.Visible = true;
                labelPaused.BringToFront();
            }
        }
        #endregion

        #region player input (Keybinds)
        private async void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            int distance = 8;

            if (!paused && !inCutscene)
            {
                if (e.KeyCode == Keys.Right && game.CurrWalkArea != null && game.CurrTalkArea == null)
                {
                    if (!game.CurrWalkArea.FinishedAllQuestions())
                    {
                        if (player.X + distance > this.Width - 100)
                        {
                            distance = 0;
                        }
                    }

                    player.MoveRight(distance);

                    if (player.CurrState != "walk-right")
                    {
                        player.SetState("walk-right");
                        AnimatePlayer();
                    }

                    if (player.X >= this.Width - 50)
                    {
                        walkArea.GenerateWalkArea(this, labelArea);
                    }
                }
                else if (e.KeyCode == Keys.Left && game.CurrWalkArea != null && game.CurrTalkArea == null)
                {
                    if (player.X - distance < 0)
                    {
                        distance = 0;
                    }

                    player.MoveLeft(distance);

                    if (player.CurrState != "walk-left")
                    {
                        player.SetState("walk-left");
                        AnimatePlayer();
                    }
                }
                else if (e.KeyCode == Keys.Enter && !blockEnterToStart) //starts game
                {
                    if (!gameStarted && !allowReturnMainMenu)
                    {
                        if (startToolStripMenuItem.Enabled)
                        {
                            timerGame.Start();
                            skip = new CancellationTokenSource();
                            creditsToolStripMenuItem.Enabled = false;
                            helpToolStripMenuItem.Enabled = false;
                            skinsToolStripMenuItem.Enabled = false;
                            await cutscene.PlayOpeningCutscene(this, startToolStripMenuItem,pauseToolStripMenuItem, labelCutscene, labelSkip, skip.Token);
                            StartGame();
                        }
                        else
                        {
                            MessageBox.Show("Still fetching questions, please wait a moment!");
                        }
                    }
                    else if (game.ActivePerson != null && !allowReturnMainMenu && !enterTalkArea)
                    {
                        if (game.ActivePerson.Solved)
                        {
                            MessageBox.Show("Question Already Solved.");
                        }
                        else
                        {
                            talkArea.EnterTalkArea(this, labelAreaTalk);
                        }
                    }
                }
                else if (e.KeyCode == Keys.Escape && enterTalkArea)
                {
                    talkArea.ExitTalkArea(this);
                }
                else if (e.KeyCode == Keys.Escape && pauseToolStripMenuItem.Enabled) //pause when not paused
                {
                    pauseToolStripMenuItem.PerformClick();
                }
                else if (e.KeyCode == Keys.Y && enterTalkArea)
                {
                    form = new FormQuestion();
                    form.Owner = this;
                    form.ShowDialog();
                }
            }
            else if (e.KeyCode == Keys.Enter && allowReturnMainMenu) //return to main menu
            {
                GameOver();
                sound.PlaySound("main-menu");
                allowReturnMainMenu = false;
                sound.Fade = 4;
            }
            else if (e.KeyCode == Keys.Enter && allowSkipCutscene)
            {
                SkipCutscene();
            }
            else if(e.KeyCode == Keys.Escape && pauseToolStripMenuItem.Enabled) //continue when paused
            {
                pauseToolStripMenuItem.PerformClick();
            }

        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (!paused)
            {
                if (e.KeyCode == Keys.Right && game.CurrWalkArea != null)
                {
                    player.SetState("idle-right");
                    AnimatePlayer();
                }
                else if (e.KeyCode == Keys.Left && game.CurrWalkArea != null)
                {
                    player.SetState("idle-left");
                    AnimatePlayer();
                }
            }
        }
        #endregion

        #region graphics engine paint drivers
        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics draw = e.Graphics;

            if (game.CurrWalkArea == null)
            {
                draw.DrawImage(this.BackgroundImage, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
            }
            else
            {
                draw.DrawImage(game.CurrWalkArea.Background, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

                foreach (Person person in game.CurrWalkArea.People)
                {
                    draw.DrawImage(person.Sprite, person.X, person.Y, person.Size.Width, person.Size.Height);
                }

                if (player.IsVisible)
                {
                    draw.DrawImage(player.Sprite, player.X, player.Y, player.Size.Width, player.Size.Height);
                }

            }
        }

        private void panelTalkArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics draw = e.Graphics;

            if (enterTalkArea && game.CurrTalkArea != null)
            {
                draw.DrawImage(game.CurrTalkArea.Background, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

                draw.DrawImage(game.ActivePerson.Sprite, game.ActivePerson.X - (game.ActivePerson.Size.Width / 2), game.ActivePerson.Y, game.ActivePerson.Size.Width, game.ActivePerson.Size.Height);
            }
        }

        private async void timerGame_Tick(object sender, EventArgs e)
        {
            if (gameStarted) //in game
            {
                if (player.Sprite != null && !paused) //update player sprite
                {
                    ImageAnimator.UpdateFrames(player.Sprite);
                }
                if (game.CurrWalkArea != null && !paused) //update NPC sprite
                {
                    foreach (Person person in game.CurrWalkArea.People)
                    {
                        ImageAnimator.UpdateFrames(person.Sprite);
                    }
                }

                if (game.CurrWalkArea != null && !enterTalkArea) //check collision
                {
                    game.CurrWalkArea.CheckTouchPerson(player, out Person collisionNPC);
                    game.ActivePerson = collisionNPC;
                }

                if (game.CurrTalkArea != null) //updates talk area
                {
                    panelTalkArea.Invalidate();
                }
                else //updates walk area
                {
                    this.Invalidate();
                }

                if (game.CurrWalkArea.AreaNum == numOfWalkArea && game.CurrWalkArea.FinishedAllQuestions() && !enterTalkArea) //check for win
                {
                    sound.PlaySound("win");
                    skip = new CancellationTokenSource();
                    await cutscene.PlayGoodEnding(this, pauseToolStripMenuItem, startToolStripMenuItem,labelCutscene, labelSkip, skip.Token);

                    FormPlayReport form = new FormPlayReport();
                    form.Owner = this;
                    form.ShowDialog();
                }
            }
            else if (!inCutscene) //main menu
            {
                ImageAnimator.UpdateFrames(this.BackgroundImage);
                this.Invalidate();
            }
            else if (inCutscene) //opening, lose, or win cutscene
            {
                ImageAnimator.UpdateFrames(this.BackgroundImage);

                if (game.CurrWalkArea != null)
                {
                    foreach (Person person in game.CurrWalkArea.People)
                    {
                        ImageAnimator.UpdateFrames(person.Sprite);
                    }
                }
                this.Invalidate();
            }
        }
        #endregion

        #region animation utilities
        private void AnimatePlayer()
        {
            if (ImageAnimator.CanAnimate(player.Sprite))
            {
                ImageAnimator.Animate(player.Sprite, (s, ev) => { });
            }
        }

        public void AnimatePerson(Person person)
        {
            if (ImageAnimator.CanAnimate(person.Sprite))
            {
                ImageAnimator.Animate(person.Sprite, (s, ev) => { });
            }
        }

        public void AnimateMainMenu()
        {
            if (ImageAnimator.CanAnimate(this.BackgroundImage))
            {
                ImageAnimator.Animate(this.BackgroundImage, (s, ev) => { });
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Leave blank to prevent Windows UI flicker anomaly
        }

        private void SkipCutscene()
        {
            if(this.skip != null)
            {
                this.skip.Cancel();
                this.skip.Dispose();
                skip = null;
            }
        }

        #endregion

        #region help page
        private void openHelpPage(int page)
        {
            var resourcemanager = Properties.Resources.ResourceManager;
            panelHelp.BackgroundImage = (Image)resourcemanager.GetObject($"help{page}");
            if(page == 1)
            {
                panelHelpBack.Enabled = false;
                panelHelpNext.Enabled = true;
            } 
            else if(page == 6)
            {
                panelHelpBack.Enabled = true;
                panelHelpNext.Enabled = false;
            }
            else
            {
                panelHelpBack.Enabled = true;
                panelHelpNext.Enabled = true;
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blockEnterToStart = true;
            openHelpPage(helpPage);
            panelHelp.Visible = true;
            panelHelp.BringToFront();
        }

        private void buttonCloseHelp_Click(object sender, EventArgs e)
        {
            helpPage = 1;
            panelHelp.Visible = false;
            panelHelp.SendToBack();
            this.ActiveControl = null;
            blockEnterToStart = false;
        }

        private void panelHelpNext_Click(object sender, EventArgs e)
        {
            helpPage++;
            openHelpPage(helpPage);
        }

        private void panelHelpBack_Click(object sender, EventArgs e)
        {
            helpPage--;
            openHelpPage(helpPage);
        }
        #endregion

        #region credits
        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelCredits.Visible = true;
            panelCredits.BringToFront();
            startToolStripMenuItem.Enabled = false;
            blockEnterToStart = true; //locks enter to start
        }

        private void buttonExitCredit_Click(object sender, EventArgs e)
        {
            panelCredits.Visible = false;
            startToolStripMenuItem.Enabled = true;
            panelCredits.SendToBack();
            blockEnterToStart = false; //allows enter to start
            this.ActiveControl = null; //allows the enter button to work again
        }
        #endregion
    }
}