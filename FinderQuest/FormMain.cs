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

        public Player player;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            labelArea.Visible = false;
            labelPlayer.Visible = false;
            labelTimer.Visible = false;
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
            labelTimer.Visible = false;
            labelArea.Visible = false;
            labelPlayer.Visible = false;

            startToolStripMenuItem.Enabled = true;
        }

        private void StartGame()
        {
            panelGame.Visible = true;
            labelTimer.Visible = true;
            labelPlayer.Visible= true;
            labelArea.Visible= true;

            pauseToolStripMenuItem.Enabled = true;
            startToolStripMenuItem.Enabled = false;

            pauseToolStripMenuItem.Text = "Pause Game";

            time = new Time(0, 1, 0);
            labelTimer.Text = time.DisplayData();
            timerTime.Start();

            player = new Player("John", Properties.Resources.player_right, new Size(50, 80), new Point(10, 200), time);

            labelPlayer.Text = player.DisplayData();
            player.DisplayPicture(this);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            int distance = 30;

            if(e.KeyCode == Keys.Right)
            {
                if(player.Picture.Location.X + distance > this.Width - 50)
                {
                    distance = 0;
                }

                player.MoveRight(distance);
            }

            else if(e.KeyCode == Keys.Left)
            {
                if (player.Picture.Location.X - distance < 0)
                {
                    distance = player.Picture.Location.X;
                }

                player.MoveLeft(distance);
            }

            else if(e.KeyCode == Keys.Enter)
            {

            }

            else if(e.KeyCode == Keys.Escape)
            {

            } 
            else if(e.KeyCode == Keys.Y)
            {

            }

            player.DisplayPicture(this);
        }
    }
}
