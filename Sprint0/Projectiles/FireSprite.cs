using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class FireSprite : AbstractSprite
    {
        public int counter = 2;
        public FireSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            //Set the 8 source rectangles for the boomerang animation
            SourceRect[0] = new Rectangle(191, 185, 16, 16);

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
