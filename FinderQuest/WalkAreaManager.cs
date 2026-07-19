using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinderQuest
{
    public class WalkAreaManager
    {
        #region methods
        public void GenerateWalkArea(FormMain form, Label labelArea)
        {
            double scaleX = (double)form.ClientSize.Width / 800.0;

            // First run
            if (form.game.CurrWalkArea == null)
            {
                form.game.CurrWalkArea = new WalkArea("The Needlewood", Properties.Resources.GoblinForest, 1);
                form.sound.PlaySound("area1");

                // Passes specific indexes from 2D questions matrix to each Person
                form.game.CurrWalkArea.AddPerson(1, "Goblin", Properties.Resources.Goblin_Idle_Left, new Size(form.GetSize("small"), form.GetSize("small")), "One little lie, and I call the whole pack. And we're hungry today...\n", (int)(100 * scaleX), form.ClientSize.Height / 2, "GoblinGreeting", "GoblinDeath", form.game.GetQuestion(1, 0));
                form.game.CurrWalkArea.AddPerson(2, "Orc", Properties.Resources.Orc_Idle_Left, new Size(form.GetSize("medium"), form.GetSize("medium")), "Tick-tock, the trap is unlocked! Give us the right answer, or enjoy the drop.\n", (int)(370 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("medium") - form.GetPlayerSize().Height), "OrcGreeting", "OrcDeath", form.game.GetQuestion(1, 1));
                form.game.CurrWalkArea.AddPerson(3, "Ogre", Properties.Resources.Ogre_Idle_Left, new Size(form.GetSize("big"), form.GetSize("big")), "You better answer my question correctly..\n", (int)(620 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("big") - form.GetPlayerSize().Height), "OgreGreeting", "OgreDeath", form.game.GetQuestion(1, 2));
            }
            else if (form.game.CurrWalkArea.AreaNum == 7)
            {
                form.sound.SetSFXVolume(40);
                form.game.CurrWalkArea.RemovePeople(form);
                form.game.CurrWalkArea = new WalkArea("Titan's Ridge", Properties.Resources.GolemLands, 2);
                form.sound.PlaySound("area2");

                form.game.CurrWalkArea.AddPerson(4, "Rock Golem", Properties.Resources.RockGolem_Idle_Left, new Size(form.GetSize("big"), form.GetSize("big")), "Who woke me up from my sleep?\n", (int)(100 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("big") - form.GetPlayerSize().Height), "IceGolemGreeting", "IceGolemGreeting", form.game.GetQuestion(2, 0));
                form.game.CurrWalkArea.AddPerson(5, "Moss Golem", Properties.Resources.MossGolem_Idle_Left, new Size(form.GetSize("big"), form.GetSize("big")), "You shall pay for waking me up! \n", (int)(400 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("big") - form.GetPlayerSize().Height), "MossGolemGreeting", "MossGolemGreeting", form.game.GetQuestion(2, 1));
            }
            else if (form.game.CurrWalkArea.AreaNum == 2)
            {
                form.sound.SetSFXVolume(90);
                form.game.CurrWalkArea.RemovePeople(form);
                form.game.CurrWalkArea = new WalkArea("The Zombie Outpost", Properties.Resources.AbandonedVillage, 3);
                form.sound.PlaySound("area3");

                form.game.CurrWalkArea.AddPerson(6, "Zombie Stalker", Properties.Resources.Zombie_Idle_Left, new Size(form.GetSize("small"), form.GetSize("small")), "Brains... and knowledge! Answer carefully...\n", (int)(120 * scaleX), form.ClientSize.Height / 2, "ZombieGreeting", "ZombieDeath", form.game.GetQuestion(3, 0));
                form.game.CurrWalkArea.AddPerson(7, "Zombie Spitter", Properties.Resources.ZombieVillager_Idle_Left, new Size(form.GetSize("small"), form.GetSize("small")), "I have a riddle deep in my lungs... \n", (int)(420 * scaleX), form.ClientSize.Height / 2, "ZombieGreeting", "ZombieDeath", form.game.GetQuestion(3, 1));
                form.game.CurrWalkArea.AddPerson(8, "Zombie Tank", Properties.Resources.Husk_Idle_Left, new Size(form.GetSize("big"), form.GetSize("big")), "Stop right there traveler! \n", (int)(650 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("big") - form.GetPlayerSize().Height), "ZombieGreeting", "ZombieDeath", form.game.GetQuestion(3, 2));
            }
            else if (form.game.CurrWalkArea.AreaNum == 3)
            {
                form.game.CurrWalkArea.RemovePeople(form);
                form.game.CurrWalkArea = new WalkArea("The Minotaur's Terrace", Properties.Resources.MinotaurTerrace, 4);
                form.sound.PlaySound("area4");

                form.game.CurrWalkArea.AddPerson(9, "Minotaur", Properties.Resources.Minotaur_Idle_Left, new Size(form.GetSize("medium"), form.GetSize("medium")), "Myths... and memory! Answer carefully...\n", (int)(100 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("medium") - form.GetPlayerSize().Height), "MinotaurGreeting", "MinotaurDeath", form.game.GetQuestion(4, 0));
                form.game.CurrWalkArea.AddPerson(10, "Taurus", Properties.Resources.Taurus_Idle_Left, new Size(form.GetSize("medium"), form.GetSize("medium")), "Axes... and arts! Answer carefully...\n", (int)(370 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("medium") - form.GetPlayerSize().Height), "MinotaurGreeting", "MinotaurDeath", form.game.GetQuestion(4, 1));
                form.game.CurrWalkArea.AddPerson(11, "Lost Bull", Properties.Resources.LostBull_Idle_Left, new Size(form.GetSize("big"), form.GetSize("big")), "I'm the boss here, you shall not pass! \n", (int)(620 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("big") - form.GetPlayerSize().Height), "BullGreeting", "MinotaurDeath", form.game.GetQuestion(4, 2));
            }
            else if (form.game.CurrWalkArea.AreaNum == 4)
            {
                form.game.CurrWalkArea.RemovePeople(form);
                form.game.CurrWalkArea = new WalkArea("The Crypt of Skeletons", Properties.Resources.Graveyard, 5);
                form.sound.PlaySound("area5");

                form.game.CurrWalkArea.AddPerson(12, "Larry", Properties.Resources.LarrryTheSkeleton_Idle_Left, new Size(form.GetSize("small"), form.GetSize("small")), "Marrow... and mind! Think before you speak...\n", (int)(100 * scaleX), form.ClientSize.Height / 2, "SkeletonGreeting", "SkeletonDeath", form.game.GetQuestion(5, 0));
                form.game.CurrWalkArea.AddPerson(13, "Skeleton Guard", Properties.Resources.SkeletonGuard_Idle_Left, new Size(form.GetSize("small"), form.GetSize("small")), "Dust to dust, bone to bone.. give me an answer, or be left alone.\n", (int)(370 * scaleX), form.ClientSize.Height / 2, "SkeletonGreeting", "SkeletonDeath", form.game.GetQuestion(5, 1));
                form.game.CurrWalkArea.AddPerson(14, "Skeleton Warrior", Properties.Resources.SkeletonWarrior_Idle_Left, new Size(form.GetSize("small"), form.GetSize("small")), "The grave forgets nothing. Tread lightly with your words.\n", (int)(620 * scaleX), form.ClientSize.Height / 2, "SkeletonGreeting", "SkeletonDeath", form.game.GetQuestion(5, 2));
            }
            else if (form.game.CurrWalkArea.AreaNum == 5)
            {
                form.game.CurrWalkArea.RemovePeople(form);
                form.game.CurrWalkArea = new WalkArea("The Necromancer Tower", Properties.Resources.CastleEntrance, 6);
                form.sound.PlaySound("area6");

                form.game.CurrWalkArea.AddPerson(15, "Necromancer", Properties.Resources.Necro_Idle_Left, new Size(form.GetSize("medium"), form.GetSize("medium")), "Your soul is a fragile thread. Do not make me snip it...\n", (int)(120 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("medium") - form.GetPlayerSize().Height), "NecroGreeting", "NecroDeath", form.game.GetQuestion(6, 0));
                form.game.CurrWalkArea.AddPerson(16, "Soul Snatcher", Properties.Resources.NecroLady_Idle_Left, new Size(form.GetSize("medium"), form.GetSize("medium")), "Your heartbeat is a rhythm I can easily stop. Think before you answer.\n", (int)(420 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("medium") - form.GetPlayerSize().Height), "NecroGreeting", "NecroDeath", form.game.GetQuestion(6, 1));
            }
            else if (form.game.CurrWalkArea.AreaNum == 6)
            {
                form.sound.SetSFXVolume(60);
                form.game.CurrWalkArea.RemovePeople(form);
                form.game.CurrWalkArea = new WalkArea("Reaper's Domain", Properties.Resources.ReaperHallway, 7);
                form.sound.PlaySound("area7");

                form.game.CurrWalkArea.AddPerson(17, "Grim", Properties.Resources.Reaper_Idle_Left, new Size(form.GetSize("medium"), form.GetSize("medium")), "Pulse and data! Both are so easily measured and stopped. Answer me.\n", (int)(120 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("medium") - form.GetPlayerSize().Height), "ReaperGreeting", "ReaperDeath", form.game.GetQuestion(7, 0));
                form.game.CurrWalkArea.AddPerson(18, "Azrael", Properties.Resources.DeathReaper_Idle_Left, new Size(form.GetSize("medium"), form.GetSize("medium")), "I do not just kill, I keep.\n", (int)(420 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("medium") - form.GetPlayerSize().Height), "ReaperGreeting", "ReaperDeath", form.game.GetQuestion(7, 1));
            }
            else if (form.game.CurrWalkArea.AreaNum == 1)
            {
                form.sound.SetSFXVolume(90);
                form.game.CurrWalkArea.RemovePeople(form);
                form.game.CurrWalkArea = new WalkArea("The Oracle's Sanctum", Properties.Resources.throne_room, 8);
                form.sound.PlaySound("area8-Ambient");

                form.game.CurrWalkArea.AddPerson(19, "The Oracle", Properties.Resources.DarkApprentice_Idle_Left, new Size(form.GetSize("boss"), form.GetSize("boss")), "This is the final test, you will fail..\n", (int)(420 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("boss") - form.GetPlayerSize().Height - 20), "OracleGreeting", "OracleDeath", form.game.GetOracleQuestions());
            }

            foreach (Person person in form.game.CurrWalkArea.People)
            {
                form.AnimatePerson(person);
            }

            form.game.CurrWalkArea.DisplayPicture(form);
            labelArea.Text = form.game.CurrWalkArea.DisplayData();

            if (form.player != null)
            {
                form.player.X = 0;
            }
        }

        #endregion
    }
}