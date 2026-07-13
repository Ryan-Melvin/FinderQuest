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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinderQuest
{
    public partial class FormSkins : Form
    {
        public FormSkins()
        {
            InitializeComponent();
        }

        FormMain frmMain;
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            panelSkin.Top = -e.NewValue;
        }

        List<Skin> listSkins = new List<Skin>();
        Skin alchemist = new Skin("Alchemist", "Alchemist", 750, "uncommon");
        Skin buthcer = new Skin("Butcher", "Butcher", 500, "common");
        Skin darkLord = new Skin("DarkLord", "Dark Lord", 2500, "legendary");
        Skin fallenAngel = new Skin("FallenAngel", "Fallen Angel", 1750, "epic");
        Skin forestHunter = new Skin("ForestHunter", "Forest Hunter", 750, "uncommon");
        Skin forestRanger = new Skin("ForestRanger", "Forest Ranger", 500, "common");
        Skin fortuneTeller = new Skin("FortuneTeller", "Fortune Teller", 1250, "rare");
        Skin huntress = new Skin("Huntress", "Huntress", 500, "common");
        Skin ironClad = new Skin("IronClad", "Iron Clad", 750, "uncommon");
        Skin pyromancer = new Skin("Pyromancer", "Pyromancer", 1250, "rare");
        Skin rogue = new Skin("Rogue", "Rogue", 500, "common");
        Skin seer = new Skin("Seer", "Seer", 750, "uncommon");
        Skin silentSking = new Skin("SilentKing", "Silent King", 2500, "legendary");
        Skin tribeWarrior = new Skin("TribeWarrior", "Tribe Warrior", 1750, "epic");
        Skin valkyrie = new Skin("Valkyrie", "Valkyrie", 1250, "rare");
        Skin viking = new Skin("Viking", "Viking", 750, "uncommon");
        Skin wanderer = new Skin("Wanderer", "Wanderer", 1750, "epic");
        Skin selectedSkin, equippedSkin;

        int columns = 3;
        int spacingX = 160;
        int spacingY = 160;
        int startX = 30;
        int startY = 30;

        int currency = 5000; //temporary
        int skinSize = 130;

        private void FormSkins_Load(object sender, EventArgs e)
        {
            frmMain = (FormMain)this.Owner;
            EnableDoubleBuffering(panelShowSkin);
            EnableDoubleBuffering(panelSkin);

            listSkins.AddRange(new Skin[]
            {
                buthcer, huntress, rogue, seer, viking, ironClad, alchemist, forestHunter, forestRanger, valkyrie, fortuneTeller, pyromancer, tribeWarrior, wanderer, fallenAngel, silentSking, darkLord
            });
            vScrollBar1.Maximum = panelSkin.Size.Height - 460;
            labelCurrency.Text = currency.ToString(); //currency diganti poin/coin

            int totalGridWidth = ((columns - 1) * spacingX) + skinSize + 2 * startX;
            vScrollBar1.Left = totalGridWidth;
            panelSkin.Width = totalGridWidth + vScrollBar1.Width;

            int totalGridHeight = startY + ((listSkins.Count / 3) * spacingY) + skinSize + startY;
            panelSkin.Height = totalGridHeight;
            vScrollBar1.Maximum = panelSkin.Height - this.ClientSize.Height;

        }

        private void panelSkin_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int count = 0;
            foreach (Skin skins in listSkins)
            {
                int col = count % columns;
                int row = count / columns;

                int x = startX + (col * spacingX);
                int y = startY + (row * spacingY);

                Rectangle border = new Rectangle(x, y, skinSize, skinSize);
                g.DrawImage(skins.Sprite, border);

                for (int box = 0; box < listSkins.Count; box++)
                {
                    if (skins.Rarity == "common")
                    {
                        g.DrawRectangle(Pens.Gray, x - 5, y - 5, border.Width + 10, border.Height + 10);
                    }
                    else if (skins.Rarity == "uncommon")
                    {
                        g.DrawRectangle(Pens.Green, x - 5, y - 5, border.Width + 10, border.Height + 10);
                    }
                    else if (skins.Rarity == "rare")
                    {
                        g.DrawRectangle(Pens.Blue, x - 5, y - 5, border.Width + 10, border.Height + 10);
                    }
                    else if (skins.Rarity == "epic")
                    {
                        g.DrawRectangle(Pens.Purple, x - 5, y - 5, border.Width + 10, border.Height + 10);
                    }
                    else if (skins.Rarity == "legendary")
                    {
                        g.DrawRectangle(Pens.Gold, x - 5, y - 5, border.Width + 10, border.Height + 10);
                    }
                    panelShowSkin.Invalidate();
                }
                if (selectedSkin == skins)
                {
                    g.DrawRectangle(Pens.Lime, x - 8, y - 8, border.Width + 16, border.Height + 16);
                }
                if (equippedSkin == skins)
                {
                    g.DrawRectangle(Pens.Red, x - 10, y - 10, border.Width + 20, border.Height + 20);
                }
                count += 1;
            }
        }

        private void panelSkin_Click(object sender, EventArgs e)
        {
            Point mousePosition = panelSkin.PointToClient(Cursor.Position);

            int count = 0;
            foreach (Skin skins in listSkins)
            {
                int col = count % columns;
                int row = count / columns;

                int x = startX + (col * spacingX);
                int y = startY + (row * spacingY);

                Rectangle skinClickArea = new Rectangle(x, y, 130, 130);

                if (skinClickArea.Contains(mousePosition))
                {
                    selectedSkin = skins;
                    AnimateSkin();
                    panelShowSkin.Invalidate();
                    panelSkin.Invalidate();

                    if (equippedSkin == skins)
                    {
                        buttonEquip.Enabled = false;
                    }
                    else if (equippedSkin != skins)
                    {
                        buttonEquip.Enabled = true;
                    }

                    if (selectedSkin.IsUnlocked == false)
                    {
                        buttonBuy.Enabled = true;
                        buttonEquip.Enabled = false;
                        labelPrice.Visible = true;
                        labelSkinPrice.Visible = true;
                    }
                    else if (selectedSkin.IsUnlocked == true)
                    {
                        buttonBuy.Enabled = false;
                        buttonEquip.Enabled = true;
                        labelPrice.Visible = false;
                        labelSkinPrice.Visible = false;
                    }
                    break;
                }
                count++;
            }
        }

        private void panelShowSkin_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int x = 20;
            int y = 15;
            int skinSize = panelShowSkin.Width;

            Rectangle targetRect = new Rectangle(x, y, skinSize, skinSize);
            if (selectedSkin != null)
            {
                ImageAnimator.UpdateFrames(selectedSkin.Sprite);
                g.DrawImage(selectedSkin.Sprite, targetRect);
                labelSkinName.Text = selectedSkin.DisplayName;
                labelSkinPrice.Text = selectedSkin.Price.ToString();
                if (selectedSkin.Rarity == "common")
                {
                    panelShowSkin.BackColor = Color.Gray;
                }
                else if (selectedSkin.Rarity == "uncommon")
                {
                    panelShowSkin.BackColor = Color.Green;
                }
                else if (selectedSkin.Rarity == "rare")
                {
                    panelShowSkin.BackColor = Color.Blue;
                }
                else if (selectedSkin.Rarity == "epic")
                {
                    panelShowSkin.BackColor = Color.Purple;
                }
                else if (selectedSkin.Rarity == "legendary")
                {
                    panelShowSkin.BackColor = Color.Gold;
                }
            }
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            if (selectedSkin.BuySkin(ref currency))
            {
                buttonEquip.Enabled = true;
                labelCurrency.Text = currency.ToString();
                MessageBox.Show("Successfully bought " + selectedSkin.DisplayName + " for " + selectedSkin.Price);
            }
            else
            {
                MessageBox.Show("Not enough currency");
            }
        }

        private void buttonEquip_Click(object sender, EventArgs e)
        {
            equippedSkin = selectedSkin;
            labelEquippedSkin.Text = equippedSkin.DisplayName;
            panelSkin.Invalidate();
        }

        private void AnimateSkin()
        {
            if (ImageAnimator.CanAnimate(selectedSkin.Sprite))
            {
                ImageAnimator.Animate(selectedSkin.Sprite, (s, ev) =>
                {
                    panelShowSkin.Invalidate();
                });
            }
        }

        private void EnableDoubleBuffering(Panel panel)
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panel, new object[] { true });
        }
    }
}
