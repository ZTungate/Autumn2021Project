using Microsoft.Xna.Framework;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Projectiles
{
    public class SwordBeamProjectile : AbstractProjectile
    {
        public SwordBeamProjectile(Point position, Point velocity, Point size) : base(position, velocity, size)
        {
            Life = ProjectileConstants.swordBeamLife;
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
