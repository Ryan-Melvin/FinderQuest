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

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        FormMain mainForm;
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            panelSkin.Top = -e.NewValue;
        }

        List<Skin> listSkins = new List<Skin>();
        Skin alchemist = new Skin("Alchemist", "Alchemist", 750, "uncommon");
        Skin butcher = new Skin("Butcher", "Butcher", 500, "common");
        Skin darkLord = new Skin("DarkLord", "Dark Lord", 3000, "legendary");
        Skin fallenAngel = new Skin("FallenAngel", "Fallen Angel", 2000, "epic");
        Skin forestHunter = new Skin("ForestHunter", "Forest Hunter", 750, "uncommon");
        Skin forestRanger = new Skin("ForestRanger", "Forest Ranger", 500, "common");
        Skin fortuneTeller = new Skin("FortuneTeller", "Fortune Teller", 1250, "rare");
        Skin huntress = new Skin("Huntress", "Huntress", 500, "common");
        Skin ironClad = new Skin("IronClad", "Iron Clad", 750, "uncommon");
        Skin pyromancer = new Skin("Pyromancer", "Pyromancer", 1250, "rare");
        Skin rogue = new Skin("Rogue", "Rogue", 500, "common");
        Skin seer = new Skin("Seer", "Seer", 750, "uncommon");
        Skin silentKing = new Skin("SilentKing", "Silent King", 2500, "legendary");
        Skin tribeWarrior = new Skin("TribeWarrior", "Tribe Warrior", 1750, "epic");
        Skin valkyrie = new Skin("Valkyrie", "Valkyrie", 1250, "rare");
        Skin viking = new Skin("Viking", "Viking", 750, "uncommon");
        Skin wanderer = new Skin("Wanderer", "Wanderer", 1750, "epic");
      
        int columns = 3;
        int spacingX = 160;
        int spacingY = 160;
        int startX = 30;
        int startY = 30;

        Skin selectedSkin;
        int skinSize = 130;
        private bool canBuySelectedSkin;
        private bool canEquipSelectedSkin;

        #region helper methods
        private void SortSkins()
        {
            List<Skin> sortedSkins = new List<Skin>();

            string[] rarityOrder = new string[]{ "common", "uncommon", "rare", "epic", "legendary" };

            // Add the equipped skin first
            foreach (Skin skin in listSkins)
            {
                if (skin.Name == mainForm.account.EquippedSkin)
                {
                    sortedSkins.Add(skin);
                    break;
                }
            }

            // Add the other owned skins, sorted by rarity
            foreach (string rarity in rarityOrder)
            {
                foreach (Skin skin in listSkins)
                {
                    bool isOwned = mainForm.account.OwnedSkins.Contains(skin.Name);

                    bool isEquipped = skin.Name == mainForm.account.EquippedSkin;

                    if (isOwned &&
                        !isEquipped &&
                        skin.Rarity == rarity)
                    {
                        sortedSkins.Add(skin);
                    }
                }
            }

            // Add unowned skins last, sorted by rarity
            foreach (string rarity in rarityOrder)
            {
                foreach (Skin skin in listSkins)
                {
                    bool isOwned =
                        mainForm.account.OwnedSkins.Contains(skin.Name);

                    if (!isOwned && skin.Rarity == rarity)
                    {
                        sortedSkins.Add(skin);
                    }
                }
            }

            listSkins = sortedSkins;
        }

        private void UpdateActionButtons()
        {
            if (selectedSkin == null)
            {
                canBuySelectedSkin = false;
                canEquipSelectedSkin = false;

                buttonBuy.Visible = false;
                buttonEquip.Visible = false;

                return;
            }

            bool isOwned =
                mainForm.account.OwnedSkins.Contains(selectedSkin.Name);

            bool isEquipped =
                mainForm.account.EquippedSkin == selectedSkin.Name;

            bool canAfford =
                mainForm.account.GoldBalance >= selectedSkin.Price;

            // Keep both buttons enabled, add custom variable to enable styling
            buttonBuy.Enabled = true;
            buttonEquip.Enabled = true;

            if (!isOwned)
            {
                buttonBuy.Visible = true;
                buttonEquip.Visible = false;

                buttonBuy.FlatStyle = FlatStyle.Flat;
                buttonBuy.FlatAppearance.BorderSize = 2;
                buttonBuy.UseVisualStyleBackColor = false;

                if (canAfford)
                {
                    canBuySelectedSkin = true;

                    buttonBuy.Text = "Buy Skin";
                    buttonBuy.ForeColor = Color.FromArgb(255, 243, 224);
                    buttonBuy.BackColor = Color.FromArgb(150, 91, 43);
                    buttonBuy.FlatAppearance.BorderColor = Color.FromArgb(214, 190, 110);

                    buttonBuy.Cursor = Cursors.Hand;
                }
                else
                {
                    canBuySelectedSkin = false;

                    buttonBuy.Text = "Insufficient";
                    buttonBuy.ForeColor = Color.FromArgb(190, 175, 160);
                    buttonBuy.BackColor = Color.FromArgb(75, 58, 50);
                    buttonBuy.FlatAppearance.BorderColor = Color.FromArgb(110, 90, 78);

                    buttonBuy.Cursor = Cursors.Default;
                }

                return;
            }

            // Owned skin
            buttonBuy.Visible = false;
            buttonEquip.Visible = true;

            buttonEquip.FlatStyle = FlatStyle.Flat;
            buttonEquip.FlatAppearance.BorderSize = 2;
            buttonEquip.UseVisualStyleBackColor = false;

            if (isEquipped)
            {
                canEquipSelectedSkin = false;

                buttonEquip.Text = "Equipped";
                buttonEquip.ForeColor = Color.FromArgb(235, 230, 215);
                buttonEquip.BackColor = Color.FromArgb(90, 78, 68);
                buttonEquip.FlatAppearance.BorderColor = Color.FromArgb(195, 199, 205);

                buttonEquip.Cursor = Cursors.Default;
            }
            else
            {
                canEquipSelectedSkin = true;

                buttonEquip.Text = "Equip Skin";
                buttonEquip.ForeColor = Color.FromArgb(255, 243, 224);
                buttonEquip.BackColor = Color.FromArgb(150, 91, 43);
                buttonEquip.FlatAppearance.BorderColor = Color.FromArgb(214, 190, 110);

                buttonEquip.Cursor = Cursors.Hand;
            }
        }
        #endregion

        private void FormSkins_Load(object sender, EventArgs e)
        {
            mainForm = (FormMain)this.Owner;
            EnableDoubleBuffering(panelShowSkin);
            EnableDoubleBuffering(panelSkin);

            listSkins.AddRange(new Skin[]
            {
                forestRanger, butcher, huntress, rogue, seer, viking, ironClad, alchemist, forestHunter, valkyrie, fortuneTeller, pyromancer, tribeWarrior, wanderer, fallenAngel, silentKing, darkLord
            });

            SortSkins();

            vScrollBar1.Maximum = panelSkin.Size.Height - 460;
            labelCurrency.Text = mainForm.account.GoldBalance + "G";

            int totalGridWidth = ((columns - 1) * spacingX) + skinSize + 2 * startX;
            vScrollBar1.Left = totalGridWidth;
            panelSkin.Width = totalGridWidth + vScrollBar1.Width;

            int totalGridHeight = startY + ((listSkins.Count / 3) * spacingY) + skinSize + startY;
            panelSkin.Height = totalGridHeight;
            vScrollBar1.Maximum = panelSkin.Height - this.ClientSize.Height;

            labelEquipped.Visible = false;
            labelRarity.Visible = false;

            this.MouseWheel += new MouseEventHandler(FormSkins_MouseWheel); //for scrolling

            pictureBoxPrice.Visible = false;
            buttonEquip.Visible = false;
            buttonBuy.Visible = false;
            vScrollBar1.Visible = false;

            mainForm.sound.PlaySound("skin-shop");
        }

        private void panelSkin_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            SolidBrush woodBrush = new SolidBrush(Color.FromArgb(120, 68, 33));
            Pen commonPen = new Pen(Color.FromArgb(156, 142, 125), 3);
            Pen uncommonPen = new Pen(Color.FromArgb(75, 111, 68), 3);
            Pen rarePen = new Pen(Color.FromArgb(59, 114, 159), 3);
            Pen epicPen = new Pen(Color.FromArgb(130, 87, 138), 3);
            Pen legendaryPen = new Pen(Color.FromArgb(230, 168, 23), 3);

            Pen selectedPen = new Pen(Color.FromArgb(255, 243, 224), 2);
            Pen equippedPen = new Pen(Color.FromArgb(195, 199, 205), 3);

            SolidBrush lockedOverlay = new SolidBrush(Color.FromArgb(125, 20, 10, 10));
            SolidBrush lockedBoxBrush =new SolidBrush(Color.FromArgb(210, 45, 25, 22));
            SolidBrush lockedTextBrush = new SolidBrush(Color.FromArgb(235, 225, 210));
            Font lockedFont = new Font("Segoe UI", 9, FontStyle.Bold);

            int count = 0;

            foreach (Skin skin in listSkins)
            {
                int col = count % columns;
                int row = count / columns;

                int x = startX + (col * spacingX);
                int y = startY + (row * spacingY);

                Rectangle skinBox = new Rectangle(x, y, skinSize, skinSize);

                g.FillRectangle(woodBrush, skinBox);
                g.DrawImage(skin.Sprite, skinBox);

                // Draw rarity border
                if (skin.Rarity == "common")
                {
                    g.DrawRectangle(commonPen, x - 5, y - 5, skinBox.Width + 10, skinBox.Height + 10);
                }
                else if (skin.Rarity == "uncommon")
                {
                    g.DrawRectangle(uncommonPen, x - 5, y - 5, skinBox.Width + 10, skinBox.Height + 10);
                }
                else if (skin.Rarity == "rare")
                {
                    g.DrawRectangle(rarePen, x - 5, y - 5, skinBox.Width + 10, skinBox.Height + 10);
                }
                else if (skin.Rarity == "epic")
                {
                    g.DrawRectangle(epicPen, x - 5, y - 5, skinBox.Width + 10, skinBox.Height + 10);
                }
                else if (skin.Rarity == "legendary")
                {
                    g.DrawRectangle(legendaryPen, x - 5, y - 5, skinBox.Width + 10, skinBox.Height + 10);
                }

                bool isOwned = mainForm.account.OwnedSkins.Contains(skin.Name);

                // Darken unowned skins
                if (!isOwned)
                {
                    g.FillRectangle(lockedOverlay, skinBox);

                    Rectangle lockedBox = new Rectangle(x, y + skinSize - 25, skinSize, 25);

                    g.FillRectangle(lockedBoxBrush, lockedBox);

                    SizeF textSize = g.MeasureString("LOCKED", lockedFont);
                    float lockedTextX = x + (skinSize - textSize.Width) / 2;
                    float lockedTextY = y + skinSize - 22;
                    g.DrawString("LOCKED", lockedFont, lockedTextBrush, lockedTextX, lockedTextY);
                }

                // Draw selected border
                if (selectedSkin == skin)
                {
                    g.DrawRectangle(selectedPen, x - 8, y - 8, skinBox.Width + 16, skinBox.Height + 16);
                }

                // Draw equipped border
                if (mainForm.account.EquippedSkin == skin.Name)
                {
                    g.DrawRectangle(equippedPen, x - 10, y - 10, skinBox.Width + 20, skinBox.Height + 20);
                    labelEquipped.Location = new Point(x + (skinSize / 2) - (labelEquipped.Width / 2), y + 5);

                    labelEquipped.Visible = true;
                }

                count++;
            }
            woodBrush.Dispose();
            commonPen.Dispose();
            uncommonPen.Dispose();
            rarePen.Dispose();
            epicPen.Dispose();
            legendaryPen.Dispose();
            selectedPen.Dispose();
            equippedPen.Dispose();
            lockedOverlay.Dispose();
            lockedBoxBrush.Dispose();
            lockedTextBrush.Dispose();
            lockedFont.Dispose();
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

                    labelRarity.Text = skins.Rarity.Substring(0, 1).ToUpper() + skins.Rarity.Substring(1);
                    labelRarity.Location = new Point(panel1.Location.X + panel1.Width - labelRarity.Width, labelRarity.Location.Y);

                    if (!labelRarity.Visible)
                    {
                        labelRarity.Visible = true;
                    }

                    if (!mainForm.account.OwnedSkins.Contains(selectedSkin.Name))
                    {
                        labelPrice.Visible = true;

                        labelSkinPrice.Text = selectedSkin.Price + "G";
                        labelSkinPrice.Visible = true;

                        pictureBoxPrice.Parent = panel1;
                        pictureBoxPrice.Size = new Size(labelSkinPrice.Height, labelSkinPrice.Height); 
                        pictureBoxPrice.Location = new Point(labelSkinPrice.Location.X + labelSkinPrice.Width, labelSkinPrice.Location.Y);

                        pictureBoxPrice.Visible = true;
                    }
                    else
                    {
                        labelSkinPrice.Text = "Owned";

                        labelPrice.Visible = false;
                        labelSkinPrice.Visible = true;
                        pictureBoxPrice.Visible = false;
                    }

                    UpdateActionButtons();
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

                if (selectedSkin.Rarity == "common")
                {
                    panelShowSkin.BackColor = Color.FromArgb(156, 142, 125);
                }
                else if (selectedSkin.Rarity == "uncommon")
                {
                    panelShowSkin.BackColor = Color.FromArgb(75, 111, 68);
                }
                else if (selectedSkin.Rarity == "rare")
                {
                    panelShowSkin.BackColor = Color.FromArgb(59, 114, 159);
                }
                else if (selectedSkin.Rarity == "epic")
                {
                    panelShowSkin.BackColor = Color.FromArgb(130, 87, 138);
                }
                else if (selectedSkin.Rarity == "legendary")
                {
                    panelShowSkin.BackColor = Color.FromArgb(230, 168, 23);
                }
                labelRarity.ForeColor = panelShowSkin.BackColor;
            }
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            if (!canBuySelectedSkin)
            {
                return;
            }

            mainForm.account.GoldBalance -= selectedSkin.Price;
            mainForm.account.AddOwnedSkins(selectedSkin.Name);

            labelCurrency.Text = mainForm.account.GoldBalance + "G";

            MessageBox.Show("Successfully bought " + selectedSkin.DisplayName + " for " + selectedSkin.Price + "G!");

            labelSkinPrice.Text = "Owned";
            labelPrice.Visible = false;
            pictureBoxPrice.Visible = false;

            SortSkins();
            UpdateActionButtons();

            vScrollBar1.Value = 0;
            panelSkin.Top = 0;

            panelSkin.Invalidate();
        }

        private void buttonEquip_Click(object sender, EventArgs e)
        {
            if (!canEquipSelectedSkin)
            {
                return;
            }

            mainForm.account.EquippedSkin = selectedSkin.Name;

            labelPrice.Visible = false;
            pictureBoxPrice.Visible = false;

            SortSkins();
            UpdateActionButtons();

            vScrollBar1.Value = 0;
            panelSkin.Top = 0;

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

        private void FormSkins_MouseWheel(object sender, MouseEventArgs e)
        {
            int scrollDownAmount = 8;
            int scrollUpAmount = 16;

            if(e.Delta > 0) //scrolls up
            {
                if (vScrollBar1.Value - scrollUpAmount >= 0)
                {
                    vScrollBar1.Value -= scrollUpAmount;
                }
                else
                {
                    vScrollBar1.Value = 0;
                }
            }
            else //scrolls down
            {
                if(vScrollBar1.Value + scrollDownAmount <= vScrollBar1.Maximum)
                {
                    vScrollBar1.Value += scrollDownAmount;
                }
                else
                {
                    vScrollBar1.Value = vScrollBar1.Maximum;
                }
            }

            vScrollBar1_Scroll(vScrollBar1, new ScrollEventArgs(ScrollEventType.ThumbPosition, vScrollBar1.Value)); //updates panel position
        }

        private void pictureBoxPrice_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
