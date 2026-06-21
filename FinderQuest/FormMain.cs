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

        private Time time;
        private bool paused;
        private int numOfWalkArea = 8; // 8 walk areas

        public Player player;
        private bool enterTalkArea = false;
        private bool gameStarted = false;

        private int savePersonX;
        private int savePersonY;
        private Size savePersonSize;

        private int smallNPC = 100;
        private int mediumNPC = 120;
        private int bigNPC = 150;
        private int bossSize = 220;
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

            time = new Time(0, 1, 0);
            player = new Player("John", new Size(110, 110), time, 10, this.ClientSize.Height/2, "Alchemist");
            player.IsVisible = true;

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
        private void timerTime_Tick(object sender, EventArgs e)
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
                MessageBox.Show("Game Over. Time is up.");
                GameOver();
            }
        }

        private void GameOver()
        {
            timerTime.Stop();
            panelGame.Visible = false;
            startToolStripMenuItem.Enabled = true;
            gameStarted = false;
            enterTalkArea = false;
            startToolStripMenuItem.Text = "Start new game";
            player.Sprite.Dispose();
            this.BackgroundImage = Properties.Resources.background;

            if (game.CurrWalkArea != null)
            {
                game.CurrWalkArea.RemovePeople();
            }
            game.CurrWalkArea = null;
            game.CurrTalkArea = null;
            this.BackgroundImage = Properties.Resources.Finder_Quest;
            AnimateMainMenu();
        }

        private void StartGame()
        {
            panelGame.Visible = true;
            paused = false;

            pauseToolStripMenuItem.Enabled = true;
            startToolStripMenuItem.Text = "Stop Game";
            gameStarted = true;
            pauseToolStripMenuItem.Text = "Pause Game";

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
            if (!gameStarted) StartGame();
            else GameOver();
        }
        #endregion

        #region player input tracking mapping
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            int distance = 5;

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
                    if (!gameStarted)
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
                    else if (game.ActivePerson != null)
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
                game.CurrWalkArea = new WalkArea("The Needlewood", Properties.Resources.GoblinVillage_Back, 1);

                // Passes specific indexes from 2D questions matrix to each Person
                game.CurrWalkArea.AddPerson(1, "Goblin", Properties.Resources.Goblin_Idle_Left, new Size(smallNPC, smallNPC), "I Have a question for you. Are you ready? \n", (int)(100 * scaleX), this.ClientSize.Height - smallNPC, game.GetQuestion(1, 0));
                game.CurrWalkArea.AddPerson(2, "Orc", Properties.Resources.Orc_Idle_Left, new Size(mediumNPC, mediumNPC), "Can you answer my question? Let's go! \n", (int)(370 * scaleX), this.ClientSize.Height - mediumNPC, game.GetQuestion(1, 1));
                game.CurrWalkArea.AddPerson(3, "Ogre", Properties.Resources.Ogre_Idle_Left, new Size(bigNPC, bigNPC), "Just answer my question please..\n", (int)(620 * scaleX), this.ClientSize.Height - bigNPC, game.GetQuestion(1, 2));
            }
            else if (game.CurrWalkArea.AreaNum == 1)
            {
                game.CurrWalkArea.RemovePeople();
                game.CurrWalkArea = new WalkArea("Titan's Ridge", Properties.Resources.Mountain, 2);

                game.CurrWalkArea.AddPerson(4, "Rock Golem", Properties.Resources.RockGolem_Idle_Left, new Size(bigNPC, bigNPC), "I'm sure you can answer my question.\n", (int)(100 * scaleX), this.ClientSize.Height - bigNPC, game.GetQuestion(2, 0));
                game.CurrWalkArea.AddPerson(5, "Moss Golem", Properties.Resources.MossGolem_Idle_Left, new Size(bigNPC, bigNPC), "You look smart, can you answer my question? \n", (int)(400 * scaleX), this.ClientSize.Height - bigNPC, game.GetQuestion(2, 1));
            }
            else if (game.CurrWalkArea.AreaNum == 2)
            {
                game.CurrWalkArea.RemovePeople();
                game.CurrWalkArea = new WalkArea("The Zombie Outpost", Properties.Resources.walkArea3, 3);

                game.CurrWalkArea.AddPerson(6, "Zombie Stalker", Properties.Resources.person6, new Size(smallNPC, mediumNPC), "Brains... and knowledge! Answer carefully...\n", (int)(120 * scaleX), this.ClientSize.Height - mediumNPC, game.GetQuestion(3, 0));
                game.CurrWalkArea.AddPerson(7, "Zombie Spitter", Properties.Resources.person7, new Size(smallNPC, mediumNPC), "I have a riddle deep in my lungs... \n", (int)(420 * scaleX), this.ClientSize.Height - mediumNPC, game.GetQuestion(3, 1));
                game.CurrWalkArea.AddPerson(8, "Zombie Tank", Properties.Resources.Ogre_Idle_Left, new Size(bigNPC, bigNPC), "Stop right there traveler! \n", (int)(650 * scaleX), this.ClientSize.Height - bigNPC, game.GetQuestion(3, 2));
            }
            // Area 4 to 8 to be added, especially Area8 will be different (since the final boss is going to have 7 questions, Oracle.Solved needs some tinkering

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
            string roomName = game.GetTalkAreaName(game.ActivePerson.PersonNum);

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
            }
            else
            {
                pauseToolStripMenuItem.Text = "Continue";
                paused = true;
                timerTime.Stop();
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

        private void timerGame_Tick(object sender, EventArgs e)
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
                    GameOver();
                    MessageBox.Show("You Win! ");
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
        #endregion
    }
}