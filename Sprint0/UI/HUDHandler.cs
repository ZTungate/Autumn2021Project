using System;
using System.Collections.Generic;
using System.Text;
using Poggus.UI.UIObjects;
using Poggus.Player;
using Poggus.PlayerInventory;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poggus.UI
{
    public class HUDHandler
    {
        bool fullHUD;
        MapUIHandler mapHandler;
        TextSprite lifeText, levelText, rupeeAmtText, keyAmtText, bombAmtText, slotAText, slotBText, inventoryText;
        ImageUI hudBlackBackground, aSlotBackground, bSlotBackground, inventoryBackground, keyImage, bombImage, rupeeImage;
        List<ImageUI> heartImages;

        public int hudWidth, hudHeight;
        ILink link;
        Inventory inventory;
        public HUDHandler(ILink link)
        {
            this.link = link;
            this.inventory = link.LinkInventory;
            this.heartImages = new List<ImageUI>();
            hudWidth = Game1.instance._graphics.PreferredBackBufferWidth;
            hudHeight = Main.Camera.main.GetOffset().Y;
            mapHandler = new MapUIHandler(new Point(50,hudHeight-100));

            InitHUD();
        }
        public void Reset()
        {
            this.inventory = link.LinkInventory;
            this.heartImages = new List<ImageUI>();
            hudWidth = Game1.instance._graphics.PreferredBackBufferWidth;
            hudHeight = Main.Camera.main.GetOffset().Y;
            mapHandler = new MapUIHandler(new Point(50, hudHeight - 100));

            InitHUD();
        }
        public void InitHUD()
        {
            this.hudBlackBackground = new ImageUI(HUDSpriteFactory.instance.GetNewBlackBlockSprite(), new Point(0, 0), new Point(Game1.instance._graphics.PreferredBackBufferWidth, hudHeight));
            this.lifeText = new TextSprite(HUDSpriteFactory.instance.hudFont, "--LIFE--", Color.Red, new Point(Game1.instance._graphics.PreferredBackBufferWidth-175, hudHeight - 100));
            this.levelText = new TextSprite(HUDSpriteFactory.instance.hudFont, Game1.instance.GetDungeon().GetDungeonName(), Color.White, new Point(10, hudHeight - 165));

            for (int i = 0; i < link.Health; i++)
            {
                ISprite heartSprite = HUDSpriteFactory.instance.GetNewHeartSprite();
                heartSprite.IsUISprite = true;
                heartImages.Add(new ImageUI(heartSprite, new Point(Game1.instance._graphics.PreferredBackBufferWidth - 200 + i * 30, hudHeight - 65), new Point(25,25)));
            }
        }
        public void Update(GameTime gameTime)
        {
            if(link.Health < heartImages.Count && heartImages.Count > 0)
            {
                for(int i = heartImages.Count - 1; i >= link.Health; i--)
                {
                    heartImages.RemoveAt(i);
                }
            }
            mapHandler.Update(gameTime);
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

            /*aSlotBackground.Draw(batch);
            slotAText.Draw(batch);

            bSlotBackground.Draw(batch);
            slotBText.Draw(batch);

            levelText.Draw(batch);
            */
            lifeText.Draw(batch);
            if (fullHUD)
            {

            }
        }
    }
}
