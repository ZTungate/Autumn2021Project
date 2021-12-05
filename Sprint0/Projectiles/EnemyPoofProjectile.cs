using Microsoft.Xna.Framework;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Projectiles
{
    public class EnemyPoofProjectile : AbstractProjectile
    {
        public EnemyPoofProjectile(Point position,Point size) : base(position, Point.Zero, size)
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
