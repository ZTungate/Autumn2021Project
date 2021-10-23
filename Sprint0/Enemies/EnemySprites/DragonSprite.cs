using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class DragonSprite : AbstractSprite
    {
        public DragonSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[4])
        {
            //Set the two frames for the slime animation
            SourceRect[0] = new Rectangle(1, 11, 24, 32);
            SourceRect[1] = new Rectangle(26, 11, 24, 32);
            SourceRect[2] = new Rectangle(51, 11, 24, 32);
            SourceRect[3] = new Rectangle(76, 11, 24, 32);

            //Dummy position, needs to be fixed by adding pos relevant to the enemy.
            //Position = new Vector2(500, 100);
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }
}
