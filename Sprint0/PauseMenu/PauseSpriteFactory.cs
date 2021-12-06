using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Poggus.PauseMenu.PauseSprites;

namespace Poggus.PauseMenu
{
    public class PauseSpriteFactory
    {
        public static PauseSpriteFactory instance = new PauseSpriteFactory();
        public Texture2D pauseSpriteSheet;

        public void LoadContent(ContentManager content)
        {
            
            pauseSpriteSheet = content.Load<Texture2D>("PauseMenuSheet");
        }
        public ISprite GetNewPauseSprite()
        {
            return new ResumeButtonSprite(pauseSpriteSheet);
        }
        public ISprite GetNewOptionsSprite()
        {
            return new OptionsButtonSprite(pauseSpriteSheet);
        }

    }
}
