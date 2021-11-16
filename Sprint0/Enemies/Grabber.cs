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
                    DestRect = new Rectangle(RandomMove(), DestRect.Size);
                }
                //Decrement the invincibility timer if there is time on it
                if (InvincibilityTimer > 0)
                {
                    InvincibilityTimer -= gameTime.ElapsedGameTime.Milliseconds;
                }
            }
            else
            {
                StunTimer -= gameTime.ElapsedGameTime.Milliseconds;
            }
        }

        public Point RandomMove()
        {
            Point newPosition = this.DestRect.Location;

            //Get a random number from 0-3
            Random rand = new Random();
            int i = rand.Next(RANDMOVE);

            if (i == 0)
            {
                newPosition.X += EnemyConstants.grabberMoveSpeed;
            }
            else if (i == 1)
            {
                newPosition.Y += EnemyConstants.grabberMoveSpeed;
            }
            else if (i == 2)
            {
                newPosition.X -= EnemyConstants.grabberMoveSpeed;
            }
            else
            {
                newPosition.Y -= EnemyConstants.grabberMoveSpeed;
            }
            return newPosition;
        }

    }
}
