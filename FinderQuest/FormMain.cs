using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeApplication;

namespace FinderQuest
{
    public partial class FormMain : Form
    {
        #region fields
        public GameManager game = new GameManager(); // Centralized game manager that handles logic

        public Time time; 
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
        #endregion

        #region constructor
        public FormMain()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            typeof(Panel).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, panelTalkArea, new object[] { true });
        }
        #endregion

        #region form lifecycle events
        // Change to async function (pull trivia items immediately at Form Load)
        private async void FormMain_Load(object sender, EventArgs e)
        {
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


            // Lock the startup button 
            startToolStripMenuItem.Text = "Connecting to Trivia Servers...";
            startToolStripMenuItem.Enabled = false;
            pauseToolStripMenuItem.Enabled = false;
            timerTime.Interval = 1000;

            this.KeyPreview = true;
            this.DoubleBuffered = true;
            this.BackgroundImage = Properties.Resources.Finder_Quest;

            time = new Time(0, 0, 0);
            player = new Player("John", new Size(110, 110), time, 10, this.ClientSize.Height/2, "Pyromancer");
            player.IsVisible = true;

            game.PlaySound("main-menu");

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

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Press arrow key to move the player. \n\nPress Enter to talk with the person. \n\nPress y key to answer the question. \n\nPress Esc to exit the talk area.", "How to Play");
        }
        #endregion

        #region gameplay loop controllers
        private async void timerTime_Tick(object sender, EventArgs e)
        {
            time.AddWithSecond(-1);
            labelTimer.Text = time.DisplayData();

            if (enterTalkArea)
            {
                labelTimerTalk.Text = time.DisplayData();
            }

            if (time.Hour == 0 && time.Minute == 0 && time.Second == 0)
            {
                timerTime.Stop();
                //GameOver();
                game.PlaySound("lose");
                //DialogResult result = MessageBox.Show("Game Over. Time is up.");
                //if(result == DialogResult.OK)
                //{
                //    game.PlaySound("main-menu");
                //}
                await PlayBadEnding();
            }
        }

        private void GameOver()
        {
            timerTime.Stop();
            time.ResetTimer();
            panelGame.Visible = false;
            startToolStripMenuItem.Enabled = true;
            gameStarted = false;
            enterTalkArea = false;
            startToolStripMenuItem.Text = "Start new game";
            //player.Sprite.Dispose(); we no longer dispose the player spirte, we just tell paint to not draw it via setting currArea to null
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
        }

        private void StartGame()
        {
            panelGame.Visible = true;
            paused = false;

            pauseToolStripMenuItem.Enabled = true;
            startToolStripMenuItem.Text = "Stop Game";
            gameStarted = true;
            pauseToolStripMenuItem.Text = "Pause Game";

            time.AddWithSecond(60);
            labelTimer.Text = time.DisplayData();
            timerTime.Start();
            timerGame.Start();

            AnimatePlayer();
            labelPlayer.Text = player.DisplayData();

            if (game.CurrWalkArea != null)
            {
                game.CurrWalkArea.RemovePeople();
            }
            game.CurrWalkArea = null;
            GenerateWalkArea();

            this.Invalidate();         
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                StartGame();
            }
            else
            {
                GameOver();
                game.PlaySound("main-menu");
            }
        }
        #endregion

        #region player input tracking mapping
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            int distance = 8;

            if (!paused)
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
                        GenerateWalkArea();
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
                else if (e.KeyCode == Keys.Enter)
                {
                    if (!gameStarted && !allowReturnMainMenu)
                    {
                        if (startToolStripMenuItem.Enabled)
                        {
                            StartGame();
                        }
                        else
                        {
                            MessageBox.Show("Still fetching questions, please wait a moment!");
                        }
                    }
                    else if (game.ActivePerson != null && !allowReturnMainMenu)
                    {
                        if (game.ActivePerson.Solved)
                        {
                            MessageBox.Show("Question Already Solved.");
                        }
                        else
                        {
                            EnterTalkArea();
                        }
                    }
                    else if (allowReturnMainMenu)
                    {
                        GameOver();
                        game.PlaySound("main-menu");
                        allowReturnMainMenu = false;
                        game.Fade = 4;
                    }
                }
                else if (e.KeyCode == Keys.Escape && enterTalkArea)
                {
                    ExitTalkArea();
                }
                else if (e.KeyCode == Keys.Y && enterTalkArea)
                {
                    FormQuestion form = new FormQuestion();
                    form.Owner = this;
                    form.ShowDialog();
                }
            }
            //if (player != null)
            //{
            //    this.Invalidate();
            //}

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

        #region world engine level generators
        private void GenerateWalkArea()
        {
            double scaleX = (double)this.ClientSize.Width / 800.0;

            // First run
            if (game.CurrWalkArea == null)
            {
                game.CurrWalkArea = new WalkArea("The Needlewood", Properties.Resources.GoblinForest, 1);
                game.PlaySound("area1");

                // Passes specific indexes from 2D questions matrix to each Person
                game.CurrWalkArea.AddPerson(1, "Goblin", Properties.Resources.Goblin_Idle_Left, new Size(smallNPC, smallNPC), "One little lie, and I call the whole pack. And we're hungry today...\n", (int)(100 * scaleX), this.ClientSize.Height / 2, game.GetQuestion(1, 0));
                game.CurrWalkArea.AddPerson(2, "Orc", Properties.Resources.Orc_Idle_Left, new Size(mediumNPC, mediumNPC), "Tick-tock, the trap is unlocked! Give us the right answer, or enjoy the drop.\n", (int)(370 * scaleX), this.ClientSize.Height / 2 - (mediumNPC - player.Size.Height), game.GetQuestion(1, 1));
                game.CurrWalkArea.AddPerson(3, "Ogre", Properties.Resources.Ogre_Idle_Left, new Size(bigNPC, bigNPC), "You better answer my question correctly..\n", (int)(620 * scaleX), this.ClientSize.Height / 2 - (bigNPC - player.Size.Height), game.GetQuestion(1, 2));
            }
            else if (game.CurrWalkArea.AreaNum == 7)
            {
                game.CurrWalkArea.RemovePeople();
                game.CurrWalkArea = new WalkArea("Titan's Ridge", Properties.Resources.GolemLands, 2);
                game.PlaySound("area2");

                game.CurrWalkArea.AddPerson(4, "Rock Golem", Properties.Resources.RockGolem_Idle_Left, new Size(bigNPC, bigNPC), "Who woke me up from my sleep?\n", (int)(100 * scaleX), this.ClientSize.Height / 2 - (bigNPC - player.Size.Height), game.GetQuestion(2, 0));
                game.CurrWalkArea.AddPerson(5, "Moss Golem", Properties.Resources.MossGolem_Idle_Left, new Size(bigNPC, bigNPC), "You shall pay for waking me up! \n", (int)(400 * scaleX), this.ClientSize.Height / 2 - (bigNPC - player.Size.Height), game.GetQuestion(2, 1));
            }
            else if (game.CurrWalkArea.AreaNum == 2)
            {
                game.CurrWalkArea.RemovePeople();
                game.CurrWalkArea = new WalkArea("The Zombie Outpost", Properties.Resources.AbandonedVillage, 3);
                game.PlaySound("area3");

                game.CurrWalkArea.AddPerson(6, "Zombie Stalker", Properties.Resources.Zombie_Idle_Left, new Size(smallNPC, smallNPC), "Brains... and knowledge! Answer carefully...\n", (int)(120 * scaleX), this.ClientSize.Height / 2, game.GetQuestion(3, 0));
                game.CurrWalkArea.AddPerson(7, "Zombie Spitter", Properties.Resources.ZombieVillager_Idle_Left, new Size(smallNPC, smallNPC), "I have a riddle deep in my lungs... \n", (int)(420 * scaleX), this.ClientSize.Height / 2, game.GetQuestion(3, 1));
                game.CurrWalkArea.AddPerson(8, "Zombie Tank", Properties.Resources.Husk_Idle_Left, new Size(bigNPC, bigNPC), "Stop right there traveler! \n", (int)(650 * scaleX), this.ClientSize.Height / 2 - (bigNPC - player.Size.Height), game.GetQuestion(3, 2));
            }
            else if (game.CurrWalkArea.AreaNum == 3)
            {
                game.CurrWalkArea.RemovePeople();
                game.CurrWalkArea = new WalkArea("The Minotaur's Terrace", Properties.Resources.MinotaurTerrace, 4);
                game.PlaySound("area4");

                game.CurrWalkArea.AddPerson(9, "Minotaur", Properties.Resources.Minotaur_Idle_Left, new Size(mediumNPC, mediumNPC), "Myths... and memory! Answer carefully...\n", (int)(100 * scaleX), this.ClientSize.Height / 2 - (mediumNPC - player.Size.Height), game.GetQuestion(4, 0));
                game.CurrWalkArea.AddPerson(10, "Taurus", Properties.Resources.Taurus_Idle_Left, new Size(mediumNPC, mediumNPC), "Axes... and arts! Answer carefully...\n", (int)(370 * scaleX), this.ClientSize.Height / 2 - (mediumNPC - player.Size.Height), game.GetQuestion(4, 1));
                game.CurrWalkArea.AddPerson(11, "Lost Bull", Properties.Resources.LostBull_Idle_Left, new Size(bigNPC, bigNPC), "I'm the boss here, you shall not pass! \n", (int)(620 * scaleX), this.ClientSize.Height / 2 - (bigNPC - player.Size.Height), game.GetQuestion(4, 2));
            }
            else if (game.CurrWalkArea.AreaNum == 4)
            {
                game.CurrWalkArea.RemovePeople();
                game.CurrWalkArea = new WalkArea("The Crypt of Skeletons", Properties.Resources.Graveyard, 5);
                game.PlaySound("area5");

                game.CurrWalkArea.AddPerson(12, "Larry", Properties.Resources.LarrryTheSkeleton_Idle_Left, new Size(smallNPC, smallNPC), "Marrow... and mind! Think before you speak...\n", (int)(100 * scaleX), this.ClientSize.Height / 2, game.GetQuestion(5, 0));
                game.CurrWalkArea.AddPerson(13, "Skeleton Guard", Properties.Resources.SkeletonGuard_Idle_Left, new Size(smallNPC, smallNPC), "Dust to dust, bone to bone.. give me an answer, or be left alone.\n", (int)(370 * scaleX), this.ClientSize.Height / 2, game.GetQuestion(5, 1));
                game.CurrWalkArea.AddPerson(14, "Skeleton Warrior", Properties.Resources.SkeletonWarrior_Idle_Left, new Size(smallNPC, smallNPC), "The grave forgets nothing. Tread lightly with your words.\n", (int)(620 * scaleX), this.ClientSize.Height / 2, game.GetQuestion(5, 2));
            }
            else if (game.CurrWalkArea.AreaNum == 5)
            {
                game.CurrWalkArea.RemovePeople();
                game.CurrWalkArea = new WalkArea("The Necromancer Tower", Properties.Resources.CastleEntrance, 6);
                game.PlaySound("area6");

                game.CurrWalkArea.AddPerson(15, "Necromancer", Properties.Resources.Necro_Idle_Left, new Size(mediumNPC, mediumNPC), "Your soul is a fragile thread. Do not make me snip it...\n", (int)(120 * scaleX), this.ClientSize.Height / 2 - (mediumNPC - player.Size.Height), game.GetQuestion(6, 0));
                game.CurrWalkArea.AddPerson(16, "Soul Snatcher", Properties.Resources.NecroLady_Idle_Left, new Size(mediumNPC, mediumNPC), "Your heartbeat is a rhythm I can easily stop. Think before you answer.\n", (int)(420 * scaleX), this.ClientSize.Height / 2 - (mediumNPC - player.Size.Height), game.GetQuestion(6, 1));
            }
            else if (game.CurrWalkArea.AreaNum == 6)
            {
                game.CurrWalkArea.RemovePeople();
                game.CurrWalkArea = new WalkArea("Reaper's Domain", Properties.Resources.ReaperHallway, 7);
                game.PlaySound("area7");

                game.CurrWalkArea.AddPerson(17, "Grim", Properties.Resources.Reaper_Idle_Left, new Size(mediumNPC, mediumNPC), "Pulse and data! Both are so easily measured and stopped. Answer me.\n", (int)(120 * scaleX), this.ClientSize.Height / 2 - (mediumNPC - player.Size.Height), game.GetQuestion(7, 0));
                game.CurrWalkArea.AddPerson(18, "Azrael", Properties.Resources.DeathReaper_Idle_Left, new Size(mediumNPC, mediumNPC), "I do not just kill, I keep.\n", (int)(420 * scaleX), this.ClientSize.Height / 2 - (mediumNPC - player.Size.Height), game.GetQuestion(7, 1));
            }
            else if (game.CurrWalkArea.AreaNum == 1) 
            {
                game.CurrWalkArea.RemovePeople();
                game.CurrWalkArea = new WalkArea("The Oracle's Sanctum", Properties.Resources.throne_room, 8);
                game.PlaySound("area8-Ambient");

                game.CurrWalkArea.AddPerson(19, "The Oracle", Properties.Resources.DarkApprentice_Idle_Left, new Size(bossSize, bossSize), "This is the final test, you will fail..\n", (int)(420 * scaleX), this.ClientSize.Height / 2 - (bossSize - player.Size.Height - 20), game.GetOracleQuestions());
            }

            foreach (Person person in game.CurrWalkArea.People)
            {
                AnimatePerson(person);
            }

            game.CurrWalkArea.DisplayPicture(this);
            labelArea.Text = game.CurrWalkArea.DisplayData();

            if (player != null)
            {
                player.X = 0;
            }
        }

        private void GenerateTalkArea()
        {
            string roomName = game.GetTalkAreaName(game.CurrWalkArea.AreaNum);

            game.CurrTalkArea = new TalkArea(roomName, this.BackgroundImage, game.ActivePerson);

            labelAreaTalk.Text = game.CurrTalkArea.DisplayData();
            labelAreaTalk.Location = new Point(10, panelTalkArea.Height - labelAreaTalk.Size.Height - 10);
        }

        public void EnterTalkArea()
        {
            GenerateTalkArea();
            savePersonX = game.ActivePerson.X;
            savePersonY = game.ActivePerson.Y;
            savePersonSize = game.ActivePerson.Size;

            player.IsVisible = false;
            panelTalkArea.BringToFront();
            panelTalkArea.Visible = true;

            game.ActivePerson.Size = new Size(mediumNPC * 2, mediumNPC * 2);
            game.ActivePerson.X = panelTalkArea.ClientSize.Width / 2;
            game.ActivePerson.Y = panelTalkArea.ClientSize.Height - (mediumNPC * 2);

            enterTalkArea = true;

            if (game.ActivePerson.Solved)
            {
                game.ActivePerson.Dialog = "Congrats, you solved my question!";
            }

            game.ActivePerson.DisplayDialog(panelTalkArea);
        }

        public void ExitTalkArea()
        {
            player.IsVisible = true;
            enterTalkArea = false;

            panelTalkArea.Visible = false;
            game.ActivePerson.Size = savePersonSize;
            game.ActivePerson.X = savePersonX;
            game.ActivePerson.Y = savePersonY;

            game.ActivePerson.RemoveDialog();
            game.CurrTalkArea = null;

        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (paused)
            {
                pauseToolStripMenuItem.Text = "Pause";
                paused = false;
                timerTime.Start();
                game.ResumeMusic();
            }
            else
            {
                pauseToolStripMenuItem.Text = "Continue";
                paused = true;
                timerTime.Stop();
                game.PauseMusic();
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
            if (gameStarted)
            {
                if (player.Sprite != null && !paused)
                {
                    ImageAnimator.UpdateFrames(player.Sprite);
                }
                if (game.CurrWalkArea != null && !paused)
                {
                    foreach (Person person in game.CurrWalkArea.People)
                    {
                        ImageAnimator.UpdateFrames(person.Sprite);
                    }
                }

                if (game.CurrWalkArea != null && !enterTalkArea)
                {
                    game.CurrWalkArea.CheckTouchPerson(player, out Person collisionNPC);
                    game.ActivePerson = collisionNPC;
                }

                if (game.CurrTalkArea != null)
                {
                    panelTalkArea.Invalidate();
                }
                this.Invalidate();

                if (game.CurrWalkArea.AreaNum == numOfWalkArea && game.CurrWalkArea.FinishedAllQuestions() && !enterTalkArea)
                {
                    //GameOver();
                    game.PlaySound("win");
                    //DialogResult result = MessageBox.Show("You Win! ");
                    //if(result == DialogResult.OK)
                    //{
                    //    game.PlaySound("main-menu");
                    //}
                    await PlayGoodEnding();
                }
            }
            else
            {
                ImageAnimator.UpdateFrames(this.BackgroundImage);
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

        private void AnimatePerson(Person person)
        {
            if (ImageAnimator.CanAnimate(person.Sprite))
            {
                ImageAnimator.Animate(person.Sprite, (s, ev) => { });
            }
        }

        private void AnimateMainMenu()
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

        private async Task PlayGoodEnding()
        {
            game.Fade = 8;
            this.BackgroundImage = Properties.Resources.BackgroundWin;    
            this.game.CurrWalkArea.RemovePeople();
            this.game.CurrWalkArea = null;
            gameStarted = false;
            panelGame.Visible = false;

            labelCutscene.Text = "";
            labelCutscene.Parent = this;
            labelCutscene.BringToFront();
            labelCutscene.Font = new Font("Plus Jakarta Sans", 16, FontStyle.Bold);
            labelCutscene.ForeColor = Color.White;
            labelCutscene.BackColor = Color.FromArgb(180, 0, 0, 0);
            labelCutscene.TextAlign = ContentAlignment.MiddleCenter;
            labelCutscene.AutoSize = true;
            labelCutscene.MaximumSize = new Size(this.ClientSize.Width - 80, 0);

            await AnimateText("The Oracle's ancient gaze shattered into blinding fragments...");
            await Task.Delay(2500);

            await AnimateText("Warm, long-forgotten light cascaded over the valleys of the realm.");
            await Task.Delay(4000);

            await AnimateText("A broken crown rests on the altar, its curse lifted forevermore.");
            await Task.Delay(4000);
            labelCutscene.Text = "";

            this.BackgroundImage = Properties.Resources.WinTextGoIn;
            AnimateMainMenu();
            await Task.Delay(2400);
            this.BackgroundImage = Properties.Resources.WinEnterToReturn;
            AnimateMainMenu();

            allowReturnMainMenu = true;
        }

        private async Task PlayBadEnding()
        {
            game.Fade = 8;
            this.BackgroundImage = Properties.Resources.BackgroundLose;
            this.game.CurrWalkArea.RemovePeople();
            this.game.CurrWalkArea = null;
            gameStarted = false;
            panelGame.Visible = false;

            labelCutscene.Text = "";
            labelCutscene.Parent = this;
            labelCutscene.BringToFront();
            labelCutscene.Font = new Font("Plus Jakarta Sans", 16, FontStyle.Bold);
            labelCutscene.ForeColor = Color.White;
            labelCutscene.BackColor = Color.FromArgb(180, 0, 0, 0);
            labelCutscene.TextAlign = ContentAlignment.MiddleCenter;
            labelCutscene.AutoSize = true;
            labelCutscene.MaximumSize = new Size(this.ClientSize.Width - 80, 0);

            await AnimateText("The walls of the sanctuary crumbled...");
            await Task.Delay(3500);

            await AnimateText("The hero fell to their knees as darkness swallowed the throne room.");
            await Task.Delay(4000);
            labelCutscene.Text = "";

            this.BackgroundImage = Properties.Resources.GameOverTextGoIn;
            AnimateMainMenu();
            await Task.Delay(2400);
            this.BackgroundImage = Properties.Resources.GameOverEnterToReturn;
            AnimateMainMenu();

            allowReturnMainMenu = true;
        }

        private async Task AnimateText(string text)
        {
            labelCutscene.Text = "";

            foreach (char c in text)
            {
                labelCutscene.Text += c;
                labelCutscene.Location = new Point(this.ClientSize.Width / 2 - (labelCutscene.Width / 2), this.ClientSize.Height / 2 - (labelCutscene.Height / 2) + 15);

                await Task.Delay(40);
            }
        }
        #endregion
    }
}