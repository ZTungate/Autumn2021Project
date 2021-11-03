using Microsoft.Xna.Framework;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Projectiles
{
    public class SwordBeamExplosionProjectile : AbstractProjectile
    {

        public SwordBeamExplosionProjectile(Point position, Point velocity) : base(position, velocity, new Point(0,0))
        {
            Life = 400;
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
