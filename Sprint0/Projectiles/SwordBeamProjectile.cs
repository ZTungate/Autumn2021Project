using Microsoft.Xna.Framework;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Projectiles
{
    public class SwordBeamProjectile : AbstractProjectile
    {
        public SwordBeamProjectile(Point position, Point velocity) : base(position, velocity, new Point(0,0))
        {
            //Fireballs have a life of 4 seconds (measured in milliseconds, could be changed).
            Life = 1000;
        }
        public override void Update(GameTime gameTime)
        {
            //Move the sword beam according to its velocity.

            DestRect = new Rectangle(DestRect.Location + Velocity, DestRect.Size);

            Sprite.Update(gameTime);

            Life -= gameTime.ElapsedGameTime.Milliseconds;

            if (Life < 1)
            {
                //spawn sword beam explosions?
            }
        }
    }
}
