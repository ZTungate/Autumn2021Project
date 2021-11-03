using Microsoft.Xna.Framework;
using Sprint2.Helpers;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class Slime : AbstractEnemy
    {
        //Timers for updating sprite without moving
        private int interval = 40;
        private int timer = 0;

        public override void Update(GameTime gameTime)
        {
            oldPosition = GetPosition();

            Sprite.Update(gameTime);

            //Timer to prevent from moving too fast, should unify with the timer in sprite.Update();
            if (timer < interval)
            {
                timer += 5;
            }
            else
            {
                timer = 0;
                SetPosition(SlimeRandomMove());
            }
        }
        public Slime(Point pos, Point size) : base(pos, size)
        {
        }

        //Placeholder movement method, will require reworking when actual level exists.
        public Point SlimeRandomMove()
        {
            //Get the current position of the slime
            Point newPosition = GetPosition();

            //Get a random number from 0-3
            Random rand = new Random();
            int i = rand.Next(5);

            if (i == 0)
            {
                //Move right if i = 0
                newPosition.X += EnemyConstants.slimeMoveSpeed;
            }
            else if (i == 1)
            {
                //Move up if i = 1
                newPosition.Y += EnemyConstants.slimeMoveSpeed;
            }
            else if (i == 2)
            {
                //Move left if i = 2
                newPosition.X -= EnemyConstants.slimeMoveSpeed;
            }
            else if (i == 3)
            {
                //Move down if i = 3
                newPosition.Y -= EnemyConstants.slimeMoveSpeed;
            }
            //If i = 4, do nothing, the slime can stand still.
            return newPosition;
        }
    }
}