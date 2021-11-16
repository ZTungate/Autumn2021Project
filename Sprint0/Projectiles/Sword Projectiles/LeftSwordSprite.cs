using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class LeftSwordSprite : AbstractSprite
    {
        public LeftSwordSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[4])
        {
            SourceRect[0] = new Rectangle(10, 154, 16, 16);  //Set the frame for sword
            SourceRect[1] = new Rectangle(45, 154, 16, 16);  //Set the frame for sword
            SourceRect[2] = new Rectangle(80, 154, 16, 16);  //Set the frame for sword
            SourceRect[3] = new Rectangle(115, 154, 16, 16);  //Set the frame for sword
            this.Interval = ProjectileConstants.swordBeamAnimInterval;
            this.effects = SpriteEffects.FlipHorizontally;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }

}
