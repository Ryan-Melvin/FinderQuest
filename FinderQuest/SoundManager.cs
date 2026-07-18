using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace FinderQuest
{
    public class SoundManager
    {
        #region fields
        private WindowsMediaPlayer player1 = new WindowsMediaPlayer();
        private WindowsMediaPlayer player2 = new WindowsMediaPlayer();
        private WindowsMediaPlayer activePlayer;
        private WindowsMediaPlayer fadingPlayer;
        private Timer fadeTimer;
        private int fade = 4;
        private int targetMusicVolume = 100;

        private WindowsMediaPlayer SFX = new WindowsMediaPlayer();
        #endregion

        #region constructors
        public SoundManager()
        {
            player1.settings.volume = 0;
            player2.settings.volume = 0;
            player1.settings.setMode("loop", true);
            player2.settings.setMode("loop", true);

            fadeTimer = new Timer();
            fadeTimer.Interval = 30;
            fadeTimer.Tick += FadeTimer_Tick; //adds the method to fadeTimer.Tick

            activePlayer = player1; //media player
        }
        #endregion

        #region properties
        public WindowsMediaPlayer Player1 { get => player1; set => player1 = value; }
        public WindowsMediaPlayer Player2 { get => player2; set => player2 = value; }
        public WindowsMediaPlayer ActivePlayer { get => activePlayer; set => activePlayer = value; }
        public WindowsMediaPlayer FadingPlayer { get => fadingPlayer; set => fadingPlayer = value; }
        public Timer FadeTimer { get => fadeTimer; set => fadeTimer = value; }
        public int Fade { get => fade; set => fade = value; }
        public WindowsMediaPlayer SFX1 { get => SFX; set => SFX = value; }
        public int TargetMusicVolume { get => targetMusicVolume; set => targetMusicVolume = value; }
        #endregion

        #region methods
        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            bool completeFadeIn = false;
            bool completeFadeOut = false;

            if (ActivePlayer.settings.volume < targetMusicVolume)
            {
                ActivePlayer.settings.volume = Math.Min(targetMusicVolume, ActivePlayer.settings.volume + Fade);
            }
            else
            {
                completeFadeIn = true;
            }

            if (FadingPlayer != null)
            {
                if (FadingPlayer.settings.volume > 0)
                {
                    fadingPlayer.settings.volume = Math.Max(0, FadingPlayer.settings.volume - Fade);
                }
                else
                {
                    FadingPlayer.controls.stop();
                    FadingPlayer = null;
                    completeFadeOut = true;
                }
            }
            else
            {
                completeFadeOut = true;
            }

            if (completeFadeIn && completeFadeOut)
            {
                FadeTimer.Stop();
            }
        }
        public void PlaySound(string soundName) //sound player
        {
            string fileName = "";
            if (soundName == "main-menu")
            {
                fileName = Application.StartupPath + "\\Sounds\\MusicMainMenu.mp3";
                targetMusicVolume = 100;
            }
            else if (soundName == "area1")
            {
                fileName = Application.StartupPath + "\\Sounds\\MusicArea1.mp3";
                targetMusicVolume = 40;
            }
            else if (soundName == "area2")
            {
                fileName = Application.StartupPath + "\\Sounds\\MusicArea2.mp3";
                targetMusicVolume = 60;
            }
            else if (soundName == "area3")
            {
                fileName = Application.StartupPath + "\\Sounds\\MusicArea3.mp3";
                targetMusicVolume = 50;
            }
            else if (soundName == "area4")
            {
                fileName = Application.StartupPath + "\\Sounds\\MusicArea4.mp3";
                targetMusicVolume = 60;
            }
            else if (soundName == "area5")
            {
                fileName = Application.StartupPath + "\\Sounds\\MusicArea5.mp3";
                targetMusicVolume = 65;
            }
            else if (soundName == "area6")
            {
                fileName = Application.StartupPath + "\\Sounds\\MusicArea6.mp3";
                targetMusicVolume = 100;
            }
            else if (soundName == "area7")
            {
                fileName = Application.StartupPath + "\\Sounds\\MusicArea7.mp3";
                targetMusicVolume = 90;
            }
            else if (soundName == "area8-Ambient")
            {
                fileName = Application.StartupPath + "\\Sounds\\MusicArea8Sanctum.mp3";
                targetMusicVolume = 40;
            }
            else if (soundName == "area8-Battle")
            {
                fileName = Application.StartupPath + "\\Sounds\\MusicArea8Battle.mp3";
                targetMusicVolume = 65;
            }
            else if (soundName == "lose")
            {
                fileName = Application.StartupPath + "\\Sounds\\MusicEndingLose.mp3";
                targetMusicVolume = 100;
            }
            else if (soundName == "win")
            {
                fileName = Application.StartupPath + "\\Sounds\\MusicEndingWin.mp3";
                targetMusicVolume = 100;
            }
            else if (soundName == "opening")
            {
                fileName = Application.StartupPath + "\\Sounds\\Opening.mp3";
                targetMusicVolume = 60;
            }
            else if (soundName == "skin-shop")
            {
                fileName = Application.StartupPath + "\\Sounds\\SkinShop.mp3";
                targetMusicVolume = 60;
            }
            else if (soundName == "profile")
            {
                fileName = Application.StartupPath + "\\Sounds\\Profile.mp3";
                targetMusicVolume = 60;
            }

            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }

            if (ActivePlayer.URL == fileName)
            {
                return;
            }

            FadingPlayer = ActivePlayer;

            ActivePlayer = (ActivePlayer == Player1) ? Player2 : Player1;

            ActivePlayer.URL = fileName;
            ActivePlayer.settings.volume = 0;
            ActivePlayer.controls.play();

            FadeTimer.Start();
        }

        public void PlaySFX(string soundName)
        {
            string url = Application.StartupPath + "\\Sounds\\SoundEffects\\" + soundName + ".mp3";

            SFX1.URL = url;
            SFX1.settings.volume = 90;

            SFX1.controls.play();
        }

        public void SetSFXVolume(int volume)
        {
            this.SFX1.settings.volume = volume;
        }

        public void ResumeMusic()
        {
            this.ActivePlayer.controls.play();
        }

        public void PauseMusic()
        {
            this.ActivePlayer.controls.pause();
        }
        #endregion
    }
}