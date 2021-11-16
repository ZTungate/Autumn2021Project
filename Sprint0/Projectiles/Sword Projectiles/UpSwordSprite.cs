using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class UpSwordSprite : AbstractSprite
    {
        public UpSwordSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[4])
        {
            SourceRect[0] = new Rectangle(1, 154, 8, 16);  //Set the frame for sword
            SourceRect[1] = new Rectangle(36, 154, 8, 16);
            SourceRect[2] = new Rectangle(71, 154, 8, 16);
            SourceRect[3] = new Rectangle(106, 154, 8, 16);
            this.Interval = ProjectileConstants.swordBeamAnimInterval;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }

}
