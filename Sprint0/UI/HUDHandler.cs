using System;
using System.Collections.Generic;
using System.Text;
using Poggus.UI.UIObjects;
using Poggus.Player;
using Poggus.PlayerInventory;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Poggus.Items;

namespace Poggus.UI
{
    public class HUDHandler
    {
        bool fullHUD;
        MapUIHandler mapHandler;
        TextSprite lifeText, levelText, rupeeAmtText, keyAmtText, bombAmtText, slotAText, slotBText, inventoryText;
        ImageUI hudBlackBackground, aSlotBackground, bSlotBackground, inventoryBackground, keyImage, bombImage, rupeeImage;
        ImageUI slotAItemImage, slotBItemImage;
        ImageUI inventoryCursor, fullInventoryBackground, activeItem;
        int hoveredItem = 0;
        List<ImageUI> heartImages;
        List<ImageUI> inventoryImages;
        private int healthDrawn;

        public int hudWidth, hudHeight;
        
        ILink link;
        Inventory inventory;
        public HUDHandler(ILink link)
        {
            this.link = link;
            this.inventory = link.LinkInventory;
            this.heartImages = new List<ImageUI>();
            inventoryImages = new List<ImageUI>();
            healthDrawn = 0;
            hudWidth = Game1.instance._graphics.PreferredBackBufferWidth;
            hudHeight = Main.Camera.main.GetOffset().Y;
            mapHandler = new MapUIHandler(new Point(50,hudHeight-100));

            InitHUD();
        }
        public void Reset()
        {
            this.inventory = link.LinkInventory;
            this.heartImages = new List<ImageUI>();
            inventoryImages = new List<ImageUI>();
            healthDrawn = 0;
            hudWidth = Game1.instance._graphics.PreferredBackBufferWidth;
            hudHeight = Main.Camera.main.GetOffset().Y;
            mapHandler = new MapUIHandler(new Point(50, hudHeight - 100));
            InitHUD();
        }
        public void InitHUD()
        {

            hudBlackBackground = new ImageUI(HUDSpriteFactory.instance.GetNewBlackBlockSprite(), new Point(0, 0), new Point(Game1.instance._graphics.PreferredBackBufferWidth, hudHeight));
            lifeText = new TextSprite(HUDSpriteFactory.instance.hudFont, "--LIFE--", Color.Red, new Point(Game1.instance._graphics.PreferredBackBufferWidth-175, hudHeight - 100));
            levelText = new TextSprite(HUDSpriteFactory.instance.hudFont, Game1.instance.GetDungeon().GetDungeonName(), Color.White, new Point(10, hudHeight - 165));

            aSlotBackground = new ImageUI(HUDSpriteFactory.instance.GetNewBlueBorderSprite(), lifeText.GetPosition() + new Point(-200,0), new Point(40,75));
            bSlotBackground = new ImageUI(HUDSpriteFactory.instance.GetNewBlueBorderSprite(), aSlotBackground.DestRect.Location + new Point(65, 0), new Point(40, 75));            

            slotBText = new TextSprite(HUDSpriteFactory.instance.hudFont, "X", Color.White, bSlotBackground.DestRect.Location + new Point(12, -25));
            slotAText = new TextSprite(HUDSpriteFactory.instance.hudFont, "Z", Color.White, aSlotBackground.DestRect.Location + new Point(12, -25));

            rupeeAmtText = new TextSprite(HUDSpriteFactory.instance.hudFont, "x", Color.White, slotAText.GetPosition() + new Point(-75, 0));
            keyAmtText = new TextSprite(HUDSpriteFactory.instance.hudFont, "x", Color.White, rupeeAmtText.GetPosition() + new Point(0, 30));
            bombAmtText = new TextSprite(HUDSpriteFactory.instance.hudFont, "x", Color.White, keyAmtText.GetPosition() + new Point(0, 30));

            rupeeImage = new ImageUI(HUDSpriteFactory.instance.GetNewRupeeSprite(), rupeeAmtText.GetPosition() + new Point(-26, 0), new Point(25, 25));
            keyImage = new ImageUI(HUDSpriteFactory.instance.GetNewKeySprite(), keyAmtText.GetPosition() + new Point(-26, 0), new Point(25, 25));
            bombImage = new ImageUI(HUDSpriteFactory.instance.GetNewBombSprite(), bombAmtText.GetPosition() + new Point(-26, 0), new Point(25, 25));


            fullInventoryBackground = new ImageUI(HUDSpriteFactory.instance.GetNewInventoryBackgroundSprite(), new Point(0, 0), new Point(256*4, 88*4));
            //inventoryText = new TextSprite(HUDSpriteFactory.instance.hudFont, "INVENTORY", Color.Red, new Point(75, 75));
            //inventoryBackground = new ImageUI(HUDSpriteFactory.instance.GetNewBlueSquareBorderSprite(), inventoryText.GetPosition() + new Point(200,50), new Point(300, 150));
            inventoryCursor = new ImageUI(HUDSpriteFactory.instance.GetInventoryCursorSprite(), new Point(128 * 4, 48 * 4), new Point(64, 64));

            for (int i = 0; i < link.maxHealth; i+=2)
            {
                ISprite currentHeartType;
                if (link.Health - i > 1)
                {
                    currentHeartType = HUDSpriteFactory.instance.GetNewHeartSprite();
                    healthDrawn += 2;
                }
                else if (link.Health - i == 1)
                {
                    currentHeartType = HUDSpriteFactory.instance.GetNewHalfHeartSprite();
                    healthDrawn += 1;
                }
                else
                {
                    currentHeartType = HUDSpriteFactory.instance.GetNewEmptyHeartSprite();
                }

                heartImages.Add(new ImageUI(currentHeartType, new Point(Game1.instance._graphics.PreferredBackBufferWidth - 200 + (heartImages.Count % 5) * 30, hudHeight - 65 + (heartImages.Count / 5) * 30), new Point(25, 25)));
            }

        }
        public void Update(GameTime gameTime)
        {
            mapHandler.linkHasMap = link.LinkInventory.GetMapState();
            mapHandler.linkHasCompass = link.LinkInventory.GetCompassState();
            updateLinkHealth();

            inventoryImages.Clear();
            List<AbstractItem> itemList = inventory.GetItemList();
            for (int i = 1; i < itemList.Count; i++)
            {
                ImageUI itemImage = new ImageUI(HUDSpriteFactory.instance.GetUIItemSprite(itemList[i]), new Point(132 * 4, 48 * 4) + new Point(((i - 1) % 4) * 64, ((i - 1) / 4) * 64), new Point(32, 64));
                if (itemList[i] is BowItem) {
                    itemImage = new ImageUI(HUDSpriteFactory.instance.GetUIItemSprite(new ArrowItem(Point.Zero)), new Point(132 * 4 - 16, 48 * 4) + new Point(((i - 1) % 4) * 64, ((i - 1) / 4) * 64), new Point(32, 64));
                    inventoryImages.Add(itemImage);
                    itemImage = new ImageUI(HUDSpriteFactory.instance.GetUIItemSprite(itemList[i]), new Point(132 * 4 + 16, 48 * 4) + new Point(((i - 1) % 4) * 64, ((i - 1) / 4) * 64), new Point(32, 64));

                }
                inventoryImages.Add(itemImage);
            }

            this.slotAItemImage = new ImageUI(HUDSpriteFactory.instance.GetUIItemSprite(inventory.getSlotA()), this.aSlotBackground.GetPosition() + new Point(5, 5), this.aSlotBackground.DestRect.Size - new Point(5, 5));

            if (!(inventory.getSlotB() is null))
            {
                this.slotBItemImage = new ImageUI(HUDSpriteFactory.instance.GetUIItemSprite(inventory.getSlotB()), this.bSlotBackground.GetPosition() + new Point(5, 5), this.bSlotBackground.DestRect.Size - new Point(5, 5));
                activeItem = new ImageUI(HUDSpriteFactory.instance.GetUIItemSprite(inventory.getSlotB()), new Point(68*4,48*4), new Point(32, 64));
            }
            else {
                slotBItemImage = null;
                activeItem = null;
            }

            this.rupeeAmtText.SetText("X" + link.LinkInventory.GetRupeeCount());
            this.keyAmtText.SetText("X" + link.LinkInventory.GetKeyCount());
            this.bombAmtText.SetText("X" + link.LinkInventory.GetBombCount());

            mapHandler.Update(gameTime);
        }

