using Microsoft.Xna.Framework;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Projectiles
{
    public class SwordBeamExplosionProjectile : AbstractProjectile
    {
        public SwordBeamExplosionProjectile(Point position, Point velocity) : base(position, velocity, ProjectileConstants.swordBeamExplosionSize)
        {
            Life = ProjectileConstants.swordBeamBurstLife;
        }
        public override void Update(GameTime gameTime)
        {
            //Move the sword beam according to its velocity.

            DestRect = new Rectangle(DestRect.Location + Velocity, DestRect.Size);

            Sprite.Update(gameTime);

            Life -= gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}
