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

        public void LoadContent(ContentManager content)
        {
            hudFont = content.Load<SpriteFont>("Arial");
            hudSpriteSheet = content.Load<Texture2D>("HUDSpriteSheet");
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
        public ISprite GetNewHeartSprite()
        {
            return Poggus.Items.ItemSprites.ItemSpriteFactory.Instance.GetItemSprite(Items.ItemEnum.Heart);
        }

    }
}
