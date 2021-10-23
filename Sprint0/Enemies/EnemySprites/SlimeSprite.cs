using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class SlimeSprite : AbstractSprite
    {
        public SlimeSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[2])
        {
            //Set the two frames for the slime animation
            SourceRect[0] = new Rectangle(1, 11, 8, 16);
            SourceRect[1] = new Rectangle(10, 11, 8, 16);
            this.Interval = 40;

            //Dummy position, needs to be fixed by adding pos relevant to the enemy.
            //Position = new Vector2(500, 100);
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }

    }
}
