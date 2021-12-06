using Microsoft.Xna.Framework;
using Poggus.Helpers;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Enemies
{
    public class Bat : AbstractEnemy
    {
        const int RANDMOVE = 4;
        public Bat(Point position) : base(EnemyType.Bat, position, EnemyConstants.stdEnemySize.Size)
        {
            Health = EnemyConstants.batHealth;
        }

        public override void Update(GameTime gameTime)
        {
            oldPosition = this.DestRect.Location;
            //Update the enemy if not stunned
            if (StunTimer <= 0)
            {

                int lastFrame = Sprite.CurrentFrame;
                Sprite.Update(gameTime);
                
                //Decrement the invincibility timer if there is time on it
                if (InvincibilityTimer > 0)
                {
                    InvincibilityTimer -= gameTime.ElapsedGameTime.Milliseconds;
                }
                //Move the bat if the animation frame changed
                if (lastFrame != Sprite.CurrentFrame)
                {
                    this.DestRect = new Rectangle(BatRandomMove(), DestRect.Size);
                }
                ColliderRect = new Rectangle(DestRect.Location + new Point(4, (int)(DestRect.Height / 2f) - 4), new Point(DestRect.Width - 4, (int)(DestRect.Height / 2f)));

            }
            else
            {
                StunTimer -= gameTime.ElapsedGameTime.Milliseconds;
            }
        }

        //Placeholder movement method, will require reworking when actual level exists.
        public Point BatRandomMove()
        {
            Point newPosition = DestRect.Location;

            //Get a random number from 0-3
            Random rand = new Random();
            int i = rand.Next(RANDMOVE);

            if (i == 0)
            {
                //Move right/Up if i = 0
                newPosition.X += EnemyConstants.batMoveSpeed;
                newPosition.Y += EnemyConstants.batMoveSpeed;
            }
            else if (i == 1)
            {
                //Move right/down if i = 1
                newPosition.X += EnemyConstants.batMoveSpeed;
                newPosition.Y -= EnemyConstants.batMoveSpeed;
            }
            else if (i == 2)
            {
                //Move left/up if i = 2
                newPosition.X -= EnemyConstants.batMoveSpeed;
                newPosition.Y += EnemyConstants.batMoveSpeed;
            }
            else if (i == 3)
            {
                //Move left/down if i = 3
                newPosition.X -= EnemyConstants.batMoveSpeed;
                newPosition.Y -= EnemyConstants.batMoveSpeed;
            }
            //Return the modified position.
            return newPosition;

        }
    }
}