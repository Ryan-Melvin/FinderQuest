using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeApplication;

namespace FinderQuest
{
    public partial class FormMain : Form
    {

        Time time;
        bool paused;
        int numOfWalkArea = 3;
        WalkArea currWalkArea = null;
        TalkArea currTalkArea = null;

        public Player player;

        public Person activePerson;
        bool enterTalkArea = false;
        bool gameStarted = false;
        int savePersonX;
        int savePersonY;
        Size savePersonSize;

        private int smallNPC = 100;
        private int mediumNPC = 120;
        private int bigNPC = 150;

        public FormMain()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            typeof(Panel).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, panelTalkArea, new object[] { true });
        }


        private void FormMain_Load(object sender, EventArgs e)
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

            pauseToolStripMenuItem.Enabled = false;
            timerTime.Interval = 1000;

            this.KeyPreview = true;
            this.DoubleBuffered = true;
            this.BackgroundImage = Properties.Resources.Finder_Quest;
            time = new Time(0, 1, 0);
            player = new Player("John", new Size(110, 110), time, 10, this.ClientSize.Height - 110, "DarkLord");
            player.IsVisible = true;
            timerGame.Start();
            AnimateMainMenu();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Press arrow key to move the player. \n\nPress Enter to talk with the person. " + "\n\nPress y key to answer the question. \n\nPress Esc to exit the talk area.", "How to Play");
        }

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
            //timerGame.Stop();
            panelGame.Visible = false;
            startToolStripMenuItem.Enabled = true;
            gameStarted = false;
            enterTalkArea = false;
            startToolStripMenuItem.Text = "Start new game";
            player.Sprite.Dispose();
            this.BackgroundImage = Properties.Resources.background;
            currWalkArea.RemovePeople();
            currWalkArea = null;
            currTalkArea = null;
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

            if (currWalkArea != null)
            {
                currWalkArea.RemovePeople();
            }
            currWalkArea = null;
            GeneratWalkArea();

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
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            int distance = 5;


            if (!paused)
            {
                if (e.KeyCode == Keys.Right && currWalkArea != null && currTalkArea == null)
                {
                    if (!currWalkArea.FinishedAllQuestions())
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
                        GeneratWalkArea();
                    }
                }

                else if (e.KeyCode == Keys.Left && currWalkArea != null && currTalkArea == null)
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
                        StartGame();
                        //MessageBox.Show("Width: " + this.ClientSize.Width + "\nHeight: " + this.ClientSize.Height);
                    }
                    else if (activePerson != null)
                    {
                        if (activePerson.Solved)
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
            if (player != null)
            {
                this.Invalidate();
            }

        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (!paused)
            {
                if (e.KeyCode == Keys.Right && currWalkArea != null)
                {
                    player.SetState("idle-right");
                    AnimatePlayer();
                }

                else if (e.KeyCode == Keys.Left && currWalkArea != null)
                {
                    player.SetState("idle-left");
                    AnimatePlayer();
                }
            }
        }
        private void GeneratWalkArea()
        {
            if (currWalkArea == null)
            {
                currWalkArea = new WalkArea("The Needlewood", Properties.Resources.GoblinVillage_Back, 1);

                currWalkArea.AddPerson(1, "Goblin", Properties.Resources.Goblin_Idle_Left, new Size(smallNPC, smallNPC), "I Hava a question for you. Are you ready? \n", 100, this.ClientSize.Height - smallNPC);
                currWalkArea.AddPerson(2, "Orc", Properties.Resources.Orc_Idle_Left, new Size(mediumNPC, mediumNPC), "can you answer my question? Lets go! \n", 370, this.ClientSize.Height - mediumNPC);
                currWalkArea.AddPerson(3, "Ogre", Properties.Resources.Ogre_Idle_Left, new Size(bigNPC, bigNPC), "Just answer my question please..\n", 620, this.ClientSize.Height - bigNPC);

                foreach(Person person in currWalkArea.People)
                {
                    AnimatePerson(person);
                }
            }
            else if (currWalkArea.AreaNum == 1)
            {
                currWalkArea.RemovePeople();

                currWalkArea = new WalkArea("Titan's Ridge", Properties.Resources.Mountain, 2);

                currWalkArea.AddPerson(4, "Rock Golem", Properties.Resources.RockGolem_Idle_Left, new Size(bigNPC, bigNPC), "I'm sure you can answer my question.\n", 100, this.ClientSize.Height - bigNPC);
                currWalkArea.AddPerson(5, "Moss Golem", Properties.Resources.MossGolem_Idle_Left, new Size(bigNPC, bigNPC), "You look smart, can you asnwer my question? \n", 400, this.ClientSize.Height - bigNPC);

                foreach (Person person in currWalkArea.People)
                {
                    AnimatePerson(person);
                }
            }
            else if (currWalkArea.AreaNum == 2)
            {
                currWalkArea.RemovePeople();

                currWalkArea = new WalkArea("The Farm", Properties.Resources.walkArea3, 3);

                currWalkArea.AddPerson(6, "Marrie", Properties.Resources.person6, new Size(60, 90), "Answer my question carefully...\n", 120, 350);
                currWalkArea.AddPerson(7, "Luke", Properties.Resources.person7, new Size(60, 90), "I have a question for you. \n", 420, 350);
            }

            currWalkArea.DisplayPicture(this);
            //currWalkArea.DisplayPeople(this);

            labelArea.Text = currWalkArea.DisplayData();
           

            if (player != null)
            {
                //player.Sprite.Location = new Point(0, player.Sprite.Location.Y);
                player.X = 0;
            }
        }

        private void GenerateTalkArea()
        {
            if (activePerson.PersonNum == 1)
            {
                currTalkArea = new TalkArea("The Forest", this.BackgroundImage, activePerson);
                activePerson.AddQuestion("Question", "a", 100);
            }
            else if (activePerson.PersonNum == 2)
            {
                currTalkArea = new TalkArea("The Forest", this.BackgroundImage, activePerson);
                activePerson.AddQuestion("Question", "A", 100);
            }
            else if (activePerson.PersonNum == 3)
            {
                currTalkArea = new TalkArea("The Forest", this.BackgroundImage, activePerson);
                activePerson.AddQuestion("Question", "a", 100);
            }
            else if (activePerson.PersonNum == 4)
            {
                currTalkArea = new TalkArea("Mountains", this.BackgroundImage, activePerson);
                activePerson.AddQuestion("Question", "a", 100);
            }
            else if (activePerson.PersonNum == 5)
            {
                currTalkArea = new TalkArea("Mountains", this.BackgroundImage, activePerson);
                activePerson.AddQuestion("Question", "A", 100);
            }
            else if (activePerson.PersonNum == 6)
            {
                currTalkArea = new TalkArea("Marie's Place", this.BackgroundImage, activePerson);
                activePerson.AddQuestion("Question", "a", 100);
            }
            else if (activePerson.PersonNum == 7)
            {
                currTalkArea = new TalkArea("Luke's House", this.BackgroundImage, activePerson);
                activePerson.AddQuestion("Question", "a", 100);
            }

  
            labelAreaTalk.Text = currTalkArea.DisplayData();
            labelAreaTalk.Location = new Point(10, panelTalkArea.Height - labelAreaTalk.Size.Height - 10);
            
        }

        public void EnterTalkArea()
        {
            GenerateTalkArea();
            savePersonX = activePerson.X;
            savePersonY = activePerson.Y;
            savePersonSize = activePerson.Size;

            player.IsVisible = false;
            //panelTalkArea.BackgroundImage = currTalkArea.Background;
            panelTalkArea.BringToFront();
            panelTalkArea.Visible = true;

            activePerson.Size = new Size(mediumNPC * 2, mediumNPC * 2);
            activePerson.X = panelTalkArea.ClientSize.Width / 2;
            activePerson.Y = panelTalkArea.ClientSize.Height - mediumNPC;
            //activePerson.Sprite.Location = new Point(300, 130);
            //activePerson.DisplayPicture(panelTalkArea);

            enterTalkArea = true;
            

            if (activePerson.Solved)
            {
                activePerson.Dialog = "Congrats, you solved my question!";
            }

            activePerson.DisplayDialog(panelTalkArea);
        }

        public void ExitTalkArea()
        {
            player.IsVisible = true;
            enterTalkArea = false;

            panelTalkArea.Visible = false;
            activePerson.Size = savePersonSize;
            activePerson.X = savePersonX;
            activePerson.Y = savePersonY;
            
            //activePerson.Sprite.Location = activePersonLocation;
            //activePerson.DisplayPicture(this);
            activePerson.RemoveDialog();
            currTalkArea = null;
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (paused)
            {
                pauseToolStripMenuItem.Text = "Pause";
                paused = false;
                timerTime.Start();
                //player.Sprite.Enabled = true;
            }
            else
            {
                pauseToolStripMenuItem.Text = "Continue";
                paused = true;
                timerTime.Stop();
                //player.Sprite.Enabled = false;
            }
        }

       
        
        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics draw = e.Graphics;

            if (currWalkArea == null)
            {
                draw.DrawImage(this.BackgroundImage, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
            }

            else
            {
                draw.DrawImage(currWalkArea.Background, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

                foreach (Person person in currWalkArea.People)
                {
                    draw.DrawImage(person.Sprite, person.X, person.Y, person.Size.Width, person.Size.Height);
                }

                if (player.IsVisible)
                {
                    draw.DrawImage(player.Sprite, player.X, player.Y, player.Size.Width, player.Size.Height);
                }
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
                if (currWalkArea != null && !paused)
                {
                    foreach (Person person in currWalkArea.People)
                    {
                        ImageAnimator.UpdateFrames(person.Sprite);
                    }
                }

                if (currWalkArea != null && !enterTalkArea)
                {
                    currWalkArea.CheckTouchPerson(player, out activePerson);
                }

                if (currTalkArea != null)
                {
                    panelTalkArea.Invalidate();
                }
                this.Invalidate();

                if (currWalkArea.AreaNum == numOfWalkArea && currWalkArea.FinishedAllQuestions() && !enterTalkArea)
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

        //private void OnFrameChanged(object sender, EventArgs e)
        //{
        //}

        private void AnimatePlayer()
        {
            if (ImageAnimator.CanAnimate(player.Sprite))
            {
                ImageAnimator.Animate(player.Sprite, (s, e) => { });
            }
        }

        private void AnimatePerson(Person person)
        {
            if (ImageAnimator.CanAnimate(person.Sprite))
            {
                ImageAnimator.Animate(person.Sprite, (s, e) => { });
            }
        }

        private void AnimateMainMenu()
        {
            if (ImageAnimator.CanAnimate(this.BackgroundImage))
            {
                ImageAnimator.Animate(this.BackgroundImage, (s, e) => { });
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        private void panelTalkArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics draw = e.Graphics;

            if (enterTalkArea)
            {
                draw.DrawImage(currTalkArea.Background, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
                draw.DrawImage(activePerson.Sprite, 300, 120, activePerson.Size.Width, activePerson.Size.Height);
            }
        }
    }
}
