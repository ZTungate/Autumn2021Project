using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class FireSprite : AbstractSprite
    {
        public Vector2 Position { get; set; }

        public int scale = 2;
        public FireSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(191, 185, 16, 16);

        }

        public override void Update(GameTime gameTime)
        {
            //Animate the sprites (pulled from animatedStillSprite.cs)
            this.FrameStep(gameTime);
        }
        /*public void Draw(SpriteBatch spriteBatch)
        {
            //Draw projectile at its position at twice its source size.
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[0].Width * 2, SourceRect[0].Height * 2);
            switch (CurrentFrame) {
                case 0:
                    spriteBatch.Draw(Texture, Position, SourceRect[0], Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 1);
                    break;
                case 1:
                    spriteBatch.Draw(Texture, Position, SourceRect[0], Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.FlipHorizontally, 1);
                    break;

            }
        }*/

    }
}