        private void updateLinkHealth()
        {
            if (link.Health != healthDrawn)
            {
                heartImages.Clear();

                for (int i = 0; i < link.maxHealth; i += 2)
                {
                    ISprite currentHeartType;
                    if (link.Health - i > 1)
                    {
                        currentHeartType = HUDSpriteFactory.instance.GetNewHeartSprite();
                        healthDrawn += 2;
                    }
                    else if (link.Health - i == 1)
                    {
                        currentHeartType = HUDSpriteFactory.instance.GetNewHalfHeartSprite();
                        healthDrawn += 1;
                    }
                    else
                    {
                        currentHeartType = HUDSpriteFactory.instance.GetNewEmptyHeartSprite();
                    }

                    heartImages.Add(new ImageUI(currentHeartType, new Point(Game1.instance._graphics.PreferredBackBufferWidth - 200 + (heartImages.Count % 5) * 30, hudHeight - 65 + (heartImages.Count / 5) * 30), new Point(25, 25)));
                }
            }
        }
        public void Draw(SpriteBatch batch)
        {
            hudBlackBackground.Draw(batch);

            foreach(ImageUI image in heartImages)
            {
                image.Draw(batch);
            }

            levelText.Draw(batch);
            mapHandler.Draw(batch);

            aSlotBackground.Draw(batch);
            slotAText.Draw(batch);

            bSlotBackground.Draw(batch);
            slotBText.Draw(batch);


            this.slotAItemImage.Draw(batch);
            
            if (slotBItemImage != null) 
            {
                this.slotBItemImage.Draw(batch);
            }

            rupeeImage.Draw(batch);
            keyImage.Draw(batch);
            bombImage.Draw(batch);

            rupeeAmtText.Draw(batch);
            keyAmtText.Draw(batch);
            bombAmtText.Draw(batch);

            lifeText.Draw(batch);
            if (fullHUD)
            {
                fullInventoryBackground.Draw(batch);

                //this.inventoryBackground.Draw(batch);
                //this.inventoryText.Draw(batch);
                inventoryCursor.Draw(batch);
                if (activeItem != null) {
                    activeItem.Draw(batch);
                }
               foreach(ImageUI image in inventoryImages)
                {
                    image.Draw(batch);
                }
            }
        }
        public void ToggleFullscreen()
        {
            fullHUD = !fullHUD;
            Point change = new Point(0, Game1.instance._graphics.PreferredBackBufferHeight - hudHeight);
            if (fullHUD)
            {
                hudBlackBackground.DestRect = new Rectangle(hudBlackBackground.DestRect.Location, new Point(hudBlackBackground.DestRect.Width, Game1.instance._graphics.PreferredBackBufferHeight));
                lifeText.SetPosition(lifeText.GetPosition() + change);
                foreach(ImageUI image in heartImages)
                {
                    image.SetPosition(image.GetPosition() + change);
                }

                levelText.SetPosition(levelText.GetPosition() + change);
                mapHandler.UpdatePosition(change);

                aSlotBackground.SetPosition(aSlotBackground.GetPosition() + change);
                slotAText.SetPosition(slotAText.GetPosition() + change);
                if (slotAItemImage != null) {
                    slotAItemImage.SetPosition(slotAItemImage.GetPosition() + change);
                }
                bSlotBackground.SetPosition(bSlotBackground.GetPosition() + change);
                slotBText.SetPosition(slotBText.GetPosition() + change);
                if (slotBItemImage != null) {
                    slotBItemImage.SetPosition(slotBItemImage.GetPosition() + change);
                }
                hoveredItem = inventory.getSlotBIndex();

                rupeeImage.SetPosition(rupeeImage.GetPosition() + change);
                keyImage.SetPosition(keyImage.GetPosition() + change);
                bombImage.SetPosition(bombImage.GetPosition() + change);

                rupeeAmtText.SetPosition(rupeeAmtText.GetPosition() + change);
                keyAmtText.SetPosition(keyAmtText.GetPosition() + change);
                bombAmtText.SetPosition(bombAmtText.GetPosition() + change);
            }
            else
            {
                change = new Point(-change.X, -change.Y);

                hudBlackBackground.DestRect = new Rectangle(hudBlackBackground.DestRect.Location, new Point(hudBlackBackground.DestRect.Width, hudHeight));
                lifeText.SetPosition(lifeText.GetPosition() + change);
                foreach (ImageUI image in heartImages)
                {
                    image.SetPosition(image.GetPosition() + change);
                }
                levelText.SetPosition(levelText.GetPosition() + change);
                mapHandler.UpdatePosition(change);
                aSlotBackground.SetPosition(aSlotBackground.GetPosition() + change);
                slotAText.SetPosition(slotAText.GetPosition() + change);
                if (slotAItemImage != null) {
                    slotAItemImage.SetPosition(slotAItemImage.GetPosition() + change);
                }
                bSlotBackground.SetPosition(bSlotBackground.GetPosition() + change);
                slotBText.SetPosition(slotBText.GetPosition() + change);
                if (slotBItemImage != null) {
                    slotBItemImage.SetPosition(slotBItemImage.GetPosition() + change);
                }

                rupeeImage.SetPosition(rupeeImage.GetPosition() + change);
                keyImage.SetPosition(keyImage.GetPosition() + change);
                bombImage.SetPosition(bombImage.GetPosition() + change);

                rupeeAmtText.SetPosition(rupeeAmtText.GetPosition() + change);
                keyAmtText.SetPosition(keyAmtText.GetPosition() + change);
                bombAmtText.SetPosition(bombAmtText.GetPosition() + change);
            }
        }

