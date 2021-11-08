using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class BlueBoomerangSprite : AbstractSprite
    {
        public BlueBoomerangSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[3])
        {
            //Set the 8 source rectangles for the boomerang animation
            SourceRect[0] = new Rectangle(91, 185, 8, 16);
            SourceRect[1] = new Rectangle(100, 185, 8, 16);
            SourceRect[2] = new Rectangle(109, 185, 8, 16);
            this.Interval = 20;

        }

        public override void Update(GameTime gameTime)
        {
            //Animate the sprites (pulled from animatedStillSprite.cs)
            this.FrameStep(gameTime);
        }
        /*public void Draw(SpriteBatch spriteBatch)
        {
            //Draw projectile at its position at twice its source size.

            int cycle = TotalFrames % 8;

            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame].Width * (int)LinkConstants.scaleX, SourceRect[CurrentFrame].Height * (int)LinkConstants.scaleY);
            switch (cycle) {
                case 0:
                case 1:
                case 2:
                    spriteBatch.Draw(Texture, Position, SourceRect[CurrentFrame % FrameCount], Color.White, 0, new Vector2(0, 0), (int)LinkConstants.scaleX, SpriteEffects.None, 1);
                    break;
                case 3:
                case 4:
                    spriteBatch.Draw(Texture, Position, SourceRect[CurrentFrame % FrameCount], Color.White, 0, new Vector2(0, 0), (int)LinkConstants.scaleX, SpriteEffects.FlipHorizontally, 1);
                    break;
                case 5:
                case 6:
                    spriteBatch.Draw(Texture, Position, SourceRect[CurrentFrame % FrameCount], Color.White, 0, new Vector2(0, 0), (int)LinkConstants.scaleX, SpriteEffects.None, 1);

                    break;
                case 7:
                    spriteBatch.Draw(Texture, Position, SourceRect[CurrentFrame % FrameCount], Color.White, 0, new Vector2(0, 0), (int)LinkConstants.scaleX, SpriteEffects.FlipVertically, 1);
                    break;

            }
        }*/
    }

}
