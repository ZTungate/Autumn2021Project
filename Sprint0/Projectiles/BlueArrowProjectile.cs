using Microsoft.Xna.Framework;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Projectiles
{
    public class BlueArrowProjectile : AbstractProjectile
    {
        public BlueArrowProjectile(Point position, Point velocity, Point size) : base(position, velocity, size)
        {
            Life = 1000;
        }
        public override void Update(GameTime gameTime)
        {
            //Move the arrow according to its velocity.
            if (Life > 200)
            {
                DestRect = new Rectangle(DestRect.Location + Velocity, DestRect.Size);

            }
            Sprite.Update(gameTime);

            Life -= gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}
