using Microsoft.Xna.Framework;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Projectiles
{
    public class SwordBeamProjectile : AbstractProjectile
    {
        ProjectileFactory pFactory;
        public SwordBeamProjectile(Point position, Point velocity, Point size, ProjectileFactory projectileFactory) : base(position, velocity, size)
        {
            Life = ProjectileConstants.swordBeamLife;
            pFactory = projectileFactory;
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
