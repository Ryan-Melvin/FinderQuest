namespace FinderQuest
{
    partial class FormSkins
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.panelSkin = new System.Windows.Forms.Panel();
            this.labelEquipped = new System.Windows.Forms.Label();
            this.labelSkinPrice = new System.Windows.Forms.Label();
            this.labelSkinName = new System.Windows.Forms.Label();
            this.panelShowSkin = new System.Windows.Forms.Panel();
            this.labelPrice = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.buttonBuy = new System.Windows.Forms.Button();
            this.buttonEquip = new System.Windows.Forms.Button();
            this.labelRarity = new System.Windows.Forms.Label();
            this.pictureBoxCurrency = new System.Windows.Forms.PictureBox();
            this.pictureBoxPrice = new System.Windows.Forms.PictureBox();
            this.panelBorderLeft = new System.Windows.Forms.Panel();
            this.panelBorderTop = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelStripe1 = new System.Windows.Forms.Panel();
            this.panelStripe2 = new System.Windows.Forms.Panel();
            this.panelSkin.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(341, -5);
            this.vScrollBar1.Maximum = 500;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(23, 482);
            this.vScrollBar1.TabIndex = 0;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // panelSkin
            // 
            this.panelSkin.AutoScroll = true;
            this.panelSkin.AutoScrollMinSize = new System.Drawing.Size(5, 5);
            this.panelSkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panelSkin.Controls.Add(this.labelEquipped);
            this.panelSkin.Location = new System.Drawing.Point(-1, 0);
            this.panelSkin.Name = "panelSkin";
            this.panelSkin.Size = new System.Drawing.Size(348, 980);
            this.panelSkin.TabIndex = 1;
            this.panelSkin.Click += new System.EventHandler(this.panelSkin_Click);
            this.panelSkin.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSkin_Paint);
            // 
            // labelEquipped
            // 
            this.labelEquipped.AutoSize = true;
            this.labelEquipped.BackColor = System.Drawing.Color.Transparent;
            this.labelEquipped.Location = new System.Drawing.Point(246, 80);
            this.labelEquipped.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEquipped.Name = "labelEquipped";
            this.labelEquipped.Size = new System.Drawing.Size(52, 13);
            this.labelEquipped.TabIndex = 0;
            this.labelEquipped.Text = "Equipped";
            this.labelEquipped.Visible = false;
            // 
            // labelSkinPrice
            // 
            this.labelSkinPrice.AutoSize = true;
            this.labelSkinPrice.BackColor = System.Drawing.Color.Transparent;
            this.labelSkinPrice.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSkinPrice.ForeColor = System.Drawing.Color.Snow;
            this.labelSkinPrice.Location = new System.Drawing.Point(229, 312);
            this.labelSkinPrice.Name = "labelSkinPrice";
            this.labelSkinPrice.Size = new System.Drawing.Size(93, 28);
            this.labelSkinPrice.TabIndex = 2;
            this.labelSkinPrice.Text = "SkinPrice";
            // 
            // labelSkinName
            // 
            this.labelSkinName.AutoSize = true;
            this.labelSkinName.BackColor = System.Drawing.Color.Transparent;
            this.labelSkinName.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSkinName.ForeColor = System.Drawing.Color.Snow;
            this.labelSkinName.Location = new System.Drawing.Point(15, 312);
            this.labelSkinName.Name = "labelSkinName";
            this.labelSkinName.Size = new System.Drawing.Size(101, 28);
            this.labelSkinName.TabIndex = 1;
            this.labelSkinName.Text = "SkinName";
            // 
            // panelShowSkin
            // 
            this.panelShowSkin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelShowSkin.Location = new System.Drawing.Point(23, 24);
            this.panelShowSkin.Name = "panelShowSkin";
            this.panelShowSkin.Size = new System.Drawing.Size(280, 280);
            this.panelShowSkin.TabIndex = 3;
            this.panelShowSkin.Paint += new System.Windows.Forms.PaintEventHandler(this.panelShowSkin_Paint);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.BackColor = System.Drawing.Color.Transparent;
            this.labelPrice.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.ForeColor = System.Drawing.Color.Snow;
            this.labelPrice.Location = new System.Drawing.Point(167, 312);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(65, 28);
            this.labelPrice.TabIndex = 3;
            this.labelPrice.Text = "Price: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panel1.Controls.Add(this.panelShowSkin);
            this.panel1.Controls.Add(this.labelPrice);
            this.panel1.Controls.Add(this.labelSkinPrice);
            this.panel1.Controls.Add(this.labelSkinName);
            this.panel1.Location = new System.Drawing.Point(397, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 349);
            this.panel1.TabIndex = 4;
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrency.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrency.ForeColor = System.Drawing.Color.Snow;
            this.labelCurrency.Location = new System.Drawing.Point(445, 20);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(86, 28);
            this.labelCurrency.TabIndex = 5;
            this.labelCurrency.Text = "Currency";
            // 
            // buttonBuy
            // 
            this.buttonBuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(82)))), ((int)(((byte)(45)))));
            this.buttonBuy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(133)))), ((int)(((byte)(70)))));
            this.buttonBuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuy.Location = new System.Drawing.Point(476, 417);
            this.buttonBuy.Name = "buttonBuy";
            this.buttonBuy.Size = new System.Drawing.Size(153, 36);
            this.buttonBuy.TabIndex = 4;
            this.buttonBuy.Text = "Buy Skin";
            this.buttonBuy.UseVisualStyleBackColor = false;
            this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);
            // 
            // buttonEquip
            // 
            this.buttonEquip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(82)))), ((int)(((byte)(45)))));
            this.buttonEquip.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(133)))), ((int)(((byte)(70)))));
            this.buttonEquip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEquip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEquip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(212)))));
            this.buttonEquip.Location = new System.Drawing.Point(476, 418);
            this.buttonEquip.Name = "buttonEquip";
            this.buttonEquip.Size = new System.Drawing.Size(153, 35);
            this.buttonEquip.TabIndex = 6;
            this.buttonEquip.Text = "Equip Skin";
            this.buttonEquip.UseVisualStyleBackColor = false;
            this.buttonEquip.Click += new System.EventHandler(this.buttonEquip_Click);
            // 
            // labelRarity
            // 
            this.labelRarity.AutoSize = true;
            this.labelRarity.BackColor = System.Drawing.Color.Transparent;
            this.labelRarity.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRarity.Location = new System.Drawing.Point(652, 20);
            this.labelRarity.Name = "labelRarity";
            this.labelRarity.Size = new System.Drawing.Size(73, 28);
            this.labelRarity.TabIndex = 7;
            this.labelRarity.Text = "Rarity";
            // 
            // pictureBoxCurrency
            // 
            this.pictureBoxCurrency.Image = global::FinderQuest.Properties.Resources.Coin;
            this.pictureBoxCurrency.Location = new System.Drawing.Point(407, 20);
            this.pictureBoxCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxCurrency.Name = "pictureBoxCurrency";
            this.pictureBoxCurrency.Size = new System.Drawing.Size(29, 29);
            this.pictureBoxCurrency.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCurrency.TabIndex = 8;
            this.pictureBoxCurrency.TabStop = false;
            // 
            // pictureBoxPrice
            // 
            this.pictureBoxPrice.Image = global::FinderQuest.Properties.Resources.Coin;
            this.pictureBoxPrice.Location = new System.Drawing.Point(727, 366);
            this.pictureBoxPrice.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxPrice.Name = "pictureBoxPrice";
            this.pictureBoxPrice.Size = new System.Drawing.Size(29, 29);
            this.pictureBoxPrice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPrice.TabIndex = 9;
            this.pictureBoxPrice.TabStop = false;
            // 
            // panelBorderLeft
            // 
            this.panelBorderLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(28)))), ((int)(((byte)(12)))));
            this.panelBorderLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(28)))), ((int)(((byte)(12)))));
            this.panelBorderLeft.Location = new System.Drawing.Point(341, 0);
            this.panelBorderLeft.Margin = new System.Windows.Forms.Padding(2);
            this.panelBorderLeft.Name = "panelBorderLeft";
            this.panelBorderLeft.Size = new System.Drawing.Size(15, 463);
            this.panelBorderLeft.TabIndex = 10;
            // 
            // panelBorderTop
            // 
            this.panelBorderTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(28)))), ((int)(((byte)(12)))));
            this.panelBorderTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(28)))), ((int)(((byte)(12)))));
            this.panelBorderTop.Location = new System.Drawing.Point(356, 1);
            this.panelBorderTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelBorderTop.Name = "panelBorderTop";
            this.panelBorderTop.Size = new System.Drawing.Size(405, 15);
            this.panelBorderTop.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(28)))), ((int)(((byte)(12)))));
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(28)))), ((int)(((byte)(12)))));
            this.panel2.Location = new System.Drawing.Point(341, 462);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 15);
            this.panel2.TabIndex = 12;
            // 
            // panelStripe1
            // 
            this.panelStripe1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.panelStripe1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(28)))), ((int)(((byte)(12)))));
            this.panelStripe1.Location = new System.Drawing.Point(340, 389);
            this.panelStripe1.Margin = new System.Windows.Forms.Padding(2);
            this.panelStripe1.Name = "panelStripe1";
            this.panelStripe1.Size = new System.Drawing.Size(19, 15);
            this.panelStripe1.TabIndex = 13;
            // 
            // panelStripe2
            // 
            this.panelStripe2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.panelStripe2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(28)))), ((int)(((byte)(12)))));
            this.panelStripe2.Location = new System.Drawing.Point(340, 81);
            this.panelStripe2.Margin = new System.Windows.Forms.Padding(2);
            this.panelStripe2.Name = "panelStripe2";
            this.panelStripe2.Size = new System.Drawing.Size(19, 15);
            this.panelStripe2.TabIndex = 14;
            // 
            // FormSkins
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(760, 478);
            this.Controls.Add(this.panelStripe2);
            this.Controls.Add(this.panelStripe1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelBorderTop);
            this.Controls.Add(this.pictureBoxPrice);
            this.Controls.Add(this.pictureBoxCurrency);
            this.Controls.Add(this.labelRarity);
            this.Controls.Add(this.buttonEquip);
            this.Controls.Add(this.buttonBuy);
            this.Controls.Add(this.labelCurrency);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.panelBorderLeft);
            this.Controls.Add(this.panelSkin);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(212)))));
            this.Name = "FormSkins";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Shop";
            this.Load += new System.EventHandler(this.FormSkins_Load);
            this.panelSkin.ResumeLayout(false);
            this.panelSkin.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Panel panelSkin;
        private System.Windows.Forms.Label labelSkinName;
        private System.Windows.Forms.Label labelSkinPrice;
        private System.Windows.Forms.Panel panelShowSkin;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.Button buttonBuy;
        private System.Windows.Forms.Button buttonEquip;
        private System.Windows.Forms.Label labelRarity;
        private System.Windows.Forms.Label labelEquipped;
        private System.Windows.Forms.PictureBox pictureBoxCurrency;
        private System.Windows.Forms.PictureBox pictureBoxPrice;
        private System.Windows.Forms.Panel panelBorderLeft;
        private System.Windows.Forms.Panel panelBorderTop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelStripe1;
        private System.Windows.Forms.Panel panelStripe2;
    }
}