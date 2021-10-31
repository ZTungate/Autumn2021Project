using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Enemies;

namespace Sprint2
{
    public class SkeletonSprite : AbstractSprite
    {
        public SkeletonSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[2])
        {
            //Set the two frames for the skeleton animation
            SourceRect[0] = new Rectangle(404, 59, 16, 16);
            SourceRect[1] = new Rectangle(423, 59, 16, 16);

            this.Interval = 120;
            //Dummy position, needs to be fixed by adding pos relevant to the enemy. TODO fix
            //Position = new Vector2(500,100);
        }

        public override void Update(GameTime gameTime)
        {
            //Animate the sprites (pulled from animatedStillSprite.cs)
            this.FrameStep(gameTime);
        }
        /*public void Draw(SpriteBatch spriteBatch)
        {
            //Draw enemy at its position at twice its source size.
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, (int)(SourceRect[CurrentFrame].Width * EnemyConstants.scaleX), (int)(SourceRect[CurrentFrame].Height * EnemyConstants.scaleY));
            spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);
        }*/

    }
}
