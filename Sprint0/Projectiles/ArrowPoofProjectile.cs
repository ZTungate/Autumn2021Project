using Microsoft.Xna.Framework;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Projectiles
{
    public class ArrowPoofProjectile : AbstractProjectile
    {
        public ArrowPoofProjectile(Point position) : base(position, Point.Zero, ProjectileConstants.arrowPoofSize)
        {
            Life = ProjectileConstants.arrowPoofLife;
        }
        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);

            //Cut the projectile's life by the elapsed time
            int timePassed = gameTime.ElapsedGameTime.Milliseconds;
            Life -= timePassed;

        }
    }
}
