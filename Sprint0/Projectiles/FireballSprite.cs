using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class FireballSprite : AbstractSprite
    {
        public Vector2 Position { get; set; }

        public FireballSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[4])
        {
            //Set the two frames for the bat animation
            SourceRect[0] = new Rectangle(231, 59, 8, 16);
            SourceRect[1] = new Rectangle(240, 59, 8, 16);
            SourceRect[2] = new Rectangle(249, 59, 8, 16);
            SourceRect[3] = new Rectangle(258, 59, 8, 16);
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
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame].Width * (int)LinkConstants.scaleX, SourceRect[CurrentFrame].Height * (int)LinkConstants.scaleY);
            spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);
        }*/
    }
}
