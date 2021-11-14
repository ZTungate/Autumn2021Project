using Microsoft.Xna.Framework;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Projectiles
{
    public class BoomerangProjectile : AbstractProjectile
    {
        bool returning = false;

        public BoomerangProjectile(Point position, Point velocity) : base(position, velocity, ProjectileConstants.boomerangSize)
        {
            Life = ProjectileConstants.boomerangLife;
            Velocity = velocity;
        }
        public override void Update(GameTime gameTime)
        {
            if(Life <= ProjectileConstants.boomerangLife / 2 && !returning)
            {
                //Return the boomerang if half of its life is over.
                ReturnBoomerang();
            }

            //Move the boomerang according to its velocity.
            DestRect = new Rectangle(DestRect.Location + Velocity, DestRect.Size);
            //DestRect = new Rectangle((int)(DestRect.X + myVelocity.X), (int)(DestRect.Y + myVelocity.Y), DestRect.Width, DestRect.Height);
            Sprite.Update(gameTime);

            //Cut the projectile's life by the elapsed time
            int timePassed = gameTime.ElapsedGameTime.Milliseconds;
            Life -= timePassed;
        }

        private void ReturnBoomerang(){
            Velocity = new Point(-Velocity.X,-Velocity.Y);
            returning = true;
        }
    }
}