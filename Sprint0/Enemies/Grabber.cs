using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Enemies;
using Poggus.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Enemies
{
    public class Grabber : AbstractEnemy
    {
        const int RANDMOVE = 4;
        private bool vertical;
        public Grabber(Point pos) : base(EnemyType.Grabber, pos, new Point(32, 32))
        {
            Health = EnemyConstants.grabberHealth;
        }
        public override void Update(GameTime gameTime)
        {
            if (StunTimer <= 0)
            {
                //Get the number for the last frame
                int lastFrame = Sprite.CurrentFrame;
                oldPosition = DestRect.Location;

                //Update the sprite
                Sprite.Update(gameTime);

                //Move the grabber if the animation frame changed
                if (lastFrame != Sprite.CurrentFrame)
                {
                    if (vertical) {
                        DestRect = new Rectangle(YMove(), DestRect.Size);
                    }
                    else
                    {
                        DestRect = new Rectangle(XMove(), DestRect.Size);
                    }

                }
                //Decrement the invincibility timer if there is time on it
                if (InvincibilityTimer > 0)
                {
                    InvincibilityTimer -= gameTime.ElapsedGameTime.Milliseconds;
                }
                ColliderRect = new Rectangle(DestRect.Location + new Point(4, (int)(DestRect.Height / 2f) - 4), new Point(DestRect.Width - 4, (int)(DestRect.Height / 2f)));

            }
            else if (StunTimer == EnemyConstants.grabberFlipTrigger)
            {
                //If given a specific stunTime, flip movement axis
                vertical = !vertical;
                StunTimer = 0;
            }
            else
            {
                StunTimer -= gameTime.ElapsedGameTime.Milliseconds;
            }
        }

        private Point XMove()
        {
            //Get the current position and a random number.
            Point newPosition = this.DestRect.Location;
            Random rand = new Random();
            int i = rand.Next(RANDMOVE);


            //Move left, right, or not at all based on the random number generated.
            if (i == 0)
            {
                newPosition.X += EnemyConstants.grabberMoveSpeed;
            }
            else if (i == 1)
            {
                newPosition.X -= EnemyConstants.grabberMoveSpeed;
            }
            return newPosition;
        }

        private Point YMove()
        {
            //Get the current position and a random number.
            Point newPosition = this.DestRect.Location;
            Random rand = new Random();
            int i = rand.Next(RANDMOVE);

            //Move up, down, or not at all based on the random number generated.
            if (i == 0)
            {
                newPosition.Y += EnemyConstants.grabberMoveSpeed;
            }
            else if (i == 1)
            {
                newPosition.Y -= EnemyConstants.grabberMoveSpeed;
            }

            return newPosition;
        }

    }
}
