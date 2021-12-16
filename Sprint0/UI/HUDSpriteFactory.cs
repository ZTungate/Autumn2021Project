using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Poggus.UI.UISprites;

namespace Poggus.UI
{
    public class HUDSpriteFactory
    {
        public static HUDSpriteFactory instance = new HUDSpriteFactory();
        public SpriteFont hudFont;
        public Texture2D hudSpriteSheet;
        public Texture2D inventoryCursorSheet;

        public void LoadContent(ContentManager content)
        {
            hudFont = content.Load<SpriteFont>("Arial");
            hudSpriteSheet = content.Load<Texture2D>("HUDSpriteSheet");
            inventoryCursorSheet = content.Load<Texture2D>("NES - The Legend of Zelda - HUD & Pause Screen");
        }
        public ISprite GetNewBlueBlockSprite()
        {
            return new BlueBlockSprite(hudSpriteSheet);
        }
        public ISprite GetNewBlackBlockSprite()
        {
            return new BlackBlockSprite(hudSpriteSheet);
        }
        public ISprite GetNewGreenBlockSprite()
        {
            return new GreenBlockSprite(hudSpriteSheet);
        }
        public ISprite GetNewRedBlockSprite()
        {
            return new RedBlockSprite(hudSpriteSheet);
        }
        public ISprite GetNewHeartSprite()
        {
            ISprite sprite = Poggus.Items.ItemSprites.ItemSpriteFactory.Instance.GetItemSprite(Items.ItemEnum.Heart);
            sprite.IsUISprite = true;
            return sprite;
        }

        public ISprite GetNewHalfHeartSprite()
        {
            ISprite sprite = Poggus.Items.ItemSprites.ItemSpriteFactory.Instance.GetItemSprite(Items.ItemEnum.HalfHeart);
            sprite.IsUISprite = true;
            return sprite;
        }

        public ISprite GetNewEmptyHeartSprite()
        {
            ISprite sprite = Poggus.Items.ItemSprites.ItemSpriteFactory.Instance.GetItemSprite(Items.ItemEnum.EmptyHeart);
            sprite.IsUISprite = true;
            return sprite;
        }

        public ISprite GetNewBombSprite()
        {
            ISprite sprite = Poggus.Items.ItemSprites.ItemSpriteFactory.Instance.GetItemSprite(Items.ItemEnum.Bomb);
            sprite.IsUISprite = true;
            return sprite;
        }
        public ISprite GetNewKeySprite()
        {
            ISprite sprite = Poggus.Items.ItemSprites.ItemSpriteFactory.Instance.GetItemSprite(Items.ItemEnum.Key);
            sprite.IsUISprite = true;
            return sprite;
        }
        public ISprite GetNewRupeeSprite()
        {
            ISprite sprite = Poggus.Items.ItemSprites.ItemSpriteFactory.Instance.GetItemSprite(Items.ItemEnum.Rupee);
            sprite.IsUISprite = true;
            return sprite;
        }
        public ISprite GetUIItemSprite(Poggus.Items.IItem item)
        {
            ISprite sprite = Poggus.Items.ItemSprites.ItemSpriteFactory.Instance.GetItemSprite(item.itemType);
            sprite.IsUISprite = true;
            return sprite;
        }

        public ISprite GetInventoryCursorSprite()
        {
            return new InventoryCursorSprite(inventoryCursorSheet);
        }
        public ISprite GetNewBlueBorderSprite()
        {
            return new BlueBorderSprite(hudSpriteSheet);
        }
        public ISprite GetNewBlueSquareBorderSprite()
        {
            return new BlueSquareBorderSprite(hudSpriteSheet);
        }

        public ISprite GetNewInventoryBackgroundSprite()
        {
            return new InventoryBackgroundSprite(inventoryCursorSheet);
        }
    }
}