        public void moveCursorUp()
        {
            if (hoveredItem / 4 >= 1) {
                hoveredItem -= 4;
            }
            inventoryCursor.SetPosition(new Point(128 * 4, 48 * 4) + new Point((hoveredItem % 4) * 64, (hoveredItem / 4) * 64));
        }

        public void moveCursorDown()
        {
            if (hoveredItem / 4 < 1 && hoveredItem + 4 < inventory.GetItemList().Count - 1) {
                hoveredItem += 4;
            }
            inventoryCursor.SetPosition(new Point(128 * 4, 48 * 4) + new Point((hoveredItem % 4) * 64, (hoveredItem / 4) * 64));
        }

        public void moveCursorLeft()
        {
            if (hoveredItem > 0) {
                --hoveredItem;
            }
            inventoryCursor.SetPosition(new Point(128 * 4, 48 * 4) + new Point((hoveredItem % 4) * 64, (hoveredItem / 4) * 64));
        }

        public void moveCursorRight()
        {
            if (hoveredItem < inventory.GetItemList().Count - 2) {
                ++hoveredItem;
            }
            inventoryCursor.SetPosition(new Point(128 * 4, 48 * 4) + new Point((hoveredItem % 4) * 64, (hoveredItem / 4) * 64));
        }

        public void selectItem()
        {
            if (!(inventory.GetItemList()[hoveredItem + 1] is null)) {
                inventory.setSlotB(inventory.GetItemList()[hoveredItem + 1]);
                activeItem = new ImageUI(HUDSpriteFactory.instance.GetUIItemSprite(inventory.getSlotB()), new Point(68 * 4, 48 * 4), new Point(32, 64));
                slotBItemImage = new ImageUI(HUDSpriteFactory.instance.GetUIItemSprite(inventory.getSlotB()), this.bSlotBackground.GetPosition() + new Point(5, 5), this.bSlotBackground.DestRect.Size - new Point(5, 5));
            }
        }

    }
}
