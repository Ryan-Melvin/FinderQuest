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
        Time time;
        bool paused;
        int numOfWalkArea = 3;
        WalkArea currWalkArea = null;
        TalkArea currTalkArea = null;

        public Player player;

        public Person activePerson;
        Point activePersonLocation;
        bool enterTalkArea = false;
        bool gameStarted = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            labelArea.Parent = panelGame;
            labelPlayer.Parent = panelGame;
            labelTimer.Parent = panelGame;
            panelGame.Visible = false;
            panelTalkArea.Visible = false;

            pauseToolStripMenuItem.Enabled = false;
            timerTime.Interval = 1000;

            this.KeyPreview = true;
            this.DoubleBuffered = true;
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

            if(time.Hour == 0 && time.Minute == 0 && time.Second == 0)
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

            startToolStripMenuItem.Text = "Start new game";
            player.Sprite.Dispose();
            this.BackgroundImage = Properties.Resources.background;
            currWalkArea.RemovePeople();
            currWalkArea = null;
        }

        private void StartGame()
        {
            panelGame.Visible = true;
            paused = false;

            pauseToolStripMenuItem.Enabled = true;
            startToolStripMenuItem.Text = "Stop Game";
            gameStarted = true;

            pauseToolStripMenuItem.Text = "Pause Game";

            time = new Time(0, 1, 0);
            labelTimer.Text = time.DisplayData();
            timerTime.Start();

            player = new Player("John", Properties.Resources.Test_Idle_Sprite, new Size(110, 110), new Point(10, 340), time);

            labelPlayer.Text = player.DisplayData();
            player.DisplayPicture(this);

            if(currWalkArea != null) 
            {
                currWalkArea.RemovePeople();
            }
            currWalkArea = null;
            GeneratWalkArea();
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
            int distance = 30;

            if (!paused)
            {
                if (e.KeyCode == Keys.Right && currWalkArea != null)
                {
                    if (!currWalkArea.FinishedAllQuestions())
                    {
                        if (player.Sprite.Location.X + distance > this.Width - 50)
                        {
                            distance = 0;
                        }
                    }

                    player.MoveRight(distance);
                    player.SetState("walk-right");

                    if (player.Sprite.Location.X >= this.Width - 50)
                    {
                        GeneratWalkArea();
                    }
                }

                else if (e.KeyCode == Keys.Left && currWalkArea != null)
                {
                    
                    if (player.Sprite.Location.X - distance < 0)
                    {
                        distance = 0;
                    }

                    player.MoveLeft(distance);
                    player.SetState("walk-left");
                }

                else if (e.KeyCode == Keys.Enter)
                {
                    if (!gameStarted)
                    {
                        StartGame();
                    }
                    else if(currWalkArea.CheckTouchPerson(player, out Person touchPerson))
                    {
                        enterTalkArea = true;
                        activePerson = touchPerson;
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

                else if (e.KeyCode == Keys.Escape)
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
            if(player != null)
            {
                player.DisplayPicture(this);
            }
            
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (!paused)
            {
                if (e.KeyCode == Keys.Right && currWalkArea != null)
                {
                    player.SetState("idle-right");
                }

                else if (e.KeyCode == Keys.Left && currWalkArea != null)
                {
                    player.SetState("idle-left");
                    
                }
            }
        }
        private void GeneratWalkArea()
        {
            if (currWalkArea == null)
            {
                currWalkArea = new WalkArea("The Barn", Properties.Resources.walkArea1, 1);

                currWalkArea.AddPerson(1, "Anna", Properties.Resources.person1, new Size(60,90), new Point(100,350), "I Hava a question for you. Are you ready? \n");
                currWalkArea.AddPerson(2, "Andy", Properties.Resources.person2, new Size(60, 90), new Point(370, 350), "can you answer my question? Lets go! \n");
                currWalkArea.AddPerson(3, "Bobby", Properties.Resources.person3, new Size(60, 90), new Point(620, 350), "Just answer my question please..\n");
            }
            else if (currWalkArea.AreaNum == 1)
            {
                currWalkArea.RemovePeople();

                currWalkArea = new WalkArea("The Field", Properties.Resources.walkArea2, 2);

                currWalkArea.AddPerson(4, "Rima", Properties.Resources.person4, new Size(60, 90), new Point(100, 350), "I'm sure you can answer my question.\n");
                currWalkArea.AddPerson(5, "Tommy", Properties.Resources.person5, new Size(60, 90), new Point(400, 350), "You look smart, can you asnwer my question? \n");
            }
            else if (currWalkArea.AreaNum == 2)
            {
                currWalkArea.RemovePeople();

                currWalkArea = new WalkArea("The Farm", Properties.Resources.walkArea3, 3);

                currWalkArea.AddPerson(6, "Marrie", Properties.Resources.person6, new Size(60, 90), new Point(120, 350), "Answer my question carefully...\n");
                currWalkArea.AddPerson(7, "Luke", Properties.Resources.person7, new Size(60, 90), new Point(420, 350), "I have a question for you. \n");
            }

            currWalkArea.DisplayPicture(this);
            currWalkArea.DisplayPeople(this);
            labelArea.Text = currWalkArea.DisplayData();

            if(player != null)
            {
                player.Sprite.Location = new Point(0, player.Sprite.Location.Y);
            }
        }

        private void GenerateTalkArea()
        {
            if(activePerson.PersonNum == 1)
            {
                currTalkArea = new TalkArea("Anna's House", Properties.Resources.talkArea1, activePerson);
                activePerson.AddQuestion("Question", "Answer", 100);
            }
            else if(activePerson.PersonNum == 2)
            {
                currTalkArea = new TalkArea("Andy's Room", Properties.Resources.talkArea2, activePerson);
                activePerson.AddQuestion("Question", "Answer", 100);
            }
            else if (activePerson.PersonNum == 3)
            {
                currTalkArea = new TalkArea("BObby's Office", Properties.Resources.talkArea3, activePerson);
                activePerson.AddQuestion("Question", "Answer", 100);
            }
            else if (activePerson.PersonNum == 4)
            {
                currTalkArea = new TalkArea("Rina's Room", Properties.Resources.talkArea4, activePerson);
                activePerson.AddQuestion("Question", "Answer", 100);
            }
            else if (activePerson.PersonNum == 5)
            {
                currTalkArea = new TalkArea("Tommy's Place", Properties.Resources.talkArea5, activePerson);
                activePerson.AddQuestion("Question", "Answer", 100);
            }
            else if (activePerson.PersonNum == 6)
            {
                currTalkArea = new TalkArea("Marie's Place", Properties.Resources.talkArea6, activePerson);
                activePerson.AddQuestion("Question", "Answer", 100);
            }
            else if (activePerson.PersonNum == 7)
            {
                currTalkArea = new TalkArea("Luke's House", Properties.Resources.talkArea7, activePerson);
                activePerson.AddQuestion("Question", "Answer", 100);
            }
        }

        public void EnterTalkArea()
        {
            GenerateTalkArea();
            activePersonLocation = activePerson.Sprite.Location;
            player.Sprite.Visible = false;
            panelTalkArea.BackgroundImage = currTalkArea.Background;
            panelTalkArea.BringToFront();
            panelTalkArea.Visible = true;

            activePerson.Sprite.Size = new Size(200, 300);
            activePerson.Sprite.Location = new Point(300, 130);
            activePerson.DisplayPicture(panelTalkArea);

            if (activePerson.Solved)
            {
                activePerson.Dialog = "Congrats, you solved my question!";
            }

            activePerson.DisplayDialog(panelTalkArea);
        }

        public void ExitTalkArea()
        {
            player.Sprite.Visible = true;
            enterTalkArea = false;

            panelTalkArea.Visible = false;
            activePerson.Sprite.Size = new Size(60, 90);
            activePerson.Sprite.Location = activePersonLocation;
            activePerson.DisplayPicture(this);
            activePerson.RemoveDialog();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (paused)
            {
                pauseToolStripMenuItem.Text = "Pause";
                paused = false;
                timerTime.Start();
                player.Sprite.Enabled = true;
            }
            else
            {
                pauseToolStripMenuItem.Text = "Continue";
                paused = true;
                timerTime.Stop();
                player.Sprite.Enabled = false;
            }
        }
    }
}
