using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class DownLeftSwordExplosionSprite : AbstractSprite
    {
        public DownLeftSwordExplosionSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[4])
        {
            SourceRect[0] = new Rectangle(27, 154, 8, 16);  //Set the frame for sword
            SourceRect[1] = new Rectangle(62, 154, 8, 16);
            SourceRect[2] = new Rectangle(97, 154, 8, 16);
            SourceRect[3] = new Rectangle(132, 154, 8, 16);
            this.Interval = ProjectileConstants.swordBeamAnimInterval;
            this.effects = SpriteEffects.FlipVertically;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }

}
