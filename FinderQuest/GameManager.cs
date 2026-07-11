using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace FinderQuest
{
    public class GameManager
    {
        #region fields
        private WalkArea currWalkArea;
        private TalkArea currTalkArea;
        private Person activePerson;

        private WindowsMediaPlayer player1 = new WindowsMediaPlayer();
        private WindowsMediaPlayer player2 = new WindowsMediaPlayer();
        private WindowsMediaPlayer activePlayer;
        private WindowsMediaPlayer fadingPlayer;
        private Timer fadeTimer;
        private int fade = 4;

        private WindowsMediaPlayer SFX = new WindowsMediaPlayer();

        private List<Question> area1Questions;
        private List<Question> area2Questions;
        private List<Question> area3Questions;
        private List<Question> area4Questions;
        private List<Question> area5Questions;
        private List<Question> area6Questions;
        private List<Question> area7Questions;
        private List<Question> area8Questions;

        // 2D matrix for assigning each Person their questions and match their respective WalkArea
        private List<Question>[] questionPools;

        private HttpClient client = new HttpClient {Timeout = TimeSpan.FromSeconds(10)};

        private int bossQuestionNum;
        #endregion

        #region lookups
        private readonly Dictionary<int, string> talkAreaNames = new Dictionary<int, string>
        {
            {1, "The Needlewood Forest"},
            {2, "Titan's Ridge Mountains"},
            {3, "The Zombie Outpost"},
            {4, "The Minotaur's Terrace"},
            {5, "The Crypt of Skeletons"},
            {6, "The Necromancer Tower"},
            {7, "The Reaper's Domain"},
            {8, "The Oracle's Sanctum"}
        };

        // API query parameters
        private string[] apiEndpoints = new string[]
        {
            "categories=food_and_drink&difficulties=easy", // Area 1: Goblin
            "tags=chemistry&difficulties=easy,medium", // Area 2: Golem
            "tags=biology&difficulties=easy,medium", // Area 3: Zombie
            "categories=arts_and_literature&difficulties=easy", // Area 4: Minotaur
            "categories=music&difficulties=easy,medium", // Area 5: Skeleton
            "tags=mathematics", // Area 6: Necro
            "tags=computing",  // Area 7: Reaper
            // Oracle will have one question from each areas' categories, totalling to 7
        };
        #endregion

        #region constructor
        public GameManager()
        {
            Area1Questions = new List<Question>(3);
            Area2Questions = new List<Question>(2);
            Area3Questions = new List<Question>(3);
            Area4Questions = new List<Question>(3);
            Area5Questions = new List<Question>(3);
            Area6Questions = new List<Question>(2);
            Area7Questions = new List<Question>(2);
            Area8Questions = new List<Question>(7);

            // Bind the AreaXQuestions list (by reference) to the questionPools
            questionPools = new List<Question>[] {
                Area1Questions, Area2Questions, Area3Questions, Area4Questions,
                Area5Questions, Area6Questions, Area7Questions, Area8Questions
            };

            LoadAllBackupQuestions();

            player1.settings.volume = 0;
            player2.settings.volume = 0;
            player1.settings.setMode("loop", true);
            player2.settings.setMode("loop", true);

            fadeTimer = new Timer();
            fadeTimer.Interval = 30;
            fadeTimer.Tick += FadeTimer_Tick; //adds the method to fadeTimer.Tick

            activePlayer = player1; //media player
            bossQuestionNum = 0;
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            bool completeFadeIn = false;
            bool completeFadeOut = false;

            if(activePlayer.settings.volume < 100)
            {
                activePlayer.settings.volume = Math.Min(100, activePlayer.settings.volume + Fade);
            }
            else
            {
                completeFadeIn = true;
            }

            if(fadingPlayer != null && fadingPlayer.settings.volume > 0)
            {
                fadingPlayer.settings.volume = Math.Max(0, fadingPlayer.settings.volume - Fade);
            }
            else
            {
                if(fadingPlayer == null)
                {
                    fadingPlayer.controls.stop();
                    completeFadeOut = true;
                }
            }

            if(completeFadeIn && completeFadeOut)
            {
                fadeTimer.Stop();
            }
        }
        #endregion

        #region properties
        public WalkArea CurrWalkArea { get => currWalkArea; set => currWalkArea = value; }
        public TalkArea CurrTalkArea { get => currTalkArea; set => currTalkArea = value; }
        public Person ActivePerson { get => activePerson; set => activePerson = value; }
        public List<Question> Area1Questions { get => area1Questions; private set => area1Questions = value; }
        public List<Question> Area2Questions { get => area2Questions; private set => area2Questions = value; }
        public List<Question> Area3Questions { get => area3Questions; private set => area3Questions = value; }
        public List<Question> Area4Questions { get => area4Questions; private set => area4Questions = value; }
        public List<Question> Area5Questions { get => area5Questions; private set => area5Questions = value; }
        public List<Question> Area6Questions { get => area6Questions; private set => area6Questions = value; }
        public List<Question> Area7Questions { get => area7Questions; private set => area7Questions = value; }
        public List<Question> Area8Questions { get => area8Questions; private set => area8Questions = value; }
        public int BossQuestionNum { get => bossQuestionNum; set => bossQuestionNum = value; }
        public int Fade { get => fade; set => fade = value; }

        #endregion

        #region methods
        public string GetTalkAreaName(int personNum)
        {
            return talkAreaNames.ContainsKey(personNum) ? talkAreaNames[personNum] : "Mysterious Place";
        }

        public Question GetQuestion(int areaNum, int questionIndex)
        {
            int poolIndex = areaNum - 1; // Since areaNum starts at 1
            if (poolIndex >= 0 && poolIndex < questionPools.Length)
            {
                var pool = questionPools[poolIndex];
                if (questionIndex >= 0 && questionIndex < pool.Count)
                {
                    return pool[questionIndex];
                }
            }
            return new Question("Failed to get question. Please enter 'exit' as the answer.", "exit", 0);
        }

        public List<Question> GetOracleQuestions()
        {
            return questionPools[7];
        }
        public async Task InitializeAllQuestionsAsync()
        {
            int[] areaNeeds = new int[] {3, 2, 3, 3, 3, 2, 2};

            try
            {
                // Clear all quuestion lists
                for (int i = 0; i < questionPools.Length; i++) questionPools[i].Clear();

                // Populate the area question pools from area 1 through 7 while Area8Questions are populated directly in FetchTriviaApiCategoryAsync()
                for (int i = 0; i < 7; i++) 
                {
                    int standardCount = areaNeeds[i];

                    // +7 backup items in case some get filtered and to have spare for Area8Questions
                    string url = $"https://the-trivia-api.com/v2/questions?limit={standardCount + 7}&{apiEndpoints[i]}";

                    await FetchTriviaApiCategoryAsync(url, questionPools[i], standardCount);
                }

                // Backup if some areas don't have spare questions to donate to Area8
                while (Area8Questions.Count < 7)
                {
                    Area8Questions.Add(new Question("The Oracle demands your survival! What is 12 multiplied by 12?", "144", 300));
                }
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Network connection timed out after 10 seconds! Poor internet connection might be the cause. Switching to Offline Backup Mode.", "Timeout Error");
                LoadAllBackupQuestions();
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Unable to connect to the internet. Please check your connection. Loading local backup questions.", "Connection Error");
                LoadAllBackupQuestions();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}\nTransitioning to local backup.", "System Error");
                LoadAllBackupQuestions();
            }
        }
        
        private async Task FetchTriviaApiCategoryAsync(string url, List<Question> targetList, int requiredCount)
        {
            string jsonResponse = await client.GetStringAsync(url);

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var apiData = serializer.Deserialize<List<TriviaApiJsonObj>>(jsonResponse);

            if (apiData != null)
            {
                targetList.Clear();
                List<Question> validPool = new List<Question>();

                // Gather all valid questions that pass the filter
                foreach (var item in apiData)
                {
                    string cleanQuestion = WebUtility.HtmlDecode(item.Question.Text);
                    string cleanAnswer = WebUtility.HtmlDecode(item.CorrectAnswer);

                    // Filter rules for filtering strict multiple choice questions
                    if (cleanQuestion.ToLower().Contains("which of the following") ||
                        cleanQuestion.ToLower().Contains("which of these"))
                    {
                        continue;
                    }

                    int score = item.Difficulty == "hard" ? 300 : (item.Difficulty == "medium" ? 200 : 100);
                    validPool.Add(new Question(cleanQuestion, cleanAnswer, score));
                }


                for (int i = 0; i < validPool.Count; i++)
                {
                    // If the targetList is not full yet, add the valid question to said list (AreaXQuestions)
                    if (targetList.Count < requiredCount)
                    {
                        targetList.Add(validPool[i]);
                    }
                    else // If there's any valid question left, add to Area8Questions
                    {
                        Area8Questions.Add(validPool[i]);
                        break; // Area 8 only need 1 question from each category
                    }
                }
            }
        }

        public void LoadAllBackupQuestions()
        {
            int[] requiredCounts = new int[] {3, 2, 3, 3, 3, 2, 2, 7};

            for (int i = 0; i < questionPools.Length; i++)
            {
                questionPools[i].Clear();
                while (questionPools[i].Count < requiredCounts[i])
                {
                    questionPools[i].Add(new Question($"Offline Backup Question #{questionPools[i].Count + 1} for Area {i + 1}.", "Backup", 100));
                }
            }
        }

        //public void PlaySound(string soundName) //sound player
        //{
        //    string fileName = "";
        //    if(soundName == "main-menu")
        //    {
        //        fileName = Application.StartupPath + "\\Sounds\\MusicMainMenu.mp3";
        //    }
        //    else if(soundName == "area1")
        //    {
        //        fileName = Application.StartupPath + "\\Sounds\\MusicArea1.mp3";;
        //    }
        //    else if (soundName == "area2")
        //    {
        //        fileName = Application.StartupPath + "\\Sounds\\MusicArea2.mp3";
        //    }
        //    else if (soundName == "area3")
        //    {
        //        fileName = Application.StartupPath + "\\Sounds\\MusicArea3.mp3";
        //    }
        //    else if (soundName == "area4")
        //    {
        //        fileName = Application.StartupPath + "\\Sounds\\MusicArea4.mp3";
        //    }
        //    else if (soundName == "area5")
        //    {
        //        fileName = Application.StartupPath + "\\Sounds\\MusicArea5.mp3";
        //    }
        //    else if (soundName == "area6")
        //    {
        //        fileName = Application.StartupPath + "\\Sounds\\MusicArea6.mp3";            
        //    }
        //    else if (soundName == "area7")
        //    {
        //        fileName = Application.StartupPath + "\\Sounds\\MusicArea7.mp3";
        //    }
        //    else if (soundName == "area8-Ambient")
        //    {
        //        fileName = Application.StartupPath + "\\Sounds\\MusicArea8Sanctum.mp3";
        //    }
        //    else if (soundName == "area8-Battle")
        //    {
        //        fileName = Application.StartupPath + "\\Sounds\\MusicArea8Battle.mp3";
        //    }
        //    else if (soundName == "lose")
        //    {
        //        fileName = Application.StartupPath + "\\Sounds\\MusicEndingLose.mp3";
        //    }
        //    else if (soundName == "win")
        //    {
        //        fileName = Application.StartupPath + "\\Sounds\\MusicEndingWin.mp3";
        //    }
        //    else if (soundName == "opening")
        //    {
        //        fileName = Application.StartupPath + "\\Sounds\\Opening.mp3";
        //    }

        //    if (string.IsNullOrEmpty(fileName))
        //    {
        //        return;
        //    }

        //    if(activePlayer.URL == fileName)
        //    {
        //        return;
        //    }

        //    fadingPlayer = activePlayer;

        //    activePlayer = (activePlayer == player1) ? player2 : player1;

        //    activePlayer.URL = fileName;
        //    activePlayer.settings.volume = 0;
        //    activePlayer.controls.play();

        //    fadeTimer.Start();
        //}

        //public void PlaySFX(string soundName)
        //{
        //    string url = Application.StartupPath + "\\Sounds\\SoundEffects\\" + soundName + ".mp3";

        //    SFX.URL = url;
        //    SFX.settings.volume = 90;

        //    SFX.controls.play();
        //}

        //public void SetSFXVolume(int volume)
        //{
        //    this.SFX.settings.volume = volume;
        //}

        //public void ResumeMusic()
        //{
        //    this.activePlayer.controls.play();
        //}

        //public void PauseMusic()
        //{
        //    this.activePlayer.controls.pause();
        //}

        #endregion
    }
}