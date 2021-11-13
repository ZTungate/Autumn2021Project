using Microsoft.Xna.Framework;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Projectiles
{
    public class FireballProjectile : AbstractProjectile
    {
        public FireballProjectile(Point position, Point velocity) : base(position, velocity, ProjectileConstants.fireballSize)
        {
            Life = ProjectileConstants.fireballLife;
        }
        public override void Update(GameTime gameTime)
        {
            //Move the fireball according to its velocity.
            DestRect = new Rectangle(DestRect.Location + Velocity, DestRect.Size);
            Sprite.Update(gameTime);

            Life -= gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}
