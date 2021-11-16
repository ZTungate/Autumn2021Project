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
        public Bat(Point position) : base(EnemyType.Bat, position, new Point(32,32))
        {
            Health = EnemyConstants.batHealth;
        }

        public override void Update(GameTime gameTime)
        {
            //Update the enemy if not stunned
            if (StunTimer <= 0)
            {
                oldPosition = this.DestRect.Location;

                int lastFrame = Sprite.CurrentFrame;
                Sprite.Update(gameTime);

                //Move the bat if the animation frame changed
                if (lastFrame != Sprite.CurrentFrame)
                {
                    this.DestRect = new Rectangle(BatRandomMove(), DestRect.Size);
                }
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