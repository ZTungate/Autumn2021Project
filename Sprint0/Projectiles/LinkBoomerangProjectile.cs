using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Poggus;
using Poggus.Helpers;
using Poggus.Player;
using Poggus.Sound;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Projectiles
{
    public class LinkBoomerangProjectile : AbstractProjectile
    {
        Point direction;
        ILink myLink;
        bool returning;
        SoundEffectInstance boomerangSound;
        public SoundManager soundManager { get; set; }

        public LinkBoomerangProjectile(Point position, Point velocity, ILink link) : base(position, velocity, ProjectileConstants.boomerangSize)
        {
            myLink = link;
            Life = ProjectileConstants.boomerangLife;
        }
        public override void Update(GameTime gameTime)
        {
            //Move the boomerang according to its velocity.
            DestRect = new Rectangle(DestRect.Location + Velocity, DestRect.Size);
            Sprite.Update(gameTime);


            if (returning)
            {
                //Move the direction to be returning to link.
                getDirection();
                Velocity = ProjectileConstants.linkBoomerangVelocity * direction;
            }
            else
            {
                //Cut the projectile's life by the elapsed time
                int timePassed = gameTime.ElapsedGameTime.Milliseconds;
                Life -= timePassed;

                //If the boomerang's life is half over, send it back to link
                if (Life <= ProjectileConstants.boomerangLife / 2)
                {
                    returning = true;
                }
            }
        }

        private void getDirection()
        {
            Point linkCenter = LocationHelpers.GetCenter(myLink.DestRect);
            Point myCenter = LocationHelpers.GetCenter(DestRect);
            Point distance = myCenter - linkCenter;
            //Get a direction vector to best travel towards link
            if(distance.X < 0)
            {
                direction.X = 1;
            }
            else if(distance.X > 0)
            {
                direction.X = -1;
            }
            else
            {
                direction.X = 0;
            }

            if(distance.Y < 0)
            {
                direction.Y = 1;
            }
            else if(distance.Y > 0)
            {
                direction.Y = -1;
            }
            else
            {
                direction.Y = 0;
            }

        }
    }
}