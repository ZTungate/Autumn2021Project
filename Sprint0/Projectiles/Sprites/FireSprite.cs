using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using Poggus.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class FireSprite : AbstractSprite
    {
        public int counter = 0;
        public FireSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            //Set the 8 source rectangles for the boomerang animation
            SourceRect[0] = new Rectangle(191, 185, 16, 16);

        }
        public float flipTime = ProjectileConstants.fireFlipInterval;
        public override void Update(GameTime gameTime)
        {
            if(flipTime <= 0)
            {
                counter++;
                flipTime = ProjectileConstants.fireFlipInterval;
            }
            flipTime -= gameTime.ElapsedGameTime.Milliseconds;
        }
        public override void Draw(SpriteBatch spriteBatch, Rectangle rect)
        {
            switch (counter % 2) {
                case 0:
                    this.effects = SpriteEffects.None;
                    base.Draw(spriteBatch, rect);
                    break;
                case 1:
                    this.effects = SpriteEffects.FlipHorizontally;
                    base.Draw(spriteBatch, rect);
                    break;

            }
        }

    }
}
